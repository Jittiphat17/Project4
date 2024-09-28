Imports System.Data.OleDb

Public Class frmCon
    ' เพิ่ม Property สำหรับเก็บค่าเลขที่สัญญาที่ถูกส่งมาจาก frmIncome
    Public Property SelectedContractId As String

    ' เพิ่มตัวเชื่อมต่อฐานข้อมูล
    Private Conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
    ' Dictionary สำหรับเก็บการเปลี่ยนแปลงสถานะการชำระ
    Private statusChanges As New Dictionary(Of Integer, Integer)

    ' เมื่อฟอร์มโหลด
    Private Sub frmCon_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Use the SelectedContractId that was passed from frmIncome
        If Not String.IsNullOrEmpty(SelectedContractId) Then
            ' Search and display contract and payment details based on SelectedContractId
            SearchContract(SelectedContractId)
            SearchPayments(SelectedContractId)
        End If
    End Sub


    ' เมื่อคลิกปุ่มค้นหา
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ' ตรวจสอบว่ามีการกรอกเลขที่สัญญาหรือไม่
        If txtSearchContractNumber.Text.Trim() = "" Then
            MessageBox.Show("กรุณากรอกเลขที่สัญญา", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' ค้นหาและแสดงข้อมูลสัญญา
        SearchContract(txtSearchContractNumber.Text.Trim())
        ' ค้นหาและแสดงข้อมูลการชำระเงิน
        SearchPayments(txtSearchContractNumber.Text.Trim())
    End Sub

    ' ฟังก์ชันสำหรับค้นหาข้อมูลสัญญา
    Private Sub SearchContract(contractNumber As String)
        Try
            ' นิยามคำสั่ง SQL เพื่อค้นหาข้อมูลสัญญา
            Dim strSQL As String = "SELECT c.*, m.m_name FROM Contract c INNER JOIN Member m ON c.m_id = m.m_id WHERE c.con_id = @contractNumber"
            Dim cmd As New OleDbCommand(strSQL, Conn)
            cmd.Parameters.AddWithValue("@contractNumber", contractNumber)

            ' เปิดการเชื่อมต่อฐานข้อมูลหากยังไม่เปิด
            If Conn.State = ConnectionState.Open Then Conn.Close()
            Conn.Open()

            ' อ่านข้อมูลสัญญา
            Dim reader As OleDbDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                ' แสดงข้อมูลใน TextBox ต่าง ๆ และเพิ่มจุดทศนิยมสองตำแหน่งในจำนวนเงิน
                txtContractNumber.Text = reader("con_id").ToString()
                txtBorrowerName.Text = reader("m_name").ToString() ' ชื่อผู้กู้จากตาราง Member
                txtDetails.Text = reader("con_details").ToString()
                txtAmount.Text = Decimal.Parse(reader("con_amount").ToString()).ToString("N2") ' เพิ่มจุดทศนิยมสองตำแหน่ง
                txtMonths.Text = reader("con_permonth").ToString()
                txtTransactionDate.Text = DateTime.Parse(reader("con_date").ToString()).ToString("dd/MM/yyyy")
            Else
                MessageBox.Show("ไม่พบเลขที่สัญญานี้", "ไม่พบข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาด: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' ปิดการเชื่อมต่อฐานข้อมูล
            Conn.Close()
        End Try
    End Sub

    ' ฟังก์ชันสำหรับค้นหาข้อมูลการชำระเงิน
    Private Sub SearchPayments(contractNumber As String)
        Try
            ' SQL query to retrieve payment data
            Dim strSQL As String = "SELECT p.payment_id, p.con_id, p.payment_date, p.payment_amount, p.payment_prin AS Principal, p.payment_interest AS Interest, s.status_name " &
                       "FROM Payment p " &
                       "INNER JOIN Status s ON p.status_id = s.status_id " &
                       "WHERE p.con_id = @contractNumber"

            Dim cmd As New OleDbCommand(strSQL, Conn)
            cmd.Parameters.AddWithValue("@contractNumber", contractNumber)

            ' เปิดการเชื่อมต่อ
            If Conn.State = ConnectionState.Open Then Conn.Close()
            Conn.Open()

            ' Create DataTable to hold the payment data
            Dim dt As New DataTable()
            Dim adapter As New OleDbDataAdapter(cmd)
            adapter.Fill(dt)

            ' แสดงผลใน DataGridView
            dgvPayments.DataSource = dt

            ' Configure DataGridView columns
            If dgvPayments.Columns.Contains("สถานะการชำระ") Then
                dgvPayments.Columns.Remove("สถานะการชำระ")
            End If

            ' Add status combo box column
            Dim statusColumn As New DataGridViewComboBoxColumn()
            statusColumn.Name = "สถานะการชำระ"
            statusColumn.HeaderText = "สถานะการชำระ"
            statusColumn.DataPropertyName = "status_name"
            statusColumn.DataSource = GetStatusList()
            statusColumn.DisplayMember = "status_name"
            statusColumn.ValueMember = "status_name"
            dgvPayments.Columns.Add(statusColumn)

            ' Hide the status_name column
            dgvPayments.Columns("status_name").Visible = False

            ' Set header text and format columns
            dgvPayments.Columns("payment_id").HeaderText = "รหัสการชำระ"
            dgvPayments.Columns("con_id").HeaderText = "รหัสสัญญา"
            dgvPayments.Columns("payment_date").HeaderText = "วันที่ต้องชำระ"
            dgvPayments.Columns("payment_amount").HeaderText = "จำนวนเงิน"
            dgvPayments.Columns("Principal").HeaderText = "เงินต้น"
            dgvPayments.Columns("Interest").HeaderText = "ดอกเบี้ย (บาท)"

            ' Format to show two decimal places
            dgvPayments.Columns("payment_amount").DefaultCellStyle.Format = "N2"
            dgvPayments.Columns("Principal").DefaultCellStyle.Format = "N2"
            dgvPayments.Columns("Interest").DefaultCellStyle.Format = "N2"

        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาด: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Conn.Close()
        End Try
    End Sub


    ' ฟังก์ชันคำนวณการผ่อนชำระแบบดอกเบี้ยคงที่ (Flat Rate)
    Private Function CalculateFixedPayment(principal As Decimal, monthlyInterestRate As Decimal, totalPayments As Integer) As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("Principal", GetType(Decimal))
        dt.Columns.Add("Interest", GetType(Decimal))

        ' เงินต้นที่ต้องจ่ายต่อเดือน (เท่ากันทุกเดือน)
        Dim fixedPrincipalPayment As Decimal = principal / totalPayments

        ' คำนวณดอกเบี้ยเป็นจำนวนเงินในแต่ละงวด
        For i As Integer = 1 To totalPayments
            ' คำนวณดอกเบี้ยเป็นจำนวนเงิน (เงินต้น x อัตราดอกเบี้ย)
            Dim fixedInterest As Decimal = principal * monthlyInterestRate

            ' เพิ่มข้อมูลเงินต้นและดอกเบี้ย (เป็นจำนวนเงิน) ลงใน DataTable
            dt.Rows.Add(fixedPrincipalPayment, fixedInterest)
        Next

        Return dt
    End Function

    ' ฟังก์ชันสำหรับดึงข้อมูลสัญญา
    Private Function GetContractDetails(contractNumber As String) As DataTable
        Dim dt As New DataTable()
        Try
            Dim strSQL As String = "SELECT con_amount, con_interest, con_permonth FROM Contract WHERE con_id = @contractNumber"
            Dim cmd As New OleDbCommand(strSQL, Conn)
            cmd.Parameters.AddWithValue("@contractNumber", contractNumber)

            If Conn.State = ConnectionState.Open Then Conn.Close()
            Conn.Open()

            Dim adapter As New OleDbDataAdapter(cmd)
            adapter.Fill(dt)

        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาด: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Conn.Close()
        End Try
        Return dt
    End Function

    ' ฟังก์ชันสำหรับดึงรายการสถานะการชำระจากฐานข้อมูล
    Private Function GetStatusList() As DataTable
        Dim dt As New DataTable()
        Try
            Dim strSQL As String = "SELECT status_id, status_name FROM Status"
            Dim cmd As New OleDbCommand(strSQL, Conn)

            If Conn.State = ConnectionState.Open Then Conn.Close()
            Conn.Open()

            Dim adapter As New OleDbDataAdapter(cmd)
            adapter.Fill(dt)
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาด: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Conn.Close()
        End Try
        Return dt
    End Function

    ' เมื่อค่าในเซลล์ของ DataGridView มีการเปลี่ยนแปลง
    Private Sub dgvPayments_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPayments.CellValueChanged
        If e.ColumnIndex = dgvPayments.Columns("สถานะการชำระ").Index AndAlso e.RowIndex >= 0 Then
            Dim paymentId As Integer = Convert.ToInt32(dgvPayments.Rows(e.RowIndex).Cells("payment_id").Value)
            Dim newStatus As String = dgvPayments.Rows(e.RowIndex).Cells("สถานะการชำระ").Value.ToString()
            Dim statusId As Integer = GetStatusId(newStatus)

            ' บันทึกการเปลี่ยนแปลงสถานะการชำระลงใน Dictionary
            If statusChanges.ContainsKey(paymentId) Then
                statusChanges(paymentId) = statusId
            Else
                statusChanges.Add(paymentId, statusId)
            End If
        End If
    End Sub

    ' ฟังก์ชันสำหรับดึง status_id จาก status_name
    Private Function GetStatusId(statusName As String) As Integer
        Dim statusId As Integer = -1
        Try
            Dim strSQL As String = "SELECT status_id FROM Status WHERE status_name = @status_name"
            Dim cmd As New OleDbCommand(strSQL, Conn)
            cmd.Parameters.AddWithValue("@status_name", statusName)

            If Conn.State = ConnectionState.Open Then Conn.Close()
            Conn.Open()

            Dim reader As OleDbDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                statusId = Convert.ToInt32(reader("status_id"))
            End If
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาด: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Conn.Close()
        End Try
        Return statusId
    End Function

    ' เมื่อคลิกปุ่มบันทึก
    Private Sub btnSave_Click(sender As Object, e As EventArgs)
        Try
            ' ตรวจสอบให้แน่ใจว่าการเชื่อมต่อฐานข้อมูลถูกเปิด
            If Conn.State = ConnectionState.Closed Then Conn.Open()

            ' ทำการอัปเดตสถานะการชำระในฐานข้อมูล
            For Each kvp As KeyValuePair(Of Integer, Integer) In statusChanges
                Dim strSQL As String = "UPDATE Payment SET status_id = @status_id WHERE payment_id = @payment_id"
                Dim cmd As New OleDbCommand(strSQL, Conn)
                cmd.Parameters.AddWithValue("@status_id", kvp.Value)
                cmd.Parameters.AddWithValue("@payment_id", kvp.Key)
                cmd.ExecuteNonQuery()
            Next

            MessageBox.Show("บันทึกข้อมูลสำเร็จ", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            statusChanges.Clear()
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาด: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Conn.Close()
        End Try
    End Sub
End Class

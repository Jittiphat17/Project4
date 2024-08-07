Imports System.Data.OleDb

Public Class frmIncome
    ' เชื่อมต่อกับฐานข้อมูล Access
    Private Conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\db_test.mdb")

    Private Sub frmIncome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ตั้งค่า AutoComplete ให้กับ TextBox txtMemberID
        txtMemberID.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtMemberID.AutoCompleteSource = AutoCompleteSource.CustomSource
        LoadAutoCompleteData()
        LoadDepositTypes()

        ' เพิ่มคอลัมน์ใน DataGridView
        dgvIncome.Columns.Add("MemberID", "รหัสสมาชิก")
        dgvIncome.Columns.Add("Details", "รายละเอียด")
        dgvIncome.Columns.Add("Description", "คำอธิบาย")
        dgvIncome.Columns.Add("Date", "วันที่")
        dgvIncome.Columns.Add("Amount", "จำนวนเงิน")
        dgvIncome.Columns.Add("DepositType", "ประเภทเงินฝาก")
    End Sub

    ' โหลดข้อมูล AutoComplete สำหรับ TextBox txtMemberID
    Private Sub LoadAutoCompleteData()
        Try
            Conn.Open()
            Dim query As String = "SELECT m_name FROM Member"
            Using cmd As New OleDbCommand(query, Conn)
                Dim reader As OleDbDataReader = cmd.ExecuteReader()
                Dim autoComplete As New AutoCompleteStringCollection()
                While reader.Read()
                    autoComplete.Add(reader("m_name").ToString())
                End While
                txtMemberID.AutoCompleteCustomSource = autoComplete
            End Using
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการโหลดข้อมูล AutoComplete: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Conn.Close()
        End Try
    End Sub

    ' โหลดข้อมูลประเภทเงินฝากสำหรับ ComboBox cboDepositType
    Private Sub LoadDepositTypes()
        Try
            Conn.Open()
            Dim query As String = "SELECT acc_id, acc_name FROM Account"
            Using cmd As New OleDbCommand(query, Conn)
                Dim reader As OleDbDataReader = cmd.ExecuteReader()
                While reader.Read()
                    cboDepositType.Items.Add(reader("acc_name").ToString())
                End While
            End Using
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการโหลดข้อมูลประเภทเงินฝาก: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Conn.Close()
        End Try
    End Sub

    ' เมื่อมีการเปลี่ยนแปลงใน TextBox txtMemberID
    Private Sub txtMemberID_TextChanged(sender As Object, e As EventArgs) Handles txtMemberID.TextChanged
        If txtMemberID.Text.Length > 2 Then
            SearchMember(txtMemberID.Text)
        End If
    End Sub

    ' ค้นหาสมาชิกตามข้อความที่กรอกใน TextBox txtMemberID
    Private Sub SearchMember(searchText As String)
        Try
            Conn.Open()
            Dim query As String = "SELECT * FROM Member WHERE m_name LIKE @searchText"
            Using cmd As New OleDbCommand(query, Conn)
                cmd.Parameters.AddWithValue("@searchText", "%" & searchText & "%")
                Dim reader As OleDbDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    txtDetails.Text = "รหัสสมาชิก: " & reader("m_id").ToString() & ", " &
                                      "ชื่อ-นามสกุล: " & reader("m_name").ToString() & ", " &
                                      "ที่อยู่: " & reader("m_address").ToString() & ", " &
                                      "เบอร์โทรติดต่อ: " & reader("m_tel").ToString()
                Else
                    txtDetails.Clear()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาด: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Conn.Close()
        End Try
    End Sub

    ' เมื่อคลิกปุ่มเพิ่มข้อมูลลงใน DataGridView
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' ตรวจสอบว่าข้อมูลที่จำเป็นถูกกรอกครบถ้วนหรือไม่
        If txtMemberID.Text = "" Or txtAmount.Text = "" Or cboDepositType.SelectedIndex = -1 Then
            MessageBox.Show("กรุณากรอกข้อมูลให้ครบถ้วน", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' แปลงค่าจำนวนเงิน
        Dim amount As Decimal
        If Not Decimal.TryParse(txtAmount.Text, amount) Then
            MessageBox.Show("กรุณากรอกจำนวนเงินที่ถูกต้อง", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' เพิ่มข้อมูลลงใน DataGridView
        Dim formattedAmount As String = FormatCurrency(amount)
        Dim row As String() = New String() {txtMemberID.Text, txtDetails.Text, txtDescrip.Text, DateTime.Now.ToString("dd/MM/yyyy"), formattedAmount, cboDepositType.SelectedItem.ToString()}
        dgvIncome.Rows.Add(row)
        ClearFields()
    End Sub


    ' เมื่อคลิกปุ่มบันทึก
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' ตรวจสอบว่ามีข้อมูลใน DataGridView หรือไม่
        If dgvIncome.Rows.Count = 0 Then
            MessageBox.Show("ไม่มีข้อมูลสำหรับบันทึก", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' เชื่อมต่อกับฐานข้อมูลและบันทึกข้อมูลจาก DataGridView
        Try
            Conn.Open()
            For Each row As DataGridViewRow In dgvIncome.Rows
                If Not row.IsNewRow Then
                    Dim query As String = "INSERT INTO Income (inc_name, inc_detail, inc_description, inc_date, inc_amount, acc_id) VALUES (@inc_name, @inc_detail, @inc_description, @inc_date, @inc_amount, @acc_id)"
                    Using cmd As New OleDbCommand(query, Conn)
                        cmd.Parameters.AddWithValue("@inc_name", row.Cells(0).Value.ToString())
                        cmd.Parameters.AddWithValue("@inc_detail", row.Cells(1).Value.ToString())
                        cmd.Parameters.AddWithValue("@inc_description", row.Cells(2).Value.ToString())
                        cmd.Parameters.AddWithValue("@inc_date", DateTime.ParseExact(row.Cells(3).Value.ToString(), "dd/MM/yyyy", Nothing))
                        ' แปลงค่าจำนวนเงินกลับ
                        Dim amount As Decimal = Decimal.Parse(row.Cells(4).Value.ToString().Replace(" บาท", "").Replace(",", ""))
                        cmd.Parameters.AddWithValue("@inc_amount", amount)
                        cmd.Parameters.AddWithValue("@acc_id", GetAccIdByName(row.Cells(5).Value.ToString()))
                        cmd.ExecuteNonQuery()
                    End Using
                End If
            Next
            MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dgvIncome.Rows.Clear()
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาด: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Conn.Close()
        End Try
    End Sub


    ' ฟังก์ชันเพื่อดึงค่า acc_id จากชื่อบัญชี
    Private Function GetAccIdByName(accName As String) As String
        Try
            Dim query As String = "SELECT acc_id FROM Account WHERE acc_name = @acc_name"
            Using cmd As New OleDbCommand(query, Conn)
                cmd.Parameters.AddWithValue("@acc_name", accName)
                Dim accId As String = cmd.ExecuteScalar().ToString()
                Return accId
            End Using
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการดึง acc_id: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    ' เมื่อคลิกปุ่มล้างข้อมูล
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    ' ล้างข้อมูลในฟิลด์ทั้งหมด
    Private Sub ClearFields()
        txtMemberID.Clear()
        txtDetails.Clear()
        txtDescrip.Clear()
        txtAmount.Clear()
        cboDepositType.SelectedIndex = -1
    End Sub

    ' ฟังก์ชันสำหรับการแปลงจำนวนเงิน
    Private Function FormatCurrency(value As Decimal) As String
        Return value.ToString("N0") & " บาท"
    End Function

End Class

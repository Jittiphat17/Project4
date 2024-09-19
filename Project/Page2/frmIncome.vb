Imports System.Data.OleDb
Imports System.IO

Public Class frmIncome
    ' เชื่อมต่อกับฐานข้อมูล Access
    Private Conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")

    Private Sub frmIncome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupDataGridView()
        LoadIncomeTypes()
        LoadMemberData()
        LoadAccountData()
        GenerateNextIncomeId() ' เรียกฟังก์ชันนี้เมื่อฟอร์มโหลด
        SetupDateTimePicker()
    End Sub

    Private Sub SetupDateTimePicker()
        dtpBirth.Format = DateTimePickerFormat.Custom
        dtpBirth.CustomFormat = "dd/MM/yyyy"
        dtpBirth.Value = DateTime.Now
    End Sub

    Private Sub GenerateNextIncomeId()
        Try
            Using Conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
                Conn.Open()
                Dim query As String = "SELECT MAX(inc_id) FROM Income"
                Dim cmd As New OleDbCommand(query, Conn)
                Dim result As Object = cmd.ExecuteScalar()

                If IsDBNull(result) Then
                    txtInid.Text = "1" ' ถ้าไม่มีข้อมูลในตาราง Income เลย ให้เริ่มต้นจาก 1
                Else
                    txtInid.Text = (Convert.ToInt32(result) + 1).ToString() ' ถ้ามีข้อมูลอยู่แล้ว เพิ่มจากค่าที่มากที่สุด
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการสร้างเลขที่รายรับใหม่: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ฟังก์ชัน SetupDataGridView
    Private Sub SetupDataGridView()
        ' เพิ่มคอลัมน์ ComboBox สำหรับประเภทของรายรับ
        Dim colIncomeType As New DataGridViewComboBoxColumn()
        colIncomeType.HeaderText = "ประเภทของรายรับ"
        colIncomeType.Name = "IncomeType"
        colIncomeType.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvIncomeDetails.Columns.Add(colIncomeType)

        ' ปิดการใช้งาน DataGridView ก่อนที่จะมีการเลือกสมาชิก
        dgvIncomeDetails.Enabled = False

        ' เพิ่มคอลัมน์สำหรับจำนวนเงิน
        Dim colAmount As New DataGridViewTextBoxColumn()
        colAmount.HeaderText = "จำนวนเงิน"
        colAmount.Name = "Amount"
        colAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        colAmount.DefaultCellStyle.Format = "N2"
        colAmount.ValueType = GetType(Decimal)
        dgvIncomeDetails.Columns.Add(colAmount)

        ' เพิ่มคอลัมน์ ComboBox สำหรับเลขที่สัญญา
        Dim colContractNumber As New DataGridViewComboBoxColumn()
        colContractNumber.HeaderText = "เลขที่สัญญา"
        colContractNumber.Name = "ContractNumber"
        colContractNumber.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvIncomeDetails.Columns.Add(colContractNumber)

        ' ตั้งค่าเพิ่มเติมให้ DataGridView
        dgvIncomeDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvIncomeDetails.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvIncomeDetails.RowTemplate.Height = 30
        dgvIncomeDetails.AllowUserToAddRows = True
    End Sub

    Private Sub LoadAccountData()
        Try
            Using Conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
                Conn.Open()
                Dim query As String = "SELECT acc_id, acc_name FROM Account"
                Dim cmd As New OleDbCommand(query, Conn)
                Dim reader As OleDbDataReader = cmd.ExecuteReader()

                cboDepositType.Items.Clear()
                Dim dt As New DataTable()
                dt.Load(reader)

                cboDepositType.DataSource = dt
                cboDepositType.DisplayMember = "acc_name"   ' ชื่อคอลัมน์ที่ต้องการแสดงใน ComboBox
                cboDepositType.ValueMember = "acc_id"       ' คอลัมน์ที่ต้องการใช้เป็นค่า (id)
                cboDepositType.SelectedIndex = -1           ' ทำให้ ComboBox ว่างเปล่าในตอนเริ่มต้น
            End Using
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการโหลดข้อมูลบัญชี: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadIncomeTypes()
        Try
            Using Conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
                Conn.Open()
                Dim incomeTypeColumn As DataGridViewComboBoxColumn = CType(dgvIncomeDetails.Columns("IncomeType"), DataGridViewComboBoxColumn)
                incomeTypeColumn.Items.Clear() ' ล้างรายการเก่า

                ' เพิ่มรายการใหม่
                incomeTypeColumn.Items.Add("เงินต้น")
                incomeTypeColumn.Items.Add("ดอกเบี้ย")
                incomeTypeColumn.Items.Add("เงินฝากสัจจะ")
                incomeTypeColumn.Items.Add("ค่าปรับ")
                incomeTypeColumn.Items.Add("เงินสำรอง")
                incomeTypeColumn.Items.Add("เงินหุ้น")
                incomeTypeColumn.Items.Add("ค่าธรรมเนียม")
                incomeTypeColumn.Items.Add("เงินบริจาค")
                incomeTypeColumn.Items.Add("เงินสนับสนุน")
                incomeTypeColumn.Items.Add("เงินกู้")
                incomeTypeColumn.Items.Add("ค่าธรรมเนียมแรกเข้า")
                incomeTypeColumn.Items.Add("อื่น ๆ")
            End Using
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการโหลดข้อมูลประเภทเงินฝาก: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadMemberData()
        Try
            Using Conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
                Conn.Open()
                Dim query As String = "SELECT m_id, m_name FROM Member"
                Dim cmd As New OleDbCommand(query, Conn)
                Dim reader As OleDbDataReader = cmd.ExecuteReader()

                Dim autoComplete As New AutoCompleteStringCollection()

                While reader.Read()
                    ' เพิ่มชื่อสมาชิกลงใน AutoCompleteStringCollection
                    autoComplete.Add(reader("m_name").ToString())
                End While

                ' ตั้งค่า AutoComplete ให้กับ TextBox txtMemberID
                txtMemberID.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                txtMemberID.AutoCompleteSource = AutoCompleteSource.CustomSource
                txtMemberID.AutoCompleteCustomSource = autoComplete
            End Using
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการโหลดข้อมูลสมาชิก: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadContractNumbersForMember(memberName As String)
        Try
            Using Conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
                Conn.Open()
                Dim contractNumberColumn As DataGridViewComboBoxColumn = CType(dgvIncomeDetails.Columns("ContractNumber"), DataGridViewComboBoxColumn)
                contractNumberColumn.Items.Clear()

                If Not String.IsNullOrEmpty(memberName) Then
                    Dim query As String = "SELECT Contract.con_id FROM Contract INNER JOIN Member ON Contract.m_id = Member.m_id WHERE Member.m_name = @memberName"
                    Dim cmd As New OleDbCommand(query, Conn)
                    cmd.Parameters.AddWithValue("@memberName", memberName)
                    Dim reader As OleDbDataReader = cmd.ExecuteReader()

                    While reader.Read()
                        contractNumberColumn.Items.Add(reader("con_id").ToString())
                    End While
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการโหลดเลขที่สัญญาของสมาชิก: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DisplayMemberDetails(memberName As String)
        If String.IsNullOrEmpty(memberName) Then
            txtDetails.Clear()
            Return
        End If

        Try
            Using Conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
                Conn.Open()
                Dim query As String = "SELECT * FROM Member WHERE m_name = @memberName"
                Dim cmd As New OleDbCommand(query, Conn)
                cmd.Parameters.AddWithValue("@memberName", memberName)
                Dim reader As OleDbDataReader = cmd.ExecuteReader()

                If reader.Read() Then
                    ' แสดงรายละเอียดใน txtDetails
                    txtDetails.Text = "รหัสสมาชิก: " & reader("m_id").ToString() & vbCrLf &
                                      "ชื่อ: " & reader("m_name").ToString() & vbCrLf &
                                      "ที่อยู่: " & reader("m_address").ToString() & vbCrLf &
                                      "เบอร์โทร: " & reader("m_tel").ToString()
                Else
                    txtDetails.Clear()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการดึงข้อมูลสมาชิก: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CalculateTotalAmount()
        Dim totalAmount As Decimal = 0

        ' คำนวณผลรวมของจำนวนเงินใน DataGridView
        For Each row As DataGridViewRow In dgvIncomeDetails.Rows
            If Not row.IsNewRow Then
                Dim amount As Decimal
                If Decimal.TryParse(row.Cells("Amount").Value?.ToString(), amount) Then
                    totalAmount += amount
                End If
            End If
        Next

        ' แสดงผลรวมใน Label
        lblTotalAmount.Text = totalAmount.ToString("N2")
    End Sub

    ' ฟังก์ชันสำหรับบันทึกข้อมูลและทำการหักยอดเมื่อค่าของ lblTotalAmount และ txtAmount เท่ากัน
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' แปลงค่าใน lblTotalAmount และ txtAmount ให้เป็น Decimal ก่อนเปรียบเทียบ
        Dim totalAmount As Decimal
        Dim inputAmount As Decimal

        ' ลองแปลงค่าจาก lblTotalAmount และ txtAmount
        If Decimal.TryParse(lblTotalAmount.Text, totalAmount) AndAlso Decimal.TryParse(txtAmount.Text, inputAmount) Then
            ' ตรวจสอบว่าค่าทั้งสองเท่ากันหรือไม่
            If totalAmount = inputAmount Then
                ' บันทึกข้อมูล
                SaveData() ' ฟังก์ชันสำหรับการบันทึกข้อมูล

                ' ปิดการใช้งานปุ่ม "บันทึก" จนกว่าจะมีการเพิ่มรายการใหม่
                btnSave.Enabled = False
            Else
                ' แสดงข้อความแจ้งเตือนว่าค่าไม่เท่ากัน
                MessageBox.Show("จำนวนเงินรวมไม่ตรงกับจำนวนเงินที่ระบุ", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            ' แสดงข้อความแจ้งเตือนว่ามีข้อผิดพลาดในการแปลงค่า
            MessageBox.Show("กรุณากรอกจำนวนเงินที่ถูกต้อง", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub SaveData()
        Try
            If cboDepositType.SelectedValue Is Nothing Then
                MessageBox.Show("กรุณาเลือกบัญชีเงินฝาก", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Using Conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
                Conn.Open()

                ' Get m_id from Member table based on the member name
                Dim queryGetMemberId As String = "SELECT m_id FROM Member WHERE m_name = @memberName"
                Dim cmdGetMemberId As New OleDbCommand(queryGetMemberId, Conn)
                cmdGetMemberId.Parameters.AddWithValue("@memberName", txtMemberID.Text)
                Dim memberId As Object = cmdGetMemberId.ExecuteScalar()

                If memberId Is Nothing OrElse DBNull.Value.Equals(memberId) Then
                    MessageBox.Show("ไม่พบข้อมูลสมาชิก", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                ' บันทึกข้อมูลลงในตาราง Income
                Dim queryIncome As String = "INSERT INTO Income (m_id, inc_detail, inc_description, inc_date, inc_amount, acc_id) VALUES (@m_id, @inc_detail, @inc_description, @inc_date, @inc_amount, @acc_id)"
                Using cmdIncome As New OleDbCommand(queryIncome, Conn)
                    cmdIncome.Parameters.AddWithValue("@m_id", memberId)
                    cmdIncome.Parameters.AddWithValue("@inc_detail", txtDetails.Text)
                    cmdIncome.Parameters.AddWithValue("@inc_description", txtDescrip.Text)
                    cmdIncome.Parameters.AddWithValue("@inc_date", dtpBirth.Value)
                    cmdIncome.Parameters.AddWithValue("@inc_amount", Decimal.Parse(lblTotalAmount.Text))
                    cmdIncome.Parameters.AddWithValue("@acc_id", cboDepositType.SelectedValue)

                    cmdIncome.ExecuteNonQuery()

                    ' ดึง inc_id ล่าสุด
                    cmdIncome.CommandText = "SELECT @@IDENTITY"
                    Dim incId As Integer = CInt(cmdIncome.ExecuteScalar())

                    ' บันทึกข้อมูลลงในตาราง Income_Details และหักยอดเงินคงเหลือ
                    For Each row As DataGridViewRow In dgvIncomeDetails.Rows
                        If Not row.IsNewRow Then
                            Dim incomeType As String = If(row.Cells("IncomeType").Value, "").ToString()
                            Dim contractNumber As String = If(row.Cells("ContractNumber").Value, DBNull.Value).ToString()
                            Dim amount As Decimal = Decimal.Parse(If(row.Cells("Amount").Value, 0).ToString())

                            If Not String.IsNullOrEmpty(incomeType) Then
                                If Not String.IsNullOrEmpty(contractNumber) Then
                                    DeductBalance(contractNumber, amount)
                                End If

                                ' เพิ่มคอลัมน์ m_id ลงในคำสั่ง INSERT INTO
                                Dim queryDetails As String = "INSERT INTO Income_Details (ind_accname, con_id, ind_amount, inc_id, m_id) VALUES (@ind_accname, @con_id, @ind_amount, @inc_id, @m_id)"
                                Using cmdDetails As New OleDbCommand(queryDetails, Conn)
                                    cmdDetails.Parameters.AddWithValue("@ind_accname", incomeType)
                                    cmdDetails.Parameters.AddWithValue("@con_id", If(String.IsNullOrEmpty(contractNumber), DBNull.Value, contractNumber))
                                    cmdDetails.Parameters.AddWithValue("@ind_amount", amount)
                                    cmdDetails.Parameters.AddWithValue("@inc_id", incId)
                                    ' เพิ่มพารามิเตอร์ m_id
                                    cmdDetails.Parameters.AddWithValue("@m_id", memberId)

                                    cmdDetails.ExecuteNonQuery()
                                End Using
                            End If
                        End If
                    Next

                End Using
            End Using

            MessageBox.Show("บันทึกข้อมูลสำเร็จ", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' รีเซ็ตฟอร์มเพื่อเตรียมทำรายการใหม่
            ClearAll()

        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการบันทึกข้อมูล: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub DeductBalance(contractNumber As String, amount As Decimal)
        Try
            Using Conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
                Conn.Open()

                ' ดึงจำนวนเงินที่มีอยู่ในสัญญาปัจจุบัน
                Dim queryAmount As String = "SELECT con_amount FROM Contract WHERE con_id = @contractNumber"
                Dim cmdAmount As New OleDbCommand(queryAmount, Conn)
                cmdAmount.Parameters.AddWithValue("@contractNumber", contractNumber)
                Dim currentAmount As Decimal = Convert.ToDecimal(cmdAmount.ExecuteScalar())

                ' คำนวณจำนวนเงินใหม่หลังจากหักออก
                Dim newAmount As Decimal = currentAmount - amount

                ' ตรวจสอบว่าจำนวนเงินหลังหักไม่ติดลบ
                If newAmount < 0 Then
                    MessageBox.Show("ไม่สามารถหักยอดเงินได้เนื่องจากยอดเงินคงเหลือติดลบ", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                ' อัปเดตจำนวนเงินในสัญญา
                Dim queryUpdate As String = "UPDATE Contract SET con_amount = @newAmount WHERE con_id = @contractNumber"
                Dim cmdUpdate As New OleDbCommand(queryUpdate, Conn)
                cmdUpdate.Parameters.AddWithValue("@newAmount", newAmount)
                cmdUpdate.Parameters.AddWithValue("@contractNumber", contractNumber)
                cmdUpdate.ExecuteNonQuery()

                MessageBox.Show("อัปเดตจำนวนเงินในสัญญาเรียบร้อยแล้ว", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการอัปเดตจำนวนเงิน: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearAll()
        ' ล้างข้อมูลในฟอร์ม
        txtMemberID.Clear()
        txtDetails.Clear()
        txtAmount.Clear()
        cboDepositType.SelectedIndex = -1
        lblTotalAmount.Text = "0.00"

        ' ล้างข้อมูลใน DataGridView
        dgvIncomeDetails.Rows.Clear()

        ' โหลดข้อมูลใหม่สำหรับ ComboBox ใน DataGridView
        LoadIncomeTypes()
        LoadContractNumbersForMember(txtMemberID.Text)

        ' สร้างเลขที่รายรับใหม่
        GenerateNextIncomeId()
    End Sub

    ' เมื่อมีการเปลี่ยนแปลงรหัสสมาชิก
    Private Sub txtMemberID_TextChanged(sender As Object, e As EventArgs) Handles txtMemberID.TextChanged
        ' ตรวจสอบว่าผู้ใช้ได้ป้อนชื่อสมาชิกหรือไม่
        If String.IsNullOrEmpty(txtMemberID.Text.Trim()) Then
            MessageBox.Show("กรุณาเลือกหรือระบุชื่อสมาชิก", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' เรียกฟังก์ชันเพื่อแสดงรายละเอียดของสมาชิกเมื่อผู้ใช้พิมพ์หรือเลือกชื่อสมาชิก
        DisplayMemberDetails(txtMemberID.Text)

        ' โหลดเลขที่สัญญาที่เกี่ยวข้องกับสมาชิกที่ถูกเลือก
        LoadContractNumbersForMember(txtMemberID.Text)

        ' ถ้าเจอข้อมูลสมาชิกแล้ว จึงทำการโหลดประเภทของรายรับและเปิดใช้งาน DataGridView
        LoadIncomeTypes()
        dgvIncomeDetails.Enabled = True
    End Sub

    ' ฟังก์ชันสำหรับการคำนวณยอดรวมโดยไม่หักยอด
    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        CalculateTotalAmount()
    End Sub

    Private Sub dgvIncomeDetails_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvIncomeDetails.DataError
        ' แสดงข้อความแจ้งข้อผิดพลาดที่เข้าใจง่ายขึ้น
        MessageBox.Show("มีข้อผิดพลาดในการกรอกข้อมูลในเซลล์ กรุณาตรวจสอบค่าที่คุณกรอกให้ตรงกับรายการที่มีใน ComboBox", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        e.ThrowException = False ' ป้องกันไม่ให้แอปพลิเคชันหยุดทำงาน
    End Sub

    Private Sub dgvIncomeDetails_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvIncomeDetails.CellValidating
        If dgvIncomeDetails.Columns(e.ColumnIndex).Name = "IncomeType" Then
            Dim comboBoxColumn As DataGridViewComboBoxColumn = CType(dgvIncomeDetails.Columns("IncomeType"), DataGridViewComboBoxColumn)
            If Not comboBoxColumn.Items.Contains(e.FormattedValue.ToString()) Then
                MessageBox.Show("กรุณาเลือกประเภทของรายรับที่ถูกต้อง", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub dgvIncomeDetails_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvIncomeDetails.RowsAdded
        btnSave.Enabled = True ' เปิดการใช้งานปุ่ม "บันทึก" เมื่อมีการเพิ่มรายการใหม่
        btnCalculate.Enabled = True ' เปิดการใช้งานปุ่ม "คำนวณ" เมื่อมีการเพิ่มรายการใหม่
    End Sub
End Class

Imports System.Data.OleDb
Imports System.IO

Public Class frmIncome
    ' เชื่อมต่อกับฐานข้อมูล Access
    Private Conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")

    Private Sub frmIncome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupDataGridView() ' สำหรับรายรับ
        SetupDataGridViewForPayments() ' สำหรับค่างวด
        LoadIncomeTypes()
        LoadPaymentTypes() ' โหลดประเภทของค่างวด
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

        ' เพิ่มคอลัมน์ปุ่มลบรายการ
        Dim colDeleteButton As New DataGridViewButtonColumn()
        colDeleteButton.HeaderText = "ลบรายการ"
        colDeleteButton.Name = "DeleteButton"
        colDeleteButton.Text = "ลบ"
        colDeleteButton.UseColumnTextForButtonValue = True
        dgvIncomeDetails.Columns.Add(colDeleteButton)

        ' ตั้งค่าเพิ่มเติมให้ DataGridView
        dgvIncomeDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvIncomeDetails.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvIncomeDetails.RowTemplate.Height = 30
        dgvIncomeDetails.AllowUserToAddRows = True
    End Sub

    Private Sub SetupDataGridViewForPayments()
        ' เพิ่มคอลัมน์ ComboBox สำหรับประเภทของค่างวด
        Dim colPaymentType As New DataGridViewComboBoxColumn()
        colPaymentType.HeaderText = "ประเภทของค่างวด"
        colPaymentType.Name = "PaymentType"
        colPaymentType.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvPaymentDetails.Columns.Add(colPaymentType)

        ' เพิ่มคอลัมน์สำหรับจำนวนเงินค่างวด
        Dim colPaymentAmount As New DataGridViewTextBoxColumn()
        colPaymentAmount.HeaderText = "จำนวนเงินค่างวด"
        colPaymentAmount.Name = "PaymentAmount"
        colPaymentAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        colPaymentAmount.DefaultCellStyle.Format = "N2"
        colPaymentAmount.ValueType = GetType(Decimal)
        dgvPaymentDetails.Columns.Add(colPaymentAmount)

        ' เพิ่มคอลัมน์ ComboBox สำหรับเลขที่สัญญา
        Dim colPaymentContractNumber As New DataGridViewComboBoxColumn()
        colPaymentContractNumber.HeaderText = "เลขที่สัญญา"
        colPaymentContractNumber.Name = "PaymentContractNumber"
        colPaymentContractNumber.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvPaymentDetails.Columns.Add(colPaymentContractNumber)

        ' เพิ่มคอลัมน์ ComboBox สำหรับงวดที่
        Dim colPaymentPeriod As New DataGridViewComboBoxColumn()
        colPaymentPeriod.HeaderText = "งวดที่"
        colPaymentPeriod.Name = "PaymentPeriod"
        colPaymentPeriod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPaymentDetails.Columns.Add(colPaymentPeriod)

        ' เพิ่มคอลัมน์ปุ่มลบรายการ
        Dim colDeletePaymentButton As New DataGridViewButtonColumn()
        colDeletePaymentButton.HeaderText = "ลบรายการ"
        colDeletePaymentButton.Name = "DeletePaymentButton"
        colDeletePaymentButton.Text = "ลบ"
        colDeletePaymentButton.UseColumnTextForButtonValue = True
        dgvPaymentDetails.Columns.Add(colDeletePaymentButton)

        ' ตั้งค่าเพิ่มเติมให้ DataGridView สำหรับค่างวด
        dgvPaymentDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvPaymentDetails.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPaymentDetails.RowTemplate.Height = 30
        dgvPaymentDetails.AllowUserToAddRows = True
    End Sub


    Private Sub LoadPaymentTypes()
        Try
            Dim paymentTypeColumn As DataGridViewComboBoxColumn = CType(dgvPaymentDetails.Columns("PaymentType"), DataGridViewComboBoxColumn)
            paymentTypeColumn.Items.Clear() ' ล้างรายการเก่า

            ' เพิ่มรายการใหม่
            paymentTypeColumn.Items.AddRange(New String() {"เงินต้น", "ดอกเบี้ย", "ค่าปรับ", "ค่างวดสินเชื่อ", "ดอกเบี้ยค้างชำระ", "ค่าธรรมเนียมล่าช้า", "อื่น ๆ"})
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการโหลดข้อมูลประเภทค่างวด: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
                incomeTypeColumn.Items.Add("เงินฝากสัจจะ")
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


    Private Sub LoadContractNumbersForPayment(memberName As String)
        Try
            Using Conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
                Conn.Open()

                ' โหลดเลขที่สัญญาสำหรับ dgvPaymentDetails
                Dim contractNumberColumnPayment As DataGridViewComboBoxColumn = CType(dgvPaymentDetails.Columns("PaymentContractNumber"), DataGridViewComboBoxColumn)
                contractNumberColumnPayment.Items.Clear()

                If Not String.IsNullOrEmpty(memberName) Then
                    Dim query As String = "SELECT Contract.con_id FROM Contract INNER JOIN Member ON Contract.m_id = Member.m_id WHERE Member.m_name = @memberName"
                    Dim cmd As New OleDbCommand(query, Conn)
                    cmd.Parameters.AddWithValue("@memberName", memberName)
                    Dim reader As OleDbDataReader = cmd.ExecuteReader()

                    While reader.Read()
                        Dim contractId As String = reader("con_id").ToString()
                        contractNumberColumnPayment.Items.Add(contractId)
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

        ' Calculate the total amount from dgvIncomeDetails
        For Each row As DataGridViewRow In dgvIncomeDetails.Rows
            If Not row.IsNewRow Then
                Dim amount As Decimal
                If Decimal.TryParse(row.Cells("Amount").Value?.ToString(), amount) Then
                    totalAmount += amount
                End If
            End If
        Next

        ' Calculate the total amount from dgvPaymentDetails
        For Each row As DataGridViewRow In dgvPaymentDetails.Rows
            If Not row.IsNewRow Then
                Dim amount As Decimal
                If Decimal.TryParse(row.Cells("PaymentAmount").Value?.ToString(), amount) Then
                    totalAmount += amount
                End If
            End If
        Next

        ' Display the total amount in lblTotalAmount
        lblTotalAmount.Text = totalAmount.ToString("N2")
    End Sub



    ' ฟังก์ชันสำหรับบันทึกข้อมูลและทำการหักยอดเมื่อค่าของ lblTotalAmount และ txtAmount เท่ากัน
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' ตรวจสอบว่าข้อมูลในทั้งสอง DataGridView นั้นครบถ้วน
        If dgvIncomeDetails.Rows.Count > 1 OrElse dgvPaymentDetails.Rows.Count > 1 Then
            ' ตรวจสอบจำนวนเงินรวมกับยอดที่ผู้ใช้ระบุ
            CalculateTotalAmount()
            Dim totalAmount As Decimal
            Dim inputAmount As Decimal

            If Decimal.TryParse(lblTotalAmount.Text, totalAmount) AndAlso Decimal.TryParse(txtAmount.Text, inputAmount) Then
                If totalAmount = inputAmount Then
                    ' บันทึกข้อมูล
                    SaveData() ' บันทึกข้อมูลทั่วไป
                    SavePaymentData() ' บันทึกข้อมูลการชำระเงินงวด

                    ' ปิดการใช้งานปุ่มบันทึกหลังจากบันทึกเสร็จ
                    btnSave.Enabled = False
                    MessageBox.Show("บันทึกข้อมูลสำเร็จ", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("จำนวนเงินรวมไม่ตรงกับจำนวนเงินที่ระบุ", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("กรุณากรอกจำนวนเงินที่ถูกต้อง", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("กรุณาเพิ่มรายการรายรับหรือค่างวด", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub SavePaymentData()
        Try
            ' ดึงข้อมูลสมาชิก
            Dim memberId As String = txtMemberID.Text

            If String.IsNullOrEmpty(memberId) Then
                MessageBox.Show("กรุณาเลือกหรือระบุชื่อสมาชิก", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' ชำระเงินสำหรับทุกรายการในตาราง dgvPaymentDetails
            For Each row As DataGridViewRow In dgvPaymentDetails.Rows
                If Not row.IsNewRow Then
                    Dim contractNumber As String = row.Cells("PaymentContractNumber").Value.ToString()
                    Dim paymentType As String = row.Cells("PaymentType").Value.ToString()
                    Dim amount As Decimal = CDec(row.Cells("PaymentAmount").Value)

                    ' หักยอดเงินและอัปเดตสถานะการชำระเงิน พร้อมอัปเดตฟิลด์ payment_balance
                    If DeductBalance(contractNumber, amount) Then
                        UpdatePaymentStatus(contractNumber)
                    End If
                End If
            Next

            ' เคลียร์ข้อมูลหลังจากบันทึกเสร็จ
            ClearAll()
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการบันทึกข้อมูล: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub SaveData()
        Try
            If cboDepositType.SelectedValue Is Nothing Then
                MessageBox.Show("กรุณาเลือกบัญชีเงินฝาก", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Using Conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
                Conn.Open()

                ' ดึง m_id จากตาราง Member โดยใช้ชื่อสมาชิก
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
                    cmdIncome.Parameters.AddWithValue("@m_id", CInt(memberId))
                    cmdIncome.Parameters.AddWithValue("@inc_detail", txtDetails.Text)
                    cmdIncome.Parameters.AddWithValue("@inc_description", txtDescrip.Text)
                    cmdIncome.Parameters.AddWithValue("@inc_date", dtpBirth.Value)
                    cmdIncome.Parameters.AddWithValue("@inc_amount", CDec(lblTotalAmount.Text))
                    cmdIncome.Parameters.AddWithValue("@acc_id", cboDepositType.SelectedValue.ToString())

                    cmdIncome.ExecuteNonQuery()

                    ' ดึง inc_id ล่าสุด
                    cmdIncome.CommandText = "SELECT @@IDENTITY"
                    Dim incId As Integer = CInt(cmdIncome.ExecuteScalar())

                    ' บันทึกข้อมูลจาก dgvIncomeDetails ลงในตาราง Income_Details
                    For Each row As DataGridViewRow In dgvIncomeDetails.Rows
                        If Not row.IsNewRow Then
                            Dim incomeType As String = If(row.Cells("IncomeType").Value, "").ToString()
                            Dim amount As Decimal = CDec(If(row.Cells("Amount").Value, 0))
                            Dim incDate As Date = dtpBirth.Value ' ใช้วันที่จาก DateTimePicker หรือเปลี่ยนตามวันที่ที่ต้องการ

                            If Not String.IsNullOrEmpty(incomeType) Then
                                Dim queryDetails As String = "INSERT INTO Income_Details (ind_accname, con_id, ind_amount, inc_id, m_id, ind_date) VALUES (@ind_accname, @con_id, @ind_amount, @inc_id, @m_id, @ind_date)"
                                Using cmdDetails As New OleDbCommand(queryDetails, Conn)
                                    cmdDetails.Parameters.AddWithValue("@ind_accname", incomeType)
                                    cmdDetails.Parameters.AddWithValue("@con_id", DBNull.Value) ' ไม่มี con_id ในกรณีนี้
                                    cmdDetails.Parameters.AddWithValue("@ind_amount", amount)
                                    cmdDetails.Parameters.AddWithValue("@inc_id", incId)
                                    cmdDetails.Parameters.AddWithValue("@m_id", CInt(memberId))
                                    cmdDetails.Parameters.AddWithValue("@ind_date", incDate)

                                    cmdDetails.ExecuteNonQuery()
                                End Using
                            End If
                        End If
                    Next
                    ' บันทึกข้อมูลจาก dgvPaymentDetails ลงในตาราง Income_Details
                    For Each row As DataGridViewRow In dgvPaymentDetails.Rows
                        If Not row.IsNewRow Then
                            Dim paymentType As String = If(row.Cells("PaymentType").Value, "").ToString()
                            Dim paymentContractNumber As String = If(row.Cells("PaymentContractNumber").Value, "").ToString()
                            Dim amount As Decimal = CDec(If(row.Cells("PaymentAmount").Value, 0))
                            Dim incDate As Date = dtpBirth.Value ' ใช้วันที่จาก DateTimePicker หรือเปลี่ยนตามวันที่ที่ต้องการ

                            If Not String.IsNullOrEmpty(paymentType) Then
                                If Not String.IsNullOrEmpty(paymentContractNumber) Then
                                    DeductBalance(paymentContractNumber, amount)
                                End If

                                Dim queryDetails As String = "INSERT INTO Income_Details (ind_accname, con_id, ind_amount, inc_id, m_id, ind_date) VALUES (@ind_accname, @con_id, @ind_amount, @inc_id, @m_id, @ind_date)"
                                Using cmdDetails As New OleDbCommand(queryDetails, Conn)
                                    cmdDetails.Parameters.AddWithValue("@ind_accname", paymentType)
                                    cmdDetails.Parameters.AddWithValue("@con_id", If(String.IsNullOrEmpty(paymentContractNumber), DBNull.Value, paymentContractNumber))
                                    cmdDetails.Parameters.AddWithValue("@ind_amount", amount)
                                    cmdDetails.Parameters.AddWithValue("@inc_id", incId)
                                    cmdDetails.Parameters.AddWithValue("@m_id", CInt(memberId))
                                    cmdDetails.Parameters.AddWithValue("@ind_date", incDate)

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


    Private Function DeductBalance(contractNumber As String, amount As Decimal) As Boolean
        Try
            Using Conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
                Conn.Open()

                ' ดึงจำนวนเงินที่มีอยู่ในสัญญาปัจจุบัน
                Dim queryAmount As String = "SELECT con_amount FROM Contract WHERE con_id = @contractNumber"
                Dim cmdAmount As New OleDbCommand(queryAmount, Conn)
                cmdAmount.Parameters.AddWithValue("@contractNumber", contractNumber)
                Dim currentAmount As Decimal = Convert.ToDecimal(cmdAmount.ExecuteScalar())

                Dim newAmount As Decimal = currentAmount - amount

                If newAmount < 0 Then
                    MessageBox.Show("ไม่สามารถหักยอดเงินได้เนื่องจากยอดเงินคงเหลือติดลบ", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If

                ' อัปเดตจำนวนเงินในสัญญา
                Dim queryUpdateContract As String = "UPDATE Contract SET con_amount = @newAmount WHERE con_id = @contractNumber"
                Dim cmdUpdateContract As New OleDbCommand(queryUpdateContract, Conn)
                cmdUpdateContract.Parameters.AddWithValue("@newAmount", newAmount)
                cmdUpdateContract.Parameters.AddWithValue("@contractNumber", contractNumber)
                cmdUpdateContract.ExecuteNonQuery()

                ' อัปเดตฟิลด์ payment_balance ในตาราง Payment
                Dim queryUpdatePayment As String = "UPDATE Payment SET payment_balance = @newAmount WHERE con_id = @contractNumber"
                Dim cmdUpdatePayment As New OleDbCommand(queryUpdatePayment, Conn)
                cmdUpdatePayment.Parameters.AddWithValue("@newAmount", newAmount)
                cmdUpdatePayment.Parameters.AddWithValue("@contractNumber", contractNumber)
                cmdUpdatePayment.ExecuteNonQuery()

                Return True
            End Using
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการหักยอดเงิน: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function


    Private Sub UpdatePaymentStatus(contractNumber As String)
        Try
            Using Conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
                Conn.Open()

                ' ดึงข้อมูลงวดที่ยังไม่ได้ชำระล่าสุด
                Dim querySelect As String = "SELECT TOP 1 payment_period, payment_prin, payment_interest FROM Payment WHERE con_id = @contractNumber AND status_id = 1 ORDER BY payment_period ASC"
                Dim cmdSelect As New OleDbCommand(querySelect, Conn)
                cmdSelect.Parameters.AddWithValue("@contractNumber", contractNumber)
                Dim reader As OleDbDataReader = cmdSelect.ExecuteReader()

                If reader.Read() Then
                    Dim period As Integer = Convert.ToInt32(reader("payment_period"))
                    Dim principal As Decimal = Convert.ToDecimal(reader("payment_prin"))
                    Dim interest As Decimal = Convert.ToDecimal(reader("payment_interest"))

                    ' อัปเดตสถานะของงวดที่พบเป็นชำระแล้ว
                    Dim queryUpdate As String = "UPDATE Payment SET status_id = 2 WHERE con_id = @contractNumber AND payment_period = @period"
                    Dim cmdUpdate As New OleDbCommand(queryUpdate, Conn)
                    cmdUpdate.Parameters.AddWithValue("@contractNumber", contractNumber)
                    cmdUpdate.Parameters.AddWithValue("@period", period)
                    cmdUpdate.ExecuteNonQuery()

                    MessageBox.Show($"ชำระงวดที่ {period} สำเร็จ เงินต้น: {principal:N2} ดอกเบี้ย: {interest:N2}", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("ไม่พบงวดที่ยังไม่ได้ชำระ", "ข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการอัพเดตสถานะการชำระเงิน: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearAll()
        ' ปิดการใช้งาน DataGridView ชั่วคราวเพื่อป้องกันข้อผิดพลาด
        dgvIncomeDetails.Enabled = False
        dgvPaymentDetails.Enabled = False

        ' ล้างข้อมูลในฟอร์ม
        txtMemberID.Clear()
        txtDetails.Clear()
        txtAmount.Clear()
        cboDepositType.SelectedIndex = -1
        lblTotalAmount.Text = "0.00"

        ' ล้างข้อมูลใน DataGridView
        dgvIncomeDetails.Rows.Clear()
        dgvPaymentDetails.Rows.Clear()

        ' โหลดข้อมูลใหม่สำหรับ ComboBox ใน DataGridView
        LoadIncomeTypes()
        LoadContractNumbersForPayment(txtMemberID.Text)

        ' สร้างเลขที่รายรับใหม่
        GenerateNextIncomeId()

        ' เปิดการใช้งาน DataGridView อีกครั้งหลังจากการล้างข้อมูลเสร็จสิ้น
        dgvIncomeDetails.Enabled = True
        dgvPaymentDetails.Enabled = True
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
        LoadContractNumbersForPayment(txtMemberID.Text) ' ใช้สำหรับทั้ง dgvIncomeDetails และ dgvPaymentDetails

        ' เปิดการใช้งาน DataGridView
        dgvIncomeDetails.Enabled = True
        dgvPaymentDetails.Enabled = True
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

    Private Sub dgvIncomeDetails_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvIncomeDetails.CellClick
        ' ตรวจสอบว่าเป็นการคลิกปุ่มลบ
        If e.ColumnIndex = dgvIncomeDetails.Columns("DeleteButton").Index AndAlso e.RowIndex >= 0 Then
            ' ยืนยันการลบ
            Dim result As DialogResult = MessageBox.Show("คุณต้องการลบรายการนี้หรือไม่?", "ยืนยันการลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                ' ลบรายการ
                dgvIncomeDetails.Rows.RemoveAt(e.RowIndex)
            End If
        End If
    End Sub

    Private Sub dgvIncomeDetails_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvIncomeDetails.RowsAdded
        btnSave.Enabled = True ' เปิดการใช้งานปุ่ม "บันทึก" เมื่อมีการเพิ่มรายการใหม่
        btnCalculate.Enabled = True ' เปิดการใช้งานปุ่ม "คำนวณ" เมื่อมีการเพิ่มรายการใหม่
    End Sub

    Private Sub dgvPaymentDetails_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvPaymentDetails.EditingControlShowing
        If dgvPaymentDetails.CurrentCell.ColumnIndex = dgvPaymentDetails.Columns("PaymentContractNumber").Index Then
            Dim cmb As ComboBox = TryCast(e.Control, ComboBox)
            If cmb IsNot Nothing Then
                RemoveHandler cmb.SelectedIndexChanged, AddressOf PaymentContractNumber_SelectedIndexChanged
                AddHandler cmb.SelectedIndexChanged, AddressOf PaymentContractNumber_SelectedIndexChanged
            End If
        End If
    End Sub

    Private Sub PaymentContractNumber_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim cmb As ComboBox = CType(sender, ComboBox)
        Dim contractNumber As String = cmb.Text
        Dim currentRow As DataGridViewRow = dgvPaymentDetails.CurrentRow

        ' ตรวจสอบว่าแถวปัจจุบันมีค่าอยู่แล้วหรือไม่ก่อนทำการเพิ่มแถวใหม่
        If Not String.IsNullOrEmpty(currentRow.Cells("PaymentType").Value?.ToString()) Then
            ' ถ้ามีอยู่แล้ว ให้รีเทิร์นออกไป ไม่ต้องทำการเพิ่มแถวใหม่
            Return
        End If

        ' สร้างประเภทของรายรับโดยอัตโนมัติเมื่อไม่มีค่าในแถว
        currentRow.Cells("PaymentType").Value = "เงินต้น"

        ' เพิ่มแถวใหม่สำหรับ "ดอกเบี้ย" เฉพาะเมื่อยังไม่มีแถวที่คล้ายกันใน DataGridView
        If Not IsPaymentAlreadyAdded(contractNumber, "ดอกเบี้ย") Then
            Dim rowIndex As Integer = dgvPaymentDetails.Rows.Add()
            dgvPaymentDetails.Rows(rowIndex).Cells("PaymentContractNumber").Value = contractNumber
            dgvPaymentDetails.Rows(rowIndex).Cells("PaymentType").Value = "ดอกเบี้ย"
        End If
    End Sub

    ' ฟังก์ชันตรวจสอบว่ามีการเพิ่ม PaymentType แบบเดียวกันแล้วหรือไม่
    Private Function IsPaymentAlreadyAdded(contractNumber As String, paymentType As String) As Boolean
        For Each row As DataGridViewRow In dgvPaymentDetails.Rows
            If Not row.IsNewRow AndAlso
           row.Cells("PaymentContractNumber").Value IsNot Nothing AndAlso
           row.Cells("PaymentType").Value IsNot Nothing AndAlso
           row.Cells("PaymentContractNumber").Value.ToString() = contractNumber AndAlso
           row.Cells("PaymentType").Value.ToString() = paymentType Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub dgvPaymentDetails_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPaymentDetails.CellValueChanged
        If e.ColumnIndex = dgvPaymentDetails.Columns("PaymentContractNumber").Index Then
            Dim contractNumber As String = dgvPaymentDetails.Rows(e.RowIndex).Cells("PaymentContractNumber").Value?.ToString()

            If Not String.IsNullOrEmpty(contractNumber) Then
                If Not IsPaymentAlreadyAdded(contractNumber, "เงินต้น") AndAlso Not IsPaymentAlreadyAdded(contractNumber, "ดอกเบี้ย") Then
                    Dim paymentDataList = GetPaymentData(contractNumber)
                    If paymentDataList.Count > 0 Then
                        Dim paymentData = paymentDataList(0) ' เลือกงวดแรกที่ยังไม่ได้ชำระ

                        If dgvPaymentDetails.Rows(e.RowIndex).Cells("PaymentType").Value Is Nothing Then
                            dgvPaymentDetails.Rows(e.RowIndex).Cells("PaymentType").Value = "ดอกเบี้ย"
                            dgvPaymentDetails.Rows(e.RowIndex).Cells("PaymentAmount").Value = paymentData.Interest
                        End If

                        If Not IsPaymentAlreadyAdded(contractNumber, "เงินต้น") Then
                            Dim rowIndex As Integer = dgvPaymentDetails.Rows.Add()
                            dgvPaymentDetails.Rows(rowIndex).Cells("PaymentContractNumber").Value = contractNumber
                            dgvPaymentDetails.Rows(rowIndex).Cells("PaymentType").Value = "เงินต้น"
                            dgvPaymentDetails.Rows(rowIndex).Cells("PaymentAmount").Value = paymentData.Principal
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    ' ฟังก์ชันสำหรับดึงข้อมูลเงินต้นและดอกเบี้ยตาม PaymentContractNumber
    Private Function GetPaymentData(contractNumber As String) As List(Of (Period As Integer, Principal As Decimal, Interest As Decimal))
        Dim payments As New List(Of (Period As Integer, Principal As Decimal, Interest As Decimal))

        Using Conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
            Conn.Open()

            ' ดึงข้อมูลงวดการชำระทั้งหมดที่ยังไม่ได้ชำระเรียงตามลำดับงวด
            Dim query As String = "SELECT payment_period, payment_prin, payment_interest FROM Payment WHERE con_id = @contractNumber AND status_id = 1 ORDER BY payment_period ASC"
            Dim cmd As New OleDbCommand(query, Conn)
            cmd.Parameters.AddWithValue("@contractNumber", contractNumber)
            Dim reader As OleDbDataReader = cmd.ExecuteReader()

            ' เก็บข้อมูลแต่ละงวดที่ดึงมาในรายการ
            While reader.Read()
                Dim period As Integer = Convert.ToInt32(reader("payment_period"))
                Dim principalAmount As Decimal = Convert.ToDecimal(reader("payment_prin"))
                Dim interestAmount As Decimal = Convert.ToDecimal(reader("payment_interest"))
                payments.Add((Period:=period, Principal:=principalAmount, Interest:=interestAmount))
            End While
        End Using

        Return payments
    End Function


    Private Sub dgvPaymentDetails_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvPaymentDetails.DataError
        If e.Context = DataGridViewDataErrorContexts.Commit Then
            MessageBox.Show("มีข้อผิดพลาดในการกรอกข้อมูลในเซลล์ กรุณาตรวจสอบค่าที่คุณกรอกให้ตรงกับรายการที่มีใน ComboBox", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        e.ThrowException = False ' ป้องกันไม่ให้แอปพลิเคชันหยุดทำงาน
    End Sub

    Private Sub dgvPaymentDetails_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPaymentDetails.CellClick
        ' ตรวจสอบว่าคลิกที่คอลัมน์ปุ่มลบและไม่ใช่แถวส่วนหัว
        If e.ColumnIndex = dgvPaymentDetails.Columns("DeletePaymentButton").Index AndAlso e.RowIndex >= 0 Then
            ' ตรวจสอบว่ามีมากกว่า 2 แถวหรือไม่
            If dgvPaymentDetails.Rows.Count > 2 Then
                ' ถามยืนยันก่อนลบ
                Dim result As DialogResult = MessageBox.Show("คุณแน่ใจหรือไม่ที่จะลบรายการนี้?", "ยืนยันการลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    ' ลบแถว
                    dgvPaymentDetails.Rows.RemoveAt(e.RowIndex)

                    ' คำนวณยอดรวมใหม่หลังจากลบ
                    CalculateTotalAmount()
                End If
            Else
                MessageBox.Show("ไม่สามารถลบรายการนี้ได้ เนื่องจากต้องมีอย่างน้อย 2 รายการ (เงินต้นและดอกเบี้ย)", "ไม่สามารถลบได้", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub dgvPaymentDetails_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvPaymentDetails.CellValidating
        If dgvPaymentDetails.Columns(e.ColumnIndex).Name = "PaymentType" Then
            Dim comboBoxColumn As DataGridViewComboBoxColumn = CType(dgvPaymentDetails.Columns("PaymentType"), DataGridViewComboBoxColumn)

            ' ตรวจสอบว่าค่าที่ป้อนไม่ว่างเปล่า
            If Not String.IsNullOrEmpty(e.FormattedValue.ToString()) Then
                ' ตรวจสอบว่าค่าที่ป้อนอยู่ในรายการของ ComboBox หรือไม่
                If Not comboBoxColumn.Items.Contains(e.FormattedValue.ToString()) Then
                    e.Cancel = True
                    MessageBox.Show("กรุณาเลือกประเภทของค่างวดที่ถูกต้อง", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        ' ตรวจสอบว่าเซลล์ในคอลัมน์ "PaymentContractNumber" ของแถวที่ถูกเลือกมีค่าอยู่หรือไม่
        If dgvPaymentDetails.SelectedCells.Count > 0 AndAlso dgvPaymentDetails.SelectedCells(0).ColumnIndex = dgvPaymentDetails.Columns("PaymentContractNumber").Index Then
            Dim contractId As String = dgvPaymentDetails.SelectedCells(0).Value?.ToString()

            ' ตรวจสอบว่า Contract ID ไม่ว่างเปล่า
            If Not String.IsNullOrEmpty(contractId) Then
                ' สร้างอินสแตนซ์ของ frmCon และกำหนดค่า SelectedContractId
                Dim frm As New frmCon()
                frm.SelectedContractId = contractId

                ' แสดงฟอร์ม frmCon
                frm.Show()
            Else
                MessageBox.Show("ไม่พบเลขที่สัญญาในแถวที่เลือก", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("กรุณาเลือกเซลล์ในคอลัมน์เลขที่สัญญา", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub


End Class
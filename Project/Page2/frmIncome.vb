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
        colPaymentType.DataPropertyName = "PaymentType" ' เพิ่มบรรทัดนี้
        ' เพิ่มรายการที่ถูกต้องให้กับ ComboBox
        colPaymentType.Items.AddRange(New String() {"เงินต้น", "ดอกเบี้ย", "ค่าปรับ", "ค่างวดสินเชื่อ", "ดอกเบี้ยค้างชำระ", "ค่าธรรมเนียมล่าช้า", "อื่น ๆ"})
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

        ' เพิ่มคอลัมน์ ComboBox สำหรับงวดการชำระ
        Dim colPaymentInstallment As New DataGridViewComboBoxColumn()
        colPaymentInstallment.HeaderText = "งวดการชำระ"
        colPaymentInstallment.Name = "PaymentInstallment"
        colPaymentInstallment.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvPaymentDetails.Columns.Add(colPaymentInstallment)

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

        ' คำนวณผลรวมของจำนวนเงินใน dgvIncomeDetails
        For Each row As DataGridViewRow In dgvIncomeDetails.Rows
            If Not row.IsNewRow Then
                Dim amount As Decimal
                If Decimal.TryParse(row.Cells("Amount").Value?.ToString(), amount) Then
                    totalAmount += amount
                End If
            End If
        Next

        ' คำนวณผลรวมของจำนวนเงินใน dgvPaymentDetails
        For Each row As DataGridViewRow In dgvPaymentDetails.Rows
            If Not row.IsNewRow Then
                Dim amount As Decimal
                If Decimal.TryParse(row.Cells("PaymentAmount").Value?.ToString(), amount) Then
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

                            If Not String.IsNullOrEmpty(incomeType) Then
                                Dim queryDetails As String = "INSERT INTO Income_Details (ind_accname, con_id, ind_amount, inc_id, m_id) VALUES (@ind_accname, @con_id, @ind_amount, @inc_id, @m_id)"
                                Using cmdDetails As New OleDbCommand(queryDetails, Conn)
                                    cmdDetails.Parameters.AddWithValue("@ind_accname", incomeType)
                                    cmdDetails.Parameters.AddWithValue("@con_id", DBNull.Value) ' ไม่มี con_id ในกรณีนี้
                                    cmdDetails.Parameters.AddWithValue("@ind_amount", amount)
                                    cmdDetails.Parameters.AddWithValue("@inc_id", incId)
                                    cmdDetails.Parameters.AddWithValue("@m_id", CInt(memberId))

                                    cmdDetails.ExecuteNonQuery()
                                End Using
                            End If
                        End If
                    Next

                    ' บันทึกข้อมูลจาก dgvPaymentDetails ลงในตาราง Income_Details
                    For Each row As DataGridViewRow In dgvPaymentDetails.Rows
                        If Not row.IsNewRow Then
                            Dim paymentType As String = If(row.Cells("PaymentType").Value, "").ToString()
                            Dim paymentContractNumber As String = If(row.Cells("PaymentContractNumber").Value, DBNull.Value).ToString()
                            Dim amount As Decimal = CDec(If(row.Cells("PaymentAmount").Value, 0))

                            If Not String.IsNullOrEmpty(paymentType) Then
                                If Not String.IsNullOrEmpty(paymentContractNumber) Then
                                    DeductBalance(paymentContractNumber, amount)
                                End If

                                Dim queryDetails As String = "INSERT INTO Income_Details (ind_accname, con_id, ind_amount, inc_id, m_id) VALUES (@ind_accname, @con_id, @ind_amount, @inc_id, @m_id)"
                                Using cmdDetails As New OleDbCommand(queryDetails, Conn)
                                    cmdDetails.Parameters.AddWithValue("@ind_accname", paymentType)
                                    cmdDetails.Parameters.AddWithValue("@con_id", If(String.IsNullOrEmpty(paymentContractNumber), DBNull.Value, paymentContractNumber))
                                    cmdDetails.Parameters.AddWithValue("@ind_amount", amount)
                                    cmdDetails.Parameters.AddWithValue("@inc_id", incId)
                                    cmdDetails.Parameters.AddWithValue("@m_id", CInt(memberId))

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
                cmdAmount.Parameters.AddWithValue("@contractNumber", CInt(contractNumber))
                Dim currentAmount As Decimal = Convert.ToDecimal(cmdAmount.ExecuteScalar())

                ' คำนวณจำนวนเงินใหม่หลังจากหักออก
                Dim newAmount As Decimal = currentAmount - amount

                ' ตรวจสอบว่าจำนวนเงินหลังหักไม่ติดลบ
                If newAmount < 0 Then
                    MessageBox.Show("ไม่สามารถหักยอดเงินได้เนื่องจากยอดเงินคงเหลือติดลบ", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                ' อัปเดตจำนวนเงินในสัญญา
                Dim queryUpdateContract As String = "UPDATE Contract SET con_amount = @newAmount WHERE con_id = @contractNumber"
                Dim cmdUpdateContract As New OleDbCommand(queryUpdateContract, Conn)
                cmdUpdateContract.Parameters.AddWithValue("@newAmount", newAmount)
                cmdUpdateContract.Parameters.AddWithValue("@contractNumber", CInt(contractNumber))
                cmdUpdateContract.ExecuteNonQuery()

                ' อัปเดตสถานะของงวดที่ 1 เป็น "ชำระเงินแล้ว" (status_id = 2) โดยตรวจสอบก่อนว่าต้องเป็นสถานะ "ต้องชำระ" (status_id = 1)
                Dim updateQuery As String = "UPDATE Payment SET payment_prin = 0, payment_interest = 0, status_id = @statusId WHERE con_id = @contractNumber AND payment_period = 1 AND status_id = 1"
                Dim updateCmd As New OleDbCommand(updateQuery, Conn)
                updateCmd.Parameters.AddWithValue("@statusId", 2) ' สถานะ 2 คือ "ชำระเงินแล้ว"
                updateCmd.Parameters.AddWithValue("@contractNumber", contractNumber)
                updateCmd.ExecuteNonQuery()

                ' อัปเดตงวดถัดไป (payment_period ที่ยังไม่ได้ชำระ) ให้เป็น "ต้องชำระ" (status_id = 1)
                Dim queryUpdateNextPayment As String = "UPDATE Payment SET status_id = 1 WHERE con_id = @contractNumber AND payment_period = (SELECT MIN(payment_period) FROM Payment WHERE con_id = @contractNumber AND status_id = 1)"
                Dim cmdUpdateNextPayment As New OleDbCommand(queryUpdateNextPayment, Conn)
                cmdUpdateNextPayment.Parameters.AddWithValue("@contractNumber", CInt(contractNumber))
                cmdUpdateNextPayment.ExecuteNonQuery()

                MessageBox.Show("อัปเดตจำนวนเงินและสถานะการชำระเงินเรียบร้อยแล้ว", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการอัปเดตจำนวนเงิน: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub UpdateNextPaymentPeriod(contractNumber As String)
        Try
            Using Conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
                Conn.Open()

                ' หา Payment ที่ต้องการชำระในงวดถัดไป
                Dim query As String = "SELECT TOP 1 payment_period FROM Payment WHERE con_id = @contractNumber AND status_id = 1 ORDER BY payment_period ASC"
                Dim cmd As New OleDbCommand(query, Conn)
                cmd.Parameters.AddWithValue("@contractNumber", contractNumber)
                Dim nextPaymentPeriod As Object = cmd.ExecuteScalar()

                ' ถ้าพบงวดถัดไปที่ต้องอัปเดต
                If nextPaymentPeriod IsNot Nothing Then
                    ' อัปเดตสถานะของงวดถัดไปเป็น "ต้องชำระ"
                    Dim updateQuery As String = "UPDATE Payment SET status_id = 1 WHERE con_id = @contractNumber AND payment_period = @nextPaymentPeriod"
                    Dim updateCmd As New OleDbCommand(updateQuery, Conn)
                    updateCmd.Parameters.AddWithValue("@contractNumber", contractNumber)
                    updateCmd.Parameters.AddWithValue("@nextPaymentPeriod", CInt(nextPaymentPeriod))
                    updateCmd.ExecuteNonQuery()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการอัปเดตงวดถัดไป: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        LoadContractNumbersForPayment(txtMemberID.Text)

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

        ' สร้างประเภทของรายรับโดยอัตโนมัติ
        currentRow.Cells("PaymentType").Value = "เงินต้น"

        ' เพิ่มอีกแถวเพื่อแสดง "ดอกเบี้ย"
        Dim rowIndex As Integer = dgvPaymentDetails.Rows.Add()
        dgvPaymentDetails.Rows(rowIndex).Cells("PaymentContractNumber").Value = contractNumber
        dgvPaymentDetails.Rows(rowIndex).Cells("PaymentType").Value = "ดอกเบี้ย"
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
        ' ตรวจสอบว่าเซลล์ที่เปลี่ยนแปลงอยู่ในคอลัมน์ PaymentContractNumber
        If e.ColumnIndex = dgvPaymentDetails.Columns("PaymentContractNumber").Index Then
            Dim contractNumber As String = dgvPaymentDetails.Rows(e.RowIndex).Cells("PaymentContractNumber").Value.ToString()

            ' ตรวจสอบว่ามีการเลือกค่าแล้วและไม่ใช่ค่า null หรือค่าว่าง
            If Not String.IsNullOrEmpty(contractNumber) Then
                ' ตรวจสอบว่าเป็นแถวแรกสุดเท่านั้นที่สามารถสร้าง "เงินต้น" และ "ดอกเบี้ย" ได้
                If Not IsPaymentAlreadyAdded(contractNumber, "เงินต้น") AndAlso Not IsPaymentAlreadyAdded(contractNumber, "ดอกเบี้ย") Then
                    ' ดึงข้อมูลเงินต้นและดอกเบี้ยจากตาราง Payment
                    Dim paymentData As (Principal As Decimal, Interest As Decimal) = GetPaymentData(contractNumber)

                    ' ตรวจสอบว่ามีการตั้งค่าดอกเบี้ยแล้วหรือยัง ถ้ายังไม่ตั้งค่า ให้ตั้งค่า
                    If dgvPaymentDetails.Rows(e.RowIndex).Cells("PaymentType").Value Is Nothing Then
                        dgvPaymentDetails.Rows(e.RowIndex).Cells("PaymentType").Value = "ดอกเบี้ย"
                        dgvPaymentDetails.Rows(e.RowIndex).Cells("PaymentAmount").Value = paymentData.Interest
                    End If

                    ' ตรวจสอบว่ามีการเพิ่มแถวสำหรับ "เงินต้น" แล้วหรือยัง ถ้ายังไม่มี ให้เพิ่มแถว
                    If Not IsPaymentAlreadyAdded(contractNumber, "เงินต้น") Then
                        Dim rowIndex As Integer = dgvPaymentDetails.Rows.Add()
                        dgvPaymentDetails.Rows(rowIndex).Cells("PaymentContractNumber").Value = contractNumber
                        dgvPaymentDetails.Rows(rowIndex).Cells("PaymentType").Value = "เงินต้น"
                        dgvPaymentDetails.Rows(rowIndex).Cells("PaymentAmount").Value = paymentData.Principal
                    End If
                End If
            End If
        End If
    End Sub

    ' ฟังก์ชันสำหรับดึงข้อมูลเงินต้นและดอกเบี้ยตาม PaymentContractNumber
    Private Function GetPaymentData(contractNumber As String) As (Principal As Decimal, Interest As Decimal)
        Dim principalAmount As Decimal = 0
        Dim interestAmount As Decimal = 0
        Using Conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
            Conn.Open()
            ' SQL query ที่แก้ไขเพื่อดึงข้อมูลที่ยังไม่ได้ชำระและเรียงตาม payment_period
            Dim query As String = "SELECT payment_prin, payment_interest FROM Payment WHERE con_id = @contractNumber AND status_id = 1 ORDER BY payment_period ASC"
            Dim cmd As New OleDbCommand(query, Conn)
            cmd.Parameters.AddWithValue("@contractNumber", contractNumber)
            Dim reader As OleDbDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                principalAmount = Convert.ToDecimal(reader("payment_prin"))
                interestAmount = Convert.ToDecimal(reader("payment_interest"))
            Else
                ' ถ้าไม่พบข้อมูลในตาราง Payment ให้ดึงข้อมูลจากตาราง Contract
                query = "SELECT con_amount, con_interest FROM Contract WHERE con_id = @contractNumber"
                cmd = New OleDbCommand(query, Conn)
                cmd.Parameters.AddWithValue("@contractNumber", contractNumber)
                reader = cmd.ExecuteReader()
                If reader.Read() Then
                    principalAmount = Convert.ToDecimal(reader("con_amount"))
                    interestAmount = Convert.ToDecimal(reader("con_interest"))
                End If
            End If
        End Using
        Return (Principal:=principalAmount, Interest:=interestAmount)
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


End Class
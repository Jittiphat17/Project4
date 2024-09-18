Imports System.Data.OleDb
Imports System.Globalization
Imports Guna.UI2.WinForms
Imports Microsoft.Reporting.WinForms

Public Class frmBrrow
    Private Conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
    Private cmd As OleDbCommand
    Private strSQL As String

    Private Sub frmBrrow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupEventHandlers()
        Auto_id()
        ClearAllData()
        SetupDataGridView()
        SetupDateTimePicker()
        LoadAutoCompleteData()
        LoadAccountData()
        LoadPerMData()
        LoadGuaranteeTypes() ' โหลดตัวเลือกการค้ำประกัน
    End Sub

    Private Sub LoadGuaranteeTypes()
        ' เพิ่มตัวเลือกลงใน ComboBox สำหรับการค้ำประกัน
        cbGuaranteeType.Items.Clear()
        cbGuaranteeType.Items.Add("เลือกการค้ำประกัน")
        cbGuaranteeType.Items.Add("ผู้ค้ำประกัน")
        cbGuaranteeType.Items.Add("เงินในบัญชี")
        cbGuaranteeType.Items.Add("อื่น ๆ")
        cbGuaranteeType.SelectedIndex = 0 ' ตั้งค่าเป็นค่าเริ่มต้น
    End Sub

    Private Sub SetupDataGridView()
        dgvConn.Columns.Clear()
        Dim columnNames As String() = {"เลขที่สัญญา", "ผู้กู้", "รายละเอียดผู้กู้", "จำนวนเงินกู้", "แหล่งจ่าย",
                                       "จำนวนเดือน", "ดอกเบี้ย", "วันที่ทำรายการ", "ผู้ค้ำที่ 1", "ผู้ค้ำที่ 2",
                                       "ผู้ค้ำที่ 3", "ผ่อนชำระต่อเดือน"}
        For Each colName As String In columnNames
            dgvConn.Columns.Add(colName, colName)
        Next
    End Sub

    Private Sub SetupEventHandlers()
        AddHandler txtSearch.TextChanged, AddressOf txtSearch_TextChanged
        AddHandler txtSearch1.TextChanged, AddressOf txtSearch_TextChanged
        AddHandler txtSearch2.TextChanged, AddressOf txtSearch_TextChanged
        AddHandler txtSearch3.TextChanged, AddressOf txtSearch_TextChanged
        AddHandler chkGuarantor.CheckedChanged, AddressOf chkGuarantor_CheckedChanged
    End Sub

    Private Sub LoadAccountData()
        Using conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
            conn.Open()
            Using cmd As New OleDbCommand("SELECT acc_id, acc_name FROM Account", conn)
                Using reader As OleDbDataReader = cmd.ExecuteReader()
                    Dim accountDict As New Dictionary(Of String, String)()

                    If cbAccount.Items.Count = 0 Then
                        cbAccount.Items.Add("เลือกบัญชี")
                    End If

                    While reader.Read()
                        Dim accId As String = reader("acc_id").ToString()
                        Dim accName As String = reader("acc_name").ToString()
                        If Not accountDict.ContainsKey(accId) Then
                            accountDict.Add(accId, accName)
                            cbAccount.Items.Add(accName)
                        End If
                    End While

                    cbAccount.Tag = accountDict
                End Using
            End Using
        End Using
    End Sub

    Private Sub LoadPerMData()
        cbPerM.Items.Clear()
        cbPerM.Items.AddRange(New String() {"เลือกจำนวนเดือน", "6เดือน", "12เดือน", "18เดือน", "24เดือน", "36เดือน", "48เดือน", "60เดือน"})
        cbPerM.SelectedIndex = 0
    End Sub

    Private Sub LoadAutoCompleteData()
        Using conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
            conn.Open()
            Using cmd As New OleDbCommand("SELECT m_name FROM Member", conn)
                Using reader As OleDbDataReader = cmd.ExecuteReader()
                    Dim autoComplete As New AutoCompleteStringCollection()
                    While reader.Read()
                        autoComplete.Add(reader("m_name").ToString())
                    End While

                    ' แทนที่ TextBox เดิมด้วย Guna2TextBox
                    Dim textBoxes As Guna2TextBox() = {txtSearch, txtSearch1, txtSearch2, txtSearch3}
                    For Each tb As Guna2TextBox In textBoxes
                        tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                        tb.AutoCompleteSource = AutoCompleteSource.CustomSource
                        tb.AutoCompleteCustomSource = autoComplete
                    Next
                End Using
            End Using
        End Using
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs)
        Dim tb As Guna2TextBox = CType(sender, Guna2TextBox)
        If String.IsNullOrWhiteSpace(tb.Text) Then Exit Sub

        Using conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
            conn.Open()
            Using cmd As New OleDbCommand("SELECT m_id, m_name, m_address, m_tel FROM Member WHERE m_name LIKE @m_name", conn)
                cmd.Parameters.AddWithValue("@m_name", "%" & tb.Text & "%")
                Using reader As OleDbDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim detail As String = String.Format("รหัสสมาชิก: {0}, ชื่อ-นามสกุล: {1}, ที่อยู่: {2}, เบอร์โทรติดต่อ: {3}",
                                                             reader("m_id"), reader("m_name"), reader("m_address"), reader("m_tel"))
                        Dim detailTextBox As Guna2TextBox = FindDetailTextBoxForSearchBox(tb)
                        If detailTextBox IsNot Nothing Then detailTextBox.Text = detail
                    Else
                        Dim detailTextBox As Guna2TextBox = FindDetailTextBoxForSearchBox(tb)
                        If detailTextBox IsNot Nothing Then detailTextBox.Text = String.Empty
                    End If
                End Using
            End Using
        End Using
    End Sub

    Private Function FindDetailTextBoxForSearchBox(searchBox As Guna2TextBox) As Guna2TextBox
        Select Case searchBox.Name
            Case "txtSearch"
                Return txtDetail
            Case "txtSearch1"
                Return txtDetail1
            Case "txtSearch2"
                Return txtDetail2
            Case "txtSearch3"
                Return txtDetail3
            Case Else
                Return Nothing
        End Select
    End Function

    Private Sub Auto_id()
        Using conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
            conn.Open()
            Using cmd As New OleDbCommand("SELECT MAX(con_id) FROM Contract", conn)
                Dim result As Object = cmd.ExecuteScalar()
                Dim newId As Integer = If(IsDBNull(result), 1, Convert.ToInt32(result) + 1)
                txtCid.Text = newId.ToString("D4")
            End Using
        End Using
    End Sub

    Private Sub ClearAllData()
        txtSearch.Clear()
        txtSearch1.Clear()
        txtSearch2.Clear()
        txtSearch3.Clear()
        txtDetail.Clear()
        txtDetail1.Clear()
        txtDetail2.Clear()
        txtDetail3.Clear()
        txtMoney.Clear()

        If cbAccount.Items.Count > 0 Then cbAccount.SelectedIndex = 0
        LoadPerMData()

        dtpBirth.Value = DateTime.Today
        chkGuarantor.Checked = False
    End Sub

    Private Sub SetupDateTimePicker()
        dtpBirth.Format = DateTimePickerFormat.Custom
        dtpBirth.CustomFormat = "dd/MM/yyyy"
        dtpBirth.Value = DateTime.Now
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' ตรวจสอบว่าข้อมูลที่จำเป็นได้รับการกรอกครบถ้วนหรือไม่
        If Not IsDataComplete() Then
            MessageBox.Show("กรุณากรอกข้อมูลให้ครบถ้วน", "ข้อมูลไม่ครบ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' รับข้อมูลจากฟอร์ม
        Dim principal As Decimal = Decimal.Parse(txtMoney.Text)  ' จำนวนเงินกู้
        Dim loanDate As DateTime = dtpBirth.Value ' Date of the loan
        Dim interestRate As Decimal = Decimal.Parse(txtPercen.Text)  ' อัตราดอกเบี้ยต่อปี
        Dim totalPayments As Integer = Integer.Parse(cbPerM.SelectedItem.ToString().Replace("เดือน", "").Trim())  ' จำนวนเดือน

        ' ตรวจสอบว่าเลือกประเภทการค้ำประกันอะไร
        If cbGuaranteeType.SelectedItem.ToString() = "เงินในบัญชี" Then
            Try
                Dim loanAmount As Decimal
                If Decimal.TryParse(txtMoney.Text, loanAmount) Then
                    ' ดึง m_id ของผู้กู้
                    Dim borrowerId As Integer = GetMemberIdByName(txtSearch.Text)
                    If borrowerId = -1 Then
                        MessageBox.Show("ไม่พบข้อมูลผู้กู้", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If

                    ' ตรวจสอบเงินในบัญชีสัจจะของผู้กู้
                    Dim savingsBalance As Decimal = GetSavingsBalance(borrowerId)

                    If savingsBalance >= loanAmount Then
                        MessageBox.Show("สามารถใช้เงินในบัญชีค้ำประกันได้ เนื่องจากมีเงินสะสม " & savingsBalance.ToString("N2") & " บาท ซึ่งมากกว่าหรือเท่ากับเงินที่จะกู้ " & loanAmount.ToString("N2") & " บาท", "การค้ำประกัน", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ' ดำเนินการต่อไปสำหรับการใช้เงินในบัญชีค้ำประกัน
                    Else
                        MessageBox.Show("เงินในบัญชีไม่เพียงพอสำหรับการค้ำประกัน เนื่องจากมีเงินสะสมเพียง " & savingsBalance.ToString("N2") & " บาท ซึ่งน้อยกว่าเงินที่จะกู้ " & loanAmount.ToString("N2") & " บาท ต้องใช้ผู้ค้ำประกัน", "การค้ำประกัน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        ' ดำเนินการต่อไปสำหรับกรณีที่ต้องใช้ผู้ค้ำประกัน
                    End If
                Else
                    MessageBox.Show("กรุณากรอกจำนวนเงินที่ต้องการกู้ให้ถูกต้อง", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As OleDbException
                MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

        ' คำนวณการชำระเงินรายเดือน
        Dim monthlyPayment As Decimal = CalculateMonthlyPayment(principal, interestRate, totalPayments)

        ' ดึง acc_id จากชื่อบัญชีที่เลือกใน ComboBox
        Dim accountDict As Dictionary(Of String, String) = CType(cbAccount.Tag, Dictionary(Of String, String))
        Dim acc_id As String = accountDict.FirstOrDefault(Function(x) x.Value = cbAccount.SelectedItem.ToString()).Key

        ' สร้างอาร์เรย์สตริงที่มีข้อมูลจากฟอร์ม
        Dim rowData As String() = New String() {
        txtCid.Text,
        txtSearch.Text,  ' สมมติว่านี่คือชื่อผู้กู้
        txtDetail.Text,  ' รายละเอียดผู้กู้
        String.Format("{0:n0} บาท", principal),   ' จำนวนเงินกู้
        cbAccount.SelectedItem.ToString(),  ' แหล่งจ่าย
        cbPerM.SelectedItem.ToString(),     ' จำนวนเดือน
        txtPercen.Text,   ' ดอกเบี้ย
        dtpBirth.Value.ToString("dd/MM/yyyy"),  ' วันที่ทำรายการ
        If(chkGuarantor.Checked, txtSearch1.Text, ""), ' ผู้ค้ำที่ 1
        If(chkGuarantor.Checked, txtSearch2.Text, ""), ' ผู้ค้ำที่ 2
        If(chkGuarantor.Checked, txtSearch3.Text, ""), ' ผู้ค้ำที่ 3
        monthlyPayment.ToString("F2")  ' ผ่อนชำระต่อเดือน
    }

        ' เพิ่มข้อมูลเป็นแถวใหม่ใน DataGridView
        dgvConn.Rows.Add(rowData)

        ' เคลียร์ข้อมูลในฟอร์มหลังจากเพิ่มข้อมูล
        ClearAllData()

        ' อัปเดต ID สัญญาใหม่
        Auto_id()
    End Sub

    ' ฟังก์ชันสำหรับดึงยอดเงินสะสมในบัญชีสัจจะ
    Private Function GetSavingsBalance(memberId As Integer) As Decimal
        Dim savingsBalance As Decimal = 0
        Using conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
            conn.Open()

            ' ปรับคำสั่ง SQL เพื่อดึงข้อมูลจากตาราง Income_Details โดยตรง
            Dim strSQL As String = "SELECT SUM(ind_amount) AS TotalSavings " &
                               "FROM Income_Details " &
                               "WHERE m_id = @memberId " &
                               "AND ind_accname = 'เงินฝากสัจจะ'"

            Using cmd As New OleDbCommand(strSQL, conn)
                cmd.Parameters.AddWithValue("@memberId", memberId)

                ' Debug message for SQL query
                MessageBox.Show($"Debug: SQL Query = {strSQL}, memberId = {memberId}")

                ' Execute the query and get the result
                Dim result As Object = cmd.ExecuteScalar()
                If result IsNot DBNull.Value Then
                    savingsBalance = Convert.ToDecimal(result)
                End If

                ' Debug message for the raw result and the converted balance
                MessageBox.Show($"Debug: Raw result = {result}, Converted balance = {savingsBalance}")
            End Using
        End Using
        Return savingsBalance
    End Function


    ' ส่วนของการตรวจสอบการค้ำประกันด้วยเงินในบัญชี
    Private Sub CheckGuaranteeWithSavings()
        If cbGuaranteeType.SelectedItem.ToString() = "เงินในบัญชี" Then
            Try
                Dim loanAmount As Decimal
                If Decimal.TryParse(txtMoney.Text, loanAmount) Then
                    ' ดึง m_id ของผู้กู้
                    Dim borrowerId As Integer = GetMemberIdByName(txtSearch.Text)
                    If borrowerId = -1 Then
                        MessageBox.Show("ไม่พบข้อมูลผู้กู้", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If

                    ' ตรวจสอบเงินในบัญชีสัจจะของผู้กู้
                    Dim savingsBalance As Decimal = GetSavingsBalance(borrowerId)

                    ' Debug message
                    MessageBox.Show($"Debug: Loan Amount = {loanAmount}, Savings Balance = {savingsBalance}")

                    If savingsBalance >= loanAmount Then
                        MessageBox.Show("สามารถใช้เงินในบัญชีค้ำประกันได้ เนื่องจากมีเงินสะสม " &
                                savingsBalance.ToString("N2") & " บาท ซึ่งมากกว่าหรือเท่ากับเงินที่จะกู้ " &
                                loanAmount.ToString("N2") & " บาท", "การค้ำประกัน",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ' ดำเนินการต่อไปสำหรับการใช้เงินในบัญชีค้ำประกัน
                    Else
                        MessageBox.Show("เงินในบัญชีไม่เพียงพอสำหรับการค้ำประกัน เนื่องจากมีเงินสะสมเพียง " &
                                savingsBalance.ToString("N2") & " บาท ซึ่งน้อยกว่าเงินที่จะกู้ " &
                                loanAmount.ToString("N2") & " บาท ต้องใช้ผู้ค้ำประกัน", "การค้ำประกัน",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        ' ดำเนินการต่อไปสำหรับกรณีที่ต้องใช้ผู้ค้ำประกัน
                    End If
                Else
                    MessageBox.Show("กรุณากรอกจำนวนเงินที่ต้องการกู้ให้ถูกต้อง", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As OleDbException
                MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' เรียกใช้ฟังก์ชันตรวจสอบเมื่อต้องการ เช่น เมื่อกดปุ่มหรือเลือกประเภทการค้ำประกัน
    Private Sub cbGuaranteeType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbGuaranteeType.SelectedIndexChanged
        If cbGuaranteeType.SelectedItem.ToString() = "เงินในบัญชี" Then
            CheckGuaranteeWithSavings()
        End If
    End Sub



    Private Function IsDataComplete() As Boolean
        ' Validate that all necessary fields are filled out and contain valid numbers
        If Not Decimal.TryParse(txtMoney.Text, Nothing) Then
            MessageBox.Show("กรุณากรอกจำนวนเงินที่ถูกต้อง", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If Not Decimal.TryParse(txtPercen.Text, Nothing) Then
            MessageBox.Show("กรุณากรอกอัตราดอกเบี้ยที่ถูกต้อง", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return Not String.IsNullOrWhiteSpace(txtCid.Text) AndAlso
               Not String.IsNullOrWhiteSpace(txtSearch.Text) AndAlso
               Not String.IsNullOrWhiteSpace(txtDetail.Text) AndAlso
               cbAccount.SelectedIndex > 0 AndAlso
               cbPerM.SelectedIndex > 0 AndAlso
               (Not chkGuarantor.Checked OrElse
                (Not String.IsNullOrWhiteSpace(txtSearch1.Text) AndAlso Not String.IsNullOrWhiteSpace(txtDetail1.Text)))
    End Function

    Private Sub chkGuarantor_CheckedChanged(sender As Object, e As EventArgs) Handles chkGuarantor.CheckedChanged
        txtSearch1.Enabled = chkGuarantor.Checked
        txtSearch2.Enabled = chkGuarantor.Checked
        txtSearch3.Enabled = chkGuarantor.Checked
        txtDetail1.Enabled = chkGuarantor.Checked
        txtDetail2.Enabled = chkGuarantor.Checked
        txtDetail3.Enabled = chkGuarantor.Checked
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            ' ใช้การเชื่อมต่อใหม่และใช้ Using statement เพื่อจัดการการเชื่อมต่อ
            Using conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
                conn.Open()

                For Each row As DataGridViewRow In dgvConn.Rows
                    If Not row.IsNewRow Then
                        Dim borrowerName As String = row.Cells("ผู้กู้").Value.ToString()
                        Dim loanAmount As Decimal = Decimal.Parse(row.Cells("จำนวนเงินกู้").Value.ToString().Replace(" บาท", "").Replace(",", ""))
                        Dim accountDict As Dictionary(Of String, String) = CType(cbAccount.Tag, Dictionary(Of String, String))
                        Dim acc_id As String = accountDict.FirstOrDefault(Function(x) x.Value = row.Cells("แหล่งจ่าย").Value.ToString()).Key
                        Dim periodText As String = row.Cells("จำนวนเดือน").Value.ToString()
                        Dim interest As Decimal = Decimal.Parse(row.Cells("ดอกเบี้ย").Value.ToString())
                        Dim transactionDateStr As String = row.Cells("วันที่ทำรายการ").Value.ToString()
                        Dim guarantorName1 As String = row.Cells("ผู้ค้ำที่ 1").Value.ToString()
                        Dim guarantorName2 As String = row.Cells("ผู้ค้ำที่ 2").Value.ToString()
                        Dim guarantorName3 As String = row.Cells("ผู้ค้ำที่ 3").Value.ToString()

                        Dim period As Integer = Integer.Parse(periodText.Replace("เดือน", ""))

                        Dim transactionDate As DateTime
                        If Not DateTime.TryParseExact(transactionDateStr, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, transactionDate) Then
                            MessageBox.Show("รูปแบบวันที่ไม่ถูกต้อง: " & transactionDateStr, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return
                        End If

                        Dim borrowerId As Integer = GetMemberIdByName(borrowerName)
                        If borrowerId = -1 Then
                            MessageBox.Show("ไม่พบข้อมูลผู้กู้", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return
                        End If

                        ' Insert into Contract table
                        strSQL = "INSERT INTO Contract (m_id, con_details, con_amount, con_interest, con_permonth, con_date, acc_id) VALUES (@m_id, @con_details, @con_amount, @con_interest, @con_permonth, @con_date, @acc_id)"
                        Using cmd As New OleDbCommand(strSQL, conn)
                            cmd.Parameters.AddWithValue("@m_id", borrowerId)
                            cmd.Parameters.AddWithValue("@con_details", row.Cells("รายละเอียดผู้กู้").Value.ToString())
                            cmd.Parameters.AddWithValue("@con_amount", loanAmount)
                            cmd.Parameters.AddWithValue("@con_interest", interest)
                            cmd.Parameters.AddWithValue("@con_permonth", period)
                            cmd.Parameters.AddWithValue("@con_date", transactionDate)
                            cmd.Parameters.AddWithValue("@acc_id", acc_id)

                            cmd.ExecuteNonQuery()

                            cmd.CommandText = "SELECT @@IDENTITY"
                            Dim con_id As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                            ' Insert into Guarantor table
                            Dim guarantorNames As String() = {guarantorName1, guarantorName2, guarantorName3}

                            For Each guarantorName As String In guarantorNames
                                If Not String.IsNullOrEmpty(guarantorName) Then
                                    Dim guarantorId As Integer = GetMemberIdByName(guarantorName)
                                    If guarantorId <> -1 Then
                                        strSQL = "INSERT INTO Guarantor (con_id, m_id) VALUES (@con_id, @m_id)"
                                        Using guarantorCmd As New OleDbCommand(strSQL, conn)
                                            guarantorCmd.Parameters.AddWithValue("@con_id", con_id)
                                            guarantorCmd.Parameters.AddWithValue("@m_id", guarantorId)
                                            guarantorCmd.ExecuteNonQuery()
                                        End Using
                                    End If
                                End If
                            Next

                            ' Insert into Payment table
                            Dim monthlyPayment As Decimal = CalculateMonthlyPayment(loanAmount, interest, period)

                            For i As Integer = 1 To period
                                Dim paymentDate As DateTime = transactionDate.AddMonths(i)
                                strSQL = "INSERT INTO Payment (con_id, payment_date, payment_amount, status_id) VALUES (@con_id, @payment_date, @payment_amount, 1)"
                                Using paymentCmd As New OleDbCommand(strSQL, conn)
                                    paymentCmd.Parameters.AddWithValue("@con_id", con_id)
                                    paymentCmd.Parameters.AddWithValue("@payment_date", paymentDate)
                                    paymentCmd.Parameters.AddWithValue("@payment_amount", monthlyPayment)
                                    paymentCmd.ExecuteNonQuery()
                                End Using
                            Next

                            ' Insert into Account_Details table
                            strSQL = "INSERT INTO Account_Details (acc_id, m_id) VALUES (@acc_id, @m_id)"
                            Using accountDetailsCmd As New OleDbCommand(strSQL, conn)
                                accountDetailsCmd.Parameters.AddWithValue("@acc_id", acc_id)
                                accountDetailsCmd.Parameters.AddWithValue("@m_id", borrowerId)
                                accountDetailsCmd.ExecuteNonQuery()
                            End Using

                            ' Insert into Expense table
                            strSQL = "INSERT INTO Expense (ex_name, ex_detail, ex_description, ex_date, ex_amount, acc_id) VALUES (@ex_name, @ex_detail, @ex_description, @ex_date, @ex_amount, @acc_id)"
                            Using cmdExpense As New OleDbCommand(strSQL, conn)
                                cmdExpense.Parameters.AddWithValue("@ex_name", borrowerName)  ' ชื่อผู้กู้
                                cmdExpense.Parameters.AddWithValue("@ex_detail", row.Cells("รายละเอียดผู้กู้").Value.ToString())  ' รายละเอียดผู้กู้
                                cmdExpense.Parameters.AddWithValue("@ex_description", "เงินกู้ยืมสำหรับ " & borrowerName)  ' คำอธิบาย
                                cmdExpense.Parameters.AddWithValue("@ex_date", transactionDate)  ' วันที่ทำรายการ
                                cmdExpense.Parameters.AddWithValue("@ex_amount", loanAmount)  ' จำนวนเงินที่กู้
                                cmdExpense.Parameters.AddWithValue("@acc_id", acc_id)  ' รหัสบัญชี

                                cmdExpense.ExecuteNonQuery()

                                ' ดึง ex_id จากตาราง Expense
                                cmdExpense.CommandText = "SELECT @@IDENTITY"
                                Dim ex_id As Integer = Convert.ToInt32(cmdExpense.ExecuteScalar())

                                ' ดึงชื่อบัญชีจาก DataGridView แทน ComboBox
                                Dim accountNameFromGrid As String = row.Cells("แหล่งจ่าย").Value.ToString() ' ดึงค่าชื่อบัญชีจาก DataGridView

                                ' Insert into Expense_Details table
                                strSQL = "INSERT INTO Expense_Details (exd_nameacc, exd_amount, ex_id) VALUES (@exd_nameacc, @exd_amount, @ex_id)"
                                Using cmdExpenseDetails As New OleDbCommand(strSQL, conn)
                                    cmdExpenseDetails.Parameters.AddWithValue("@exd_nameacc", accountNameFromGrid)  ' ชื่อบัญชีจาก DataGridView
                                    cmdExpenseDetails.Parameters.AddWithValue("@exd_amount", loanAmount)  ' จำนวนเงิน
                                    cmdExpenseDetails.Parameters.AddWithValue("@ex_id", ex_id)  ' รหัส ex_id จากตาราง Expense

                                    cmdExpenseDetails.ExecuteNonQuery()
                                End Using
                            End Using

                        End Using
                    End If
                Next

                MessageBox.Show("บันทึกข้อมูลสำเร็จ", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information)

                dgvConn.Rows.Clear()

            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetMemberIdByName(name As String) As Integer
        strSQL = "SELECT m_id FROM Member WHERE m_name = @m_name"
        Using cmd As New OleDbCommand(strSQL, Conn)
            cmd.Parameters.AddWithValue("@m_name", name)

            Try
                If Conn.State = ConnectionState.Open Then Conn.Close()
                Conn.Open()
                Using reader As OleDbDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Return Integer.Parse(reader("m_id").ToString())
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Conn.Close()
            End Try
        End Using

        Return -1
    End Function

    Private Function CalculateMonthlyPayment(principal As Decimal, monthlyInterestRate As Decimal, totalPayments As Integer) As Decimal
        ' ดอกเบี้ยทั้งหมดที่ต้องจ่าย
        Dim totalInterest As Decimal = principal * (monthlyInterestRate / 100) * totalPayments
        ' เงินต้นรวมดอกเบี้ยทั้งหมด
        Dim totalAmount As Decimal = principal + totalInterest
        ' ผ่อนชำระต่อเดือน
        Dim monthlyPayment As Decimal = totalAmount / totalPayments
        Return monthlyPayment
    End Function

End Class

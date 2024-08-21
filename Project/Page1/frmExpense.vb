Imports System.Data.OleDb

Public Class frmExpense
    ' เชื่อมต่อกับฐานข้อมูล Access
    Private Conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\db_test.mdb")

    Private Sub frmExpense_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupDataGridView()
        LoadExpenseTypes()
        LoadMemberData()
        LoadAccountData()
        GenerateNextExpenseId() ' เรียกฟังก์ชันนี้เมื่อฟอร์มโหลด
    End Sub

    Private Sub GenerateNextExpenseId()
        Try
            Conn.Open()
            Dim query As String = "SELECT MAX(ex_id) FROM Expense"
            Dim cmd As New OleDbCommand(query, Conn)
            Dim result As Object = cmd.ExecuteScalar()

            If IsDBNull(result) Then
                txtExpId.Text = "1" ' ถ้าไม่มีข้อมูลในตาราง Expense เลย ให้เริ่มต้นจาก 1
            Else
                txtExpId.Text = (Convert.ToInt32(result) + 1).ToString() ' ถ้ามีข้อมูลอยู่แล้ว เพิ่มจากค่าที่มากที่สุด
            End If
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการสร้างเลขที่รายจ่ายใหม่: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub SetupDataGridView()
        ' เพิ่มคอลัมน์ ComboBox สำหรับประเภทของรายจ่าย
        Dim colExpenseType As New DataGridViewComboBoxColumn()
        colExpenseType.HeaderText = "ประเภทของรายจ่าย"
        colExpenseType.Name = "ExpenseType"
        colExpenseType.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvExpenseDetails.Columns.Add(colExpenseType)

        ' เพิ่มคอลัมน์สำหรับจำนวนเงิน
        Dim colAmount As New DataGridViewTextBoxColumn()
        colAmount.HeaderText = "จำนวนเงิน"
        colAmount.Name = "Amount"
        colAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        colAmount.DefaultCellStyle.Format = "N2"
        colAmount.ValueType = GetType(Decimal)
        dgvExpenseDetails.Columns.Add(colAmount)

        ' ตั้งค่าเพิ่มเติมให้ DataGridView
        dgvExpenseDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvExpenseDetails.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvExpenseDetails.RowTemplate.Height = 30
        dgvExpenseDetails.AllowUserToAddRows = True
    End Sub

    Private Sub LoadAccountData()
        Try
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
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการโหลดข้อมูลบัญชี: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub LoadExpenseTypes()
        Try
            Conn.Open()
            Dim expenseTypeColumn As DataGridViewComboBoxColumn = CType(dgvExpenseDetails.Columns("ExpenseType"), DataGridViewComboBoxColumn)
            expenseTypeColumn.Items.Clear() ' ล้างรายการเก่า

            ' เพิ่มรายการใหม่
            expenseTypeColumn.Items.Add("ค่าสินค้า")
            expenseTypeColumn.Items.Add("ค่าบริการ")
            expenseTypeColumn.Items.Add("ค่าเช่า")
            expenseTypeColumn.Items.Add("ค่าเดินทาง")
            expenseTypeColumn.Items.Add("ค่าซ่อมบำรุง")
            expenseTypeColumn.Items.Add("ค่าใช้จ่ายอื่น ๆ")
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการโหลดข้อมูลประเภทรายจ่าย: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub LoadMemberData()
        Try
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
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการโหลดข้อมูลสมาชิก: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub DisplayMemberDetails(memberName As String)
        If String.IsNullOrEmpty(memberName) Then
            txtDetails.Clear()
            Return
        End If

        Try
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
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการดึงข้อมูลสมาชิก: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub CalculateTotalAmount()
        Dim totalAmount As Decimal = 0

        ' คำนวณผลรวมของจำนวนเงินใน DataGridView
        For Each row As DataGridViewRow In dgvExpenseDetails.Rows
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

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' แปลงค่าใน lblTotalAmount และ txtAmount ให้เป็น Decimal ก่อนเปรียบเทียบ
        Dim totalAmount As Decimal
        Dim inputAmount As Decimal

        ' ลองแปลงค่าจาก lblTotalAmount และ txtAmount
        If Decimal.TryParse(lblTotalAmount.Text, totalAmount) AndAlso Decimal.TryParse(txtAmount.Text, inputAmount) Then
            ' ตรวจสอบว่าค่าทั้งสองเท่ากันหรือไม่
            If totalAmount = inputAmount Then
                ' บันทึกข้อมูล
                SaveData()

                ' ปิดการใช้งานปุ่ม "บันทึก" จนกว่าจะมีการเพิ่มรายการใหม่
                btnSave.Enabled = False
            Else
                MessageBox.Show("จำนวนเงินรวมไม่ตรงกับจำนวนเงินที่ระบุ", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("กรุณากรอกจำนวนเงินที่ถูกต้อง", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub SaveData()
        Try
            If cboDepositType.SelectedValue Is Nothing Then
                MessageBox.Show("กรุณาเลือกบัญชี", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Using Conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\db_test.mdb")
                Conn.Open()

                ' บันทึกข้อมูลลงในตาราง Expense
                Dim queryExpense As String = "INSERT INTO Expense (ex_id, ex_name, ex_detail, ex_description, ex_date, ex_amount, acc_id) VALUES (@ex_id, @ex_name, @ex_detail, @ex_description, @ex_date, @ex_amount, @acc_id)"
                Using cmdExpense As New OleDbCommand(queryExpense, Conn)
                    cmdExpense.Parameters.AddWithValue("@ex_id", Convert.ToInt32(txtExpId.Text))
                    cmdExpense.Parameters.AddWithValue("@ex_name", txtMemberID.Text)
                    cmdExpense.Parameters.AddWithValue("@ex_detail", txtDetails.Text)
                    cmdExpense.Parameters.AddWithValue("@ex_description", txtDescrip.Text)
                    cmdExpense.Parameters.AddWithValue("@ex_date", dtpBirth.Value)
                    cmdExpense.Parameters.AddWithValue("@ex_amount", Decimal.Parse(lblTotalAmount.Text))
                    cmdExpense.Parameters.AddWithValue("@acc_id", cboDepositType.SelectedValue)

                    cmdExpense.ExecuteNonQuery()

                    ' ดึง ex_id ล่าสุดที่ถูกเพิ่มลงในตาราง Expense
                    ' กรณีที่คุณต้องการดึง ex_id ที่เพิ่งเพิ่ม
                    ' cmdExpense.CommandText = "SELECT @@IDENTITY"
                    ' Dim exId As Integer = CInt(cmdExpense.ExecuteScalar())
                    Dim exId As Integer = Convert.ToInt32(txtExpId.Text)

                    ' บันทึกข้อมูลลงในตาราง Expense_Details
                    For Each row As DataGridViewRow In dgvExpenseDetails.Rows
                        If Not row.IsNewRow Then
                            Dim expenseType As String = If(row.Cells("ExpenseType").Value, "").ToString()
                            Dim amount As Decimal = Decimal.Parse(If(row.Cells("Amount").Value, 0).ToString())

                            If Not String.IsNullOrEmpty(expenseType) Then
                                ' บันทึกข้อมูลลงในตาราง Expense_Details
                                Dim queryDetails As String = "INSERT INTO Expense_Details (exd_nameacc, exd_amount, ex_id) VALUES (@exd_nameacc, @exd_amount, @ex_id)"
                                Using cmdDetails As New OleDbCommand(queryDetails, Conn)
                                    cmdDetails.Parameters.AddWithValue("@exd_nameacc", expenseType)
                                    cmdDetails.Parameters.AddWithValue("@exd_amount", amount)
                                    cmdDetails.Parameters.AddWithValue("@ex_id", exId)
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


    Private Sub ClearAll()
        ' ล้างข้อมูลในฟอร์ม
        txtMemberID.Clear()
        txtDetails.Clear()
        txtAmount.Clear()
        cboDepositType.SelectedIndex = -1
        lblTotalAmount.Text = "0.00"

        ' ล้างข้อมูลใน DataGridView
        dgvExpenseDetails.Rows.Clear()

        ' โหลดข้อมูลใหม่สำหรับ ComboBox ใน DataGridView
        LoadExpenseTypes()

        ' สร้างเลขที่รายจ่ายใหม่
        GenerateNextExpenseId()
    End Sub

    Private Sub txtMemberID_TextChanged(sender As Object, e As EventArgs) Handles txtMemberID.TextChanged
        DisplayMemberDetails(txtMemberID.Text)
    End Sub

    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        CalculateTotalAmount()
    End Sub

    Private Sub dgvExpenseDetails_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvExpenseDetails.DataError
        MessageBox.Show("มีข้อผิดพลาดในการกรอกข้อมูลในเซลล์ กรุณาตรวจสอบค่าที่คุณกรอกให้ตรงกับรายการที่มีใน ComboBox", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        e.ThrowException = False
    End Sub

    Private Sub dgvExpenseDetails_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvExpenseDetails.CellValidating
        If dgvExpenseDetails.Columns(e.ColumnIndex).Name = "ExpenseType" Then
            Dim comboBoxColumn As DataGridViewComboBoxColumn = CType(dgvExpenseDetails.Columns("ExpenseType"), DataGridViewComboBoxColumn)
            If Not comboBoxColumn.Items.Contains(e.FormattedValue.ToString()) Then
                MessageBox.Show("กรุณาเลือกประเภทของรายจ่ายที่ถูกต้อง", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub dgvExpenseDetails_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvExpenseDetails.RowsAdded
        btnSave.Enabled = True
        btnCalculate.Enabled = True
    End Sub
End Class

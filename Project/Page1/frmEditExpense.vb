Imports System.Data.OleDb

Public Class frmEditExpense
    Dim conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
    Private expenseID As String = "" ' เก็บค่า ex_id ของรายจ่ายที่ถูกเลือก

    Private Sub frmEditExpense_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAccounts() ' โหลดข้อมูลบัญชี
        LoadExpenses() ' โหลดรายการรายจ่าย
        ConfigureDataGridView() ' ตั้งค่าการแสดงผลของ DataGridView
        ConfigureDetailsDataGridView() ' ตั้งค่าการแสดงผลของ DataGridView สำหรับรายละเอียดรายจ่าย

        ' ตั้งค่า TextAlign ของ TextBox ที่แสดงจำนวนเงินให้ชิดขวา
        txtExpenseAmount.TextAlign = HorizontalAlignment.Right
        txtDetailAmount.TextAlign = HorizontalAlignment.Right
    End Sub

    Private Sub LoadAccounts()
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim query As String = "SELECT acc_id, acc_name FROM Account"
            Dim adapter As New OleDbDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)

            If table.Rows.Count > 0 Then
                cmbAccount.DataSource = table
                cmbAccount.DisplayMember = "acc_name"
                cmbAccount.ValueMember = "acc_id"
                cmbAccount.SelectedIndex = -1 ' ไม่มีการเลือกค่าใด ๆ เริ่มต้น
            Else
                MessageBox.Show("No data available in Account table.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading accounts: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub ConfigureDataGridView()
        ' ใช้ Guna2DataGridView พร้อมตั้งค่าธีม
        dgvExpenses.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Dark

        ' ตั้งค่าฟอนต์และสีของ DataGridView
        dgvExpenses.DefaultCellStyle.Font = New Font("Tahoma", 10)
        dgvExpenses.DefaultCellStyle.BackColor = Color.White
        dgvExpenses.DefaultCellStyle.ForeColor = Color.Black
        dgvExpenses.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray
        dgvExpenses.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 10, FontStyle.Bold)
        dgvExpenses.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy
        dgvExpenses.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvExpenses.EnableHeadersVisualStyles = False

        ' เปิดการใช้งาน ScrollBars
        dgvExpenses.ScrollBars = ScrollBars.Both

        ' ปิดการตั้งค่า AutoSizeColumnMode
        dgvExpenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None

        ' ตั้งชื่อหัวตารางเป็นภาษาไทย
        If dgvExpenses.Columns.Contains("ex_id") Then
            dgvExpenses.Columns("ex_id").HeaderText = "รหัสรายจ่าย"
        End If
        If dgvExpenses.Columns.Contains("ex_name") Then
            dgvExpenses.Columns("ex_name").HeaderText = "ชื่อรายจ่าย"
        End If
        If dgvExpenses.Columns.Contains("ex_date") Then
            dgvExpenses.Columns("ex_date").HeaderText = "วันที่จ่าย"
            dgvExpenses.Columns("ex_date").DefaultCellStyle.Format = "dd/MM/yyyy"
        End If
        If dgvExpenses.Columns.Contains("ex_amount") Then
            dgvExpenses.Columns("ex_amount").HeaderText = "จำนวนเงิน"
            dgvExpenses.Columns("ex_amount").DefaultCellStyle.Format = "N2"
            dgvExpenses.Columns("ex_amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If
        If dgvExpenses.Columns.Contains("acc_id") Then
            dgvExpenses.Columns("acc_id").HeaderText = "บัญชี"
        End If
    End Sub

    Private Sub ConfigureDetailsDataGridView()
        ' ใช้ Guna2DataGridView สำหรับรายละเอียดรายจ่าย
        dgvExpenseDetails.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Dark

        ' ตั้งค่าฟอนต์และสีของ DataGridView สำหรับรายละเอียดรายจ่าย
        dgvExpenseDetails.DefaultCellStyle.Font = New Font("Tahoma", 10)
        dgvExpenseDetails.DefaultCellStyle.BackColor = Color.White
        dgvExpenseDetails.DefaultCellStyle.ForeColor = Color.Black
        dgvExpenseDetails.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray
        dgvExpenseDetails.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 10, FontStyle.Bold)
        dgvExpenseDetails.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy
        dgvExpenseDetails.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvExpenseDetails.EnableHeadersVisualStyles = False

        ' เปิดการใช้งาน ScrollBars
        dgvExpenseDetails.ScrollBars = ScrollBars.Both

        ' อนุญาตให้แก้ไขข้อมูลใน DataGridView
        dgvExpenseDetails.ReadOnly = False

        ' ตั้งชื่อหัวตารางเป็นภาษาไทย
        If dgvExpenseDetails.Columns.Contains("exd_id") Then
            dgvExpenseDetails.Columns("exd_id").HeaderText = "รหัสรายละเอียด"
            dgvExpenseDetails.Columns("exd_id").ReadOnly = True ' ไม่ให้แก้ไขค่า ID
        End If
        If dgvExpenseDetails.Columns.Contains("exd_nameacc") Then
            dgvExpenseDetails.Columns("exd_nameacc").HeaderText = "ชื่อบัญชีรายจ่าย"
            dgvExpenseDetails.Columns("exd_nameacc").ReadOnly = False
        End If
        If dgvExpenseDetails.Columns.Contains("exd_amount") Then
            dgvExpenseDetails.Columns("exd_amount").HeaderText = "จำนวนเงิน"
            dgvExpenseDetails.Columns("exd_amount").DefaultCellStyle.Format = "N2"
            dgvExpenseDetails.Columns("exd_amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvExpenseDetails.Columns("exd_amount").ReadOnly = False
        End If
    End Sub


    Private Sub LoadExpenses()
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim query As String = "SELECT * FROM Expense"
            Dim adapter As New OleDbDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)

            dgvExpenses.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Error loading expenses: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub LoadExpenseDetails()
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            ' ใช้ SQL เพื่อดึงข้อมูลจากตาราง Expense_Details โดยใช้ ex_id ที่เลือก
            Dim query As String = "SELECT * FROM Expense_Details WHERE ex_id = @ex_id"
            Dim cmd As New OleDbCommand(query, conn)
            cmd.Parameters.AddWithValue("@ex_id", expenseID)
            Dim adapter As New OleDbDataAdapter(cmd)
            Dim table As New DataTable()
            adapter.Fill(table)

            ' เชื่อมโยงข้อมูลกับ DataGridView สำหรับรายละเอียด
            dgvExpenseDetails.DataSource = table

            ' ตั้งชื่อหัวตารางเป็นภาษาไทย
            If dgvExpenseDetails.Columns.Contains("exd_id") Then
                dgvExpenseDetails.Columns("exd_id").HeaderText = "รหัสรายละเอียด"
            End If
            If dgvExpenseDetails.Columns.Contains("exd_nameacc") Then
                dgvExpenseDetails.Columns("exd_nameacc").HeaderText = "ชื่อบัญชีรายจ่าย"
            End If
            If dgvExpenseDetails.Columns.Contains("exd_amount") Then
                dgvExpenseDetails.Columns("exd_amount").HeaderText = "จำนวนเงิน"
                dgvExpenseDetails.Columns("exd_amount").DefaultCellStyle.Format = "N2"
                dgvExpenseDetails.Columns("exd_amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading expense details: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub dgvExpenses_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvExpenses.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim selectedExpenseID As String = dgvExpenses.Rows(e.RowIndex).Cells("ex_id").Value.ToString()
            expenseID = selectedExpenseID
            LoadExpenseDetails()
        End If
    End Sub

    Private Sub dgvExpenses_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvExpenses.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvExpenses.Rows(e.RowIndex)
            txtExpenseID.Text = row.Cells("ex_id").Value.ToString()
            txtExpenseName.Text = row.Cells("ex_name").Value.ToString()
            txtExpenseAmount.Text = row.Cells("ex_amount").Value.ToString()
            dtpExpenseDate.Value = Convert.ToDateTime(row.Cells("ex_date").Value)
            cmbAccount.SelectedValue = row.Cells("acc_id").Value.ToString()
            txtExpenseDescription.Text = row.Cells("ex_description").Value.ToString() ' เพิ่มส่วนนี้
        End If
    End Sub


    Private Sub dgvExpenseDetails_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvExpenseDetails.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvExpenseDetails.Rows(e.RowIndex)
            txtDetailID.Text = row.Cells("exd_id").Value.ToString()
            txtDetailName.Text = row.Cells("exd_nameacc").Value.ToString()
            txtDetailAmount.Text = row.Cells("exd_amount").Value.ToString()
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrEmpty(expenseID) Then
            MessageBox.Show("Please select an expense to edit.")
            Return
        End If

        ' ตรวจสอบว่า จำนวนเงินรวมของรายละเอียดค่าใช้จ่ายเท่ากับจำนวนเงินของค่าใช้จ่ายหลักหรือไม่
        Dim totalDetailAmount As Decimal = 0

        ' คำนวณจำนวนเงินรวมจากรายละเอียดค่าใช้จ่าย
        For Each row As DataGridViewRow In dgvExpenseDetails.Rows
            If Not row.IsNewRow Then
                totalDetailAmount += Convert.ToDecimal(row.Cells("exd_amount").Value)
            End If
        Next

        ' จำนวนเงินของค่าใช้จ่ายหลัก
        Dim mainExpenseAmount As Decimal = Convert.ToDecimal(txtExpenseAmount.Text)

        ' ตรวจสอบว่าเงินรวมของรายละเอียดเท่ากับเงินของค่าใช้จ่ายหลักหรือไม่
        If totalDetailAmount <> mainExpenseAmount Then
            MessageBox.Show("The total amount of expense details (" & totalDetailAmount.ToString("N2") & ") does not match the main expense amount (" & mainExpenseAmount.ToString("N2") & "). Please check and correct the amounts before saving.")
            Return
        End If

        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            ' อัปเดตฟิลด์ที่สามารถแก้ไขได้ในตาราง Expense
            Dim updateExpenseQuery As String = "UPDATE Expense SET ex_name = @name, ex_date = @date, ex_amount = @amount, acc_id = @acc_id WHERE ex_id = @ex_id"
            Dim cmd As New OleDbCommand(updateExpenseQuery, conn)
            cmd.Parameters.AddWithValue("@name", txtExpenseName.Text)
            cmd.Parameters.AddWithValue("@date", dtpExpenseDate.Value)
            cmd.Parameters.AddWithValue("@amount", mainExpenseAmount)
            cmd.Parameters.AddWithValue("@acc_id", cmbAccount.SelectedValue.ToString())
            cmd.Parameters.AddWithValue("@ex_id", expenseID)

            cmd.ExecuteNonQuery()

            ' อัปเดตข้อมูลรายละเอียดรายจ่าย
            UpdateExpenseDetails()

            MessageBox.Show("Expense and details updated successfully!")

            ' รีเฟรชข้อมูลใน DataGridView หลังจากบันทึกข้อมูล
            LoadExpenses()
            LoadExpenseDetails() ' เพิ่มการรีเฟรชรายละเอียดรายจ่ายที่นี่

        Catch ex As Exception
            MessageBox.Show("Error saving expense and details: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub



    Private Sub UpdateExpenseDetails()
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            ' ใช้ Transaction เพื่อความปลอดภัย
            Dim transaction As OleDbTransaction = conn.BeginTransaction()

            Try
                ' ใช้ค่าใน TextBox โดยตรงในการอัปเดตข้อมูล
                Dim detailID As String = txtDetailID.Text
                Dim nameacc As String = txtDetailName.Text
                Dim amount As Decimal = Convert.ToDecimal(txtDetailAmount.Text)

                ' ตรวจสอบว่า TextBox ไม่ว่างเปล่า
                If String.IsNullOrEmpty(detailID) OrElse String.IsNullOrEmpty(nameacc) OrElse amount = 0 Then
                    MessageBox.Show("Please fill in all details correctly.")
                    transaction.Rollback()
                    Return
                End If

                Dim updateDetailQuery As String = "UPDATE Expense_Details SET exd_nameacc = @nameacc, exd_amount = @amount WHERE exd_id = @exd_id"
                Dim cmdUpdateDetail As New OleDbCommand(updateDetailQuery, conn, transaction)
                cmdUpdateDetail.Parameters.AddWithValue("@nameacc", nameacc)
                cmdUpdateDetail.Parameters.AddWithValue("@amount", amount)
                cmdUpdateDetail.Parameters.AddWithValue("@exd_id", detailID)

                cmdUpdateDetail.ExecuteNonQuery()

                ' Commit ถ้าไม่มีปัญหา
                transaction.Commit()
                MessageBox.Show("Expense details updated successfully!")
                LoadExpenseDetails() ' รีเฟรช DataGridView ของรายละเอียดรายจ่าย

            Catch ex As Exception
                transaction.Rollback()
                MessageBox.Show("Error updating expense details: " & ex.Message)
            End Try

        Catch ex As Exception
            MessageBox.Show("Error updating expense details: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub





    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If String.IsNullOrEmpty(expenseID) Then
            MessageBox.Show("Please select an expense to delete.")
            Return
        End If

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this expense?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            Try
                If conn.State = ConnectionState.Closed Then conn.Open()

                ' ลบข้อมูลจากตาราง Expense
                Dim deleteExpenseQuery As String = "DELETE FROM Expense WHERE ex_id = @ex_id"
                Dim cmdDeleteExpense As New OleDbCommand(deleteExpenseQuery, conn)
                cmdDeleteExpense.Parameters.AddWithValue("@ex_id", expenseID)
                cmdDeleteExpense.ExecuteNonQuery()

                ' ลบข้อมูลที่เกี่ยวข้องจากตาราง Expense_Details
                Dim deleteExpenseDetailsQuery As String = "DELETE FROM Expense_Details WHERE ex_id = @ex_id"
                Dim cmdDeleteExpenseDetails As New OleDbCommand(deleteExpenseDetailsQuery, conn)
                cmdDeleteExpenseDetails.Parameters.AddWithValue("@ex_id", expenseID)
                cmdDeleteExpenseDetails.ExecuteNonQuery()

                MessageBox.Show("Expense and related details deleted successfully!")

                ' รีเฟรชข้อมูลใน DataGridView หลังจากลบข้อมูล
                LoadExpenses()

            Catch ex As Exception
                MessageBox.Show("Error deleting expense and details: " & ex.Message)
            Finally
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Try
        End If
    End Sub
End Class
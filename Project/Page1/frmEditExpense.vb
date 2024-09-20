Imports System.Data.OleDb
Imports System.Drawing.Printing

Public Class frmEditExpense
    Dim conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
    Private expenseID As String = "" ' เก็บค่า ex_id ของรายจ่ายที่ถูกเลือก
    Private printDocument As New PrintDocument()
    Private printPreviewDialog As New PrintPreviewDialog()

    Private Sub frmEditExpense_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAccounts() ' โหลดข้อมูลบัญชี
        LoadExpenses() ' โหลดรายการรายจ่าย
        ConfigureDataGridView() ' ตั้งค่าการแสดงผลของ DataGridView
        ConfigureDetailsDataGridView() ' ตั้งค่าการแสดงผลของ DataGridView สำหรับรายละเอียดรายจ่าย

        ' ตั้งค่า TextAlign ของ TextBox ที่แสดงจำนวนเงินให้ชิดขวา
        txtExpenseAmount.TextAlign = HorizontalAlignment.Right
        txtDetailAmount.TextAlign = HorizontalAlignment.Right

        ' เพิ่ม event handler สำหรับการพิมพ์
        AddHandler printDocument.PrintPage, AddressOf PrintDocument_PrintPage

        ' ตั้งค่า PrintPreviewDialog
        printPreviewDialog.Document = printDocument
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
            txtExpenseDescription.Text = row.Cells("ex_description").Value.ToString()
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
            LoadExpenseDetails()

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

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If String.IsNullOrEmpty(expenseID) Then
            MessageBox.Show("กรุณาเลือกรายการค่าใช้จ่ายก่อนพิมพ์", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' แสดง PrintPreviewDialog
        printPreviewDialog.ShowDialog()
    End Sub

    Private Sub PrintDocument_PrintPage(sender As Object, e As PrintPageEventArgs)
        Dim font As New Font("Arial", 10)
        Dim boldFont As New Font("Arial", 12, FontStyle.Bold)
        Dim headerFont As New Font("Arial", 14, FontStyle.Bold)
        Dim startX As Integer
        Dim startY As Integer = 10
        Dim offset As Integer = 40
        Dim lineHeight As Integer = 25 ' Standard line height for rows

        ' Get the page width
        Dim pageWidth As Integer = e.PageBounds.Width

        ' ส่วนหัว (Header Section)
        Dim headerText As String = "กองทุนหมู่บ้าน บ้านใหม่หลังมอ"
        startX = (pageWidth - e.Graphics.MeasureString(headerText, headerFont).Width) / 2 ' Center the header text
        e.Graphics.DrawString(headerText, headerFont, Brushes.Black, startX, startY)
        offset += 30

        Dim addressLine1 As String = "หมู่ที่ 14 ตำบลสุเทพ อำเภอเมืองเชียงใหม่ จังหวัดเชียงใหม่"
        startX = (pageWidth - e.Graphics.MeasureString(addressLine1, font).Width) / 2 ' Center the address line
        e.Graphics.DrawString(addressLine1, font, Brushes.Black, startX, startY + offset)
        offset += 20

        Dim phoneText As String = "โทรศัพท์: 053-219535"
        startX = (pageWidth - e.Graphics.MeasureString(phoneText, font).Width) / 2 ' Center the phone number
        e.Graphics.DrawString(phoneText, font, Brushes.Black, startX, startY + offset)
        offset += 20

        Dim addressLine2 As String = "66/2 หมู่ 14 ต.สุเทพ อ.เมืองเชียงใหม่ จ.เชียงใหม่ 50200"
        startX = (pageWidth - e.Graphics.MeasureString(addressLine2, font).Width) / 2 ' Center the second address line
        e.Graphics.DrawString(addressLine2, font, Brushes.Black, startX, startY + offset)

        ' เว้นระยะระหว่างส่วนหัวและเนื้อหา
        offset += 40

        ' รายละเอียดการจ่าย (Details Section)
        Dim detailsTitle As String = "รายละเอียด:"
        startX = (pageWidth - e.Graphics.MeasureString(detailsTitle, boldFont).Width) / 2 ' Center the details title
        e.Graphics.DrawString(detailsTitle, boldFont, Brushes.Black, startX, startY + offset)
        offset += 20

        Dim expenseIdText As String = "รหัสรายจ่าย: " & txtExpenseID.Text
        startX = (pageWidth - e.Graphics.MeasureString(expenseIdText, font).Width) / 2 ' Center the expense ID
        e.Graphics.DrawString(expenseIdText, font, Brushes.Black, startX, startY + offset)
        offset += 20

        ' รายการในตาราง (Table Header)
        Dim noText As String = "No."
        Dim itemText As String = "รายการจ่าย"
        Dim amountText As String = "จำนวนเงิน"

        startX = (pageWidth - 500) / 2 ' Start at the middle of the page minus half the table width (assuming table is 500 units wide)
        e.Graphics.DrawString(noText, boldFont, Brushes.Black, startX, startY + offset)
        e.Graphics.DrawString(itemText, boldFont, Brushes.Black, startX + 100, startY + offset)
        e.Graphics.DrawString(amountText, boldFont, Brushes.Black, startX + 400, startY + offset)

        ' เส้นใต้หัวข้อ (Underline Table Header)
        offset += lineHeight
        e.Graphics.DrawLine(Pens.Black, startX, startY + offset, startX + 500, startY + offset)

        ' Loop through DataGridView rows and print them
        Dim rowIndex As Integer = 1
        For Each row As DataGridViewRow In dgvExpenseDetails.Rows
            If Not row.IsNewRow Then
                offset += 5
                e.Graphics.DrawString(rowIndex.ToString(), font, Brushes.Black, startX, startY + offset)
                e.Graphics.DrawString(row.Cells("exd_nameacc").Value.ToString(), font, Brushes.Black, startX + 100, startY + offset)

                ' Format the amount with thousand separators
                Dim amount As Decimal
                If Decimal.TryParse(row.Cells("exd_amount").Value.ToString(), amount) Then
                    Dim formattedAmount As String = String.Format("{0:N2}", amount)
                    e.Graphics.DrawString(formattedAmount & " บาท", font, Brushes.Black, startX + 400, startY + offset)
                Else
                    e.Graphics.DrawString(row.Cells("exd_amount").Value.ToString() & " บาท", font, Brushes.Black, startX + 400, startY + offset)
                End If

                ' Move to next row
                rowIndex += 1
                offset += lineHeight
                e.Graphics.DrawLine(Pens.Black, startX, startY + offset, startX + 500, startY + offset) ' Line under the row
            End If
        Next

        ' รวมยอดเงิน (Total Amount Section)
        offset += 40
        Dim totalAmount As Decimal
        If Decimal.TryParse(txtExpenseAmount.Text, totalAmount) Then
            Dim formattedTotal As String = String.Format("{0:N2}", totalAmount) ' This will format the number with thousand separators and 2 decimal places
            Dim totalText As String = "รวมเป็นเงิน: " & formattedTotal & " บาท"
            startX = (pageWidth - e.Graphics.MeasureString(totalText, boldFont).Width) / 2 ' Center the total amount text
            e.Graphics.DrawString(totalText, boldFont, Brushes.Black, startX, startY + offset)
        Else
            ' Handle the case where parsing fails (e.g., invalid input)
            Dim totalText As String = "รวมเป็นเงิน: " & txtExpenseAmount.Text & " บาท"
            startX = (pageWidth - e.Graphics.MeasureString(totalText, boldFont).Width) / 2 ' Center the total amount text
            e.Graphics.DrawString(totalText, boldFont, Brushes.Black, startX, startY + offset)
        End If

        ' เส้นแบ่งลายเซ็น (Line for signature section)
        offset += 60
        Dim signatureText As String = "ผู้รับเงิน"
        startX = (pageWidth - e.Graphics.MeasureString(signatureText, font).Width) / 2 ' Center the signature line
        e.Graphics.DrawString(signatureText, font, Brushes.Black, startX, startY + offset)
        e.Graphics.DrawString("..........................................", font, Brushes.Black, startX + 100, startY + offset)
    End Sub

End Class
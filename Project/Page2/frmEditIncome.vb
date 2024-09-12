Imports System.Data.OleDb
Imports Guna.UI2.WinForms

Public Class frmEditIncome
    Dim conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
    Private incomeID As String = "" ' เก็บค่า inc_id ของรายรับที่ถูกเลือก

    Private Sub frmEditIncome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAccounts() ' โหลดข้อมูลบัญชี
        LoadIncome() ' โหลดรายการรายรับ
        ConfigureDataGridView() ' ตั้งค่าการแสดงผลของ DataGridView
        ConfigureDetailsDataGridView() ' ตั้งค่าการแสดงผลของ DataGridView สำหรับรายละเอียดรายรับ
    End Sub

    ' โหลดบัญชีลงใน ComboBox
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
                MessageBox.Show("ไม่พบข้อมูลบัญชีในตาราง Account")
            End If
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการโหลดบัญชี: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' ตั้งค่าการแสดงผล DataGridView สำหรับรายรับ
    Private Sub ConfigureDataGridView()
        dgvIncome.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Dark
        dgvIncome.DefaultCellStyle.Font = New Font("Tahoma", 10)
        dgvIncome.DefaultCellStyle.BackColor = Color.White
        dgvIncome.DefaultCellStyle.ForeColor = Color.Black
        dgvIncome.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray
        dgvIncome.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 10, FontStyle.Bold)
        dgvIncome.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy
        dgvIncome.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvIncome.EnableHeadersVisualStyles = False
    End Sub

    ' ตั้งค่าการแสดงผล DataGridView สำหรับรายละเอียดรายรับ
    Private Sub ConfigureDetailsDataGridView()
        dgvIncomeDetails.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Dark
        dgvIncomeDetails.DefaultCellStyle.Font = New Font("Tahoma", 10)
        dgvIncomeDetails.DefaultCellStyle.BackColor = Color.White
        dgvIncomeDetails.DefaultCellStyle.ForeColor = Color.Black
        dgvIncomeDetails.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray
        dgvIncomeDetails.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 10, FontStyle.Bold)
        dgvIncomeDetails.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy
        dgvIncomeDetails.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvIncomeDetails.EnableHeadersVisualStyles = False
    End Sub

    ' โหลดข้อมูลรายรับลงใน DataGridView
    Private Sub LoadIncome()
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim query As String = "SELECT * FROM Income"
            Dim adapter As New OleDbDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)

            dgvIncome.DataSource = table
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการโหลดข้อมูลรายรับ: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' โหลดข้อมูลรายละเอียดรายรับลงใน DataGridView
    Private Sub LoadIncomeDetails()
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim query As String = "SELECT * FROM Income_Details WHERE inc_id = @inc_id"
            Dim cmd As New OleDbCommand(query, conn)
            cmd.Parameters.AddWithValue("@inc_id", Convert.ToInt32(incomeID))
            Dim adapter As New OleDbDataAdapter(cmd)
            Dim table As New DataTable()
            adapter.Fill(table)

            dgvIncomeDetails.DataSource = table
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการโหลดรายละเอียดรายรับ: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' เมื่อคลิกเลือกข้อมูลใน DataGridView รายรับ
    Private Sub dgvIncome_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvIncome.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvIncome.Rows(e.RowIndex)
            txtIncomeID.Text = row.Cells("inc_id").Value.ToString()
            txtIncomeName.Text = row.Cells("inc_name").Value.ToString()
            txtIncomeAmount.Text = row.Cells("inc_amount").Value.ToString()
            dtpIncomeDate.Value = Convert.ToDateTime(row.Cells("inc_date").Value)
            cmbAccount.SelectedValue = Convert.ToInt32(row.Cells("acc_id").Value.ToString())

            ' กำหนดค่า incomeID
            incomeID = row.Cells("inc_id").Value.ToString()
            LoadIncomeDetails() ' โหลดรายละเอียดรายรับตาม inc_id ที่ถูกเลือก
        End If
    End Sub

    ' เมื่อคลิกเลือกข้อมูลใน DataGridView รายละเอียดรายรับ
    Private Sub dgvIncomeDetails_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvIncomeDetails.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvIncomeDetails.Rows(e.RowIndex)
            txtDetailID.Text = row.Cells("ind_id").Value.ToString()
            txtDetailName.Text = row.Cells("ind_accname").Value.ToString()
            txtDetailAmount.Text = row.Cells("ind_amount").Value.ToString()
        End If
    End Sub

    ' ฟังก์ชันบันทึกข้อมูลรายรับและรายละเอียดรายรับ
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            ' บันทึกการแก้ไขข้อมูลรายรับ
            Dim query As String = "UPDATE Income SET inc_name = @name, inc_date = @date, inc_amount = @amount, acc_id = @acc_id WHERE inc_id = @inc_id"
            Dim cmd As New OleDbCommand(query, conn)
            cmd.Parameters.AddWithValue("@name", txtIncomeName.Text)
            cmd.Parameters.AddWithValue("@date", dtpIncomeDate.Value)
            cmd.Parameters.AddWithValue("@amount", Convert.ToDouble(txtIncomeAmount.Text))
            cmd.Parameters.AddWithValue("@acc_id", Convert.ToInt32(cmbAccount.SelectedValue))
            cmd.Parameters.AddWithValue("@inc_id", Convert.ToInt32(txtIncomeID.Text))
            cmd.ExecuteNonQuery()

            ' บันทึกการแก้ไขข้อมูลรายละเอียดรายรับ
            UpdateIncomeDetails()

            MessageBox.Show("แก้ไขข้อมูลสำเร็จ")
            LoadIncome()
            LoadIncomeDetails()

        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการบันทึกข้อมูล: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' ฟังก์ชันบันทึกการแก้ไขรายละเอียดรายรับ
    Private Sub UpdateIncomeDetails()
        Try
            For Each row As DataGridViewRow In dgvIncomeDetails.Rows
                If Not row.IsNewRow Then
                    Dim query As String = "UPDATE Income_Details SET ind_accname = @accname, ind_amount = @amount WHERE ind_id = @ind_id"
                    Dim cmd As New OleDbCommand(query, conn)
                    cmd.Parameters.AddWithValue("@accname", row.Cells("ind_accname").Value)
                    cmd.Parameters.AddWithValue("@amount", Convert.ToDouble(row.Cells("ind_amount").Value))
                    cmd.Parameters.AddWithValue("@ind_id", Convert.ToInt32(row.Cells("ind_id").Value))
                    cmd.ExecuteNonQuery()
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการอัปเดตรายละเอียดรายรับ: " & ex.Message)
        End Try
    End Sub
End Class

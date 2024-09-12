Imports Guna.UI2.WinForms
Imports System.Data.OleDb

Public Class frmManageUser
    ' Database connection string
    Dim Conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
    Dim cmd As OleDbCommand
    Dim da As OleDbDataAdapter
    Dim dt As DataTable
    Dim SQL As String

    ' Form load event to initialize any necessary data
    Private Sub frmManage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUserTypes()
        LoadUsers()
        CustomizeDataGridView() ' เรียกฟังก์ชันปรับแต่ง DataGridView
    End Sub

    ' Method to load user types into the Guna2ComboBox
    Private Sub LoadUserTypes()
        cmbUsertype.Items.Add("Admin")
        cmbUsertype.Items.Add("User")
        cmbUsertype.SelectedIndex = 0 ' Default selection
    End Sub

    Private Sub CustomizeDataGridView()
        ' ตั้งค่าฟอนต์สำหรับ Guna2DataGridView
        gunaDataGridView1.DefaultCellStyle.Font = New Font("FC Minimal", 12, FontStyle.Regular)
        gunaDataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("FC Minimal", 14, FontStyle.Bold)

        ' ตั้งค่าขนาดและสไตล์ของ DataGridView อื่น ๆ
        With gunaDataGridView1
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(223, 240, 255)
            .DefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.ForeColor = Color.Black
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(63, 81, 181)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .EnableHeadersVisualStyles = False
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            .GridColor = Color.FromArgb(214, 234, 247)
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(63, 81, 181)
            .DefaultCellStyle.SelectionForeColor = Color.White
            .RowTemplate.Height = 40
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End With
    End Sub

    ' Method to load users into the Guna2DataGridView
    Private Sub LoadUsers()
        Try
            Using Conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
                Conn.Open()
                SQL = "SELECT * FROM Users"
                da = New OleDbDataAdapter(SQL, Conn)
                dt = New DataTable()
                da.Fill(dt)

                ' ตั้งค่าชื่อหัวคอลัมน์เป็นภาษาไทย
                gunaDataGridView1.DataSource = dt
                gunaDataGridView1.Columns(0).HeaderText = "รหัสผู้ใช้"
                gunaDataGridView1.Columns(1).HeaderText = "ชื่อผู้ใช้"
                gunaDataGridView1.Columns(2).HeaderText = "รหัสผ่าน"
                gunaDataGridView1.Columns(3).HeaderText = "ประเภทผู้ใช้"
                gunaDataGridView1.Columns(4).HeaderText = "ชื่อ"
                gunaDataGridView1.Columns(5).HeaderText = "นามสกุล"
                gunaDataGridView1.Columns(6).HeaderText = "เบอร์โทรศัพท์"
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub gunaDataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles gunaDataGridView1.CellClick
        ' ตรวจสอบว่ามีการเลือกแถวหรือไม่
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = gunaDataGridView1.Rows(e.RowIndex)

            ' โหลดข้อมูลจาก DataGridView ลงในฟิลด์ต่าง ๆ
            txtUsername.Text = row.Cells("user_name").Value.ToString()
            txtPassword.Text = row.Cells("user_pass").Value.ToString()
            cmbUsertype.SelectedItem = row.Cells("user_type").Value.ToString()
            txtFname.Text = row.Cells("user_fname").Value.ToString()
            txtTel.Text = row.Cells("user_tel").Value.ToString()

            ' เปิดการใช้งานปุ่มแก้ไข และปิดปุ่มบันทึก
            btnSave.Enabled = False   ' ปิดปุ่มบันทึกเพื่อไม่ให้บันทึกข้อมูลใหม่
            btnEdit.Enabled = True    ' เปิดการใช้งานปุ่มแก้ไข
        End If
    End Sub


    ' Button click event for saving user data (Guna2Button)
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' ตรวจสอบว่าทุกฟิลด์ได้รับการกรอกข้อมูลครบถ้วน
        If String.IsNullOrEmpty(txtUsername.Text) Or String.IsNullOrEmpty(txtPassword.Text) Or String.IsNullOrEmpty(txtFname.Text) Or String.IsNullOrEmpty(txtTel.Text) Then
            MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' บันทึกข้อมูลใหม่
        Try
            Using Conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
                Conn.Open()

                ' ตรวจสอบว่าชื่อผู้ใช้งานซ้ำหรือไม่
                SQL = "SELECT COUNT(*) FROM Users WHERE user_name = @Username"
                cmd = New OleDbCommand(SQL, Conn)
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text)
                Dim userCount As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                If userCount > 0 Then
                    MessageBox.Show("Username already exists. Please choose a different username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                ' เพิ่มผู้ใช้ใหม่
                SQL = "INSERT INTO Users (user_name, user_pass, user_type, user_fname, user_tel) VALUES (@Username, @Password, @UserType, @FullName, @PhoneNumber)"
                cmd = New OleDbCommand(SQL, Conn)
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text)
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text)
                cmd.Parameters.AddWithValue("@UserType", cmbUsertype.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@FullName", txtFname.Text)
                cmd.Parameters.AddWithValue("@PhoneNumber", txtTel.Text)
                cmd.ExecuteNonQuery()

                MessageBox.Show("User added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' ล้างข้อมูลในฟิลด์
                ClearFields()

                ' โหลดข้อมูลผู้ใช้ใหม่
                LoadUsers()
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        ' ตรวจสอบว่าทุกฟิลด์ได้รับการกรอกข้อมูลครบถ้วน
        If txtUsername.Text = "" Or txtPassword.Text = "" Or txtFname.Text = "" Or txtTel.Text = "" Then
            MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            ' อัปเดตข้อมูลผู้ใช้ในฐานข้อมูล
            Using Conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
                Conn.Open()

                ' SQL สำหรับอัปเดตข้อมูล
                SQL = "UPDATE Users SET user_pass = @Password, user_type = @UserType, user_fname = @FullName, user_tel = @PhoneNumber WHERE user_name = @Username"
                cmd = New OleDbCommand(SQL, Conn)
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text)
                cmd.Parameters.AddWithValue("@UserType", cmbUsertype.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@FullName", txtFname.Text)
                cmd.Parameters.AddWithValue("@PhoneNumber", txtTel.Text)
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text)
                cmd.ExecuteNonQuery()

                MessageBox.Show("User information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' โหลดข้อมูลผู้ใช้ใหม่
                LoadUsers()

                ' ล้างข้อมูลในฟิลด์
                ClearFields()

                ' กลับไปเปิดการใช้งานปุ่มบันทึก
                btnSave.Enabled = True
                btnEdit.Enabled = False ' ปิดการใช้งานปุ่มแก้ไข
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Button click event for deleting user data (Guna2Button)
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' ตรวจสอบว่ามีการเลือกแถวหรือไม่
        If gunaDataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a user to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim username As String = gunaDataGridView1.SelectedRows(0).Cells("user_name").Value.ToString()
        DeleteUser(username)

        ' โหลดข้อมูลผู้ใช้ใหม่
        LoadUsers()
    End Sub

    ' Method to delete user data
    Private Sub DeleteUser(username As String)
        Try
            Using Conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
                Conn.Open()
                SQL = "DELETE FROM Users WHERE user_name = @Username"
                cmd = New OleDbCommand(SQL, Conn)
                cmd.Parameters.AddWithValue("@Username", username)
                cmd.ExecuteNonQuery()
                MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Button click event for canceling (Guna2Button)
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ' ล้างข้อมูลในฟิลด์ทั้งหมด
        ClearFields()

        ' กำหนดปุ่มบันทึกให้พร้อมใช้งานสำหรับการเพิ่มข้อมูลใหม่
        btnSave.Enabled = True  ' เปิดใช้งานปุ่มบันทึกสำหรับเพิ่มข้อมูลใหม่
        btnEdit.Enabled = False ' ปิดการใช้งานปุ่มแก้ไขข้อมูล
    End Sub

    Private Sub ClearFields()
        txtUsername.Clear()
        txtPassword.Clear()
        txtFname.Clear()
        txtTel.Clear()
        cmbUsertype.SelectedIndex = 0 ' Reset to default selection
    End Sub

End Class
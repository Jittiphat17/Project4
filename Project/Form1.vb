Imports System.Data.OleDb

Public Class Form1
    ' การเชื่อมต่อฐานข้อมูล Access
    Dim Conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
    Dim cmd As OleDbCommand
    Dim da As OleDbDataAdapter
    Dim dt As DataTable
    Dim SQL As String

    ' ฟังก์ชัน Load เมื่อฟอร์มถูกเปิด
    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' ทำให้ MaterialTextBox ที่ใช้สำหรับรหัสผ่านแสดงเป็น dot (●)
        txtPass.UseSystemPasswordChar = True

        ' Focus ที่ txtUser เมื่อเปิดฟอร์ม
        txtUser.Focus()
    End Sub

    ' จำกัดการใส่ข้อมูลใน TextBox ให้เฉพาะตัวอักษรภาษาอังกฤษและตัวเลข
    Private Sub txtUser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUser.KeyPress
        If Not Char.IsLetterOrDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ' ฟังก์ชันที่ทำงานเมื่อกดปุ่ม "เข้าสู่ระบบ"
    Private Sub btn_login_Click(sender As Object, e As EventArgs) Handles btn_login.Click
        ' ปิดการใช้งานปุ่ม Login ชั่วคราวเพื่อป้องกันการคลิกซ้ำ
        btn_login.Enabled = False

        SQL = "SELECT * FROM Users WHERE user_name= @userName AND user_pass= @userPass"

        Try
            ' ตรวจสอบและเปิดการเชื่อมต่อฐานข้อมูล
            If Conn.State = ConnectionState.Open Then Conn.Close()
            Conn.Open()

            ' การตรวจสอบชื่อผู้ใช้และรหัสผ่าน
            Using cmd As New OleDbCommand(SQL, Conn)
                cmd.Parameters.AddWithValue("@userName", txtUser.Text.Trim())
                cmd.Parameters.AddWithValue("@userPass", txtPass.Text.Trim())

                da = New OleDbDataAdapter(cmd)
                dt = New DataTable
                da.Fill(dt)

                If dt.Rows.Count > 0 Then
                    ' ดึงข้อมูลชื่อผู้ใช้และประเภทผู้ใช้จากฐานข้อมูล
                    User_name = dt.Rows(0)("user_name").ToString()
                    User_type = dt.Rows(0)("user_type").ToString()

                    ' เปิดฟอร์มหลักและซ่อนฟอร์ม Login
                    Dim frm As New frmMain
                    frm.Show()
                    Me.Hide()
                Else
                    ' แสดงข้อความเตือนหากชื่อผู้ใช้หรือรหัสผ่านผิด
                    MessageBox.Show("ชื่อผู้ใช้งาน หรือ รหัสผ่าน ผิด", "ข้อความจากระบบ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtUser.Focus()
                End If
            End Using

        Catch ex As Exception
            ' แสดงข้อความหากเกิดข้อผิดพลาด
            MessageBox.Show(ex.Message, "ข้อความจากระบบ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            ' ปิดการเชื่อมต่อฐานข้อมูลและเปิดการใช้งานปุ่มอีกครั้ง
            If Conn.State = ConnectionState.Open Then Conn.Close()
            btn_login.Enabled = True
        End Try
    End Sub
End Class

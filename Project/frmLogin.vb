Imports System.Data.OleDb

Public Class Form1
    Dim Conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
    Dim cmd As OleDbCommand
    Dim da As OleDbDataAdapter
    Dim dt As DataTable
    Dim SQL As String

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtPass.UseSystemPasswordChar = True
    End Sub

    Private Sub txtUser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) 
        ' อนุญาตเฉพาะตัวอักษรภาษาอังกฤษและตัวเลขเท่านั้น
        If Not Char.IsLetterOrDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btn_login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_login.Click
        SQL = "SELECT * FROM Users WHERE user_name= @userName AND user_pass= @userPass"

        Try
            If Conn.State = ConnectionState.Open Then Conn.Close()
            Conn.Open()

            Using cmd As New OleDbCommand(SQL, Conn)
                cmd.Parameters.AddWithValue("@userName", txtUser.Text.Trim())
                cmd.Parameters.AddWithValue("@userPass", txtPass.Text.Trim())

                da = New OleDbDataAdapter(cmd)
                dt = New DataTable
                da.Fill(dt)

                If dt.Rows.Count > 0 Then
                    User_name = dt.Rows(0)("user_name")
                    User_type = dt.Rows(0)("user_type")
                    Dim frm As New frmMain
                    frm.Show()
                    Me.Hide()
                Else
                    MessageBox.Show("ชื่อผู้ใช้งาน หรือ รหัสผ่าน ผิด", "ข้อความจากระบบ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtUser.Focus()
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ข้อความจากระบบ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Private Sub btn_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exit.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        ' Check if the user clicked Yes
        If result = DialogResult.Yes Then
            ' Exit the application
            Application.Exit()
        End If
    End Sub
End Class

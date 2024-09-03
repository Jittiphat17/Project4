Imports System.Data.OleDb

Public Class frmEditUser
    Dim Conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
    Dim cmd As OleDbCommand
    Dim SQL As String
    Public Username As String

    Private Sub frmEditUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUserTypes()
        LoadUserData()
    End Sub

    ' Load user types into the combo box
    Private Sub LoadUserTypes()
        cmbUsertype.Items.Add("Admin")
        cmbUsertype.Items.Add("User")
    End Sub

    ' Load user data to be edited
    Private Sub LoadUserData()
        Try
            Using Conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
                Conn.Open()
                SQL = "SELECT * FROM Users WHERE user_name = @Username"
                cmd = New OleDbCommand(SQL, Conn)
                cmd.Parameters.AddWithValue("@Username", Username)
                Dim reader As OleDbDataReader = cmd.ExecuteReader()

                If reader.Read() Then
                    txtUsername.Text = reader("user_name").ToString()
                    txtPassword.Text = reader("user_pass").ToString()
                    txtFname.Text = reader("user_fname").ToString()
                    txtTel.Text = reader("user_tel").ToString()
                    cmbUsertype.SelectedItem = reader("user_type").ToString()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Button click event for saving changes
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateFields() Then
            MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            Using Conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
                Conn.Open()
                SQL = "UPDATE Users SET user_pass = @Password, user_type = @UserType, user_fname = @FullName, user_tel = @PhoneNumber WHERE user_name = @Username"
                cmd = New OleDbCommand(SQL, Conn)
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text)
                cmd.Parameters.AddWithValue("@UserType", cmbUsertype.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@FullName", txtFname.Text)
                cmd.Parameters.AddWithValue("@PhoneNumber", txtTel.Text)
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text)
                cmd.ExecuteNonQuery()

                MessageBox.Show("User updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close() ' Close the form after saving changes
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Button click event for canceling
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    ' Method to validate input fields
    Private Function ValidateFields() As Boolean
        Return Not String.IsNullOrWhiteSpace(txtUsername.Text) AndAlso
               Not String.IsNullOrWhiteSpace(txtPassword.Text) AndAlso
               Not String.IsNullOrWhiteSpace(txtFname.Text) AndAlso
               Not String.IsNullOrWhiteSpace(txtTel.Text) AndAlso
               cmbUsertype.SelectedItem IsNot Nothing
    End Function
End Class

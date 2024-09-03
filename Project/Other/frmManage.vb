Imports System.Data.OleDb

Public Class frmManage
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
    End Sub

    ' Method to load user types into the combo box
    Private Sub LoadUserTypes()
        cmbUsertype.Items.Add("Admin")
        cmbUsertype.Items.Add("User")
        cmbUsertype.SelectedIndex = 0 ' Default selection
    End Sub

    ' Method to load users into the DataGridView
    Private Sub LoadUsers()
        Try
            Using Conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
                Conn.Open()
                SQL = "SELECT * FROM Users"
                da = New OleDbDataAdapter(SQL, Conn)
                dt = New DataTable()
                da.Fill(dt)
                DataGridView1.DataSource = dt
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Button click event for saving user data
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtUsername.Text = "" Or txtPassword.Text = "" Then
            MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            Using Conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\db_test.mdb")
                Conn.Open()

                ' Check if the username already exists
                SQL = "SELECT COUNT(*) FROM Users WHERE user_name = @Username"
                cmd = New OleDbCommand(SQL, Conn)
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text)
                Dim userCount As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                If userCount > 0 Then
                    MessageBox.Show("Username already exists. Please choose a different username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                ' Insert new user
                SQL = "INSERT INTO Users (user_name, user_pass, user_type, user_fname, user_tel) VALUES (@Username, @Password, @UserType, @FullName, @PhoneNumber)"
                cmd = New OleDbCommand(SQL, Conn)
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text)
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text)
                cmd.Parameters.AddWithValue("@UserType", cmbUsertype.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@FullName", txtFname.Text)
                cmd.Parameters.AddWithValue("@PhoneNumber", txtTel.Text)
                cmd.ExecuteNonQuery()

                MessageBox.Show("User added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Clear input fields
                ClearFields()

                ' Reload users in DataGridView
                LoadUsers()
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Button click event for canceling
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    ' Button click event for editing user data
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a user to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim frmEdit As New frmEditUser()
        frmEdit.Username = DataGridView1.SelectedRows(0).Cells("user_name").Value.ToString()
        frmEdit.ShowDialog()

        ' Reload users in DataGridView
        LoadUsers()
    End Sub

    ' Button click event for deleting user data
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a user to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim username As String = DataGridView1.SelectedRows(0).Cells("user_name").Value.ToString()
        DeleteUser(username)

        ' Reload users in DataGridView
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

    ' Method to clear input fields
    Private Sub ClearFields()
        txtUsername.Clear()
        txtPassword.Clear()
        txtFname.Clear()
        txtTel.Clear()
        cmbUsertype.SelectedIndex = 0 ' Reset to default selection
    End Sub
End Class

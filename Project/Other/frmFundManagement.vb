Imports System.Data.OleDb
Imports Guna.UI2.WinForms

Public Class frmFundManagement
    ' เชื่อมต่อกับฐานข้อมูล Access
    Private Conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")

    Private Sub frmFundManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeDataGridView()
        SetupDataGridView()
        LoadFundData()
        LoadMembersToCheckedListBox() ' โหลดสมาชิกเข้า CheckedListBox
    End Sub
    Public Class MemberItem
        Public Property m_id As Integer
        Public Property m_name As String

        ' Override the ToString method to format the display text
        Public Overrides Function ToString() As String
            Return $"รหัสสมาชิก: {m_id}, ชื่อ-นามสกุลสมาชิก: {m_name}"
        End Function
    End Class

    Private Sub InitializeDataGridView()
        ' Clear existing columns (optional)
        dgvFunds.Columns.Clear()

        ' Add columns to DataGridView
        dgvFunds.Columns.Add("fu_id", "รหัส")
        dgvFunds.Columns.Add("fu_name", "ชื่อกองทุน")
        dgvFunds.Columns.Add("fu_address", "ที่อยู่กองทุน")
        dgvFunds.Columns.Add("fu_office", "ที่ทำการกองทุน")
        dgvFunds.Columns.Add("fu_pass", "รหัสกองทุน")
        dgvFunds.Columns.Add("fu_tel", "เบอร์โทรศัพท์")
        dgvFunds.Columns.Add("director_name", "กรรมการ") ' Add director column
    End Sub

    Private Sub SetupDataGridView()
        ' Set DataGridView properties
        dgvFunds.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvFunds.MultiSelect = False
        dgvFunds.ReadOnly = True ' This will disable editing, but allow selection

        ' Set Font to FC Minimal Bold
        dgvFunds.DefaultCellStyle.Font = New Font("FC Minimal Bold", 10)
        dgvFunds.ColumnHeadersDefaultCellStyle.Font = New Font("FC Minimal Bold", 12, FontStyle.Bold)

        ' Set colors to match your style
        dgvFunds.DefaultCellStyle.BackColor = Color.LightBlue
        dgvFunds.DefaultCellStyle.ForeColor = Color.Black
        dgvFunds.AlternatingRowsDefaultCellStyle.BackColor = Color.White
        dgvFunds.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue
        dgvFunds.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

        ' Set Gridline and border styles
        dgvFunds.GridColor = Color.Black
        dgvFunds.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvFunds.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single

        ' Auto resize columns to fit the content
        dgvFunds.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        ' Center align the header text
        dgvFunds.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    ' ฟังก์ชันสำหรับโหลดข้อมูลสมาชิกใน CheckedListBox
    Private Sub LoadMembersToCheckedListBox()
        Try
            Conn.Open()
            Dim query As String = "SELECT m_id, m_name FROM Member"
            Dim cmd As New OleDbCommand(query, Conn)
            Dim reader As OleDbDataReader = cmd.ExecuteReader()

            ' ล้างรายการใน CheckedListBox ก่อน
            chkListDirectors.Items.Clear()

            ' เพิ่มรายการจากตาราง Member ลงใน CheckedListBox
            While reader.Read()
                Dim memberItem As New MemberItem With {
                .m_id = reader("m_id"),
                .m_name = reader("m_name").ToString()
            }
                chkListDirectors.Items.Add(memberItem, False)
            End While

            Conn.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading members: " & ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then
                Conn.Close()
            End If
        End Try
    End Sub


    Private Sub LoadFundData()
        Try
            Conn.Open()

            Dim query As String = "SELECT f.fu_id, f.fu_name, f.fu_address, f.fu_office, f.fu_pass, f.fu_tel " &
                              "FROM Fund f"

            Dim cmd As New OleDbCommand(query, Conn)
            Dim reader As OleDbDataReader = cmd.ExecuteReader()

            dgvFunds.Rows.Clear()

            While reader.Read()
                Dim fundID As Integer = reader("fu_id")
                Dim directorNames As String = GetDirectorNames(fundID)

                dgvFunds.Rows.Add(reader("fu_id"), reader("fu_name"), reader("fu_address"), reader("fu_office"),
                              reader("fu_pass"), reader("fu_tel"), directorNames)
            End While

            Conn.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading fund data: " & ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then
                Conn.Close()
            End If
        End Try
    End Sub

    Private Function GetDirectorNames(fundID As Integer) As String
        Try
            Dim names As New List(Of String)
            Dim query As String = "SELECT m.m_name FROM Director d " &
                              "LEFT JOIN Member m ON d.m_id = m.m_id " &
                              "WHERE d.fu_id = @fu_id"

            Dim cmd As New OleDbCommand(query, Conn)
            cmd.Parameters.AddWithValue("@fu_id", fundID)

            Dim reader As OleDbDataReader = cmd.ExecuteReader()

            While reader.Read()
                names.Add(reader("m_name").ToString())
            End While

            reader.Close()

            Return String.Join(", ", names)
        Catch ex As Exception
            MessageBox.Show("Error loading director names: " & ex.Message)
            Return ""
        End Try
    End Function

    Private Function ValidateInputs() As Boolean
        ' ตรวจสอบว่าฟิลด์ทั้งหมดถูกกรอกหรือไม่
        If String.IsNullOrWhiteSpace(txtFundName.Text) OrElse
           String.IsNullOrWhiteSpace(txtAddress.Text) OrElse
           String.IsNullOrWhiteSpace(txtOffice.Text) OrElse
           String.IsNullOrWhiteSpace(txtPass.Text) OrElse
           String.IsNullOrWhiteSpace(txtTel.Text) Then

            MessageBox.Show("กรุณากรอกข้อมูลให้ครบทุกฟิลด์", "ข้อมูลไม่ครบ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    Private Sub btnAddFund_Click(sender As Object, e As EventArgs) Handles btnAddFund.Click
        If Not ValidateInputs() Then
            Exit Sub
        End If

        If chkListDirectors.CheckedItems.Count > 10 Then
            MessageBox.Show("คุณสามารถเลือกกรรมการได้สูงสุด 10 คน", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            Conn.Open()
            Dim query As String = "INSERT INTO Fund (fu_name, fu_address, fu_office, fu_pass, fu_tel) VALUES (@fu_name, @fu_address, @fu_office, @fu_pass, @fu_tel)"
            Dim cmd As New OleDbCommand(query, Conn)

            cmd.Parameters.AddWithValue("@fu_name", txtFundName.Text)
            cmd.Parameters.AddWithValue("@fu_address", txtAddress.Text)
            cmd.Parameters.AddWithValue("@fu_office", txtOffice.Text)
            cmd.Parameters.AddWithValue("@fu_pass", txtPass.Text)
            cmd.Parameters.AddWithValue("@fu_tel", txtTel.Text)

            cmd.ExecuteNonQuery()

            ' ดึงค่า fu_id ที่เพิ่งถูกสร้าง
            cmd.CommandText = "SELECT @@IDENTITY"
            Dim newFundID As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            ' เพิ่มกรรมการที่ถูกเลือกใน CheckedListBox
            For Each selectedItem In chkListDirectors.CheckedItems
                Dim memberId As Integer = CType(selectedItem, Object).m_id
                AddDirector(newFundID, memberId)
            Next

            Conn.Close()

            MessageBox.Show("เพิ่มข้อมูลกองทุนเรียบร้อยแล้ว")
            LoadFundData()
            ClearInputs()
        Catch ex As Exception
            MessageBox.Show("Error adding fund: " & ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then
                Conn.Close()
            End If
        End Try
    End Sub

    ' ฟังก์ชันสำหรับเพิ่มกรรมการในตาราง Director
    Private Sub AddDirector(fundID As Integer, memberID As Integer)
        Try
            Dim query As String = "INSERT INTO Director (fu_id, m_id) VALUES (@fu_id, @m_id)"
            Dim cmd As New OleDbCommand(query, Conn)

            cmd.Parameters.AddWithValue("@fu_id", fundID)
            cmd.Parameters.AddWithValue("@m_id", memberID)

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Error adding director: " & ex.Message)
        End Try
    End Sub

    Private Sub btnUpdateFund_Click(sender As Object, e As EventArgs) Handles btnUpdateFund.Click
        If Not ValidateInputs() Then
            Exit Sub
        End If

        Try
            Conn.Open()
            Dim query As String = "UPDATE Fund SET fu_name = @fu_name, fu_address = @fu_address, fu_office = @fu_office, fu_pass = @fu_pass, fu_tel = @fu_tel WHERE fu_id = @fu_id"
            Dim cmd As New OleDbCommand(query, Conn)

            cmd.Parameters.AddWithValue("@fu_name", txtFundName.Text)
            cmd.Parameters.AddWithValue("@fu_address", txtAddress.Text)
            cmd.Parameters.AddWithValue("@fu_office", txtOffice.Text)
            cmd.Parameters.AddWithValue("@fu_pass", txtPass.Text)
            cmd.Parameters.AddWithValue("@fu_tel", txtTel.Text)
            cmd.Parameters.AddWithValue("@fu_id", CInt(txtFundID.Text))

            cmd.ExecuteNonQuery()

            ' Update the director in the Director table
            UpdateDirectors(CInt(txtFundID.Text))

            Conn.Close()

            MessageBox.Show("แก้ไขข้อมูลกองทุนเรียบร้อยแล้ว")
            LoadFundData()
            ClearInputs()
        Catch ex As Exception
            MessageBox.Show("Error updating fund: " & ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then
                Conn.Close()
            End If
        End Try
    End Sub

    Private Sub UpdateDirectors(fundID As Integer)
        Try
            ' First, delete existing directors for this fund
            DeleteDirectors(fundID)

            ' Then, add the selected directors from CheckedListBox
            For Each selectedItem In chkListDirectors.CheckedItems
                Dim memberId As Integer = CType(selectedItem, Object).m_id
                AddDirector(fundID, memberId)
            Next
        Catch ex As Exception
            MessageBox.Show("Error updating directors: " & ex.Message)
        End Try
    End Sub

    Private Sub DeleteDirectors(fundID As Integer)
        Try
            Dim query As String = "DELETE FROM Director WHERE fu_id = @fu_id"
            Dim cmd As New OleDbCommand(query, Conn)

            cmd.Parameters.AddWithValue("@fu_id", fundID)

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Error deleting directors: " & ex.Message)
        End Try
    End Sub

    Private Sub btnDeleteFund_Click(sender As Object, e As EventArgs) Handles btnDeleteFund.Click
        Try
            Conn.Open()
            Dim query As String = "DELETE FROM Fund WHERE fu_id = @fu_id"
            Dim cmd As New OleDbCommand(query, Conn)

            cmd.Parameters.AddWithValue("@fu_id", CInt(txtFundID.Text))

            cmd.ExecuteNonQuery()

            ' Delete the directors from the Director table
            DeleteDirectors(CInt(txtFundID.Text))

            Conn.Close()

            MessageBox.Show("ลบข้อมูลกองทุนเรียบร้อยแล้ว")
            LoadFundData()
            ClearInputs()
        Catch ex As Exception
            MessageBox.Show("Error deleting fund: " & ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then
                Conn.Close()
            End If
        End Try
    End Sub

    Private Sub dgvFunds_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFunds.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvFunds.Rows(e.RowIndex)

            ' Ensure cells are not DBNull before accessing their values
            txtFundID.Text = If(IsDBNull(row.Cells("fu_id").Value), "", row.Cells("fu_id").Value.ToString())
            txtFundName.Text = If(IsDBNull(row.Cells("fu_name").Value), "", row.Cells("fu_name").Value.ToString())
            txtAddress.Text = If(IsDBNull(row.Cells("fu_address").Value), "", row.Cells("fu_address").Value.ToString())
            txtOffice.Text = If(IsDBNull(row.Cells("fu_office").Value), "", row.Cells("fu_office").Value.ToString())
            txtPass.Text = If(IsDBNull(row.Cells("fu_pass").Value), "", row.Cells("fu_pass").Value.ToString())
            txtTel.Text = If(IsDBNull(row.Cells("fu_tel").Value), "", row.Cells("fu_tel").Value.ToString())

            ' Load the directors for this fund and check them in CheckedListBox
            LoadDirectors(CInt(txtFundID.Text))
        End If
    End Sub

    Private Sub LoadDirectors(fundID As Integer)
        Try
            Conn.Open()
            Dim query As String = "SELECT m_id FROM Director WHERE fu_id = @fu_id"
            Dim cmd As New OleDbCommand(query, Conn)
            cmd.Parameters.AddWithValue("@fu_id", fundID)

            Dim reader As OleDbDataReader = cmd.ExecuteReader()

            ' Clear previous selections
            For i As Integer = 0 To chkListDirectors.Items.Count - 1
                chkListDirectors.SetItemChecked(i, False)
            Next

            ' Check the directors that are associated with this fund
            While reader.Read()
                For i As Integer = 0 To chkListDirectors.Items.Count - 1
                    If CType(chkListDirectors.Items(i), Object).m_id = reader("m_id").ToString() Then
                        chkListDirectors.SetItemChecked(i, True)
                    End If
                Next
            End While

            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading directors: " & ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then
                Conn.Close()
            End If
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearInputs()
    End Sub

    Private Sub ClearInputs()
        txtFundID.Clear()
        txtFundName.Clear()
        txtAddress.Clear()
        txtOffice.Clear()
        txtPass.Clear()
        txtTel.Clear()

        ' Clear the CheckedListBox selections
        For i As Integer = 0 To chkListDirectors.Items.Count - 1
            chkListDirectors.SetItemChecked(i, False)
        Next

        ' Clear DataGridView selection
        dgvFunds.ClearSelection()
    End Sub
End Class

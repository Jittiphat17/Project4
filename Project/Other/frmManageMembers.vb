Imports System.Data.OleDb

Imports System.Globalization



Public Class frmManageMembers
    Dim conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
    Dim cmd As OleDbCommand
    Dim dr As OleDbDataReader
    Dim strSQL As String ' SQL Query String
    Dim isEditing As Boolean = False ' State for add/edit mode

    Private Sub frmManageMembers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigureDataGridView()
        ClearAllData()
        Loadinfo()
        Auto_id()
    End Sub

    Sub ConfigureDataGridView()
        ' Configure DataGridView columns
        dgvMembers.Columns.Clear()
        dgvMembers.Columns.Add("m_id", "รหัสสมาชิก")
        dgvMembers.Columns.Add("m_gender", "คำนำหน้า")
        dgvMembers.Columns.Add("m_name", "ชื่อ-นามสกุล")
        dgvMembers.Columns.Add("m_nick", "ชื่อเล่น")
        dgvMembers.Columns.Add("m_birth", "วัน/เดือน/ปีเกิด")
        dgvMembers.Columns.Add("m_age", "อายุ")
        dgvMembers.Columns.Add("m_thaiid", "รหัสประชาชน")
        dgvMembers.Columns.Add("m_job", "อาชีพ")
        dgvMembers.Columns.Add("m_address", "ที่อยู่")
        dgvMembers.Columns.Add("m_post", "รหัสไปรษณีย์")
        dgvMembers.Columns.Add("m_tel", "เบอร์โทรติดต่อ")
        dgvMembers.Columns.Add("m_accountName", "ชื่อบัญชี")
        dgvMembers.Columns.Add("m_accountNum", "เลขบัญชี")
        dgvMembers.Columns.Add("m_beginning", "ยอดยกมา")
        dgvMembers.Columns.Add("m_outstanding", "ลูกหนี้ค้างชำระ")
        dgvMembers.Columns.Add("m_national", "สัญชาติ")

        ' Set other DataGridView properties
        dgvMembers.DefaultCellStyle.Font = New Font("Tahoma", 10)
        dgvMembers.DefaultCellStyle.BackColor = Color.White
        dgvMembers.DefaultCellStyle.ForeColor = Color.Black
        dgvMembers.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray
        dgvMembers.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 10, FontStyle.Bold)
        dgvMembers.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy
        dgvMembers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvMembers.EnableHeadersVisualStyles = False
    End Sub

    Sub Loadinfo()
        strSQL = "SELECT * FROM Member"
        cmd = New OleDbCommand(strSQL, conn)

        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()

            dr = cmd.ExecuteReader
            dgvMembers.Rows.Clear()

            While dr.Read
                Dim birthDate As String = DateTime.Parse(dr("m_birth").ToString()).ToString("dd/MM/yyyy")
                Dim age As Integer = dr("m_age") ' Retrieve age from the database
                dgvMembers.Rows.Add(dr("m_id").ToString, dr("m_gender").ToString, dr("m_name").ToString,
                                    dr("m_nick").ToString, birthDate, age, dr("m_thaiid").ToString, dr("m_job").ToString,
                                    dr("m_address").ToString, dr("m_post").ToString, dr("m_tel").ToString,
                                    dr("m_accountName").ToString, dr("m_accountNum").ToString,
                                    dr("m_beginning").ToString, dr("m_outstanding").ToString, dr("m_national").ToString)
            End While

            conn.Close()
            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ClearAllData()
        txtID.Clear()
        txtName.Clear()
        txtnick.Clear()
        dtpBirth.Value = DateTime.Now
        txtThaiid.Clear()
        txtJob.Clear()
        txtAddress.Clear()
        txtPost.Clear()
        txtTel.Clear()
        txtOutstanding.Clear()
        txtBeginning.Clear()
        txtAccountname.Clear()
        txtAccountnum.Clear()
        txtAge.Clear()

        cmbGender.Items.Clear()
        cmbGender.Items.Add("เลือกคำนำหน้า")
        cmbGender.Items.Add("ดช.")
        cmbGender.Items.Add("ดญ.")
        cmbGender.Items.Add("นาย")
        cmbGender.Items.Add("นาง")
        cmbGender.Items.Add("นางสาว")
        cmbGender.SelectedIndex = 0

        cmbNational.Items.Clear()
        cmbNational.Items.Add("เลือกสัญชาติ")
        cmbNational.Items.Add("ไทย")
        cmbNational.SelectedIndex = 0

        isEditing = False ' Reset editing state
    End Sub

    Sub Auto_id()
        Dim m_id As Integer
        Try
            strSQL = "SELECT m_id FROM Member ORDER BY m_id DESC"
            cmd = New OleDbCommand(strSQL, conn)

            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If dr.Read = True Then
                m_id = Val(dr(0)) + 1
            Else
                m_id = 1
            End If
            txtID.Text = m_id.ToString("0000")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not AllFieldsFilled() Then
            MessageBox.Show("โปรดกรอกข้อมูลให้ครบถ้วน", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            If isEditing Then
                ' Update existing member
                strSQL = "UPDATE Member SET m_gender = @m_gender, m_name = @m_name, m_nick = @m_nick, m_birth = @m_birth, m_national = @m_national, " &
                         "m_thaiid = @m_thaiid, m_job = @m_job, m_address = @m_address, m_post = @m_post, m_tel = @m_tel, m_accountName = @m_accountName, " &
                         "m_accountNum = @m_accountNum, m_beginning = @m_beginning, m_outstanding = @m_outstanding, m_age = @m_age WHERE m_id = @m_id"
            Else
                ' Add new member
                strSQL = "INSERT INTO Member (m_id, m_gender, m_name, m_nick, m_birth, m_national, m_thaiid, m_job, m_address, m_post, m_tel, m_accountName, " &
                         "m_accountNum, m_beginning, m_outstanding, m_age) VALUES (@m_id, @m_gender, @m_name, @m_nick, @m_birth, @m_national, @m_thaiid, " &
                         "@m_job, @m_address, @m_post, @m_tel, @m_accountName, @m_accountNum, @m_beginning, @m_outstanding, @m_age)"
            End If

            Using cmd As New OleDbCommand(strSQL, conn)
                cmd.Parameters.AddWithValue("@m_id", txtID.Text.Trim())
                cmd.Parameters.AddWithValue("@m_gender", cmbGender.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@m_name", txtName.Text.Trim())
                cmd.Parameters.AddWithValue("@m_nick", txtnick.Text.Trim())
                cmd.Parameters.AddWithValue("@m_birth", dtpBirth.Value.ToString("yyyy-MM-dd"))
                cmd.Parameters.AddWithValue("@m_national", cmbNational.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@m_thaiid", txtThaiid.Text.Trim())
                cmd.Parameters.AddWithValue("@m_job", txtJob.Text.Trim())
                cmd.Parameters.AddWithValue("@m_address", txtAddress.Text.Trim())
                cmd.Parameters.AddWithValue("@m_post", txtPost.Text.Trim())
                cmd.Parameters.AddWithValue("@m_tel", txtTel.Text.Trim())
                cmd.Parameters.AddWithValue("@m_accountName", txtAccountname.Text.Trim())
                cmd.Parameters.AddWithValue("@m_accountNum", txtAccountnum.Text.Trim())

                If String.IsNullOrEmpty(txtBeginning.Text.Trim()) Then
                    cmd.Parameters.AddWithValue("@m_beginning", DBNull.Value)
                Else
                    cmd.Parameters.AddWithValue("@m_beginning", Double.Parse(txtBeginning.Text.Trim()))
                End If

                If String.IsNullOrEmpty(txtOutstanding.Text.Trim()) Then
                    cmd.Parameters.AddWithValue("@m_outstanding", DBNull.Value)
                Else
                    cmd.Parameters.AddWithValue("@m_outstanding", Double.Parse(txtOutstanding.Text.Trim()))
                End If

                cmd.Parameters.AddWithValue("@m_age", CalculateAge(dtpBirth.Value.ToString("dd/MM/yyyy")))

                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If

                cmd.ExecuteNonQuery()
                MessageBox.Show("บันทึกข้อมูลสำเร็จ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                conn.Close()
            End Using

            ClearAllData()
            Loadinfo()
            Auto_id()
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการบันทึกข้อมูล: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function AllFieldsFilled() As Boolean
        Return Not (String.IsNullOrWhiteSpace(txtName.Text) Or String.IsNullOrWhiteSpace(txtnick.Text) Or String.IsNullOrWhiteSpace(txtThaiid.Text) Or
                    String.IsNullOrWhiteSpace(txtJob.Text) Or String.IsNullOrWhiteSpace(txtAddress.Text) Or String.IsNullOrWhiteSpace(txtPost.Text) Or
                    String.IsNullOrWhiteSpace(txtTel.Text) Or String.IsNullOrWhiteSpace(txtAccountname.Text) Or String.IsNullOrWhiteSpace(txtAccountnum.Text) Or
                    cmbGender.SelectedIndex = 0 Or cmbNational.SelectedIndex = 0)
    End Function

    Private Sub dgvMembers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMembers.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvMembers.Rows(e.RowIndex)
            txtID.Text = If(row.Cells("m_id").Value IsNot Nothing, row.Cells("m_id").Value.ToString(), String.Empty)
            cmbGender.SelectedItem = If(row.Cells("m_gender").Value IsNot Nothing, row.Cells("m_gender").Value.ToString(), Nothing)
            txtName.Text = If(row.Cells("m_name").Value IsNot Nothing, row.Cells("m_name").Value.ToString(), String.Empty)
            txtnick.Text = If(row.Cells("m_nick").Value IsNot Nothing, row.Cells("m_nick").Value.ToString(), String.Empty)

            Dim birthDateString As String = If(row.Cells("m_birth").Value IsNot Nothing, row.Cells("m_birth").Value.ToString(), String.Empty)
            Dim birthDate As DateTime
            If DateTime.TryParseExact(birthDateString, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, birthDate) Then
                dtpBirth.Value = birthDate
            Else
                dtpBirth.Value = DateTime.Now
            End If

            txtAge.Text = If(row.Cells("m_age").Value IsNot Nothing, row.Cells("m_age").Value.ToString(), String.Empty)
            txtThaiid.Text = If(row.Cells("m_thaiid").Value IsNot Nothing, row.Cells("m_thaiid").Value.ToString(), String.Empty)
            txtJob.Text = If(row.Cells("m_job").Value IsNot Nothing, row.Cells("m_job").Value.ToString(), String.Empty)
            txtAddress.Text = If(row.Cells("m_address").Value IsNot Nothing, row.Cells("m_address").Value.ToString(), String.Empty)
            txtPost.Text = If(row.Cells("m_post").Value IsNot Nothing, row.Cells("m_post").Value.ToString(), String.Empty)
            txtTel.Text = If(row.Cells("m_tel").Value IsNot Nothing, row.Cells("m_tel").Value.ToString(), String.Empty)
            txtAccountname.Text = If(row.Cells("m_accountName").Value IsNot Nothing, row.Cells("m_accountName").Value.ToString(), String.Empty)
            txtAccountnum.Text = If(row.Cells("m_accountNum").Value IsNot Nothing, row.Cells("m_accountNum").Value.ToString(), String.Empty)
            txtBeginning.Text = If(row.Cells("m_beginning").Value IsNot Nothing, row.Cells("m_beginning").Value.ToString(), String.Empty)
            txtOutstanding.Text = If(row.Cells("m_outstanding").Value IsNot Nothing, row.Cells("m_outstanding").Value.ToString(), String.Empty)
            cmbNational.SelectedItem = If(row.Cells("m_national").Value IsNot Nothing, row.Cells("m_national").Value.ToString(), Nothing)

            isEditing = True ' Set editing state to true
        End If
    End Sub

    Private Function CalculateAge(birthDate As String) As Integer
        Dim birthDateObj As Date
        If DateTime.TryParseExact(birthDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, birthDateObj) Then
            Dim age As Integer = DateTime.Now.Year - birthDateObj.Year
            If DateTime.Now < birthDateObj.AddYears(age) Then age -= 1
            Return age
        Else
            Return 0
        End If
    End Function

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearAllData()
        Auto_id() ' Set new ID for new entry
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If String.IsNullOrEmpty(txtID.Text) Then
            MessageBox.Show("Please select a member to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this member?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.Yes Then
            Try
                If conn.State = ConnectionState.Closed Then conn.Open()
                Dim deleteQuery As String = "DELETE FROM Member WHERE m_id = @m_id"
                Using cmdDelete As New OleDbCommand(deleteQuery, conn)
                    cmdDelete.Parameters.AddWithValue("@m_id", txtID.Text)
                    cmdDelete.ExecuteNonQuery()
                End Using

                MessageBox.Show("Member deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ClearAllData()
                Loadinfo()
            Catch ex As Exception
                MessageBox.Show("Error deleting member: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                conn.Close()
            End Try
        End If
    End Sub

End Class
Imports System.Data.OleDb
Imports System.Globalization

Public Class frmAddmember
    Dim Conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\db_test.mdb")
    Dim cmd As OleDbCommand
    Dim dr As OleDbDataReader
    Dim strSQL As String ' เปลี่ยนชื่อตัวแปร SQL เป็น strSQL

    Sub Loadinfo()
        strSQL = "SELECT * FROM Member"
        cmd = New OleDbCommand(strSQL, Conn)

        Try
            If Conn.State = ConnectionState.Open Then Conn.Close()
            Conn.Open()

            dr = cmd.ExecuteReader
            dgvConn.Rows.Clear()

            While dr.Read
                Dim birthDate As String = DateTime.Parse(dr("m_birth").ToString()).ToString("dd/MM/yyyy")
                Dim age As Integer = dr("m_age") ' ดึงอายุจากฐานข้อมูล
                dgvConn.Rows.Add(dr("m_id").ToString, dr("m_gender").ToString, dr("m_name").ToString,
                 dr("m_nick").ToString, birthDate,
                 age, dr("m_thaiid").ToString, dr("m_job").ToString,
                 dr("m_address").ToString, dr("m_post").ToString, dr("m_tel").ToString,
                 dr("m_accountName").ToString, dr("m_accountNum").ToString,
                 dr("m_beginning").ToString, dr("m_outstanding").ToString,
                 dr("m_national").ToString)
            End While

            Conn.Close()
            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Sub ClearAllData()
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
        txtAge.Clear() ' Clear age field

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
    End Sub

    Sub Auto_id()
        Dim m_id As Integer
        Try
            strSQL = "SELECT m_id FROM Member ORDER BY m_id DESC" ' เปลี่ยนชื่อตัวแปร SQL เป็น strSQL
            cmd = New OleDbCommand(strSQL, Conn) ' เปลี่ยนชื่อตัวแปร SQL เป็น strSQL

            If Conn.State = ConnectionState.Open Then Conn.Close()
            Conn.Open()

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
        ' Check if all required fields are filled
        If AllFieldsFilled() Then
            ' Check if Thai ID already exists
            If IsThaiIdExists(txtThaiid.Text.Trim()) Then
                MessageBox.Show("เลขบัตรประชาชนนี้มีอยู่แล้วในฐานข้อมูล", "Duplicate Thai ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            ' Continue with save process
            Try
                strSQL = "INSERT INTO Member (m_id,m_gender,m_name,m_nick,m_birth,m_national,
        m_thaiid,m_job,m_address,m_post,m_tel,m_accountName,m_accountNum,m_beginning,m_outstanding, m_age)"
                strSQL &= " VALUES (@m_id,@m_gender,@m_name,@m_nick,@m_birth,@m_national,@m_thaiid,
        @m_job,@m_address,@m_post,@m_tel,@m_accountName,@m_accountNum,@m_beginning,@m_outstanding, @m_age)"

                Using cmdInsert As New OleDbCommand(strSQL, Conn)
                    ' Add parameters
                    cmdInsert.Parameters.AddWithValue("@m_id", txtID.Text.Trim())
                    cmdInsert.Parameters.AddWithValue("@m_gender", cmbGender.SelectedItem.ToString())
                    cmdInsert.Parameters.AddWithValue("@m_name", txtName.Text.Trim())
                    cmdInsert.Parameters.AddWithValue("@m_nick", txtnick.Text.Trim())
                    ' Specify the correct date format here
                    cmdInsert.Parameters.AddWithValue("@m_birth", DateTime.ParseExact(dtpBirth.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"))
                    cmdInsert.Parameters.AddWithValue("@m_national", cmbNational.SelectedItem.ToString())
                    cmdInsert.Parameters.AddWithValue("@m_thaiid", txtThaiid.Text.Trim())
                    cmdInsert.Parameters.AddWithValue("@m_job", txtJob.Text.Trim())
                    cmdInsert.Parameters.AddWithValue("@m_address", txtAddress.Text.Trim())
                    cmdInsert.Parameters.AddWithValue("@m_post", txtPost.Text.Trim())
                    cmdInsert.Parameters.AddWithValue("@m_tel", txtTel.Text.Trim())
                    cmdInsert.Parameters.AddWithValue("@m_accountName", txtAccountname.Text.Trim())
                    cmdInsert.Parameters.AddWithValue("@m_accountNum", txtAccountnum.Text.Trim())

                    ' Check if m_beginning and m_outstanding are not empty, if so, add them as parameters
                    If Not String.IsNullOrEmpty(txtBeginning.Text.Trim()) Then
                        cmdInsert.Parameters.AddWithValue("@m_beginning", Double.Parse(txtBeginning.Text.Trim()))
                    Else
                        cmdInsert.Parameters.AddWithValue("@m_beginning", DBNull.Value)
                    End If

                    If Not String.IsNullOrEmpty(txtOutstanding.Text.Trim()) Then
                        cmdInsert.Parameters.AddWithValue("@m_outstanding", Double.Parse(txtOutstanding.Text.Trim()))
                    Else
                        cmdInsert.Parameters.AddWithValue("@m_outstanding", DBNull.Value)
                    End If

                    ' Add age parameter
                    Dim birthDate As String = dtpBirth.Value.ToString("dd/MM/yyyy")
                    Dim age As Integer = CalculateAge(birthDate)
                    cmdInsert.Parameters.AddWithValue("@m_age", age)

                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If

                    cmdInsert.ExecuteNonQuery()

                    MessageBox.Show("บันทึกข้อมูลสำเร็จ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Conn.Close()
                End Using

                ' Clear data and reload info
                ClearAllData()
                Loadinfo()
                Auto_id()
            Catch ex As Exception
                MessageBox.Show("เกิดข้อผิดพลาดในการบันทึกข้อมูล: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("โปรดกรอกข้อมูลให้ครบถ้วน", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearAllData()
    End Sub

    Private Sub frmAddmember_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClearAllData()
        Loadinfo()
        Auto_id()
    End Sub

    Private Function AllFieldsFilled() As Boolean
        ' Check if all required fields are filled except for m_beginning and m_outstanding
        If txtName.Text.Trim() = "" OrElse
           txtnick.Text.Trim() = "" OrElse
           txtThaiid.Text.Trim() = "" OrElse
           txtJob.Text.Trim() = "" OrElse
           txtAddress.Text.Trim() = "" OrElse
           txtPost.Text.Trim() = "" OrElse
           txtTel.Text.Trim() = "" OrElse
           txtAccountname.Text.Trim() = "" OrElse
           txtAccountnum.Text.Trim() = "" OrElse
           cmbGender.SelectedIndex = 0 OrElse
           cmbNational.SelectedIndex = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Function IsThaiIdExists(thaiId As String) As Boolean
        Dim isExists As Boolean = False
        Try
            Dim query As String = "SELECT COUNT(*) FROM Member WHERE m_thaiid = @m_thaiid"
            Using cmdCheck As New OleDbCommand(query, Conn)
                cmdCheck.Parameters.AddWithValue("@m_thaiid", thaiId)
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If
                Dim count As Integer = Convert.ToInt32(cmdCheck.ExecuteScalar())
                If count > 0 Then
                    isExists = True
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการตรวจสอบเลขบัตรประชาชน: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Conn.Close()
        End Try
        Return isExists
    End Function

    Function CalculateAge(birthDate As String) As Integer
        Dim birthDateObj As Date
        Dim formats As String() = {"dd/MM/yyyy", "d/M/yyyy", "dd-MM-yyyy", "d-M-yyyy"} ' Add any other date formats if necessary
        If DateTime.TryParseExact(birthDate, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, birthDateObj) Then
            Dim age As Integer = DateTime.Now.Year - birthDateObj.Year
            If DateTime.Now.Month < birthDateObj.Month OrElse (DateTime.Now.Month = birthDateObj.Month AndAlso DateTime.Now.Day < birthDateObj.Day) Then
                age -= 1
            End If
            Return age
        Else
            MessageBox.Show("รูปแบบวันที่ไม่ถูกต้อง: " & birthDate, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1 ' Return -1 if there is an error
        End If
    End Function

    Private Sub dtpBirth_ValueChanged(sender As Object, e As EventArgs) Handles dtpBirth.ValueChanged
        ' Calculate age when birth date changes
        Dim birthDate As String = dtpBirth.Value.ToString("dd/MM/yyyy")
        Dim age As Integer = CalculateAge(birthDate)
        If age >= 0 Then
            txtAge.Text = age.ToString()
        Else
            txtAge.Text = "" ' Clear age if there is an error
        End If
    End Sub

End Class

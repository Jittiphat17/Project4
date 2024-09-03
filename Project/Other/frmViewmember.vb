Imports System.Data.OleDb

Public Class frmViewmember
    Dim Conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
    Dim cmd As OleDbCommand
    Dim dr As OleDbDataReader
    Dim strSQL As String ' เปลี่ยนชื่อตัวแปร SQL เป็น strSQL

    Private Sub frmViewmember_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Loadinfo()
    End Sub

    Sub Loadinfo()
        strSQL = "SELECT Member.*, Account.acc_name FROM Member LEFT JOIN Account ON Member.acc_id = Account.acc_id" ' เปลี่ยนชื่อตัวแปร SQL เป็น strSQL
        cmd = New OleDbCommand(strSQL, Conn) ' เปลี่ยนชื่อตัวแปร SQL เป็น strSQL

        Try
            If Conn.State = ConnectionState.Open Then Conn.Close()
            Conn.Open()

            dr = cmd.ExecuteReader
            dgvConn.Rows.Clear()

            While dr.Read
                Dim age As Integer = CalculateAge(dr("m_birth").ToString())
                dgvConn.Rows.Add(dr("m_id").ToString, dr("m_gender").ToString, dr("m_name").ToString,
                     dr("m_nick").ToString, DateTime.Parse(dr("m_birth").ToString()).ToString("dd/MM/yyyy"),
                     age, dr("m_thaiid").ToString, dr("m_job").ToString,
                     dr("m_address").ToString, dr("m_post").ToString, dr("m_tel").ToString,
                     dr("m_accountName").ToString, dr("m_accountNum").ToString,
                     dr("m_beginning").ToString, dr("m_outstanding").ToString,
                     dr("m_national").ToString, dr("acc_id").ToString, dr("acc_name").ToString) ' เพิ่มฟิลด์ประเภทบัญชี
            End While

            Conn.Close()
            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function CalculateAge(birthDate As String) As Integer
        Dim birthDateObj As Date = DateTime.Parse(birthDate)
        Dim age As Integer = DateDiff(DateInterval.Year, birthDateObj, DateTime.Now)
        Return age
    End Function

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Call Search()
    End Sub

    Sub Search()
        strSQL = "SELECT Member.*, Account.acc_name FROM Member LEFT JOIN Account ON Member.acc_id = Account.acc_id WHERE m_nick='" & txtSearch.Text & "' OR m_name LIKE '%" & txtSearch.Text & "%'"
        cmd = New OleDbCommand(strSQL, Conn)
        Try
            If Conn.State = ConnectionState.Open Then Conn.Close()
            Conn.Open()

            dr = cmd.ExecuteReader
            If dr.HasRows Then
                dgvConn.Rows.Clear()
                While dr.Read
                    Dim age As Integer = CalculateAge(dr("m_birth").ToString())
                    dgvConn.Rows.Add(dr("m_id").ToString, dr("m_gender").ToString, dr("m_name").ToString,
                     dr("m_nick").ToString, DateTime.Parse(dr("m_birth").ToString()).ToString("dd/MM/yyyy"),
                     age, dr("m_thaiid").ToString, dr("m_job").ToString,
                     dr("m_address").ToString, dr("m_post").ToString, dr("m_tel").ToString,
                     dr("m_accountName").ToString, dr("m_accountNum").ToString,
                     dr("m_beginning").ToString, dr("m_outstanding").ToString,
                     dr("m_national").ToString, dr("acc_id").ToString, dr("acc_name").ToString) ' เพิ่มฟิลด์ประเภทบัญชี
                End While
                txtSearch.Clear()

            Else
                MessageBox.Show("ไม่พบข้อมูลการค้นหา", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            Conn.Close()
            cmd.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

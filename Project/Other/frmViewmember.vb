Imports System.Data.OleDb

Public Class frmViewMember
    Dim Conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
    Dim cmd As OleDbCommand
    Dim dr As OleDbDataReader ' ประกาศตัวแปร dr ที่ระดับคลาส
    Dim strSQL As String

    Private Sub frmViewmember_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DecorateDataGridView() ' Set up columns first
        Loadinfo()             ' Load the data into the Guna2DataGridView
        LoadAccountTypes()     ' Load account types into the ComboBox
    End Sub

    Sub LoadAccountTypes()
        Try
            If Conn.State = ConnectionState.Closed Then Conn.Open()
            Dim cmd As New OleDbCommand("SELECT DISTINCT acc_name FROM Account", Conn)
            dr = cmd.ExecuteReader()

            cboAccountType.Items.Clear()
            cboAccountType.Items.Add("ทั้งหมด") ' สำหรับค้นหาทุกประเภท
            While dr.Read()
                cboAccountType.Items.Add(dr("acc_name").ToString())
            End While
            cboAccountType.SelectedIndex = 0 ' เริ่มต้นที่ 'ทั้งหมด'
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการโหลดประเภทบัญชี: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dr IsNot Nothing Then dr.Close()
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Sub DecorateDataGridView()
        ' Clear existing columns
        dgvConn.Columns.Clear()

        ' Define columns using Guna2DataGridView
        dgvConn.Columns.Add("m_id", "รหัสสมาชิก")
        dgvConn.Columns.Add("m_gender", "คำนำหน้า")
        dgvConn.Columns.Add("m_name", "ชื่อ-นามสกุล")
        dgvConn.Columns.Add("m_nick", "ชื่อเล่น")
        dgvConn.Columns.Add("m_birth", "วันเกิด")
        dgvConn.Columns.Add("age", "อายุ")
        dgvConn.Columns.Add("m_thaiid", "เลขบัตรประชาชน")
        dgvConn.Columns.Add("m_job", "อาชีพ")
        dgvConn.Columns.Add("m_address", "ที่อยู่")
        dgvConn.Columns.Add("m_post", "รหัสไปรษณีย์")
        dgvConn.Columns.Add("m_tel", "เบอร์โทรศัพท์")
        dgvConn.Columns.Add("m_accountName", "ชื่อบัญชี")
        dgvConn.Columns.Add("m_accountNum", "หมายเลขบัญชี")
        dgvConn.Columns.Add("m_beginning", "ยอดยกมา")
        dgvConn.Columns.Add("m_outstanding", "ยอดคงเหลือ")
        dgvConn.Columns.Add("m_national", "สัญชาติ")
        dgvConn.Columns.Add("acc_name", "ประเภทบัญชี") ' Column for the account type

        ' Apply Guna.UI2 styling with FC Minimal font
        Dim fcMinimalFont As New Font("FC Minimal", 10, FontStyle.Regular)
        Dim fcMinimalBoldFont As New Font("FC Minimal", 12, FontStyle.Bold)

        dgvConn.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240)
        dgvConn.DefaultCellStyle.SelectionBackColor = Color.LightBlue
        dgvConn.DefaultCellStyle.SelectionForeColor = Color.Black
        dgvConn.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvConn.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        dgvConn.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy
        dgvConn.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvConn.ColumnHeadersDefaultCellStyle.Font = fcMinimalBoldFont
        dgvConn.DefaultCellStyle.Font = fcMinimalFont
        dgvConn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvConn.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvConn.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        For Each column As DataGridViewColumn In dgvConn.Columns
            column.SortMode = DataGridViewColumnSortMode.Automatic
        Next
    End Sub

    Sub Loadinfo()
        ' Ensure that columns are set up before loading data
        If dgvConn.Columns.Count = 0 Then
            DecorateDataGridView() ' Ensure columns are set up
        End If

        ' Adjust the SQL query to join Member with Account_Details and Account
        strSQL = "SELECT Member.m_id, Member.m_gender, Member.m_name, Member.m_nick, Member.m_birth, " &
             "Member.m_thaiid, Member.m_job, Member.m_address, Member.m_post, Member.m_tel, " &
             "Member.m_accountName, Member.m_accountNum, Member.m_beginning, Member.m_outstanding, " &
             "Member.m_national, Account.acc_name " &
             "FROM (Member " &
             "LEFT JOIN Account_Details ON Member.m_id = Account_Details.m_id) " &
             "LEFT JOIN Account ON Account_Details.acc_id = Account.acc_id"

        cmd = New OleDbCommand(strSQL, Conn)

        Try
            If Conn.State = ConnectionState.Closed Then Conn.Open()
            dr = cmd.ExecuteReader

            dgvConn.Rows.Clear()

            While dr.Read
                Dim age As Integer = If(IsDBNull(dr("m_birth")), 0, CalculateAge(dr("m_birth").ToString()))
                Dim accountName As String = If(IsDBNull(dr("acc_name")), "ไม่พบข้อมูล", dr("acc_name").ToString())

                dgvConn.Rows.Add(
                dr("m_id").ToString(),
                dr("m_gender").ToString(),
                dr("m_name").ToString(),
                dr("m_nick").ToString(),
                If(IsDBNull(dr("m_birth")), "", DateTime.Parse(dr("m_birth").ToString()).ToString("dd/MM/yyyy")),
                age,
                dr("m_thaiid").ToString(),
                dr("m_job").ToString(),
                dr("m_address").ToString(),
                dr("m_post").ToString(),
                dr("m_tel").ToString(),
                dr("m_accountName").ToString(),
                dr("m_accountNum").ToString(),
                dr("m_beginning").ToString(),
                dr("m_outstanding").ToString(),
                dr("m_national").ToString(),
                accountName ' Display the account type from the Account table
            )
            End While

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dr IsNot Nothing Then dr.Close()
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Function CalculateAge(birthDate As String) As Integer
        Dim birthDateObj As Date = DateTime.Parse(birthDate)
        Dim age As Integer = DateDiff(DateInterval.Year, birthDateObj, DateTime.Now)
        Return age
    End Function

    Private Sub btnSearchByAccount_Click(sender As Object, e As EventArgs) Handles btnSearchByAccount.Click
        SearchByAccountType()
    End Sub

    Private Sub btnSearchByName_Click(sender As Object, e As EventArgs) Handles btnSearchByName.Click
        SearchByName()
    End Sub

    Sub SearchByAccountType()
        ' Query ข้อมูลสมาชิกที่ตรงกับประเภทบัญชีที่ค้นหา
        strSQL = "SELECT Member.m_id, Member.m_gender, Member.m_name, Member.m_nick, Member.m_birth, " &
                 "Member.m_thaiid, Member.m_job, Member.m_address, Member.m_post, Member.m_tel, " &
                 "Member.m_accountName, Member.m_accountNum, Member.m_beginning, Member.m_outstanding, " &
                 "Member.m_national, Account.acc_name " &
                 "FROM (Member " &
                 "LEFT JOIN Account_Details ON Member.m_id = Account_Details.m_id) " &
                 "LEFT JOIN Account ON Account_Details.acc_id = Account.acc_id "

        ' เพิ่มเงื่อนไขการกรองตามประเภทบัญชี
        If cboAccountType.SelectedIndex > 0 Then ' ตรวจสอบว่าได้เลือกประเภทบัญชีหรือยัง (ค่า index > 0)
            strSQL &= "WHERE Account.acc_name = @accountType"
        End If

        ' ตั้งค่าคำสั่ง SQL และเชื่อมต่อกับฐานข้อมูล
        cmd = New OleDbCommand(strSQL, Conn)

        ' ถ้าเลือกประเภทบัญชีให้เพิ่มค่า parameter
        If cboAccountType.SelectedIndex > 0 Then
            cmd.Parameters.AddWithValue("@accountType", cboAccountType.SelectedItem.ToString())
        End If

        Try
            If Conn.State = ConnectionState.Closed Then Conn.Open()

            dr = cmd.ExecuteReader()
            dgvConn.Rows.Clear()

            ' เติมข้อมูลที่พบลงใน DataGridView
            While dr.Read()
                Dim age As Integer = If(IsDBNull(dr("m_birth")), 0, CalculateAge(dr("m_birth").ToString()))
                Dim accountName As String = If(IsDBNull(dr("acc_name")), "ไม่พบข้อมูล", dr("acc_name").ToString())

                dgvConn.Rows.Add(
                    dr("m_id").ToString(),
                    dr("m_gender").ToString(),
                    dr("m_name").ToString(),
                    dr("m_nick").ToString(),
                    If(IsDBNull(dr("m_birth")), "", DateTime.Parse(dr("m_birth").ToString()).ToString("dd/MM/yyyy")),
                    age,
                    dr("m_thaiid").ToString(),
                    dr("m_job").ToString(),
                    dr("m_address").ToString(),
                    dr("m_post").ToString(),
                    dr("m_tel").ToString(),
                    dr("m_accountName").ToString(),
                    dr("m_accountNum").ToString(),
                    dr("m_beginning").ToString(),
                    dr("m_outstanding").ToString(),
                    dr("m_national").ToString(),
                    accountName ' แสดงชื่อบัญชีที่เชื่อมโยง
                )
            End While

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dr IsNot Nothing Then dr.Close()
            If Conn.State = ConnectionState.Open Then Conn.Close()
            If cmd IsNot Nothing Then cmd.Dispose()
        End Try
    End Sub

    Sub SearchByName()
        ' Query ข้อมูลสมาชิกที่ตรงกับชื่อที่ค้นหา
        strSQL = "SELECT Member.m_id, Member.m_gender, Member.m_name, Member.m_nick, Member.m_birth, " &
                 "Member.m_thaiid, Member.m_job, Member.m_address, Member.m_post, Member.m_tel, " &
                 "Member.m_accountName, Member.m_accountNum, Member.m_beginning, Member.m_outstanding, " &
                 "Member.m_national, Account.acc_name " &
                 "FROM (Member " &
                 "LEFT JOIN Account_Details ON Member.m_id = Account_Details.m_id) " &
                 "LEFT JOIN Account ON Account_Details.acc_id = Account.acc_id " &
                 "WHERE Member.m_name LIKE @name"

        cmd = New OleDbCommand(strSQL, Conn)
        cmd.Parameters.AddWithValue("@name", "%" & txtSearch.Text & "%") ' ใช้ LIKE เพื่อค้นหาชื่อที่ตรงหรือมีส่วนคล้าย

        Try
            If Conn.State = ConnectionState.Closed Then Conn.Open()

            dr = cmd.ExecuteReader()
            dgvConn.Rows.Clear()

            ' เติมข้อมูลที่พบลงใน DataGridView
            While dr.Read()
                Dim age As Integer = If(IsDBNull(dr("m_birth")), 0, CalculateAge(dr("m_birth").ToString()))
                Dim accountName As String = If(IsDBNull(dr("acc_name")), "ไม่พบข้อมูล", dr("acc_name").ToString())

                dgvConn.Rows.Add(
                    dr("m_id").ToString(),
                    dr("m_gender").ToString(),
                    dr("m_name").ToString(),
                    dr("m_nick").ToString(),
                    If(IsDBNull(dr("m_birth")), "", DateTime.Parse(dr("m_birth").ToString()).ToString("dd/MM/yyyy")),
                    age,
                    dr("m_thaiid").ToString(),
                    dr("m_job").ToString(),
                    dr("m_address").ToString(),
                    dr("m_post").ToString(),
                    dr("m_tel").ToString(),
                    dr("m_accountName").ToString(),
                    dr("m_accountNum").ToString(),
                    dr("m_beginning").ToString(),
                    dr("m_outstanding").ToString(),
                    dr("m_national").ToString(),
                    accountName ' แสดงชื่อบัญชีที่เชื่อมโยง
                )
            End While

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dr IsNot Nothing Then dr.Close()
            If Conn.State = ConnectionState.Open Then Conn.Close()
            If cmd IsNot Nothing Then cmd.Dispose()
        End Try
    End Sub
End Class
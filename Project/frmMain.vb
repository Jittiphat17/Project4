Imports System.Data.OleDb
Imports System.Globalization

Public Class frmMain
    ' เพิ่มตัวเชื่อมต่อฐานข้อมูล
    Dim Conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\db_test.mdb")

    Public Sub Loadinfo()
        If User_type = "Admin" Then
            tsm_exp.Enabled = True
            tsm_rev.Enabled = True
            tsm_report.Enabled = True
            tsm_other.Enabled = True
        Else
            tsm_other.Enabled = False
        End If
    End Sub

    Private Sub UpdateUserInfo()
        ' ใช้ตัวแปร User_type จาก Module1 และคำว่า "ผู้ใช้ขณะนี้"
        lblUserInfo.Text = $"ผู้ใช้ขณะนี้ : {User_type}"
    End Sub

    Private Sub UpdateDateTime()
        ' อัปเดต Label สำหรับแสดงวันที่และเวลา
        lblDateTime.Text = DateTime.Now.ToString("d MMMM yyyy เวลา HH:mm:ss น.", CultureInfo.CreateSpecificCulture("th-TH"))
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ' อัปเดตวันที่และเวลาในทุกๆ 1 วินาที
        UpdateDateTime()
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Loadinfo()

        ' เรียกใช้ฟังก์ชันอัปเดตจำนวนสมาชิกและจำนวนสัญญา
        UpdateMemberCount()
        UpdateContractCount()
        ' ตั้งค่าเบื้องต้น
        UpdateUserInfo()
        UpdateDateTime()

        ' เริ่ม Timer
        Timer1.Start()
    End Sub

    Private Sub UpdateMemberCount()
        Try
            ' นิยามคำสั่ง SQL เพื่อดึงจำนวนสมาชิก
            Dim strSQL As String = "SELECT COUNT(*) FROM Member"
            Dim cmd As New OleDbCommand(strSQL, Conn)

            ' เปิดการเชื่อมต่อฐานข้อมูลหากยังไม่เปิด
            If Conn.State = ConnectionState.Open Then Conn.Close()
            Conn.Open()

            ' ดึงจำนวนสมาชิกและแสดงใน Label
            Dim memberCount As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            lbCount.Text = "จำนวนสมาชิก: " & memberCount.ToString() & " ราย"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' ปิดการเชื่อมต่อฐานข้อมูล
            Conn.Close()
        End Try
    End Sub

    Private Sub UpdateContractCount()
        Try
            ' นิยามคำสั่ง SQL เพื่อดึงจำนวนสัญญา
            Dim strSQL As String = "SELECT COUNT(*) FROM Contract"
            Dim cmd As New OleDbCommand(strSQL, Conn)

            ' เปิดการเชื่อมต่อฐานข้อมูลหากยังไม่เปิด
            If Conn.State = ConnectionState.Open Then Conn.Close()
            Conn.Open()

            ' ดึงจำนวนสัญญาและแสดงใน Label
            Dim contractCount As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            lbContractCount.Text = "จำนวนสัญญา: " & contractCount.ToString() & " ราย"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' ปิดการเชื่อมต่อฐานข้อมูล
            Conn.Close()
        End Try
    End Sub


    ' เมนู
    Private Sub รบเงนToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles รบเงนToolStripMenuItem.Click
        Dim frm As New frmIncome()
        ' เพิ่มการเชื่อมต่อ FormClosed event เพื่อรีเฟรชหน้าหลักเมื่อปิดฟอร์ม
        AddHandler frm.FormClosed, AddressOf RefreshMainForm
        frm.ShowDialog()
    End Sub

    Private Sub ออกจากระบบToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ออกจากระบบToolStripMenuItem.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        ' ตรวจสอบว่าผู้ใช้คลิก Yes หรือไม่
        If result = DialogResult.Yes Then
            ' ออกจากแอปพลิเคชัน
            Application.Exit()
        End If
    End Sub

    Private Sub เพมสมาชกToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles เพมสมาชกToolStripMenuItem.Click
        Dim frm As New frmAddmember()
        AddHandler frm.FormClosed, AddressOf RefreshMainForm
        frm.ShowDialog()
    End Sub

    Private Sub เรยกดสมาชกฃToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles เรยกดสมาชกฃToolStripMenuItem.Click
        Dim frm As New frmViewmember()
        AddHandler frm.FormClosed, AddressOf RefreshMainForm
        frm.ShowDialog()
    End Sub

    Private Sub แกไขคาใชจายToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles แกไขคาใชจายToolStripMenuItem.Click
        Dim frm As New frmUpdatee()
        AddHandler frm.FormClosed, AddressOf RefreshMainForm
        frm.ShowDialog()
    End Sub

    Private Sub จดการสทธToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles จดการสทธToolStripMenuItem.Click
        Dim frm As New frmManage()
        AddHandler frm.FormClosed, AddressOf RefreshMainForm
        frm.ShowDialog()
    End Sub

    Private Sub สำรองขอมลToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles สำรองขอมลToolStripMenuItem1.Click
        Dim frm As New frmBackup
        AddHandler frm.FormClosed, AddressOf RefreshMainForm
        frm.ShowDialog()
    End Sub

    Private Sub นำเขาขอมลToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles นำเขาขอมลToolStripMenuItem1.Click
        Dim frm As New frmImport
        AddHandler frm.FormClosed, AddressOf RefreshMainForm
        frm.ShowDialog()
    End Sub

    Private Sub อานบตรToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles อานบตรToolStripMenuItem.Click
        Dim frm As New frmCard
        AddHandler frm.FormClosed, AddressOf RefreshMainForm
        frm.ShowDialog()
    End Sub

    Private Sub ตารางเงนกToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ตารางเงนกToolStripMenuItem.Click
        Dim frm As New frmCon
        AddHandler frm.FormClosed, AddressOf RefreshMainForm
        frm.ShowDialog()
    End Sub

    Private Sub สมาชกลาออกToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles สมาชกลาออกToolStripMenuItem.Click
        Dim frm As New frmMemberResign
        AddHandler frm.FormClosed, AddressOf RefreshMainForm
        frm.ShowDialog()
    End Sub

    Private Sub ทำสญญาToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ทำสญญาToolStripMenuItem1.Click
        Dim frm As New frmBrrow()
        AddHandler frm.FormClosed, AddressOf RefreshMainForm
        frm.ShowDialog()
    End Sub

    Private Sub บนทกคาใชจายToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles บนทกคาใชจายToolStripMenuItem.Click
        Dim frm As New frmExpense()
        AddHandler frm.FormClosed, AddressOf RefreshMainForm
        frm.ShowDialog()
    End Sub

    Private Sub รายงานสญญาเงนกToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles รายงานสญญาเงนกToolStripMenuItem.Click
        Dim frm As New frmSearch
        AddHandler frm.FormClosed, AddressOf RefreshMainForm
        frm.ShowDialog()
    End Sub

    ' ฟังก์ชันเพื่อรีเฟรชข้อมูลในหน้าหลักเมื่อปิดฟอร์มอื่นๆ
    Private Sub RefreshMainForm(ByVal sender As Object, ByVal e As FormClosedEventArgs)
        ' เรียกใช้ฟังก์ชันเพื่อรีเฟรชข้อมูลในหน้าหลัก
        UpdateMemberCount()
        UpdateContractCount()
        UpdateDateTime() ' อัปเดตวันที่และเวลาหากต้องการ
    End Sub
End Class

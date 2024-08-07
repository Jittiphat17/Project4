Imports ThaiNationalIDCard
Imports System.ComponentModel
Public Class frmCard
    Dim bgWorker As New BackgroundWorker

    Private Sub frmSmartCard_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F7
                Call btnRead_Click(sender, e)
            Case Keys.F10
                Me.Close()
        End Select
    End Sub

    Private Sub frmSmartCard_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call SetupScreen()
        '// Detect Smart card reader.
        If Not GetReader() Then Return
        ProgressBar1.Visible = False
        '// Initialized BackGroundWorker
        With bgWorker
            .WorkerReportsProgress = True
            .WorkerSupportsCancellation = True
        End With
        '// *********** IMPORTANT ***********
        Control.CheckForIllegalCrossThreadCalls = False
        '// Add Event Handler.
        AddHandler bgWorker.DoWork, AddressOf bgWorker_DoWork
        AddHandler bgWorker.RunWorkerCompleted, AddressOf bgWorker_RunWorkerCompleted
    End Sub

    '// ตรวจสอบเครื่องอ่านบัตรว่ามีอยู่หรือไม่
    Function GetReader() As Boolean
        Try
            Dim ID As New ThaiIDCard
            Dim readers = ID.GetReaders
            If readers Is Nothing Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MessageBox.Show("Smart Card Reader not found.", "Report Status", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End Try
    End Function

    Private Sub btnRead_Click(sender As System.Object, e As System.EventArgs) Handles btnRead.Click
        Call SetupScreen()
        If Not GetReader() Then Return
        btnRead.Enabled = False
        '/
        ProgressBar1.Style = ProgressBarStyle.Marquee
        ProgressBar1.Visible = True
        '// BackGroundWorker
        bgWorker.RunWorkerAsync()
    End Sub

    Private Sub bgWorker_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs)
        Try
            '// -------------------------------------------
            '// โค้ดส่วนของการอ่านข้อมูลบัตรประชาชน
            Dim ID As New ThaiIDCard
            Refresh()
            Dim Personal As Personal = ID.readAllPhoto
            If Not IsNothing(Personal) Then
                With Personal
                    txtIDCard.Text = .Citizenid
                    txtPreFixThai.Text = .Th_Prefix
                    txtPrefixEng.Text = .En_Prefix
                    txtFirstNameThai.Text = .Th_Firstname
                    txtLastnameThai.Text = .Th_Lastname
                    txtFirstNameEng.Text = .En_Firstname
                    txtLastNameEng.Text = .En_Lastname
                    txtBirthDate.Text = Format(CDate(.Birthday.ToString), "dd/MM/yyyy")
                    '// คำนวณอายุ
                    If Not IsNothing(txtBirthDate.Text) Then lblAge.Text = CalcDate(txtBirthDate.Text, Now())
                    '// 1 = ชาย, 2 = หญิง (นำไปแปลงค่าเพศในฟังค์ชั่นก่อน)
                    txtSex.Text = CheckSex(.Sex, txtSex).ToString
                    txtIssueDate.Text = Format(CDate(.Issue.ToString), "dd/MM/yyyy")
                    txtExpireDate.Text = Format(CDate(.Expire.ToString), "dd/MM/yyyy")
                    '// ที่อยู่
                    txtHouseNo.Text = .addrHouseNo
                    txtVillageNo.Text = .addrVillageNo
                    txtLane.Text = .addrLane
                    txtRoad.Text = .addrRoad
                    txtTambol.Text = .addrTambol
                    txtAmphur.Text = .addrAmphur
                    txtProvince.Text = .addrProvince
                    '// รูปภาพ
                    picData.Image = .PhotoBitmap
                End With
                '// -------------------------------------------
                '//
            ElseIf (ID.ErrorCode() > 0) Then
                MessageBox.Show(ID.Error)
            Else
                MessageBox.Show("Catch All", "รายงานความผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        btnRead.Enabled = True
    End Sub

    '// Reading complete.
    Private Sub bgWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs)
        ProgressBar1.Visible = False
        'MessageBox.Show("Done Complete.", "Report Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Function CheckSex(ByVal sex As Byte, ByRef txt As TextBox) As String
        '// เก็บค่าตัวเลขไว้ใน Tag เผื่อไว้ตอนไปเก็บลงในฐานข้อมูล [กำหนดให้ ชาย=1 หญิง=2]
        txt.Tag = sex
        If sex = 1 Then
            CheckSex = "ชาย"
        Else
            CheckSex = "หญิง"
        End If
    End Function

    '// เคลียร์หน้าจอทั้งหมด
    Sub SetupScreen()
        '// หรือสั่งลูปเคลียร์ TextBox Control ทั้งหมดที่มีอยู่บนฟอร์ม
        For Each tb As TextBox In Me.GroupBox1.Controls.OfType(Of TextBox)()
            tb.Clear()
        Next
        picData.Image = Nothing
    End Sub

    Private Sub btnExit_Click(sender As System.Object, e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub frmSmartCard_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        GC.SuppressFinalize(Me)
        Application.Exit()
    End Sub

    ' / --------------------------------------------------------------------------------
    ' / ฟังค์ชั่นในการคำนวณหาความแตกต่างระหว่างวันเดือนปี (คำนวณหาอายุ)
    ' / คัดลอกโค้ดทั้งหมดมาจาก VB6
    Public Function CalcDate(sDate As Date, eDate As Date) As String
        Dim vDays As Integer
        Dim vMonths As Integer
        Dim vYears As Integer
        '/ Parameters:
        '/    sDate - ค่าวันเดือนปีเกิด (หรือวันเดือนปีที่ต้องการคำนวณหา)
        '/    eDate - คำนวณเทียบกับวันเดือนปีปัจจุบัน (Now())
        '/ Results:
        '/    vYears - เก็บค่าความแตกต่างของจำนวนปี
        '/    vMonths - เก็บค่าความแตกต่างของจำนวนเดือน
        '/    vDays - เก็บค่าความแตกต่างของจำนวนวัน

        '/ หาความแตกต่างของจำนวนเดือน
        vMonths = DateDiff("m", sDate, eDate)
        vDays = DateDiff("d", DateAdd("m", vMonths, sDate), eDate)
        If vDays < 0 Then
            vMonths = vMonths - 1
            vDays = DateDiff("d", DateAdd("m", vMonths, sDate), eDate)
        End If
        vYears = vMonths \ 12 ' หารตัดเศษก็จะได้จำนวนปี
        vMonths = vMonths Mod 12 ' การหารเอาเศษ โดยจะมีค่าระหว่าง 0, 1, 2, ... 11 ไม่มีทางเท่ากับ หรือ มากกว่า 12
        CalcDate = "อายุ: " & vYears & " ปี " & vMonths & " เดือน " & vDays & " วัน."
    End Function
End Class
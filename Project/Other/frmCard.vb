Imports ThaiNationalIDCard
Imports System.ComponentModel
Imports System.Globalization
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

        If Not bgWorker.IsBusy Then
            ProgressBar1.Style = ProgressBarStyle.Marquee
            ProgressBar1.Visible = True
            bgWorker.RunWorkerAsync()
        Else
            MessageBox.Show("Process is already running. Please wait for it to complete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub bgWorker_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs)
        Try
            '// ตรวจสอบการยกเลิก
            If bgWorker.CancellationPending Then
                e.Cancel = True
                Return
            End If

            '// โค้ดส่วนของการอ่านข้อมูลบัตรประชาชน
            Dim ID As New ThaiIDCard
            Dim Personal As Personal = ID.readAllPhoto
            If Not IsNothing(Personal) Then
                With Personal
                    txtIDCard.Text = .Citizenid
                    txtPreFixThai.Text = .Th_Prefix
                    txtPrefixEng.Text = .En_Prefix
                    txtFirstNameThai.Text = .Th_Firstname
                    txtLastNameThai.Text = .Th_Lastname
                    txtFirstNameEng.Text = .En_Firstname
                    txtLastNameEng.Text = .En_Lastname
                    Try
                        If Not String.IsNullOrWhiteSpace(.Birthday.ToString()) Then
                            Dim birthDateString As String = .Birthday.ToString()

                            ' แสดงข้อมูลวันเกิดดิบ (Raw) จากบัตร เพื่อดูรูปแบบที่แท้จริง
                            MessageBox.Show("Raw birthday data: " & birthDateString)

                            ' เพิ่มรูปแบบวันที่ใหม่สำหรับการตรวจสอบ
                            Dim formats() As String = {"d MMM yyyy", "d MMMM yyyy", "dd/MM/yyyy", "dd-MM-yyyy", "yyyy-MM-dd", "yyyy/MM/dd", "yyyyMMdd", "dd MMM yyyy h:mm:ss tt"}

                            Dim birthDate As DateTime
                            ' ตรวจสอบหลายรูปแบบของวันที่ และลองแปลง
                            If DateTime.TryParseExact(birthDateString, formats, New System.Globalization.CultureInfo("th-TH"), DateTimeStyles.None, birthDate) Then
                                ' ถ้าเป็นปีพุทธศักราช ให้ลบ 543
                                If birthDate.Year > 2500 Then
                                    birthDate = birthDate.AddYears(-543)
                                End If
                                txtBirthDate.Text = birthDate.ToString("dd/MM/yyyy")
                            Else
                                MessageBox.Show("Birthday format is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        Else
                            txtBirthDate.Text = "N/A"
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Invalid date format. Please check the date format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try


                    '// คำนวณอายุ
                    If Not String.IsNullOrWhiteSpace(txtBirthDate.Text) AndAlso txtBirthDate.Text <> "N/A" Then
                        lblAge.Text = CalcDate(Convert.ToDateTime(txtBirthDate.Text), Now())
                    End If

                    '// 1 = ชาย, 2 = หญิง
                    txtSex.Text = CheckSex(.Sex, txtSex).ToString

                    ' แก้ไขปีพุทธศักราชเป็นคริสต์ศักราชในวันออกบัตรและวันหมดอายุ
                    Try
                        If Not String.IsNullOrWhiteSpace(.Issue.ToString()) Then
                            ' ใช้ DateTime แปลงวันที่เป็น string ก่อนทำการแยก
                            Dim issueDate As DateTime = .Issue
                            txtIssueDate.Text = issueDate.ToString("dd/MM/yyyy")
                        Else
                            txtIssueDate.Text = "N/A"
                        End If

                        If Not String.IsNullOrWhiteSpace(.Expire.ToString()) Then
                            ' ใช้ DateTime แปลงวันที่เป็น string ก่อนทำการแยก
                            Dim expireDate As DateTime = .Expire
                            txtExpireDate.Text = expireDate.ToString("dd/MM/yyyy")
                        Else
                            txtExpireDate.Text = "N/A"
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Invalid issue or expire date format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

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


    Private Sub bgWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs)
        ProgressBar1.Visible = False
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnExit.Click
        If bgWorker.IsBusy Then
            bgWorker.CancelAsync()
        End If
    End Sub

    Function CheckSex(ByVal sex As Byte, ByRef txt As TextBox) As String
        txt.Tag = sex
        If sex = 1 Then
            Return "ชาย"
        Else
            Return "หญิง"
        End If
    End Function

    Sub SetupScreen()
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
    End Sub

    ' / คำนวณหาอายุ
    Public Function CalcDate(sDate As Date, eDate As Date) As String
        Dim vDays As Integer
        Dim vMonths As Integer
        Dim vYears As Integer

        vMonths = DateDiff("m", sDate, eDate)
        vDays = DateDiff("d", DateAdd("m", vMonths, sDate), eDate)
        If vDays < 0 Then
            vMonths = vMonths - 1
            vDays = DateDiff("d", DateAdd("m", vMonths, sDate), eDate)
        End If
        vYears = vMonths \ 12
        vMonths = vMonths Mod 12
        Return "อายุ: " & vYears & " ปี " & vMonths & " เดือน " & vDays & " วัน."
    End Function
End Class

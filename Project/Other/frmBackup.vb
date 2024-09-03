Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class frmBackup
    Private Sub btnBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackup.Click
        Dim ThisDB As String = Application.StartupPath & "\db_banmai1.accdb" ' เปลี่ยนเป็น .accdb
        Dim BackupFolderPath As String = Application.StartupPath & "\Backups\"

        Try
            ' สร้างโฟลเดอร์สำหรับเก็บไฟล์ Backup หากยังไม่มี
            If Not Directory.Exists(BackupFolderPath) Then
                Directory.CreateDirectory(BackupFolderPath)
            End If

            ' สร้างชื่อไฟล์ Backup พร้อมกับ Timestamp
            Dim BackupFileName As String = BackupFolderPath & DateTime.Now.ToString("yyyy-MM-dd_HHmmss") & ".accdb" ' เปลี่ยนเป็น .accdb

            ' ตรวจสอบว่าไฟล์กำลังถูกใช้งานอยู่หรือไม่
            If IsFileInUse(ThisDB) Then
                MessageBox.Show("ไฟล์ฐานข้อมูลกำลังถูกใช้งานอยู่ กรุณาปิดไฟล์แล้วลองใหม่อีกครั้ง", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' ตั้งค่า ProgressBar
            ProgressBar1.Visible = True
            ProgressBar1.Minimum = 0
            ProgressBar1.Maximum = 100
            ProgressBar1.Value = 0

            ' ทำการสำรองข้อมูล
            File.Copy(ThisDB, BackupFileName, True)

            ' อัปเดต ProgressBar เป็น 100% เมื่อสำรองข้อมูลเสร็จสิ้น
            ProgressBar1.Value = 100

            MessageBox.Show("สำเร็จ!", "การสำรองข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการสำรองข้อมูล: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ProgressBar1.Visible = False
        End Try
    End Sub

    Private Function IsFileInUse(filePath As String) As Boolean
        Try
            Using fs As New FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None)
                fs.Close()
            End Using
            Return False
        Catch ex As IOException
            Return True
        End Try
    End Function

    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs) Handles ProgressBar1.Click
        ' ไม่มีการดำเนินการในที่นี้ แต่คุณสามารถใช้ ProgressBar ในการอัปเดตสถานะได้
    End Sub
End Class

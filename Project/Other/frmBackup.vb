Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class frmBackup
    Private Sub btnBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackup.Click
        Dim ThisDB As String = Application.StartupPath & "\db_banmai1.accdb" ' เปลี่ยนเป็น .accdb
        Dim BackupFolderPath As String = String.Empty

        ' ใช้ FolderBrowserDialog ให้ผู้ใช้เลือกโฟลเดอร์
        Using folderDialog As New FolderBrowserDialog()
            folderDialog.Description = "เลือกโฟลเดอร์ที่จะเก็บไฟล์สำรองข้อมูล"
            folderDialog.RootFolder = Environment.SpecialFolder.MyComputer
            folderDialog.ShowNewFolderButton = True

            If folderDialog.ShowDialog() = DialogResult.OK Then
                BackupFolderPath = folderDialog.SelectedPath
            Else
                ' หากผู้ใช้กดยกเลิก ให้หยุดการทำงาน
                MessageBox.Show("การสำรองข้อมูลถูกยกเลิก", "ยกเลิก", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
        End Using

        Try
            ' สร้างชื่อไฟล์ Backup พร้อมกับ Timestamp
            Dim BackupFileName As String = Path.Combine(BackupFolderPath, DateTime.Now.ToString("yyyy-MM-dd_HHmmss") & ".accdb")

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

            MessageBox.Show("สำเร็จ! ข้อมูลถูกสำรองไว้ที่: " & BackupFileName, "การสำรองข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

End Class

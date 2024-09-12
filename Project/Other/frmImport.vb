Imports System.IO

Public Class frmImport
    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Dim RestoreLocation As String = Application.StartupPath & "\db_banmai1.accdb"

        Dim OFD As New OpenFileDialog
        OFD.Filter = "Access Files|*.accdb"

        ' ตรวจสอบว่าผู้ใช้เลือกไฟล์หรือไม่
        If OFD.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Try
                Dim PickedFile As String = OFD.FileName

                ' ตรวจสอบว่าปลายทางไม่ถูกใช้งาน
                If IsFileInUse(RestoreLocation) Then
                    MessageBox.Show("ไฟล์ฐานข้อมูลปลายทางกำลังถูกใช้งานอยู่ กรุณาปิดไฟล์แล้วลองใหม่อีกครั้ง")
                    Return
                End If

                ' สำรองไฟล์ปลายทางถ้ามีอยู่แล้ว
                If File.Exists(RestoreLocation) Then
                    File.Copy(RestoreLocation, RestoreLocation & ".bak", True)
                End If

                ' คัดลอกไฟล์ที่เลือกไปยังปลายทาง
                File.Copy(PickedFile, RestoreLocation, True)
                MessageBox.Show("เรียกคืนข้อมูลเรียบร้อยแล้ว!")
            Catch ex As Exception
                MessageBox.Show("เกิดข้อผิดพลาดในการเรียกคืนข้อมูล: " & ex.Message)
            End Try
        End If
    End Sub

    ' ฟังก์ชันตรวจสอบว่าไฟล์กำลังถูกใช้งานอยู่หรือไม่
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

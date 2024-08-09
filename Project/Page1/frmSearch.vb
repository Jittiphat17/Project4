Imports System.Data.OleDb
Imports Microsoft.Reporting.WinForms

Public Class frmSearch
    Private Conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\db_test.mdb")

    Private Sub frmSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' เพิ่มตัวเลือกสำหรับประเภทของรายงาน
        cbReportType.Items.Add("รายงานสัญญากู้เงิน")
        cbReportType.Items.Add("รายงานสัญญาอื่นๆ")
        cbReportType.SelectedIndex = 0 ' ตั้งค่าเริ่มต้น
        LoadAllContracts()
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub FormatDataGridView()
        ' ตั้งค่าการแสดงจำนวนเงินด้วยเครื่องหมายคั่นหลักพัน
        dgvResults.Columns("con_amount").DefaultCellStyle.Format = "N0"
        ' ตั้งค่าการจัดชิดด้านขวา
        dgvResults.Columns("con_amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvResults.Columns("con_interest").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvResults.Columns("con_permonth").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If String.IsNullOrWhiteSpace(txtSearch.Text) Then
            LoadAllContracts()
        Else
            SearchContracts(txtSearch.Text)
        End If
    End Sub

    Private Sub LoadAllContracts()
        Try
            Using conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\db_test.mdb")
                conn.Open()
                Dim query As String = "SELECT con_id, m_id, con_details, con_amount, con_interest, con_permonth, con_date, acc_id FROM Contract"
                Dim cmd As New OleDbCommand(query, conn)
                Dim adapter As New OleDbDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)
                dgvResults.DataSource = table
                ' เรียกใช้ฟังก์ชันการจัดรูปแบบ DataGridView
                FormatDataGridView()
            End Using
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการเชื่อมต่อฐานข้อมูล: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SearchContracts(keyword As String)
        Try
            Using conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\db_test.mdb")
                conn.Open()
                Dim query As String = "SELECT con_id, m_id, con_details, con_amount, con_interest, con_permonth, con_date, acc_id FROM Contract WHERE con_id LIKE @keyword OR m_id IN (SELECT m_id FROM Member WHERE m_name LIKE @keyword)"
                Dim cmd As New OleDbCommand(query, conn)
                cmd.Parameters.AddWithValue("@keyword", "%" & keyword & "%")
                Dim adapter As New OleDbDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)
                dgvResults.DataSource = table
            End Using
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการเชื่อมต่อฐานข้อมูล: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function ConvertNumberToText(ByVal num As Decimal) As String
        Dim bahtText As String = ""
        Dim numParts() As String = Split(num.ToString("F2"), ".")
        Dim bahtPart As Long = CLng(numParts(0))
        Dim satangPart As Integer = CInt(numParts(1))

        Dim bahtWords As String = ConvertPartToText(bahtPart)
        Dim satangWords As String = ConvertPartToText(satangPart)

        If bahtWords <> "" Then
            bahtText &= bahtWords & "บาท"
        End If

        If satangWords <> "" Then
            bahtText &= satangWords & "สตางค์"
        Else
            bahtText &= "ถ้วน"
        End If

        Return bahtText
    End Function

    Private Function ConvertPartToText(ByVal num As Long) As String
        Dim text As String = ""
        Dim units() As String = {"", "สิบ", "ร้อย", "พัน", "หมื่น", "แสน", "ล้าน"}
        Dim nums() As String = {"", "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า"}

        Dim digit As Integer
        Dim pos As Integer = 0

        While num > 0
            digit = num Mod 10
            If digit > 0 Then
                text = nums(digit) & units(pos) & text
            End If
            num = num \ 10
            pos += 1
        End While

        text = text.Replace("หนึ่งสิบ", "สิบ")
        text = text.Replace("สองสิบ", "ยี่สิบ")
        If text.Length > 1 Then
            text = text.Substring(0, 1) & text.Substring(1).Replace("หนึ่ง", "เอ็ด")
        End If

        Return text
    End Function

    Private Function ConvertToThaiDateString(ByVal dateValue As Date) As String
        Dim thaiMonths As String() = {"มกราคม", "กุมภาพันธ์", "มีนาคม", "เมษายน", "พฤษภาคม", "มิถุนายน", "กรกฎาคม", "สิงหาคม", "กันยายน", "ตุลาคม", "พฤศจิกายน", "ธันวาคม"}
        Dim day As Integer = dateValue.Day
        Dim month As Integer = dateValue.Month
        Dim year As Integer = dateValue.Year + 543 ' เพิ่ม 543 เพื่อแปลงเป็นปีพุทธศักราช (พ.ศ.)

        Return String.Format("{0} {1} พ.ศ. {2}", day, thaiMonths(month - 1), year)
    End Function

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        If dgvResults.SelectedRows.Count = 0 Then
            MessageBox.Show("กรุณาเลือกสัญญาที่ต้องการสร้างรายงาน", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedConId As String = dgvResults.SelectedRows(0).Cells("con_id").Value.ToString()
        Dim selectedMemberId As String = dgvResults.SelectedRows(0).Cells("m_id").Value.ToString()
        Dim selectedAccId As String = dgvResults.SelectedRows(0).Cells("acc_id").Value.ToString()

        Try
            Using conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\db_test.mdb")
                conn.Open()

                ' ดึงข้อมูลสำหรับ DataSet1 จากตาราง Contract
                Dim query1 As String = "SELECT con_id, m_id, con_details, con_amount, con_interest, con_permonth, con_date, acc_id FROM Contract WHERE con_id = @con_id"
                Dim cmd1 As New OleDbCommand(query1, conn)
                cmd1.Parameters.AddWithValue("@con_id", selectedConId)
                Dim adapter1 As New OleDbDataAdapter(cmd1)
                Dim table1 As New DataTable()
                adapter1.Fill(table1)

                ' ดึงข้อมูลสำหรับ DataSet2 จากตาราง Member
                Dim query2 As String = "SELECT m_id, m_gender,m_national, m_thaiid, m_name, m_address, m_tel FROM Member WHERE m_id = @m_id"
                Dim cmd2 As New OleDbCommand(query2, conn)
                cmd2.Parameters.AddWithValue("@m_id", selectedMemberId)
                Dim adapter2 As New OleDbDataAdapter(cmd2)
                Dim table2 As New DataTable()
                adapter2.Fill(table2)

                ' ดึงข้อมูลสำหรับ DataSet3 จากตาราง Account
                Dim query3 As String = "SELECT acc_id, acc_name FROM Account WHERE acc_id = @acc_id"
                Dim cmd3 As New OleDbCommand(query3, conn)
                cmd3.Parameters.AddWithValue("@acc_id", selectedAccId)
                Dim adapter3 As New OleDbDataAdapter(cmd3)
                Dim table3 As New DataTable()
                adapter3.Fill(table3)

                ' ดึงข้อมูลสำหรับ DataSet4 จากตาราง Payment
                Dim query4 As String = "SELECT payment_id, con_id, payment_date, payment_amount FROM Payment WHERE con_id = @con_id ORDER BY payment_date ASC"
                Dim cmd4 As New OleDbCommand(query4, conn)
                cmd4.Parameters.AddWithValue("@con_id", selectedConId)
                Dim adapter4 As New OleDbDataAdapter(cmd4)
                Dim table4 As New DataTable()
                adapter4.Fill(table4)

                ' หาและแสดงวันที่ชำระเงินที่เร็วที่สุดและช้าที่สุด
                Dim firstPaymentDate As Date = Date.MinValue
                Dim lastPaymentDate As Date = Date.MinValue

                If table4.Rows.Count > 0 Then
                    firstPaymentDate = Convert.ToDateTime(table4.Rows(0)("payment_date"))
                    lastPaymentDate = Convert.ToDateTime(table4.Rows(table4.Rows.Count - 1)("payment_date"))
                Else
                    firstPaymentDate = Date.MinValue 'หรือกำหนดข้อความอื่นๆ
                    lastPaymentDate = Date.MinValue 'หรือกำหนดข้อความอื่นๆ
                End If

                ' ชื่อ DataSource ต้องตรงกับชื่อในรายงาน
                Dim rds1 As New ReportDataSource("DataSet1", table1)
                Dim rds2 As New ReportDataSource("DataSet2", table2)
                Dim rds3 As New ReportDataSource("DataSet3", table3)
                Dim rds4 As New ReportDataSource("DataSet4", table4)
                Me.ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(rds1)
                Me.ReportViewer1.LocalReport.DataSources.Add(rds2)
                Me.ReportViewer1.LocalReport.DataSources.Add(rds3)
                Me.ReportViewer1.LocalReport.DataSources.Add(rds4)

                ' ส่งข้อมูลจำนวนเงินเป็นคำอ่านไปยังรายงาน
                Dim amountText As String = ConvertNumberToText(Convert.ToDecimal(table1.Rows(0)("con_amount")))
                Dim amountWithCommas As String = Convert.ToDecimal(table1.Rows(0)("con_amount")).ToString("N0")

                Me.ReportViewer1.LocalReport.SetParameters(New ReportParameter("AmountText", amountText))
                Me.ReportViewer1.LocalReport.SetParameters(New ReportParameter("AmountWithCommas", amountWithCommas))

                ' ส่งข้อมูลวันที่ชำระเงินแรกและสุดท้ายไปยังรายงาน
                Dim firstPaymentDateThai As String = ConvertToThaiDateString(firstPaymentDate)
                Dim lastPaymentDateThai As String = ConvertToThaiDateString(lastPaymentDate)
                Me.ReportViewer1.LocalReport.SetParameters(New ReportParameter("FirstPaymentDate", firstPaymentDateThai))
                Me.ReportViewer1.LocalReport.SetParameters(New ReportParameter("LastPaymentDate", lastPaymentDateThai))

                ' ตั้งค่าพารามิเตอร์สำหรับแต่ละหน้า
                Dim page1Content As String = "เนื้อหาสำหรับหน้าแรก"
                Dim page2Content As String = "เนื้อหาสำหรับหน้าสอง"
                Dim page3Content As String = "เนื้อหาสำหรับหน้าสาม"


                ' เลือกรายงานตามที่ผู้ใช้เลือก
                Dim reportPath As String
                Select Case cbReportType.SelectedItem.ToString()
                    Case "รายงานสัญญากู้เงิน"
                        reportPath = "D:\Project-2022\Project\Project\report\LoanReport1.rdlc"
                    Case "รายงานสัญญาอื่นๆ"
                        reportPath = "D:\Project-2022\Project\Project\report\OtherLoanReport1.rdlc"
                    Case Else
                        MessageBox.Show("ไม่พบรายงานที่ต้องการ", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                End Select

                Me.ReportViewer1.LocalReport.ReportPath = reportPath ' กำหนดเส้นทางของรายงาน
                Me.ReportViewer1.RefreshReport()
            End Using
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการสร้างรายงาน: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

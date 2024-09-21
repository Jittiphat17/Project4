Imports System.Data.OleDb
Imports Microsoft.Reporting.WinForms

Public Class frmInter

    Private ConnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb"

    ' ฟังก์ชันสำหรับโหลดข้อมูลจากตาราง Income และ Income_Details และแสดงใน ReportViewer
    Private Sub LoadData()
        Try
            Using conn As New OleDbConnection(ConnString)
                conn.Open()

                ' DataSet 1: ดึงข้อมูลจากตาราง Income พร้อมชื่อสมาชิก สำหรับทุกเดือน
                Dim queryIncome As String = "SELECT i.inc_id, i.m_id, m.m_name, i.inc_detail, i.inc_description, i.inc_date, i.inc_amount, i.acc_id " &
                                            "FROM Income i " &
                                            "INNER JOIN Member m ON i.m_id = m.m_id " &
                                            "ORDER BY i.inc_date"
                Dim cmdIncome As New OleDbCommand(queryIncome, conn)
                Dim adapterIncome As New OleDbDataAdapter(cmdIncome)
                Dim tableIncome As New DataTable()
                adapterIncome.Fill(tableIncome)

                ' DataSet 2: ดึงข้อมูลจากตาราง Income_Details พร้อมชื่อสมาชิก สำหรับทุกเดือน
                Dim queryIncomeDetails As String = "SELECT id.ind_id, id.inc_id, id.ind_accname, id.ind_amount, id.m_id, m.m_name, i.inc_date " &
                                                   "FROM (Income_Details id " &
                                                   "INNER JOIN Income i ON id.inc_id = i.inc_id) " &
                                                   "INNER JOIN Member m ON id.m_id = m.m_id " &
                                                   "WHERE id.ind_accname = 'เงินฝากสัจจะ' " &
                                                   "ORDER BY i.inc_date"
                Dim cmdIncomeDetails As New OleDbCommand(queryIncomeDetails, conn)
                Dim adapterIncomeDetails As New OleDbDataAdapter(cmdIncomeDetails)
                Dim tableIncomeDetails As New DataTable()
                adapterIncomeDetails.Fill(tableIncomeDetails)

                ' ตรวจสอบข้อมูลใน DataTable
                If tableIncome.Rows.Count = 0 Or tableIncomeDetails.Rows.Count = 0 Then
                    MessageBox.Show("ไม่มีข้อมูลสำหรับแสดงในรายงาน", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                ' สร้าง ReportDataSource สำหรับ DataSet 1 (Income)
                Dim rdsIncome As New ReportDataSource("IncomeDataSet", tableIncome)

                ' สร้าง ReportDataSource สำหรับ DataSet 2 (Income_Details)
                Dim rdsIncomeDetails As New ReportDataSource("IncomeDetailsDataSet", tableIncomeDetails)

                If rdsIncome IsNot Nothing AndAlso rdsIncomeDetails IsNot Nothing Then
                    Me.ReportViewer1.LocalReport.DataSources.Clear()
                    Me.ReportViewer1.LocalReport.DataSources.Add(rdsIncome)
                    Me.ReportViewer1.LocalReport.DataSources.Add(rdsIncomeDetails)

                    ' กำหนด Report Path
                    Me.ReportViewer1.LocalReport.ReportPath = "D:\Project-2022\Project\Project\report\IncomeReport.rdlc"

                    ' กำหนดค่า Parameter สำหรับดอกเบี้ยสัจจะ
                    Dim interestRate As New ReportParameter("InterestRate", 0.03D)
                    Me.ReportViewer1.LocalReport.SetParameters(interestRate)

                    ' Refresh รายงาน
                    Me.ReportViewer1.RefreshReport()
                Else
                    MessageBox.Show("ไม่สามารถตั้งค่า DataSource ได้", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            End Using
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการโหลดข้อมูลรายได้: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' เหตุการณ์เมื่อกดปุ่มแสดงรายงาน
    Private Sub btnViewReport_Click(sender As Object, e As EventArgs) Handles btnViewReport.Click
        LoadData()
    End Sub

    ' ฟังก์ชันเมื่อโหลดฟอร์ม
    Private Sub frmInter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ไม่จำเป็นต้องมีการตั้งค่า ComboBox อีกต่อไป
        ' เราสามารถเรียกใช้ LoadData() ทันทีถ้าต้องการแสดงรายงานตั้งแต่เริ่มต้น
        ' LoadData()
    End Sub

End Class
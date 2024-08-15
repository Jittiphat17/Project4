Imports Microsoft.Reporting.WinForms

Public Class frmGuarantorReport
    Public Property ReportData1 As DataTable

    Private Sub frmReportViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ตั้งค่า ReportViewer
        ReportViewerGuarantor.LocalReport.ReportPath = "D:\Project-2022\Project\Project\report\LoanReport1.rdlc" ' เพิ่มหาไปยังไฟล์ .rdlc ของคุณ
        ReportViewerGuarantor.LocalReport.DataSources.Clear()

        ' เพิ่ม DataSource สำหรับ DataSet1
        Dim reportDataSource1 As New ReportDataSource("DataSet1", ReportData1)
        ReportViewerGuarantor.LocalReport.DataSources.Add(reportDataSource1)

        ' สร้างรายการพารามิเตอร์รายงาน
        Dim reportParameters As New List(Of ReportParameter)()
        reportParameters.Add(New ReportParameter("ReportTitle", "รายงานข้อมูลการกู้ยืม"))

        ' ตั้งค่าพารามิเตอร์รายงาน
        ReportViewerGuarantor.LocalReport.SetParameters(reportParameters)

        ' แสดงรายงานใน ReportViewer
        ReportViewerGuarantor.RefreshReport()
    End Sub
End Class

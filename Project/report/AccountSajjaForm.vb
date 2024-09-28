Imports System.Data.OleDb
Imports Microsoft.Reporting.WinForms

Public Class AccountSajjaForm

    ' สร้างการเชื่อมต่อฐานข้อมูล Access
    Dim connection As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")

    Private Sub AccountSajjaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' โหลดข้อมูลเมื่อฟอร์มเปิด
        LoadData()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Private Sub LoadData(Optional ByVal filter As String = "")
        ' SQL Query ที่รวมข้อมูลจากตาราง Income, Income_Details และ Member ใน Access
        Dim query As String = "SELECT m.[m_id], m.[m_name], " &
                          "FORMAT(i.[inc_date], 'yyyy-MM') AS [DepositMonth], " &
                          "Nz(SUM(id.[ind_amount]), 0) AS [TotalDeposit], " &
                          "Nz(SUM(id.[ind_amount]) * 0.03 / 12, 0) AS [Interest] " &
                          "FROM [Member] m " &
                          "LEFT JOIN ([Income] i " &
                          "LEFT JOIN [Income_Details] id ON i.[inc_id] = id.[inc_id] " &
                          "AND id.[ind_accname] = 'เงินฝากสัจจะ') " &
                          "ON m.[m_id] = i.[m_id] " &
                          "GROUP BY m.[m_id], m.[m_name], FORMAT(i.[inc_date], 'yyyy-MM') " &
                          "ORDER BY m.[m_name], FORMAT(i.[inc_date], 'yyyy-MM')"

        Dim command As New OleDbCommand(query, connection)
        Dim adapter As New OleDbDataAdapter(command)
        Dim dt As New DataTable()

        connection.Open()
        adapter.Fill(dt)
        connection.Close()

        ' แสดงข้อมูลใน ReportViewer
        ShowReport(dt)
    End Sub

    Private Sub ShowReport(ByVal dt As DataTable)
        ' ตั้งค่า ReportViewer เพื่อแสดงรายงาน
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = "D:\Project-2022\Project\Project\report\Income.rdlc"

        ' สร้าง ReportDataSource และตั้งค่าให้กับ ReportViewer
        Dim rds As New ReportDataSource("SajjaDataSet", dt)
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(rds)

        ' กำหนดค่า Parameter
        Dim interestRateParam As New ReportParameter("InterestRate", "0.03") ' อัตราดอกเบี้ย 3%
        ReportViewer1.LocalReport.SetParameters(interestRateParam)

        ' Refresh รายงาน
        ReportViewer1.RefreshReport()
    End Sub

    Private Sub btnShowAll_Click(sender As Object, e As EventArgs) Handles btnShowAll.Click
        ' แสดงข้อมูลทั้งหมดที่มี ind_accname = 'เงินฝากสัจจะ'
        LoadData()
    End Sub

End Class

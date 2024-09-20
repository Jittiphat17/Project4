Imports System.Data.OleDb
Imports Microsoft.Reporting.WinForms

Public Class frmInter

    Private ConnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb"

    ' ฟังก์ชันสำหรับโหลดข้อมูลจากตาราง Income และ Income_Details และแสดงใน ReportViewer
    Private Sub LoadData()
        Try
            Using conn As New OleDbConnection(ConnString)
                conn.Open()

                ' กำหนดค่าที่ต้องการใช้กรองจาก ComboBox1
                Dim selectedMonth As Integer = ComboBox1.SelectedValue

                ' DataSet 1: ดึงข้อมูลจากตาราง Income พร้อมชื่อสมาชิก ที่ตรงกับเดือนที่เลือก
                Dim queryIncome As String = "SELECT i.inc_id, i.m_id, m.m_name, i.inc_detail, i.inc_description, i.inc_date, i.inc_amount, i.acc_id " &
                                            "FROM Income i " &
                                            "INNER JOIN Member m ON i.m_id = m.m_id " &
                                            "WHERE MONTH(i.inc_date) = @Month"
                Dim cmdIncome As New OleDbCommand(queryIncome, conn)
                cmdIncome.Parameters.AddWithValue("@Month", selectedMonth)
                Dim adapterIncome As New OleDbDataAdapter(cmdIncome)
                Dim tableIncome As New DataTable()
                adapterIncome.Fill(tableIncome)

                ' DataSet 2: ดึงข้อมูลจากตาราง Income_Details พร้อมชื่อสมาชิก ที่ตรงกับเดือนที่เลือก
                Dim queryIncomeDetails As String = "SELECT id.ind_id, id.inc_id, id.ind_accname, id.ind_amount, id.m_id, m.m_name " &
                                                   "FROM (Income_Details id " &
                                                   "INNER JOIN Income i ON id.inc_id = i.inc_id) " &
                                                   "INNER JOIN Member m ON id.m_id = m.m_id " &
                                                   "WHERE id.ind_accname = 'เงินฝากสัจจะ' AND MONTH(i.inc_date) = @Month"
                Dim cmdIncomeDetails As New OleDbCommand(queryIncomeDetails, conn)
                cmdIncomeDetails.Parameters.AddWithValue("@Month", selectedMonth)
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

    ' ฟังก์ชันสำหรับเติมข้อมูลใน ComboBox สำหรับการเลือกเดือน
    Private Sub frmInter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' เติมชื่อเดือนใน ComboBox
        Dim months As New List(Of Object)
        For i As Integer = 1 To 12
            months.Add(New With {
                .Value = i,
                .Text = New DateTime(2000, i, 1).ToString("MMMM")
            })
        Next
        ComboBox1.DataSource = months
        ComboBox1.DisplayMember = "Text"
        ComboBox1.ValueMember = "Value"
        ComboBox1.SelectedIndex = DateTime.Now.Month - 1  ' ตั้งค่าให้เลือกเดือนปัจจุบันเป็นค่าเริ่มต้น
    End Sub

End Class

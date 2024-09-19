Imports System.Data.OleDb
Imports Microsoft.Reporting.WinForms

Public Class frmInterestReport
    ' เชื่อมต่อกับฐานข้อมูล Access
    Private ConnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb"

    Private Sub frmInterestReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadMonths()
        LoadYears()
        SetDefaultSelections()
        SetReportPath()
    End Sub

    Private Sub LoadMonths()
        For i As Integer = 1 To 12
            cbMonth.Items.Add(New With {
                .Value = i,
                .Display = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i)
            })
        Next

        cbMonth.DisplayMember = "Display"
        cbMonth.ValueMember = "Value"
    End Sub

    Private Sub LoadYears()
        Dim currentYear As Integer = DateTime.Now.Year
        For i As Integer = currentYear To currentYear - 10 Step -1
            cbYear.Items.Add(i)
        Next
    End Sub

    Private Sub SetDefaultSelections()
        cbMonth.SelectedIndex = DateTime.Now.Month - 1
        cbYear.SelectedItem = DateTime.Now.Year
    End Sub

    Private Sub SetReportPath()
        Me.ReportViewer1.LocalReport.ReportPath = "D:\Project-2022\Project\Project\report\ReportInterest.rdlc"
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub LoadReportData()
        Dim dtMember As New DataTable() ' DataTable สำหรับ Member
        Dim dtIncome As New DataTable() ' DataTable สำหรับ Income_Details

        ' ตรวจสอบ ComboBox
        If cbMonth.SelectedItem Is Nothing Or cbYear.SelectedItem Is Nothing Then
            MessageBox.Show("กรุณาเลือกเดือนและปี")
            Return
        End If

        Dim selectedMonth = DirectCast(cbMonth.SelectedItem, Object).Value
        Dim selectedYear = cbYear.SelectedItem

        Try
            Using conn As New OleDbConnection(ConnString)
                conn.Open()

                ' คำสั่ง SQL สำหรับ Member
                Dim queryMember As String = "SELECT m_id, m_name FROM Member"
                Using cmdMember As New OleDbCommand(queryMember, conn)
                    Using daMember As New OleDbDataAdapter(cmdMember)
                        daMember.Fill(dtMember)
                    End Using
                End Using

                ' คำสั่ง SQL สำหรับ Income_Details โดยเชื่อมกับ Income เพื่อเข้าถึง inc_date
                Dim queryIncome As String = "SELECT id.m_id, SUM(id.ind_amount) AS TotalDeposit " &
                                             "FROM Income_Details AS id " &
                                             "INNER JOIN Income AS i ON id.inc_id = i.inc_id " &
                                             "WHERE id.ind_accname = 'เงินฝากสัจจะ' AND MONTH(i.inc_date) = @Month AND YEAR(i.inc_date) = @Year " &
                                             "GROUP BY id.m_id"
                Using cmdIncome As New OleDbCommand(queryIncome, conn)
                    cmdIncome.Parameters.AddWithValue("@Month", selectedMonth)
                    cmdIncome.Parameters.AddWithValue("@Year", selectedYear)

                    Using daIncome As New OleDbDataAdapter(cmdIncome)
                        daIncome.Fill(dtIncome)
                    End Using
                End Using
            End Using

            ' ตรวจสอบว่ามีข้อมูลใน DataSet
            If dtMember.Rows.Count > 0 And dtIncome.Rows.Count > 0 Then
                SetReportData(dtMember, dtIncome) ' ส่ง DataTable ทั้งสองไปยังฟังก์ชัน
            Else
                MessageBox.Show("ไม่พบข้อมูลใน Member หรือ Income_Details.")
            End If
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการโหลดข้อมูล: " & ex.Message)
        End Try
    End Sub

    Private Sub SetReportData(dtMember As DataTable, dtIncome As DataTable)
        ' ตั้งค่า DataSource สำหรับ DataSet (Member)
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("MemberDataSet", dtMember)) ' Member

        ' ตั้งค่า DataSource สำหรับ DataSet (Income_Details)
        ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("IncomeDataSet", dtIncome)) ' Income_Details

        ' รีเฟรชรายงาน
        ReportViewer1.RefreshReport()
    End Sub

    Private Sub btnLoadReport_Click(sender As Object, e As EventArgs) Handles btnLoadReport.Click
        LoadReportData()
    End Sub
End Class

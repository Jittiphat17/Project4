Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb

Public Class frmSajja
    Private Sub frmSajja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' เพิ่มรายการเดือนใน ComboBox
        ComboBox1.Items.Add("January")
        ComboBox1.Items.Add("February")
        ComboBox1.Items.Add("March")
        ComboBox1.Items.Add("April")
        ComboBox1.Items.Add("May")
        ComboBox1.Items.Add("June")
        ComboBox1.Items.Add("July")
        ComboBox1.Items.Add("August")
        ComboBox1.Items.Add("September")
        ComboBox1.Items.Add("October")
        ComboBox1.Items.Add("November")
        ComboBox1.Items.Add("December")

        ' ตั้งค่าเดือนเริ่มต้นเป็นเดือนปัจจุบัน
        ComboBox1.SelectedIndex = DateTime.Now.Month - 1

        ' โหลดข้อมูลรายงานสำหรับเดือนที่เลือก
        LoadReportData(ComboBox1.SelectedIndex + 1)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' เรียกใช้ฟังก์ชันเพื่อกรองข้อมูลตามเดือนที่เลือก
        LoadReportData(ComboBox1.SelectedIndex + 1)
    End Sub

    Private Sub LoadReportData(selectedMonth As Integer)
        ' การเชื่อมต่อกับฐานข้อมูล
        Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb"
        Dim conn As New OleDbConnection(connString)

        ' สร้าง DataSet แรกสำหรับข้อมูลสมาชิก
        Dim query1 As String = "SELECT m_id, m_name, m_address, m_tel FROM Member"
        Dim adapter1 As New OleDbDataAdapter(query1, conn)
        Dim ds1 As New DataSet()

        ' สร้าง DataSet ที่สองสำหรับข้อมูลเงินฝากสัจจะเฉพาะเดือนที่เลือก
        Dim query2 As String = "SELECT d.m_id, SUM(d.ind_amount) AS ind_amount " &
                               "FROM Income_Details d " &
                               "INNER JOIN Income i ON d.m_id = i.m_id " &
                               "WHERE d.ind_accname = 'เงินฝากสัจจะ' AND MONTH(d.ind_date) = @Month " &
                               "GROUP BY d.m_id"
        Dim adapter2 As New OleDbDataAdapter(query2, conn)
        Dim ds2 As New DataSet()

        ' ปรับปรุง queryPrev เพื่อรวม ind_date ด้วย
        Dim queryPrev As String = "SELECT d.m_id, SUM(d.ind_amount) AS carry_forward_amount, MAX(d.ind_date) AS ind_date " &
                                  "FROM Income_Details d " &
                                  "INNER JOIN Income i ON d.m_id = i.m_id " &
                                  "WHERE d.ind_accname = 'เงินฝากสัจจะ' AND MONTH(d.ind_date) < @Month AND YEAR(d.ind_date) = @Year " &
                                  "GROUP BY d.m_id"
        Dim adapterPrev As New OleDbDataAdapter(queryPrev, conn)
        Dim dsPrev As New DataSet()

        ' ตั้งค่าเดือนและปีที่ต้องการกรอง
        adapter2.SelectCommand.Parameters.AddWithValue("@Month", selectedMonth)
        adapterPrev.SelectCommand.Parameters.AddWithValue("@Month", selectedMonth)
        adapterPrev.SelectCommand.Parameters.AddWithValue("@Year", DateTime.Now.Year)

        Try
            conn.Open()
            ' เติมข้อมูลให้กับ DataSets ทั้งสาม
            adapter1.Fill(ds1, "MemberDataSet")
            adapter2.Fill(ds2, "IncomeDataSet")
            adapterPrev.Fill(dsPrev, "CarryForwardDataSet")
            conn.Close()

            ' ตรวจสอบและปรับปรุงข้อมูลใน ds2 เพื่อรวมยอดยกมาจากเดือนก่อนหน้า
            For Each row As DataRow In ds1.Tables("MemberDataSet").Rows
                Dim memberID As String = row("m_id").ToString()
                Dim incomeRows As DataRow() = ds2.Tables("IncomeDataSet").Select("m_id = '" & memberID & "'")
                Dim carryForwardRows As DataRow() = dsPrev.Tables("CarryForwardDataSet").Select("m_id = '" & memberID & "'")

                If incomeRows.Length = 0 Then
                    ' ถ้าไม่มีรายการฝากสำหรับเดือนนี้ ให้เพิ่มแถวใหม่ใน ds2 ด้วย ind_amount = 0
                    Dim newRow As DataRow = ds2.Tables("IncomeDataSet").NewRow()
                    newRow("m_id") = memberID
                    newRow("ind_amount") = 0
                    ds2.Tables("IncomeDataSet").Rows.Add(newRow)
                    incomeRows = ds2.Tables("IncomeDataSet").Select("m_id = '" & memberID & "'")
                End If

                ' ตรวจสอบว่ามีแถวใน carryForwardRows หรือไม่
                If carryForwardRows.Length > 0 Then
                    Dim carryForwardAmount As Decimal = Convert.ToDecimal(carryForwardRows(0)("carry_forward_amount"))
                    Dim carryDate As DateTime = Convert.ToDateTime(carryForwardRows(0)("ind_date"))
                    Dim currentMonthDate As New DateTime(DateTime.Now.Year, selectedMonth, 1)

                    ' เงื่อนไขการบวกยอดยกมาเฉพาะเดือนก่อนหน้า และบวกกับเดือนถัดไปเท่านั้น
                    If carryDate.Month < currentMonthDate.Month AndAlso carryDate.Year = currentMonthDate.Year Then
                        incomeRows(0)("ind_amount") += carryForwardAmount ' บวกยอดยกมากับยอดของเดือนปัจจุบัน
                    End If
                End If
            Next


            ' ตั้งค่าเส้นทางรายงาน
            Me.ReportViewer1.LocalReport.ReportPath = "D:\Project-2022\Project\Project\report\SajjaReport.rdlc"

            ' ตรวจสอบว่าไฟล์รายงานมีอยู่จริงหรือไม่
            If Not IO.File.Exists(Me.ReportViewer1.LocalReport.ReportPath) Then
                MessageBox.Show("Report file not found: " & Me.ReportViewer1.LocalReport.ReportPath)
                Return
            End If

            ' ผูกข้อมูลกับ ReportViewer
            Me.ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("MemberDataSet", ds1.Tables("MemberDataSet")))
            Me.ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("IncomeDataSet", ds2.Tables("IncomeDataSet")))

            ' Refresh รายงาน
            Me.ReportViewer1.RefreshReport()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

End Class
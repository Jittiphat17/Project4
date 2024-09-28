Imports System.Data.OleDb
Imports Microsoft.Reporting.WinForms

Public Class ReportForm
    Private Sub ReportForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 1. ตั้งค่าการเชื่อมต่อกับฐานข้อมูล
        Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb"

        ' ใช้ Using statement เพื่อจัดการกับการเชื่อมต่ออย่างปลอดภัย
        Using connection As New OleDbConnection(connectionString)
            Try
                ' 2. เปิดการเชื่อมต่อ
                connection.Open()

                ' 3. ดึงข้อมูลจากตาราง Member (DataSet1)
                Dim queryMember As String = "SELECT m_id, m_name FROM Member"
                Dim adapterMember As New OleDbDataAdapter(queryMember, connection)
                Dim dtMember As New DataTable()
                adapterMember.Fill(dtMember)

                ' 4. ดึงข้อมูลจากตาราง Income_Details ที่มีการเชื่อมโยงกับ Income (DataSet2)
                Dim queryIncome As String = "SELECT m.m_id, m.m_name, ind.ind_accname, ind.ind_amount, i.inc_date " &
                                            "FROM [Member] m, [Income] i, [Income_Details] ind " &
                                            "WHERE m.m_id = i.m_id AND i.inc_id = ind.inc_id " &
                                            "AND MONTH(i.inc_date) = @currentMonth AND YEAR(i.inc_date) = @currentYear"

                Dim adapterIncome As New OleDbDataAdapter(queryIncome, connection)
                adapterIncome.SelectCommand.Parameters.AddWithValue("@currentMonth", DateTime.Now.Month)
                adapterIncome.SelectCommand.Parameters.AddWithValue("@currentYear", DateTime.Now.Year)

                Dim dtIncome As New DataTable()
                adapterIncome.Fill(dtIncome)

                ' 5. สร้าง DataTable ใหม่ที่รวมข้อมูล
                Dim dtCombined As New DataTable()

                ' เพิ่มคอลัมน์ที่จำเป็นลงใน DataTable
                dtCombined.Columns.Add("m_id", GetType(Integer))
                dtCombined.Columns.Add("m_name", GetType(String))
                dtCombined.Columns.Add("ind_accname", GetType(String))
                dtCombined.Columns.Add("ind_amount", GetType(Decimal))
                dtCombined.Columns.Add("inc_date", GetType(Date))

                ' รวมข้อมูลจาก dtMember และ dtIncome
                For Each incomeRow As DataRow In dtIncome.Rows
                    Dim newRow As DataRow = dtCombined.NewRow()

                    newRow("m_id") = incomeRow("m_id")
                    newRow("m_name") = incomeRow("m_name")
                    newRow("ind_accname") = incomeRow("ind_accname")
                    newRow("ind_amount") = incomeRow("ind_amount")
                    newRow("inc_date") = incomeRow("inc_date")

                    dtCombined.Rows.Add(newRow)
                Next

                ' 6. ตั้งค่า ReportDataSource สำหรับ CombinedDataset
                Dim rdsCombined As New ReportDataSource("CombinedDataset", dtCombined)

                ' 7. เคลียร์ DataSource ใน ReportViewer
                ReportViewer1.LocalReport.DataSources.Clear()

                ' 8. เพิ่ม DataSource เดียวที่รวมข้อมูลแล้ว
                ReportViewer1.LocalReport.DataSources.Add(rdsCombined)

                ' 9. กำหนดเส้นทางไฟล์รายงาน
                ReportViewer1.LocalReport.ReportPath = "D:\Project-2022\Project\Project\report\MemberReport.rdlc"

                ' 10. Refresh รายงาน
                ReportViewer1.RefreshReport()

            Catch ex As Exception
                MessageBox.Show("เกิดข้อผิดพลาด: " & ex.Message)
            End Try
        End Using
    End Sub
End Class

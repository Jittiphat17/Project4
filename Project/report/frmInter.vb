Imports System.Data.OleDb
Imports Microsoft.Reporting.WinForms

Public Class frmInter

    Private ConnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb"

    Private Sub frmInter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ถ้าต้องการโหลดข้อมูลตั้งแต่เริ่มต้นฟอร์ม สามารถคงไว้หรือคอมเมนต์ได้
        'LoadIncomeData()
    End Sub
    Private Sub LoadIncomeData()
        Try
            Using conn As New OleDbConnection(ConnString)
                conn.Open()

                ' ดึงข้อมูลจากตาราง Member
                Dim queryMember As String = "SELECT m_id AS MemberID, m_name AS MemberName FROM Member"
                Dim cmdMember As New OleDbCommand(queryMember, conn)
                Dim adapterMember As New OleDbDataAdapter(cmdMember)
                Dim tableMember As New DataTable()
                adapterMember.Fill(tableMember)

                ' ดึงข้อมูลจากตาราง Income_Details ที่เกี่ยวข้องกับบัญชี "เงินฝากสัจจะ"
                Dim queryIncomeDetails As String = "SELECT m_id AS MemberID, 'เงินฝากสัจจะ' AS AccountName, SUM(ind_amount) AS TotalDeposit " &
                                               "FROM Income_Details " &
                                               "WHERE ind_accname = 'เงินฝากสัจจะ' " &
                                               "GROUP BY m_id"
                Dim cmdIncomeDetails As New OleDbCommand(queryIncomeDetails, conn)
                Dim adapterIncomeDetails As New OleDbDataAdapter(cmdIncomeDetails)
                Dim tableIncomeDetails As New DataTable()
                adapterIncomeDetails.Fill(tableIncomeDetails)

                ' สร้าง ReportDataSource สำหรับ ReportViewer
                Dim rdsMember As New ReportDataSource("MemberDataSet", tableMember)
                Dim rdsIncomeDetails As New ReportDataSource("IncomeDetailsDataSet", tableIncomeDetails) ' ตรงกับ DataSet ใน RDLC

                ' ตั้งค่า ReportViewer
                Me.ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(rdsMember)
                Me.ReportViewer1.LocalReport.DataSources.Add(rdsIncomeDetails)
                Me.ReportViewer1.LocalReport.ReportPath = "D:\Project-2022\Project\Project\report\IncomeReport.rdlc"
                Me.ReportViewer1.RefreshReport()
            End Using
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการโหลดข้อมูลรายได้: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnViewReport_Click(sender As Object, e As EventArgs) Handles btnViewReport.Click
        ' เรียกใช้ฟังก์ชัน LoadIncomeData เพื่อดึงข้อมูลและแสดงรายงาน
        LoadIncomeData()
    End Sub

End Class

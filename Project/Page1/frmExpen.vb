Imports System.Data.OleDb

Public Class frmExpen
    Dim Conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\db_test.mdb")
    Dim cmd As OleDbCommand
    Dim da As OleDbDataAdapter
    Dim dt As DataTable
    Dim tempTable As DataTable ' ตารางชั่วคราวสำหรับเก็บข้อมูลที่เพิ่มในฟอร์ม
    Dim SQL As String

    ' เหตุการณ์เมื่อฟอร์มโหลด เพื่อตั้งค่าข้อมูลเริ่มต้น
    Private Sub frmExpen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadMemberNames()
        LoadSources()
        LoadExpenses()
        InitializeDataGridView()
        GenerateNewExId()
    End Sub

    ' เมธอดสำหรับโหลดรายชื่อสมาชิกและตั้งค่า AutoComplete ให้กับ TextBox
    Private Sub LoadMemberNames()
        Try
            Using Conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\db_test.mdb")
                Conn.Open()
                SQL = "SELECT m_name FROM Member"
                cmd = New OleDbCommand(SQL, Conn)
                Dim reader As OleDbDataReader = cmd.ExecuteReader()
                Dim autoComplete As New AutoCompleteStringCollection()

                While reader.Read()
                    autoComplete.Add(reader("m_name").ToString())
                End While
                reader.Close()

                ' ตั้งค่า AutoComplete ให้กับ TextBox
                txtRecipient.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                txtRecipient.AutoCompleteSource = AutoCompleteSource.CustomSource
                txtRecipient.AutoCompleteCustomSource = autoComplete
            End Using
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาด: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' เมธอดสำหรับโหลดแหล่งจ่ายลงใน ComboBox
    Private Sub LoadSources()
        ' เพิ่มแหล่งจ่ายลงใน ComboBox (สามารถปรับเปลี่ยนให้ดึงจากฐานข้อมูลได้)
        cmbSources.Items.Add("Source 1")
        cmbSources.Items.Add("Source 2")
        cmbSources.Items.Add("Source 3")
        cmbSources.SelectedIndex = 0 ' เลือกค่าเริ่มต้น
    End Sub

    ' เมธอดสำหรับโหลดข้อมูลค่าใช้จ่ายลงใน DataGridView
    Private Sub LoadExpenses()
        Try
            ' ใช้ Using Statement เพื่อเปิดและปิดการเชื่อมต่อฐานข้อมูลอย่างถูกต้อง
            Using Conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\db_test.mdb")
                Conn.Open()
                SQL = "SELECT * FROM Expense"
                da = New OleDbDataAdapter(SQL, Conn)
                dt = New DataTable()
                da.Fill(dt)
                DataGridView1.DataSource = dt
            End Using
        Catch ex As Exception
            ' แสดงข้อความข้อผิดพลาดถ้าเกิดปัญหาในการเชื่อมต่อฐานข้อมูล
            MessageBox.Show("เกิดข้อผิดพลาด: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' เมธอดสำหรับเริ่มต้น DataGridView
    Private Sub InitializeDataGridView()
        tempTable = New DataTable()
        tempTable.Columns.Add("Recipient", GetType(String))
        tempTable.Columns.Add("Detail", GetType(String))
        tempTable.Columns.Add("Description", GetType(String))
        tempTable.Columns.Add("Date", GetType(DateTime))
        tempTable.Columns.Add("Amount", GetType(Decimal))
        tempTable.Columns.Add("Source", GetType(String))
        tempTable.Columns.Add("ExId", GetType(Integer))

        DataGridView1.DataSource = tempTable

        ' ตั้งค่าหัวข้อคอลัมน์ของ DataGridView
        DataGridView1.Columns("Recipient").HeaderText = "ชื่อผู้รับ"
        DataGridView1.Columns("Detail").HeaderText = "รายละเอียด"
        DataGridView1.Columns("Description").HeaderText = "คำอธิบาย"
        DataGridView1.Columns("Date").HeaderText = "วันที่"
        DataGridView1.Columns("Amount").HeaderText = "จำนวนเงิน"
        DataGridView1.Columns("Source").HeaderText = "แหล่งจ่าย"
    End Sub

    ' เมธอดสำหรับสร้าง ex_id ใหม่
    Private Sub GenerateNewExId()
        Try
            Using Conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\db_test.mdb")
                Conn.Open()
                SQL = "SELECT MAX(ex_id) FROM Expense"
                cmd = New OleDbCommand(SQL, Conn)
                Dim latestExId As Object = cmd.ExecuteScalar()
                Dim newExId As Integer
                If latestExId IsNot DBNull.Value Then
                    newExId = Convert.ToInt32(latestExId) + 1
                Else
                    newExId = 1
                End If
                txtExId.Text = newExId.ToString()
            End Using
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาด: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' เหตุการณ์เมื่อคลิกปุ่มเพิ่มข้อมูลลงใน DataGridView
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' ตรวจสอบว่าฟิลด์ที่จำเป็นได้รับการกรอกครบถ้วนหรือไม่
        If txtRecipient.Text = "" Or txtAmount.Text = "" Then
            MessageBox.Show("กรุณากรอกข้อมูลให้ครบถ้วน", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' เพิ่มข้อมูลลงใน DataTable โดยไม่ต้องระบุค่า ID
        tempTable.Rows.Add(txtRecipient.Text, txtDetail.Text, txtDescription.Text, dtpDate.Value, Convert.ToDecimal(txtAmount.Text), cmbSources.SelectedItem.ToString())

        ' เคลียร์ข้อมูลในฟิลด์อินพุตหลังการเพิ่มข้อมูล
        ClearFields()
    End Sub

    ' เหตุการณ์เมื่อคลิกปุ่มบันทึกข้อมูลค่าใช้จ่ายลงในฐานข้อมูล
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            ' ใช้ Using Statement เพื่อเปิดและปิดการเชื่อมต่อฐานข้อมูลอย่างถูกต้อง
            Using Conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\db_test.mdb")
                Conn.Open()
                For Each row As DataRow In tempTable.Rows
                    SQL = "INSERT INTO Expense (ex_name, ex_detail, ex_description, ex_date, ex_amount, acc_id) VALUES (@Name, @Detail, @Description, @Date, @Amount, @AccId)"
                    cmd = New OleDbCommand(SQL, Conn)
                    cmd.Parameters.AddWithValue("@Name", row("Recipient").ToString())
                    cmd.Parameters.AddWithValue("@Detail", row("Detail").ToString())
                    cmd.Parameters.AddWithValue("@Description", row("Description").ToString())
                    cmd.Parameters.AddWithValue("@Date", Convert.ToDateTime(row("Date")))
                    cmd.Parameters.AddWithValue("@Amount", Convert.ToDecimal(row("Amount")))
                    cmd.Parameters.AddWithValue("@AccId", row("Source").ToString())
                    cmd.ExecuteNonQuery()

                    ' ดึงค่า ex_id ที่เพิ่มใหม่
                    cmd.CommandText = "SELECT @@IDENTITY"
                    Dim newExId As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                    ' แสดงค่า ex_id ใน TextBox
                    txtExId.Text = newExId.ToString()

                    ' บันทึกค่า ex_id ลงใน DataTable
                    row("ExId") = newExId
                Next

                MessageBox.Show("บันทึกข้อมูลค่าใช้จ่ายเรียบร้อยแล้ว", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' โหลดข้อมูลใหม่ใน DataGridView
                LoadExpenses()

                ' เคลียร์ DataTable หลังจากบันทึกข้อมูลลงฐานข้อมูลเรียบร้อยแล้ว
                tempTable.Clear()

                ' สร้าง ex_id ใหม่สำหรับการบันทึกครั้งถัดไป
                GenerateNewExId()
            End Using
        Catch ex As Exception
            ' แสดงข้อความข้อผิดพลาดถ้าเกิดปัญหาในการบันทึกข้อมูล
            MessageBox.Show("เกิดข้อผิดพลาด: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' เมธอดสำหรับเคลียร์ข้อมูลในฟิลด์อินพุต
    Private Sub ClearFields()
        txtRecipient.Clear()
        txtDetail.Clear()
        txtDescrip.Clear()
        txtAmount.Clear()
        cmbSources.SelectedIndex = 0 ' รีเซ็ตค่าเริ่มต้น
        dtpDate.Value = DateTime.Now
    End Sub

    ' เหตุการณ์เมื่อคลิกปุ่มล้างข้อมูล
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    ' เหตุการณ์เมื่อคลิกปุ่มพิมพ์เอกสาร (ยังไม่ได้ implement)
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        ' แสดงข้อความแจ้งว่าฟังก์ชันการพิมพ์ยังไม่ได้ implement
        MessageBox.Show("ฟังก์ชันการพิมพ์ยังไม่ได้ implement", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' เหตุการณ์เมื่อเปลี่ยนข้อความใน TextBox txtRecipient
    Private Sub txtRecipient_TextChanged(sender As Object, e As EventArgs) Handles txtRecipient.TextChanged
        LoadMemberDetails(txtRecipient.Text)
    End Sub

    ' เมธอดสำหรับโหลดรายละเอียดสมาชิกลงใน txtDetail
    Private Sub LoadMemberDetails(memberName As String)
        Try
            Using Conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\db_test.mdb")
                Conn.Open()
                SQL = "SELECT m_id, m_name, m_address FROM Member WHERE m_name = @Name"
                cmd = New OleDbCommand(SQL, Conn)
                cmd.Parameters.AddWithValue("@Name", memberName)
                Dim reader As OleDbDataReader = cmd.ExecuteReader()

                If reader.Read() Then
                    ' แสดงข้อมูลใน txtDetail
                    txtDetail.Text = $"รหัสสมาชิก: {reader("m_id").ToString()}, ชื่อ: {reader("m_name").ToString()}, ที่อยู่: {reader("m_address").ToString()}"
                Else
                    txtDetail.Clear() ' เคลียร์ข้อมูลถ้าไม่พบสมาชิก
                End If
                reader.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาด: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class

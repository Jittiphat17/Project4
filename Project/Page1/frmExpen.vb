Imports System.Data.OleDb

Public Class frmExpen
    Dim Conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\db_test.mdb")
    Dim cmd As OleDbCommand
    Dim da As OleDbDataAdapter
    Dim dt As DataTable
    Dim tempTable As DataTable
    Dim SQL As String

    Private Sub frmExpen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadMemberNames()
        LoadSources()
        LoadExpenses()
        InitializeDataGridView()
        GenerateNewExId()
    End Sub

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

                txtRecipient.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                txtRecipient.AutoCompleteSource = AutoCompleteSource.CustomSource
                txtRecipient.AutoCompleteCustomSource = autoComplete
            End Using
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาด: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadSources()
        Try
            Using Conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\db_test.mdb")
                Conn.Open()
                SQL = "SELECT acc_id, acc_name FROM Account"
                cmd = New OleDbCommand(SQL, Conn)
                Dim reader As OleDbDataReader = cmd.ExecuteReader()

                cmbSources.Items.Clear()
                While reader.Read()
                    Dim source As String = reader("acc_id").ToString() & " - " & reader("acc_name").ToString()
                    cmbSources.Items.Add(source)
                End While
                reader.Close()
                cmbSources.SelectedIndex = 0
            End Using
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาด: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadExpenses()
        Try
            Using Conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\db_test.mdb")
                Conn.Open()
                SQL = "SELECT * FROM Expense"
                da = New OleDbDataAdapter(SQL, Conn)
                dt = New DataTable()
                da.Fill(dt)
                DataGridView1.DataSource = dt
            End Using
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาด: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

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

        DataGridView1.Columns("Recipient").HeaderText = "ชื่อผู้รับ"
        DataGridView1.Columns("Detail").HeaderText = "รายละเอียด"
        DataGridView1.Columns("Description").HeaderText = "คำอธิบาย"
        DataGridView1.Columns("Date").HeaderText = "วันที่"
        DataGridView1.Columns("Amount").HeaderText = "จำนวนเงิน"
        DataGridView1.Columns("Source").HeaderText = "แหล่งจ่าย"
    End Sub

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

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If txtRecipient.Text = "" Or txtAmount.Text = "" Then
            MessageBox.Show("กรุณากรอกข้อมูลให้ครบถ้วน", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim totalAmount As Decimal = tempTable.AsEnumerable().Sum(Function(row) Convert.ToDecimal(row("Amount")))
        Dim inputAmount As Decimal = Convert.ToDecimal(txtAmount.Text)

        If totalAmount + inputAmount > inputAmount Then
            MessageBox.Show("จำนวนเงินในรายการเกินจำนวนที่ระบุ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        tempTable.Rows.Add(txtRecipient.Text, txtDetail.Text, txtDescription.Text, dtpDate.Value, inputAmount, cmbSources.SelectedItem.ToString())

        ClearFields()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim totalAmount As Decimal = tempTable.AsEnumerable().Sum(Function(row) Convert.ToDecimal(row("Amount")))
            Dim inputAmount As Decimal = Convert.ToDecimal(txtAmount.Text)

            If totalAmount <> inputAmount Then
                MessageBox.Show("จำนวนเงินในรายการไม่ตรงกับจำนวนที่ระบุ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

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

                    cmd.CommandText = "SELECT @@IDENTITY"
                    Dim newExId As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    row("ExId") = newExId

                    SQL = "INSERT INTO Expense_Details (exd_nameacc, con_id, exd_amount, ex_id) VALUES (@exd_nameacc, @con_id, @exd_amount, @ex_id)"
                    cmd = New OleDbCommand(SQL, Conn)
                    cmd.Parameters.AddWithValue("@exd_nameacc", row("Source").ToString())
                    cmd.Parameters.AddWithValue("@con_id", DBNull.Value) ' ใช้ค่า DBNull สำหรับ con_id ที่ยังไม่ได้เชื่อมต่อ
                    cmd.Parameters.AddWithValue("@exd_amount", row("Amount"))
                    cmd.Parameters.AddWithValue("@ex_id", newExId)
                    cmd.ExecuteNonQuery()
                Next

                MessageBox.Show("บันทึกข้อมูลค่าใช้จ่ายเรียบร้อยแล้ว", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                LoadExpenses()
                tempTable.Clear()
                GenerateNewExId()
            End Using
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาด: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearFields()
        txtRecipient.Clear()
        txtDetail.Clear()
        txtDescrip.Clear()
        txtAmount.Clear()
        cmbSources.SelectedIndex = 0
        dtpDate.Value = DateTime.Now
    End Sub

End Class

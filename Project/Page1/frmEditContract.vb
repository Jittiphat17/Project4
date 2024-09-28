Imports System.Data.OleDb

Public Class frmEditContract
    Dim conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb")
    Private contractID As String = "" ' เก็บค่า con_id ของสัญญาที่ถูกเลือก

    Private Sub frmEditContract_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupAutoComplete() ' ตั้งค่า Autocomplete สำหรับฟิลด์ค้นหา
        LoadAccounts() ' โหลดข้อมูลบัญชีใน ComboBox แต่ไม่เลือกค่าใดๆ
        LoadGuarantorList() ' โหลดข้อมูลผู้ค้ำประกันใน ComboBox
        ConfigureDataGridView() ' เรียกใช้ฟังก์ชันเพื่อตั้งค่าการแสดงผลของ Guna2DataGridView
        cmbAccount.SelectedIndex = -1 ' ตั้งค่า ComboBox ให้ไม่เลือกค่าใด ๆ เริ่มต้น
        cmbGuarantor1.SelectedIndex = -1
        cmbGuarantor2.SelectedIndex = -1
        cmbGuarantor3.SelectedIndex = -1
        txtContractID.ReadOnly = True
        txtContractInterest.ReadOnly = True
        txtContractAmount.ReadOnly = False
        dtpContractDate.Enabled = True
        cmbAccount.Enabled = True
    End Sub

    Private Sub ConfigureDataGridView()
        ' ใช้ Guna2DataGridView พร้อมตั้งค่า Theme
        dgvContracts.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Dark

        ' เปิดการใช้งาน ScrollBars
        dgvContracts.ScrollBars = ScrollBars.Both ' ทั้งแนวนอนและแนวตั้ง

        ' ปิดการตั้งค่า AutoSizeColumnMode
        dgvContracts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None

        ' ตั้งค่าฟอนต์และสีสำหรับ DefaultCellStyle
        dgvContracts.DefaultCellStyle.Font = New Font("Fc minimal", 15)
        dgvContracts.DefaultCellStyle.BackColor = Color.White
        dgvContracts.DefaultCellStyle.ForeColor = Color.Black
        dgvContracts.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray
        dgvContracts.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black

        ' ตั้งค่าฟอนต์และสีสำหรับ ColumnHeaders
        dgvContracts.ColumnHeadersDefaultCellStyle.Font = New Font("Fc minimal", 10, FontStyle.Bold)
        dgvContracts.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy
        dgvContracts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

        ' เปิดใช้หัวตาราง
        dgvContracts.EnableHeadersVisualStyles = False
        dgvContracts.ColumnHeadersVisible = True

        ' ตั้งชื่อหัวตารางและกำหนดรูปแบบ
        If dgvContracts.Columns.Contains("con_id") Then
            dgvContracts.Columns("con_id").HeaderText = "รหัสสัญญา"
            dgvContracts.Columns("con_id").Width = 50 ' กำหนดความกว้างคอลัมน์
        End If

        If dgvContracts.Columns.Contains("m_id") Then
            dgvContracts.Columns("m_id").HeaderText = "รหัสสมาชิก"
            dgvContracts.Columns("m_id").Width = 50
        End If

        If dgvContracts.Columns.Contains("con_details") Then
            dgvContracts.Columns("con_details").HeaderText = "รายละเอียดผู้ทำสัญญา"
            dgvContracts.Columns("con_details").Width = 200
        End If

        If dgvContracts.Columns.Contains("con_amount") Then
            dgvContracts.Columns("con_amount").HeaderText = "จำนวนเงิน"
            dgvContracts.Columns("con_amount").DefaultCellStyle.Format = "N0" ' กำหนดรูปแบบตัวเลข
            dgvContracts.Columns("con_amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If

        If dgvContracts.Columns.Contains("con_interest") Then
            dgvContracts.Columns("con_interest").HeaderText = "ดอกเบี้ย"
            dgvContracts.Columns("con_interest").DefaultCellStyle.Format = "N2" ' รูปแบบทศนิยม 2 ตำแหน่ง
            dgvContracts.Columns("con_interest").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If

        If dgvContracts.Columns.Contains("con_permonth") Then
            dgvContracts.Columns("con_permonth").HeaderText = "จำนวนต่อเดือน"
        End If

        If dgvContracts.Columns.Contains("con_date") Then
            dgvContracts.Columns("con_date").HeaderText = "วันที่ทำรายการ"
            dgvContracts.Columns("con_date").DefaultCellStyle.Format = "dd/MM/yyyy" ' รูปแบบวันที่
        End If

        If dgvContracts.Columns.Contains("acc_name") Then
            dgvContracts.Columns("acc_name").HeaderText = "ชื่อบัญชี"
        End If

        ' ตั้งชื่อหัวตารางสำหรับ GuarantorNames เป็นภาษาไทย
        If dgvContracts.Columns.Contains("GuarantorNames") Then
            dgvContracts.Columns("GuarantorNames").HeaderText = "ชื่อผู้ค้ำประกัน"
            dgvContracts.Columns("GuarantorNames").Width = 150 ' ตั้งค่าความกว้างคอลัมน์
        End If

        ' เปิดการเลื่อนแถบ (ScrollBars)
        dgvContracts.ScrollBars = ScrollBars.Both ' เปิดทั้งแถบเลื่อนแนวนอนและแนวตั้ง
    End Sub



    Private Sub SetupAutoComplete()
        txtSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource
        Dim autoCompleteCollection As New AutoCompleteStringCollection()

        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim query As String = "SELECT DISTINCT con_id FROM Contract"
            Dim cmd As New OleDbCommand(query, conn)
            Dim reader As OleDbDataReader = cmd.ExecuteReader()
            While reader.Read()
                autoCompleteCollection.Add(reader("con_id").ToString())
            End While
        Catch ex As Exception
            MessageBox.Show("Error setting autocomplete: " & ex.Message)
        Finally
            conn.Close()
        End Try

        txtSearch.AutoCompleteCustomSource = autoCompleteCollection
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        SearchContracts()
    End Sub

    Private Sub SearchContracts()
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim searchQuery As String = "SELECT c.con_id, c.m_id, c.con_details, c.con_amount, c.con_interest, " &
                                    "c.con_permonth, c.con_date, a.acc_name " &
                                    "FROM (Contract c " &
                                    "LEFT JOIN Account a ON c.acc_id = a.acc_id) " &
                                    "WHERE c.con_id LIKE @searchTerm"
            Dim cmd As New OleDbCommand(searchQuery, conn)
            cmd.Parameters.AddWithValue("@searchTerm", "%" & txtSearch.Text.Trim() & "%")

            Dim adapter As New OleDbDataAdapter(cmd)
            Dim table As New DataTable()
            adapter.Fill(table)

            table.Columns.Add("GuarantorNames", GetType(String))

            For Each row As DataRow In table.Rows
                Dim conId As String = row("con_id").ToString()
                Dim guarantorNames As String = GetGuarantorNames(conId)
                row("GuarantorNames") = guarantorNames
            Next

            dgvContracts.DataSource = table

        Catch ex As Exception
            MessageBox.Show("Error searching contracts: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Function GetGuarantorNames(conId As String) As String
        Dim guarantorNames As New List(Of String)

        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim query As String = "SELECT m.m_name FROM Guarantor g " &
                              "INNER JOIN Member m ON g.m_id = m.m_id " &
                              "WHERE g.con_id = @con_id"
            Dim cmd As New OleDbCommand(query, conn)
            cmd.Parameters.AddWithValue("@con_id", conId)
            Dim reader As OleDbDataReader = cmd.ExecuteReader()

            While reader.Read()
                guarantorNames.Add(reader("m_name").ToString())
            End While

            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error fetching guarantor names: " & ex.Message)
        Finally
            conn.Close()
        End Try

        Return String.Join(", ", guarantorNames)
    End Function

    Private Sub dgvContracts_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvContracts.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim selectedContractID As String = dgvContracts.Rows(e.RowIndex).Cells("con_id").Value.ToString()
            contractID = selectedContractID
            LoadContractDetails()
            LoadGuarantorDetails()
        End If
    End Sub

    Private Sub LoadContractDetails()
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim query As String = "SELECT * FROM Contract WHERE con_id = @con_id"
            Dim cmd As New OleDbCommand(query, conn)
            cmd.Parameters.AddWithValue("@con_id", contractID)
            Dim reader As OleDbDataReader = cmd.ExecuteReader()

            If reader.HasRows Then
                reader.Read()
                txtContractID.Text = reader("con_id").ToString()
                txtContractAmount.Text = reader("con_amount").ToString()
                txtContractInterest.Text = reader("con_interest").ToString()
                dtpContractDate.Value = Convert.ToDateTime(reader("con_date"))

                If Not reader.IsDBNull(reader.GetOrdinal("acc_id")) Then
                    Dim accountId As String = reader("acc_id").ToString()
                    If cmbAccount.Items.Cast(Of DataRowView)().Any(Function(item) item("acc_id").ToString() = accountId) Then
                        cmbAccount.SelectedValue = accountId
                    End If
                End If
            End If

            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading contract details: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub LoadGuarantorDetails()
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim query As String = "SELECT m.m_name, g.m_id FROM Guarantor g " &
                              "INNER JOIN Member m ON g.m_id = m.m_id " &
                              "WHERE g.con_id = @con_id"
            Dim cmd As New OleDbCommand(query, conn)
            cmd.Parameters.AddWithValue("@con_id", contractID)
            Dim reader As OleDbDataReader = cmd.ExecuteReader()

            Dim guarantorCount As Integer = 0

            While reader.Read()
                guarantorCount += 1

                Select Case guarantorCount
                    Case 1
                        cmbGuarantor1.Text = reader("m_name").ToString()
                        cmbGuarantor1.Tag = reader("m_id").ToString()
                    Case 2
                        cmbGuarantor2.Text = reader("m_name").ToString()
                        cmbGuarantor2.Tag = reader("m_id").ToString()
                    Case 3
                        cmbGuarantor3.Text = reader("m_name").ToString()
                        cmbGuarantor3.Tag = reader("m_id").ToString()
                End Select
            End While

            reader.Close()

        Catch ex As Exception
            MessageBox.Show("Error loading guarantor details: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub LoadAccounts()
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim query As String = "SELECT acc_id, acc_name FROM Account"
            Dim adapter As New OleDbDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)

            If table.Rows.Count > 0 Then
                cmbAccount.DataSource = table
                cmbAccount.DisplayMember = "acc_name"
                cmbAccount.ValueMember = "acc_id"
                cmbAccount.SelectedIndex = -1
            Else
                MessageBox.Show("No data available in Account table.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading accounts: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub LoadGuarantorList()
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim query As String = "SELECT m_id, m_name FROM Member"
            Dim adapter As New OleDbDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)

            cmbGuarantor1.DataSource = table.Copy()
            cmbGuarantor1.DisplayMember = "m_name"
            cmbGuarantor1.ValueMember = "m_id"
            cmbGuarantor1.SelectedIndex = -1

            cmbGuarantor2.DataSource = table.Copy()
            cmbGuarantor2.DisplayMember = "m_name"
            cmbGuarantor2.ValueMember = "m_id"
            cmbGuarantor2.SelectedIndex = -1

            cmbGuarantor3.DataSource = table.Copy()
            cmbGuarantor3.DisplayMember = "m_name"
            cmbGuarantor3.ValueMember = "m_id"
            cmbGuarantor3.SelectedIndex = -1

        Catch ex As Exception
            MessageBox.Show("Error loading guarantor list: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub
    ' ฟังก์ชันสำหรับคำนวณยอดชำระรายเดือน
    Private Function CalculateMonthlyPayment(principal As Decimal, annualInterestRate As Decimal, totalPayments As Integer) As Decimal
        Dim monthlyInterestRate As Decimal = annualInterestRate / 12 / 100
        Dim numerator As Decimal = principal * monthlyInterestRate
        Dim denominator As Decimal = 1 - Math.Pow(1 + monthlyInterestRate, -totalPayments)
        Dim monthlyPayment As Decimal = numerator / denominator
        Return monthlyPayment
    End Function

    Private Sub UpdateAccountDetails(contractId As String, newAccountId As String)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim m_id As String = ""
            Dim selectMIDQuery As String = "SELECT m_id FROM Contract WHERE con_id = @con_id"
            Using selectCmd As New OleDbCommand(selectMIDQuery, conn)
                selectCmd.Parameters.AddWithValue("@con_id", contractId)
                m_id = Convert.ToString(selectCmd.ExecuteScalar())
            End Using

            If Not String.IsNullOrEmpty(m_id) Then
                Dim updateAccountDetailsQuery As String = "UPDATE Account_Details SET acc_id = @new_acc_id WHERE m_id = @m_id"
                Using cmdUpdateAccountDetails As New OleDbCommand(updateAccountDetailsQuery, conn)
                    cmdUpdateAccountDetails.Parameters.AddWithValue("@new_acc_id", newAccountId)
                    cmdUpdateAccountDetails.Parameters.AddWithValue("@m_id", m_id)

                    cmdUpdateAccountDetails.ExecuteNonQuery()
                End Using

                MessageBox.Show("Account details updated successfully with new acc_id: " & newAccountId)
            Else
                MessageBox.Show("Error: m_id not found.")
            End If

        Catch ex As Exception
            MessageBox.Show("Error updating account details: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub UpdatePaymentAmounts(contractId As String, amountPerMonth As Decimal)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim updatePaymentsQuery As String = "UPDATE Payment SET payment_amount = @payment_amount WHERE con_id = @con_id"
            Dim cmdUpdatePayments As New OleDbCommand(updatePaymentsQuery, conn)
            cmdUpdatePayments.Parameters.AddWithValue("@payment_amount", amountPerMonth)
            cmdUpdatePayments.Parameters.AddWithValue("@con_id", contractId)

            cmdUpdatePayments.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Error updating payment amounts: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub UpdateGuarantorDetails()
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            ' ดึง m_id ของผู้กู้จากตาราง Contract
            Dim borrowerMID As String = ""
            Dim selectBorrowerQuery As String = "SELECT m_id FROM Contract WHERE con_id = @con_id"
            Using selectCmd As New OleDbCommand(selectBorrowerQuery, conn)
                selectCmd.Parameters.AddWithValue("@con_id", contractID)
                borrowerMID = Convert.ToString(selectCmd.ExecuteScalar())
            End Using

            ' ลบข้อมูลผู้ค้ำประกันที่มีอยู่ทั้งหมดก่อน
            Dim deleteGuarantorQuery As String = "DELETE FROM Guarantor WHERE con_id = @con_id"
            Dim cmdDeleteGuarantor As New OleDbCommand(deleteGuarantorQuery, conn)
            cmdDeleteGuarantor.Parameters.AddWithValue("@con_id", contractID)
            cmdDeleteGuarantor.ExecuteNonQuery()

            ' ตรวจสอบว่ามีผู้ค้ำประกันซ้ำกับผู้กู้หรือไม่
            If cmbGuarantor1.SelectedIndex <> -1 AndAlso cmbGuarantor1.SelectedValue.ToString() = borrowerMID Then
                MessageBox.Show("ผู้ค้ำประกันไม่สามารถเป็นผู้กู้ได้.")
                Return ' หยุดการทำงาน
            End If
            If cmbGuarantor2.SelectedIndex <> -1 AndAlso cmbGuarantor2.SelectedValue.ToString() = borrowerMID Then
                MessageBox.Show("ผู้ค้ำประกันไม่สามารถเป็นผู้กู้ได้.")
                Return ' หยุดการทำงาน
            End If
            If cmbGuarantor3.SelectedIndex <> -1 AndAlso cmbGuarantor3.SelectedValue.ToString() = borrowerMID Then
                MessageBox.Show("ผู้ค้ำประกันไม่สามารถเป็นผู้กู้ได้.")
                Return ' หยุดการทำงาน
            End If

            ' เพิ่มข้อมูลผู้ค้ำประกันใหม่จาก ComboBox
            If cmbGuarantor1.SelectedIndex <> -1 Then
                InsertGuarantor(cmbGuarantor1.SelectedValue.ToString())
            End If
            If cmbGuarantor2.SelectedIndex <> -1 Then
                InsertGuarantor(cmbGuarantor2.SelectedValue.ToString())
            End If
            If cmbGuarantor3.SelectedIndex <> -1 Then
                InsertGuarantor(cmbGuarantor3.SelectedValue.ToString())
            End If

            MessageBox.Show("Guarantor details updated successfully!")

        Catch ex As Exception
            MessageBox.Show("Error updating guarantor details: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub


    Private Sub InsertGuarantor(guarantorID As String)
        Dim insertGuarantorQuery As String = "INSERT INTO Guarantor (con_id, m_id) VALUES (@con_id, @m_id)"
        Dim cmdInsertGuarantor As New OleDbCommand(insertGuarantorQuery, conn)
        cmdInsertGuarantor.Parameters.AddWithValue("@con_id", contractID)
        cmdInsertGuarantor.Parameters.AddWithValue("@m_id", guarantorID)
        cmdInsertGuarantor.ExecuteNonQuery()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrEmpty(contractID) Then
            MessageBox.Show("Please select a contract to edit.")
            Return
        End If

        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            ' อ่านค่าจำนวนเงินและจำนวนเดือน
            Dim totalAmount As Decimal = Convert.ToDecimal(txtContractAmount.Text)
            Dim numMonths As Integer = Integer.Parse(dgvContracts.CurrentRow.Cells("con_permonth").Value.ToString())

            ' ดอกเบี้ยต่อปีเป็นเปอร์เซ็นต์
            Dim annualInterestRate As Decimal = 0.9 ' 0.9% ต่อปี

            ' ใช้ฟังก์ชัน CalculateMonthlyPayment เพื่อคำนวณจำนวนเงินที่ต้องชำระต่อเดือน
            Dim amountPerMonth As Decimal = CalculateMonthlyPayment(totalAmount, annualInterestRate, numMonths)

            ' ตรวจสอบว่า ComboBox มีการเลือกค่าหรือไม่
            If cmbAccount.SelectedItem IsNot Nothing Then
                Dim selectedAccountID As String = cmbAccount.SelectedValue.ToString()

                ' อัปเดตฟิลด์ที่สามารถแก้ไขได้ในตาราง Contract: con_amount, con_date, acc_id
                Dim updateContractQuery As String = "UPDATE Contract SET con_amount = @amount, con_date = @date, acc_id = @acc_id WHERE con_id = @con_id"
                Dim cmd As New OleDbCommand(updateContractQuery, conn)
                cmd.Parameters.AddWithValue("@amount", totalAmount)
                cmd.Parameters.AddWithValue("@date", dtpContractDate.Value)
                cmd.Parameters.AddWithValue("@acc_id", selectedAccountID) ' ใช้ค่า acc_id จาก ComboBox
                cmd.Parameters.AddWithValue("@con_id", contractID)

                cmd.ExecuteNonQuery()

                ' อัปเดตฟิลด์ payment_amount ในตาราง Payment
                UpdatePaymentAmounts(contractID, amountPerMonth)

                ' อัปเดตฟิลด์ acc_id ในตาราง Account_Details
                UpdateAccountDetails(contractID, selectedAccountID)

                ' อัปเดตข้อมูลผู้ค้ำประกัน
                UpdateGuarantorDetails()

                MessageBox.Show("Contract, Account, Payment, and Guarantor details updated successfully!")

                ' รีเซ็ตฟอร์มและรีเฟรชข้อมูลใน DataGridView หลังจากบันทึกข้อมูล
                ResetForm()
                SearchContracts()
            Else
                MessageBox.Show("Please select an account.")
            End If

        Catch ex As Exception
            MessageBox.Show("Error saving contract, account, payment, and guarantor details: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If String.IsNullOrEmpty(contractID) Then
            MessageBox.Show("Please select a contract to delete.")
            Return
        End If

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this contract?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            Try
                If conn.State = ConnectionState.Closed Then conn.Open()

                ' ลบข้อมูลจากตาราง Contract
                Dim deleteContractQuery As String = "DELETE FROM Contract WHERE con_id = @con_id"
                Dim cmdDeleteContract As New OleDbCommand(deleteContractQuery, conn)
                cmdDeleteContract.Parameters.AddWithValue("@con_id", contractID)
                cmdDeleteContract.ExecuteNonQuery()

                ' ลบข้อมูลที่เกี่ยวข้องจากตาราง Account_Details
                Dim deleteAccountDetailsQuery As String = "DELETE FROM Account_Details WHERE acc_id = (SELECT acc_id FROM Contract WHERE con_id = @con_id)"
                Dim cmdDeleteAccountDetails As New OleDbCommand(deleteAccountDetailsQuery, conn)
                cmdDeleteAccountDetails.Parameters.AddWithValue("@con_id", contractID)
                cmdDeleteAccountDetails.ExecuteNonQuery()

                ' ลบข้อมูลผู้ค้ำประกัน
                Dim deleteGuarantorQuery As String = "DELETE FROM Guarantor WHERE con_id = @con_id"
                Dim cmdDeleteGuarantor As New OleDbCommand(deleteGuarantorQuery, conn)
                cmdDeleteGuarantor.Parameters.AddWithValue("@con_id", contractID)
                cmdDeleteGuarantor.ExecuteNonQuery()

                MessageBox.Show("Contract, related account details, and guarantor deleted successfully!")

                ' รีเฟรชข้อมูลใน DataGridView หลังจากลบข้อมูล
                SearchContracts()

            Catch ex As Exception
                MessageBox.Show("Error deleting contract and related details: " & ex.Message)
            Finally
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub ResetForm()
        txtContractID.Clear()
        txtContractAmount.Clear()
        txtContractInterest.Clear()
        dtpContractDate.Value = DateTime.Now
        cmbAccount.SelectedIndex = -1
    End Sub

    Private Sub cmbGuarantor1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGuarantor1.SelectedIndexChanged
        PreventDuplicateSelection(cmbGuarantor1)
    End Sub

    Private Sub cmbGuarantor2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGuarantor2.SelectedIndexChanged
        PreventDuplicateSelection(cmbGuarantor2)
    End Sub

    Private Sub cmbGuarantor3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGuarantor3.SelectedIndexChanged
        PreventDuplicateSelection(cmbGuarantor3)
    End Sub

    Private Sub PreventDuplicateSelection(changedComboBox As ComboBox)
        ' ตรวจสอบว่ามีการเลือกผู้ค้ำใน ComboBox อื่นที่ซ้ำกันหรือไม่
        Dim selectedIds As New List(Of String)()

        If cmbGuarantor1.SelectedIndex <> -1 Then
            selectedIds.Add(cmbGuarantor1.SelectedValue.ToString())
        End If
        If cmbGuarantor2.SelectedIndex <> -1 Then
            selectedIds.Add(cmbGuarantor2.SelectedValue.ToString())
        End If
        If cmbGuarantor3.SelectedIndex <> -1 Then
            selectedIds.Add(cmbGuarantor3.SelectedValue.ToString())
        End If

        ' หากมีการเลือกผู้ค้ำที่ซ้ำกันใน ComboBox
        Dim duplicateCount = selectedIds.GroupBy(Function(x) x).Where(Function(g) g.Count() > 1).Count()
        If duplicateCount > 0 Then
            MessageBox.Show("กรุณาเลือกผู้ค้ำประกันที่ไม่ซ้ำกัน.")
            changedComboBox.SelectedIndex = -1 ' รีเซ็ตการเลือกของ ComboBox ที่เกิดซ้ำ
        End If
    End Sub

End Class
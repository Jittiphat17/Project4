Imports System.Data.OleDb

Public Class frmIncomePayment

    ' เชื่อมต่อกับฐานข้อมูล Access
    Private ReadOnly connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_banmai1.accdb"

    Private Sub frmIncomePayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' โหลดสถานะการชำระเงินจากฐานข้อมูล
        LoadPaymentStatuses()
        ' โหลดบัญชีใน ComboBox
        LoadAccounts()
    End Sub

    Private Sub LoadPaymentStatuses()
        Using connection As New OleDbConnection(connectionString)
            Try
                connection.Open()
                Dim strSQL As String = "SELECT status_id, status_name FROM Status ORDER BY status_id"
                Using adapter As New OleDbDataAdapter(strSQL, connection)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)
                    cbPaymentStatus.DataSource = dt
                    cbPaymentStatus.DisplayMember = "status_name"
                    cbPaymentStatus.ValueMember = "status_id"
                End Using
            Catch ex As Exception
                MessageBox.Show("เกิดข้อผิดพลาดในการโหลดสถานะการชำระ: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub LoadAccounts()
        Using connection As New OleDbConnection(connectionString)
            Try
                connection.Open()
                Dim strSQL As String = "SELECT acc_id, acc_name FROM Account"
                Using adapter As New OleDbDataAdapter(strSQL, connection)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)
                    cbAccount.DataSource = dt
                    cbAccount.DisplayMember = "acc_name"
                    cbAccount.ValueMember = "acc_id"
                End Using
            Catch ex As Exception
                MessageBox.Show("เกิดข้อผิดพลาดในการโหลดข้อมูลบัญชี: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub btnSearchContract_Click(sender As Object, e As EventArgs) Handles btnSearchContract.Click
        SearchContract()
    End Sub

    Private Sub SearchContract()
        If String.IsNullOrEmpty(txtContractId.Text) Then
            MessageBox.Show("กรุณากรอกเลขที่สัญญา", "ข้อมูลไม่ครบ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using connection As New OleDbConnection(connectionString)
            Try
                connection.Open()
                ' ค้นหาข้อมูลสัญญา, ผู้กู้, จำนวนเงิน และสถานะการชำระล่าสุด
                Dim strSQL As String = "SELECT c.con_id, m.m_name, p.payment_amount, s.status_name " &
                                       "FROM ((Contract c " &
                                       "INNER JOIN Member m ON c.m_id = m.m_id) " &
                                       "LEFT JOIN Payment p ON c.con_id = p.con_id) " &
                                       "LEFT JOIN Status s ON p.status_id = s.status_id " &
                                       "WHERE c.con_id = @con_id " &
                                       "ORDER BY p.payment_date DESC"
                Using cmd As New OleDbCommand(strSQL, connection)
                    cmd.Parameters.AddWithValue("@con_id", txtContractId.Text)

                    Using reader As OleDbDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            ' แสดงข้อมูลผู้กู้
                            txtBorrowerName.Text = reader("m_name").ToString()
                            ' แสดงจำนวนเงิน
                            txtPaymentAmount.Text = If(reader("payment_amount") IsNot DBNull.Value, CDec(reader("payment_amount")).ToString("N2"), "")
                            ' แสดงสถานะการชำระ
                            Dim statusName As String = If(reader("status_name") IsNot DBNull.Value, reader("status_name").ToString(), "")
                            cbPaymentStatus.SelectedIndex = cbPaymentStatus.FindStringExact(statusName)
                            ' โหลดงวดการชำระที่เกี่ยวข้อง
                            LoadInstallments()
                        Else
                            MessageBox.Show("ไม่พบเลขที่สัญญานี้", "ไม่พบข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            ClearForm()
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("เกิดข้อผิดพลาด: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub LoadInstallments()
        cbInstallment.Items.Clear()
        Using connection As New OleDbConnection(connectionString)
            Try
                connection.Open()
                Dim strSQL As String = "SELECT p.payment_id, p.payment_date, p.payment_amount, p.status_id, s.status_name " &
                                   "FROM Payment p INNER JOIN Status s ON p.status_id = s.status_id " &
                                   "WHERE p.con_id = @con_id ORDER BY p.payment_date"
                Using cmd As New OleDbCommand(strSQL, connection)
                    cmd.Parameters.AddWithValue("@con_id", txtContractId.Text)
                    Using reader As OleDbDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim paymentId As Integer = CInt(reader("payment_id"))
                            Dim paymentDate As Date = CDate(reader("payment_date"))
                            Dim paymentAmount As Decimal = CDec(reader("payment_amount"))
                            Dim statusId As Integer = CInt(reader("status_id"))
                            Dim statusName As String = reader("status_name").ToString()
                            cbInstallment.Items.Add(New InstallmentItem(paymentId, paymentDate, paymentAmount, statusId, $"งวดที่ {paymentId} - {paymentDate:dd/MM/yyyy} - {paymentAmount:N2} บาท - {statusName}"))
                        End While
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("เกิดข้อผิดพลาดในการโหลดงวดการชำระ: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using

        AddHandler cbInstallment.SelectedIndexChanged, AddressOf cbInstallment_SelectedIndexChanged
    End Sub

    Private Class InstallmentItem
        Public Property PaymentId As Integer
        Public Property PaymentDate As Date
        Public Property PaymentAmount As Decimal
        Public Property StatusId As Integer
        Public Property DisplayText As String

        Public Sub New(paymentId As Integer, paymentDate As Date, paymentAmount As Decimal, statusId As Integer, displayText As String)
            Me.PaymentId = paymentId
            Me.PaymentDate = paymentDate
            Me.PaymentAmount = paymentAmount
            Me.StatusId = statusId
            Me.DisplayText = displayText
        End Sub

        Public Overrides Function ToString() As String
            Return DisplayText
        End Function
    End Class

    Private Sub cbInstallment_SelectedIndexChanged(sender As Object, e As EventArgs)
        If cbInstallment.SelectedItem IsNot Nothing Then
            Dim selectedInstallment As InstallmentItem = DirectCast(cbInstallment.SelectedItem, InstallmentItem)
            cbPaymentStatus.SelectedValue = selectedInstallment.StatusId
            dtpPaymentDate.Value = selectedInstallment.PaymentDate
            txtPaymentAmount.Text = selectedInstallment.PaymentAmount.ToString("N2")
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateInput() Then Return

        Using connection As New OleDbConnection(connectionString)
            Try
                connection.Open()
                Using transaction As OleDbTransaction = connection.BeginTransaction()
                    Try
                        SaveIncome(connection, transaction)
                        SavePayment(connection, transaction)
                        transaction.Commit()
                        MessageBox.Show("บันทึกข้อมูลและปรับปรุงยอดคงเหลือเรียบร้อย", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ClearForm()
                    Catch ex As Exception
                        transaction.Rollback()
                        MessageBox.Show("เกิดข้อผิดพลาด: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            Catch ex As Exception
                MessageBox.Show("เกิดข้อผิดพลาดในการเชื่อมต่อฐานข้อมูล: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub SaveIncome(connection As OleDbConnection, transaction As OleDbTransaction)
        Dim incomeName As String = $"ชำระค่างวดจากสัญญา: {txtContractId.Text}"
        Dim incomeDetail As String = $"ชำระเงินจากผู้กู้: {txtBorrowerName.Text}"
        Dim incomeDate As Date = dtpPaymentDate.Value
        Dim incomeAmount As Decimal = Decimal.Parse(txtPaymentAmount.Text)
        Dim accountId As String = cbAccount.SelectedValue.ToString()

        Dim strSQL As String = "INSERT INTO Income (inc_name, inc_detail, inc_description, inc_date, inc_amount, acc_id) " &
                               "VALUES (@inc_name, @inc_detail, @inc_description, @inc_date, @inc_amount, @acc_id)"
        Using cmd As New OleDbCommand(strSQL, connection, transaction)
            cmd.Parameters.AddWithValue("@inc_name", incomeName)
            cmd.Parameters.AddWithValue("@inc_detail", incomeDetail)
            cmd.Parameters.AddWithValue("@inc_description", incomeDetail)
            cmd.Parameters.AddWithValue("@inc_date", incomeDate)
            cmd.Parameters.AddWithValue("@inc_amount", incomeAmount)
            cmd.Parameters.AddWithValue("@acc_id", accountId)
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub UpdateContractBalance(connection As OleDbConnection, transaction As OleDbTransaction, contractId As String, paymentAmount As Decimal)
        If String.IsNullOrEmpty(contractId) Then
            Throw New Exception("ไม่พบรหัสสัญญา") ' Contract ID not found
        End If

        Dim contractAmount As Decimal = 0
        Dim totalPaid As Decimal = 0

        ' Retrieve the contract amount
        Dim getContractAmountSQL As String = "SELECT con_amount FROM Contract WHERE con_id = @con_id"
        Using cmdGetContractAmount As New OleDbCommand(getContractAmountSQL, connection, transaction)
            cmdGetContractAmount.Parameters.AddWithValue("@con_id", contractId)
            Dim result = cmdGetContractAmount.ExecuteScalar()
            If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                contractAmount = Convert.ToDecimal(result)
            Else
                Throw New Exception("ไม่พบข้อมูลสัญญา") ' Contract data not found
            End If
        End Using

        ' Retrieve the total amount paid
        Dim getTotalPaidSQL As String = "SELECT IIf(SUM(payment_amount) Is Null, 0, SUM(payment_amount)) AS total_paid FROM Payment WHERE con_id = @con_id"
        Using cmdGetTotalPaid As New OleDbCommand(getTotalPaidSQL, connection, transaction)
            cmdGetTotalPaid.Parameters.AddWithValue("@con_id", contractId)
            Dim result = cmdGetTotalPaid.ExecuteScalar()
            If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                totalPaid = Convert.ToDecimal(result)
            End If
        End Using

        ' Calculate the new total paid and remaining balance
        Dim newTotalPaid As Decimal = totalPaid + paymentAmount
        Dim remainingBalance As Decimal = contractAmount - newTotalPaid

        If remainingBalance < 0 Then
            Throw New Exception($"ยอดชำระเกินยอดตามสัญญา ยอดคงเหลือตามสัญญา: {(contractAmount - totalPaid):N2} บาท")
        End If

        ' Check if PaymentId is selected
        Dim selectedInstallment = CType(cbInstallment.SelectedItem, InstallmentItem)
        If selectedInstallment Is Nothing Then
            Throw New Exception("ไม่พบการเลือกงวดการชำระเงิน") ' No installment selected
        End If

        ' Update payment details
        Dim updatePaymentSQL As String = "UPDATE Payment SET payment_amount = @payment_amount WHERE payment_id = @payment_id"
        Using cmdUpdatePayment As New OleDbCommand(updatePaymentSQL, connection, transaction)
            cmdUpdatePayment.Parameters.AddWithValue("@payment_amount", paymentAmount)
            cmdUpdatePayment.Parameters.AddWithValue("@payment_id", selectedInstallment.PaymentId)
            Try
                Dim rowsAffected = cmdUpdatePayment.ExecuteNonQuery()
                If rowsAffected = 0 Then
                    Throw New Exception("ไม่มีข้อมูลการชำระเงินที่ตรงกับ PaymentId") ' No matching payment data
                End If
            Catch ex As OleDbException
                Throw New Exception("เกิดข้อผิดพลาดในการอัพเดทข้อมูลการชำระเงิน: " & ex.Message) ' Error updating payment info
            End Try
        End Using

        ' Display payment summary
        MessageBox.Show($"ชำระเงินแล้ว: {paymentAmount:N2} บาท" & vbNewLine &
                    $"ยอดคงเหลือ: {remainingBalance:N2} บาท",
                    "สรุปการชำระเงิน", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub SavePayment(connection As OleDbConnection, transaction As OleDbTransaction)
        If cbInstallment.SelectedItem Is Nothing Then
            Throw New Exception("กรุณาเลือกงวดการชำระ")
        End If

        Dim selectedInstallment As InstallmentItem = DirectCast(cbInstallment.SelectedItem, InstallmentItem)
        Dim paymentId As Integer = selectedInstallment.PaymentId
        Dim paymentDate As Date = dtpPaymentDate.Value
        Dim paymentAmount As Decimal = selectedInstallment.PaymentAmount
        Dim statusId As Integer

        If cbPaymentStatus.SelectedValue Is Nothing Then
            Throw New Exception("กรุณาเลือกสถานะการชำระเงิน")
        End If
        statusId = CInt(cbPaymentStatus.SelectedValue)

        ' อัพเดทข้อมูลการชำระเงิน
        Dim updatePaymentSQL As String = "UPDATE Payment SET payment_date = @payment_date, status_id = @status_id WHERE payment_id = @payment_id"
        Using cmdUpdatePayment As New OleDbCommand(updatePaymentSQL, connection, transaction)
            cmdUpdatePayment.Parameters.AddWithValue("@payment_date", paymentDate)
            cmdUpdatePayment.Parameters.AddWithValue("@status_id", statusId)
            cmdUpdatePayment.Parameters.AddWithValue("@payment_id", paymentId)

            Try
                cmdUpdatePayment.ExecuteNonQuery()
            Catch ex As OleDbException
                Throw New Exception("เกิดข้อผิดพลาดในการบันทึกข้อมูลการชำระเงิน: " & ex.Message)
            End Try
        End Using

        ' ถ้าสถานะเป็น "ชำระแล้ว" ให้อัพเดทยอดการชำระเงิน
        If statusId = 2 Then ' สมมติว่า status_id 2 คือ "ชำระแล้ว"
            UpdateContractBalance(connection, transaction, txtContractId.Text, paymentAmount)
        End If
    End Sub

    Private Function GetRemainingBalance(connection As OleDbConnection, transaction As OleDbTransaction, contractId As String) As Decimal
        Dim strSQL As String = "SELECT con_amount - IIf(SUM(payment_amount) Is Null, 0, SUM(payment_amount)) AS remaining_balance " &
                               "FROM Contract LEFT JOIN Payment ON Contract.con_id = Payment.con_id " &
                               "WHERE Contract.con_id = @con_id GROUP BY Contract.con_amount"
        Using cmd As New OleDbCommand(strSQL, connection, transaction)
            cmd.Parameters.AddWithValue("@con_id", contractId)
            Dim result = cmd.ExecuteScalar()
            If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                Return Convert.ToDecimal(result)
            Else
                Throw New Exception("ไม่พบข้อมูลยอดคงเหลือของสัญญา")
            End If
        End Using
    End Function

    Private Function ValidateInput() As Boolean
        If String.IsNullOrEmpty(txtContractId.Text) OrElse
           String.IsNullOrEmpty(txtPaymentAmount.Text) OrElse
           cbInstallment.SelectedIndex = -1 OrElse
           cbPaymentStatus.SelectedIndex = -1 OrElse
           cbAccount.SelectedIndex = -1 Then
            MessageBox.Show("กรุณากรอกข้อมูลให้ครบถ้วน", "ข้อมูลไม่ครบ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Dim paymentAmount As Decimal
        If Decimal.TryParse(txtPaymentAmount.Text, paymentAmount) Then
            Using connection As New OleDbConnection(connectionString)
                connection.Open()
                Using transaction As OleDbTransaction = connection.BeginTransaction()
                    Try
                        Dim remainingBalance = GetRemainingBalance(connection, transaction, txtContractId.Text)
                        If paymentAmount > remainingBalance Then
                            MessageBox.Show($"ยอดชำระเกินยอดคงเหลือตามสัญญา ยอดคงเหลือ: {remainingBalance:N2} บาท", "ข้อมูลไม่ถูกต้อง", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Return False
                        End If
                    Catch ex As Exception
                        MessageBox.Show("เกิดข้อผิดพลาดในการตรวจสอบยอดคงเหลือ: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    Finally
                        transaction.Rollback()
                    End Try
                End Using
            End Using
        Else
            MessageBox.Show("กรุณากรอกจำนวนเงินให้ถูกต้อง", "ข้อมูลไม่ถูกต้อง", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    Private Sub ClearForm()
        txtContractId.Clear()
        txtBorrowerName.Clear()
        txtPaymentAmount.Clear()
        cbInstallment.Items.Clear()
        cbPaymentStatus.SelectedIndex = -1
        cbAccount.SelectedIndex = -1
        dtpPaymentDate.Value = Date.Today
    End Sub

End Class
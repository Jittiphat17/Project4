﻿Imports System.Data.OleDb

Public Class frmMemberResign
    Private Conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\db_test.mdb")

    Private Sub frmMemberResign_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ตั้งค่า TextAlign ให้กับ TextBox ที่ต้องการ
        txtBeforeTotalSaving.TextAlign = HorizontalAlignment.Right
        txtTotalSaving.TextAlign = HorizontalAlignment.Right
        txtLoanAccount1.TextAlign = HorizontalAlignment.Right
        txtLoanSaving.TextAlign = HorizontalAlignment.Right
        txtLoanPublic.TextAlign = HorizontalAlignment.Right
        txtTotalLoan.TextAlign = HorizontalAlignment.Right

        LoadMemberData() ' โหลดข้อมูลสมาชิกเพื่อทำ AutoComplete
    End Sub


    Private Sub LoadMemberData()
        Try
            Conn.Open()
            Dim query As String = "SELECT m_name FROM Member"
            Dim cmd As New OleDbCommand(query, Conn)
            Dim reader As OleDbDataReader = cmd.ExecuteReader()

            Dim autoComplete As New AutoCompleteStringCollection()

            While reader.Read()
                autoComplete.Add(reader("m_name").ToString())
            End While

            txtSearchMember.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txtSearchMember.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtSearchMember.AutoCompleteCustomSource = autoComplete
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการโหลดข้อมูลสมาชิก: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub txtSearchMember_TextChanged(sender As Object, e As EventArgs) Handles txtSearchMember.TextChanged
        If txtSearchMember.Text.Length > 0 Then
            SearchMemberDetails(txtSearchMember.Text)
        End If
    End Sub

    Private Sub SearchMemberDetails(memberName As String)
        Try
            Conn.Open()

            ' ดึงข้อมูลเงินฝากจากบัญชีสัจจะ
            Dim queryIncome As String = "SELECT SUM(inc_amount) FROM Income WHERE inc_name = @memberName AND acc_id = 'ACC002'"
            Dim cmdIncome As New OleDbCommand(queryIncome, Conn)
            cmdIncome.Parameters.AddWithValue("@memberName", memberName)
            Dim incomeResult As Object = cmdIncome.ExecuteScalar()

            If IsDBNull(incomeResult) OrElse incomeResult Is Nothing Then
                txtBeforeTotalSaving.Text = "0.00" ' แสดงยอดเงินก่อนรวม
                txtTotalSaving.Text = "0.00" ' แสดงยอดเงินรวม (ในกรณีนี้คือค่าเดียวกัน)
            Else
                txtBeforeTotalSaving.Text = Convert.ToDecimal(incomeResult).ToString("N2") ' แสดงยอดเงินก่อนรวม
                txtTotalSaving.Text = txtBeforeTotalSaving.Text ' แสดงยอดเงินรวม
            End If

            ' ดึงข้อมูลสัญญาของสมาชิก
            Dim queryContracts As String = "SELECT con_id, acc_id, con_amount FROM Contract WHERE m_id = (SELECT m_id FROM Member WHERE m_name = @memberName)"
            Dim cmdContracts As New OleDbCommand(queryContracts, Conn)
            cmdContracts.Parameters.AddWithValue("@memberName", memberName)
            Dim contractReader As OleDbDataReader = cmdContracts.ExecuteReader()

            ' กำหนดค่าเริ่มต้นสำหรับยอดเงินกู้
            Dim totalLoanAccount1 As Decimal = 0
            Dim totalLoanSaving As Decimal = 0
            Dim totalLoanPublic As Decimal = 0

            While contractReader.Read()
                Dim contractId As Integer = contractReader("con_id")
                Dim accId As String = contractReader("acc_id").ToString()

                ' คำนวณยอดเงินกู้แยกตามประเภทบัญชี
                If accId = "ACC001" Then
                    totalLoanAccount1 += Convert.ToDecimal(contractReader("con_amount"))
                ElseIf accId = "ACC002" Then
                    totalLoanSaving += Convert.ToDecimal(contractReader("con_amount"))
                ElseIf accId = "ACC003" Then
                    totalLoanPublic += Convert.ToDecimal(contractReader("con_amount"))
                End If
            End While
            contractReader.Close()

            ' แสดงยอดเงินกู้ใน TextBox ที่เกี่ยวข้อง
            txtLoanAccount1.Text = totalLoanAccount1.ToString("N2")
            txtLoanSaving.Text = totalLoanSaving.ToString("N2")
            txtLoanPublic.Text = totalLoanPublic.ToString("N2")

            ' คำนวณยอดรวมของเงินกู้
            Dim totalLoan As Decimal = totalLoanAccount1 + totalLoanSaving + totalLoanPublic
            txtTotalLoan.Text = totalLoan.ToString("N2")

        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการดึงข้อมูล: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Conn.Close()
        End Try
    End Sub

End Class
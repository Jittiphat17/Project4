Imports System.Data.OleDb

Public Class frmIncome
    ' เชื่อมต่อกับฐานข้อมูล Access
    Private Conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\db_test.mdb")

    Private Sub frmIncome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ตั้งค่า DataGridView
        SetupDataGridView()
        LoadIncomeTypes()
        LoadContractNumbers() ' โหลดเลขที่สัญญา
    End Sub

    Private Sub SetupDataGridView()
        ' เพิ่มคอลัมน์ ComboBox สำหรับประเภทของรายรับ
        Dim colIncomeType As New DataGridViewComboBoxColumn()
        colIncomeType.HeaderText = "ประเภทของรายรับ"
        colIncomeType.Name = "IncomeType"
        colIncomeType.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvIncomeDetails.Columns.Add(colIncomeType)

        ' เพิ่มคอลัมน์สำหรับจำนวนเงิน
        Dim colAmount As New DataGridViewTextBoxColumn()
        colAmount.HeaderText = "จำนวนเงิน"
        colAmount.Name = "Amount"
        colAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        colAmount.DefaultCellStyle.Format = "N2"
        colAmount.ValueType = GetType(Decimal)
        dgvIncomeDetails.Columns.Add(colAmount)

        ' เพิ่มคอลัมน์สำหรับหมายเหตุ
        Dim colRemarks As New DataGridViewTextBoxColumn()
        colRemarks.HeaderText = "หมายเหตุ"
        colRemarks.Name = "Remarks"
        colRemarks.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvIncomeDetails.Columns.Add(colRemarks)

        ' เพิ่มคอลัมน์ ComboBox สำหรับเลขที่สัญญา
        Dim colContractNumber As New DataGridViewComboBoxColumn()
        colContractNumber.HeaderText = "เลขที่สัญญา"
        colContractNumber.Name = "ContractNumber"
        colContractNumber.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvIncomeDetails.Columns.Add(colContractNumber)

        ' ตั้งค่าเพิ่มเติมให้ DataGridView
        dgvIncomeDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvIncomeDetails.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvIncomeDetails.RowTemplate.Height = 30
        dgvIncomeDetails.AllowUserToAddRows = True
    End Sub

    Private Sub LoadIncomeTypes()
        Try
            Conn.Open()
            Dim incomeTypeColumn As DataGridViewComboBoxColumn = CType(dgvIncomeDetails.Columns("IncomeType"), DataGridViewComboBoxColumn)

            ' เพิ่มรายการใน ComboBox สำหรับประเภทของรายรับ
            incomeTypeColumn.Items.Add("เงินต้น")
            incomeTypeColumn.Items.Add("ดอกเบี้ย")
            incomeTypeColumn.Items.Add("เงินสำรอง")
            incomeTypeColumn.Items.Add("เงินหุ้น")
            incomeTypeColumn.Items.Add("ค่าธรรมเนียม")
            incomeTypeColumn.Items.Add("เงินบริจาค")
            incomeTypeColumn.Items.Add("เงินสนับสนุน")
            incomeTypeColumn.Items.Add("เงินกู้")
            incomeTypeColumn.Items.Add("ค่าธรรมเนียมแรกเข้า")
            incomeTypeColumn.Items.Add("อื่น ๆ")

        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการโหลดข้อมูลประเภทเงินฝาก: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub LoadContractNumbers()
        Try
            Conn.Open()
            Dim query As String = "SELECT con_id FROM Contract"
            Dim cmd As New OleDbCommand(query, Conn)
            Dim reader As OleDbDataReader = cmd.ExecuteReader()

            Dim contractNumberColumn As DataGridViewComboBoxColumn = CType(dgvIncomeDetails.Columns("ContractNumber"), DataGridViewComboBoxColumn)

            While reader.Read()
                contractNumberColumn.Items.Add(reader("con_id").ToString())
            End While
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการโหลดข้อมูลเลขที่สัญญา: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Conn.Close()
        End Try
    End Sub


    Private Sub CalculateTotalAmount()
        Dim totalAmount As Decimal = 0

        ' คำนวณผลรวมของจำนวนเงินใน DataGridView
        For Each row As DataGridViewRow In dgvIncomeDetails.Rows
            If Not row.IsNewRow Then
                Dim amount As Decimal
                If Decimal.TryParse(row.Cells("Amount").Value?.ToString(), amount) Then
                    totalAmount += amount
                End If
            End If
        Next

        ' แสดงผลรวมใน Label
        lblTotalAmount.Text = totalAmount.ToString("N2")
    End Sub

    ' เรียกคำนวณผลรวมเมื่อมีการเปลี่ยนแปลงข้อมูลใน DataGridView
    Private Sub dgvIncomeDetails_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvIncomeDetails.CellValueChanged
        CalculateTotalAmount()
    End Sub

    ' เรียกคำนวณผลรวมเมื่อมีการลบแถวใน DataGridView
    Private Sub dgvIncomeDetails_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgvIncomeDetails.RowsRemoved
        CalculateTotalAmount()
    End Sub

    ' จัดการข้อผิดพลาดใน DataGridView เมื่อมีการกรอกข้อมูลที่ไม่ถูกต้องหรือมีปัญหาในการฟอร์แมต
    Private Sub dgvIncomeDetails_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvIncomeDetails.DataError
        If e.Context = DataGridViewDataErrorContexts.Formatting Or e.Context = DataGridViewDataErrorContexts.Display Then
            MessageBox.Show("เกิดข้อผิดพลาดในการฟอร์แมตข้อมูลหรือการแสดงผล: " & e.Exception.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            MessageBox.Show("เกิดข้อผิดพลาด: " & e.Exception.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        e.ThrowException = False ' หยุดการขว้างข้อผิดพลาดเพิ่มเติม
    End Sub

    ' ฟังก์ชันสำหรับลบแถวที่เลือกใน DataGridView
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' ตรวจสอบว่ามีแถวที่ถูกเลือกหรือไม่
        If dgvIncomeDetails.SelectedRows.Count > 0 Then
            ' ลบแถวที่ถูกเลือก
            For Each row As DataGridViewRow In dgvIncomeDetails.SelectedRows
                If Not row.IsNewRow Then
                    dgvIncomeDetails.Rows.Remove(row)
                End If
            Next
        Else
            MessageBox.Show("กรุณาเลือกแถวที่ต้องการลบ", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    ' ฟังก์ชันสำหรับบันทึกข้อมูลเมื่อค่าของ lblTotalAmount และ txtAmount เท่ากัน
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' แปลงค่าใน lblTotalAmount และ txtAmount ให้เป็น Decimal ก่อนเปรียบเทียบ
        Dim totalAmount As Decimal
        Dim inputAmount As Decimal

        ' ลองแปลงค่าจาก lblTotalAmount และ txtAmount
        If Decimal.TryParse(lblTotalAmount.Text, totalAmount) AndAlso Decimal.TryParse(txtAmount.Text, inputAmount) Then
            ' ตรวจสอบว่าค่าทั้งสองเท่ากันหรือไม่
            If totalAmount = inputAmount Then
                ' สามารถบันทึกข้อมูลได้
                SaveData() ' ฟังก์ชันสำหรับการบันทึกข้อมูล
            Else
                ' แสดงข้อความแจ้งเตือนว่าค่าไม่เท่ากัน
                MessageBox.Show("จำนวนเงินรวมไม่ตรงกับจำนวนเงินที่ระบุ", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            ' แสดงข้อความแจ้งเตือนว่ามีข้อผิดพลาดในการแปลงค่า
            MessageBox.Show("กรุณากรอกจำนวนเงินที่ถูกต้อง", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' ฟังก์ชันสำหรับการบันทึกข้อมูล
    Private Sub SaveData()
        ' โค้ดสำหรับการบันทึกข้อมูลลงฐานข้อมูลหรืออื่น ๆ
        MessageBox.Show("บันทึกข้อมูลสำเร็จ", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class

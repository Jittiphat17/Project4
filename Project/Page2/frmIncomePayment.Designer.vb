<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmIncomePayment
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblContractId = New System.Windows.Forms.Label()
        Me.txtContractId = New System.Windows.Forms.TextBox()
        Me.lblBorrowerName = New System.Windows.Forms.Label()
        Me.txtBorrowerName = New System.Windows.Forms.TextBox()
        Me.lblInstallment = New System.Windows.Forms.Label()
        Me.cbInstallment = New System.Windows.Forms.ComboBox()
        Me.lblPaymentDate = New System.Windows.Forms.Label()
        Me.dtpPaymentDate = New System.Windows.Forms.DateTimePicker()
        Me.lblPaymentAmount = New System.Windows.Forms.Label()
        Me.txtPaymentAmount = New System.Windows.Forms.TextBox()
        Me.lblPaymentStatus = New System.Windows.Forms.Label()
        Me.cbPaymentStatus = New System.Windows.Forms.ComboBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblAccount = New System.Windows.Forms.Label()
        Me.cbAccount = New System.Windows.Forms.ComboBox()
        Me.btnSearchContract = New Guna.UI2.WinForms.Guna2Button()
        Me.SuspendLayout()
        '
        'lblContractId
        '
        Me.lblContractId.AutoSize = True
        Me.lblContractId.Location = New System.Drawing.Point(12, 20)
        Me.lblContractId.Name = "lblContractId"
        Me.lblContractId.Size = New System.Drawing.Size(63, 13)
        Me.lblContractId.TabIndex = 0
        Me.lblContractId.Text = "เลขที่สัญญา:"
        '
        'txtContractId
        '
        Me.txtContractId.Location = New System.Drawing.Point(120, 17)
        Me.txtContractId.Name = "txtContractId"
        Me.txtContractId.Size = New System.Drawing.Size(200, 20)
        Me.txtContractId.TabIndex = 1
        '
        'lblBorrowerName
        '
        Me.lblBorrowerName.AutoSize = True
        Me.lblBorrowerName.Location = New System.Drawing.Point(12, 60)
        Me.lblBorrowerName.Name = "lblBorrowerName"
        Me.lblBorrowerName.Size = New System.Drawing.Size(37, 13)
        Me.lblBorrowerName.TabIndex = 2
        Me.lblBorrowerName.Text = "ชื่อผู้กู้:"
        '
        'txtBorrowerName
        '
        Me.txtBorrowerName.Location = New System.Drawing.Point(120, 57)
        Me.txtBorrowerName.Name = "txtBorrowerName"
        Me.txtBorrowerName.Size = New System.Drawing.Size(200, 20)
        Me.txtBorrowerName.TabIndex = 3
        '
        'lblInstallment
        '
        Me.lblInstallment.AutoSize = True
        Me.lblInstallment.Location = New System.Drawing.Point(12, 100)
        Me.lblInstallment.Name = "lblInstallment"
        Me.lblInstallment.Size = New System.Drawing.Size(69, 13)
        Me.lblInstallment.TabIndex = 4
        Me.lblInstallment.Text = "งวดการชำระ:"
        '
        'cbInstallment
        '
        Me.cbInstallment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbInstallment.FormattingEnabled = True
        Me.cbInstallment.Location = New System.Drawing.Point(120, 97)
        Me.cbInstallment.Name = "cbInstallment"
        Me.cbInstallment.Size = New System.Drawing.Size(200, 21)
        Me.cbInstallment.TabIndex = 5
        '
        'lblPaymentDate
        '
        Me.lblPaymentDate.AutoSize = True
        Me.lblPaymentDate.Location = New System.Drawing.Point(12, 140)
        Me.lblPaymentDate.Name = "lblPaymentDate"
        Me.lblPaymentDate.Size = New System.Drawing.Size(54, 13)
        Me.lblPaymentDate.TabIndex = 6
        Me.lblPaymentDate.Text = "วันที่ชำระ:"
        '
        'dtpPaymentDate
        '
        Me.dtpPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPaymentDate.Location = New System.Drawing.Point(120, 137)
        Me.dtpPaymentDate.Name = "dtpPaymentDate"
        Me.dtpPaymentDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpPaymentDate.TabIndex = 7
        '
        'lblPaymentAmount
        '
        Me.lblPaymentAmount.AutoSize = True
        Me.lblPaymentAmount.Location = New System.Drawing.Point(12, 180)
        Me.lblPaymentAmount.Name = "lblPaymentAmount"
        Me.lblPaymentAmount.Size = New System.Drawing.Size(91, 13)
        Me.lblPaymentAmount.TabIndex = 8
        Me.lblPaymentAmount.Text = "จำนวนเงินที่ชำระ:"
        '
        'txtPaymentAmount
        '
        Me.txtPaymentAmount.Location = New System.Drawing.Point(120, 177)
        Me.txtPaymentAmount.Name = "txtPaymentAmount"
        Me.txtPaymentAmount.Size = New System.Drawing.Size(200, 20)
        Me.txtPaymentAmount.TabIndex = 9
        '
        'lblPaymentStatus
        '
        Me.lblPaymentStatus.AutoSize = True
        Me.lblPaymentStatus.Location = New System.Drawing.Point(12, 220)
        Me.lblPaymentStatus.Name = "lblPaymentStatus"
        Me.lblPaymentStatus.Size = New System.Drawing.Size(82, 13)
        Me.lblPaymentStatus.TabIndex = 10
        Me.lblPaymentStatus.Text = "สถานะการชำระ:"
        '
        'cbPaymentStatus
        '
        Me.cbPaymentStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPaymentStatus.FormattingEnabled = True
        Me.cbPaymentStatus.Location = New System.Drawing.Point(120, 217)
        Me.cbPaymentStatus.Name = "cbPaymentStatus"
        Me.cbPaymentStatus.Size = New System.Drawing.Size(200, 21)
        Me.cbPaymentStatus.TabIndex = 11
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(120, 300)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(200, 23)
        Me.btnSave.TabIndex = 12
        Me.btnSave.Text = "บันทึก"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lblAccount
        '
        Me.lblAccount.AutoSize = True
        Me.lblAccount.Location = New System.Drawing.Point(12, 260)
        Me.lblAccount.Name = "lblAccount"
        Me.lblAccount.Size = New System.Drawing.Size(71, 13)
        Me.lblAccount.TabIndex = 13
        Me.lblAccount.Text = "บัญชีที่รับเงิน:"
        '
        'cbAccount
        '
        Me.cbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAccount.FormattingEnabled = True
        Me.cbAccount.Location = New System.Drawing.Point(120, 257)
        Me.cbAccount.Name = "cbAccount"
        Me.cbAccount.Size = New System.Drawing.Size(200, 21)
        Me.cbAccount.TabIndex = 14
        '
        'btnSearchContract
        '
        Me.btnSearchContract.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnSearchContract.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnSearchContract.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnSearchContract.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnSearchContract.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSearchContract.ForeColor = System.Drawing.Color.White
        Me.btnSearchContract.Location = New System.Drawing.Point(326, 20)
        Me.btnSearchContract.Name = "btnSearchContract"
        Me.btnSearchContract.Size = New System.Drawing.Size(93, 17)
        Me.btnSearchContract.TabIndex = 15
        Me.btnSearchContract.Text = "Guna2Button1"
        '
        'frmIncomePayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(480, 350)
        Me.Controls.Add(Me.btnSearchContract)
        Me.Controls.Add(Me.cbAccount)
        Me.Controls.Add(Me.lblAccount)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.cbPaymentStatus)
        Me.Controls.Add(Me.lblPaymentStatus)
        Me.Controls.Add(Me.txtPaymentAmount)
        Me.Controls.Add(Me.lblPaymentAmount)
        Me.Controls.Add(Me.dtpPaymentDate)
        Me.Controls.Add(Me.lblPaymentDate)
        Me.Controls.Add(Me.cbInstallment)
        Me.Controls.Add(Me.lblInstallment)
        Me.Controls.Add(Me.txtBorrowerName)
        Me.Controls.Add(Me.lblBorrowerName)
        Me.Controls.Add(Me.txtContractId)
        Me.Controls.Add(Me.lblContractId)
        Me.Name = "frmIncomePayment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "บันทึกรายรับและชำระเงิน"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblContractId As Label
    Friend WithEvents txtContractId As TextBox
    Friend WithEvents lblBorrowerName As Label
    Friend WithEvents txtBorrowerName As TextBox
    Friend WithEvents lblInstallment As Label
    Friend WithEvents cbInstallment As ComboBox
    Friend WithEvents lblPaymentDate As Label
    Friend WithEvents dtpPaymentDate As DateTimePicker
    Friend WithEvents lblPaymentAmount As Label
    Friend WithEvents txtPaymentAmount As TextBox
    Friend WithEvents lblPaymentStatus As Label
    Friend WithEvents cbPaymentStatus As ComboBox
    Friend WithEvents btnSave As Button
    Friend WithEvents lblAccount As Label
    Friend WithEvents cbAccount As ComboBox
    Friend WithEvents btnSearchContract As Guna.UI2.WinForms.Guna2Button
End Class

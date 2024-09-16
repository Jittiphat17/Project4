<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmIncome
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
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnCalculate = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.dgvIncomeDetails = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSearchContract = New Guna.UI2.WinForms.Guna2Button()
        Me.dtpBirth = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboDepositType = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtDetails = New System.Windows.Forms.TextBox()
        Me.txtDescrip = New System.Windows.Forms.TextBox()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.txtMemberID = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblTotalAmount = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtInid = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.dgvIncomeDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnClear.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnClear.Location = New System.Drawing.Point(726, 442)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(150, 75)
        Me.btnClear.TabIndex = 5
        Me.btnClear.Text = "ล้างข้อมูล"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'btnCalculate
        '
        Me.btnCalculate.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnCalculate.Font = New System.Drawing.Font("TH SarabunPSK", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCalculate.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnCalculate.Location = New System.Drawing.Point(570, 442)
        Me.btnCalculate.Name = "btnCalculate"
        Me.btnCalculate.Size = New System.Drawing.Size(150, 75)
        Me.btnCalculate.TabIndex = 6
        Me.btnCalculate.Text = "คำนวณ"
        Me.btnCalculate.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnSave.Font = New System.Drawing.Font("TH SarabunPSK", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSave.Location = New System.Drawing.Point(258, 442)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(150, 75)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "บันทึก"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'dgvIncomeDetails
        '
        Me.dgvIncomeDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvIncomeDetails.Location = New System.Drawing.Point(566, 82)
        Me.dgvIncomeDetails.Name = "dgvIncomeDetails"
        Me.dgvIncomeDetails.Size = New System.Drawing.Size(548, 301)
        Me.dgvIncomeDetails.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSearchContract)
        Me.GroupBox1.Controls.Add(Me.dtpBirth)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.cboDepositType)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.txtDescrip)
        Me.GroupBox1.Controls.Add(Me.txtAmount)
        Me.GroupBox1.Controls.Add(Me.txtMemberID)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("TH SarabunPSK", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 68)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(548, 368)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "สมาชิก"
        '
        'btnSearchContract
        '
        Me.btnSearchContract.BorderRadius = 10
        Me.btnSearchContract.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnSearchContract.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnSearchContract.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnSearchContract.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnSearchContract.Font = New System.Drawing.Font("FC Minimal", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearchContract.ForeColor = System.Drawing.Color.White
        Me.btnSearchContract.Location = New System.Drawing.Point(319, 30)
        Me.btnSearchContract.Name = "btnSearchContract"
        Me.btnSearchContract.Size = New System.Drawing.Size(120, 35)
        Me.btnSearchContract.TabIndex = 11
        Me.btnSearchContract.Text = "ค้นหาสัญญา"
        '
        'dtpBirth
        '
        Me.dtpBirth.BorderRadius = 10
        Me.dtpBirth.Checked = True
        Me.dtpBirth.FillColor = System.Drawing.Color.DarkSlateBlue
        Me.dtpBirth.Font = New System.Drawing.Font("FC Minimal", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpBirth.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dtpBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpBirth.Location = New System.Drawing.Point(116, 324)
        Me.dtpBirth.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpBirth.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpBirth.Name = "dtpBirth"
        Me.dtpBirth.Size = New System.Drawing.Size(197, 36)
        Me.dtpBirth.TabIndex = 10
        Me.dtpBirth.Value = New Date(2024, 9, 16, 20, 26, 3, 16)
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(65, 333)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(45, 24)
        Me.Label13.TabIndex = 9
        Me.Label13.Text = "วันที่ :"
        '
        'cboDepositType
        '
        Me.cboDepositType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDepositType.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDepositType.FormattingEnabled = True
        Me.cboDepositType.Location = New System.Drawing.Point(116, 246)
        Me.cboDepositType.Name = "cboDepositType"
        Me.cboDepositType.Size = New System.Drawing.Size(197, 32)
        Me.cboDepositType.TabIndex = 4
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtDetails)
        Me.GroupBox3.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(32, 75)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(426, 124)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "รายละเอียด"
        '
        'txtDetails
        '
        Me.txtDetails.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDetails.Location = New System.Drawing.Point(6, 21)
        Me.txtDetails.Multiline = True
        Me.txtDetails.Name = "txtDetails"
        Me.txtDetails.Size = New System.Drawing.Size(414, 97)
        Me.txtDetails.TabIndex = 1
        '
        'txtDescrip
        '
        Me.txtDescrip.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescrip.Location = New System.Drawing.Point(116, 205)
        Me.txtDescrip.Name = "txtDescrip"
        Me.txtDescrip.Size = New System.Drawing.Size(197, 31)
        Me.txtDescrip.TabIndex = 1
        '
        'txtAmount
        '
        Me.txtAmount.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount.Location = New System.Drawing.Point(116, 287)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(197, 31)
        Me.txtAmount.TabIndex = 1
        '
        'txtMemberID
        '
        Me.txtMemberID.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMemberID.Location = New System.Drawing.Point(116, 34)
        Me.txtMemberID.Name = "txtMemberID"
        Me.txtMemberID.Size = New System.Drawing.Size(197, 31)
        Me.txtMemberID.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(319, 293)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 24)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "บาท"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(30, 293)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 24)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "จำนวนเงิน :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(37, 211)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 24)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "คำอธิบาย :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(28, 252)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 24)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "เงินฝากเข้า :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(50, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "สมาชิก :"
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnDelete.Font = New System.Drawing.Font("TH SarabunPSK", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnDelete.Location = New System.Drawing.Point(410, 442)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(150, 75)
        Me.btnDelete.TabIndex = 8
        Me.btnDelete.Text = "ลบ"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("TH SarabunPSK", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(483, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(147, 71)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "รายรับ"
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.AutoSize = True
        Me.lblTotalAmount.Font = New System.Drawing.Font("TH SarabunPSK", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTotalAmount.Location = New System.Drawing.Point(107, 7)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(62, 39)
        Me.lblTotalAmount.TabIndex = 10
        Me.lblTotalAmount.Text = "0.00"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Panel1.Controls.Add(Me.lblTotalAmount)
        Me.Panel1.Location = New System.Drawing.Point(914, 389)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 47)
        Me.Panel1.TabIndex = 11
        '
        'txtInid
        '
        Me.txtInid.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtInid.Font = New System.Drawing.Font("TH SarabunPSK", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInid.Location = New System.Drawing.Point(972, 36)
        Me.txtInid.Multiline = True
        Me.txtInid.Name = "txtInid"
        Me.txtInid.ReadOnly = True
        Me.txtInid.Size = New System.Drawing.Size(139, 40)
        Me.txtInid.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(891, 45)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 24)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "เลขที่รายรับ"
        '
        'frmIncome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1126, 535)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtInid)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnCalculate)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.dgvIncomeDetails)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmIncome"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "รายรับ"
        CType(Me.dgvIncomeDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnClear As Button
    Friend WithEvents btnCalculate As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents dgvIncomeDetails As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cboDepositType As ComboBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtDetails As TextBox
    Friend WithEvents txtAmount As TextBox
    Friend WithEvents txtMemberID As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDescrip As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnDelete As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblTotalAmount As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtInid As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents dtpBirth As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents btnSearchContract As Guna.UI2.WinForms.Guna2Button
End Class
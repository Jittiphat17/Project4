<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditExpense
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dgvExpenses = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtExpenseAmount = New System.Windows.Forms.TextBox()
        Me.txtExpenseDescription = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbAccount = New System.Windows.Forms.ComboBox()
        Me.dtpExpenseDate = New System.Windows.Forms.DateTimePicker()
        Me.txtExpenseName = New System.Windows.Forms.TextBox()
        Me.txtExpenseID = New System.Windows.Forms.TextBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.dgvExpenseDetails = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDetailName = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDetailAmount = New System.Windows.Forms.TextBox()
        Me.txtDetailID = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        CType(Me.dgvExpenses, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvExpenseDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvExpenses
        '
        Me.dgvExpenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvExpenses.Location = New System.Drawing.Point(11, 73)
        Me.dgvExpenses.Name = "dgvExpenses"
        Me.dgvExpenses.Size = New System.Drawing.Size(400, 232)
        Me.dgvExpenses.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtExpenseAmount)
        Me.GroupBox1.Controls.Add(Me.txtExpenseDescription)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbAccount)
        Me.GroupBox1.Controls.Add(Me.dtpExpenseDate)
        Me.GroupBox1.Controls.Add(Me.txtExpenseName)
        Me.GroupBox1.Controls.Add(Me.txtExpenseID)
        Me.GroupBox1.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 311)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(804, 162)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "แก้ไขข้อมูลค่าใช้จ่าย"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(484, 45)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 24)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "จำนวนเงิน :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(491, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 24)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "คำอธิบาย :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(275, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 24)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "ชื่อผู้รับ :"
        '
        'txtExpenseAmount
        '
        Me.txtExpenseAmount.Location = New System.Drawing.Point(570, 42)
        Me.txtExpenseAmount.Name = "txtExpenseAmount"
        Me.txtExpenseAmount.Size = New System.Drawing.Size(145, 31)
        Me.txtExpenseAmount.TabIndex = 16
        '
        'txtExpenseDescription
        '
        Me.txtExpenseDescription.Location = New System.Drawing.Point(570, 100)
        Me.txtExpenseDescription.Name = "txtExpenseDescription"
        Me.txtExpenseDescription.Size = New System.Drawing.Size(106, 31)
        Me.txtExpenseDescription.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(287, 102)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 24)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "บัญชี :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(19, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 24)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "วันที่ทำรายการ :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(287, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 24)
        Me.Label4.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(28, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 24)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "เลขที่รายจ่าย :"
        '
        'cmbAccount
        '
        Me.cmbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAccount.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAccount.FormattingEnabled = True
        Me.cmbAccount.Location = New System.Drawing.Point(341, 99)
        Me.cmbAccount.Name = "cmbAccount"
        Me.cmbAccount.Size = New System.Drawing.Size(121, 32)
        Me.cmbAccount.TabIndex = 9
        '
        'dtpExpenseDate
        '
        Me.dtpExpenseDate.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpExpenseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpExpenseDate.Location = New System.Drawing.Point(128, 97)
        Me.dtpExpenseDate.Name = "dtpExpenseDate"
        Me.dtpExpenseDate.Size = New System.Drawing.Size(126, 31)
        Me.dtpExpenseDate.TabIndex = 8
        '
        'txtExpenseName
        '
        Me.txtExpenseName.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExpenseName.Location = New System.Drawing.Point(341, 42)
        Me.txtExpenseName.Name = "txtExpenseName"
        Me.txtExpenseName.Size = New System.Drawing.Size(100, 31)
        Me.txtExpenseName.TabIndex = 7
        '
        'txtExpenseID
        '
        Me.txtExpenseID.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExpenseID.Location = New System.Drawing.Point(128, 42)
        Me.txtExpenseID.Name = "txtExpenseID"
        Me.txtExpenseID.ReadOnly = True
        Me.txtExpenseID.Size = New System.Drawing.Size(100, 31)
        Me.txtExpenseID.TabIndex = 4
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnDelete.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnDelete.Location = New System.Drawing.Point(402, 645)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(193, 51)
        Me.btnDelete.TabIndex = 16
        Me.btnDelete.Text = "ลบ"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnSave.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSave.Location = New System.Drawing.Point(203, 645)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(193, 51)
        Me.btnSave.TabIndex = 17
        Me.btnSave.Text = "บันทึก"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'dgvExpenseDetails
        '
        Me.dgvExpenseDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvExpenseDetails.Location = New System.Drawing.Point(417, 73)
        Me.dgvExpenseDetails.Name = "dgvExpenseDetails"
        Me.dgvExpenseDetails.Size = New System.Drawing.Size(399, 232)
        Me.dgvExpenseDetails.TabIndex = 18
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtDetailName)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtDetailAmount)
        Me.GroupBox2.Controls.Add(Me.txtDetailID)
        Me.GroupBox2.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 479)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(804, 162)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "แก้ไขรายละเอียดค่าใช้จ่าย"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 50)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(114, 24)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "เลขที่รายละเอียด :"
        '
        'txtDetailName
        '
        Me.txtDetailName.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDetailName.Location = New System.Drawing.Point(128, 112)
        Me.txtDetailName.Name = "txtDetailName"
        Me.txtDetailName.Size = New System.Drawing.Size(100, 31)
        Me.txtDetailName.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(255, 50)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 24)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "จำนวนเงิน :"
        '
        'txtDetailAmount
        '
        Me.txtDetailAmount.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDetailAmount.Location = New System.Drawing.Point(341, 47)
        Me.txtDetailAmount.Name = "txtDetailAmount"
        Me.txtDetailAmount.Size = New System.Drawing.Size(100, 31)
        Me.txtDetailAmount.TabIndex = 7
        '
        'txtDetailID
        '
        Me.txtDetailID.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDetailID.Location = New System.Drawing.Point(128, 47)
        Me.txtDetailID.Name = "txtDetailID"
        Me.txtDetailID.ReadOnly = True
        Me.txtDetailID.Size = New System.Drawing.Size(100, 31)
        Me.txtDetailID.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(59, 115)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 24)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "รายการ :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("TH SarabunPSK", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(328, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(158, 39)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "แก้ไขค่าใช้จ่าย"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(721, 45)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(35, 24)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "บาท"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(447, 50)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(35, 24)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "บาท"
        '
        'frmEditExpense
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(828, 727)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.dgvExpenseDetails)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvExpenses)
        Me.Name = "frmEditExpense"
        Me.Text = "frmEditExpense"
        CType(Me.dgvExpenses, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvExpenseDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvExpenses As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbAccount As ComboBox
    Friend WithEvents dtpExpenseDate As DateTimePicker
    Friend WithEvents txtExpenseName As TextBox
    Friend WithEvents txtExpenseID As TextBox
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents dgvExpenseDetails As DataGridView
    Friend WithEvents txtExpenseDescription As TextBox
    Friend WithEvents txtExpenseAmount As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtDetailName As TextBox
    Friend WithEvents txtDetailAmount As TextBox
    Friend WithEvents txtDetailID As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
End Class

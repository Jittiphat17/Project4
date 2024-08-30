<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEditContract
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
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtContractID = New System.Windows.Forms.TextBox()
        Me.txtContractInterest = New System.Windows.Forms.TextBox()
        Me.txtContractAmount = New System.Windows.Forms.TextBox()
        Me.dtpContractDate = New System.Windows.Forms.DateTimePicker()
        Me.cmbAccount = New System.Windows.Forms.ComboBox()
        Me.dgvContracts = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbGuarantor1 = New System.Windows.Forms.ComboBox()
        Me.cmbGuarantor2 = New System.Windows.Forms.ComboBox()
        Me.cmbGuarantor3 = New System.Windows.Forms.ComboBox()
        CType(Me.dgvContracts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("TH SarabunPSK", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(680, 26)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(108, 38)
        Me.txtSearch.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(586, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 24)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "ค้นหาสัญญา :"
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnSave.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSave.Location = New System.Drawing.Point(201, 516)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(193, 51)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "บันทึก"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'txtContractID
        '
        Me.txtContractID.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContractID.Location = New System.Drawing.Point(128, 42)
        Me.txtContractID.Name = "txtContractID"
        Me.txtContractID.ReadOnly = True
        Me.txtContractID.Size = New System.Drawing.Size(100, 31)
        Me.txtContractID.TabIndex = 4
        '
        'txtContractInterest
        '
        Me.txtContractInterest.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContractInterest.Location = New System.Drawing.Point(630, 45)
        Me.txtContractInterest.Name = "txtContractInterest"
        Me.txtContractInterest.ReadOnly = True
        Me.txtContractInterest.Size = New System.Drawing.Size(100, 31)
        Me.txtContractInterest.TabIndex = 6
        '
        'txtContractAmount
        '
        Me.txtContractAmount.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContractAmount.Location = New System.Drawing.Point(370, 42)
        Me.txtContractAmount.Name = "txtContractAmount"
        Me.txtContractAmount.Size = New System.Drawing.Size(100, 31)
        Me.txtContractAmount.TabIndex = 7
        '
        'dtpContractDate
        '
        Me.dtpContractDate.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpContractDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpContractDate.Location = New System.Drawing.Point(128, 97)
        Me.dtpContractDate.Name = "dtpContractDate"
        Me.dtpContractDate.Size = New System.Drawing.Size(126, 31)
        Me.dtpContractDate.TabIndex = 8
        '
        'cmbAccount
        '
        Me.cmbAccount.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAccount.FormattingEnabled = True
        Me.cmbAccount.Location = New System.Drawing.Point(370, 99)
        Me.cmbAccount.Name = "cmbAccount"
        Me.cmbAccount.Size = New System.Drawing.Size(121, 32)
        Me.cmbAccount.TabIndex = 9
        '
        'dgvContracts
        '
        Me.dgvContracts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvContracts.Location = New System.Drawing.Point(12, 70)
        Me.dgvContracts.Name = "dgvContracts"
        Me.dgvContracts.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.dgvContracts.Size = New System.Drawing.Size(776, 232)
        Me.dgvContracts.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(37, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 24)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "เลขที่สัญญา :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(287, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 24)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "จำนวนเงิน :"
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
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(316, 102)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 24)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "บัญชี :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbGuarantor3)
        Me.GroupBox1.Controls.Add(Me.cmbGuarantor2)
        Me.GroupBox1.Controls.Add(Me.cmbGuarantor1)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbAccount)
        Me.GroupBox1.Controls.Add(Me.dtpContractDate)
        Me.GroupBox1.Controls.Add(Me.txtContractAmount)
        Me.GroupBox1.Controls.Add(Me.txtContractInterest)
        Me.GroupBox1.Controls.Add(Me.txtContractID)
        Me.GroupBox1.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 308)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(775, 202)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "แก้ไขข้อมูล"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(81, 149)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 24)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "ผู้ค้ำ :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(476, 45)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 24)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "บาท"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(561, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 24)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "ดอกเบี้ย :"
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnDelete.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnDelete.Location = New System.Drawing.Point(400, 516)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(193, 51)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "ลบ"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(325, 149)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 24)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "ผู้ค้ำ :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(539, 149)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 24)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "ผู้ค้ำ :"
        '
        'cmbGuarantor1
        '
        Me.cmbGuarantor1.FormattingEnabled = True
        Me.cmbGuarantor1.Location = New System.Drawing.Point(128, 146)
        Me.cmbGuarantor1.Name = "cmbGuarantor1"
        Me.cmbGuarantor1.Size = New System.Drawing.Size(121, 32)
        Me.cmbGuarantor1.TabIndex = 17
        '
        'cmbGuarantor2
        '
        Me.cmbGuarantor2.FormattingEnabled = True
        Me.cmbGuarantor2.Location = New System.Drawing.Point(370, 146)
        Me.cmbGuarantor2.Name = "cmbGuarantor2"
        Me.cmbGuarantor2.Size = New System.Drawing.Size(121, 32)
        Me.cmbGuarantor2.TabIndex = 17
        '
        'cmbGuarantor3
        '
        Me.cmbGuarantor3.FormattingEnabled = True
        Me.cmbGuarantor3.Location = New System.Drawing.Point(587, 146)
        Me.cmbGuarantor3.Name = "cmbGuarantor3"
        Me.cmbGuarantor3.Size = New System.Drawing.Size(121, 32)
        Me.cmbGuarantor3.TabIndex = 17
        '
        'frmEditContract
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(799, 579)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvContracts)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSearch)
        Me.Name = "frmEditContract"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmEditContract"
        CType(Me.dgvContracts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents txtContractID As TextBox
    Friend WithEvents txtContractInterest As TextBox
    Friend WithEvents txtContractAmount As TextBox
    Friend WithEvents dtpContractDate As DateTimePicker
    Friend WithEvents cmbAccount As ComboBox
    Friend WithEvents dgvContracts As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents btnDelete As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents cmbGuarantor1 As ComboBox
    Friend WithEvents cmbGuarantor3 As ComboBox
    Friend WithEvents cmbGuarantor2 As ComboBox
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEditIncome
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
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvIncome = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.txtIncomeName = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2GroupBox1 = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.cmbAccount = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.dtpIncomeDate = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.txtIncomeAmount = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btnSave = New Guna.UI2.WinForms.Guna2Button()
        Me.btnCancel = New Guna.UI2.WinForms.Guna2Button()
        Me.dgvIncomeDetails = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.Guna2GroupBox2 = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.txtIncomeID = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtDetailID = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtDetailName = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtDetailAmount = New Guna.UI2.WinForms.Guna2TextBox()
        CType(Me.dgvIncome, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2GroupBox1.SuspendLayout()
        CType(Me.dgvIncomeDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvIncome
        '
        Me.dgvIncome.AllowUserToAddRows = False
        Me.dgvIncome.AllowUserToDeleteRows = False
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.White
        Me.dgvIncome.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle13
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIncome.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvIncome.ColumnHeadersHeight = 50
        Me.dgvIncome.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvIncome.DefaultCellStyle = DataGridViewCellStyle15
        Me.dgvIncome.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvIncome.Location = New System.Drawing.Point(12, 12)
        Me.dgvIncome.Name = "dgvIncome"
        Me.dgvIncome.ReadOnly = True
        Me.dgvIncome.RowHeadersVisible = False
        Me.dgvIncome.Size = New System.Drawing.Size(430, 296)
        Me.dgvIncome.TabIndex = 0
        Me.dgvIncome.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvIncome.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.dgvIncome.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.dgvIncome.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.dgvIncome.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.dgvIncome.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.dgvIncome.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvIncome.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvIncome.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvIncome.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvIncome.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.dgvIncome.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.dgvIncome.ThemeStyle.HeaderStyle.Height = 50
        Me.dgvIncome.ThemeStyle.ReadOnly = True
        Me.dgvIncome.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvIncome.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvIncome.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvIncome.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.dgvIncome.ThemeStyle.RowsStyle.Height = 22
        Me.dgvIncome.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvIncome.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'txtIncomeName
        '
        Me.txtIncomeName.BorderRadius = 10
        Me.txtIncomeName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtIncomeName.DefaultText = ""
        Me.txtIncomeName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtIncomeName.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtIncomeName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtIncomeName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtIncomeName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtIncomeName.Font = New System.Drawing.Font("FC Minimal", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIncomeName.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtIncomeName.Location = New System.Drawing.Point(561, 115)
        Me.txtIncomeName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtIncomeName.Name = "txtIncomeName"
        Me.txtIncomeName.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtIncomeName.PlaceholderText = ""
        Me.txtIncomeName.SelectedText = ""
        Me.txtIncomeName.Size = New System.Drawing.Size(172, 38)
        Me.txtIncomeName.TabIndex = 1
        '
        'Guna2GroupBox1
        '
        Me.Guna2GroupBox1.BackColor = System.Drawing.Color.White
        Me.Guna2GroupBox1.Controls.Add(Me.txtIncomeID)
        Me.Guna2GroupBox1.Controls.Add(Me.cmbAccount)
        Me.Guna2GroupBox1.Controls.Add(Me.dtpIncomeDate)
        Me.Guna2GroupBox1.Controls.Add(Me.txtIncomeAmount)
        Me.Guna2GroupBox1.Controls.Add(Me.txtIncomeName)
        Me.Guna2GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.Guna2GroupBox1.Location = New System.Drawing.Point(12, 314)
        Me.Guna2GroupBox1.Name = "Guna2GroupBox1"
        Me.Guna2GroupBox1.Size = New System.Drawing.Size(866, 214)
        Me.Guna2GroupBox1.TabIndex = 2
        Me.Guna2GroupBox1.Text = "Guna2GroupBox1"
        '
        'cmbAccount
        '
        Me.cmbAccount.BackColor = System.Drawing.Color.Transparent
        Me.cmbAccount.BorderRadius = 10
        Me.cmbAccount.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAccount.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbAccount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbAccount.Font = New System.Drawing.Font("FC Minimal", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAccount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cmbAccount.ItemHeight = 30
        Me.cmbAccount.Location = New System.Drawing.Point(48, 60)
        Me.cmbAccount.Name = "cmbAccount"
        Me.cmbAccount.Size = New System.Drawing.Size(172, 36)
        Me.cmbAccount.TabIndex = 3
        '
        'dtpIncomeDate
        '
        Me.dtpIncomeDate.BorderRadius = 10
        Me.dtpIncomeDate.Checked = True
        Me.dtpIncomeDate.FillColor = System.Drawing.Color.LightGray
        Me.dtpIncomeDate.Font = New System.Drawing.Font("FC Minimal", 15.75!, System.Drawing.FontStyle.Bold)
        Me.dtpIncomeDate.ForeColor = System.Drawing.Color.Black
        Me.dtpIncomeDate.Format = System.Windows.Forms.DateTimePickerFormat.[Long]
        Me.dtpIncomeDate.Location = New System.Drawing.Point(312, 49)
        Me.dtpIncomeDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpIncomeDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpIncomeDate.Name = "dtpIncomeDate"
        Me.dtpIncomeDate.Size = New System.Drawing.Size(285, 47)
        Me.dtpIncomeDate.TabIndex = 2
        Me.dtpIncomeDate.Value = New Date(2024, 9, 10, 17, 56, 37, 496)
        '
        'txtIncomeAmount
        '
        Me.txtIncomeAmount.BorderRadius = 10
        Me.txtIncomeAmount.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtIncomeAmount.DefaultText = ""
        Me.txtIncomeAmount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtIncomeAmount.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtIncomeAmount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtIncomeAmount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtIncomeAmount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtIncomeAmount.Font = New System.Drawing.Font("FC Minimal", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIncomeAmount.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtIncomeAmount.Location = New System.Drawing.Point(312, 115)
        Me.txtIncomeAmount.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtIncomeAmount.Name = "txtIncomeAmount"
        Me.txtIncomeAmount.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtIncomeAmount.PlaceholderText = ""
        Me.txtIncomeAmount.SelectedText = ""
        Me.txtIncomeAmount.Size = New System.Drawing.Size(172, 38)
        Me.txtIncomeAmount.TabIndex = 1
        '
        'btnSave
        '
        Me.btnSave.Animated = True
        Me.btnSave.BorderRadius = 10
        Me.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnSave.Font = New System.Drawing.Font("FC Minimal", 15.75!, System.Drawing.FontStyle.Bold)
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(202, 715)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(180, 45)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "บันทึก"
        '
        'btnCancel
        '
        Me.btnCancel.Animated = True
        Me.btnCancel.BorderRadius = 10
        Me.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnCancel.Font = New System.Drawing.Font("FC Minimal", 15.75!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(388, 715)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(180, 45)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "ยกเลิก"
        '
        'dgvIncomeDetails
        '
        Me.dgvIncomeDetails.AllowUserToAddRows = False
        Me.dgvIncomeDetails.AllowUserToDeleteRows = False
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.White
        Me.dgvIncomeDetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle16
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIncomeDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.dgvIncomeDetails.ColumnHeadersHeight = 50
        Me.dgvIncomeDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvIncomeDetails.DefaultCellStyle = DataGridViewCellStyle18
        Me.dgvIncomeDetails.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvIncomeDetails.Location = New System.Drawing.Point(448, 12)
        Me.dgvIncomeDetails.Name = "dgvIncomeDetails"
        Me.dgvIncomeDetails.ReadOnly = True
        Me.dgvIncomeDetails.RowHeadersVisible = False
        Me.dgvIncomeDetails.Size = New System.Drawing.Size(430, 296)
        Me.dgvIncomeDetails.TabIndex = 0
        Me.dgvIncomeDetails.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvIncomeDetails.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.dgvIncomeDetails.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.dgvIncomeDetails.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.dgvIncomeDetails.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.dgvIncomeDetails.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.dgvIncomeDetails.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvIncomeDetails.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvIncomeDetails.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvIncomeDetails.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvIncomeDetails.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.dgvIncomeDetails.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.dgvIncomeDetails.ThemeStyle.HeaderStyle.Height = 50
        Me.dgvIncomeDetails.ThemeStyle.ReadOnly = True
        Me.dgvIncomeDetails.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvIncomeDetails.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvIncomeDetails.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvIncomeDetails.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.dgvIncomeDetails.ThemeStyle.RowsStyle.Height = 22
        Me.dgvIncomeDetails.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvIncomeDetails.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'Guna2GroupBox2
        '
        Me.Guna2GroupBox2.Controls.Add(Me.txtDetailAmount)
        Me.Guna2GroupBox2.Controls.Add(Me.txtDetailName)
        Me.Guna2GroupBox2.Controls.Add(Me.txtDetailID)
        Me.Guna2GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Guna2GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.Guna2GroupBox2.Location = New System.Drawing.Point(12, 534)
        Me.Guna2GroupBox2.Name = "Guna2GroupBox2"
        Me.Guna2GroupBox2.Size = New System.Drawing.Size(866, 164)
        Me.Guna2GroupBox2.TabIndex = 4
        Me.Guna2GroupBox2.Text = "Guna2GroupBox2"
        '
        'txtIncomeID
        '
        Me.txtIncomeID.BorderRadius = 10
        Me.txtIncomeID.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtIncomeID.DefaultText = ""
        Me.txtIncomeID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtIncomeID.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtIncomeID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtIncomeID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtIncomeID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtIncomeID.Font = New System.Drawing.Font("FC Minimal", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIncomeID.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtIncomeID.Location = New System.Drawing.Point(312, 161)
        Me.txtIncomeID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtIncomeID.Name = "txtIncomeID"
        Me.txtIncomeID.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtIncomeID.PlaceholderText = ""
        Me.txtIncomeID.SelectedText = ""
        Me.txtIncomeID.Size = New System.Drawing.Size(172, 38)
        Me.txtIncomeID.TabIndex = 4
        '
        'txtDetailID
        '
        Me.txtDetailID.BorderRadius = 10
        Me.txtDetailID.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDetailID.DefaultText = ""
        Me.txtDetailID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtDetailID.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtDetailID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDetailID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDetailID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDetailID.Font = New System.Drawing.Font("FC Minimal", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDetailID.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDetailID.Location = New System.Drawing.Point(31, 55)
        Me.txtDetailID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDetailID.Name = "txtDetailID"
        Me.txtDetailID.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDetailID.PlaceholderText = ""
        Me.txtDetailID.SelectedText = ""
        Me.txtDetailID.Size = New System.Drawing.Size(172, 38)
        Me.txtDetailID.TabIndex = 1
        '
        'txtDetailName
        '
        Me.txtDetailName.BorderRadius = 10
        Me.txtDetailName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDetailName.DefaultText = ""
        Me.txtDetailName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtDetailName.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtDetailName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDetailName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDetailName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDetailName.Font = New System.Drawing.Font("FC Minimal", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDetailName.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDetailName.Location = New System.Drawing.Point(31, 112)
        Me.txtDetailName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDetailName.Name = "txtDetailName"
        Me.txtDetailName.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDetailName.PlaceholderText = ""
        Me.txtDetailName.SelectedText = ""
        Me.txtDetailName.Size = New System.Drawing.Size(172, 38)
        Me.txtDetailName.TabIndex = 4
        '
        'txtDetailAmount
        '
        Me.txtDetailAmount.BorderRadius = 10
        Me.txtDetailAmount.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDetailAmount.DefaultText = ""
        Me.txtDetailAmount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtDetailAmount.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtDetailAmount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDetailAmount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDetailAmount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDetailAmount.Font = New System.Drawing.Font("FC Minimal", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDetailAmount.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDetailAmount.Location = New System.Drawing.Point(248, 55)
        Me.txtDetailAmount.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDetailAmount.Name = "txtDetailAmount"
        Me.txtDetailAmount.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDetailAmount.PlaceholderText = ""
        Me.txtDetailAmount.SelectedText = ""
        Me.txtDetailAmount.Size = New System.Drawing.Size(172, 38)
        Me.txtDetailAmount.TabIndex = 4
        '
        'frmEditIncome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 772)
        Me.Controls.Add(Me.Guna2GroupBox2)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Guna2GroupBox1)
        Me.Controls.Add(Me.dgvIncomeDetails)
        Me.Controls.Add(Me.dgvIncome)
        Me.Name = "frmEditIncome"
        Me.Text = "frmEditIncome"
        CType(Me.dgvIncome, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2GroupBox1.ResumeLayout(False)
        CType(Me.dgvIncomeDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvIncome As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents txtIncomeName As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2GroupBox1 As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents txtIncomeAmount As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents dtpIncomeDate As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents btnSave As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnCancel As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents cmbAccount As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents dgvIncomeDetails As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents Guna2GroupBox2 As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents txtIncomeID As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtDetailID As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtDetailName As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtDetailAmount As Guna.UI2.WinForms.Guna2TextBox
End Class

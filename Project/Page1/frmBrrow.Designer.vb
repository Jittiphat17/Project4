<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBrrow
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
        Me.components = New System.ComponentModel.Container()
        Me.txtSearch = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2GroupBox1 = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dtpBirth = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbPercen = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.cbPerM = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.cbAccount = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.txtMoney = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtDetail = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Guna2GroupBox2 = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSearch3 = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtDetail3 = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSearch2 = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtDetail2 = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSearch1 = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtDetail1 = New Guna.UI2.WinForms.Guna2TextBox()
        Me.chkGuarantor = New Guna.UI2.WinForms.Guna2CheckBox()
        Me.Guna2Elipse1 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.dgvConn = New System.Windows.Forms.DataGridView()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnSave = New Guna.UI2.WinForms.Guna2Button()
        Me.btnAdd = New Guna.UI2.WinForms.Guna2Button()
        Me.btnClear = New Guna.UI2.WinForms.Guna2Button()
        Me.txtCid = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Guna2ControlBox2 = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.Guna2GroupBox1.SuspendLayout()
        Me.Guna2GroupBox2.SuspendLayout()
        Me.Guna2Panel1.SuspendLayout()
        CType(Me.dgvConn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtSearch
        '
        Me.txtSearch.BorderRadius = 10
        Me.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSearch.DefaultText = ""
        Me.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSearch.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!)
        Me.txtSearch.ForeColor = System.Drawing.Color.Black
        Me.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSearch.Location = New System.Drawing.Point(168, 56)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtSearch.PlaceholderForeColor = System.Drawing.Color.White
        Me.txtSearch.PlaceholderText = ""
        Me.txtSearch.SelectedText = ""
        Me.txtSearch.Size = New System.Drawing.Size(207, 37)
        Me.txtSearch.TabIndex = 0
        '
        'Guna2GroupBox1
        '
        Me.Guna2GroupBox1.BackColor = System.Drawing.Color.White
        Me.Guna2GroupBox1.Controls.Add(Me.Label12)
        Me.Guna2GroupBox1.Controls.Add(Me.Label7)
        Me.Guna2GroupBox1.Controls.Add(Me.Label9)
        Me.Guna2GroupBox1.Controls.Add(Me.Label8)
        Me.Guna2GroupBox1.Controls.Add(Me.Label4)
        Me.Guna2GroupBox1.Controls.Add(Me.Label13)
        Me.Guna2GroupBox1.Controls.Add(Me.dtpBirth)
        Me.Guna2GroupBox1.Controls.Add(Me.Label11)
        Me.Guna2GroupBox1.Controls.Add(Me.cbPercen)
        Me.Guna2GroupBox1.Controls.Add(Me.txtSearch)
        Me.Guna2GroupBox1.Controls.Add(Me.cbPerM)
        Me.Guna2GroupBox1.Controls.Add(Me.cbAccount)
        Me.Guna2GroupBox1.Controls.Add(Me.txtMoney)
        Me.Guna2GroupBox1.Controls.Add(Me.Label10)
        Me.Guna2GroupBox1.Controls.Add(Me.txtDetail)
        Me.Guna2GroupBox1.Controls.Add(Me.Label6)
        Me.Guna2GroupBox1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.Guna2GroupBox1.Location = New System.Drawing.Point(12, 84)
        Me.Guna2GroupBox1.Name = "Guna2GroupBox1"
        Me.Guna2GroupBox1.Size = New System.Drawing.Size(518, 449)
        Me.Guna2GroupBox1.TabIndex = 1
        Me.Guna2GroupBox1.Text = "ผู้กู้"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(336, 323)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(39, 24)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "เดือน"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(314, 237)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 24)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "บาท"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(311, 407)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 24)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "% / เดือน"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(98, 407)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 24)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "ดอกเบี้ย :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(127, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 24)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "ผู้กู้ :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(117, 365)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(45, 24)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "วันที่ :"
        '
        'dtpBirth
        '
        Me.dtpBirth.Animated = True
        Me.dtpBirth.Checked = True
        Me.dtpBirth.FillColor = System.Drawing.Color.White
        Me.dtpBirth.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpBirth.ForeColor = System.Drawing.Color.Black
        Me.dtpBirth.Format = System.Windows.Forms.DateTimePickerFormat.[Long]
        Me.dtpBirth.Location = New System.Drawing.Point(168, 353)
        Me.dtpBirth.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpBirth.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpBirth.Name = "dtpBirth"
        Me.dtpBirth.Size = New System.Drawing.Size(212, 36)
        Me.dtpBirth.TabIndex = 3
        Me.dtpBirth.Value = New Date(2024, 9, 7, 22, 10, 28, 596)
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(73, 323)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(89, 24)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "จำนวนเดือน :"
        '
        'cbPercen
        '
        Me.cbPercen.BackColor = System.Drawing.Color.Transparent
        Me.cbPercen.BorderRadius = 10
        Me.cbPercen.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbPercen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPercen.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbPercen.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbPercen.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cbPercen.ForeColor = System.Drawing.Color.Black
        Me.cbPercen.ItemHeight = 30
        Me.cbPercen.Location = New System.Drawing.Point(168, 395)
        Me.cbPercen.Name = "cbPercen"
        Me.cbPercen.Size = New System.Drawing.Size(140, 36)
        Me.cbPercen.TabIndex = 2
        '
        'cbPerM
        '
        Me.cbPerM.BackColor = System.Drawing.Color.Transparent
        Me.cbPerM.BorderRadius = 10
        Me.cbPerM.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbPerM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPerM.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbPerM.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbPerM.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cbPerM.ForeColor = System.Drawing.Color.Black
        Me.cbPerM.ItemHeight = 30
        Me.cbPerM.Location = New System.Drawing.Point(168, 311)
        Me.cbPerM.Name = "cbPerM"
        Me.cbPerM.Size = New System.Drawing.Size(162, 36)
        Me.cbPerM.TabIndex = 2
        '
        'cbAccount
        '
        Me.cbAccount.BackColor = System.Drawing.Color.Transparent
        Me.cbAccount.BorderRadius = 10
        Me.cbAccount.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAccount.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbAccount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbAccount.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cbAccount.ForeColor = System.Drawing.Color.Black
        Me.cbAccount.ItemHeight = 30
        Me.cbAccount.Location = New System.Drawing.Point(168, 269)
        Me.cbAccount.Name = "cbAccount"
        Me.cbAccount.Size = New System.Drawing.Size(140, 36)
        Me.cbAccount.TabIndex = 2
        '
        'txtMoney
        '
        Me.txtMoney.BorderRadius = 10
        Me.txtMoney.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMoney.DefaultText = ""
        Me.txtMoney.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtMoney.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtMoney.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtMoney.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtMoney.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtMoney.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!)
        Me.txtMoney.ForeColor = System.Drawing.Color.Black
        Me.txtMoney.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtMoney.Location = New System.Drawing.Point(168, 224)
        Me.txtMoney.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.txtMoney.Name = "txtMoney"
        Me.txtMoney.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtMoney.PlaceholderText = ""
        Me.txtMoney.SelectedText = ""
        Me.txtMoney.Size = New System.Drawing.Size(135, 37)
        Me.txtMoney.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(88, 281)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(74, 24)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "แหล่งจ่าย :"
        '
        'txtDetail
        '
        Me.txtDetail.BorderRadius = 10
        Me.txtDetail.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDetail.DefaultText = ""
        Me.txtDetail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtDetail.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtDetail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDetail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDetail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDetail.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!)
        Me.txtDetail.ForeColor = System.Drawing.Color.Black
        Me.txtDetail.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDetail.Location = New System.Drawing.Point(168, 103)
        Me.txtDetail.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.txtDetail.Multiline = True
        Me.txtDetail.Name = "txtDetail"
        Me.txtDetail.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDetail.PlaceholderText = ""
        Me.txtDetail.ReadOnly = True
        Me.txtDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDetail.SelectedText = ""
        Me.txtDetail.Size = New System.Drawing.Size(272, 111)
        Me.txtDetail.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(74, 237)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 24)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "จำนวนเงินกู้ :"
        '
        'Guna2GroupBox2
        '
        Me.Guna2GroupBox2.Controls.Add(Me.Label3)
        Me.Guna2GroupBox2.Controls.Add(Me.txtSearch3)
        Me.Guna2GroupBox2.Controls.Add(Me.txtDetail3)
        Me.Guna2GroupBox2.Controls.Add(Me.Label2)
        Me.Guna2GroupBox2.Controls.Add(Me.txtSearch2)
        Me.Guna2GroupBox2.Controls.Add(Me.txtDetail2)
        Me.Guna2GroupBox2.Controls.Add(Me.Label1)
        Me.Guna2GroupBox2.Controls.Add(Me.txtSearch1)
        Me.Guna2GroupBox2.Controls.Add(Me.txtDetail1)
        Me.Guna2GroupBox2.Controls.Add(Me.chkGuarantor)
        Me.Guna2GroupBox2.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Guna2GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.Guna2GroupBox2.Location = New System.Drawing.Point(552, 84)
        Me.Guna2GroupBox2.Name = "Guna2GroupBox2"
        Me.Guna2GroupBox2.Size = New System.Drawing.Size(648, 449)
        Me.Guna2GroupBox2.TabIndex = 2
        Me.Guna2GroupBox2.Text = "ผู้ค้ำ"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(303, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 24)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "ผู้กู้ :"
        '
        'txtSearch3
        '
        Me.txtSearch3.BackColor = System.Drawing.Color.White
        Me.txtSearch3.BorderRadius = 10
        Me.txtSearch3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSearch3.DefaultText = ""
        Me.txtSearch3.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtSearch3.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtSearch3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSearch3.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSearch3.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSearch3.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!)
        Me.txtSearch3.ForeColor = System.Drawing.Color.Black
        Me.txtSearch3.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSearch3.Location = New System.Drawing.Point(344, 85)
        Me.txtSearch3.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.txtSearch3.Name = "txtSearch3"
        Me.txtSearch3.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtSearch3.PlaceholderForeColor = System.Drawing.Color.White
        Me.txtSearch3.PlaceholderText = ""
        Me.txtSearch3.SelectedText = ""
        Me.txtSearch3.Size = New System.Drawing.Size(207, 37)
        Me.txtSearch3.TabIndex = 15
        '
        'txtDetail3
        '
        Me.txtDetail3.BackColor = System.Drawing.Color.White
        Me.txtDetail3.BorderRadius = 10
        Me.txtDetail3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDetail3.DefaultText = ""
        Me.txtDetail3.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtDetail3.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtDetail3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDetail3.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDetail3.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDetail3.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!)
        Me.txtDetail3.ForeColor = System.Drawing.Color.Black
        Me.txtDetail3.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDetail3.Location = New System.Drawing.Point(344, 132)
        Me.txtDetail3.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.txtDetail3.Multiline = True
        Me.txtDetail3.Name = "txtDetail3"
        Me.txtDetail3.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDetail3.PlaceholderText = ""
        Me.txtDetail3.ReadOnly = True
        Me.txtDetail3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDetail3.SelectedText = ""
        Me.txtDetail3.Size = New System.Drawing.Size(272, 111)
        Me.txtDetail3.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(12, 281)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 24)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "ผู้กู้ :"
        '
        'txtSearch2
        '
        Me.txtSearch2.BackColor = System.Drawing.Color.White
        Me.txtSearch2.BorderRadius = 10
        Me.txtSearch2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSearch2.DefaultText = ""
        Me.txtSearch2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtSearch2.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtSearch2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSearch2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSearch2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSearch2.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!)
        Me.txtSearch2.ForeColor = System.Drawing.Color.Black
        Me.txtSearch2.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSearch2.Location = New System.Drawing.Point(53, 272)
        Me.txtSearch2.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.txtSearch2.Name = "txtSearch2"
        Me.txtSearch2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtSearch2.PlaceholderForeColor = System.Drawing.Color.White
        Me.txtSearch2.PlaceholderText = ""
        Me.txtSearch2.SelectedText = ""
        Me.txtSearch2.Size = New System.Drawing.Size(207, 37)
        Me.txtSearch2.TabIndex = 12
        '
        'txtDetail2
        '
        Me.txtDetail2.BackColor = System.Drawing.Color.White
        Me.txtDetail2.BorderRadius = 10
        Me.txtDetail2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDetail2.DefaultText = ""
        Me.txtDetail2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtDetail2.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtDetail2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDetail2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDetail2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDetail2.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!)
        Me.txtDetail2.ForeColor = System.Drawing.Color.Black
        Me.txtDetail2.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDetail2.Location = New System.Drawing.Point(53, 319)
        Me.txtDetail2.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.txtDetail2.Multiline = True
        Me.txtDetail2.Name = "txtDetail2"
        Me.txtDetail2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDetail2.PlaceholderText = ""
        Me.txtDetail2.ReadOnly = True
        Me.txtDetail2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDetail2.SelectedText = ""
        Me.txtDetail2.Size = New System.Drawing.Size(272, 111)
        Me.txtDetail2.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 103)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 24)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "ผู้กู้ :"
        '
        'txtSearch1
        '
        Me.txtSearch1.BackColor = System.Drawing.Color.White
        Me.txtSearch1.BorderRadius = 10
        Me.txtSearch1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSearch1.DefaultText = ""
        Me.txtSearch1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtSearch1.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtSearch1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSearch1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSearch1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSearch1.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!)
        Me.txtSearch1.ForeColor = System.Drawing.Color.Black
        Me.txtSearch1.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSearch1.Location = New System.Drawing.Point(53, 94)
        Me.txtSearch1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.txtSearch1.Name = "txtSearch1"
        Me.txtSearch1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtSearch1.PlaceholderForeColor = System.Drawing.Color.White
        Me.txtSearch1.PlaceholderText = ""
        Me.txtSearch1.SelectedText = ""
        Me.txtSearch1.Size = New System.Drawing.Size(207, 37)
        Me.txtSearch1.TabIndex = 9
        '
        'txtDetail1
        '
        Me.txtDetail1.BackColor = System.Drawing.Color.White
        Me.txtDetail1.BorderRadius = 10
        Me.txtDetail1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDetail1.DefaultText = ""
        Me.txtDetail1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtDetail1.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtDetail1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDetail1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDetail1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDetail1.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!)
        Me.txtDetail1.ForeColor = System.Drawing.Color.Black
        Me.txtDetail1.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDetail1.Location = New System.Drawing.Point(53, 141)
        Me.txtDetail1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.txtDetail1.Multiline = True
        Me.txtDetail1.Name = "txtDetail1"
        Me.txtDetail1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDetail1.PlaceholderText = ""
        Me.txtDetail1.ReadOnly = True
        Me.txtDetail1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDetail1.SelectedText = ""
        Me.txtDetail1.Size = New System.Drawing.Size(272, 111)
        Me.txtDetail1.TabIndex = 10
        '
        'chkGuarantor
        '
        Me.chkGuarantor.AutoSize = True
        Me.chkGuarantor.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkGuarantor.CheckedState.BorderRadius = 0
        Me.chkGuarantor.CheckedState.BorderThickness = 0
        Me.chkGuarantor.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkGuarantor.ForeColor = System.Drawing.Color.Black
        Me.chkGuarantor.Location = New System.Drawing.Point(16, 56)
        Me.chkGuarantor.Name = "chkGuarantor"
        Me.chkGuarantor.Size = New System.Drawing.Size(174, 23)
        Me.chkGuarantor.TabIndex = 1
        Me.chkGuarantor.Text = "มี(ให้กดถูก)/ไม่มี(ไม่ต้องกด)"
        Me.chkGuarantor.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkGuarantor.UncheckedState.BorderRadius = 0
        Me.chkGuarantor.UncheckedState.BorderThickness = 0
        Me.chkGuarantor.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        '
        'Guna2Elipse1
        '
        Me.Guna2Elipse1.BorderRadius = 10
        Me.Guna2Elipse1.TargetControl = Me
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Guna2Panel1.Controls.Add(Me.Guna2ControlBox2)
        Me.Guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(1212, 30)
        Me.Guna2Panel1.TabIndex = 3
        '
        'dgvConn
        '
        Me.dgvConn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvConn.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column11, Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10})
        Me.dgvConn.Location = New System.Drawing.Point(12, 539)
        Me.dgvConn.Name = "dgvConn"
        Me.dgvConn.ReadOnly = True
        Me.dgvConn.Size = New System.Drawing.Size(1188, 228)
        Me.dgvConn.TabIndex = 6
        '
        'Column11
        '
        Me.Column11.HeaderText = "เลขที่สัญญา"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "ผู้กู้"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "รายละเอียดผู้กู้"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 300
        '
        'Column3
        '
        Me.Column3.HeaderText = "จำนวนเงินกู้"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "แหล่งจ่าย"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "จำนวนเดือน"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "ดอกเบี้ยต่อเดือน"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "วันที่ทำรายการ"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "ผู้ค้ำที่1"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.HeaderText = "ผู้ค้ำที่2"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column10
        '
        Me.Column10.HeaderText = "ผู้ค้ำที่3"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'btnSave
        '
        Me.btnSave.Animated = True
        Me.btnSave.BorderRadius = 10
        Me.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnSave.Font = New System.Drawing.Font("TH SarabunPSK", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSave.Location = New System.Drawing.Point(279, 794)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(200, 75)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "บันทึก"
        '
        'btnAdd
        '
        Me.btnAdd.Animated = True
        Me.btnAdd.BorderRadius = 10
        Me.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnAdd.Font = New System.Drawing.Font("TH SarabunPSK", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnAdd.Location = New System.Drawing.Point(486, 794)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(200, 75)
        Me.btnAdd.TabIndex = 7
        Me.btnAdd.Text = "เพิ่ม"
        '
        'btnClear
        '
        Me.btnClear.Animated = True
        Me.btnClear.BorderRadius = 10
        Me.btnClear.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnClear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnClear.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnClear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnClear.Font = New System.Drawing.Font("TH SarabunPSK", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnClear.Location = New System.Drawing.Point(692, 794)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(200, 75)
        Me.btnClear.TabIndex = 7
        Me.btnClear.Text = "ล้างข้อมูล"
        '
        'txtCid
        '
        Me.txtCid.BorderRadius = 10
        Me.txtCid.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCid.DefaultText = ""
        Me.txtCid.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtCid.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtCid.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCid.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCid.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCid.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!)
        Me.txtCid.ForeColor = System.Drawing.Color.Black
        Me.txtCid.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCid.Location = New System.Drawing.Point(993, 38)
        Me.txtCid.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.txtCid.Name = "txtCid"
        Me.txtCid.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCid.PlaceholderForeColor = System.Drawing.Color.White
        Me.txtCid.PlaceholderText = ""
        Me.txtCid.ReadOnly = True
        Me.txtCid.SelectedText = ""
        Me.txtCid.Size = New System.Drawing.Size(207, 37)
        Me.txtCid.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(901, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 24)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "เลขที่สัญญา :"
        '
        'Guna2ControlBox2
        '
        Me.Guna2ControlBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2ControlBox2.BackColor = System.Drawing.Color.Red
        Me.Guna2ControlBox2.CustomIconSize = 30.0!
        Me.Guna2ControlBox2.FillColor = System.Drawing.Color.LightGray
        Me.Guna2ControlBox2.IconColor = System.Drawing.Color.Red
        Me.Guna2ControlBox2.Location = New System.Drawing.Point(1162, 1)
        Me.Guna2ControlBox2.Name = "Guna2ControlBox2"
        Me.Guna2ControlBox2.Size = New System.Drawing.Size(38, 29)
        Me.Guna2ControlBox2.TabIndex = 15
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1212, 879)
        Me.Controls.Add(Me.txtCid)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.dgvConn)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Guna2GroupBox2)
        Me.Controls.Add(Me.Guna2GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form2"
        Me.Guna2GroupBox1.ResumeLayout(False)
        Me.Guna2GroupBox1.PerformLayout()
        Me.Guna2GroupBox2.ResumeLayout(False)
        Me.Guna2GroupBox2.PerformLayout()
        Me.Guna2Panel1.ResumeLayout(False)
        CType(Me.dgvConn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtSearch As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2GroupBox1 As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents Guna2GroupBox2 As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents txtDetail As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtMoney As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents cbAccount As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents cbPerM As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents dtpBirth As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents Label13 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cbPercen As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents chkGuarantor As Guna.UI2.WinForms.Guna2CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtSearch3 As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtDetail3 As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSearch2 As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtDetail2 As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtSearch1 As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtDetail1 As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2Elipse1 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents dgvConn As DataGridView
    Friend WithEvents Column11 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents btnSave As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnClear As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnAdd As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents txtCid As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Guna2ControlBox2 As Guna.UI2.WinForms.Guna2ControlBox
End Class

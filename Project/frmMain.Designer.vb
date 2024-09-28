<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
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
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Guna2Elipse1 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.lblUserInfo = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.lblDateTime = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2Elipse2 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.tsm_exp = New System.Windows.Forms.ToolStripMenuItem()
        Me.สญญาToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ทำสญญาToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.แกไขสญญาToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.คาใชจายToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.บนทกคาใชจายToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.แกToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ตารางเงนกToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsm_inc = New System.Windows.Forms.ToolStripMenuItem()
        Me.แกไขรายรบToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.รายรบToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsm_report = New System.Windows.Forms.ToolStripMenuItem()
        Me.รายงานสญญาเงนกToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.รายงานดอกเบยสจจะToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsm_other = New System.Windows.Forms.ToolStripMenuItem()
        Me.สมาชกToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.จดการสมาชกToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ดสมาชกToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.สมาชกลาออกToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.อานบตรToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ขอมลToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.สำรองขอมลToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.นำเขาขอมลToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.จดการสทธToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.จดการกองทนToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ออกจากระบบToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Guna2GroupBox1 = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.lbCount = New System.Windows.Forms.Label()
        Me.Guna2GroupBox2 = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.lbContractCount = New System.Windows.Forms.Label()
        Me.Guna2ControlBox1 = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.ดอกเบยสจจะToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Guna2Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.Guna2GroupBox1.SuspendLayout()
        Me.Guna2GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Guna2Elipse1
        '
        Me.Guna2Elipse1.BorderRadius = 20
        Me.Guna2Elipse1.TargetControl = Me
        '
        'lblUserInfo
        '
        Me.lblUserInfo.BackColor = System.Drawing.Color.Transparent
        Me.lblUserInfo.Font = New System.Drawing.Font("FC Minimal", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserInfo.Location = New System.Drawing.Point(152, 503)
        Me.lblUserInfo.Name = "lblUserInfo"
        Me.lblUserInfo.Size = New System.Drawing.Size(131, 23)
        Me.lblUserInfo.TabIndex = 19
        Me.lblUserInfo.Text = "Guna2HtmlLabel1"
        '
        'lblDateTime
        '
        Me.lblDateTime.BackColor = System.Drawing.Color.Transparent
        Me.lblDateTime.Font = New System.Drawing.Font("FC Minimal", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateTime.Location = New System.Drawing.Point(464, 503)
        Me.lblDateTime.Name = "lblDateTime"
        Me.lblDateTime.Size = New System.Drawing.Size(133, 23)
        Me.lblDateTime.TabIndex = 20
        Me.lblDateTime.Text = "Guna2HtmlLabel2"
        '
        'Guna2Elipse2
        '
        Me.Guna2Elipse2.BorderRadius = 30
        Me.Guna2Elipse2.TargetControl = Me.Guna2Panel1
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Guna2Panel1.Controls.Add(Me.MenuStrip1)
        Me.Guna2Panel1.Location = New System.Drawing.Point(-13, -1)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.ShadowDecoration.BorderRadius = 30
        Me.Guna2Panel1.ShadowDecoration.Color = System.Drawing.Color.Gray
        Me.Guna2Panel1.ShadowDecoration.Depth = 20
        Me.Guna2Panel1.ShadowDecoration.Enabled = True
        Me.Guna2Panel1.Size = New System.Drawing.Size(159, 539)
        Me.Guna2Panel1.TabIndex = 21
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.Left
        Me.MenuStrip1.Font = New System.Drawing.Font("FC Minimal", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsm_exp, Me.tsm_inc, Me.tsm_report, Me.tsm_other, Me.ออกจากระบบToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MenuStrip1.Size = New System.Drawing.Size(161, 539)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'tsm_exp
        '
        Me.tsm_exp.AutoSize = False
        Me.tsm_exp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.สญญาToolStripMenuItem1, Me.คาใชจายToolStripMenuItem, Me.ตารางเงนกToolStripMenuItem})
        Me.tsm_exp.Name = "tsm_exp"
        Me.tsm_exp.Size = New System.Drawing.Size(150, 50)
        Me.tsm_exp.Text = "รายจ่าย"
        '
        'สญญาToolStripMenuItem1
        '
        Me.สญญาToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ทำสญญาToolStripMenuItem, Me.แกไขสญญาToolStripMenuItem})
        Me.สญญาToolStripMenuItem1.Name = "สญญาToolStripMenuItem1"
        Me.สญญาToolStripMenuItem1.Size = New System.Drawing.Size(180, 32)
        Me.สญญาToolStripMenuItem1.Text = "สัญญา"
        '
        'ทำสญญาToolStripMenuItem
        '
        Me.ทำสญญาToolStripMenuItem.Name = "ทำสญญาToolStripMenuItem"
        Me.ทำสญญาToolStripMenuItem.Size = New System.Drawing.Size(185, 32)
        Me.ทำสญญาToolStripMenuItem.Text = "ทำสัญญา"
        '
        'แกไขสญญาToolStripMenuItem
        '
        Me.แกไขสญญาToolStripMenuItem.Name = "แกไขสญญาToolStripMenuItem"
        Me.แกไขสญญาToolStripMenuItem.Size = New System.Drawing.Size(185, 32)
        Me.แกไขสญญาToolStripMenuItem.Text = "แก้ไขสัญญา"
        '
        'คาใชจายToolStripMenuItem
        '
        Me.คาใชจายToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.บนทกคาใชจายToolStripMenuItem, Me.แกToolStripMenuItem})
        Me.คาใชจายToolStripMenuItem.Name = "คาใชจายToolStripMenuItem"
        Me.คาใชจายToolStripMenuItem.Size = New System.Drawing.Size(180, 32)
        Me.คาใชจายToolStripMenuItem.Text = "ค่าใช้จ่าย"
        '
        'บนทกคาใชจายToolStripMenuItem
        '
        Me.บนทกคาใชจายToolStripMenuItem.Name = "บนทกคาใชจายToolStripMenuItem"
        Me.บนทกคาใชจายToolStripMenuItem.Size = New System.Drawing.Size(210, 32)
        Me.บนทกคาใชจายToolStripMenuItem.Text = "บันทึกค่าใช้จ่าย"
        '
        'แกToolStripMenuItem
        '
        Me.แกToolStripMenuItem.Name = "แกToolStripMenuItem"
        Me.แกToolStripMenuItem.Size = New System.Drawing.Size(210, 32)
        Me.แกToolStripMenuItem.Text = "แก้ไขค่าใช้จ่าย"
        '
        'ตารางเงนกToolStripMenuItem
        '
        Me.ตารางเงนกToolStripMenuItem.Name = "ตารางเงนกToolStripMenuItem"
        Me.ตารางเงนกToolStripMenuItem.Size = New System.Drawing.Size(180, 32)
        Me.ตารางเงนกToolStripMenuItem.Text = "ตารางเงินกู้"
        '
        'tsm_inc
        '
        Me.tsm_inc.AutoSize = False
        Me.tsm_inc.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.แกไขรายรบToolStripMenuItem, Me.รายรบToolStripMenuItem})
        Me.tsm_inc.Name = "tsm_inc"
        Me.tsm_inc.Size = New System.Drawing.Size(150, 50)
        Me.tsm_inc.Text = "รายรับ"
        '
        'แกไขรายรบToolStripMenuItem
        '
        Me.แกไขรายรบToolStripMenuItem.Name = "แกไขรายรบToolStripMenuItem"
        Me.แกไขรายรบToolStripMenuItem.Size = New System.Drawing.Size(182, 32)
        Me.แกไขรายรบToolStripMenuItem.Text = "แก้ไขรายรับ"
        '
        'รายรบToolStripMenuItem
        '
        Me.รายรบToolStripMenuItem.Name = "รายรบToolStripMenuItem"
        Me.รายรบToolStripMenuItem.Size = New System.Drawing.Size(182, 32)
        Me.รายรบToolStripMenuItem.Text = "รายรับ"
        '
        'tsm_report
        '
        Me.tsm_report.AutoSize = False
        Me.tsm_report.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.รายงานสญญาเงนกToolStripMenuItem, Me.รายงานดอกเบยสจจะToolStripMenuItem, Me.ดอกเบยสจจะToolStripMenuItem})
        Me.tsm_report.Name = "tsm_report"
        Me.tsm_report.Size = New System.Drawing.Size(150, 50)
        Me.tsm_report.Text = "รายงาน"
        '
        'รายงานสญญาเงนกToolStripMenuItem
        '
        Me.รายงานสญญาเงนกToolStripMenuItem.Name = "รายงานสญญาเงนกToolStripMenuItem"
        Me.รายงานสญญาเงนกToolStripMenuItem.Size = New System.Drawing.Size(262, 32)
        Me.รายงานสญญาเงนกToolStripMenuItem.Text = "รายงานสัญญาเงินกู้"
        '
        'รายงานดอกเบยสจจะToolStripMenuItem
        '
        Me.รายงานดอกเบยสจจะToolStripMenuItem.Name = "รายงานดอกเบยสจจะToolStripMenuItem"
        Me.รายงานดอกเบยสจจะToolStripMenuItem.Size = New System.Drawing.Size(262, 32)
        Me.รายงานดอกเบยสจจะToolStripMenuItem.Text = "รายงานดอกเบี้ยสัจจะ"
        '
        'tsm_other
        '
        Me.tsm_other.AutoSize = False
        Me.tsm_other.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.สมาชกToolStripMenuItem, Me.อานบตรToolStripMenuItem, Me.ขอมลToolStripMenuItem, Me.จดการสทธToolStripMenuItem, Me.จดการกองทนToolStripMenuItem})
        Me.tsm_other.Name = "tsm_other"
        Me.tsm_other.Size = New System.Drawing.Size(150, 50)
        Me.tsm_other.Text = "อื่นๆ"
        '
        'สมาชกToolStripMenuItem
        '
        Me.สมาชกToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.จดการสมาชกToolStripMenuItem, Me.ดสมาชกToolStripMenuItem, Me.สมาชกลาออกToolStripMenuItem})
        Me.สมาชกToolStripMenuItem.Name = "สมาชกToolStripMenuItem"
        Me.สมาชกToolStripMenuItem.Size = New System.Drawing.Size(205, 32)
        Me.สมาชกToolStripMenuItem.Text = "สมาชิก"
        '
        'จดการสมาชกToolStripMenuItem
        '
        Me.จดการสมาชกToolStripMenuItem.Name = "จดการสมาชกToolStripMenuItem"
        Me.จดการสมาชกToolStripMenuItem.Size = New System.Drawing.Size(203, 32)
        Me.จดการสมาชกToolStripMenuItem.Text = "จัดการสมาชิก"
        '
        'ดสมาชกToolStripMenuItem
        '
        Me.ดสมาชกToolStripMenuItem.Name = "ดสมาชกToolStripMenuItem"
        Me.ดสมาชกToolStripMenuItem.Size = New System.Drawing.Size(203, 32)
        Me.ดสมาชกToolStripMenuItem.Text = "เรียกดูสมาชิก"
        '
        'สมาชกลาออกToolStripMenuItem
        '
        Me.สมาชกลาออกToolStripMenuItem.Name = "สมาชกลาออกToolStripMenuItem"
        Me.สมาชกลาออกToolStripMenuItem.Size = New System.Drawing.Size(203, 32)
        Me.สมาชกลาออกToolStripMenuItem.Text = "สมาชิกลาออก"
        '
        'อานบตรToolStripMenuItem
        '
        Me.อานบตรToolStripMenuItem.Name = "อานบตรToolStripMenuItem"
        Me.อานบตรToolStripMenuItem.Size = New System.Drawing.Size(205, 32)
        Me.อานบตรToolStripMenuItem.Text = "เพิ่มสมาชิก"
        '
        'ขอมลToolStripMenuItem
        '
        Me.ขอมลToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.สำรองขอมลToolStripMenuItem, Me.นำเขาขอมลToolStripMenuItem})
        Me.ขอมลToolStripMenuItem.Name = "ขอมลToolStripMenuItem"
        Me.ขอมลToolStripMenuItem.Size = New System.Drawing.Size(205, 32)
        Me.ขอมลToolStripMenuItem.Text = "ข้อมูล"
        '
        'สำรองขอมลToolStripMenuItem
        '
        Me.สำรองขอมลToolStripMenuItem.Name = "สำรองขอมลToolStripMenuItem"
        Me.สำรองขอมลToolStripMenuItem.Size = New System.Drawing.Size(190, 32)
        Me.สำรองขอมลToolStripMenuItem.Text = "สำรองข้อมูล"
        '
        'นำเขาขอมลToolStripMenuItem
        '
        Me.นำเขาขอมลToolStripMenuItem.Name = "นำเขาขอมลToolStripMenuItem"
        Me.นำเขาขอมลToolStripMenuItem.Size = New System.Drawing.Size(190, 32)
        Me.นำเขาขอมลToolStripMenuItem.Text = "นำเข้าข้อมูล"
        '
        'จดการสทธToolStripMenuItem
        '
        Me.จดการสทธToolStripMenuItem.Name = "จดการสทธToolStripMenuItem"
        Me.จดการสทธToolStripMenuItem.Size = New System.Drawing.Size(205, 32)
        Me.จดการสทธToolStripMenuItem.Text = "จัดการสิทธิ"
        '
        'จดการกองทนToolStripMenuItem
        '
        Me.จดการกองทนToolStripMenuItem.Name = "จดการกองทนToolStripMenuItem"
        Me.จดการกองทนToolStripMenuItem.Size = New System.Drawing.Size(205, 32)
        Me.จดการกองทนToolStripMenuItem.Text = "จัดการกองทุน"
        '
        'ออกจากระบบToolStripMenuItem
        '
        Me.ออกจากระบบToolStripMenuItem.AutoSize = False
        Me.ออกจากระบบToolStripMenuItem.BackColor = System.Drawing.Color.IndianRed
        Me.ออกจากระบบToolStripMenuItem.Margin = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.ออกจากระบบToolStripMenuItem.Name = "ออกจากระบบToolStripMenuItem"
        Me.ออกจากระบบToolStripMenuItem.Padding = New System.Windows.Forms.Padding(5, 0, 4, 0)
        Me.ออกจากระบบToolStripMenuItem.Size = New System.Drawing.Size(150, 50)
        Me.ออกจากระบบToolStripMenuItem.Text = "ออกจากระบบ"
        '
        'Guna2GroupBox1
        '
        Me.Guna2GroupBox1.Controls.Add(Me.lbCount)
        Me.Guna2GroupBox1.CustomBorderColor = System.Drawing.Color.DarkSlateBlue
        Me.Guna2GroupBox1.Font = New System.Drawing.Font("FC Minimal", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2GroupBox1.ForeColor = System.Drawing.Color.White
        Me.Guna2GroupBox1.Location = New System.Drawing.Point(162, 60)
        Me.Guna2GroupBox1.Name = "Guna2GroupBox1"
        Me.Guna2GroupBox1.Size = New System.Drawing.Size(295, 113)
        Me.Guna2GroupBox1.TabIndex = 23
        Me.Guna2GroupBox1.Text = "จำนวนสมาชิก"
        '
        'lbCount
        '
        Me.lbCount.AutoSize = True
        Me.lbCount.BackColor = System.Drawing.Color.White
        Me.lbCount.Font = New System.Drawing.Font("FC Minimal", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbCount.Location = New System.Drawing.Point(26, 62)
        Me.lbCount.Name = "lbCount"
        Me.lbCount.Size = New System.Drawing.Size(130, 21)
        Me.lbCount.TabIndex = 1
        Me.lbCount.Text = "แสดงจำนวนสมาชิก"
        '
        'Guna2GroupBox2
        '
        Me.Guna2GroupBox2.BackColor = System.Drawing.Color.Black
        Me.Guna2GroupBox2.Controls.Add(Me.lbContractCount)
        Me.Guna2GroupBox2.CustomBorderColor = System.Drawing.Color.DarkSlateBlue
        Me.Guna2GroupBox2.Font = New System.Drawing.Font("FC Minimal", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2GroupBox2.ForeColor = System.Drawing.Color.White
        Me.Guna2GroupBox2.Location = New System.Drawing.Point(474, 60)
        Me.Guna2GroupBox2.Name = "Guna2GroupBox2"
        Me.Guna2GroupBox2.Size = New System.Drawing.Size(289, 113)
        Me.Guna2GroupBox2.TabIndex = 24
        Me.Guna2GroupBox2.Text = "จำนวนการทำสัญญา"
        '
        'lbContractCount
        '
        Me.lbContractCount.AutoSize = True
        Me.lbContractCount.BackColor = System.Drawing.Color.White
        Me.lbContractCount.Font = New System.Drawing.Font("FC Minimal", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbContractCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbContractCount.Location = New System.Drawing.Point(43, 62)
        Me.lbContractCount.Name = "lbContractCount"
        Me.lbContractCount.Size = New System.Drawing.Size(131, 21)
        Me.lbContractCount.TabIndex = 2
        Me.lbContractCount.Text = "แสดงจำนวนสัญญา"
        '
        'Guna2ControlBox1
        '
        Me.Guna2ControlBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2ControlBox1.BackColor = System.Drawing.Color.Red
        Me.Guna2ControlBox1.CustomIconSize = 30.0!
        Me.Guna2ControlBox1.FillColor = System.Drawing.Color.LightGray
        Me.Guna2ControlBox1.IconColor = System.Drawing.Color.Red
        Me.Guna2ControlBox1.Location = New System.Drawing.Point(730, 12)
        Me.Guna2ControlBox1.Name = "Guna2ControlBox1"
        Me.Guna2ControlBox1.Size = New System.Drawing.Size(38, 29)
        Me.Guna2ControlBox1.TabIndex = 5
        '
        'ดอกเบยสจจะToolStripMenuItem
        '
        Me.ดอกเบยสจจะToolStripMenuItem.Name = "ดอกเบยสจจะToolStripMenuItem"
        Me.ดอกเบยสจจะToolStripMenuItem.Size = New System.Drawing.Size(262, 32)
        Me.ดอกเบยสจจะToolStripMenuItem.Text = "ดอกเบี้ยสัจจะ"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(780, 538)
        Me.Controls.Add(Me.lblUserInfo)
        Me.Controls.Add(Me.Guna2ControlBox1)
        Me.Controls.Add(Me.lblDateTime)
        Me.Controls.Add(Me.Guna2GroupBox2)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.Controls.Add(Me.Guna2GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "y"
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Guna2GroupBox1.ResumeLayout(False)
        Me.Guna2GroupBox1.PerformLayout()
        Me.Guna2GroupBox2.ResumeLayout(False)
        Me.Guna2GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Guna2Elipse1 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents lblDateTime As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents lblUserInfo As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2Elipse2 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2GroupBox2 As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents lbContractCount As Label
    Friend WithEvents Guna2GroupBox1 As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents lbCount As Label
    Friend WithEvents Guna2ControlBox1 As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents tsm_exp As ToolStripMenuItem
    Friend WithEvents สญญาToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ทำสญญาToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents แกไขสญญาToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents คาใชจายToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents บนทกคาใชจายToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents แกToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ตารางเงนกToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tsm_inc As ToolStripMenuItem
    Friend WithEvents แกไขรายรบToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents รายรบToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tsm_report As ToolStripMenuItem
    Friend WithEvents รายงานสญญาเงนกToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tsm_other As ToolStripMenuItem
    Friend WithEvents สมาชกToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents จดการสมาชกToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ดสมาชกToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents สมาชกลาออกToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents อานบตรToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ขอมลToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents สำรองขอมลToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents นำเขาขอมลToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents จดการสทธToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ออกจากระบบToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents รายงานดอกเบยสจจะToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents จดการกองทนToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ดอกเบยสจจะToolStripMenuItem As ToolStripMenuItem
End Class

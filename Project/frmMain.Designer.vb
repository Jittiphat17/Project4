﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.tsm_exp = New System.Windows.Forms.ToolStripMenuItem()
        Me.ทำสญญาToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.แกไขสญญาToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.คาใชจายToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.แกไขคาใชจายToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ตารางเงนกToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.สญญาเงนกToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsm_rev = New System.Windows.Forms.ToolStripMenuItem()
        Me.รบเงนToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsm_report = New System.Windows.Forms.ToolStripMenuItem()
        Me.รายงานลกหนรายตวToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.รายงานเงนฝากสมาชกToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.รายงานบญชToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.งบทดลองToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.งบกำไรขาดทนToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.งดแสดงฐานะทางการเงนToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsm_other = New System.Windows.Forms.ToolStripMenuItem()
        Me.จดการสมาชกToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.เพมสมาชกToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.เรยกดสมาชกฃToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.จดการสทธToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.สำรองขอมลToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.สำรองขอมลToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.นำเขาขอมลToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.อานบตรToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.สมาชกลาออกToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ออกจากระบบToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbCount = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lbContractCount = New System.Windows.Forms.Label()
        Me.panelHeader = New System.Windows.Forms.Panel()
        Me.lblDateTime = New System.Windows.Forms.Label()
        Me.lblUserInfo = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.panelHeader.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.White
        Me.MenuStrip1.Font = New System.Drawing.Font("TH SarabunPSK", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsm_exp, Me.tsm_rev, Me.tsm_report, Me.tsm_other, Me.ออกจากระบบToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(784, 38)
        Me.MenuStrip1.TabIndex = 10
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'tsm_exp
        '
        Me.tsm_exp.BackColor = System.Drawing.Color.Transparent
        Me.tsm_exp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ทำสญญาToolStripMenuItem, Me.คาใชจายToolStripMenuItem, Me.ตารางเงนกToolStripMenuItem, Me.สญญาเงนกToolStripMenuItem})
        Me.tsm_exp.Font = New System.Drawing.Font("TH SarabunPSK", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsm_exp.Name = "tsm_exp"
        Me.tsm_exp.Size = New System.Drawing.Size(83, 34)
        Me.tsm_exp.Text = "รายจ่าย"
        '
        'ทำสญญาToolStripMenuItem
        '
        Me.ทำสญญาToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.แกไขสญญาToolStripMenuItem})
        Me.ทำสญญาToolStripMenuItem.Name = "ทำสญญาToolStripMenuItem"
        Me.ทำสญญาToolStripMenuItem.Size = New System.Drawing.Size(174, 34)
        Me.ทำสญญาToolStripMenuItem.Text = "ทำสัญญา"
        '
        'แกไขสญญาToolStripMenuItem
        '
        Me.แกไขสญญาToolStripMenuItem.Name = "แกไขสญญาToolStripMenuItem"
        Me.แกไขสญญาToolStripMenuItem.Size = New System.Drawing.Size(176, 34)
        Me.แกไขสญญาToolStripMenuItem.Text = "แก้ไขสัญญา"
        '
        'คาใชจายToolStripMenuItem
        '
        Me.คาใชจายToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.แกไขคาใชจายToolStripMenuItem})
        Me.คาใชจายToolStripMenuItem.Name = "คาใชจายToolStripMenuItem"
        Me.คาใชจายToolStripMenuItem.Size = New System.Drawing.Size(174, 34)
        Me.คาใชจายToolStripMenuItem.Text = "ค่าใช้จ่าย"
        '
        'แกไขคาใชจายToolStripMenuItem
        '
        Me.แกไขคาใชจายToolStripMenuItem.Name = "แกไขคาใชจายToolStripMenuItem"
        Me.แกไขคาใชจายToolStripMenuItem.Size = New System.Drawing.Size(194, 34)
        Me.แกไขคาใชจายToolStripMenuItem.Text = "แก้ไขค่าใช้จ่าย"
        '
        'ตารางเงนกToolStripMenuItem
        '
        Me.ตารางเงนกToolStripMenuItem.Name = "ตารางเงนกToolStripMenuItem"
        Me.ตารางเงนกToolStripMenuItem.Size = New System.Drawing.Size(174, 34)
        Me.ตารางเงนกToolStripMenuItem.Text = "ตารางเงินกู้"
        '
        'สญญาเงนกToolStripMenuItem
        '
        Me.สญญาเงนกToolStripMenuItem.Name = "สญญาเงนกToolStripMenuItem"
        Me.สญญาเงนกToolStripMenuItem.Size = New System.Drawing.Size(174, 34)
        Me.สญญาเงนกToolStripMenuItem.Text = "สัญญาเงินกู้"
        '
        'tsm_rev
        '
        Me.tsm_rev.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.รบเงนToolStripMenuItem})
        Me.tsm_rev.Font = New System.Drawing.Font("TH SarabunPSK", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsm_rev.Name = "tsm_rev"
        Me.tsm_rev.Size = New System.Drawing.Size(74, 34)
        Me.tsm_rev.Text = "รายรับ"
        '
        'รบเงนToolStripMenuItem
        '
        Me.รบเงนToolStripMenuItem.Name = "รบเงนToolStripMenuItem"
        Me.รบเงนToolStripMenuItem.Size = New System.Drawing.Size(134, 34)
        Me.รบเงนToolStripMenuItem.Text = "รับเงิน"
        '
        'tsm_report
        '
        Me.tsm_report.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.รายงานลกหนรายตวToolStripMenuItem, Me.รายงานเงนฝากสมาชกToolStripMenuItem, Me.รายงานบญชToolStripMenuItem})
        Me.tsm_report.Font = New System.Drawing.Font("TH SarabunPSK", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsm_report.Name = "tsm_report"
        Me.tsm_report.Size = New System.Drawing.Size(83, 34)
        Me.tsm_report.Text = "รายงาน"
        '
        'รายงานลกหนรายตวToolStripMenuItem
        '
        Me.รายงานลกหนรายตวToolStripMenuItem.Name = "รายงานลกหนรายตวToolStripMenuItem"
        Me.รายงานลกหนรายตวToolStripMenuItem.Size = New System.Drawing.Size(255, 34)
        Me.รายงานลกหนรายตวToolStripMenuItem.Text = "รายงานลูกหนี้รายตัว"
        '
        'รายงานเงนฝากสมาชกToolStripMenuItem
        '
        Me.รายงานเงนฝากสมาชกToolStripMenuItem.Name = "รายงานเงนฝากสมาชกToolStripMenuItem"
        Me.รายงานเงนฝากสมาชกToolStripMenuItem.Size = New System.Drawing.Size(255, 34)
        Me.รายงานเงนฝากสมาชกToolStripMenuItem.Text = "รายงานเงินฝากสมาชิก"
        '
        'รายงานบญชToolStripMenuItem
        '
        Me.รายงานบญชToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.งบทดลองToolStripMenuItem, Me.งบกำไรขาดทนToolStripMenuItem, Me.งดแสดงฐานะทางการเงนToolStripMenuItem})
        Me.รายงานบญชToolStripMenuItem.Name = "รายงานบญชToolStripMenuItem"
        Me.รายงานบญชToolStripMenuItem.Size = New System.Drawing.Size(255, 34)
        Me.รายงานบญชToolStripMenuItem.Text = "รายงานบัญชี"
        '
        'งบทดลองToolStripMenuItem
        '
        Me.งบทดลองToolStripMenuItem.Name = "งบทดลองToolStripMenuItem"
        Me.งบทดลองToolStripMenuItem.Size = New System.Drawing.Size(276, 34)
        Me.งบทดลองToolStripMenuItem.Text = "งบทดลอง"
        '
        'งบกำไรขาดทนToolStripMenuItem
        '
        Me.งบกำไรขาดทนToolStripMenuItem.Name = "งบกำไรขาดทนToolStripMenuItem"
        Me.งบกำไรขาดทนToolStripMenuItem.Size = New System.Drawing.Size(276, 34)
        Me.งบกำไรขาดทนToolStripMenuItem.Text = "งบกำไรขาดทุน"
        '
        'งดแสดงฐานะทางการเงนToolStripMenuItem
        '
        Me.งดแสดงฐานะทางการเงนToolStripMenuItem.Name = "งดแสดงฐานะทางการเงนToolStripMenuItem"
        Me.งดแสดงฐานะทางการเงนToolStripMenuItem.Size = New System.Drawing.Size(276, 34)
        Me.งดแสดงฐานะทางการเงนToolStripMenuItem.Text = "งบแสดงฐานะทางการเงิน"
        '
        'tsm_other
        '
        Me.tsm_other.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.จดการสมาชกToolStripMenuItem, Me.จดการสทธToolStripMenuItem, Me.สำรองขอมลToolStripMenuItem, Me.อานบตรToolStripMenuItem, Me.สมาชกลาออกToolStripMenuItem})
        Me.tsm_other.Font = New System.Drawing.Font("TH SarabunPSK", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsm_other.Name = "tsm_other"
        Me.tsm_other.Size = New System.Drawing.Size(60, 34)
        Me.tsm_other.Text = "อื่นๆ"
        '
        'จดการสมาชกToolStripMenuItem
        '
        Me.จดการสมาชกToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.เพมสมาชกToolStripMenuItem, Me.เรยกดสมาชกฃToolStripMenuItem})
        Me.จดการสมาชกToolStripMenuItem.Name = "จดการสมาชกToolStripMenuItem"
        Me.จดการสมาชกToolStripMenuItem.Size = New System.Drawing.Size(192, 34)
        Me.จดการสมาชกToolStripMenuItem.Text = "จัดการสมาชิก"
        '
        'เพมสมาชกToolStripMenuItem
        '
        Me.เพมสมาชกToolStripMenuItem.Name = "เพมสมาชกToolStripMenuItem"
        Me.เพมสมาชกToolStripMenuItem.Size = New System.Drawing.Size(186, 34)
        Me.เพมสมาชกToolStripMenuItem.Text = "เพิ่มสมาชิก"
        '
        'เรยกดสมาชกฃToolStripMenuItem
        '
        Me.เรยกดสมาชกฃToolStripMenuItem.Name = "เรยกดสมาชกฃToolStripMenuItem"
        Me.เรยกดสมาชกฃToolStripMenuItem.Size = New System.Drawing.Size(186, 34)
        Me.เรยกดสมาชกฃToolStripMenuItem.Text = "เรียกดูสมาชิก"
        '
        'จดการสทธToolStripMenuItem
        '
        Me.จดการสทธToolStripMenuItem.Name = "จดการสทธToolStripMenuItem"
        Me.จดการสทธToolStripMenuItem.Size = New System.Drawing.Size(192, 34)
        Me.จดการสทธToolStripMenuItem.Text = "จัดการสิทธิ"
        '
        'สำรองขอมลToolStripMenuItem
        '
        Me.สำรองขอมลToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.สำรองขอมลToolStripMenuItem1, Me.นำเขาขอมลToolStripMenuItem1})
        Me.สำรองขอมลToolStripMenuItem.Name = "สำรองขอมลToolStripMenuItem"
        Me.สำรองขอมลToolStripMenuItem.Size = New System.Drawing.Size(192, 34)
        Me.สำรองขอมลToolStripMenuItem.Text = "จัดการข้อมูล"
        '
        'สำรองขอมลToolStripMenuItem1
        '
        Me.สำรองขอมลToolStripMenuItem1.Name = "สำรองขอมลToolStripMenuItem1"
        Me.สำรองขอมลToolStripMenuItem1.Size = New System.Drawing.Size(179, 34)
        Me.สำรองขอมลToolStripMenuItem1.Text = "สำรองข้อมูล"
        '
        'นำเขาขอมลToolStripMenuItem1
        '
        Me.นำเขาขอมลToolStripMenuItem1.Name = "นำเขาขอมลToolStripMenuItem1"
        Me.นำเขาขอมลToolStripMenuItem1.Size = New System.Drawing.Size(179, 34)
        Me.นำเขาขอมลToolStripMenuItem1.Text = "นำเข้าข้อมูล"
        '
        'อานบตรToolStripMenuItem
        '
        Me.อานบตรToolStripMenuItem.Name = "อานบตรToolStripMenuItem"
        Me.อานบตรToolStripMenuItem.Size = New System.Drawing.Size(192, 34)
        Me.อานบตรToolStripMenuItem.Text = "อ่านบัตร"
        '
        'สมาชกลาออกToolStripMenuItem
        '
        Me.สมาชกลาออกToolStripMenuItem.Name = "สมาชกลาออกToolStripMenuItem"
        Me.สมาชกลาออกToolStripMenuItem.Size = New System.Drawing.Size(192, 34)
        Me.สมาชกลาออกToolStripMenuItem.Text = "สมาชิกลาออก"
        '
        'ออกจากระบบToolStripMenuItem
        '
        Me.ออกจากระบบToolStripMenuItem.BackColor = System.Drawing.Color.Red
        Me.ออกจากระบบToolStripMenuItem.Font = New System.Drawing.Font("TH SarabunPSK", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ออกจากระบบToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.ออกจากระบบToolStripMenuItem.Name = "ออกจากระบบToolStripMenuItem"
        Me.ออกจากระบบToolStripMenuItem.Size = New System.Drawing.Size(131, 34)
        Me.ออกจากระบบToolStripMenuItem.Text = "ออกจากระบบ"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.lbCount)
        Me.GroupBox1.Font = New System.Drawing.Font("TH SarabunPSK", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(9, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(236, 75)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "สมาชิกทั้งหมด"
        '
        'lbCount
        '
        Me.lbCount.AutoSize = True
        Me.lbCount.BackColor = System.Drawing.SystemColors.Control
        Me.lbCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbCount.Location = New System.Drawing.Point(6, 34)
        Me.lbCount.Name = "lbCount"
        Me.lbCount.Size = New System.Drawing.Size(162, 30)
        Me.lbCount.TabIndex = 1
        Me.lbCount.Text = "แสดงจำนวนสมาชิก"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.Controls.Add(Me.lbContractCount)
        Me.GroupBox2.Font = New System.Drawing.Font("TH SarabunPSK", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(9, 84)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(236, 75)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "จำนวนการทำสัญญา"
        '
        'lbContractCount
        '
        Me.lbContractCount.AutoSize = True
        Me.lbContractCount.BackColor = System.Drawing.SystemColors.Control
        Me.lbContractCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbContractCount.Location = New System.Drawing.Point(6, 34)
        Me.lbContractCount.Name = "lbContractCount"
        Me.lbContractCount.Size = New System.Drawing.Size(159, 30)
        Me.lbContractCount.TabIndex = 2
        Me.lbContractCount.Text = "แสดงจำนวนสัญญา"
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.panelHeader.Controls.Add(Me.lblDateTime)
        Me.panelHeader.Controls.Add(Me.lblUserInfo)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelHeader.Location = New System.Drawing.Point(0, 423)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Size = New System.Drawing.Size(784, 38)
        Me.panelHeader.TabIndex = 14
        '
        'lblDateTime
        '
        Me.lblDateTime.AutoSize = True
        Me.lblDateTime.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateTime.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDateTime.Location = New System.Drawing.Point(542, 9)
        Me.lblDateTime.Name = "lblDateTime"
        Me.lblDateTime.Size = New System.Drawing.Size(37, 24)
        Me.lblDateTime.TabIndex = 15
        Me.lblDateTime.Text = "เวลา"
        '
        'lblUserInfo
        '
        Me.lblUserInfo.AutoSize = True
        Me.lblUserInfo.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserInfo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblUserInfo.Location = New System.Drawing.Point(3, 9)
        Me.lblUserInfo.Name = "lblUserInfo"
        Me.lblUserInfo.Size = New System.Drawing.Size(56, 24)
        Me.lblUserInfo.TabIndex = 0
        Me.lblUserInfo.Text = "ผู้ใช้งาน"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(756, 41)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(28, 23)
        Me.btnRefresh.TabIndex = 15
        Me.btnRefresh.Text = "Button1"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Location = New System.Drawing.Point(22, 60)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(255, 169)
        Me.Panel1.TabIndex = 16
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(784, 461)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.panelHeader)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "หนักหลัก"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents tsm_exp As ToolStripMenuItem
    Friend WithEvents ทำสญญาToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents แกไขสญญาToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents คาใชจายToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents แกไขคาใชจายToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tsm_rev As ToolStripMenuItem
    Friend WithEvents รบเงนToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tsm_report As ToolStripMenuItem
    Friend WithEvents รายงานลกหนรายตวToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents รายงานเงนฝากสมาชกToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents รายงานบญชToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents งบทดลองToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents งบกำไรขาดทนToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents งดแสดงฐานะทางการเงนToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tsm_other As ToolStripMenuItem
    Friend WithEvents จดการสมาชกToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents เพมสมาชกToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents เรยกดสมาชกฃToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents จดการสทธToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents สำรองขอมลToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents สำรองขอมลToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents นำเขาขอมลToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ออกจากระบบToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lbCount As Label
    Friend WithEvents อานบตรToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lbContractCount As Label
    Friend WithEvents panelHeader As Panel
    Friend WithEvents lblUserInfo As Label
    Friend WithEvents lblDateTime As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents btnRefresh As Button
    Friend WithEvents ตารางเงนกToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents สญญาเงนกToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents สมาชกลาออกToolStripMenuItem As ToolStripMenuItem
End Class

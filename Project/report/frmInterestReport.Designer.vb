<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInterestReport
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
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.cbMonth = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.cbYear = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.btnLoadReport = New Guna.UI2.WinForms.Guna2Button()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 91)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(776, 347)
        Me.ReportViewer1.TabIndex = 0
        '
        'cbMonth
        '
        Me.cbMonth.BackColor = System.Drawing.Color.Transparent
        Me.cbMonth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMonth.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbMonth.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbMonth.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cbMonth.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cbMonth.ItemHeight = 30
        Me.cbMonth.Location = New System.Drawing.Point(12, 35)
        Me.cbMonth.Name = "cbMonth"
        Me.cbMonth.Size = New System.Drawing.Size(140, 36)
        Me.cbMonth.TabIndex = 1
        '
        'cbYear
        '
        Me.cbYear.BackColor = System.Drawing.Color.Transparent
        Me.cbYear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbYear.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbYear.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbYear.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cbYear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cbYear.ItemHeight = 30
        Me.cbYear.Location = New System.Drawing.Point(203, 35)
        Me.cbYear.Name = "cbYear"
        Me.cbYear.Size = New System.Drawing.Size(140, 36)
        Me.cbYear.TabIndex = 1
        '
        'btnLoadReport
        '
        Me.btnLoadReport.BorderRadius = 10
        Me.btnLoadReport.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnLoadReport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnLoadReport.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnLoadReport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnLoadReport.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnLoadReport.ForeColor = System.Drawing.Color.White
        Me.btnLoadReport.Location = New System.Drawing.Point(360, 26)
        Me.btnLoadReport.Name = "btnLoadReport"
        Me.btnLoadReport.Size = New System.Drawing.Size(180, 45)
        Me.btnLoadReport.TabIndex = 2
        Me.btnLoadReport.Text = "Guna2Button1"
        '
        'frmInterestReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnLoadReport)
        Me.Controls.Add(Me.cbYear)
        Me.Controls.Add(Me.cbMonth)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frmInterestReport"
        Me.Text = "frmInterestReport"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents cbMonth As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents cbYear As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents btnLoadReport As Guna.UI2.WinForms.Guna2Button
End Class

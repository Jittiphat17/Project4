<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInter
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
        Me.btnViewReport = New Guna.UI2.WinForms.Guna2Button()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Project.IncomeReport.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 89)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(980, 349)
        Me.ReportViewer1.TabIndex = 0
        '
        'btnViewReport
        '
        Me.btnViewReport.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnViewReport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnViewReport.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnViewReport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnViewReport.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnViewReport.ForeColor = System.Drawing.Color.White
        Me.btnViewReport.Location = New System.Drawing.Point(716, 38)
        Me.btnViewReport.Name = "btnViewReport"
        Me.btnViewReport.Size = New System.Drawing.Size(276, 45)
        Me.btnViewReport.TabIndex = 1
        Me.btnViewReport.Text = "Guna2Button1"
        '
        'frmInter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1004, 461)
        Me.Controls.Add(Me.btnViewReport)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frmInter"
        Me.Text = "frmInter"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents btnViewReport As Guna.UI2.WinForms.Guna2Button
End Class

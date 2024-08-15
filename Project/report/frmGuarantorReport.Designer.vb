<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmGuarantorReport
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ReportViewerGuarantor = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'ReportViewerGuarantor
        '
        Me.ReportViewerGuarantor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewerGuarantor.LocalReport.ReportEmbeddedResource = "Project.GuarantorReport.rdlc"
        Me.ReportViewerGuarantor.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewerGuarantor.Name = "ReportViewerGuarantor"
        Me.ReportViewerGuarantor.ServerReport.BearerToken = Nothing
        Me.ReportViewerGuarantor.Size = New System.Drawing.Size(800, 450)
        Me.ReportViewerGuarantor.TabIndex = 0
        '
        'frmGuarantorReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ReportViewerGuarantor)
        Me.Name = "frmGuarantorReport"
        Me.Text = "frmReportViewer"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewerGuarantor As Microsoft.Reporting.WinForms.ReportViewer
End Class

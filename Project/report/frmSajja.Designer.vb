<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSajja
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
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ComboBox1 = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Project.SajjaReport.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 89)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(1081, 518)
        Me.ReportViewer1.TabIndex = 0
        '
        'ComboBox1
        '
        Me.ComboBox1.BackColor = System.Drawing.Color.Transparent
        Me.ComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ComboBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ComboBox1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ComboBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.ComboBox1.ItemHeight = 30
        Me.ComboBox1.Location = New System.Drawing.Point(736, 35)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(357, 36)
        Me.ComboBox1.TabIndex = 1
        '
        'frmSajja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1105, 619)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frmSajja"
        Me.Text = "frmSajja"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ComboBox1 As Guna.UI2.WinForms.Guna2ComboBox
End Class

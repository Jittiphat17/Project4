<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSearch
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
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.dgvResults = New System.Windows.Forms.DataGridView()
        Me.btnReport = New System.Windows.Forms.Button()
        Me.cbReportType = New System.Windows.Forms.ComboBox()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ReportViewer2 = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.dgvResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(12, 12)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(300, 20)
        Me.txtSearch.TabIndex = 0
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(318, 10)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "ค้นหา"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'dgvResults
        '
        Me.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResults.Location = New System.Drawing.Point(12, 40)
        Me.dgvResults.Name = "dgvResults"
        Me.dgvResults.Size = New System.Drawing.Size(1033, 200)
        Me.dgvResults.TabIndex = 2
        '
        'btnReport
        '
        Me.btnReport.Location = New System.Drawing.Point(399, 10)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(75, 23)
        Me.btnReport.TabIndex = 3
        Me.btnReport.Text = "สร้างรายงาน"
        Me.btnReport.UseVisualStyleBackColor = True
        '
        'cbReportType
        '
        Me.cbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbReportType.FormattingEnabled = True
        Me.cbReportType.Location = New System.Drawing.Point(480, 10)
        Me.cbReportType.Name = "cbReportType"
        Me.cbReportType.Size = New System.Drawing.Size(121, 21)
        Me.cbReportType.TabIndex = 5
        '
        'ReportViewer1
        '
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Project.LoanReport1.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 246)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(507, 538)
        Me.ReportViewer1.TabIndex = 6
        '
        'ReportViewer2
        '
        Me.ReportViewer2.LocalReport.ReportEmbeddedResource = "Project.GuarantorReport1.rdlc"
        Me.ReportViewer2.Location = New System.Drawing.Point(538, 246)
        Me.ReportViewer2.Name = "ReportViewer2"
        Me.ReportViewer2.ServerReport.BearerToken = Nothing
        Me.ReportViewer2.Size = New System.Drawing.Size(507, 538)
        Me.ReportViewer2.TabIndex = 7
        '
        'frmSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1057, 796)
        Me.Controls.Add(Me.ReportViewer2)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.cbReportType)
        Me.Controls.Add(Me.btnReport)
        Me.Controls.Add(Me.dgvResults)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Name = "frmSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ค้นหาสัญญา"
        CType(Me.dgvResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents dgvResults As System.Windows.Forms.DataGridView
    Friend WithEvents btnReport As System.Windows.Forms.Button
    Friend WithEvents cbReportType As ComboBox
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ReportViewer2 As Microsoft.Reporting.WinForms.ReportViewer
End Class

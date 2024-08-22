<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMemberResign
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
        Me.txtSearchMember = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTotalSaving = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtBeforeTotalSaving = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTotalLoan = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLoanPublic = New System.Windows.Forms.TextBox()
        Me.txtLoanSaving = New System.Windows.Forms.TextBox()
        Me.txtLoanAccount1 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtSearchMember
        '
        Me.txtSearchMember.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchMember.Location = New System.Drawing.Point(584, 18)
        Me.txtSearchMember.Name = "txtSearchMember"
        Me.txtSearchMember.Size = New System.Drawing.Size(204, 31)
        Me.txtSearchMember.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtTotalSaving)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtBeforeTotalSaving)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 55)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(776, 162)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "เงินฝาก"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(729, 127)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(35, 24)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "บาท"
        '
        'txtTotalSaving
        '
        Me.txtTotalSaving.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalSaving.Location = New System.Drawing.Point(557, 124)
        Me.txtTotalSaving.Name = "txtTotalSaving"
        Me.txtTotalSaving.ReadOnly = True
        Me.txtTotalSaving.Size = New System.Drawing.Size(166, 31)
        Me.txtTotalSaving.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(475, 127)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 24)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "รวมเป็นเงิน"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(336, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 24)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "บาท"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(50, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 24)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "เงินสัจจะ :"
        '
        'txtBeforeTotalSaving
        '
        Me.txtBeforeTotalSaving.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBeforeTotalSaving.Location = New System.Drawing.Point(126, 67)
        Me.txtBeforeTotalSaving.Name = "txtBeforeTotalSaving"
        Me.txtBeforeTotalSaving.ReadOnly = True
        Me.txtBeforeTotalSaving.Size = New System.Drawing.Size(204, 31)
        Me.txtBeforeTotalSaving.TabIndex = 4
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtTotalLoan)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtLoanPublic)
        Me.GroupBox2.Controls.Add(Me.txtLoanSaving)
        Me.GroupBox2.Controls.Add(Me.txtLoanAccount1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 223)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(776, 157)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "เงินกู้"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(729, 123)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(35, 24)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "บาท"
        '
        'txtTotalLoan
        '
        Me.txtTotalLoan.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalLoan.Location = New System.Drawing.Point(557, 120)
        Me.txtTotalLoan.Name = "txtTotalLoan"
        Me.txtTotalLoan.ReadOnly = True
        Me.txtTotalLoan.Size = New System.Drawing.Size(166, 31)
        Me.txtTotalLoan.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(475, 123)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(76, 24)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "รวมเป็นเงิน"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(336, 108)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 24)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "บาท"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(336, 71)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 24)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "บาท"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(336, 34)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 24)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "บาท"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(28, 108)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 24)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "เงินประชารัฐ :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(50, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 24)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "เงินสัจจะ :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(64, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 24)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "บัญชี1 :"
        '
        'txtLoanPublic
        '
        Me.txtLoanPublic.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoanPublic.Location = New System.Drawing.Point(126, 105)
        Me.txtLoanPublic.Name = "txtLoanPublic"
        Me.txtLoanPublic.ReadOnly = True
        Me.txtLoanPublic.Size = New System.Drawing.Size(204, 31)
        Me.txtLoanPublic.TabIndex = 1
        '
        'txtLoanSaving
        '
        Me.txtLoanSaving.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoanSaving.Location = New System.Drawing.Point(126, 68)
        Me.txtLoanSaving.Name = "txtLoanSaving"
        Me.txtLoanSaving.ReadOnly = True
        Me.txtLoanSaving.Size = New System.Drawing.Size(204, 31)
        Me.txtLoanSaving.TabIndex = 1
        '
        'txtLoanAccount1
        '
        Me.txtLoanAccount1.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoanAccount1.Location = New System.Drawing.Point(126, 31)
        Me.txtLoanAccount1.Name = "txtLoanAccount1"
        Me.txtLoanAccount1.ReadOnly = True
        Me.txtLoanAccount1.Size = New System.Drawing.Size(204, 31)
        Me.txtLoanAccount1.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(444, 21)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(134, 24)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "ค้นหาด้วยชื่อสมาชิก :"
        '
        'frmMemberResign
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 407)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtSearchMember)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmMemberResign"
        Me.Text = "frmMemberResign"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSearchMember As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtLoanPublic As TextBox
    Friend WithEvents txtLoanSaving As TextBox
    Friend WithEvents txtLoanAccount1 As TextBox
    Friend WithEvents txtBeforeTotalSaving As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtTotalSaving As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtTotalLoan As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label13 As Label
End Class

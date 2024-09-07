<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.btn_login = New System.Windows.Forms.Button()
        Me.btn_exit = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtUser = New MaterialSkin.Controls.MaterialTextBox2()
        Me.txtPass = New MaterialSkin.Controls.MaterialTextBox2()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_login
        '
        Me.btn_login.BackColor = System.Drawing.SystemColors.Highlight
        Me.btn_login.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_login.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_login.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btn_login.Location = New System.Drawing.Point(38, 315)
        Me.btn_login.Name = "btn_login"
        Me.btn_login.Size = New System.Drawing.Size(269, 52)
        Me.btn_login.TabIndex = 9
        Me.btn_login.Text = "เข้าสู่ระบบ"
        Me.btn_login.UseVisualStyleBackColor = False
        '
        'btn_exit
        '
        Me.btn_exit.BackColor = System.Drawing.Color.Red
        Me.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_exit.Font = New System.Drawing.Font("TH SarabunPSK", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_exit.Location = New System.Drawing.Point(38, 374)
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(269, 52)
        Me.btn_exit.TabIndex = 10
        Me.btn_exit.Text = "ออกจากโปรแกรม"
        Me.btn_exit.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("TH SarabunPSK", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(136, 165)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 30)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Sign In"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(100, 32)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(131, 130)
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'txtUser
        '
        Me.txtUser.AnimateReadOnly = False
        Me.txtUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.txtUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtUser.Depth = 0
        Me.txtUser.Font = New System.Drawing.Font("Roboto", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.txtUser.HideSelection = True
        Me.txtUser.LeadingIcon = Nothing
        Me.txtUser.Location = New System.Drawing.Point(38, 206)
        Me.txtUser.MaxLength = 32767
        Me.txtUser.MouseState = MaterialSkin.MouseState.OUT
        Me.txtUser.Name = "txtUser"
        Me.txtUser.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtUser.PrefixSuffixText = Nothing
        Me.txtUser.ReadOnly = False
        Me.txtUser.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtUser.SelectedText = ""
        Me.txtUser.SelectionLength = 0
        Me.txtUser.SelectionStart = 0
        Me.txtUser.ShortcutsEnabled = True
        Me.txtUser.Size = New System.Drawing.Size(269, 48)
        Me.txtUser.TabIndex = 12
        Me.txtUser.TabStop = False
        Me.txtUser.Text = "MaterialTextBox21"
        Me.txtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtUser.TrailingIcon = Nothing
        Me.txtUser.UseSystemPasswordChar = False
        '
        'txtPass
        '
        Me.txtPass.AnimateReadOnly = False
        Me.txtPass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.txtPass.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtPass.Depth = 0
        Me.txtPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.txtPass.HideSelection = True
        Me.txtPass.LeadingIcon = Nothing
        Me.txtPass.Location = New System.Drawing.Point(38, 261)
        Me.txtPass.MaxLength = 32767
        Me.txtPass.MouseState = MaterialSkin.MouseState.OUT
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPass.PrefixSuffixText = Nothing
        Me.txtPass.ReadOnly = False
        Me.txtPass.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPass.SelectedText = ""
        Me.txtPass.SelectionLength = 0
        Me.txtPass.SelectionStart = 0
        Me.txtPass.ShortcutsEnabled = True
        Me.txtPass.Size = New System.Drawing.Size(269, 48)
        Me.txtPass.TabIndex = 12
        Me.txtPass.TabStop = False
        Me.txtPass.Text = "MaterialTextBox21"
        Me.txtPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtPass.TrailingIcon = Nothing
        Me.txtPass.UseSystemPasswordChar = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(343, 438)
        Me.Controls.Add(Me.txtPass)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btn_login)
        Me.Controls.Add(Me.btn_exit)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_login As Button
    Friend WithEvents btn_exit As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents txtUser As MaterialSkin.Controls.MaterialTextBox2
    Friend WithEvents txtPass As MaterialSkin.Controls.MaterialTextBox2
End Class

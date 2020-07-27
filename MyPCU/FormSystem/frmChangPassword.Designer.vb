<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChangPassword
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChangPassword))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPasswordNew = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPasswordNew2 = New System.Windows.Forms.TextBox()
        Me.cmdCancle = New System.Windows.Forms.Button()
        Me.cmdLogin = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(69, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 17)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "รหัสผ่านเดิม"
        '
        'txtPassword
        '
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.Location = New System.Drawing.Point(144, 33)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(168, 25)
        Me.txtPassword.TabIndex = 64
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(68, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 17)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "รหัสผ่านใหม่"
        '
        'txtPasswordNew
        '
        Me.txtPasswordNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPasswordNew.Location = New System.Drawing.Point(144, 73)
        Me.txtPasswordNew.Name = "txtPasswordNew"
        Me.txtPasswordNew.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPasswordNew.Size = New System.Drawing.Size(168, 25)
        Me.txtPasswordNew.TabIndex = 66
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(34, 117)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 17)
        Me.Label3.TabIndex = 69
        Me.Label3.Text = "ยืนยัน รหัสผ่านใหม่"
        '
        'txtPasswordNew2
        '
        Me.txtPasswordNew2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPasswordNew2.Location = New System.Drawing.Point(144, 114)
        Me.txtPasswordNew2.Name = "txtPasswordNew2"
        Me.txtPasswordNew2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPasswordNew2.Size = New System.Drawing.Size(168, 25)
        Me.txtPasswordNew2.TabIndex = 68
        '
        'cmdCancle
        '
        Me.cmdCancle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdCancle.Image = Global.MyPCU.My.Resources.Resources.a_cancle
        Me.cmdCancle.Location = New System.Drawing.Point(216, 170)
        Me.cmdCancle.Name = "cmdCancle"
        Me.cmdCancle.Size = New System.Drawing.Size(114, 30)
        Me.cmdCancle.TabIndex = 71
        Me.cmdCancle.Text = " Cancel"
        Me.cmdCancle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdCancle.UseVisualStyleBackColor = True
        '
        'cmdLogin
        '
        Me.cmdLogin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdLogin.Image = Global.MyPCU.My.Resources.Resources.a_save
        Me.cmdLogin.Location = New System.Drawing.Point(94, 170)
        Me.cmdLogin.Name = "cmdLogin"
        Me.cmdLogin.Size = New System.Drawing.Size(114, 30)
        Me.cmdLogin.TabIndex = 70
        Me.cmdLogin.Text = " Save"
        Me.cmdLogin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdLogin.UseVisualStyleBackColor = True
        '
        'frmChangPassword
        '
        Me.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(397, 229)
        Me.Controls.Add(Me.cmdCancle)
        Me.Controls.Add(Me.cmdLogin)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPasswordNew2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPasswordNew)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPassword)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmChangPassword"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "เปลี่ยนรหัสผ่าน"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPasswordNew As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPasswordNew2 As System.Windows.Forms.TextBox
    Friend WithEvents cmdCancle As System.Windows.Forms.Button
    Friend WithEvents cmdLogin As System.Windows.Forms.Button
End Class

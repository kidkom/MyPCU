<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSendMyPCUConfig
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSendMyPCUConfig))
        Me.txtDatabasename = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdTest = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDataSource = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtUserID = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtDatabasename
        '
        Me.txtDatabasename.BackColor = System.Drawing.Color.Beige
        Me.txtDatabasename.Location = New System.Drawing.Point(135, 58)
        Me.txtDatabasename.MaxLength = 50
        Me.txtDatabasename.Name = "txtDatabasename"
        Me.txtDatabasename.Size = New System.Drawing.Size(160, 25)
        Me.txtDatabasename.TabIndex = 57
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(27, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 17)
        Me.Label5.TabIndex = 58
        Me.Label5.Text = "Database Name"
        '
        'cmdClose
        '
        Me.cmdClose.Image = Global.MyPCU.My.Resources.Resources.a_cancle
        Me.cmdClose.Location = New System.Drawing.Point(373, 138)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(113, 31)
        Me.cmdClose.TabIndex = 56
        Me.cmdClose.Text = "ออก"
        Me.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'txtPort
        '
        Me.txtPort.BackColor = System.Drawing.Color.Beige
        Me.txtPort.Location = New System.Drawing.Point(390, 28)
        Me.txtPort.MaxLength = 10
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(112, 25)
        Me.txtPort.TabIndex = 48
        '
        'cmdSave
        '
        Me.cmdSave.Image = Global.MyPCU.My.Resources.Resources.a_save
        Me.cmdSave.Location = New System.Drawing.Point(254, 138)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(113, 31)
        Me.cmdSave.TabIndex = 54
        Me.cmdSave.Text = "บันทึก"
        Me.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdTest
        '
        Me.cmdTest.Image = Global.MyPCU.My.Resources.Resources.a_connect
        Me.cmdTest.Location = New System.Drawing.Point(135, 138)
        Me.cmdTest.Name = "cmdTest"
        Me.cmdTest.Size = New System.Drawing.Size(113, 31)
        Me.cmdTest.TabIndex = 55
        Me.cmdTest.Text = "ทดสอบ"
        Me.cmdTest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdTest.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(320, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 17)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "Password"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(53, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 17)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Server Host"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(62, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 17)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "Username"
        '
        'txtDataSource
        '
        Me.txtDataSource.BackColor = System.Drawing.Color.Beige
        Me.txtDataSource.Location = New System.Drawing.Point(135, 27)
        Me.txtDataSource.MaxLength = 50
        Me.txtDataSource.Name = "txtDataSource"
        Me.txtDataSource.Size = New System.Drawing.Size(160, 25)
        Me.txtDataSource.TabIndex = 47
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(352, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 17)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Port"
        '
        'txtUserID
        '
        Me.txtUserID.BackColor = System.Drawing.Color.Beige
        Me.txtUserID.Location = New System.Drawing.Point(135, 90)
        Me.txtUserID.MaxLength = 50
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(160, 25)
        Me.txtUserID.TabIndex = 49
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.Color.Beige
        Me.txtPassword.Location = New System.Drawing.Point(390, 90)
        Me.txtPassword.MaxLength = 50
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(191, 25)
        Me.txtPassword.TabIndex = 50
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'frmSendMyPCUConfig
        '
        Me.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(606, 195)
        Me.Controls.Add(Me.txtDatabasename)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdTest)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDataSource)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtUserID)
        Me.Controls.Add(Me.txtPassword)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSendMyPCUConfig"
        Me.ShowInTaskbar = False
        Me.Text = "กำหนดค่าการเชื่อมต่อ MyData"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDatabasename As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdTest As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDataSource As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtUserID As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
End Class

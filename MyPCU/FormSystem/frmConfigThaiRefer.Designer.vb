<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfigThaiRefer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfigThaiRefer))
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDatabasename = New System.Windows.Forms.TextBox()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDataSource = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtUserID = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdTest = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(29, 77)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 17)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "Database Name"
        '
        'txtDatabasename
        '
        Me.txtDatabasename.Location = New System.Drawing.Point(137, 74)
        Me.txtDatabasename.MaxLength = 50
        Me.txtDatabasename.Name = "txtDatabasename"
        Me.txtDatabasename.Size = New System.Drawing.Size(160, 25)
        Me.txtDatabasename.TabIndex = 50
        Me.txtDatabasename.Text = "referdb"
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(360, 36)
        Me.txtPort.MaxLength = 10
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(112, 25)
        Me.txtPort.TabIndex = 40
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(290, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 17)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "Password"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(55, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 17)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Server Host"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(64, 115)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 17)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Username"
        '
        'txtDataSource
        '
        Me.txtDataSource.Location = New System.Drawing.Point(137, 36)
        Me.txtDataSource.MaxLength = 50
        Me.txtDataSource.Name = "txtDataSource"
        Me.txtDataSource.Size = New System.Drawing.Size(160, 25)
        Me.txtDataSource.TabIndex = 39
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(316, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 17)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "Port"
        '
        'txtUserID
        '
        Me.txtUserID.Location = New System.Drawing.Point(137, 111)
        Me.txtUserID.MaxLength = 50
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(111, 25)
        Me.txtUserID.TabIndex = 41
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(360, 111)
        Me.txtPassword.MaxLength = 50
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(112, 25)
        Me.txtPassword.TabIndex = 42
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'cmdClose
        '
        Me.cmdClose.Image = Global.MyPCU.My.Resources.Resources.a_cancle
        Me.cmdClose.Location = New System.Drawing.Point(354, 183)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(119, 33)
        Me.cmdClose.TabIndex = 48
        Me.cmdClose.Text = "ออก"
        Me.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdTest
        '
        Me.cmdTest.Image = Global.MyPCU.My.Resources.Resources.a_connect
        Me.cmdTest.Location = New System.Drawing.Point(104, 183)
        Me.cmdTest.Name = "cmdTest"
        Me.cmdTest.Size = New System.Drawing.Size(119, 33)
        Me.cmdTest.TabIndex = 47
        Me.cmdTest.Text = "ทดสอบ"
        Me.cmdTest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdTest.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Image = Global.MyPCU.My.Resources.Resources.a_save
        Me.cmdSave.Location = New System.Drawing.Point(229, 183)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(119, 33)
        Me.cmdSave.TabIndex = 46
        Me.cmdSave.Text = "บันทึก"
        Me.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.txtDataSource)
        Me.GroupControl1.Controls.Add(Me.Label5)
        Me.GroupControl1.Controls.Add(Me.txtPassword)
        Me.GroupControl1.Controls.Add(Me.txtDatabasename)
        Me.GroupControl1.Controls.Add(Me.txtUserID)
        Me.GroupControl1.Controls.Add(Me.Label1)
        Me.GroupControl1.Controls.Add(Me.txtPort)
        Me.GroupControl1.Controls.Add(Me.Label3)
        Me.GroupControl1.Controls.Add(Me.Label2)
        Me.GroupControl1.Controls.Add(Me.Label4)
        Me.GroupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Card
        Me.GroupControl1.Location = New System.Drawing.Point(12, 12)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(544, 161)
        Me.GroupControl1.TabIndex = 51
        Me.GroupControl1.Text = "ตั้งค่าเชื่อมต่อ Thai Refer"
        '
        'frmConfigThaiRefer
        '
        Me.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(568, 233)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdTest)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConfigThaiRefer"
        Me.Text = "กำหนดค่าการเชื่อมต่อ Thai Refer"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label5 As Label
    Friend WithEvents txtDatabasename As TextBox
    Friend WithEvents cmdClose As Button
    Friend WithEvents txtPort As TextBox
    Friend WithEvents cmdTest As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents cmdSave As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtDataSource As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtUserID As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
End Class

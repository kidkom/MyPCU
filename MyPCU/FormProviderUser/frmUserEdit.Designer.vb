<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUserEdit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUserEdit))
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.chkPorvider0 = New System.Windows.Forms.CheckBox()
        Me.chkPorvider1 = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.optUser = New System.Windows.Forms.CheckBox()
        Me.optAdmin = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkStatus1 = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkStatus0 = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.cboPrename = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPrename = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtLName = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblUSERID = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCID = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.chkMetUser = New System.Windows.Forms.CheckBox()
        Me.chkDataAdmin = New System.Windows.Forms.CheckBox()
        Me.chkAccout = New System.Windows.Forms.CheckBox()
        Me.chkAsset = New System.Windows.Forms.CheckBox()
        Me.chkMetAdmin = New System.Windows.Forms.CheckBox()
        Me.chkDrug = New System.Windows.Forms.CheckBox()
        Me.chkChronic = New System.Windows.Forms.CheckBox()
        Me.chkService = New System.Windows.Forms.CheckBox()
        Me.chkPop = New System.Windows.Forms.CheckBox()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblCIDError = New System.Windows.Forms.Label()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.cboPrename.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.lblCIDError)
        Me.GroupControl1.Controls.Add(Me.chkPorvider0)
        Me.GroupControl1.Controls.Add(Me.chkPorvider1)
        Me.GroupControl1.Controls.Add(Me.Label9)
        Me.GroupControl1.Controls.Add(Me.optUser)
        Me.GroupControl1.Controls.Add(Me.optAdmin)
        Me.GroupControl1.Controls.Add(Me.Label6)
        Me.GroupControl1.Controls.Add(Me.chkStatus1)
        Me.GroupControl1.Controls.Add(Me.Label2)
        Me.GroupControl1.Controls.Add(Me.chkStatus0)
        Me.GroupControl1.Controls.Add(Me.Label7)
        Me.GroupControl1.Controls.Add(Me.txtPassword)
        Me.GroupControl1.Controls.Add(Me.Label8)
        Me.GroupControl1.Controls.Add(Me.txtUsername)
        Me.GroupControl1.Controls.Add(Me.cboPrename)
        Me.GroupControl1.Controls.Add(Me.Label5)
        Me.GroupControl1.Controls.Add(Me.txtPrename)
        Me.GroupControl1.Controls.Add(Me.Label3)
        Me.GroupControl1.Controls.Add(Me.Label4)
        Me.GroupControl1.Controls.Add(Me.txtLName)
        Me.GroupControl1.Controls.Add(Me.txtName)
        Me.GroupControl1.Controls.Add(Me.lblUSERID)
        Me.GroupControl1.Controls.Add(Me.Label10)
        Me.GroupControl1.Controls.Add(Me.txtCID)
        Me.GroupControl1.Controls.Add(Me.Label1)
        Me.GroupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Card
        Me.GroupControl1.Location = New System.Drawing.Point(21, 22)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(757, 296)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "บันทึกข้อมูลผู้ใช้งาน"
        '
        'chkPorvider0
        '
        Me.chkPorvider0.AutoSize = True
        Me.chkPorvider0.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.chkPorvider0.ForeColor = System.Drawing.Color.Red
        Me.chkPorvider0.Location = New System.Drawing.Point(496, 227)
        Me.chkPorvider0.Name = "chkPorvider0"
        Me.chkPorvider0.Size = New System.Drawing.Size(52, 21)
        Me.chkPorvider0.TabIndex = 1137
        Me.chkPorvider0.Text = "ไม่ใช่"
        Me.chkPorvider0.UseVisualStyleBackColor = True
        '
        'chkPorvider1
        '
        Me.chkPorvider1.AutoSize = True
        Me.chkPorvider1.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.chkPorvider1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.chkPorvider1.Location = New System.Drawing.Point(440, 227)
        Me.chkPorvider1.Name = "chkPorvider1"
        Me.chkPorvider1.Size = New System.Drawing.Size(40, 21)
        Me.chkPorvider1.TabIndex = 1136
        Me.chkPorvider1.Text = "ใช่"
        Me.chkPorvider1.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label9.Location = New System.Drawing.Point(324, 229)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 17)
        Me.Label9.TabIndex = 1135
        Me.Label9.Text = "ผู้ให้บริการรักษาได้"
        '
        'optUser
        '
        Me.optUser.AutoSize = True
        Me.optUser.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.optUser.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.optUser.Location = New System.Drawing.Point(215, 227)
        Me.optUser.Name = "optUser"
        Me.optUser.Size = New System.Drawing.Size(54, 21)
        Me.optUser.TabIndex = 1134
        Me.optUser.Text = "User"
        Me.optUser.UseVisualStyleBackColor = True
        '
        'optAdmin
        '
        Me.optAdmin.AutoSize = True
        Me.optAdmin.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.optAdmin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.optAdmin.Location = New System.Drawing.Point(145, 227)
        Me.optAdmin.Name = "optAdmin"
        Me.optAdmin.Size = New System.Drawing.Size(64, 21)
        Me.optAdmin.TabIndex = 1133
        Me.optAdmin.Text = "Admin"
        Me.optAdmin.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label6.Location = New System.Drawing.Point(29, 229)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(108, 17)
        Me.Label6.TabIndex = 1132
        Me.Label6.Text = "สถานภาพการใช้งาน"
        '
        'chkStatus1
        '
        Me.chkStatus1.AutoSize = True
        Me.chkStatus1.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.chkStatus1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.chkStatus1.Location = New System.Drawing.Point(145, 257)
        Me.chkStatus1.Name = "chkStatus1"
        Me.chkStatus1.Size = New System.Drawing.Size(59, 21)
        Me.chkStatus1.TabIndex = 1130
        Me.chkStatus1.Text = "ใช้งาน"
        Me.chkStatus1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(48, 257)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 17)
        Me.Label2.TabIndex = 1129
        Me.Label2.Text = "สถานะการใช้งาน"
        '
        'chkStatus0
        '
        Me.chkStatus0.AutoSize = True
        Me.chkStatus0.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.chkStatus0.ForeColor = System.Drawing.Color.Crimson
        Me.chkStatus0.Location = New System.Drawing.Point(215, 257)
        Me.chkStatus0.Name = "chkStatus0"
        Me.chkStatus0.Size = New System.Drawing.Size(58, 21)
        Me.chkStatus0.TabIndex = 1128
        Me.chkStatus0.Text = "ยกเลิก"
        Me.chkStatus0.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(70, 193)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 17)
        Me.Label7.TabIndex = 1127
        Me.Label7.Text = "Password"
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(145, 190)
        Me.txtPassword.MaxLength = 10
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(198, 25)
        Me.txtPassword.TabIndex = 1125
        Me.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(70, 156)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 17)
        Me.Label8.TabIndex = 1126
        Me.Label8.Text = "Username"
        '
        'txtUsername
        '
        Me.txtUsername.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.Location = New System.Drawing.Point(145, 153)
        Me.txtUsername.MaxLength = 10
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(198, 25)
        Me.txtUsername.TabIndex = 1124
        Me.txtUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboPrename
        '
        Me.cboPrename.Location = New System.Drawing.Point(192, 112)
        Me.cboPrename.Name = "cboPrename"
        Me.cboPrename.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboPrename.Size = New System.Drawing.Size(151, 24)
        Me.cboPrename.TabIndex = 1123
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.Location = New System.Drawing.Point(348, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(23, 17)
        Me.Label5.TabIndex = 1122
        Me.Label5.Text = "ชื่อ"
        '
        'txtPrename
        '
        Me.txtPrename.BackColor = System.Drawing.Color.Beige
        Me.txtPrename.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtPrename.HidePromptOnLeave = True
        Me.txtPrename.Location = New System.Drawing.Point(145, 112)
        Me.txtPrename.Mask = "000"
        Me.txtPrename.Name = "txtPrename"
        Me.txtPrename.Size = New System.Drawing.Size(41, 25)
        Me.txtPrename.TabIndex = 1117
        Me.txtPrename.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPrename.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(80, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 17)
        Me.Label3.TabIndex = 1121
        Me.Label3.Text = "คำนำหน้า"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.Location = New System.Drawing.Point(510, 116)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 17)
        Me.Label4.TabIndex = 1120
        Me.Label4.Text = "นามสกุล"
        '
        'txtLName
        '
        Me.txtLName.BackColor = System.Drawing.Color.Beige
        Me.txtLName.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtLName.Location = New System.Drawing.Point(564, 112)
        Me.txtLName.Name = "txtLName"
        Me.txtLName.Size = New System.Drawing.Size(141, 25)
        Me.txtLName.TabIndex = 1119
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.Color.Beige
        Me.txtName.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtName.Location = New System.Drawing.Point(376, 112)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(128, 25)
        Me.txtName.TabIndex = 1118
        '
        'lblUSERID
        '
        Me.lblUSERID.BackColor = System.Drawing.Color.Beige
        Me.lblUSERID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUSERID.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblUSERID.Location = New System.Drawing.Point(145, 39)
        Me.lblUSERID.Name = "lblUSERID"
        Me.lblUSERID.Size = New System.Drawing.Size(128, 27)
        Me.lblUSERID.TabIndex = 607
        Me.lblUSERID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label10.Location = New System.Drawing.Point(64, 79)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(73, 17)
        Me.Label10.TabIndex = 606
        Me.Label10.Text = "เลขประชาชน"
        '
        'txtCID
        '
        Me.txtCID.BackColor = System.Drawing.Color.Beige
        Me.txtCID.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtCID.Location = New System.Drawing.Point(145, 76)
        Me.txtCID.Mask = "0000000000000"
        Me.txtCID.Name = "txtCID"
        Me.txtCID.Size = New System.Drawing.Size(128, 25)
        Me.txtCID.TabIndex = 604
        Me.txtCID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(86, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 17)
        Me.Label1.TabIndex = 605
        Me.Label1.Text = "User ID"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.chkMetUser)
        Me.GroupControl2.Controls.Add(Me.chkDataAdmin)
        Me.GroupControl2.Controls.Add(Me.chkAccout)
        Me.GroupControl2.Controls.Add(Me.chkAsset)
        Me.GroupControl2.Controls.Add(Me.chkMetAdmin)
        Me.GroupControl2.Controls.Add(Me.chkDrug)
        Me.GroupControl2.Controls.Add(Me.chkChronic)
        Me.GroupControl2.Controls.Add(Me.chkService)
        Me.GroupControl2.Controls.Add(Me.chkPop)
        Me.GroupControl2.GroupStyle = DevExpress.Utils.GroupStyle.Card
        Me.GroupControl2.Location = New System.Drawing.Point(21, 324)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(757, 136)
        Me.GroupControl2.TabIndex = 1129
        Me.GroupControl2.Text = "กำหนดระบบใช้งาน"
        '
        'chkMetUser
        '
        Me.chkMetUser.AutoSize = True
        Me.chkMetUser.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.chkMetUser.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.chkMetUser.Location = New System.Drawing.Point(340, 76)
        Me.chkMetUser.Name = "chkMetUser"
        Me.chkMetUser.Size = New System.Drawing.Size(125, 21)
        Me.chkMetUser.TabIndex = 1144
        Me.chkMetUser.Text = "งานวัสดุ (เฉพาะเบิก)"
        Me.chkMetUser.UseVisualStyleBackColor = True
        '
        'chkDataAdmin
        '
        Me.chkDataAdmin.AutoSize = True
        Me.chkDataAdmin.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.chkDataAdmin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.chkDataAdmin.Location = New System.Drawing.Point(596, 49)
        Me.chkDataAdmin.Name = "chkDataAdmin"
        Me.chkDataAdmin.Size = New System.Drawing.Size(108, 21)
        Me.chkDataAdmin.TabIndex = 1143
        Me.chkDataAdmin.Text = "การจัดการข้อมูล"
        Me.chkDataAdmin.UseVisualStyleBackColor = True
        '
        'chkAccout
        '
        Me.chkAccout.AutoSize = True
        Me.chkAccout.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.chkAccout.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.chkAccout.Location = New System.Drawing.Point(485, 76)
        Me.chkAccout.Name = "chkAccout"
        Me.chkAccout.Size = New System.Drawing.Size(77, 21)
        Me.chkAccout.TabIndex = 1142
        Me.chkAccout.Text = "ระบบบัญชี"
        Me.chkAccout.UseVisualStyleBackColor = True
        '
        'chkAsset
        '
        Me.chkAsset.AutoSize = True
        Me.chkAsset.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.chkAsset.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.chkAsset.Location = New System.Drawing.Point(485, 49)
        Me.chkAsset.Name = "chkAsset"
        Me.chkAsset.Size = New System.Drawing.Size(88, 21)
        Me.chkAsset.TabIndex = 1141
        Me.chkAsset.Text = "งานครุภัณฑ์"
        Me.chkAsset.UseVisualStyleBackColor = True
        '
        'chkMetAdmin
        '
        Me.chkMetAdmin.AutoSize = True
        Me.chkMetAdmin.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.chkMetAdmin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.chkMetAdmin.Location = New System.Drawing.Point(340, 49)
        Me.chkMetAdmin.Name = "chkMetAdmin"
        Me.chkMetAdmin.Size = New System.Drawing.Size(115, 21)
        Me.chkMetAdmin.TabIndex = 1140
        Me.chkMetAdmin.Text = "งานวัสดุ (Admin)"
        Me.chkMetAdmin.UseVisualStyleBackColor = True
        '
        'chkDrug
        '
        Me.chkDrug.AutoSize = True
        Me.chkDrug.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.chkDrug.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.chkDrug.Location = New System.Drawing.Point(173, 76)
        Me.chkDrug.Name = "chkDrug"
        Me.chkDrug.Size = New System.Drawing.Size(146, 21)
        Me.chkDrug.TabIndex = 1138
        Me.chkDrug.Text = "ระบบคลังยาและเวชภัณฑ์"
        Me.chkDrug.UseVisualStyleBackColor = True
        '
        'chkChronic
        '
        Me.chkChronic.AutoSize = True
        Me.chkChronic.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.chkChronic.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.chkChronic.Location = New System.Drawing.Point(173, 49)
        Me.chkChronic.Name = "chkChronic"
        Me.chkChronic.Size = New System.Drawing.Size(130, 21)
        Me.chkChronic.TabIndex = 1137
        Me.chkChronic.Text = "งานโรคเรื้อรัง/ผู้พิการ"
        Me.chkChronic.UseVisualStyleBackColor = True
        '
        'chkService
        '
        Me.chkService.AutoSize = True
        Me.chkService.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.chkService.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.chkService.Location = New System.Drawing.Point(63, 76)
        Me.chkService.Name = "chkService"
        Me.chkService.Size = New System.Drawing.Size(78, 21)
        Me.chkService.TabIndex = 1136
        Me.chkService.Text = "งานบริการ"
        Me.chkService.UseVisualStyleBackColor = True
        '
        'chkPop
        '
        Me.chkPop.AutoSize = True
        Me.chkPop.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.chkPop.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.chkPop.Location = New System.Drawing.Point(63, 49)
        Me.chkPop.Name = "chkPop"
        Me.chkPop.Size = New System.Drawing.Size(71, 21)
        Me.chkPop.TabIndex = 1135
        Me.chkPop.Text = "ประชากร"
        Me.chkPop.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdSave.Image = Global.MyPCU.My.Resources.Resources.a_save
        Me.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSave.Location = New System.Drawing.Point(791, 428)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(121, 32)
        Me.cmdSave.TabIndex = 1128
        Me.cmdSave.Text = "     บันทึก"
        Me.cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Image = Global.MyPCU.My.Resources.Resources.man
        Me.PictureBox1.InitialImage = CType(resources.GetObject("PictureBox1.InitialImage"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(791, 22)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(121, 143)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 890
        Me.PictureBox1.TabStop = False
        '
        'lblCIDError
        '
        Me.lblCIDError.AutoSize = True
        Me.lblCIDError.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblCIDError.ForeColor = System.Drawing.Color.Crimson
        Me.lblCIDError.Location = New System.Drawing.Point(279, 79)
        Me.lblCIDError.Name = "lblCIDError"
        Me.lblCIDError.Size = New System.Drawing.Size(136, 17)
        Me.lblCIDError.TabIndex = 1145
        Me.lblCIDError.Text = "เลขประชาชนอาจไม่ถูกต้อง"
        '
        'frmUserEdit
        '
        Me.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(924, 483)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmUserEdit"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "กำหนดผู้ใช้งานในระบบ"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.cboPrename.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblUSERID As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtCID As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents cboPrename As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPrename As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtLName As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents optUser As System.Windows.Forms.CheckBox
    Friend WithEvents optAdmin As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkStatus1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkStatus0 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents chkChronic As System.Windows.Forms.CheckBox
    Friend WithEvents chkService As System.Windows.Forms.CheckBox
    Friend WithEvents chkPop As System.Windows.Forms.CheckBox
    Friend WithEvents chkDrug As System.Windows.Forms.CheckBox
    Friend WithEvents chkAsset As System.Windows.Forms.CheckBox
    Friend WithEvents chkMetAdmin As System.Windows.Forms.CheckBox
    Friend WithEvents chkDataAdmin As System.Windows.Forms.CheckBox
    Friend WithEvents chkAccout As System.Windows.Forms.CheckBox
    Friend WithEvents chkMetUser As System.Windows.Forms.CheckBox
    Friend WithEvents chkPorvider0 As System.Windows.Forms.CheckBox
    Friend WithEvents chkPorvider1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblCIDError As System.Windows.Forms.Label
End Class

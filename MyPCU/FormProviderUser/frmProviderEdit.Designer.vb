<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProviderEdit
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProviderEdit))
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.txtLine = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtTelephone = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.chkPorvider2 = New System.Windows.Forms.CheckBox()
        Me.chkPorvider1 = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmdPrename = New System.Windows.Forms.Button()
        Me.lblErrorCode = New System.Windows.Forms.Label()
        Me.txtProviderType = New System.Windows.Forms.MaskedTextBox()
        Me.txtBirth = New DevExpress.XtraEditors.DateEdit()
        Me.cboProviderEdit = New System.Windows.Forms.Button()
        Me.txtOutDate = New DevExpress.XtraEditors.DateEdit()
        Me.txtStartDate = New DevExpress.XtraEditors.DateEdit()
        Me.cboPROVIDERTYPE = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboSEX = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboPrename = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboCouncil = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtPOSITION = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.chkCancle = New System.Windows.Forms.CheckBox()
        Me.lblPROVIDER_ID = New System.Windows.Forms.TextBox()
        Me.lblCIDError = New System.Windows.Forms.Label()
        Me.cmdSearch2 = New System.Windows.Forms.Button()
        Me.cmdSearch1 = New System.Windows.Forms.Button()
        Me.lblHospName2 = New System.Windows.Forms.Label()
        Me.txtMoveTo = New System.Windows.Forms.MaskedTextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblHospName = New System.Windows.Forms.Label()
        Me.txtMoveForm = New System.Windows.Forms.MaskedTextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtProviderTypeHosp = New System.Windows.Forms.MaskedTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSex = New System.Windows.Forms.MaskedTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPrename = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtLName = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCID = New System.Windows.Forms.MaskedTextBox()
        Me.txtCouncil = New System.Windows.Forms.MaskedTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRegisterno = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTipController1 = New DevExpress.Utils.ToolTipController(Me.components)
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdFingerPrint = New System.Windows.Forms.Button()
        Me.cmdSmartCard = New System.Windows.Forms.Button()
        Me.cmdWebCam = New System.Windows.Forms.Button()
        Me.cmdPicture = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.XtraOpenFileDialog1 = New DevExpress.XtraEditors.XtraOpenFileDialog(Me.components)
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.MyPCU.WaitForm1), True, True)
        Me.cmdUser = New System.Windows.Forms.Button()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.txtBirth.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBirth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOutDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOutDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtStartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtStartDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPROVIDERTYPE.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboSEX.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPrename.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCouncil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.txtLine)
        Me.GroupControl1.Controls.Add(Me.Label18)
        Me.GroupControl1.Controls.Add(Me.txtEmail)
        Me.GroupControl1.Controls.Add(Me.Label16)
        Me.GroupControl1.Controls.Add(Me.txtTelephone)
        Me.GroupControl1.Controls.Add(Me.Label15)
        Me.GroupControl1.Controls.Add(Me.chkPorvider2)
        Me.GroupControl1.Controls.Add(Me.chkPorvider1)
        Me.GroupControl1.Controls.Add(Me.Label13)
        Me.GroupControl1.Controls.Add(Me.cmdPrename)
        Me.GroupControl1.Controls.Add(Me.lblErrorCode)
        Me.GroupControl1.Controls.Add(Me.txtProviderType)
        Me.GroupControl1.Controls.Add(Me.txtBirth)
        Me.GroupControl1.Controls.Add(Me.cboProviderEdit)
        Me.GroupControl1.Controls.Add(Me.txtOutDate)
        Me.GroupControl1.Controls.Add(Me.txtStartDate)
        Me.GroupControl1.Controls.Add(Me.cboPROVIDERTYPE)
        Me.GroupControl1.Controls.Add(Me.cboSEX)
        Me.GroupControl1.Controls.Add(Me.cboPrename)
        Me.GroupControl1.Controls.Add(Me.cboCouncil)
        Me.GroupControl1.Controls.Add(Me.txtPOSITION)
        Me.GroupControl1.Controls.Add(Me.Label19)
        Me.GroupControl1.Controls.Add(Me.chkCancle)
        Me.GroupControl1.Controls.Add(Me.lblPROVIDER_ID)
        Me.GroupControl1.Controls.Add(Me.lblCIDError)
        Me.GroupControl1.Controls.Add(Me.cmdSearch2)
        Me.GroupControl1.Controls.Add(Me.cmdSearch1)
        Me.GroupControl1.Controls.Add(Me.lblHospName2)
        Me.GroupControl1.Controls.Add(Me.txtMoveTo)
        Me.GroupControl1.Controls.Add(Me.Label14)
        Me.GroupControl1.Controls.Add(Me.lblHospName)
        Me.GroupControl1.Controls.Add(Me.txtMoveForm)
        Me.GroupControl1.Controls.Add(Me.Label17)
        Me.GroupControl1.Controls.Add(Me.Label12)
        Me.GroupControl1.Controls.Add(Me.Label11)
        Me.GroupControl1.Controls.Add(Me.txtProviderTypeHosp)
        Me.GroupControl1.Controls.Add(Me.Label9)
        Me.GroupControl1.Controls.Add(Me.Label8)
        Me.GroupControl1.Controls.Add(Me.txtSex)
        Me.GroupControl1.Controls.Add(Me.Label7)
        Me.GroupControl1.Controls.Add(Me.Label5)
        Me.GroupControl1.Controls.Add(Me.txtPrename)
        Me.GroupControl1.Controls.Add(Me.Label3)
        Me.GroupControl1.Controls.Add(Me.Label4)
        Me.GroupControl1.Controls.Add(Me.txtLName)
        Me.GroupControl1.Controls.Add(Me.txtName)
        Me.GroupControl1.Controls.Add(Me.Label10)
        Me.GroupControl1.Controls.Add(Me.txtCID)
        Me.GroupControl1.Controls.Add(Me.txtCouncil)
        Me.GroupControl1.Controls.Add(Me.Label6)
        Me.GroupControl1.Controls.Add(Me.Label2)
        Me.GroupControl1.Controls.Add(Me.txtRegisterno)
        Me.GroupControl1.Controls.Add(Me.Label1)
        Me.GroupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Card
        Me.GroupControl1.Location = New System.Drawing.Point(12, 12)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(789, 548)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "บันทึกข้อมูลเจ้าหน้าที่"
        '
        'txtLine
        '
        Me.txtLine.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtLine.Location = New System.Drawing.Point(149, 471)
        Me.txtLine.Name = "txtLine"
        Me.txtLine.Size = New System.Drawing.Size(442, 25)
        Me.txtLine.TabIndex = 1261
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label18.Location = New System.Drawing.Point(55, 474)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(89, 17)
        Me.Label18.TabIndex = 1260
        Me.Label18.Text = "LINE Token ID"
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(149, 440)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(303, 25)
        Me.txtEmail.TabIndex = 1259
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label16.Location = New System.Drawing.Point(100, 443)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(44, 17)
        Me.Label16.TabIndex = 1258
        Me.Label16.Text = "E-mail"
        '
        'txtTelephone
        '
        Me.txtTelephone.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtTelephone.Location = New System.Drawing.Point(149, 409)
        Me.txtTelephone.Name = "txtTelephone"
        Me.txtTelephone.Size = New System.Drawing.Size(303, 25)
        Me.txtTelephone.TabIndex = 1257
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label15.Location = New System.Drawing.Point(93, 412)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(51, 17)
        Me.Label15.TabIndex = 1256
        Me.Label15.Text = "โทรศัพท์"
        '
        'chkPorvider2
        '
        Me.chkPorvider2.AutoSize = True
        Me.chkPorvider2.Location = New System.Drawing.Point(196, 382)
        Me.chkPorvider2.Name = "chkPorvider2"
        Me.chkPorvider2.Size = New System.Drawing.Size(52, 21)
        Me.chkPorvider2.TabIndex = 1255
        Me.chkPorvider2.Text = "ไม่ใช่"
        Me.chkPorvider2.UseVisualStyleBackColor = True
        '
        'chkPorvider1
        '
        Me.chkPorvider1.AutoSize = True
        Me.chkPorvider1.Location = New System.Drawing.Point(149, 382)
        Me.chkPorvider1.Name = "chkPorvider1"
        Me.chkPorvider1.Size = New System.Drawing.Size(40, 21)
        Me.chkPorvider1.TabIndex = 1254
        Me.chkPorvider1.Text = "ใช่"
        Me.chkPorvider1.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label13.Location = New System.Drawing.Point(44, 384)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 17)
        Me.Label13.TabIndex = 1253
        Me.Label13.Text = "สามารถให้บริการได้"
        '
        'cmdPrename
        '
        Me.cmdPrename.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdPrename.Image = Global.MyPCU.My.Resources.Resources.a_edit4
        Me.cmdPrename.Location = New System.Drawing.Point(353, 160)
        Me.cmdPrename.Name = "cmdPrename"
        Me.cmdPrename.Size = New System.Drawing.Size(33, 27)
        Me.cmdPrename.TabIndex = 1252
        Me.cmdPrename.UseVisualStyleBackColor = True
        '
        'lblErrorCode
        '
        Me.lblErrorCode.AutoSize = True
        Me.lblErrorCode.BackColor = System.Drawing.Color.Transparent
        Me.lblErrorCode.ForeColor = System.Drawing.Color.Crimson
        Me.lblErrorCode.Location = New System.Drawing.Point(19, 520)
        Me.lblErrorCode.Name = "lblErrorCode"
        Me.lblErrorCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblErrorCode.Size = New System.Drawing.Size(67, 17)
        Me.lblErrorCode.TabIndex = 895
        Me.lblErrorCode.Text = "ErroCODE"
        Me.lblErrorCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtProviderType
        '
        Me.txtProviderType.BackColor = System.Drawing.Color.Beige
        Me.txtProviderType.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtProviderType.Location = New System.Drawing.Point(553, 224)
        Me.txtProviderType.Name = "txtProviderType"
        Me.txtProviderType.Size = New System.Drawing.Size(104, 25)
        Me.txtProviderType.TabIndex = 1251
        Me.txtProviderType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtProviderType.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.txtProviderType.Visible = False
        '
        'txtBirth
        '
        Me.txtBirth.EditValue = Nothing
        Me.txtBirth.Location = New System.Drawing.Point(428, 192)
        Me.txtBirth.Name = "txtBirth"
        Me.txtBirth.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtBirth.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtBirth.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.txtBirth.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtBirth.Properties.EditFormat.FormatString = "dd/MM/yyyy"
        Me.txtBirth.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtBirth.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.txtBirth.Size = New System.Drawing.Size(128, 24)
        Me.txtBirth.TabIndex = 1250
        '
        'cboProviderEdit
        '
        Me.cboProviderEdit.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cboProviderEdit.Image = Global.MyPCU.My.Resources.Resources.a_edit4
        Me.cboProviderEdit.Location = New System.Drawing.Point(514, 223)
        Me.cboProviderEdit.Name = "cboProviderEdit"
        Me.cboProviderEdit.Size = New System.Drawing.Size(33, 27)
        Me.cboProviderEdit.TabIndex = 1122
        Me.cboProviderEdit.UseVisualStyleBackColor = True
        '
        'txtOutDate
        '
        Me.txtOutDate.EditValue = Nothing
        Me.txtOutDate.Location = New System.Drawing.Point(464, 256)
        Me.txtOutDate.Name = "txtOutDate"
        Me.txtOutDate.Properties.Appearance.BackColor = System.Drawing.Color.Beige
        Me.txtOutDate.Properties.Appearance.Options.UseBackColor = True
        Me.txtOutDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtOutDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtOutDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.txtOutDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtOutDate.Properties.EditFormat.FormatString = "dd/MM/yyyy"
        Me.txtOutDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtOutDate.Size = New System.Drawing.Size(127, 24)
        Me.txtOutDate.TabIndex = 1121
        '
        'txtStartDate
        '
        Me.txtStartDate.EditValue = Nothing
        Me.txtStartDate.Location = New System.Drawing.Point(149, 256)
        Me.txtStartDate.Name = "txtStartDate"
        Me.txtStartDate.Properties.Appearance.BackColor = System.Drawing.Color.Beige
        Me.txtStartDate.Properties.Appearance.Options.UseBackColor = True
        Me.txtStartDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtStartDate.Size = New System.Drawing.Size(127, 24)
        Me.txtStartDate.TabIndex = 1120
        '
        'cboPROVIDERTYPE
        '
        Me.cboPROVIDERTYPE.Location = New System.Drawing.Point(195, 225)
        Me.cboPROVIDERTYPE.Name = "cboPROVIDERTYPE"
        Me.cboPROVIDERTYPE.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboPROVIDERTYPE.Size = New System.Drawing.Size(313, 24)
        Me.cboPROVIDERTYPE.TabIndex = 1119
        '
        'cboSEX
        '
        Me.cboSEX.Location = New System.Drawing.Point(196, 193)
        Me.cboSEX.Name = "cboSEX"
        Me.cboSEX.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboSEX.Size = New System.Drawing.Size(81, 24)
        Me.cboSEX.TabIndex = 1117
        '
        'cboPrename
        '
        Me.cboPrename.Location = New System.Drawing.Point(196, 161)
        Me.cboPrename.Name = "cboPrename"
        Me.cboPrename.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboPrename.Size = New System.Drawing.Size(151, 24)
        Me.cboPrename.TabIndex = 1116
        '
        'cboCouncil
        '
        Me.cboCouncil.Location = New System.Drawing.Point(220, 99)
        Me.cboCouncil.Name = "cboCouncil"
        Me.cboCouncil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboCouncil.Size = New System.Drawing.Size(489, 24)
        Me.cboCouncil.TabIndex = 1115
        '
        'txtPOSITION
        '
        Me.txtPOSITION.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtPOSITION.Location = New System.Drawing.Point(149, 351)
        Me.txtPOSITION.Name = "txtPOSITION"
        Me.txtPOSITION.Size = New System.Drawing.Size(442, 25)
        Me.txtPOSITION.TabIndex = 652
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label19.Location = New System.Drawing.Point(60, 354)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(84, 17)
        Me.Label19.TabIndex = 651
        Me.Label19.Text = "ตำแหน่งปัจจุบัน"
        '
        'chkCancle
        '
        Me.chkCancle.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkCancle.AutoSize = True
        Me.chkCancle.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.chkCancle.ForeColor = System.Drawing.Color.Crimson
        Me.chkCancle.Location = New System.Drawing.Point(582, 516)
        Me.chkCancle.Name = "chkCancle"
        Me.chkCancle.Size = New System.Drawing.Size(202, 21)
        Me.chkCancle.TabIndex = 650
        Me.chkCancle.Text = "ยกเลิก (ไม่แสดงในรายการให้เลือกใช้)"
        Me.chkCancle.UseVisualStyleBackColor = True
        '
        'lblPROVIDER_ID
        '
        Me.lblPROVIDER_ID.BackColor = System.Drawing.Color.Beige
        Me.lblPROVIDER_ID.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblPROVIDER_ID.Location = New System.Drawing.Point(149, 34)
        Me.lblPROVIDER_ID.Name = "lblPROVIDER_ID"
        Me.lblPROVIDER_ID.Size = New System.Drawing.Size(270, 25)
        Me.lblPROVIDER_ID.TabIndex = 649
        Me.lblPROVIDER_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblCIDError
        '
        Me.lblCIDError.AutoSize = True
        Me.lblCIDError.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblCIDError.ForeColor = System.Drawing.Color.Crimson
        Me.lblCIDError.Location = New System.Drawing.Point(283, 132)
        Me.lblCIDError.Name = "lblCIDError"
        Me.lblCIDError.Size = New System.Drawing.Size(136, 17)
        Me.lblCIDError.TabIndex = 648
        Me.lblCIDError.Text = "เลขประชาชนอาจไม่ถูกต้อง"
        '
        'cmdSearch2
        '
        Me.cmdSearch2.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdSearch2.Image = CType(resources.GetObject("cmdSearch2.Image"), System.Drawing.Image)
        Me.cmdSearch2.Location = New System.Drawing.Point(597, 318)
        Me.cmdSearch2.Name = "cmdSearch2"
        Me.cmdSearch2.Size = New System.Drawing.Size(33, 27)
        Me.cmdSearch2.TabIndex = 647
        Me.cmdSearch2.UseVisualStyleBackColor = True
        '
        'cmdSearch1
        '
        Me.cmdSearch1.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdSearch1.Image = CType(resources.GetObject("cmdSearch1.Image"), System.Drawing.Image)
        Me.cmdSearch1.Location = New System.Drawing.Point(597, 286)
        Me.cmdSearch1.Name = "cmdSearch1"
        Me.cmdSearch1.Size = New System.Drawing.Size(33, 27)
        Me.cmdSearch1.TabIndex = 646
        Me.cmdSearch1.UseVisualStyleBackColor = True
        '
        'lblHospName2
        '
        Me.lblHospName2.BackColor = System.Drawing.Color.White
        Me.lblHospName2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHospName2.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblHospName2.Location = New System.Drawing.Point(220, 319)
        Me.lblHospName2.Name = "lblHospName2"
        Me.lblHospName2.Size = New System.Drawing.Size(371, 24)
        Me.lblHospName2.TabIndex = 645
        Me.lblHospName2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMoveTo
        '
        Me.txtMoveTo.BackColor = System.Drawing.Color.Beige
        Me.txtMoveTo.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtMoveTo.HidePromptOnLeave = True
        Me.txtMoveTo.Location = New System.Drawing.Point(149, 319)
        Me.txtMoveTo.Mask = "00000"
        Me.txtMoveTo.Name = "txtMoveTo"
        Me.txtMoveTo.Size = New System.Drawing.Size(64, 25)
        Me.txtMoveTo.TabIndex = 621
        Me.txtMoveTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtMoveTo.ValidatingType = GetType(Integer)
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(28, 323)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(116, 17)
        Me.Label14.TabIndex = 644
        Me.Label14.Text = "สถานพยาบาลที่ย้ายไป"
        '
        'lblHospName
        '
        Me.lblHospName.BackColor = System.Drawing.Color.White
        Me.lblHospName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHospName.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblHospName.Location = New System.Drawing.Point(220, 287)
        Me.lblHospName.Name = "lblHospName"
        Me.lblHospName.Size = New System.Drawing.Size(371, 24)
        Me.lblHospName.TabIndex = 643
        Me.lblHospName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMoveForm
        '
        Me.txtMoveForm.AllowDrop = True
        Me.txtMoveForm.BackColor = System.Drawing.Color.Beige
        Me.txtMoveForm.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtMoveForm.HidePromptOnLeave = True
        Me.txtMoveForm.Location = New System.Drawing.Point(149, 288)
        Me.txtMoveForm.Mask = "00000"
        Me.txtMoveForm.Name = "txtMoveForm"
        Me.txtMoveForm.Size = New System.Drawing.Size(64, 25)
        Me.txtMoveForm.TabIndex = 620
        Me.txtMoveForm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtMoveForm.ValidatingType = GetType(Integer)
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label17.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(25, 292)
        Me.Label17.Name = "Label17"
        Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label17.Size = New System.Drawing.Size(119, 17)
        Me.Label17.TabIndex = 642
        Me.Label17.Text = "สถานพยาบาลที่ย้ายมา"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label12.Location = New System.Drawing.Point(332, 260)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(126, 17)
        Me.Label12.TabIndex = 640
        Me.Label12.Text = "วันที่สิ่นสุดการปฏิบัติงาน"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label11.Location = New System.Drawing.Point(50, 260)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(94, 17)
        Me.Label11.TabIndex = 638
        Me.Label11.Text = "วันที่เริ่มปฎิบัติงาน"
        '
        'txtProviderTypeHosp
        '
        Me.txtProviderTypeHosp.BackColor = System.Drawing.Color.Beige
        Me.txtProviderTypeHosp.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtProviderTypeHosp.Location = New System.Drawing.Point(149, 224)
        Me.txtProviderTypeHosp.Name = "txtProviderTypeHosp"
        Me.txtProviderTypeHosp.Size = New System.Drawing.Size(40, 25)
        Me.txtProviderTypeHosp.TabIndex = 617
        Me.txtProviderTypeHosp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtProviderTypeHosp.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label9.Location = New System.Drawing.Point(60, 227)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 17)
        Me.Label9.TabIndex = 636
        Me.Label9.Text = "ประเภทบุคลากร"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label8.Location = New System.Drawing.Point(352, 196)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 17)
        Me.Label8.TabIndex = 634
        Me.Label8.Text = "วันเดือนปีเกิด"
        '
        'txtSex
        '
        Me.txtSex.BackColor = System.Drawing.Color.Beige
        Me.txtSex.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtSex.HidePromptOnLeave = True
        Me.txtSex.Location = New System.Drawing.Point(149, 193)
        Me.txtSex.Mask = "0"
        Me.txtSex.Name = "txtSex"
        Me.txtSex.Size = New System.Drawing.Size(40, 25)
        Me.txtSex.TabIndex = 615
        Me.txtSex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtSex.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label7.Location = New System.Drawing.Point(117, 197)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(27, 17)
        Me.Label7.TabIndex = 632
        Me.Label7.Text = "เพศ"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.Location = New System.Drawing.Point(400, 165)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(23, 17)
        Me.Label5.TabIndex = 631
        Me.Label5.Text = "ชื่อ"
        '
        'txtPrename
        '
        Me.txtPrename.BackColor = System.Drawing.Color.Beige
        Me.txtPrename.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtPrename.HidePromptOnLeave = True
        Me.txtPrename.Location = New System.Drawing.Point(149, 161)
        Me.txtPrename.Mask = "0000"
        Me.txtPrename.Name = "txtPrename"
        Me.txtPrename.Size = New System.Drawing.Size(41, 25)
        Me.txtPrename.TabIndex = 612
        Me.txtPrename.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPrename.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(87, 165)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 17)
        Me.Label3.TabIndex = 630
        Me.Label3.Text = "คำนำหน้า"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.Location = New System.Drawing.Point(562, 165)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 17)
        Me.Label4.TabIndex = 629
        Me.Label4.Text = "นามสกุล"
        '
        'txtLName
        '
        Me.txtLName.BackColor = System.Drawing.Color.Beige
        Me.txtLName.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtLName.Location = New System.Drawing.Point(616, 161)
        Me.txtLName.Name = "txtLName"
        Me.txtLName.Size = New System.Drawing.Size(141, 25)
        Me.txtLName.TabIndex = 614
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.Color.Beige
        Me.txtName.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtName.Location = New System.Drawing.Point(428, 161)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(128, 25)
        Me.txtName.TabIndex = 613
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label10.Location = New System.Drawing.Point(43, 132)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(101, 17)
        Me.Label10.TabIndex = 627
        Me.Label10.Text = "เลขที่บัตรประชาชน"
        '
        'txtCID
        '
        Me.txtCID.BackColor = System.Drawing.Color.Beige
        Me.txtCID.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtCID.Location = New System.Drawing.Point(149, 129)
        Me.txtCID.Mask = "0000000000000"
        Me.txtCID.Name = "txtCID"
        Me.txtCID.Size = New System.Drawing.Size(128, 25)
        Me.txtCID.TabIndex = 611
        Me.txtCID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCouncil
        '
        Me.txtCouncil.BackColor = System.Drawing.Color.Beige
        Me.txtCouncil.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtCouncil.HidePromptOnLeave = True
        Me.txtCouncil.Location = New System.Drawing.Point(149, 98)
        Me.txtCouncil.Mask = "00"
        Me.txtCouncil.Name = "txtCouncil"
        Me.txtCouncil.Size = New System.Drawing.Size(65, 25)
        Me.txtCouncil.TabIndex = 610
        Me.txtCouncil.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtCouncil.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label6.Location = New System.Drawing.Point(78, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 17)
        Me.Label6.TabIndex = 626
        Me.Label6.Text = "สภาวิชาชีพ"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 17)
        Me.Label2.TabIndex = 624
        Me.Label2.Text = "หมายเลขทะเบียนวิชาชีพ"
        '
        'txtRegisterno
        '
        Me.txtRegisterno.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtRegisterno.Location = New System.Drawing.Point(149, 65)
        Me.txtRegisterno.Name = "txtRegisterno"
        Me.txtRegisterno.Size = New System.Drawing.Size(128, 25)
        Me.txtRegisterno.TabIndex = 609
        Me.txtRegisterno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(57, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 17)
        Me.Label1.TabIndex = 623
        Me.Label1.Text = "เลขที่ผู้ให้บริการ"
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdSave.Image = Global.MyPCU.My.Resources.Resources.a_save
        Me.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSave.Location = New System.Drawing.Point(810, 528)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(121, 32)
        Me.cmdSave.TabIndex = 894
        Me.cmdSave.Text = "     บันทึก"
        Me.cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdFingerPrint
        '
        Me.cmdFingerPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFingerPrint.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdFingerPrint.Image = Global.MyPCU.My.Resources.Resources.a_finger3
        Me.cmdFingerPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdFingerPrint.Location = New System.Drawing.Point(807, 266)
        Me.cmdFingerPrint.Name = "cmdFingerPrint"
        Me.cmdFingerPrint.Size = New System.Drawing.Size(121, 32)
        Me.cmdFingerPrint.TabIndex = 893
        Me.cmdFingerPrint.Text = "   ลายนิ้วมือ"
        Me.cmdFingerPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdFingerPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdFingerPrint.UseVisualStyleBackColor = True
        '
        'cmdSmartCard
        '
        Me.cmdSmartCard.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSmartCard.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdSmartCard.Image = Global.MyPCU.My.Resources.Resources.a_smart_card2
        Me.cmdSmartCard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSmartCard.Location = New System.Drawing.Point(807, 161)
        Me.cmdSmartCard.Name = "cmdSmartCard"
        Me.cmdSmartCard.Size = New System.Drawing.Size(121, 32)
        Me.cmdSmartCard.TabIndex = 892
        Me.cmdSmartCard.Text = "   Smart Card"
        Me.cmdSmartCard.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdSmartCard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdSmartCard.UseVisualStyleBackColor = True
        '
        'cmdWebCam
        '
        Me.cmdWebCam.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdWebCam.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdWebCam.Image = Global.MyPCU.My.Resources.Resources.a_webcam
        Me.cmdWebCam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdWebCam.Location = New System.Drawing.Point(807, 231)
        Me.cmdWebCam.Name = "cmdWebCam"
        Me.cmdWebCam.Size = New System.Drawing.Size(121, 32)
        Me.cmdWebCam.TabIndex = 891
        Me.cmdWebCam.Text = "   Web Cam"
        Me.cmdWebCam.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdWebCam.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdWebCam.UseVisualStyleBackColor = True
        '
        'cmdPicture
        '
        Me.cmdPicture.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPicture.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdPicture.Image = Global.MyPCU.My.Resources.Resources.a_picture
        Me.cmdPicture.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdPicture.Location = New System.Drawing.Point(807, 196)
        Me.cmdPicture.Name = "cmdPicture"
        Me.cmdPicture.Size = New System.Drawing.Size(121, 32)
        Me.cmdPicture.TabIndex = 890
        Me.cmdPicture.Text = "   ค้นหารูปภาพ"
        Me.cmdPicture.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdPicture.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdPicture.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Image = Global.MyPCU.My.Resources.Resources.man
        Me.PictureBox1.InitialImage = CType(resources.GetObject("PictureBox1.InitialImage"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(807, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(121, 143)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 889
        Me.PictureBox1.TabStop = False
        '
        'XtraOpenFileDialog1
        '
        Me.XtraOpenFileDialog1.FileName = "XtraOpenFileDialog1"
        '
        'SplashScreenManager1
        '
        Me.SplashScreenManager1.ClosingDelay = 500
        '
        'cmdUser
        '
        Me.cmdUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUser.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdUser.Image = Global.MyPCU.My.Resources.Resources.a_key
        Me.cmdUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdUser.Location = New System.Drawing.Point(807, 302)
        Me.cmdUser.Name = "cmdUser"
        Me.cmdUser.Size = New System.Drawing.Size(121, 32)
        Me.cmdUser.TabIndex = 895
        Me.cmdUser.Text = "กำหนดการใข้งาน"
        Me.cmdUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdUser.UseVisualStyleBackColor = True
        '
        'frmProviderEdit
        '
        Me.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(943, 572)
        Me.Controls.Add(Me.cmdUser)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdFingerPrint)
        Me.Controls.Add(Me.cmdSmartCard)
        Me.Controls.Add(Me.cmdWebCam)
        Me.Controls.Add(Me.cmdPicture)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmProviderEdit"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "บันทึกข้อมูลเจ้าหน้าที่"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.txtBirth.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBirth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOutDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOutDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtStartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtStartDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPROVIDERTYPE.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboSEX.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPrename.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCouncil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents cmdFingerPrint As System.Windows.Forms.Button
    Friend WithEvents cmdSmartCard As System.Windows.Forms.Button
    Friend WithEvents cmdWebCam As System.Windows.Forms.Button
    Friend WithEvents cmdPicture As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents txtPOSITION As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents chkCancle As System.Windows.Forms.CheckBox
    Friend WithEvents lblPROVIDER_ID As System.Windows.Forms.TextBox
    Friend WithEvents lblCIDError As System.Windows.Forms.Label
    Friend WithEvents cmdSearch2 As System.Windows.Forms.Button
    Friend WithEvents cmdSearch1 As System.Windows.Forms.Button
    Friend WithEvents lblHospName2 As System.Windows.Forms.Label
    Friend WithEvents txtMoveTo As System.Windows.Forms.MaskedTextBox
    Public WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblHospName As System.Windows.Forms.Label
    Friend WithEvents txtMoveForm As System.Windows.Forms.MaskedTextBox
    Public WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtProviderTypeHosp As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSex As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPrename As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtLName As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtCID As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtCouncil As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRegisterno As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtOutDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtStartDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents cboPROVIDERTYPE As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboSEX As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboPrename As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboCouncil As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboProviderEdit As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents txtBirth As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtProviderType As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblErrorCode As System.Windows.Forms.Label
    Friend WithEvents ToolTipController1 As DevExpress.Utils.ToolTipController
    Friend WithEvents XtraOpenFileDialog1 As DevExpress.XtraEditors.XtraOpenFileDialog
    Friend WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
    Friend WithEvents cmdUser As System.Windows.Forms.Button
    Friend WithEvents cmdPrename As Button
    Friend WithEvents txtLine As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtTelephone As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents chkPorvider2 As CheckBox
    Friend WithEvents chkPorvider1 As CheckBox
    Friend WithEvents Label13 As Label
End Class

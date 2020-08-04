<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPersonEpi
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPersonEpi))
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.txtVaccinePlaceName = New DevExpress.XtraEditors.LabelControl()
        Me.txtVaccineTypeCode = New DevExpress.XtraEditors.TextEdit()
        Me.txtVaccinePlaceCode = New DevExpress.XtraEditors.TextEdit()
        Me.numBottle = New System.Windows.Forms.NumericUpDown()
        Me.txtLotNo = New DevExpress.XtraEditors.TextEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkUnkonw = New System.Windows.Forms.CheckBox()
        Me.btnLookupHospital = New System.Windows.Forms.Button()
        Me.txtDateServ = New DevExpress.XtraEditors.DateEdit()
        Me.cboProvider = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtProviderCode = New DevExpress.XtraEditors.LabelControl()
        Me.cboVaccineType = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblErrorCode = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.ToolTipController1 = New DevExpress.Utils.ToolTipController(Me.components)
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TimeEdit1 = New DevExpress.XtraEditors.TimeEdit()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LookUpEdit1 = New DevExpress.XtraEditors.LookUpEdit()
        Me.LookUpEdit2 = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LookUpEdit3 = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.txtVaccineTypeCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVaccinePlaceCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numBottle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLotNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDateServ.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDateServ.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboProvider.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboVaccineType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimeEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LookUpEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LookUpEdit3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl1.Controls.Add(Me.CheckBox2)
        Me.GroupControl1.Controls.Add(Me.CheckBox1)
        Me.GroupControl1.Controls.Add(Me.Label13)
        Me.GroupControl1.Controls.Add(Me.LookUpEdit3)
        Me.GroupControl1.Controls.Add(Me.Label12)
        Me.GroupControl1.Controls.Add(Me.NumericUpDown1)
        Me.GroupControl1.Controls.Add(Me.Label11)
        Me.GroupControl1.Controls.Add(Me.LookUpEdit2)
        Me.GroupControl1.Controls.Add(Me.Label10)
        Me.GroupControl1.Controls.Add(Me.LookUpEdit1)
        Me.GroupControl1.Controls.Add(Me.Label9)
        Me.GroupControl1.Controls.Add(Me.Label8)
        Me.GroupControl1.Controls.Add(Me.TimeEdit1)
        Me.GroupControl1.Controls.Add(Me.Label7)
        Me.GroupControl1.Controls.Add(Me.txtVaccinePlaceName)
        Me.GroupControl1.Controls.Add(Me.txtVaccineTypeCode)
        Me.GroupControl1.Controls.Add(Me.txtVaccinePlaceCode)
        Me.GroupControl1.Controls.Add(Me.numBottle)
        Me.GroupControl1.Controls.Add(Me.txtLotNo)
        Me.GroupControl1.Controls.Add(Me.Label5)
        Me.GroupControl1.Controls.Add(Me.Label2)
        Me.GroupControl1.Controls.Add(Me.chkUnkonw)
        Me.GroupControl1.Controls.Add(Me.btnLookupHospital)
        Me.GroupControl1.Controls.Add(Me.txtDateServ)
        Me.GroupControl1.Controls.Add(Me.cboProvider)
        Me.GroupControl1.Controls.Add(Me.txtProviderCode)
        Me.GroupControl1.Controls.Add(Me.cboVaccineType)
        Me.GroupControl1.Controls.Add(Me.Label6)
        Me.GroupControl1.Controls.Add(Me.Label3)
        Me.GroupControl1.Controls.Add(Me.Label4)
        Me.GroupControl1.Controls.Add(Me.Label1)
        Me.GroupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Card
        Me.GroupControl1.Location = New System.Drawing.Point(12, 12)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(791, 307)
        Me.GroupControl1.TabIndex = 1154
        Me.GroupControl1.Text = "บันทึกข้อมูลการได้รับวัคซีน (กรณีไม่ได้ให้บริการเอง)"
        '
        'txtVaccinePlaceName
        '
        Me.txtVaccinePlaceName.Appearance.BackColor = System.Drawing.Color.White
        Me.txtVaccinePlaceName.Appearance.Options.UseBackColor = True
        Me.txtVaccinePlaceName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.txtVaccinePlaceName.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtVaccinePlaceName.Location = New System.Drawing.Point(199, 106)
        Me.txtVaccinePlaceName.Name = "txtVaccinePlaceName"
        Me.txtVaccinePlaceName.Size = New System.Drawing.Size(389, 24)
        Me.txtVaccinePlaceName.TabIndex = 1270
        '
        'txtVaccineTypeCode
        '
        Me.txtVaccineTypeCode.Location = New System.Drawing.Point(130, 75)
        Me.txtVaccineTypeCode.Name = "txtVaccineTypeCode"
        Me.txtVaccineTypeCode.Properties.Appearance.Options.UseTextOptions = True
        Me.txtVaccineTypeCode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtVaccineTypeCode.Size = New System.Drawing.Size(63, 24)
        Me.txtVaccineTypeCode.TabIndex = 1266
        '
        'txtVaccinePlaceCode
        '
        Me.txtVaccinePlaceCode.Location = New System.Drawing.Point(130, 105)
        Me.txtVaccinePlaceCode.Name = "txtVaccinePlaceCode"
        Me.txtVaccinePlaceCode.Properties.Appearance.Options.UseTextOptions = True
        Me.txtVaccinePlaceCode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtVaccinePlaceCode.Size = New System.Drawing.Size(63, 24)
        Me.txtVaccinePlaceCode.TabIndex = 1266
        '
        'numBottle
        '
        Me.numBottle.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.numBottle.Location = New System.Drawing.Point(539, 135)
        Me.numBottle.Name = "numBottle"
        Me.numBottle.Size = New System.Drawing.Size(49, 25)
        Me.numBottle.TabIndex = 1265
        Me.numBottle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLotNo
        '
        Me.txtLotNo.Location = New System.Drawing.Point(130, 136)
        Me.txtLotNo.Name = "txtLotNo"
        Me.txtLotNo.Properties.Appearance.Options.UseTextOptions = True
        Me.txtLotNo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtLotNo.Size = New System.Drawing.Size(305, 24)
        Me.txtLotNo.TabIndex = 1264
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(496, 138)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 17)
        Me.Label5.TabIndex = 1263
        Me.Label5.Text = "ขวดที่"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(62, 139)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 17)
        Me.Label2.TabIndex = 1263
        Me.Label2.Text = "LOT NO."
        '
        'chkUnkonw
        '
        Me.chkUnkonw.AutoSize = True
        Me.chkUnkonw.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.chkUnkonw.Location = New System.Drawing.Point(631, 107)
        Me.chkUnkonw.Name = "chkUnkonw"
        Me.chkUnkonw.Size = New System.Drawing.Size(66, 21)
        Me.chkUnkonw.TabIndex = 1262
        Me.chkUnkonw.Text = "ไม่ทราบ"
        Me.chkUnkonw.UseVisualStyleBackColor = True
        '
        'btnLookupHospital
        '
        Me.btnLookupHospital.Image = Global.MyPCU.My.Resources.Resources.a_search
        Me.btnLookupHospital.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLookupHospital.Location = New System.Drawing.Point(594, 105)
        Me.btnLookupHospital.Name = "btnLookupHospital"
        Me.btnLookupHospital.Size = New System.Drawing.Size(31, 25)
        Me.btnLookupHospital.TabIndex = 1261
        Me.btnLookupHospital.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLookupHospital.UseVisualStyleBackColor = True
        '
        'txtDateServ
        '
        Me.txtDateServ.EditValue = Nothing
        Me.txtDateServ.Location = New System.Drawing.Point(130, 44)
        Me.txtDateServ.Name = "txtDateServ"
        Me.txtDateServ.Properties.Appearance.BackColor = System.Drawing.Color.Beige
        Me.txtDateServ.Properties.Appearance.Options.UseBackColor = True
        Me.txtDateServ.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDateServ.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDateServ.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.txtDateServ.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtDateServ.Properties.EditFormat.FormatString = "dd/MM/yyyy"
        Me.txtDateServ.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtDateServ.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.txtDateServ.Size = New System.Drawing.Size(118, 24)
        Me.txtDateServ.TabIndex = 1258
        '
        'cboProvider
        '
        Me.cboProvider.Location = New System.Drawing.Point(266, 260)
        Me.cboProvider.Name = "cboProvider"
        Me.cboProvider.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboProvider.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.cboProvider.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboProvider.Size = New System.Drawing.Size(322, 24)
        Me.cboProvider.TabIndex = 10
        '
        'txtProviderCode
        '
        Me.txtProviderCode.Appearance.BackColor = System.Drawing.Color.Beige
        Me.txtProviderCode.Appearance.Options.UseBackColor = True
        Me.txtProviderCode.Appearance.Options.UseTextOptions = True
        Me.txtProviderCode.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtProviderCode.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.txtProviderCode.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtProviderCode.Location = New System.Drawing.Point(130, 259)
        Me.txtProviderCode.Name = "txtProviderCode"
        Me.txtProviderCode.Size = New System.Drawing.Size(130, 25)
        Me.txtProviderCode.TabIndex = 9
        '
        'cboVaccineType
        '
        Me.cboVaccineType.Location = New System.Drawing.Point(199, 75)
        Me.cboVaccineType.Name = "cboVaccineType"
        Me.cboVaccineType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboVaccineType.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.cboVaccineType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboVaccineType.Size = New System.Drawing.Size(389, 24)
        Me.cboVaccineType.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(28, 264)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 17)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "เจ้าหน้าที่ผู้บันทึก"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(34, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 17)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "สถานที่รับวัคซีน"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(47, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 17)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "ประเภทวัคซีน"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(45, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "วันที่รับบริการ"
        '
        'lblErrorCode
        '
        Me.lblErrorCode.AutoSize = True
        Me.lblErrorCode.BackColor = System.Drawing.Color.AntiqueWhite
        Me.lblErrorCode.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblErrorCode.ForeColor = System.Drawing.Color.Crimson
        Me.lblErrorCode.Location = New System.Drawing.Point(12, 331)
        Me.lblErrorCode.Name = "lblErrorCode"
        Me.lblErrorCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblErrorCode.Size = New System.Drawing.Size(67, 17)
        Me.lblErrorCode.TabIndex = 1156
        Me.lblErrorCode.Text = "ErroCODE"
        Me.lblErrorCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSave
        '
        Me.btnSave.Image = Global.MyPCU.My.Resources.Resources.a_save
        Me.btnSave.Location = New System.Drawing.Point(695, 325)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(108, 28)
        Me.btnSave.TabIndex = 1155
        Me.btnSave.Text = "บันทึก"
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(263, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 17)
        Me.Label7.TabIndex = 1271
        Me.Label7.Text = "เวลา"
        '
        'TimeEdit1
        '
        Me.TimeEdit1.EditValue = New Date(2020, 8, 4, 0, 0, 0, 0)
        Me.TimeEdit1.Location = New System.Drawing.Point(299, 44)
        Me.TimeEdit1.Name = "TimeEdit1"
        Me.TimeEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TimeEdit1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TimeEdit1.Size = New System.Drawing.Size(100, 24)
        Me.TimeEdit1.TabIndex = 1272
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(405, 47)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(19, 17)
        Me.Label8.TabIndex = 1273
        Me.Label8.Text = "น."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(40, 170)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 17)
        Me.Label9.TabIndex = 1274
        Me.Label9.Text = "วิธีการให้วัคซีน"
        '
        'LookUpEdit1
        '
        Me.LookUpEdit1.Location = New System.Drawing.Point(130, 167)
        Me.LookUpEdit1.Name = "LookUpEdit1"
        Me.LookUpEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LookUpEdit1.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.LookUpEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.LookUpEdit1.Size = New System.Drawing.Size(178, 24)
        Me.LookUpEdit1.TabIndex = 1275
        '
        'LookUpEdit2
        '
        Me.LookUpEdit2.Location = New System.Drawing.Point(434, 167)
        Me.LookUpEdit2.Name = "LookUpEdit2"
        Me.LookUpEdit2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LookUpEdit2.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.LookUpEdit2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.LookUpEdit2.Size = New System.Drawing.Size(154, 24)
        Me.LookUpEdit2.TabIndex = 1277
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(359, 170)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 17)
        Me.Label10.TabIndex = 1276
        Me.Label10.Text = "ตำแหน่งที่ให้"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.NumericUpDown1.Location = New System.Drawing.Point(130, 198)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(49, 25)
        Me.NumericUpDown1.TabIndex = 1279
        Me.NumericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(52, 200)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 17)
        Me.Label11.TabIndex = 1278
        Me.Label11.Text = "ปริมาณที่ให้"
        '
        'LookUpEdit3
        '
        Me.LookUpEdit3.Location = New System.Drawing.Point(355, 229)
        Me.LookUpEdit3.Name = "LookUpEdit3"
        Me.LookUpEdit3.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LookUpEdit3.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.LookUpEdit3.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.LookUpEdit3.Size = New System.Drawing.Size(178, 24)
        Me.LookUpEdit3.TabIndex = 1281
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(57, 233)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 17)
        Me.Label12.TabIndex = 1280
        Me.Label12.Text = "แหล่งข้อมูล"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(196, 200)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(24, 17)
        Me.Label13.TabIndex = 1282
        Me.Label13.Text = "ซีซี"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(130, 231)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(95, 21)
        Me.CheckBox1.TabIndex = 1283
        Me.CheckBox1.Text = "ผู้รับบริการเอง"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(232, 231)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(117, 21)
        Me.CheckBox2.TabIndex = 1284
        Me.CheckBox2.Text = "ข้อมูลจากแหล่่งอื่น"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'frmPersonEpi
        '
        Me.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(818, 369)
        Me.Controls.Add(Me.lblErrorCode)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.btnSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPersonEpi"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ข้อมูลการรับวัคซีนรายบุคคล"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.txtVaccineTypeCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVaccinePlaceCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numBottle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLotNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDateServ.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDateServ.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboProvider.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboVaccineType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimeEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LookUpEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LookUpEdit3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents cboVaccineType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDateServ As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents btnLookupHospital As Button
    Friend WithEvents numBottle As NumericUpDown
    Friend WithEvents txtLotNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents chkUnkonw As CheckBox
    Friend WithEvents cboProvider As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtProviderCode As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label6 As Label
    Friend WithEvents lblErrorCode As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents txtVaccineTypeCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtVaccinePlaceCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtVaccinePlaceName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ToolTipController1 As DevExpress.Utils.ToolTipController
    Friend WithEvents Label13 As Label
    Friend WithEvents LookUpEdit3 As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label12 As Label
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents Label11 As Label
    Friend WithEvents LookUpEdit2 As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label10 As Label
    Friend WithEvents LookUpEdit1 As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TimeEdit1 As DevExpress.XtraEditors.TimeEdit
    Friend WithEvents Label7 As Label
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
End Class

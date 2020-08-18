<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPersonNutrition
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPersonNutrition))
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.txtNutritionPlaceName = New DevExpress.XtraEditors.LabelControl()
        Me.txtNutritionPlaceCode = New DevExpress.XtraEditors.TextEdit()
        Me.chkUnkonw = New System.Windows.Forms.CheckBox()
        Me.btnLookupHospital = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkFood2 = New System.Windows.Forms.CheckBox()
        Me.chkFood5 = New System.Windows.Forms.CheckBox()
        Me.chkFood4 = New System.Windows.Forms.CheckBox()
        Me.chkBottle2 = New System.Windows.Forms.CheckBox()
        Me.chkFood1 = New System.Windows.Forms.CheckBox()
        Me.chkFood3 = New System.Windows.Forms.CheckBox()
        Me.chkChildDevelop3 = New System.Windows.Forms.CheckBox()
        Me.chkBottle1 = New System.Windows.Forms.CheckBox()
        Me.chkFood0 = New System.Windows.Forms.CheckBox()
        Me.chkChildDevelop2 = New System.Windows.Forms.CheckBox()
        Me.chkChildDevelop1 = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TimeEdit1 = New DevExpress.XtraEditors.TimeEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtHeadCircum = New DevExpress.XtraEditors.TextEdit()
        Me.txtHeight = New DevExpress.XtraEditors.TextEdit()
        Me.txtBottle = New DevExpress.XtraEditors.TextEdit()
        Me.txtWeight = New DevExpress.XtraEditors.TextEdit()
        Me.txtFood = New DevExpress.XtraEditors.TextEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtChildDevelope = New DevExpress.XtraEditors.TextEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDateServ = New DevExpress.XtraEditors.DateEdit()
        Me.cboProvider = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtProviderCode = New DevExpress.XtraEditors.LabelControl()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblErrorCode = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.ToolTipController1 = New DevExpress.Utils.ToolTipController(Me.components)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.txtNutritionPlaceCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimeEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHeadCircum.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHeight.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBottle.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWeight.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFood.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtChildDevelope.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDateServ.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDateServ.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboProvider.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl1.Controls.Add(Me.txtNutritionPlaceName)
        Me.GroupControl1.Controls.Add(Me.txtNutritionPlaceCode)
        Me.GroupControl1.Controls.Add(Me.chkUnkonw)
        Me.GroupControl1.Controls.Add(Me.btnLookupHospital)
        Me.GroupControl1.Controls.Add(Me.Label9)
        Me.GroupControl1.Controls.Add(Me.chkFood2)
        Me.GroupControl1.Controls.Add(Me.chkFood5)
        Me.GroupControl1.Controls.Add(Me.chkFood4)
        Me.GroupControl1.Controls.Add(Me.chkBottle2)
        Me.GroupControl1.Controls.Add(Me.chkFood1)
        Me.GroupControl1.Controls.Add(Me.chkFood3)
        Me.GroupControl1.Controls.Add(Me.chkChildDevelop3)
        Me.GroupControl1.Controls.Add(Me.chkBottle1)
        Me.GroupControl1.Controls.Add(Me.chkFood0)
        Me.GroupControl1.Controls.Add(Me.chkChildDevelop2)
        Me.GroupControl1.Controls.Add(Me.chkChildDevelop1)
        Me.GroupControl1.Controls.Add(Me.Label8)
        Me.GroupControl1.Controls.Add(Me.TimeEdit1)
        Me.GroupControl1.Controls.Add(Me.Label7)
        Me.GroupControl1.Controls.Add(Me.txtHeadCircum)
        Me.GroupControl1.Controls.Add(Me.txtHeight)
        Me.GroupControl1.Controls.Add(Me.txtBottle)
        Me.GroupControl1.Controls.Add(Me.txtWeight)
        Me.GroupControl1.Controls.Add(Me.txtFood)
        Me.GroupControl1.Controls.Add(Me.Label5)
        Me.GroupControl1.Controls.Add(Me.txtChildDevelope)
        Me.GroupControl1.Controls.Add(Me.Label2)
        Me.GroupControl1.Controls.Add(Me.txtDateServ)
        Me.GroupControl1.Controls.Add(Me.cboProvider)
        Me.GroupControl1.Controls.Add(Me.txtProviderCode)
        Me.GroupControl1.Controls.Add(Me.Label15)
        Me.GroupControl1.Controls.Add(Me.Label6)
        Me.GroupControl1.Controls.Add(Me.Label14)
        Me.GroupControl1.Controls.Add(Me.Label3)
        Me.GroupControl1.Controls.Add(Me.Label4)
        Me.GroupControl1.Controls.Add(Me.Label1)
        Me.GroupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Card
        Me.GroupControl1.Location = New System.Drawing.Point(12, 12)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(791, 307)
        Me.GroupControl1.TabIndex = 1155
        Me.GroupControl1.Text = "บันทึกข้อมูลการตรวจภาวะโภชนาการ"
        '
        'txtNutritionPlaceName
        '
        Me.txtNutritionPlaceName.Appearance.BackColor = System.Drawing.Color.White
        Me.txtNutritionPlaceName.Appearance.Options.UseBackColor = True
        Me.txtNutritionPlaceName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.txtNutritionPlaceName.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtNutritionPlaceName.Location = New System.Drawing.Point(264, 220)
        Me.txtNutritionPlaceName.Name = "txtNutritionPlaceName"
        Me.txtNutritionPlaceName.Size = New System.Drawing.Size(389, 24)
        Me.txtNutritionPlaceName.TabIndex = 1289
        '
        'txtNutritionPlaceCode
        '
        Me.txtNutritionPlaceCode.Location = New System.Drawing.Point(182, 219)
        Me.txtNutritionPlaceCode.Name = "txtNutritionPlaceCode"
        Me.txtNutritionPlaceCode.Properties.Appearance.BackColor = System.Drawing.Color.Beige
        Me.txtNutritionPlaceCode.Properties.Appearance.Options.UseBackColor = True
        Me.txtNutritionPlaceCode.Properties.Appearance.Options.UseTextOptions = True
        Me.txtNutritionPlaceCode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtNutritionPlaceCode.Size = New System.Drawing.Size(63, 24)
        Me.txtNutritionPlaceCode.TabIndex = 1288
        '
        'chkUnkonw
        '
        Me.chkUnkonw.AutoSize = True
        Me.chkUnkonw.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.chkUnkonw.Location = New System.Drawing.Point(696, 222)
        Me.chkUnkonw.Name = "chkUnkonw"
        Me.chkUnkonw.Size = New System.Drawing.Size(66, 21)
        Me.chkUnkonw.TabIndex = 1287
        Me.chkUnkonw.Text = "ไม่ทราบ"
        Me.chkUnkonw.UseVisualStyleBackColor = True
        '
        'btnLookupHospital
        '
        Me.btnLookupHospital.Image = Global.MyPCU.My.Resources.Resources.a_search
        Me.btnLookupHospital.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLookupHospital.Location = New System.Drawing.Point(659, 220)
        Me.btnLookupHospital.Name = "btnLookupHospital"
        Me.btnLookupHospital.Size = New System.Drawing.Size(31, 25)
        Me.btnLookupHospital.TabIndex = 1286
        Me.btnLookupHospital.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLookupHospital.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(64, 223)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(102, 17)
        Me.Label9.TabIndex = 1285
        Me.Label9.Text = "สถานบริการที่ตรวจ"
        '
        'chkFood2
        '
        Me.chkFood2.AutoSize = True
        Me.chkFood2.Location = New System.Drawing.Point(572, 138)
        Me.chkFood2.Name = "chkFood2"
        Me.chkFood2.Size = New System.Drawing.Size(86, 21)
        Me.chkFood2.TabIndex = 1284
        Me.chkFood2.Text = "นมแม่และน้ำ"
        Me.chkFood2.UseVisualStyleBackColor = True
        '
        'chkFood5
        '
        Me.chkFood5.AutoSize = True
        Me.chkFood5.Location = New System.Drawing.Point(572, 165)
        Me.chkFood5.Name = "chkFood5"
        Me.chkFood5.Size = New System.Drawing.Size(117, 21)
        Me.chkFood5.TabIndex = 1284
        Me.chkFood5.Text = "นมและอาหารอื่น ๆ"
        Me.chkFood5.UseVisualStyleBackColor = True
        '
        'chkFood4
        '
        Me.chkFood4.AutoSize = True
        Me.chkFood4.Location = New System.Drawing.Point(407, 165)
        Me.chkFood4.Name = "chkFood4"
        Me.chkFood4.Size = New System.Drawing.Size(112, 21)
        Me.chkFood4.TabIndex = 1284
        Me.chkFood4.Text = "นมผสมอย่างเดียว"
        Me.chkFood4.UseVisualStyleBackColor = True
        '
        'chkBottle2
        '
        Me.chkBottle2.AutoSize = True
        Me.chkBottle2.Location = New System.Drawing.Point(407, 192)
        Me.chkBottle2.Name = "chkBottle2"
        Me.chkBottle2.Size = New System.Drawing.Size(88, 21)
        Me.chkBottle2.TabIndex = 1284
        Me.chkBottle2.Text = "ไม่ใช้ขวดนม"
        Me.chkBottle2.UseVisualStyleBackColor = True
        '
        'chkFood1
        '
        Me.chkFood1.AutoSize = True
        Me.chkFood1.Location = New System.Drawing.Point(407, 138)
        Me.chkFood1.Name = "chkFood1"
        Me.chkFood1.Size = New System.Drawing.Size(103, 21)
        Me.chkFood1.TabIndex = 1284
        Me.chkFood1.Text = "นมแม่อย่างเดียว"
        Me.chkFood1.UseVisualStyleBackColor = True
        '
        'chkFood3
        '
        Me.chkFood3.AutoSize = True
        Me.chkFood3.Location = New System.Drawing.Point(264, 165)
        Me.chkFood3.Name = "chkFood3"
        Me.chkFood3.Size = New System.Drawing.Size(109, 21)
        Me.chkFood3.TabIndex = 1283
        Me.chkFood3.Text = "นมแม่และนมผสม"
        Me.chkFood3.UseVisualStyleBackColor = True
        '
        'chkChildDevelop3
        '
        Me.chkChildDevelop3.AutoSize = True
        Me.chkChildDevelop3.Location = New System.Drawing.Point(572, 108)
        Me.chkChildDevelop3.Name = "chkChildDevelop3"
        Me.chkChildDevelop3.Size = New System.Drawing.Size(81, 21)
        Me.chkChildDevelop3.TabIndex = 1284
        Me.chkChildDevelop3.Text = "ช้ากว่าปกติ"
        Me.chkChildDevelop3.UseVisualStyleBackColor = True
        '
        'chkBottle1
        '
        Me.chkBottle1.AutoSize = True
        Me.chkBottle1.Location = New System.Drawing.Point(264, 192)
        Me.chkBottle1.Name = "chkBottle1"
        Me.chkBottle1.Size = New System.Drawing.Size(76, 21)
        Me.chkBottle1.TabIndex = 1283
        Me.chkBottle1.Text = "ใช้ขวดนม"
        Me.chkBottle1.UseVisualStyleBackColor = True
        '
        'chkFood0
        '
        Me.chkFood0.AutoSize = True
        Me.chkFood0.Location = New System.Drawing.Point(264, 138)
        Me.chkFood0.Name = "chkFood0"
        Me.chkFood0.Size = New System.Drawing.Size(92, 21)
        Me.chkFood0.TabIndex = 1283
        Me.chkFood0.Text = "เลิกดื่มนมแล้ว"
        Me.chkFood0.UseVisualStyleBackColor = True
        '
        'chkChildDevelop2
        '
        Me.chkChildDevelop2.AutoSize = True
        Me.chkChildDevelop2.Location = New System.Drawing.Point(407, 108)
        Me.chkChildDevelop2.Name = "chkChildDevelop2"
        Me.chkChildDevelop2.Size = New System.Drawing.Size(107, 21)
        Me.chkChildDevelop2.TabIndex = 1284
        Me.chkChildDevelop2.Text = "สงสัยช้ากว่าปกติ"
        Me.chkChildDevelop2.UseVisualStyleBackColor = True
        '
        'chkChildDevelop1
        '
        Me.chkChildDevelop1.AutoSize = True
        Me.chkChildDevelop1.Location = New System.Drawing.Point(264, 108)
        Me.chkChildDevelop1.Name = "chkChildDevelop1"
        Me.chkChildDevelop1.Size = New System.Drawing.Size(48, 21)
        Me.chkChildDevelop1.TabIndex = 1283
        Me.chkChildDevelop1.Text = "ปกติ"
        Me.chkChildDevelop1.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(457, 47)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(19, 17)
        Me.Label8.TabIndex = 1273
        Me.Label8.Text = "น."
        '
        'TimeEdit1
        '
        Me.TimeEdit1.EditValue = New Date(2020, 8, 4, 0, 0, 0, 0)
        Me.TimeEdit1.Location = New System.Drawing.Point(351, 44)
        Me.TimeEdit1.Name = "TimeEdit1"
        Me.TimeEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TimeEdit1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TimeEdit1.Size = New System.Drawing.Size(100, 24)
        Me.TimeEdit1.TabIndex = 1272
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(315, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 17)
        Me.Label7.TabIndex = 1271
        Me.Label7.Text = "เวลา"
        '
        'txtHeadCircum
        '
        Me.txtHeadCircum.Location = New System.Drawing.Point(482, 75)
        Me.txtHeadCircum.Name = "txtHeadCircum"
        Me.txtHeadCircum.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtHeadCircum.Properties.Appearance.Options.UseBackColor = True
        Me.txtHeadCircum.Properties.Appearance.Options.UseTextOptions = True
        Me.txtHeadCircum.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtHeadCircum.Size = New System.Drawing.Size(63, 24)
        Me.txtHeadCircum.TabIndex = 1266
        '
        'txtHeight
        '
        Me.txtHeight.Location = New System.Drawing.Point(318, 75)
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtHeight.Properties.Appearance.Options.UseBackColor = True
        Me.txtHeight.Properties.Appearance.Options.UseTextOptions = True
        Me.txtHeight.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtHeight.Size = New System.Drawing.Size(63, 24)
        Me.txtHeight.TabIndex = 1266
        '
        'txtBottle
        '
        Me.txtBottle.Location = New System.Drawing.Point(182, 189)
        Me.txtBottle.Name = "txtBottle"
        Me.txtBottle.Properties.Appearance.BackColor = System.Drawing.Color.Beige
        Me.txtBottle.Properties.Appearance.Options.UseBackColor = True
        Me.txtBottle.Properties.Appearance.Options.UseTextOptions = True
        Me.txtBottle.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtBottle.Size = New System.Drawing.Size(63, 24)
        Me.txtBottle.TabIndex = 1266
        '
        'txtWeight
        '
        Me.txtWeight.Location = New System.Drawing.Point(182, 75)
        Me.txtWeight.Name = "txtWeight"
        Me.txtWeight.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtWeight.Properties.Appearance.Options.UseBackColor = True
        Me.txtWeight.Properties.Appearance.Options.UseTextOptions = True
        Me.txtWeight.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtWeight.Size = New System.Drawing.Size(63, 24)
        Me.txtWeight.TabIndex = 1266
        '
        'txtFood
        '
        Me.txtFood.Location = New System.Drawing.Point(182, 135)
        Me.txtFood.Name = "txtFood"
        Me.txtFood.Properties.Appearance.BackColor = System.Drawing.Color.Beige
        Me.txtFood.Properties.Appearance.Options.UseBackColor = True
        Me.txtFood.Properties.Appearance.Options.UseTextOptions = True
        Me.txtFood.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtFood.Size = New System.Drawing.Size(63, 24)
        Me.txtFood.TabIndex = 1266
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(92, 192)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 17)
        Me.Label5.TabIndex = 1263
        Me.Label5.Text = "การใช้ขวดนม"
        '
        'txtChildDevelope
        '
        Me.txtChildDevelope.Location = New System.Drawing.Point(182, 105)
        Me.txtChildDevelope.Name = "txtChildDevelope"
        Me.txtChildDevelope.Properties.Appearance.BackColor = System.Drawing.Color.Beige
        Me.txtChildDevelope.Properties.Appearance.Options.UseBackColor = True
        Me.txtChildDevelope.Properties.Appearance.Options.UseTextOptions = True
        Me.txtChildDevelope.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtChildDevelope.Size = New System.Drawing.Size(63, 24)
        Me.txtChildDevelope.TabIndex = 1266
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 138)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(137, 17)
        Me.Label2.TabIndex = 1263
        Me.Label2.Text = "อาหารที่รับประทานปัจจุบัน"
        '
        'txtDateServ
        '
        Me.txtDateServ.EditValue = Nothing
        Me.txtDateServ.Location = New System.Drawing.Point(182, 44)
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
        Me.cboProvider.Location = New System.Drawing.Point(318, 251)
        Me.cboProvider.Name = "cboProvider"
        Me.cboProvider.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboProvider.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.cboProvider.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboProvider.Size = New System.Drawing.Size(371, 24)
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
        Me.txtProviderCode.Location = New System.Drawing.Point(182, 250)
        Me.txtProviderCode.Name = "txtProviderCode"
        Me.txtProviderCode.Size = New System.Drawing.Size(130, 25)
        Me.txtProviderCode.TabIndex = 9
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(405, 78)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(71, 17)
        Me.Label15.TabIndex = 8
        Me.Label15.Text = "เส้นรอบศีรษะ"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(74, 255)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 17)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "เจ้าหน้าที่ผู้บันทึก"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(263, 78)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(41, 17)
        Me.Label14.TabIndex = 8
        Me.Label14.Text = "ส่วนสูง"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(64, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 17)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "ระดับพัฒนาการเด็ก"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(121, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 17)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "น้ำหนัก"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(91, 47)
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
        Me.lblErrorCode.Location = New System.Drawing.Point(15, 331)
        Me.lblErrorCode.Name = "lblErrorCode"
        Me.lblErrorCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblErrorCode.Size = New System.Drawing.Size(67, 17)
        Me.lblErrorCode.TabIndex = 1158
        Me.lblErrorCode.Text = "ErroCODE"
        Me.lblErrorCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSave
        '
        Me.btnSave.Image = Global.MyPCU.My.Resources.Resources.a_save
        Me.btnSave.Location = New System.Drawing.Point(695, 325)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(108, 28)
        Me.btnSave.TabIndex = 1157
        Me.btnSave.Text = "บันทึก"
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'frmPersonNutrition
        '
        Me.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(818, 369)
        Me.Controls.Add(Me.lblErrorCode)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPersonNutrition"
        Me.Text = "บันทึกข้อมูลภาวะโภชนาการ(Nutrition)"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.txtNutritionPlaceCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimeEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHeadCircum.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHeight.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBottle.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWeight.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFood.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtChildDevelope.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDateServ.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDateServ.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboProvider.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents Label8 As Label
    Friend WithEvents TimeEdit1 As DevExpress.XtraEditors.TimeEdit
    Friend WithEvents Label7 As Label
    Friend WithEvents txtWeight As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtChildDevelope As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents txtDateServ As DevExpress.XtraEditors.DateEdit
    Friend WithEvents cboProvider As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtProviderCode As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblErrorCode As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents chkFood2 As CheckBox
    Friend WithEvents chkFood5 As CheckBox
    Friend WithEvents chkFood4 As CheckBox
    Friend WithEvents chkBottle2 As CheckBox
    Friend WithEvents chkFood1 As CheckBox
    Friend WithEvents chkFood3 As CheckBox
    Friend WithEvents chkChildDevelop3 As CheckBox
    Friend WithEvents chkBottle1 As CheckBox
    Friend WithEvents chkFood0 As CheckBox
    Friend WithEvents chkChildDevelop2 As CheckBox
    Friend WithEvents chkChildDevelop1 As CheckBox
    Friend WithEvents txtHeadCircum As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtHeight As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtBottle As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtFood As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label5 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtNutritionPlaceName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtNutritionPlaceCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents chkUnkonw As CheckBox
    Friend WithEvents btnLookupHospital As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents ToolTipController1 As DevExpress.Utils.ToolTipController
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPersonFp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPersonFp))
        Me.lblErrorCode = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.cboFpType = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFpPlaceName = New DevExpress.XtraEditors.LabelControl()
        Me.txtFpType = New DevExpress.XtraEditors.TextEdit()
        Me.txtFpPlaceCode = New DevExpress.XtraEditors.TextEdit()
        Me.chkUnkonw = New System.Windows.Forms.CheckBox()
        Me.btnLookupHospital = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TimeEdit1 = New DevExpress.XtraEditors.TimeEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDateServ = New DevExpress.XtraEditors.DateEdit()
        Me.cboProvider = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtProviderCode = New DevExpress.XtraEditors.LabelControl()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolTipController1 = New DevExpress.Utils.ToolTipController(Me.components)
        Me.chkCancel = New System.Windows.Forms.CheckBox()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.cboFpType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFpType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFpPlaceCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimeEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDateServ.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDateServ.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboProvider.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblErrorCode
        '
        Me.lblErrorCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblErrorCode.AutoSize = True
        Me.lblErrorCode.BackColor = System.Drawing.Color.AntiqueWhite
        Me.lblErrorCode.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblErrorCode.ForeColor = System.Drawing.Color.Crimson
        Me.lblErrorCode.Location = New System.Drawing.Point(17, 243)
        Me.lblErrorCode.Name = "lblErrorCode"
        Me.lblErrorCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblErrorCode.Size = New System.Drawing.Size(67, 17)
        Me.lblErrorCode.TabIndex = 1161
        Me.lblErrorCode.Text = "ErroCODE"
        Me.lblErrorCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Image = Global.MyPCU.My.Resources.Resources.a_save
        Me.btnSave.Location = New System.Drawing.Point(697, 237)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(108, 28)
        Me.btnSave.TabIndex = 1160
        Me.btnSave.Text = "บันทึก"
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'GroupControl1
        '
        Me.GroupControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl1.Controls.Add(Me.chkCancel)
        Me.GroupControl1.Controls.Add(Me.cboFpType)
        Me.GroupControl1.Controls.Add(Me.Label2)
        Me.GroupControl1.Controls.Add(Me.txtFpPlaceName)
        Me.GroupControl1.Controls.Add(Me.txtFpType)
        Me.GroupControl1.Controls.Add(Me.txtFpPlaceCode)
        Me.GroupControl1.Controls.Add(Me.chkUnkonw)
        Me.GroupControl1.Controls.Add(Me.btnLookupHospital)
        Me.GroupControl1.Controls.Add(Me.Label9)
        Me.GroupControl1.Controls.Add(Me.Label8)
        Me.GroupControl1.Controls.Add(Me.TimeEdit1)
        Me.GroupControl1.Controls.Add(Me.Label7)
        Me.GroupControl1.Controls.Add(Me.txtDateServ)
        Me.GroupControl1.Controls.Add(Me.cboProvider)
        Me.GroupControl1.Controls.Add(Me.txtProviderCode)
        Me.GroupControl1.Controls.Add(Me.Label6)
        Me.GroupControl1.Controls.Add(Me.Label1)
        Me.GroupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Card
        Me.GroupControl1.Location = New System.Drawing.Point(14, 14)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(791, 217)
        Me.GroupControl1.TabIndex = 1159
        Me.GroupControl1.Text = "บันทึกข้อมูลการให้บริการวางแผนครอบครัว"
        '
        'cboFpType
        '
        Me.cboFpType.Location = New System.Drawing.Point(318, 75)
        Me.cboFpType.Name = "cboFpType"
        Me.cboFpType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboFpType.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.cboFpType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboFpType.Size = New System.Drawing.Size(371, 24)
        Me.cboFpType.TabIndex = 1292
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(59, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 17)
        Me.Label2.TabIndex = 1290
        Me.Label2.Text = "ประเภทการรับบริการ"
        '
        'txtFpPlaceName
        '
        Me.txtFpPlaceName.Appearance.BackColor = System.Drawing.Color.White
        Me.txtFpPlaceName.Appearance.Options.UseBackColor = True
        Me.txtFpPlaceName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.txtFpPlaceName.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtFpPlaceName.Location = New System.Drawing.Point(264, 106)
        Me.txtFpPlaceName.Name = "txtFpPlaceName"
        Me.txtFpPlaceName.Size = New System.Drawing.Size(389, 24)
        Me.txtFpPlaceName.TabIndex = 1289
        '
        'txtFpType
        '
        Me.txtFpType.Location = New System.Drawing.Point(182, 76)
        Me.txtFpType.Name = "txtFpType"
        Me.txtFpType.Properties.Appearance.BackColor = System.Drawing.Color.Beige
        Me.txtFpType.Properties.Appearance.Options.UseBackColor = True
        Me.txtFpType.Properties.Appearance.Options.UseTextOptions = True
        Me.txtFpType.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtFpType.Size = New System.Drawing.Size(118, 24)
        Me.txtFpType.TabIndex = 1288
        '
        'txtFpPlaceCode
        '
        Me.txtFpPlaceCode.Location = New System.Drawing.Point(182, 105)
        Me.txtFpPlaceCode.Name = "txtFpPlaceCode"
        Me.txtFpPlaceCode.Properties.Appearance.BackColor = System.Drawing.Color.Beige
        Me.txtFpPlaceCode.Properties.Appearance.Options.UseBackColor = True
        Me.txtFpPlaceCode.Properties.Appearance.Options.UseTextOptions = True
        Me.txtFpPlaceCode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtFpPlaceCode.Size = New System.Drawing.Size(76, 24)
        Me.txtFpPlaceCode.TabIndex = 1288
        '
        'chkUnkonw
        '
        Me.chkUnkonw.AutoSize = True
        Me.chkUnkonw.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.chkUnkonw.Location = New System.Drawing.Point(696, 108)
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
        Me.btnLookupHospital.Location = New System.Drawing.Point(659, 106)
        Me.btnLookupHospital.Name = "btnLookupHospital"
        Me.btnLookupHospital.Size = New System.Drawing.Size(31, 25)
        Me.btnLookupHospital.TabIndex = 1286
        Me.btnLookupHospital.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLookupHospital.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(46, 109)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(121, 17)
        Me.Label9.TabIndex = 1285
        Me.Label9.Text = "สถานบริการที่รับบริการ"
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
        Me.cboProvider.Location = New System.Drawing.Point(318, 137)
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
        Me.txtProviderCode.Location = New System.Drawing.Point(182, 136)
        Me.txtProviderCode.Name = "txtProviderCode"
        Me.txtProviderCode.Size = New System.Drawing.Size(130, 25)
        Me.txtProviderCode.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(75, 141)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 17)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "เจ้าหน้าที่ผู้บันทึก"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(92, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "วันที่รับบริการ"
        '
        'chkCancel
        '
        Me.chkCancel.AutoSize = True
        Me.chkCancel.ForeColor = System.Drawing.Color.Maroon
        Me.chkCancel.Location = New System.Drawing.Point(183, 173)
        Me.chkCancel.Name = "chkCancel"
        Me.chkCancel.Size = New System.Drawing.Size(58, 21)
        Me.chkCancel.TabIndex = 1293
        Me.chkCancel.Text = "ยกเลิก"
        Me.chkCancel.UseVisualStyleBackColor = True
        '
        'frmPersonFp
        '
        Me.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(818, 275)
        Me.Controls.Add(Me.lblErrorCode)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPersonFp"
        Me.Text = "บันทึกข้อมูลบริการวางแผนครอบครัว(FP)"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.cboFpType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFpType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFpPlaceCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimeEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDateServ.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDateServ.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboProvider.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblErrorCode As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents cboFpType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents txtFpPlaceName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtFpPlaceCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents chkUnkonw As CheckBox
    Friend WithEvents btnLookupHospital As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TimeEdit1 As DevExpress.XtraEditors.TimeEdit
    Friend WithEvents Label7 As Label
    Friend WithEvents txtDateServ As DevExpress.XtraEditors.DateEdit
    Friend WithEvents cboProvider As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtProviderCode As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label6 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtFpType As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ToolTipController1 As DevExpress.Utils.ToolTipController
    Friend WithEvents chkCancel As CheckBox
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChronicEdit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChronicEdit))
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.lblHOSP_RX = New DevExpress.XtraEditors.LabelControl()
        Me.lblHOSP_DX = New DevExpress.XtraEditors.LabelControl()
        Me.txtTYPEDISCH = New DevExpress.XtraEditors.TextEdit()
        Me.txtHOSP_RX = New DevExpress.XtraEditors.TextEdit()
        Me.txtHOSP_DX = New DevExpress.XtraEditors.TextEdit()
        Me.txtCHRONICDESC = New DevExpress.XtraEditors.LabelControl()
        Me.ToolTipController1 = New DevExpress.Utils.ToolTipController(Me.components)
        Me.txtCHRONIC = New DevExpress.XtraEditors.TextEdit()
        Me.cmdChronicSearch = New System.Windows.Forms.Button()
        Me.cmdHospRx = New System.Windows.Forms.Button()
        Me.cmdHospDx = New System.Windows.Forms.Button()
        Me.cboTYPEDISCH = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtDATE_DISCH = New DevExpress.XtraEditors.DateEdit()
        Me.txtDATE_DIAG = New DevExpress.XtraEditors.DateEdit()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label86 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.lblErrorCode = New System.Windows.Forms.Label()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.txtTYPEDISCH.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHOSP_RX.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHOSP_DX.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCHRONIC.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTYPEDISCH.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDATE_DISCH.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDATE_DISCH.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDATE_DIAG.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDATE_DIAG.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.lblHOSP_RX)
        Me.GroupControl1.Controls.Add(Me.lblHOSP_DX)
        Me.GroupControl1.Controls.Add(Me.txtTYPEDISCH)
        Me.GroupControl1.Controls.Add(Me.txtHOSP_RX)
        Me.GroupControl1.Controls.Add(Me.txtHOSP_DX)
        Me.GroupControl1.Controls.Add(Me.txtCHRONICDESC)
        Me.GroupControl1.Controls.Add(Me.txtCHRONIC)
        Me.GroupControl1.Controls.Add(Me.cmdChronicSearch)
        Me.GroupControl1.Controls.Add(Me.cmdHospRx)
        Me.GroupControl1.Controls.Add(Me.cmdHospDx)
        Me.GroupControl1.Controls.Add(Me.cboTYPEDISCH)
        Me.GroupControl1.Controls.Add(Me.txtDATE_DISCH)
        Me.GroupControl1.Controls.Add(Me.txtDATE_DIAG)
        Me.GroupControl1.Controls.Add(Me.Label33)
        Me.GroupControl1.Controls.Add(Me.Label8)
        Me.GroupControl1.Controls.Add(Me.Label7)
        Me.GroupControl1.Controls.Add(Me.Label86)
        Me.GroupControl1.Controls.Add(Me.Label28)
        Me.GroupControl1.Controls.Add(Me.Label2)
        Me.GroupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Card
        Me.GroupControl1.Location = New System.Drawing.Point(12, 12)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(824, 253)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "รายละเอียดการลงทะเบียน"
        '
        'lblHOSP_RX
        '
        Me.lblHOSP_RX.Appearance.BackColor = System.Drawing.Color.White
        Me.lblHOSP_RX.Appearance.Options.UseBackColor = True
        Me.lblHOSP_RX.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblHOSP_RX.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.lblHOSP_RX.Location = New System.Drawing.Point(283, 133)
        Me.lblHOSP_RX.Name = "lblHOSP_RX"
        Me.lblHOSP_RX.Size = New System.Drawing.Size(457, 24)
        Me.lblHOSP_RX.TabIndex = 1277
        '
        'lblHOSP_DX
        '
        Me.lblHOSP_DX.Appearance.BackColor = System.Drawing.Color.White
        Me.lblHOSP_DX.Appearance.Options.UseBackColor = True
        Me.lblHOSP_DX.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblHOSP_DX.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.lblHOSP_DX.Location = New System.Drawing.Point(283, 102)
        Me.lblHOSP_DX.Name = "lblHOSP_DX"
        Me.lblHOSP_DX.Size = New System.Drawing.Size(457, 24)
        Me.lblHOSP_DX.TabIndex = 1276
        '
        'txtTYPEDISCH
        '
        Me.txtTYPEDISCH.Location = New System.Drawing.Point(222, 163)
        Me.txtTYPEDISCH.Name = "txtTYPEDISCH"
        Me.txtTYPEDISCH.Properties.Appearance.BackColor = System.Drawing.Color.Beige
        Me.txtTYPEDISCH.Properties.Appearance.Options.UseBackColor = True
        Me.txtTYPEDISCH.Properties.Appearance.Options.UseTextOptions = True
        Me.txtTYPEDISCH.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtTYPEDISCH.Size = New System.Drawing.Size(55, 24)
        Me.txtTYPEDISCH.TabIndex = 1275
        '
        'txtHOSP_RX
        '
        Me.txtHOSP_RX.Location = New System.Drawing.Point(222, 133)
        Me.txtHOSP_RX.Name = "txtHOSP_RX"
        Me.txtHOSP_RX.Properties.Appearance.BackColor = System.Drawing.Color.Beige
        Me.txtHOSP_RX.Properties.Appearance.Options.UseBackColor = True
        Me.txtHOSP_RX.Properties.Appearance.Options.UseTextOptions = True
        Me.txtHOSP_RX.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtHOSP_RX.Size = New System.Drawing.Size(55, 24)
        Me.txtHOSP_RX.TabIndex = 1274
        '
        'txtHOSP_DX
        '
        Me.txtHOSP_DX.Location = New System.Drawing.Point(222, 102)
        Me.txtHOSP_DX.Name = "txtHOSP_DX"
        Me.txtHOSP_DX.Properties.Appearance.BackColor = System.Drawing.Color.Beige
        Me.txtHOSP_DX.Properties.Appearance.Options.UseBackColor = True
        Me.txtHOSP_DX.Properties.Appearance.Options.UseTextOptions = True
        Me.txtHOSP_DX.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtHOSP_DX.Size = New System.Drawing.Size(55, 24)
        Me.txtHOSP_DX.TabIndex = 1273
        '
        'txtCHRONICDESC
        '
        Me.txtCHRONICDESC.Appearance.BackColor = System.Drawing.Color.White
        Me.txtCHRONICDESC.Appearance.Options.UseBackColor = True
        Me.txtCHRONICDESC.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.txtCHRONICDESC.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtCHRONICDESC.Location = New System.Drawing.Point(283, 71)
        Me.txtCHRONICDESC.Name = "txtCHRONICDESC"
        Me.txtCHRONICDESC.Size = New System.Drawing.Size(493, 24)
        Me.txtCHRONICDESC.TabIndex = 1272
        Me.txtCHRONICDESC.ToolTipController = Me.ToolTipController1
        '
        'txtCHRONIC
        '
        Me.txtCHRONIC.Location = New System.Drawing.Point(222, 71)
        Me.txtCHRONIC.Name = "txtCHRONIC"
        Me.txtCHRONIC.Properties.Appearance.BackColor = System.Drawing.Color.Beige
        Me.txtCHRONIC.Properties.Appearance.Options.UseBackColor = True
        Me.txtCHRONIC.Properties.Appearance.Options.UseTextOptions = True
        Me.txtCHRONIC.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtCHRONIC.Size = New System.Drawing.Size(55, 24)
        Me.txtCHRONIC.TabIndex = 1271
        '
        'cmdChronicSearch
        '
        Me.cmdChronicSearch.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdChronicSearch.Image = CType(resources.GetObject("cmdChronicSearch.Image"), System.Drawing.Image)
        Me.cmdChronicSearch.Location = New System.Drawing.Point(782, 70)
        Me.cmdChronicSearch.Name = "cmdChronicSearch"
        Me.cmdChronicSearch.Size = New System.Drawing.Size(30, 26)
        Me.cmdChronicSearch.TabIndex = 1270
        Me.cmdChronicSearch.UseVisualStyleBackColor = True
        '
        'cmdHospRx
        '
        Me.cmdHospRx.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdHospRx.Image = CType(resources.GetObject("cmdHospRx.Image"), System.Drawing.Image)
        Me.cmdHospRx.Location = New System.Drawing.Point(746, 131)
        Me.cmdHospRx.Name = "cmdHospRx"
        Me.cmdHospRx.Size = New System.Drawing.Size(30, 26)
        Me.cmdHospRx.TabIndex = 1269
        Me.cmdHospRx.UseVisualStyleBackColor = True
        '
        'cmdHospDx
        '
        Me.cmdHospDx.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdHospDx.Image = CType(resources.GetObject("cmdHospDx.Image"), System.Drawing.Image)
        Me.cmdHospDx.Location = New System.Drawing.Point(746, 100)
        Me.cmdHospDx.Name = "cmdHospDx"
        Me.cmdHospDx.Size = New System.Drawing.Size(30, 26)
        Me.cmdHospDx.TabIndex = 1268
        Me.cmdHospDx.UseVisualStyleBackColor = True
        '
        'cboTYPEDISCH
        '
        Me.cboTYPEDISCH.Location = New System.Drawing.Point(283, 163)
        Me.cboTYPEDISCH.Name = "cboTYPEDISCH"
        Me.cboTYPEDISCH.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboTYPEDISCH.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboTYPEDISCH.Size = New System.Drawing.Size(363, 24)
        Me.cboTYPEDISCH.TabIndex = 1267
        '
        'txtDATE_DISCH
        '
        Me.txtDATE_DISCH.EditValue = Nothing
        Me.txtDATE_DISCH.Location = New System.Drawing.Point(222, 193)
        Me.txtDATE_DISCH.Name = "txtDATE_DISCH"
        Me.txtDATE_DISCH.Properties.Appearance.BackColor = System.Drawing.Color.Beige
        Me.txtDATE_DISCH.Properties.Appearance.Options.UseBackColor = True
        Me.txtDATE_DISCH.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDATE_DISCH.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDATE_DISCH.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.txtDATE_DISCH.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtDATE_DISCH.Properties.EditFormat.FormatString = "dd/MM/yyyy"
        Me.txtDATE_DISCH.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtDATE_DISCH.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.txtDATE_DISCH.Size = New System.Drawing.Size(132, 24)
        Me.txtDATE_DISCH.TabIndex = 1265
        '
        'txtDATE_DIAG
        '
        Me.txtDATE_DIAG.EditValue = Nothing
        Me.txtDATE_DIAG.Location = New System.Drawing.Point(222, 39)
        Me.txtDATE_DIAG.Name = "txtDATE_DIAG"
        Me.txtDATE_DIAG.Properties.Appearance.BackColor = System.Drawing.Color.Beige
        Me.txtDATE_DIAG.Properties.Appearance.Options.UseBackColor = True
        Me.txtDATE_DIAG.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDATE_DIAG.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDATE_DIAG.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.txtDATE_DIAG.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtDATE_DIAG.Properties.EditFormat.FormatString = "dd/MM/yyyy"
        Me.txtDATE_DIAG.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtDATE_DIAG.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.txtDATE_DIAG.Size = New System.Drawing.Size(132, 24)
        Me.txtDATE_DIAG.TabIndex = 1258
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label33.Location = New System.Drawing.Point(51, 166)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(164, 17)
        Me.Label33.TabIndex = 893
        Me.Label33.Text = "สาเหตุการจำหน่าย/สถานะล่าสุด"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(143, 197)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 17)
        Me.Label8.TabIndex = 892
        Me.Label8.Text = "วันที่จำหน่าย"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(54, 137)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(161, 17)
        Me.Label7.TabIndex = 891
        Me.Label7.Text = "สถานพยาบาลที่รับบริการประจำ"
        '
        'Label86
        '
        Me.Label86.AutoSize = True
        Me.Label86.BackColor = System.Drawing.Color.Transparent
        Me.Label86.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label86.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label86.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label86.Location = New System.Drawing.Point(56, 106)
        Me.Label86.Name = "Label86"
        Me.Label86.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label86.Size = New System.Drawing.Size(159, 17)
        Me.Label86.TabIndex = 890
        Me.Label86.Text = "สถานพยาบาลที่วินิจฉัยครั้งแรก"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label28.Location = New System.Drawing.Point(107, 75)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(108, 17)
        Me.Label28.TabIndex = 889
        Me.Label28.Text = "รหัสวินิจฉัยโรคเรื้อรัง"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(106, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 17)
        Me.Label2.TabIndex = 888
        Me.Label2.Text = "วันที่ตรวจพบครั้งแรก"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdSave
        '
        Me.cmdSave.Image = Global.MyPCU.My.Resources.Resources.a_save
        Me.cmdSave.Location = New System.Drawing.Point(728, 271)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(108, 28)
        Me.cmdSave.TabIndex = 1
        Me.cmdSave.Text = "บันทึก"
        Me.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'lblErrorCode
        '
        Me.lblErrorCode.AutoSize = True
        Me.lblErrorCode.BackColor = System.Drawing.Color.AntiqueWhite
        Me.lblErrorCode.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblErrorCode.ForeColor = System.Drawing.Color.Crimson
        Me.lblErrorCode.Location = New System.Drawing.Point(12, 277)
        Me.lblErrorCode.Name = "lblErrorCode"
        Me.lblErrorCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblErrorCode.Size = New System.Drawing.Size(67, 17)
        Me.lblErrorCode.TabIndex = 891
        Me.lblErrorCode.Text = "ErroCODE"
        Me.lblErrorCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmChronicEdit
        '
        Me.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(848, 312)
        Me.Controls.Add(Me.lblErrorCode)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.GroupControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmChronicEdit"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "บันทึก แก้ไข การลงทะเบียนโรคเรื้อรัง"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.txtTYPEDISCH.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHOSP_RX.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHOSP_DX.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCHRONIC.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTYPEDISCH.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDATE_DISCH.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDATE_DISCH.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDATE_DIAG.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDATE_DIAG.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents Label33 As Label
    Friend WithEvents Label8 As Label
    Public WithEvents Label7 As Label
    Public WithEvents Label86 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtDATE_DISCH As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtDATE_DIAG As DevExpress.XtraEditors.DateEdit
    Friend WithEvents cmdSave As Button
    Friend WithEvents cboTYPEDISCH As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cmdHospRx As Button
    Friend WithEvents cmdHospDx As Button
    Friend WithEvents cmdChronicSearch As Button
    Friend WithEvents txtCHRONIC As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtCHRONICDESC As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblHOSP_RX As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblHOSP_DX As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtTYPEDISCH As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtHOSP_RX As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtHOSP_DX As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ToolTipController1 As DevExpress.Utils.ToolTipController
    Friend WithEvents lblErrorCode As Label
End Class

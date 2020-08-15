<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQueueService
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
        Me.CheckBox6 = New System.Windows.Forms.CheckBox()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.chkClinic = New System.Windows.Forms.CheckBox()
        Me.chkClinicAll = New System.Windows.Forms.CheckBox()
        Me.cboClinic = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpDate1 = New DevExpress.XtraEditors.DateEdit()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BetterListView1 = New ComponentOwl.BetterListView.BetterListView()
        Me.chkRoom = New System.Windows.Forms.CheckBox()
        Me.cboRoom = New DevExpress.XtraEditors.LookUpEdit()
        Me.chkProvider = New System.Windows.Forms.CheckBox()
        Me.cboProvider = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtProviderCode = New DevExpress.XtraEditors.LabelControl()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.cmdRoomSetting = New System.Windows.Forms.Button()
        CType(Me.cboClinic.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpDate1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpDate1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboRoom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboProvider.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CheckBox6
        '
        Me.CheckBox6.AutoSize = True
        Me.CheckBox6.Location = New System.Drawing.Point(458, 88)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(91, 21)
        Me.CheckBox6.TabIndex = 1275
        Me.CheckBox6.Text = "รับบริการแล้ว"
        Me.CheckBox6.UseVisualStyleBackColor = True
        '
        'CheckBox5
        '
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.Location = New System.Drawing.Point(355, 88)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(97, 21)
        Me.CheckBox5.TabIndex = 1274
        Me.CheckBox5.Text = "กำลังรับบริการ"
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Checked = True
        Me.CheckBox4.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox4.Location = New System.Drawing.Point(226, 88)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(123, 21)
        Me.CheckBox4.TabIndex = 1273
        Me.CheckBox4.Text = "เฉพาะที่รอรับบริการ"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(156, 88)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(62, 21)
        Me.CheckBox3.TabIndex = 1272
        Me.CheckBox3.Text = "ทั้งหมด"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'chkClinic
        '
        Me.chkClinic.AutoSize = True
        Me.chkClinic.Location = New System.Drawing.Point(305, 20)
        Me.chkClinic.Name = "chkClinic"
        Me.chkClinic.Size = New System.Drawing.Size(86, 21)
        Me.chkClinic.TabIndex = 1271
        Me.chkClinic.Text = "เฉพาะแผนก"
        Me.chkClinic.UseVisualStyleBackColor = True
        '
        'chkClinicAll
        '
        Me.chkClinicAll.AutoSize = True
        Me.chkClinicAll.Checked = True
        Me.chkClinicAll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkClinicAll.Location = New System.Drawing.Point(228, 20)
        Me.chkClinicAll.Name = "chkClinicAll"
        Me.chkClinicAll.Size = New System.Drawing.Size(71, 21)
        Me.chkClinicAll.TabIndex = 1270
        Me.chkClinicAll.Text = "ทุกแผนก"
        Me.chkClinicAll.UseVisualStyleBackColor = True
        '
        'cboClinic
        '
        Me.cboClinic.Location = New System.Drawing.Point(397, 18)
        Me.cboClinic.Name = "cboClinic"
        Me.cboClinic.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboClinic.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.cboClinic.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboClinic.Size = New System.Drawing.Size(389, 24)
        Me.cboClinic.TabIndex = 1269
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 17)
        Me.Label1.TabIndex = 1268
        Me.Label1.Text = "วันที่รับบริการ"
        '
        'dtpDate1
        '
        Me.dtpDate1.EditValue = Nothing
        Me.dtpDate1.Location = New System.Drawing.Point(93, 18)
        Me.dtpDate1.Name = "dtpDate1"
        Me.dtpDate1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpDate1.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpDate1.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.dtpDate1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtpDate1.Properties.EditFormat.FormatString = "dd/MM/yyyy"
        Me.dtpDate1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtpDate1.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.dtpDate1.Size = New System.Drawing.Size(128, 24)
        Me.dtpDate1.TabIndex = 1267
        '
        'cmdEdit
        '
        Me.cmdEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEdit.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdEdit.Image = Global.MyPCU.My.Resources.Resources.a_edit4
        Me.cmdEdit.Location = New System.Drawing.Point(1063, 79)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(38, 26)
        Me.cmdEdit.TabIndex = 1266
        Me.cmdEdit.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        Me.cmdAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAdd.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdAdd.Image = Global.MyPCU.My.Resources.Resources.a_add
        Me.cmdAdd.Location = New System.Drawing.Point(1019, 79)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(38, 26)
        Me.cmdAdd.TabIndex = 1265
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label16.Location = New System.Drawing.Point(12, 90)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(138, 17)
        Me.Label16.TabIndex = 1264
        Me.Label16.Text = "รายชื่อผู้รอเข้าคิวรับบริการ"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 621)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 17)
        Me.Label2.TabIndex = 1263
        Me.Label2.Text = "จำนวน"
        '
        'BetterListView1
        '
        Me.BetterListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BetterListView1.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.BetterListView1.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Sortable
        Me.BetterListView1.Location = New System.Drawing.Point(14, 115)
        Me.BetterListView1.Name = "BetterListView1"
        Me.BetterListView1.Size = New System.Drawing.Size(1087, 503)
        Me.BetterListView1.TabIndex = 1262
        '
        'chkRoom
        '
        Me.chkRoom.AutoSize = True
        Me.chkRoom.Location = New System.Drawing.Point(792, 20)
        Me.chkRoom.Name = "chkRoom"
        Me.chkRoom.Size = New System.Drawing.Size(103, 21)
        Me.chkRoom.TabIndex = 1277
        Me.chkRoom.Text = "เฉพาะห้องตรวจ"
        Me.chkRoom.UseVisualStyleBackColor = True
        '
        'cboRoom
        '
        Me.cboRoom.Location = New System.Drawing.Point(901, 18)
        Me.cboRoom.Name = "cboRoom"
        Me.cboRoom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboRoom.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.cboRoom.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboRoom.Size = New System.Drawing.Size(87, 24)
        Me.cboRoom.TabIndex = 1276
        '
        'chkProvider
        '
        Me.chkProvider.AutoSize = True
        Me.chkProvider.Location = New System.Drawing.Point(12, 55)
        Me.chkProvider.Name = "chkProvider"
        Me.chkProvider.Size = New System.Drawing.Size(110, 21)
        Me.chkProvider.TabIndex = 1279
        Me.chkProvider.Text = "เฉพาะผู้ให้บริการ"
        Me.chkProvider.UseVisualStyleBackColor = True
        '
        'cboProvider
        '
        Me.cboProvider.Location = New System.Drawing.Point(264, 53)
        Me.cboProvider.Name = "cboProvider"
        Me.cboProvider.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboProvider.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.cboProvider.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboProvider.Size = New System.Drawing.Size(322, 24)
        Me.cboProvider.TabIndex = 1281
        '
        'txtProviderCode
        '
        Me.txtProviderCode.Appearance.BackColor = System.Drawing.Color.Beige
        Me.txtProviderCode.Appearance.Options.UseBackColor = True
        Me.txtProviderCode.Appearance.Options.UseTextOptions = True
        Me.txtProviderCode.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtProviderCode.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.txtProviderCode.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtProviderCode.Location = New System.Drawing.Point(128, 53)
        Me.txtProviderCode.Name = "txtProviderCode"
        Me.txtProviderCode.Size = New System.Drawing.Size(130, 25)
        Me.txtProviderCode.TabIndex = 1280
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(1029, 626)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(72, 17)
        Me.Label9.TabIndex = 1284
        Me.Label9.Text = "รับบริการแล้ว"
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = Global.MyPCU.My.Resources.Resources.a_check3
        Me.PictureBox4.Location = New System.Drawing.Point(1001, 623)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(22, 23)
        Me.PictureBox4.TabIndex = 1283
        Me.PictureBox4.TabStop = False
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(916, 626)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(78, 17)
        Me.Label3.TabIndex = 1286
        Me.Label3.Text = "กำลังรับบริการ"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.MyPCU.My.Resources.Resources.a_opd2
        Me.PictureBox1.Location = New System.Drawing.Point(888, 623)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(22, 23)
        Me.PictureBox1.TabIndex = 1285
        Me.PictureBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(808, 626)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(66, 17)
        Me.Label4.TabIndex = 1288
        Me.Label4.Text = "รอรับบริการ"
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = Global.MyPCU.My.Resources.Resources.a_clock6
        Me.PictureBox2.Location = New System.Drawing.Point(780, 623)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(22, 23)
        Me.PictureBox2.TabIndex = 1287
        Me.PictureBox2.TabStop = False
        '
        'cmdRoomSetting
        '
        Me.cmdRoomSetting.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdRoomSetting.Image = Global.MyPCU.My.Resources.Resources.a_edit4
        Me.cmdRoomSetting.Location = New System.Drawing.Point(994, 17)
        Me.cmdRoomSetting.Name = "cmdRoomSetting"
        Me.cmdRoomSetting.Size = New System.Drawing.Size(38, 26)
        Me.cmdRoomSetting.TabIndex = 1289
        Me.cmdRoomSetting.UseVisualStyleBackColor = True
        '
        'frmQueueService
        '
        Me.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1113, 652)
        Me.Controls.Add(Me.cmdRoomSetting)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.cboProvider)
        Me.Controls.Add(Me.txtProviderCode)
        Me.Controls.Add(Me.chkProvider)
        Me.Controls.Add(Me.chkRoom)
        Me.Controls.Add(Me.cboRoom)
        Me.Controls.Add(Me.CheckBox6)
        Me.Controls.Add(Me.CheckBox5)
        Me.Controls.Add(Me.CheckBox4)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.chkClinic)
        Me.Controls.Add(Me.chkClinicAll)
        Me.Controls.Add(Me.cboClinic)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpDate1)
        Me.Controls.Add(Me.cmdEdit)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BetterListView1)
        Me.Name = "frmQueueService"
        Me.Text = "คัดกรองเบื้ิองต้น-จัดคิวรับบริการ"
        CType(Me.cboClinic.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpDate1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpDate1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboRoom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboProvider.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CheckBox6 As CheckBox
    Friend WithEvents CheckBox5 As CheckBox
    Friend WithEvents CheckBox4 As CheckBox
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents chkClinic As CheckBox
    Friend WithEvents chkClinicAll As CheckBox
    Friend WithEvents cboClinic As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpDate1 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents cmdEdit As Button
    Friend WithEvents cmdAdd As Button
    Friend WithEvents Label16 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents BetterListView1 As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents chkRoom As CheckBox
    Friend WithEvents cboRoom As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents chkProvider As CheckBox
    Friend WithEvents cboProvider As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtProviderCode As DevExpress.XtraEditors.LabelControl
    Public WithEvents Label9 As Label
    Friend WithEvents PictureBox4 As PictureBox
    Public WithEvents Label3 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Public WithEvents Label4 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents cmdRoomSetting As Button
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReferInEdit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReferInEdit))
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.chkReferInType4 = New System.Windows.Forms.CheckBox()
        Me.chkReferInType3 = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateEdit1 = New DevExpress.XtraEditors.DateEdit()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCauseIn = New DevExpress.XtraEditors.TextEdit()
        Me.txtREFER_NO = New DevExpress.XtraEditors.TextEdit()
        Me.cboCauseIn = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtHospin = New DevExpress.XtraEditors.TextEdit()
        Me.bntHospName = New DevExpress.XtraEditors.ButtonEdit()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.chkCancel = New System.Windows.Forms.CheckBox()
        Me.cmdSave = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.DateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCauseIn.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtREFER_NO.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCauseIn.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHospin.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bntHospName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.chkReferInType4)
        Me.GroupControl1.Controls.Add(Me.chkReferInType3)
        Me.GroupControl1.Controls.Add(Me.Label2)
        Me.GroupControl1.Controls.Add(Me.CheckBox4)
        Me.GroupControl1.Controls.Add(Me.CheckBox3)
        Me.GroupControl1.Controls.Add(Me.Label1)
        Me.GroupControl1.Controls.Add(Me.DateEdit1)
        Me.GroupControl1.Controls.Add(Me.Label11)
        Me.GroupControl1.Controls.Add(Me.txtCauseIn)
        Me.GroupControl1.Controls.Add(Me.txtREFER_NO)
        Me.GroupControl1.Controls.Add(Me.cboCauseIn)
        Me.GroupControl1.Controls.Add(Me.Label10)
        Me.GroupControl1.Controls.Add(Me.txtHospin)
        Me.GroupControl1.Controls.Add(Me.bntHospName)
        Me.GroupControl1.Controls.Add(Me.Label18)
        Me.GroupControl1.Controls.Add(Me.Label19)
        Me.GroupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Card
        Me.GroupControl1.Location = New System.Drawing.Point(12, 12)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(736, 229)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "รายละเอียดการส่งต่อ"
        '
        'chkReferInType4
        '
        Me.chkReferInType4.AutoSize = True
        Me.chkReferInType4.Location = New System.Drawing.Point(262, 37)
        Me.chkReferInType4.Name = "chkReferInType4"
        Me.chkReferInType4.Size = New System.Drawing.Size(53, 21)
        Me.chkReferInType4.TabIndex = 1278
        Me.chkReferInType4.Text = "EMS"
        Me.chkReferInType4.UseVisualStyleBackColor = True
        '
        'chkReferInType3
        '
        Me.chkReferInType3.AutoSize = True
        Me.chkReferInType3.Checked = True
        Me.chkReferInType3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkReferInType3.Location = New System.Drawing.Point(139, 37)
        Me.chkReferInType3.Name = "chkReferInType3"
        Me.chkReferInType3.Size = New System.Drawing.Size(117, 21)
        Me.chkReferInType3.TabIndex = 1277
        Me.chkReferInType3.Text = "จากสถานพยาบาล"
        Me.chkReferInType3.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(93, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(44, 17)
        Me.Label2.TabIndex = 1276
        Me.Label2.Text = "ประเภท"
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Location = New System.Drawing.Point(215, 188)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(74, 21)
        Me.CheckBox4.TabIndex = 1275
        Me.CheckBox4.Text = "สแกนไฟล์"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(139, 188)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(70, 21)
        Me.CheckBox3.TabIndex = 1274
        Me.CheckBox3.Text = "เลือกไฟล์"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(87, 190)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 17)
        Me.Label1.TabIndex = 1128
        Me.Label1.Text = "ไฟล์แนบ"
        '
        'DateEdit1
        '
        Me.DateEdit1.EditValue = Nothing
        Me.DateEdit1.Location = New System.Drawing.Point(139, 157)
        Me.DateEdit1.Name = "DateEdit1"
        Me.DateEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Beige
        Me.DateEdit1.Properties.Appearance.Options.UseBackColor = True
        Me.DateEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit1.Size = New System.Drawing.Size(122, 24)
        Me.DateEdit1.TabIndex = 1123
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(37, 160)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 17)
        Me.Label11.TabIndex = 1127
        Me.Label11.Text = "วันหมดอายุใบส่งต่อ"
        '
        'txtCauseIn
        '
        Me.txtCauseIn.Location = New System.Drawing.Point(139, 97)
        Me.txtCauseIn.Name = "txtCauseIn"
        Me.txtCauseIn.Properties.Appearance.BackColor = System.Drawing.Color.Beige
        Me.txtCauseIn.Properties.Appearance.Options.UseBackColor = True
        Me.txtCauseIn.Properties.Appearance.Options.UseTextOptions = True
        Me.txtCauseIn.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtCauseIn.Size = New System.Drawing.Size(65, 24)
        Me.txtCauseIn.TabIndex = 1126
        '
        'txtREFER_NO
        '
        Me.txtREFER_NO.Location = New System.Drawing.Point(139, 127)
        Me.txtREFER_NO.Name = "txtREFER_NO"
        Me.txtREFER_NO.Properties.Appearance.BackColor = System.Drawing.Color.Beige
        Me.txtREFER_NO.Properties.Appearance.Options.UseBackColor = True
        Me.txtREFER_NO.Properties.Appearance.Options.UseTextOptions = True
        Me.txtREFER_NO.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtREFER_NO.Size = New System.Drawing.Size(176, 24)
        Me.txtREFER_NO.TabIndex = 1122
        '
        'cboCauseIn
        '
        Me.cboCauseIn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCauseIn.Location = New System.Drawing.Point(210, 97)
        Me.cboCauseIn.Name = "cboCauseIn"
        Me.cboCauseIn.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboCauseIn.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboCauseIn.Size = New System.Drawing.Size(285, 24)
        Me.cboCauseIn.TabIndex = 1125
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label10.Location = New System.Drawing.Point(53, 101)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 17)
        Me.Label10.TabIndex = 1124
        Me.Label10.Text = "สาเหตุการส่งต่อ"
        '
        'txtHospin
        '
        Me.txtHospin.Location = New System.Drawing.Point(139, 67)
        Me.txtHospin.Name = "txtHospin"
        Me.txtHospin.Properties.Appearance.BackColor = System.Drawing.Color.Beige
        Me.txtHospin.Properties.Appearance.Options.UseBackColor = True
        Me.txtHospin.Properties.Appearance.Options.UseTextOptions = True
        Me.txtHospin.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtHospin.Size = New System.Drawing.Size(65, 24)
        Me.txtHospin.TabIndex = 1121
        '
        'bntHospName
        '
        Me.bntHospName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bntHospName.Location = New System.Drawing.Point(210, 67)
        Me.bntHospName.Name = "bntHospName"
        Me.bntHospName.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.bntHospName.Size = New System.Drawing.Size(515, 24)
        Me.bntHospName.TabIndex = 1120
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(65, 131)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(72, 17)
        Me.Label18.TabIndex = 1119
        Me.Label18.Text = "เลขที่ใบส่งต่อ"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label19.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(13, 70)
        Me.Label19.Name = "Label19"
        Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label19.Size = New System.Drawing.Size(124, 17)
        Me.Label19.TabIndex = 1118
        Me.Label19.Text = "สถานพยาบาลที่ส่งตัวมา"
        '
        'chkCancel
        '
        Me.chkCancel.AutoSize = True
        Me.chkCancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.chkCancel.Location = New System.Drawing.Point(12, 257)
        Me.chkCancel.Name = "chkCancel"
        Me.chkCancel.Size = New System.Drawing.Size(87, 21)
        Me.chkCancel.TabIndex = 1276
        Me.chkCancel.Text = "ยกเลิกข้อมูล"
        Me.chkCancel.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.ImageOptions.Image = Global.MyPCU.My.Resources.Resources.a_save
        Me.cmdSave.Location = New System.Drawing.Point(645, 247)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(103, 31)
        Me.cmdSave.TabIndex = 1289
        Me.cmdSave.Text = "บันทึก"
        '
        'frmReferInEdit
        '
        Me.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(760, 290)
        Me.Controls.Add(Me.chkCancel)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.GroupControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmReferInEdit"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "บันทึกการรับส่งต่อ"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.DateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCauseIn.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtREFER_NO.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCauseIn.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHospin.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bntHospName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents DateEdit1 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label11 As Label
    Friend WithEvents txtCauseIn As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtREFER_NO As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cboCauseIn As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label10 As Label
    Friend WithEvents txtHospin As DevExpress.XtraEditors.TextEdit
    Friend WithEvents bntHospName As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Label18 As Label
    Public WithEvents Label19 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmdSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents CheckBox4 As CheckBox
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents chkCancel As CheckBox
    Friend WithEvents chkReferInType4 As CheckBox
    Friend WithEvents chkReferInType3 As CheckBox
    Public WithEvents Label2 As Label
End Class

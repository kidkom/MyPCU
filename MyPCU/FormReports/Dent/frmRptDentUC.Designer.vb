<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptDentUC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRptDentUC))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpEnd = New DevExpress.XtraEditors.DateEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpStart = New DevExpress.XtraEditors.DateEdit()
        Me.cboProvider = New DevExpress.XtraEditors.LookUpEdit()
        Me.BetterListView1 = New ComponentOwl.BetterListView.BetterListView()
        Me.cmdSave = New DevExpress.XtraEditors.SimpleButton()
        Me.BetterListView2 = New ComponentOwl.BetterListView.BetterListView()
        Me.cmdPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdPrint2 = New DevExpress.XtraEditors.SimpleButton()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.MyPCU.WaitForm1), True, True)
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.cboProced = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        CType(Me.dtpEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboProvider.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BetterListView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.cboProced.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(673, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 17)
        Me.Label2.TabIndex = 1305
        Me.Label2.Text = "ถึงวันที่"
        '
        'dtpEnd
        '
        Me.dtpEnd.EditValue = Nothing
        Me.dtpEnd.Location = New System.Drawing.Point(721, 7)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Properties.Appearance.BackColor = System.Drawing.Color.Beige
        Me.dtpEnd.Properties.Appearance.Options.UseBackColor = True
        Me.dtpEnd.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpEnd.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpEnd.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.dtpEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtpEnd.Properties.EditFormat.FormatString = "dd/MM/yyyy"
        Me.dtpEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtpEnd.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.dtpEnd.Size = New System.Drawing.Size(134, 24)
        Me.dtpEnd.TabIndex = 1304
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(394, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(133, 17)
        Me.Label3.TabIndex = 1303
        Me.Label3.Text = "เลือกช่วงเวลาที่ประมวลผล"
        '
        'dtpStart
        '
        Me.dtpStart.EditValue = Nothing
        Me.dtpStart.Location = New System.Drawing.Point(531, 7)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Properties.Appearance.BackColor = System.Drawing.Color.Beige
        Me.dtpStart.Properties.Appearance.Options.UseBackColor = True
        Me.dtpStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpStart.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpStart.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.dtpStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtpStart.Properties.EditFormat.FormatString = "dd/MM/yyyy"
        Me.dtpStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtpStart.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.dtpStart.Size = New System.Drawing.Size(134, 24)
        Me.dtpStart.TabIndex = 1302
        '
        'cboProvider
        '
        Me.cboProvider.Location = New System.Drawing.Point(122, 7)
        Me.cboProvider.Name = "cboProvider"
        Me.cboProvider.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboProvider.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.cboProvider.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboProvider.Size = New System.Drawing.Size(256, 24)
        Me.cboProvider.TabIndex = 1307
        '
        'BetterListView1
        '
        Me.BetterListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BetterListView1.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.BetterListView1.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Sortable
        Me.BetterListView1.Location = New System.Drawing.Point(11, 37)
        Me.BetterListView1.Name = "BetterListView1"
        Me.BetterListView1.Size = New System.Drawing.Size(951, 143)
        Me.BetterListView1.TabIndex = 1308
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.ImageOptions.Image = Global.MyPCU.My.Resources.Resources.a_play
        Me.cmdSave.Location = New System.Drawing.Point(871, 3)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(90, 31)
        Me.cmdSave.TabIndex = 1309
        Me.cmdSave.Text = "ประมวลผล"
        '
        'BetterListView2
        '
        Me.BetterListView2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BetterListView2.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.BetterListView2.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Sortable
        Me.BetterListView2.Location = New System.Drawing.Point(12, 37)
        Me.BetterListView2.Name = "BetterListView2"
        Me.BetterListView2.Size = New System.Drawing.Size(950, 144)
        Me.BetterListView2.TabIndex = 1310
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.ImageOptions.Image = Global.MyPCU.My.Resources.Resources.a_print2
        Me.cmdPrint.Location = New System.Drawing.Point(873, 186)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(89, 31)
        Me.cmdPrint.TabIndex = 1311
        Me.cmdPrint.Text = "พิมพ์"
        '
        'cmdPrint2
        '
        Me.cmdPrint2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint2.ImageOptions.Image = Global.MyPCU.My.Resources.Resources.a_print2
        Me.cmdPrint2.Location = New System.Drawing.Point(873, 191)
        Me.cmdPrint2.Name = "cmdPrint2"
        Me.cmdPrint2.Size = New System.Drawing.Size(90, 31)
        Me.cmdPrint2.TabIndex = 1312
        Me.cmdPrint2.Text = "พิมพ์"
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label17.Location = New System.Drawing.Point(12, 191)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(43, 17)
        Me.Label17.TabIndex = 1313
        Me.Label17.Text = "จำนวน"
        '
        'SplashScreenManager1
        '
        Me.SplashScreenManager1.ClosingDelay = 500
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.CheckBox1)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.cboProvider)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.dtpStart)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.cmdPrint)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.dtpEnd)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.BetterListView1)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.cmdSave)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.cboProced)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.BetterListView2)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.cmdPrint2)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.Label17)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(974, 473)
        Me.SplitContainerControl1.SplitterPosition = 223
        Me.SplitContainerControl1.TabIndex = 1314
        '
        'cboProced
        '
        Me.cboProced.Location = New System.Drawing.Point(12, 7)
        Me.cboProced.Name = "cboProced"
        Me.cboProced.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboProced.Properties.Items.AddRange(New Object() {"ทั้งหมด", "บัตรทอง", "ถอนฟัน", "ถอนฟัน (UC)", "อุดฟัน", "อุดฟัน (UC)", "ขูดหินปูน", "ขูดหินปูน (UC)", "เคลือบหลุมร่องฟัน", "เคลือบหลุมร่องฟัน  (UC)", "เคลือบฟลูออไรด์", "เคลือบฟลูออไรด์ (UC)", "ขัดฟัน", "ขัดฟัน (UC)", "อื่นๆ", "อื่นๆ (UC)"})
        Me.cboProced.Size = New System.Drawing.Size(181, 24)
        Me.cboProced.TabIndex = 1314
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(12, 9)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(104, 21)
        Me.CheckBox1.TabIndex = 1312
        Me.CheckBox1.Text = "เลือกผู้ให้บริการ"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'frmRptDentUC
        '
        Me.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(974, 473)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRptDentUC"
        Me.Text = "รายงานสรุปข้อมูลทันตกรรม (ประกันสุขภาพถ้วนหน้า)"
        CType(Me.dtpEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboProvider.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BetterListView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.cboProced.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents dtpEnd As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpStart As DevExpress.XtraEditors.DateEdit
    Friend WithEvents cboProvider As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents BetterListView1 As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents cmdSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BetterListView2 As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents cmdPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdPrint2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label17 As Label
    Friend WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents cboProced As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents CheckBox1 As CheckBox
End Class

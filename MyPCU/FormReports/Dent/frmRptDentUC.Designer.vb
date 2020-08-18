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
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BetterListView1 = New ComponentOwl.BetterListView.BetterListView()
        Me.cmdSave = New DevExpress.XtraEditors.SimpleButton()
        Me.BetterListView2 = New ComponentOwl.BetterListView.BetterListView()
        Me.cmdPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdPrint2 = New DevExpress.XtraEditors.SimpleButton()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.MyPCU.WaitForm1), True, True)
        CType(Me.dtpEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboProvider.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BetterListView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(653, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 17)
        Me.Label2.TabIndex = 1305
        Me.Label2.Text = "ถึงวันที่"
        '
        'dtpEnd
        '
        Me.dtpEnd.EditValue = Nothing
        Me.dtpEnd.Location = New System.Drawing.Point(701, 30)
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
        Me.Label3.Location = New System.Drawing.Point(374, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(133, 17)
        Me.Label3.TabIndex = 1303
        Me.Label3.Text = "เลือกช่วงเวลาที่ประมวลผล"
        '
        'dtpStart
        '
        Me.dtpStart.EditValue = Nothing
        Me.dtpStart.Location = New System.Drawing.Point(511, 30)
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
        Me.cboProvider.Location = New System.Drawing.Point(77, 30)
        Me.cboProvider.Name = "cboProvider"
        Me.cboProvider.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboProvider.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.cboProvider.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboProvider.Size = New System.Drawing.Size(288, 24)
        Me.cboProvider.TabIndex = 1307
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 17)
        Me.Label6.TabIndex = 1306
        Me.Label6.Text = "ผู้ให้บริการ"
        '
        'BetterListView1
        '
        Me.BetterListView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BetterListView1.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.BetterListView1.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Sortable
        Me.BetterListView1.Location = New System.Drawing.Point(16, 63)
        Me.BetterListView1.Name = "BetterListView1"
        Me.BetterListView1.Size = New System.Drawing.Size(929, 152)
        Me.BetterListView1.TabIndex = 1308
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.ImageOptions.Image = Global.MyPCU.My.Resources.Resources.a_play
        Me.cmdSave.Location = New System.Drawing.Point(853, 26)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(90, 31)
        Me.cmdSave.TabIndex = 1309
        Me.cmdSave.Text = "ประมวลผล"
        '
        'BetterListView2
        '
        Me.BetterListView2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BetterListView2.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.BetterListView2.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Sortable
        Me.BetterListView2.Location = New System.Drawing.Point(16, 259)
        Me.BetterListView2.Name = "BetterListView2"
        Me.BetterListView2.Size = New System.Drawing.Size(930, 162)
        Me.BetterListView2.TabIndex = 1310
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.ImageOptions.Image = Global.MyPCU.My.Resources.Resources.a_print2
        Me.cmdPrint.Location = New System.Drawing.Point(854, 221)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(89, 31)
        Me.cmdPrint.TabIndex = 1311
        Me.cmdPrint.Text = "พิมพ์"
        '
        'cmdPrint2
        '
        Me.cmdPrint2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint2.ImageOptions.Image = Global.MyPCU.My.Resources.Resources.a_print2
        Me.cmdPrint2.Location = New System.Drawing.Point(853, 429)
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
        Me.Label17.Location = New System.Drawing.Point(13, 436)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(43, 17)
        Me.Label17.TabIndex = 1313
        Me.Label17.Text = "จำนวน"
        '
        'SplashScreenManager1
        '
        Me.SplashScreenManager1.ClosingDelay = 500
        '
        'frmRptDentUC
        '
        Me.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(974, 473)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.cmdPrint2)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.BetterListView2)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.BetterListView1)
        Me.Controls.Add(Me.cboProvider)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpEnd)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtpStart)
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
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents dtpEnd As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpStart As DevExpress.XtraEditors.DateEdit
    Friend WithEvents cboProvider As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label6 As Label
    Friend WithEvents BetterListView1 As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents cmdSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BetterListView2 As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents cmdPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdPrint2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label17 As Label
    Friend WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
End Class

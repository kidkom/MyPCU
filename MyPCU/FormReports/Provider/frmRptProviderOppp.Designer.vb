<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptProviderOppp
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
        Dim SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, Nothing, True, True)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboCard = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboProvider = New DevExpress.XtraEditors.LookUpEdit()
        Me.BetterListView1 = New ComponentOwl.BetterListView.BetterListView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.cmdPrintReport1 = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdSave = New DevExpress.XtraEditors.SimpleButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpEnd = New DevExpress.XtraEditors.DateEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpStart = New DevExpress.XtraEditors.DateEdit()
        CType(Me.cboCard.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboProvider.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplashScreenManager1
        '
        SplashScreenManager1.ClosingDelay = 500
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(55, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 17)
        Me.Label5.TabIndex = 1323
        Me.Label5.Text = "ผู้ให้บริการ"
        '
        'cboCard
        '
        Me.cboCard.Location = New System.Drawing.Point(137, 67)
        Me.cboCard.Name = "cboCard"
        Me.cboCard.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboCard.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboCard.Size = New System.Drawing.Size(211, 24)
        Me.cboCard.TabIndex = 1322
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(55, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 17)
        Me.Label2.TabIndex = 1321
        Me.Label2.Text = "สิทธิ์การรักษา"
        '
        'cboProvider
        '
        Me.cboProvider.Location = New System.Drawing.Point(137, 37)
        Me.cboProvider.Name = "cboProvider"
        Me.cboProvider.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboProvider.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboProvider.Size = New System.Drawing.Size(211, 24)
        Me.cboProvider.TabIndex = 1320
        '
        'BetterListView1
        '
        Me.BetterListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BetterListView1.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.BetterListView1.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Sortable
        Me.BetterListView1.Location = New System.Drawing.Point(57, 101)
        Me.BetterListView1.Name = "BetterListView1"
        Me.BetterListView1.Size = New System.Drawing.Size(908, 260)
        Me.BetterListView1.TabIndex = 1319
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.Location = New System.Drawing.Point(54, 373)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 17)
        Me.Label4.TabIndex = 1315
        Me.Label4.Text = "จำนวน"
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(568, 40)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(138, 21)
        Me.CheckBox3.TabIndex = 1318
        Me.CheckBox3.Text = "สร้างเสริมสุขภาพ (PP)"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(447, 40)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(106, 21)
        Me.CheckBox2.TabIndex = 1317
        Me.CheckBox2.Text = "ผู้ป่วยนอก (OP)"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(379, 40)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(62, 21)
        Me.CheckBox1.TabIndex = 1316
        Me.CheckBox1.Text = "ทั้งหมด"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'cmdPrintReport1
        '
        Me.cmdPrintReport1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintReport1.ImageOptions.Image = Global.MyPCU.My.Resources.Resources.a_print2
        Me.cmdPrintReport1.Location = New System.Drawing.Point(862, 373)
        Me.cmdPrintReport1.Name = "cmdPrintReport1"
        Me.cmdPrintReport1.Size = New System.Drawing.Size(103, 31)
        Me.cmdPrintReport1.TabIndex = 1314
        Me.cmdPrintReport1.Text = "พิมพ์รายงาน"
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.ImageOptions.Image = Global.MyPCU.My.Resources.Resources.a_play
        Me.cmdSave.Location = New System.Drawing.Point(852, 60)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(113, 31)
        Me.cmdSave.TabIndex = 1313
        Me.cmdSave.Text = "ประมวลผล"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(624, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 17)
        Me.Label1.TabIndex = 1312
        Me.Label1.Text = "ถึงวันที่"
        '
        'dtpEnd
        '
        Me.dtpEnd.EditValue = Nothing
        Me.dtpEnd.Location = New System.Drawing.Point(667, 71)
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
        Me.dtpEnd.Size = New System.Drawing.Size(131, 24)
        Me.dtpEnd.TabIndex = 1311
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(374, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 17)
        Me.Label3.TabIndex = 1310
        Me.Label3.Text = "ข้อมูลบริการตั้งแต่วันที่"
        '
        'dtpStart
        '
        Me.dtpStart.EditValue = Nothing
        Me.dtpStart.Location = New System.Drawing.Point(496, 71)
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
        Me.dtpStart.Size = New System.Drawing.Size(122, 24)
        Me.dtpStart.TabIndex = 1309
        '
        'frmRptProviderOppp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1019, 446)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboCard)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboProvider)
        Me.Controls.Add(Me.BetterListView1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.cmdPrintReport1)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpEnd)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtpStart)
        Me.Name = "frmRptProviderOppp"
        Me.Text = "รายงานการให้บริการการรักษา"
        CType(Me.cboCard.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboProvider.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label5 As Label
    Friend WithEvents cboCard As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents cboProvider As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents BetterListView1 As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents Label4 As Label
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents cmdPrintReport1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpEnd As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpStart As DevExpress.XtraEditors.DateEdit
End Class

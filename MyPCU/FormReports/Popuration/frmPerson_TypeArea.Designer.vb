<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPerson_TypeArea
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
        Dim Series1 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim PieSeriesLabel1 As DevExpress.XtraCharts.PieSeriesLabel = New DevExpress.XtraCharts.PieSeriesLabel()
        Dim PieSeriesView1 As DevExpress.XtraCharts.PieSeriesView = New DevExpress.XtraCharts.PieSeriesView()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPerson_TypeArea))
        Me.BetterListView1 = New ComponentOwl.BetterListView.BetterListView()
        Me.ChartControl1 = New DevExpress.XtraCharts.ChartControl()
        Me.BetterListView2 = New ComponentOwl.BetterListView.BetterListView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboTypeArea = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboSex = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboDischarge = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkAddress = New System.Windows.Forms.CheckBox()
        Me.cboCHANGWAT = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboAMPHUR = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboTambon = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboMoo = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmdProcess = New System.Windows.Forms.Button()
        Me.cmdPrintReport2 = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.MyPCU.WaitForm1), True, True)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.cmdPrint1 = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChartControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(PieSeriesLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(PieSeriesView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BetterListView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTypeArea.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboSex.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDischarge.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCHANGWAT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAMPHUR.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTambon.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMoo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BetterListView1
        '
        Me.BetterListView1.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.BetterListView1.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Sortable
        Me.BetterListView1.Location = New System.Drawing.Point(12, 12)
        Me.BetterListView1.Name = "BetterListView1"
        Me.BetterListView1.Size = New System.Drawing.Size(683, 315)
        Me.BetterListView1.TabIndex = 1256
        '
        'ChartControl1
        '
        Me.ChartControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChartControl1.Legend.Name = "Default Legend"
        Me.ChartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.[False]
        Me.ChartControl1.Location = New System.Drawing.Point(715, 12)
        Me.ChartControl1.Name = "ChartControl1"
        PieSeriesLabel1.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series1.Label = PieSeriesLabel1
        Series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.[True]
        Series1.Name = "Series 1"
        Series1.View = PieSeriesView1
        Me.ChartControl1.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series1}
        Me.ChartControl1.Size = New System.Drawing.Size(278, 315)
        Me.ChartControl1.TabIndex = 1263
        '
        'BetterListView2
        '
        Me.BetterListView2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BetterListView2.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.BetterListView2.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Sortable
        Me.BetterListView2.Location = New System.Drawing.Point(12, 443)
        Me.BetterListView2.Name = "BetterListView2"
        Me.BetterListView2.Size = New System.Drawing.Size(981, 165)
        Me.BetterListView2.TabIndex = 1264
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 346)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 17)
        Me.Label1.TabIndex = 1265
        Me.Label1.Text = "สถานะบุคคล (TYPEAREA)"
        '
        'cboTypeArea
        '
        Me.cboTypeArea.Location = New System.Drawing.Point(157, 342)
        Me.cboTypeArea.Name = "cboTypeArea"
        Me.cboTypeArea.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboTypeArea.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboTypeArea.Size = New System.Drawing.Size(79, 24)
        Me.cboTypeArea.TabIndex = 1266
        '
        'cboSex
        '
        Me.cboSex.Location = New System.Drawing.Point(278, 342)
        Me.cboSex.Name = "cboSex"
        Me.cboSex.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboSex.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboSex.Size = New System.Drawing.Size(94, 24)
        Me.cboSex.TabIndex = 1268
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(245, 346)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 17)
        Me.Label2.TabIndex = 1267
        Me.Label2.Text = "เพศ"
        '
        'cboDischarge
        '
        Me.cboDischarge.Location = New System.Drawing.Point(485, 342)
        Me.cboDischarge.Name = "cboDischarge"
        Me.cboDischarge.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboDischarge.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboDischarge.Size = New System.Drawing.Size(124, 24)
        Me.cboDischarge.TabIndex = 1270
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(378, 346)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 17)
        Me.Label3.TabIndex = 1269
        Me.Label3.Text = "สถานะการจำหน่าย"
        '
        'chkAddress
        '
        Me.chkAddress.AutoSize = True
        Me.chkAddress.Location = New System.Drawing.Point(12, 375)
        Me.chkAddress.Name = "chkAddress"
        Me.chkAddress.Size = New System.Drawing.Size(73, 21)
        Me.chkAddress.TabIndex = 1271
        Me.chkAddress.Text = "เลือกที่อยู่"
        Me.chkAddress.UseVisualStyleBackColor = True
        '
        'cboCHANGWAT
        '
        Me.cboCHANGWAT.Location = New System.Drawing.Point(157, 373)
        Me.cboCHANGWAT.Name = "cboCHANGWAT"
        Me.cboCHANGWAT.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboCHANGWAT.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboCHANGWAT.Size = New System.Drawing.Size(169, 24)
        Me.cboCHANGWAT.TabIndex = 1273
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(104, 377)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 17)
        Me.Label4.TabIndex = 1272
        Me.Label4.Text = "จังหวัด"
        '
        'cboAMPHUR
        '
        Me.cboAMPHUR.Location = New System.Drawing.Point(381, 373)
        Me.cboAMPHUR.Name = "cboAMPHUR"
        Me.cboAMPHUR.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboAMPHUR.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboAMPHUR.Size = New System.Drawing.Size(198, 24)
        Me.cboAMPHUR.TabIndex = 1275
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(334, 377)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 17)
        Me.Label5.TabIndex = 1274
        Me.Label5.Text = "อำเภอ"
        '
        'cboTambon
        '
        Me.cboTambon.Location = New System.Drawing.Point(630, 373)
        Me.cboTambon.Name = "cboTambon"
        Me.cboTambon.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboTambon.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboTambon.Size = New System.Drawing.Size(198, 24)
        Me.cboTambon.TabIndex = 1277
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(589, 377)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 17)
        Me.Label6.TabIndex = 1276
        Me.Label6.Text = "ตำบล"
        '
        'cboMoo
        '
        Me.cboMoo.Location = New System.Drawing.Point(156, 404)
        Me.cboMoo.Name = "cboMoo"
        Me.cboMoo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboMoo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboMoo.Size = New System.Drawing.Size(80, 24)
        Me.cboMoo.TabIndex = 1279
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(120, 408)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(23, 17)
        Me.Label7.TabIndex = 1278
        Me.Label7.Text = "หมู่"
        '
        'cmdProcess
        '
        Me.cmdProcess.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdProcess.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdProcess.Image = Global.MyPCU.My.Resources.Resources.a_play
        Me.cmdProcess.Location = New System.Drawing.Point(878, 403)
        Me.cmdProcess.Name = "cmdProcess"
        Me.cmdProcess.Size = New System.Drawing.Size(115, 28)
        Me.cmdProcess.TabIndex = 1282
        Me.cmdProcess.Text = "ประมวลผล"
        Me.cmdProcess.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdProcess.UseVisualStyleBackColor = True
        '
        'cmdPrintReport2
        '
        Me.cmdPrintReport2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintReport2.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdPrintReport2.Image = Global.MyPCU.My.Resources.Resources.a_print2
        Me.cmdPrintReport2.Location = New System.Drawing.Point(878, 614)
        Me.cmdPrintReport2.Name = "cmdPrintReport2"
        Me.cmdPrintReport2.Size = New System.Drawing.Size(115, 28)
        Me.cmdPrintReport2.TabIndex = 1283
        Me.cmdPrintReport2.Text = "พิมพ์รายงาน"
        Me.cmdPrintReport2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdPrintReport2.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(12, 619)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(43, 17)
        Me.Label17.TabIndex = 1284
        Me.Label17.Text = "จำนวน"
        '
        'SplashScreenManager1
        '
        Me.SplashScreenManager1.ClosingDelay = 500
        '
        'Timer1
        '
        '
        'cmdPrint1
        '
        Me.cmdPrint1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint1.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdPrint1.Image = Global.MyPCU.My.Resources.Resources.a_print2
        Me.cmdPrint1.Location = New System.Drawing.Point(878, 340)
        Me.cmdPrint1.Name = "cmdPrint1"
        Me.cmdPrint1.Size = New System.Drawing.Size(115, 28)
        Me.cmdPrint1.TabIndex = 1285
        Me.cmdPrint1.Text = "พิมพ์รายงาน"
        Me.cmdPrint1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdPrint1.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "a_person2.png")
        Me.ImageList1.Images.SetKeyName(1, "women.ico")
        '
        'frmPerson_TypeArea
        '
        Me.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1005, 654)
        Me.Controls.Add(Me.cmdPrint1)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.cmdPrintReport2)
        Me.Controls.Add(Me.cmdProcess)
        Me.Controls.Add(Me.cboMoo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cboTambon)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cboAMPHUR)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboCHANGWAT)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.chkAddress)
        Me.Controls.Add(Me.cboDischarge)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboSex)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboTypeArea)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BetterListView2)
        Me.Controls.Add(Me.ChartControl1)
        Me.Controls.Add(Me.BetterListView1)
        Me.Name = "frmPerson_TypeArea"
        Me.Text = "รายงานประชากรแยกสถานะการอยู่อาศัย"
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(PieSeriesLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(PieSeriesView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BetterListView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTypeArea.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboSex.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDischarge.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCHANGWAT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAMPHUR.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTambon.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMoo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BetterListView1 As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents ChartControl1 As DevExpress.XtraCharts.ChartControl
    Friend WithEvents BetterListView2 As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents Label1 As Label
    Friend WithEvents cboTypeArea As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboSex As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents cboDischarge As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents chkAddress As CheckBox
    Friend WithEvents cboCHANGWAT As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label4 As Label
    Friend WithEvents cboAMPHUR As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label5 As Label
    Friend WithEvents cboTambon As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label6 As Label
    Friend WithEvents cboMoo As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label7 As Label
    Friend WithEvents cmdProcess As Button
    Friend WithEvents cmdPrintReport2 As Button
    Friend WithEvents Label17 As Label
    Friend WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
    Friend WithEvents Timer1 As Timer
    Friend WithEvents cmdPrint1 As Button
    Friend WithEvents ImageList1 As ImageList
End Class

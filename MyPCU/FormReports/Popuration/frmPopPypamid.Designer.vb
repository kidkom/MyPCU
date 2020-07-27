<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPopPypamid
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
        Dim XyDiagram1 As DevExpress.XtraCharts.XYDiagram = New DevExpress.XtraCharts.XYDiagram()
        Dim Series1 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim SideBySideStackedBarSeriesView1 As DevExpress.XtraCharts.SideBySideStackedBarSeriesView = New DevExpress.XtraCharts.SideBySideStackedBarSeriesView()
        Dim Series2 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim SideBySideStackedBarSeriesView2 As DevExpress.XtraCharts.SideBySideStackedBarSeriesView = New DevExpress.XtraCharts.SideBySideStackedBarSeriesView()
        Me.chkAll = New System.Windows.Forms.CheckBox()
        Me.chkArea = New System.Windows.Forms.CheckBox()
        Me.cboVillage = New DevExpress.XtraEditors.LookUpEdit()
        Me.dtpDate1 = New DevExpress.XtraEditors.DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdNewProcess = New System.Windows.Forms.Button()
        Me.ChartControl1 = New DevExpress.XtraCharts.ChartControl()
        Me.BetterListView1 = New ComponentOwl.BetterListView.BetterListView()
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.MyPCU.WaitForm1), True, True)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdPrint2 = New System.Windows.Forms.Button()
        Me.cmdPrintVillage = New System.Windows.Forms.Button()
        CType(Me.cboVillage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpDate1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpDate1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChartControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(SideBySideStackedBarSeriesView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(SideBySideStackedBarSeriesView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.Checked = True
        Me.chkAll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAll.Location = New System.Drawing.Point(26, 13)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(62, 21)
        Me.chkAll.TabIndex = 0
        Me.chkAll.Text = "ทั้งหมด"
        Me.chkAll.UseVisualStyleBackColor = True
        '
        'chkArea
        '
        Me.chkArea.AutoSize = True
        Me.chkArea.Location = New System.Drawing.Point(103, 13)
        Me.chkArea.Name = "chkArea"
        Me.chkArea.Size = New System.Drawing.Size(142, 21)
        Me.chkArea.TabIndex = 1
        Me.chkArea.Text = "แยกตามพื้นที่รับผิดชอบ"
        Me.chkArea.UseVisualStyleBackColor = True
        '
        'cboVillage
        '
        Me.cboVillage.Location = New System.Drawing.Point(251, 12)
        Me.cboVillage.Name = "cboVillage"
        Me.cboVillage.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboVillage.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboVillage.Size = New System.Drawing.Size(389, 24)
        Me.cboVillage.TabIndex = 11
        '
        'dtpDate1
        '
        Me.dtpDate1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpDate1.EditValue = Nothing
        Me.dtpDate1.Location = New System.Drawing.Point(976, 14)
        Me.dtpDate1.Name = "dtpDate1"
        Me.dtpDate1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpDate1.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpDate1.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.dtpDate1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtpDate1.Properties.EditFormat.FormatString = "dd/MM/yyyy"
        Me.dtpDate1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtpDate1.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.dtpDate1.Size = New System.Drawing.Size(128, 24)
        Me.dtpDate1.TabIndex = 1251
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(876, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 17)
        Me.Label2.TabIndex = 1252
        Me.Label2.Text = "ประมวลผลถึงวันที่"
        '
        'cmdNewProcess
        '
        Me.cmdNewProcess.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdNewProcess.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdNewProcess.Image = Global.MyPCU.My.Resources.Resources.a_play
        Me.cmdNewProcess.Location = New System.Drawing.Point(1110, 12)
        Me.cmdNewProcess.Name = "cmdNewProcess"
        Me.cmdNewProcess.Size = New System.Drawing.Size(115, 28)
        Me.cmdNewProcess.TabIndex = 1253
        Me.cmdNewProcess.Text = "ประมวลผลใหม่"
        Me.cmdNewProcess.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdNewProcess.UseVisualStyleBackColor = True
        '
        'ChartControl1
        '
        Me.ChartControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        XyDiagram1.AxisX.Label.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        XyDiagram1.AxisX.VisibleInPanesSerializable = "-1"
        XyDiagram1.AxisY.Label.Font = New System.Drawing.Font("Leelawadee UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        XyDiagram1.AxisY.VisibleInPanesSerializable = "-1"
        XyDiagram1.EnableAxisXScrolling = True
        XyDiagram1.EnableAxisXZooming = True
        XyDiagram1.EnableAxisYScrolling = True
        XyDiagram1.EnableAxisYZooming = True
        XyDiagram1.Rotated = True
        Me.ChartControl1.Diagram = XyDiagram1
        Me.ChartControl1.Legend.Name = "Default Legend"
        Me.ChartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.[True]
        Me.ChartControl1.Location = New System.Drawing.Point(28, 93)
        Me.ChartControl1.Name = "ChartControl1"
        Series1.Name = "MALE"
        Series1.View = SideBySideStackedBarSeriesView1
        Series2.Name = "FEMALE"
        SideBySideStackedBarSeriesView2.Color = System.Drawing.Color.DeepPink
        Series2.View = SideBySideStackedBarSeriesView2
        Me.ChartControl1.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series1, Series2}
        Me.ChartControl1.Size = New System.Drawing.Size(764, 571)
        Me.ChartControl1.TabIndex = 1254
        '
        'BetterListView1
        '
        Me.BetterListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BetterListView1.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.BetterListView1.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Sortable
        Me.BetterListView1.Location = New System.Drawing.Point(798, 93)
        Me.BetterListView1.Name = "BetterListView1"
        Me.BetterListView1.Size = New System.Drawing.Size(427, 571)
        Me.BetterListView1.TabIndex = 1255
        '
        'SplashScreenManager1
        '
        Me.SplashScreenManager1.ClosingDelay = 500
        '
        'Timer1
        '
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(795, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(430, 32)
        Me.Label1.TabIndex = 1257
        Me.Label1.Text = "ตารางแสดงจำนวนประชากรแยกตามเพศและช่วงอายุ"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(25, 58)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(691, 32)
        Me.Label12.TabIndex = 1256
        Me.Label12.Text = "แผนภูมิแสดงจำนวนประชากรแยกตามเพศและช่วงอายุ"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(25, 667)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 17)
        Me.Label3.TabIndex = 1258
        Me.Label3.Text = "ประมวลผลถึงวันที่"
        '
        'cmdPrint2
        '
        Me.cmdPrint2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint2.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdPrint2.Image = Global.MyPCU.My.Resources.Resources.a_print2
        Me.cmdPrint2.Location = New System.Drawing.Point(1103, 670)
        Me.cmdPrint2.Name = "cmdPrint2"
        Me.cmdPrint2.Size = New System.Drawing.Size(122, 30)
        Me.cmdPrint2.TabIndex = 1259
        Me.cmdPrint2.Text = "พิมพ์รายงาน"
        Me.cmdPrint2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdPrint2.UseVisualStyleBackColor = True
        '
        'cmdPrintVillage
        '
        Me.cmdPrintVillage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintVillage.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdPrintVillage.Image = Global.MyPCU.My.Resources.Resources.a_print2
        Me.cmdPrintVillage.Location = New System.Drawing.Point(611, 670)
        Me.cmdPrintVillage.Name = "cmdPrintVillage"
        Me.cmdPrintVillage.Size = New System.Drawing.Size(181, 30)
        Me.cmdPrintVillage.TabIndex = 1260
        Me.cmdPrintVillage.Text = "พิมพ์รายงานแยกรายหมู่"
        Me.cmdPrintVillage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdPrintVillage.UseVisualStyleBackColor = True
        '
        'frmPopPypamid
        '
        Me.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1237, 711)
        Me.Controls.Add(Me.cmdPrintVillage)
        Me.Controls.Add(Me.cmdPrint2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.BetterListView1)
        Me.Controls.Add(Me.ChartControl1)
        Me.Controls.Add(Me.cmdNewProcess)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpDate1)
        Me.Controls.Add(Me.cboVillage)
        Me.Controls.Add(Me.chkArea)
        Me.Controls.Add(Me.chkAll)
        Me.Name = "frmPopPypamid"
        Me.Text = "รายงานจำนวนประชากรแยกตามกลุ่มอายุและเพศ"
        CType(Me.cboVillage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpDate1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpDate1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(SideBySideStackedBarSeriesView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(SideBySideStackedBarSeriesView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chkAll As CheckBox
    Friend WithEvents chkArea As CheckBox
    Friend WithEvents cboVillage As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents dtpDate1 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents cmdNewProcess As Button
    Friend WithEvents ChartControl1 As DevExpress.XtraCharts.ChartControl
    Friend WithEvents BetterListView1 As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label1 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cmdPrint2 As Button
    Friend WithEvents cmdPrintVillage As Button
End Class

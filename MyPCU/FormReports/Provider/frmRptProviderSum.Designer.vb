<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptProviderSum
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRptProviderSum))
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.cmdPrintReport1 = New DevExpress.XtraEditors.SimpleButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdSave = New DevExpress.XtraEditors.SimpleButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpEnd = New DevExpress.XtraEditors.DateEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BetterListView1 = New ComponentOwl.BetterListView.BetterListView()
        Me.dtpStart = New DevExpress.XtraEditors.DateEdit()
        Me.cmdPrintReport2 = New DevExpress.XtraEditors.SimpleButton()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BetterListView2 = New ComponentOwl.BetterListView.BetterListView()
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.MyPCU.WaitForm1), True, True)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.dtpEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BetterListView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.cmdPrintReport1)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.cmdSave)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.dtpEnd)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.BetterListView1)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.dtpStart)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.cmdPrintReport2)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.CheckBox3)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.CheckBox2)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.CheckBox1)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.Label5)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.BetterListView2)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(752, 482)
        Me.SplitContainerControl1.SplitterPosition = 244
        Me.SplitContainerControl1.TabIndex = 0
        '
        'cmdPrintReport1
        '
        Me.cmdPrintReport1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintReport1.ImageOptions.Image = Global.MyPCU.My.Resources.Resources.a_print2
        Me.cmdPrintReport1.Location = New System.Drawing.Point(639, 12)
        Me.cmdPrintReport1.Name = "cmdPrintReport1"
        Me.cmdPrintReport1.Size = New System.Drawing.Size(103, 31)
        Me.cmdPrintReport1.TabIndex = 1297
        Me.cmdPrintReport1.Text = "พิมพ์"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 222)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 17)
        Me.Label4.TabIndex = 1296
        Me.Label4.Text = "จำนวน"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(599, 222)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(143, 17)
        Me.Label2.TabIndex = 1295
        Me.Label2.Text = "คลิกรายชื่อเพื่อดูรายละเอียด"
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.ImageOptions.Image = Global.MyPCU.My.Resources.Resources.a_play
        Me.cmdSave.Location = New System.Drawing.Point(531, 12)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(103, 31)
        Me.cmdSave.TabIndex = 1293
        Me.cmdSave.Text = "ประมวลผล"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(298, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 17)
        Me.Label1.TabIndex = 1292
        Me.Label1.Text = "ถึงวันที่"
        '
        'dtpEnd
        '
        Me.dtpEnd.EditValue = Nothing
        Me.dtpEnd.Location = New System.Drawing.Point(357, 16)
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
        Me.dtpEnd.Size = New System.Drawing.Size(132, 24)
        Me.dtpEnd.TabIndex = 1291
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 17)
        Me.Label3.TabIndex = 1290
        Me.Label3.Text = "ข้อมูลบริการตั้งแต่วันที่"
        '
        'BetterListView1
        '
        Me.BetterListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BetterListView1.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.BetterListView1.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Sortable
        Me.BetterListView1.Location = New System.Drawing.Point(12, 49)
        Me.BetterListView1.Name = "BetterListView1"
        Me.BetterListView1.Size = New System.Drawing.Size(730, 170)
        Me.BetterListView1.TabIndex = 1287
        '
        'dtpStart
        '
        Me.dtpStart.EditValue = Nothing
        Me.dtpStart.Location = New System.Drawing.Point(148, 16)
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
        Me.dtpStart.Size = New System.Drawing.Size(132, 24)
        Me.dtpStart.TabIndex = 1289
        '
        'cmdPrintReport2
        '
        Me.cmdPrintReport2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintReport2.ImageOptions.Image = Global.MyPCU.My.Resources.Resources.a_print2
        Me.cmdPrintReport2.Location = New System.Drawing.Point(637, 181)
        Me.cmdPrintReport2.Name = "cmdPrintReport2"
        Me.cmdPrintReport2.Size = New System.Drawing.Size(103, 31)
        Me.cmdPrintReport2.TabIndex = 1298
        Me.cmdPrintReport2.Text = "พิมพ์"
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(200, 11)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(138, 21)
        Me.CheckBox3.TabIndex = 1299
        Me.CheckBox3.Text = "สร้างเสริมสุขภาพ (PP)"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(82, 11)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(106, 21)
        Me.CheckBox2.TabIndex = 1298
        Me.CheckBox2.Text = "ผู้ป่วยนอก (OP)"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(11, 11)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(62, 21)
        Me.CheckBox1.TabIndex = 1297
        Me.CheckBox1.Text = "ทั้งหมด"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 188)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 17)
        Me.Label5.TabIndex = 1296
        Me.Label5.Text = "จำนวน"
        '
        'BetterListView2
        '
        Me.BetterListView2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BetterListView2.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.BetterListView2.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Sortable
        Me.BetterListView2.Location = New System.Drawing.Point(10, 41)
        Me.BetterListView2.Name = "BetterListView2"
        Me.BetterListView2.Size = New System.Drawing.Size(732, 134)
        Me.BetterListView2.TabIndex = 1288
        '
        'SplashScreenManager1
        '
        Me.SplashScreenManager1.ClosingDelay = 500
        '
        'frmRptProviderSum
        '
        Me.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(752, 482)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRptProviderSum"
        Me.Text = "รายงานสรุปการให้บริการของเจ้าหน้าที่"
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.dtpEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BetterListView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents BetterListView1 As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents BetterListView2 As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpEnd As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpStart As DevExpress.XtraEditors.DateEdit
    Friend WithEvents cmdSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents cmdPrintReport1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdPrintReport2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
End Class

﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProviderRx
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProviderRx))
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.MyPCU.WaitForm1), True, True)
        Me.BetterListView1 = New ComponentOwl.BetterListView.BetterListView()
        Me.cboProvider = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmdPrintReport1 = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpEnd = New DevExpress.XtraEditors.DateEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpStart = New DevExpress.XtraEditors.DateEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmdToday = New DevExpress.XtraEditors.SimpleButton()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboProvider.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplashScreenManager1
        '
        Me.SplashScreenManager1.ClosingDelay = 500
        '
        'BetterListView1
        '
        Me.BetterListView1.AccessibleName = "BetterListView1"
        Me.BetterListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BetterListView1.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.BetterListView1.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Sortable
        Me.BetterListView1.Location = New System.Drawing.Point(12, 89)
        Me.BetterListView1.Name = "BetterListView1"
        Me.BetterListView1.Size = New System.Drawing.Size(1022, 462)
        Me.BetterListView1.TabIndex = 1288
        '
        'cboProvider
        '
        Me.cboProvider.Location = New System.Drawing.Point(83, 12)
        Me.cboProvider.Name = "cboProvider"
        Me.cboProvider.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboProvider.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.cboProvider.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboProvider.Size = New System.Drawing.Size(322, 24)
        Me.cboProvider.TabIndex = 1291
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(23, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 17)
        Me.Label6.TabIndex = 1289
        Me.Label6.Text = "เจ้าหน้าที่"
        '
        'cmdPrintReport1
        '
        Me.cmdPrintReport1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintReport1.ImageOptions.Image = Global.MyPCU.My.Resources.Resources.a_print2
        Me.cmdPrintReport1.Location = New System.Drawing.Point(955, 58)
        Me.cmdPrintReport1.Name = "cmdPrintReport1"
        Me.cmdPrintReport1.Size = New System.Drawing.Size(79, 24)
        Me.cmdPrintReport1.TabIndex = 1303
        Me.cmdPrintReport1.Text = "พิมพ์"
        '
        'cmdSearch
        '
        Me.cmdSearch.ImageOptions.Image = Global.MyPCU.My.Resources.Resources.a_search
        Me.cmdSearch.Location = New System.Drawing.Point(465, 54)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(79, 24)
        Me.cmdSearch.TabIndex = 1302
        Me.cmdSearch.Text = "ค้นหา"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(282, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 17)
        Me.Label1.TabIndex = 1301
        Me.Label1.Text = "ถึงวันที่"
        '
        'dtpEnd
        '
        Me.dtpEnd.EditValue = Nothing
        Me.dtpEnd.Location = New System.Drawing.Point(327, 55)
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
        Me.dtpEnd.TabIndex = 1300
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 17)
        Me.Label3.TabIndex = 1299
        Me.Label3.Text = "ข้อมูลบริการตั้งแต่วันที่"
        '
        'dtpStart
        '
        Me.dtpStart.EditValue = Nothing
        Me.dtpStart.Location = New System.Drawing.Point(140, 55)
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
        Me.dtpStart.TabIndex = 1298
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 554)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 17)
        Me.Label5.TabIndex = 1304
        Me.Label5.Text = "จำนวน"
        '
        'cmdToday
        '
        Me.cmdToday.ImageOptions.Image = Global.MyPCU.My.Resources.Resources.a_calendar
        Me.cmdToday.Location = New System.Drawing.Point(411, 12)
        Me.cmdToday.Name = "cmdToday"
        Me.cmdToday.Size = New System.Drawing.Size(79, 24)
        Me.cmdToday.TabIndex = 1305
        Me.cmdToday.Text = "วันนี้"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "a_person2.png")
        Me.ImageList1.Images.SetKeyName(1, "women.ico")
        '
        'frmProviderRx
        '
        Me.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1046, 587)
        Me.Controls.Add(Me.cmdToday)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmdPrintReport1)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpEnd)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtpStart)
        Me.Controls.Add(Me.cboProvider)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.BetterListView1)
        Me.Name = "frmProviderRx"
        Me.Text = "รายงานผู้รับบริการจำแนกตามรายผู้ให้บริการ (รักษา)"
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboProvider.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BetterListView1 As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents cboProvider As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label6 As Label
    Friend WithEvents cmdPrintReport1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpEnd As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpStart As DevExpress.XtraEditors.DateEdit
    Friend WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
    Friend WithEvents Label5 As Label
    Friend WithEvents cmdToday As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ImageList1 As ImageList
End Class

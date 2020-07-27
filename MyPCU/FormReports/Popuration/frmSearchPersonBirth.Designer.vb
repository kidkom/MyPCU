<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchPersonBirth
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSearchPersonBirth))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BetterListView1 = New ComponentOwl.BetterListView.BetterListView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtpDate1 = New DevExpress.XtraEditors.DateEdit()
        Me.dtpDate2 = New DevExpress.XtraEditors.DateEdit()
        Me.chkTypeArea4 = New System.Windows.Forms.CheckBox()
        Me.chkTypeArea3 = New System.Windows.Forms.CheckBox()
        Me.chkTypeArea5 = New System.Windows.Forms.CheckBox()
        Me.chkTypeArea1 = New System.Windows.Forms.CheckBox()
        Me.chkTypeArea2 = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboVillage = New DevExpress.XtraEditors.LookUpEdit()
        Me.chkVill = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkAll = New System.Windows.Forms.CheckBox()
        Me.chkMale = New System.Windows.Forms.CheckBox()
        Me.cmdNewProcess = New System.Windows.Forms.Button()
        Me.cmdPrintReport1 = New System.Windows.Forms.Button()
        Me.chkFemale = New System.Windows.Forms.CheckBox()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.MyPCU.WaitForm1), True, True)
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpDate1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpDate1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpDate2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpDate2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboVillage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 576)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 17)
        Me.Label1.TabIndex = 1107
        Me.Label1.Text = "จำนวน"
        '
        'BetterListView1
        '
        Me.BetterListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BetterListView1.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.BetterListView1.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Sortable
        Me.BetterListView1.Location = New System.Drawing.Point(12, 101)
        Me.BetterListView1.Name = "BetterListView1"
        Me.BetterListView1.Size = New System.Drawing.Size(930, 472)
        Me.BetterListView1.TabIndex = 1106
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(207, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 17)
        Me.Label7.TabIndex = 1109
        Me.Label7.Text = "ถึงวันที่"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 17)
        Me.Label9.TabIndex = 1108
        Me.Label9.Text = "ตั้งแต่วันที่"
        '
        'dtpDate1
        '
        Me.dtpDate1.EditValue = Nothing
        Me.dtpDate1.Location = New System.Drawing.Point(73, 16)
        Me.dtpDate1.Name = "dtpDate1"
        Me.dtpDate1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpDate1.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpDate1.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.dtpDate1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtpDate1.Properties.EditFormat.FormatString = "dd/MM/yyyy"
        Me.dtpDate1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtpDate1.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.dtpDate1.Size = New System.Drawing.Size(128, 24)
        Me.dtpDate1.TabIndex = 1252
        '
        'dtpDate2
        '
        Me.dtpDate2.EditValue = Nothing
        Me.dtpDate2.Location = New System.Drawing.Point(255, 16)
        Me.dtpDate2.Name = "dtpDate2"
        Me.dtpDate2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpDate2.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpDate2.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.dtpDate2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtpDate2.Properties.EditFormat.FormatString = "dd/MM/yyyy"
        Me.dtpDate2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtpDate2.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.dtpDate2.Size = New System.Drawing.Size(128, 24)
        Me.dtpDate2.TabIndex = 1253
        '
        'chkTypeArea4
        '
        Me.chkTypeArea4.AutoSize = True
        Me.chkTypeArea4.Location = New System.Drawing.Point(690, 18)
        Me.chkTypeArea4.Name = "chkTypeArea4"
        Me.chkTypeArea4.Size = New System.Drawing.Size(34, 21)
        Me.chkTypeArea4.TabIndex = 828
        Me.chkTypeArea4.Text = "4"
        Me.chkTypeArea4.UseVisualStyleBackColor = True
        '
        'chkTypeArea3
        '
        Me.chkTypeArea3.AutoSize = True
        Me.chkTypeArea3.Checked = True
        Me.chkTypeArea3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTypeArea3.Location = New System.Drawing.Point(640, 18)
        Me.chkTypeArea3.Name = "chkTypeArea3"
        Me.chkTypeArea3.Size = New System.Drawing.Size(34, 21)
        Me.chkTypeArea3.TabIndex = 827
        Me.chkTypeArea3.Text = "3"
        Me.chkTypeArea3.UseVisualStyleBackColor = True
        '
        'chkTypeArea5
        '
        Me.chkTypeArea5.AutoSize = True
        Me.chkTypeArea5.Location = New System.Drawing.Point(741, 18)
        Me.chkTypeArea5.Name = "chkTypeArea5"
        Me.chkTypeArea5.Size = New System.Drawing.Size(34, 21)
        Me.chkTypeArea5.TabIndex = 826
        Me.chkTypeArea5.Text = "5"
        Me.chkTypeArea5.UseVisualStyleBackColor = True
        '
        'chkTypeArea1
        '
        Me.chkTypeArea1.AutoSize = True
        Me.chkTypeArea1.Checked = True
        Me.chkTypeArea1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTypeArea1.Location = New System.Drawing.Point(536, 18)
        Me.chkTypeArea1.Name = "chkTypeArea1"
        Me.chkTypeArea1.Size = New System.Drawing.Size(34, 21)
        Me.chkTypeArea1.TabIndex = 824
        Me.chkTypeArea1.Text = "1"
        Me.chkTypeArea1.UseVisualStyleBackColor = True
        '
        'chkTypeArea2
        '
        Me.chkTypeArea2.AutoSize = True
        Me.chkTypeArea2.Location = New System.Drawing.Point(585, 18)
        Me.chkTypeArea2.Name = "chkTypeArea2"
        Me.chkTypeArea2.Size = New System.Drawing.Size(34, 21)
        Me.chkTypeArea2.TabIndex = 825
        Me.chkTypeArea2.Text = "2"
        Me.chkTypeArea2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(401, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(129, 17)
        Me.Label2.TabIndex = 1255
        Me.Label2.Text = "สถานะบุคคล (Typeaea)"
        '
        'cboVillage
        '
        Me.cboVillage.Location = New System.Drawing.Point(162, 55)
        Me.cboVillage.Name = "cboVillage"
        Me.cboVillage.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboVillage.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboVillage.Size = New System.Drawing.Size(389, 24)
        Me.cboVillage.TabIndex = 1257
        '
        'chkVill
        '
        Me.chkVill.AutoSize = True
        Me.chkVill.Location = New System.Drawing.Point(14, 57)
        Me.chkVill.Name = "chkVill"
        Me.chkVill.Size = New System.Drawing.Size(142, 21)
        Me.chkVill.TabIndex = 1256
        Me.chkVill.Text = "แยกตามพื้นที่รับผิดชอบ"
        Me.chkVill.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(570, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 17)
        Me.Label3.TabIndex = 1260
        Me.Label3.Text = "เพศ"
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.Checked = True
        Me.chkAll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAll.Location = New System.Drawing.Point(613, 57)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(62, 21)
        Me.chkAll.TabIndex = 1258
        Me.chkAll.Text = "ทั้งหมด"
        Me.chkAll.UseVisualStyleBackColor = True
        '
        'chkMale
        '
        Me.chkMale.AutoSize = True
        Me.chkMale.Location = New System.Drawing.Point(681, 57)
        Me.chkMale.Name = "chkMale"
        Me.chkMale.Size = New System.Drawing.Size(48, 21)
        Me.chkMale.TabIndex = 1259
        Me.chkMale.Text = "ชาย"
        Me.chkMale.UseVisualStyleBackColor = True
        '
        'cmdNewProcess
        '
        Me.cmdNewProcess.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdNewProcess.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdNewProcess.Image = Global.MyPCU.My.Resources.Resources.a_play
        Me.cmdNewProcess.Location = New System.Drawing.Point(827, 54)
        Me.cmdNewProcess.Name = "cmdNewProcess"
        Me.cmdNewProcess.Size = New System.Drawing.Size(115, 28)
        Me.cmdNewProcess.TabIndex = 1261
        Me.cmdNewProcess.Text = "ประมวลผล"
        Me.cmdNewProcess.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdNewProcess.UseVisualStyleBackColor = True
        '
        'cmdPrintReport1
        '
        Me.cmdPrintReport1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintReport1.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdPrintReport1.Image = Global.MyPCU.My.Resources.Resources.a_print2
        Me.cmdPrintReport1.Location = New System.Drawing.Point(827, 584)
        Me.cmdPrintReport1.Name = "cmdPrintReport1"
        Me.cmdPrintReport1.Size = New System.Drawing.Size(115, 28)
        Me.cmdPrintReport1.TabIndex = 1262
        Me.cmdPrintReport1.Text = "พิมพ์รายงาน"
        Me.cmdPrintReport1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdPrintReport1.UseVisualStyleBackColor = True
        '
        'chkFemale
        '
        Me.chkFemale.AutoSize = True
        Me.chkFemale.Location = New System.Drawing.Point(735, 57)
        Me.chkFemale.Name = "chkFemale"
        Me.chkFemale.Size = New System.Drawing.Size(51, 21)
        Me.chkFemale.TabIndex = 1263
        Me.chkFemale.Text = "หญิง"
        Me.chkFemale.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "a_person2.png")
        Me.ImageList1.Images.SetKeyName(1, "women.ico")
        '
        'SplashScreenManager1
        '
        Me.SplashScreenManager1.ClosingDelay = 500
        '
        'frmSearchPersonBirth
        '
        Me.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(954, 624)
        Me.Controls.Add(Me.chkFemale)
        Me.Controls.Add(Me.cmdPrintReport1)
        Me.Controls.Add(Me.cmdNewProcess)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.chkAll)
        Me.Controls.Add(Me.chkMale)
        Me.Controls.Add(Me.cboVillage)
        Me.Controls.Add(Me.chkVill)
        Me.Controls.Add(Me.chkTypeArea4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chkTypeArea3)
        Me.Controls.Add(Me.chkTypeArea5)
        Me.Controls.Add(Me.dtpDate2)
        Me.Controls.Add(Me.chkTypeArea1)
        Me.Controls.Add(Me.chkTypeArea2)
        Me.Controls.Add(Me.dtpDate1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BetterListView1)
        Me.Name = "frmSearchPersonBirth"
        Me.Text = "ข้อมูลบุคคลตามวันเกิด"
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpDate1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpDate1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpDate2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpDate2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboVillage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents BetterListView1 As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents dtpDate1 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents dtpDate2 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents chkTypeArea4 As CheckBox
    Friend WithEvents chkTypeArea3 As CheckBox
    Friend WithEvents chkTypeArea5 As CheckBox
    Friend WithEvents chkTypeArea1 As CheckBox
    Friend WithEvents chkTypeArea2 As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cboVillage As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents chkVill As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents chkAll As CheckBox
    Friend WithEvents chkMale As CheckBox
    Friend WithEvents cmdNewProcess As Button
    Friend WithEvents cmdPrintReport1 As Button
    Friend WithEvents chkFemale As CheckBox
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
End Class

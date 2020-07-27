<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAssetFix
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAssetFix))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDOC_NO = New System.Windows.Forms.TextBox()
        Me.cmdDel = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDETAIL = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPRICE = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtASSET_NAME = New System.Windows.Forms.Label()
        Me.lblASSET_CODE_ID = New System.Windows.Forms.Label()
        Me.lblAmount = New System.Windows.Forms.Label()
        Me.cmdPrint = New System.Windows.Forms.Button()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.cmdFixMat = New System.Windows.Forms.Button()
        Me.cboBUDGET = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtDATE_IN = New DevExpress.XtraEditors.LabelControl()
        Me.cmdCalenda = New System.Windows.Forms.Button()
        Me.BetterListView1 = New ComponentOwl.BetterListView.BetterListView()
        Me.CalendarControl1 = New DevExpress.XtraEditors.Controls.CalendarControl()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.cboBUDGET.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CalendarControl1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 384)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(229, 15)
        Me.Label1.TabIndex = 943
        Me.Label1.Text = "รายละเอียดการปรับปรุง เปลี่ยนแปลง ซ่อมบำรุง"
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.Location = New System.Drawing.Point(12, 404)
        Me.ListView1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(765, 217)
        Me.ListView1.TabIndex = 942
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(73, 204)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 17)
        Me.Label7.TabIndex = 993
        Me.Label7.Text = "เอกสารอ้างอิง"
        '
        'txtDOC_NO
        '
        Me.txtDOC_NO.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtDOC_NO.Location = New System.Drawing.Point(157, 201)
        Me.txtDOC_NO.Name = "txtDOC_NO"
        Me.txtDOC_NO.Size = New System.Drawing.Size(578, 23)
        Me.txtDOC_NO.TabIndex = 4
        '
        'cmdDel
        '
        Me.cmdDel.Image = Global.MyPCU.My.Resources.Resources.a_minus
        Me.cmdDel.Location = New System.Drawing.Point(256, 311)
        Me.cmdDel.Name = "cmdDel"
        Me.cmdDel.Size = New System.Drawing.Size(93, 35)
        Me.cmdDel.TabIndex = 991
        Me.cmdDel.Text = "ลบ"
        Me.cmdDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdDel.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Image = Global.MyPCU.My.Resources.Resources.a_save
        Me.cmdSave.Location = New System.Drawing.Point(157, 311)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(93, 35)
        Me.cmdSave.TabIndex = 990
        Me.cmdSave.Text = "บันทึก"
        Me.cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(85, 230)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 17)
        Me.Label2.TabIndex = 987
        Me.Label2.Text = "รายละเอียด"
        '
        'txtDETAIL
        '
        Me.txtDETAIL.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtDETAIL.Location = New System.Drawing.Point(157, 230)
        Me.txtDETAIL.Multiline = True
        Me.txtDETAIL.Name = "txtDETAIL"
        Me.txtDETAIL.Size = New System.Drawing.Size(578, 75)
        Me.txtDETAIL.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(105, 175)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(45, 17)
        Me.Label13.TabIndex = 984
        Me.Label13.Text = "เงินที่ใช้"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(291, 147)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 17)
        Me.Label8.TabIndex = 983
        Me.Label8.Text = "บาท"
        '
        'txtPRICE
        '
        Me.txtPRICE.BackColor = System.Drawing.Color.Beige
        Me.txtPRICE.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtPRICE.Location = New System.Drawing.Point(157, 144)
        Me.txtPRICE.Name = "txtPRICE"
        Me.txtPRICE.Size = New System.Drawing.Size(128, 23)
        Me.txtPRICE.TabIndex = 981
        Me.txtPRICE.Text = "0.00"
        Me.txtPRICE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(90, 147)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 17)
        Me.Label6.TabIndex = 982
        Me.Label6.Text = "จำนวนเงิน"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(121, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 17)
        Me.Label5.TabIndex = 979
        Me.Label5.Text = "วันที่"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(39, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 17)
        Me.Label4.TabIndex = 977
        Me.Label4.Text = "รายละเอียดทรัพย์สิน"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(78, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 17)
        Me.Label3.TabIndex = 976
        Me.Label3.Text = "รหัสทรัพย์สิน"
        '
        'txtASSET_NAME
        '
        Me.txtASSET_NAME.BackColor = System.Drawing.Color.White
        Me.txtASSET_NAME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtASSET_NAME.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtASSET_NAME.Location = New System.Drawing.Point(157, 60)
        Me.txtASSET_NAME.Name = "txtASSET_NAME"
        Me.txtASSET_NAME.Size = New System.Drawing.Size(578, 52)
        Me.txtASSET_NAME.TabIndex = 1
        '
        'lblASSET_CODE_ID
        '
        Me.lblASSET_CODE_ID.BackColor = System.Drawing.Color.Beige
        Me.lblASSET_CODE_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblASSET_CODE_ID.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblASSET_CODE_ID.Location = New System.Drawing.Point(157, 30)
        Me.lblASSET_CODE_ID.Name = "lblASSET_CODE_ID"
        Me.lblASSET_CODE_ID.Size = New System.Drawing.Size(255, 26)
        Me.lblASSET_CODE_ID.TabIndex = 974
        Me.lblASSET_CODE_ID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAmount
        '
        Me.lblAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblAmount.AutoSize = True
        Me.lblAmount.BackColor = System.Drawing.Color.Transparent
        Me.lblAmount.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblAmount.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblAmount.ForeColor = System.Drawing.Color.Black
        Me.lblAmount.Location = New System.Drawing.Point(12, 639)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAmount.Size = New System.Drawing.Size(42, 15)
        Me.lblAmount.TabIndex = 994
        Me.lblAmount.Text = "จำนวน"
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdPrint.Image = Global.MyPCU.My.Resources.Resources.a_print2
        Me.cmdPrint.Location = New System.Drawing.Point(637, 629)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(140, 35)
        Me.cmdPrint.TabIndex = 1056
        Me.cmdPrint.Text = "พิมพ์"
        Me.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'GroupControl1
        '
        Me.GroupControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl1.Controls.Add(Me.cmdFixMat)
        Me.GroupControl1.Controls.Add(Me.cboBUDGET)
        Me.GroupControl1.Controls.Add(Me.txtDATE_IN)
        Me.GroupControl1.Controls.Add(Me.cmdCalenda)
        Me.GroupControl1.Controls.Add(Me.Label7)
        Me.GroupControl1.Controls.Add(Me.lblASSET_CODE_ID)
        Me.GroupControl1.Controls.Add(Me.txtDOC_NO)
        Me.GroupControl1.Controls.Add(Me.txtASSET_NAME)
        Me.GroupControl1.Controls.Add(Me.cmdDel)
        Me.GroupControl1.Controls.Add(Me.Label3)
        Me.GroupControl1.Controls.Add(Me.cmdSave)
        Me.GroupControl1.Controls.Add(Me.Label4)
        Me.GroupControl1.Controls.Add(Me.Label2)
        Me.GroupControl1.Controls.Add(Me.Label5)
        Me.GroupControl1.Controls.Add(Me.txtDETAIL)
        Me.GroupControl1.Controls.Add(Me.Label13)
        Me.GroupControl1.Controls.Add(Me.Label6)
        Me.GroupControl1.Controls.Add(Me.Label8)
        Me.GroupControl1.Controls.Add(Me.txtPRICE)
        Me.GroupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Card
        Me.GroupControl1.Location = New System.Drawing.Point(12, 12)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(765, 358)
        Me.GroupControl1.TabIndex = 1057
        Me.GroupControl1.Text = "บันทึกการซ่อมบำรุง ปรับปรุง เปลี่ยนแปลง"
        '
        'cmdFixMat
        '
        Me.cmdFixMat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFixMat.Image = Global.MyPCU.My.Resources.Resources.a_edit4
        Me.cmdFixMat.Location = New System.Drawing.Point(339, 140)
        Me.cmdFixMat.Name = "cmdFixMat"
        Me.cmdFixMat.Size = New System.Drawing.Size(180, 27)
        Me.cmdFixMat.TabIndex = 1168
        Me.cmdFixMat.Text = "รายการวัสดุที่ใช้ซ่อม"
        Me.cmdFixMat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdFixMat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdFixMat.UseVisualStyleBackColor = True
        '
        'cboBUDGET
        '
        Me.cboBUDGET.Location = New System.Drawing.Point(157, 173)
        Me.cboBUDGET.Name = "cboBUDGET"
        Me.cboBUDGET.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboBUDGET.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboBUDGET.Size = New System.Drawing.Size(362, 24)
        Me.cboBUDGET.TabIndex = 1147
        '
        'txtDATE_IN
        '
        Me.txtDATE_IN.Appearance.BackColor = System.Drawing.Color.Beige
        Me.txtDATE_IN.Appearance.Options.UseBackColor = True
        Me.txtDATE_IN.Appearance.Options.UseTextOptions = True
        Me.txtDATE_IN.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtDATE_IN.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.txtDATE_IN.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtDATE_IN.Location = New System.Drawing.Point(157, 116)
        Me.txtDATE_IN.Name = "txtDATE_IN"
        Me.txtDATE_IN.Size = New System.Drawing.Size(128, 24)
        Me.txtDATE_IN.TabIndex = 1167
        '
        'cmdCalenda
        '
        Me.cmdCalenda.Image = Global.MyPCU.My.Resources.Resources.a_calendar
        Me.cmdCalenda.Location = New System.Drawing.Point(291, 115)
        Me.cmdCalenda.Name = "cmdCalenda"
        Me.cmdCalenda.Size = New System.Drawing.Size(33, 26)
        Me.cmdCalenda.TabIndex = 1166
        Me.cmdCalenda.UseVisualStyleBackColor = True
        '
        'BetterListView1
        '
        Me.BetterListView1.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.BetterListView1.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Sortable
        Me.BetterListView1.Location = New System.Drawing.Point(12, 404)
        Me.BetterListView1.Name = "BetterListView1"
        Me.BetterListView1.Size = New System.Drawing.Size(765, 217)
        Me.BetterListView1.TabIndex = 1142
        '
        'CalendarControl1
        '
        Me.CalendarControl1.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CalendarControl1.DateTime = New Date(2019, 10, 11, 0, 0, 0, 0)
        Me.CalendarControl1.EditValue = New Date(2019, 10, 11, 0, 0, 0, 0)
        Me.CalendarControl1.Location = New System.Drawing.Point(168, 152)
        Me.CalendarControl1.Name = "CalendarControl1"
        Me.CalendarControl1.Size = New System.Drawing.Size(232, 267)
        Me.CalendarControl1.TabIndex = 1168
        '
        'frmAssetFix
        '
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 673)
        Me.Controls.Add(Me.CalendarControl1)
        Me.Controls.Add(Me.BetterListView1)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.lblAmount)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListView1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmAssetFix"
        Me.ShowInTaskbar = False
        Me.Text = "บันทึกการซ่อมบำรุง ปรับปรุง เปลี่ยนแปลง"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.cboBUDGET.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CalendarControl1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtASSET_NAME As System.Windows.Forms.Label
    Friend WithEvents lblASSET_CODE_ID As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPRICE As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDETAIL As System.Windows.Forms.TextBox
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdDel As System.Windows.Forms.Button
    Public WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDOC_NO As System.Windows.Forms.TextBox
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BetterListView1 As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents cboBUDGET As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtDATE_IN As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdCalenda As System.Windows.Forms.Button
    Friend WithEvents CalendarControl1 As DevExpress.XtraEditors.Controls.CalendarControl
    Friend WithEvents cmdFixMat As System.Windows.Forms.Button
End Class

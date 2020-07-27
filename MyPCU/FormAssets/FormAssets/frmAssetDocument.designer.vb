<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAssetDocument
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAssetDocument))
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.cmdScan = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDOC_NO = New System.Windows.Forms.TextBox()
        Me.cmdSearchID = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFile = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDETAIL = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtASSET_NAME = New System.Windows.Forms.Label()
        Me.lblASSET_CODE_ID = New System.Windows.Forms.Label()
        Me.lblAmount = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdPDF = New System.Windows.Forms.Button()
        Me.cmdDel = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.BetterListView1 = New ComponentOwl.BetterListView.BetterListView()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.cmdCalenda = New System.Windows.Forms.Button()
        Me.txtDATE_IN = New DevExpress.XtraEditors.LabelControl()
        Me.CalendarControl1 = New DevExpress.XtraEditors.Controls.CalendarControl()
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.CalendarControl1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.Location = New System.Drawing.Point(12, 353)
        Me.ListView1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(767, 296)
        Me.ListView1.TabIndex = 941
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.Visible = False
        '
        'cmdScan
        '
        Me.cmdScan.Image = Global.MyPCU.My.Resources.Resources.a_scan
        Me.cmdScan.Location = New System.Drawing.Point(643, 248)
        Me.cmdScan.Name = "cmdScan"
        Me.cmdScan.Size = New System.Drawing.Size(100, 29)
        Me.cmdScan.TabIndex = 996
        Me.cmdScan.Text = "Scan"
        Me.cmdScan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdScan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdScan.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(88, 165)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 17)
        Me.Label7.TabIndex = 995
        Me.Label7.Text = "เอกสารอ้างอิง"
        '
        'txtDOC_NO
        '
        Me.txtDOC_NO.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtDOC_NO.Location = New System.Drawing.Point(165, 161)
        Me.txtDOC_NO.Name = "txtDOC_NO"
        Me.txtDOC_NO.Size = New System.Drawing.Size(578, 23)
        Me.txtDOC_NO.TabIndex = 994
        '
        'cmdSearchID
        '
        Me.cmdSearchID.Image = Global.MyPCU.My.Resources.Resources.a_browse
        Me.cmdSearchID.Location = New System.Drawing.Point(537, 248)
        Me.cmdSearchID.Name = "cmdSearchID"
        Me.cmdSearchID.Size = New System.Drawing.Size(100, 29)
        Me.cmdSearchID.TabIndex = 992
        Me.cmdSearchID.Text = "Browse"
        Me.cmdSearchID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdSearchID.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdSearchID.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(65, 257)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 17)
        Me.Label1.TabIndex = 991
        Me.Label1.Text = "ไฟล์เอกสาร (pdf)"
        '
        'txtFile
        '
        Me.txtFile.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtFile.Location = New System.Drawing.Point(165, 254)
        Me.txtFile.Name = "txtFile"
        Me.txtFile.Size = New System.Drawing.Size(366, 23)
        Me.txtFile.TabIndex = 990
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(100, 195)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 17)
        Me.Label2.TabIndex = 989
        Me.Label2.Text = "รายละเอียด"
        '
        'txtDETAIL
        '
        Me.txtDETAIL.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtDETAIL.Location = New System.Drawing.Point(165, 192)
        Me.txtDETAIL.Multiline = True
        Me.txtDETAIL.Name = "txtDETAIL"
        Me.txtDETAIL.Size = New System.Drawing.Size(578, 44)
        Me.txtDETAIL.TabIndex = 988
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(132, 135)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 17)
        Me.Label5.TabIndex = 982
        Me.Label5.Text = "วันที่"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(55, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 17)
        Me.Label4.TabIndex = 977
        Me.Label4.Text = "รายละเอียดทรัพย์สิน"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(88, 38)
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
        Me.txtASSET_NAME.Location = New System.Drawing.Point(165, 66)
        Me.txtASSET_NAME.Name = "txtASSET_NAME"
        Me.txtASSET_NAME.Size = New System.Drawing.Size(578, 55)
        Me.txtASSET_NAME.TabIndex = 975
        '
        'lblASSET_CODE_ID
        '
        Me.lblASSET_CODE_ID.BackColor = System.Drawing.Color.Beige
        Me.lblASSET_CODE_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblASSET_CODE_ID.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblASSET_CODE_ID.Location = New System.Drawing.Point(165, 32)
        Me.lblASSET_CODE_ID.Name = "lblASSET_CODE_ID"
        Me.lblASSET_CODE_ID.Size = New System.Drawing.Size(255, 28)
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
        Me.lblAmount.Location = New System.Drawing.Point(12, 651)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAmount.Size = New System.Drawing.Size(42, 15)
        Me.lblAmount.TabIndex = 993
        Me.lblAmount.Text = "จำนวน"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 330)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(146, 15)
        Me.Label6.TabIndex = 995
        Me.Label6.Text = "รายละเอียดการบันทึกเอกสาร"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Button1.Image = Global.MyPCU.My.Resources.Resources.a_clear
        Me.Button1.Location = New System.Drawing.Point(736, 310)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(43, 35)
        Me.Button1.TabIndex = 996
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdPDF
        '
        Me.cmdPDF.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPDF.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdPDF.Image = Global.MyPCU.My.Resources.Resources._1_document
        Me.cmdPDF.Location = New System.Drawing.Point(538, 310)
        Me.cmdPDF.Name = "cmdPDF"
        Me.cmdPDF.Size = New System.Drawing.Size(95, 35)
        Me.cmdPDF.TabIndex = 994
        Me.cmdPDF.Text = "ดูเอกสาร"
        Me.cmdPDF.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdPDF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdPDF.UseVisualStyleBackColor = True
        '
        'cmdDel
        '
        Me.cmdDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDel.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdDel.Image = Global.MyPCU.My.Resources.Resources.a_minus
        Me.cmdDel.Location = New System.Drawing.Point(688, 310)
        Me.cmdDel.Name = "cmdDel"
        Me.cmdDel.Size = New System.Drawing.Size(43, 35)
        Me.cmdDel.TabIndex = 992
        Me.cmdDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdDel.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdSave.Image = Global.MyPCU.My.Resources.Resources.a_save
        Me.cmdSave.Location = New System.Drawing.Point(639, 310)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(43, 35)
        Me.cmdSave.TabIndex = 991
        Me.cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'BetterListView1
        '
        Me.BetterListView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BetterListView1.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.BetterListView1.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Sortable
        Me.BetterListView1.Location = New System.Drawing.Point(12, 353)
        Me.BetterListView1.Name = "BetterListView1"
        Me.BetterListView1.Size = New System.Drawing.Size(767, 295)
        Me.BetterListView1.TabIndex = 1143
        '
        'GroupControl1
        '
        Me.GroupControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl1.Controls.Add(Me.cmdScan)
        Me.GroupControl1.Controls.Add(Me.cmdCalenda)
        Me.GroupControl1.Controls.Add(Me.txtDATE_IN)
        Me.GroupControl1.Controls.Add(Me.cmdSearchID)
        Me.GroupControl1.Controls.Add(Me.lblASSET_CODE_ID)
        Me.GroupControl1.Controls.Add(Me.txtASSET_NAME)
        Me.GroupControl1.Controls.Add(Me.Label7)
        Me.GroupControl1.Controls.Add(Me.Label3)
        Me.GroupControl1.Controls.Add(Me.txtDOC_NO)
        Me.GroupControl1.Controls.Add(Me.Label4)
        Me.GroupControl1.Controls.Add(Me.Label5)
        Me.GroupControl1.Controls.Add(Me.Label1)
        Me.GroupControl1.Controls.Add(Me.txtDETAIL)
        Me.GroupControl1.Controls.Add(Me.txtFile)
        Me.GroupControl1.Controls.Add(Me.Label2)
        Me.GroupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Card
        Me.GroupControl1.Location = New System.Drawing.Point(12, 12)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(767, 292)
        Me.GroupControl1.TabIndex = 1144
        Me.GroupControl1.Text = "บันทึกเอกสาร"
        '
        'cmdCalenda
        '
        Me.cmdCalenda.Image = Global.MyPCU.My.Resources.Resources.a_calendar
        Me.cmdCalenda.Location = New System.Drawing.Point(296, 130)
        Me.cmdCalenda.Name = "cmdCalenda"
        Me.cmdCalenda.Size = New System.Drawing.Size(33, 26)
        Me.cmdCalenda.TabIndex = 1169
        Me.cmdCalenda.UseVisualStyleBackColor = True
        '
        'txtDATE_IN
        '
        Me.txtDATE_IN.Appearance.BackColor = System.Drawing.Color.Beige
        Me.txtDATE_IN.Appearance.Options.UseBackColor = True
        Me.txtDATE_IN.Appearance.Options.UseTextOptions = True
        Me.txtDATE_IN.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtDATE_IN.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.txtDATE_IN.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtDATE_IN.Location = New System.Drawing.Point(165, 130)
        Me.txtDATE_IN.Name = "txtDATE_IN"
        Me.txtDATE_IN.Size = New System.Drawing.Size(128, 24)
        Me.txtDATE_IN.TabIndex = 1170
        '
        'CalendarControl1
        '
        Me.CalendarControl1.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CalendarControl1.DateTime = New Date(2019, 10, 11, 0, 0, 0, 0)
        Me.CalendarControl1.EditValue = New Date(2019, 10, 11, 0, 0, 0, 0)
        Me.CalendarControl1.Location = New System.Drawing.Point(177, 167)
        Me.CalendarControl1.Name = "CalendarControl1"
        Me.CalendarControl1.Size = New System.Drawing.Size(232, 267)
        Me.CalendarControl1.TabIndex = 1171
        '
        'frmAssetDocument
        '
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(791, 676)
        Me.Controls.Add(Me.CalendarControl1)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.BetterListView1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmdPDF)
        Me.Controls.Add(Me.lblAmount)
        Me.Controls.Add(Me.cmdDel)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.ListView1)
        Me.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmAssetDocument"
        Me.ShowInTaskbar = False
        Me.Text = "เอกสารที่เกี่ยวข้อง"
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.CalendarControl1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents txtASSET_NAME As System.Windows.Forms.Label
    Friend WithEvents lblASSET_CODE_ID As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFile As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDETAIL As System.Windows.Forms.TextBox
    Friend WithEvents cmdSearchID As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdDel As System.Windows.Forms.Button
    Public WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents cmdPDF As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDOC_NO As System.Windows.Forms.TextBox
    Friend WithEvents cmdScan As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents BetterListView1 As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents cmdCalenda As System.Windows.Forms.Button
    Friend WithEvents txtDATE_IN As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CalendarControl1 As DevExpress.XtraEditors.Controls.CalendarControl
End Class

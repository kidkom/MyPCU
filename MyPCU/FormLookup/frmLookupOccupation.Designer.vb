<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLookupOccupation
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLookupOccupation))
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.cboOccupationDescOld = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblOccupationCodeOld = New DevExpress.XtraEditors.LabelControl()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkStatus = New System.Windows.Forms.CheckBox()
        Me.cboOccupationDescNew = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblOccupationCodeNew = New DevExpress.XtraEditors.LabelControl()
        Me.txtOccupation = New DevExpress.XtraEditors.TextEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.cmdUpdateOldToNew = New System.Windows.Forms.Button()
        Me.chkCancel = New System.Windows.Forms.CheckBox()
        Me.chkUseOnly = New System.Windows.Forms.CheckBox()
        Me.chkAll = New System.Windows.Forms.CheckBox()
        Me.lblTotalRow = New System.Windows.Forms.Label()
        Me.BetterListView1 = New ComponentOwl.BetterListView.BetterListView()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.MyPCU.WaitForm1), True, True)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.cboOccupationDescOld.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboOccupationDescNew.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOccupation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl1.Controls.Add(Me.cboOccupationDescOld)
        Me.GroupControl1.Controls.Add(Me.lblOccupationCodeOld)
        Me.GroupControl1.Controls.Add(Me.Label2)
        Me.GroupControl1.Controls.Add(Me.chkStatus)
        Me.GroupControl1.Controls.Add(Me.cboOccupationDescNew)
        Me.GroupControl1.Controls.Add(Me.lblOccupationCodeNew)
        Me.GroupControl1.Controls.Add(Me.txtOccupation)
        Me.GroupControl1.Controls.Add(Me.Label4)
        Me.GroupControl1.Controls.Add(Me.Label1)
        Me.GroupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Card
        Me.GroupControl1.Location = New System.Drawing.Point(12, 12)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(884, 175)
        Me.GroupControl1.TabIndex = 1110
        Me.GroupControl1.Text = "กำหนดรหัสอาชีพ"
        '
        'cboOccupationDescOld
        '
        Me.cboOccupationDescOld.Location = New System.Drawing.Point(200, 78)
        Me.cboOccupationDescOld.Name = "cboOccupationDescOld"
        Me.cboOccupationDescOld.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboOccupationDescOld.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.cboOccupationDescOld.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboOccupationDescOld.Size = New System.Drawing.Size(389, 24)
        Me.cboOccupationDescOld.TabIndex = 1107
        '
        'lblOccupationCodeOld
        '
        Me.lblOccupationCodeOld.Appearance.BackColor = System.Drawing.Color.Beige
        Me.lblOccupationCodeOld.Appearance.Options.UseBackColor = True
        Me.lblOccupationCodeOld.Appearance.Options.UseTextOptions = True
        Me.lblOccupationCodeOld.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lblOccupationCodeOld.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblOccupationCodeOld.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.lblOccupationCodeOld.Location = New System.Drawing.Point(131, 78)
        Me.lblOccupationCodeOld.Name = "lblOccupationCodeOld"
        Me.lblOccupationCodeOld.Size = New System.Drawing.Size(63, 25)
        Me.lblOccupationCodeOld.TabIndex = 1106
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 17)
        Me.Label2.TabIndex = 1105
        Me.Label2.Text = "รหัสมาตรฐาน เดิม"
        '
        'chkStatus
        '
        Me.chkStatus.AutoSize = True
        Me.chkStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.chkStatus.Location = New System.Drawing.Point(131, 145)
        Me.chkStatus.Name = "chkStatus"
        Me.chkStatus.Size = New System.Drawing.Size(58, 21)
        Me.chkStatus.TabIndex = 1104
        Me.chkStatus.Text = "ยกเลิก"
        Me.chkStatus.UseVisualStyleBackColor = True
        '
        'cboOccupationDescNew
        '
        Me.cboOccupationDescNew.Location = New System.Drawing.Point(200, 111)
        Me.cboOccupationDescNew.Name = "cboOccupationDescNew"
        Me.cboOccupationDescNew.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboOccupationDescNew.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.cboOccupationDescNew.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboOccupationDescNew.Size = New System.Drawing.Size(389, 24)
        Me.cboOccupationDescNew.TabIndex = 10
        '
        'lblOccupationCodeNew
        '
        Me.lblOccupationCodeNew.Appearance.BackColor = System.Drawing.Color.Beige
        Me.lblOccupationCodeNew.Appearance.Options.UseBackColor = True
        Me.lblOccupationCodeNew.Appearance.Options.UseTextOptions = True
        Me.lblOccupationCodeNew.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lblOccupationCodeNew.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblOccupationCodeNew.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.lblOccupationCodeNew.Location = New System.Drawing.Point(131, 111)
        Me.lblOccupationCodeNew.Name = "lblOccupationCodeNew"
        Me.lblOccupationCodeNew.Size = New System.Drawing.Size(63, 25)
        Me.lblOccupationCodeNew.TabIndex = 9
        '
        'txtOccupation
        '
        Me.txtOccupation.Location = New System.Drawing.Point(131, 44)
        Me.txtOccupation.Name = "txtOccupation"
        Me.txtOccupation.Properties.Appearance.Options.UseTextOptions = True
        Me.txtOccupation.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtOccupation.Size = New System.Drawing.Size(458, 24)
        Me.txtOccupation.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(26, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 17)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "รหัสมาตรฐาน ใหม่"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(87, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "อาชีพ"
        '
        'cmdSave
        '
        Me.cmdSave.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdSave.Image = Global.MyPCU.My.Resources.Resources.a_save
        Me.cmdSave.Location = New System.Drawing.Point(854, 204)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(43, 32)
        Me.cmdSave.TabIndex = 1123
        Me.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        Me.cmdAdd.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdAdd.Image = Global.MyPCU.My.Resources.Resources.a_add
        Me.cmdAdd.Location = New System.Drawing.Point(805, 204)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(43, 32)
        Me.cmdAdd.TabIndex = 1122
        Me.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'cmdUpdateOldToNew
        '
        Me.cmdUpdateOldToNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateOldToNew.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdUpdateOldToNew.Image = Global.MyPCU.My.Resources.Resources.a_refresh
        Me.cmdUpdateOldToNew.Location = New System.Drawing.Point(784, 648)
        Me.cmdUpdateOldToNew.Name = "cmdUpdateOldToNew"
        Me.cmdUpdateOldToNew.Size = New System.Drawing.Size(112, 32)
        Me.cmdUpdateOldToNew.TabIndex = 1121
        Me.cmdUpdateOldToNew.Text = "ปรับปรุงรหัสเดิม"
        Me.cmdUpdateOldToNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdUpdateOldToNew.UseVisualStyleBackColor = True
        '
        'chkCancel
        '
        Me.chkCancel.AutoSize = True
        Me.chkCancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.chkCancel.Location = New System.Drawing.Point(99, 209)
        Me.chkCancel.Name = "chkCancel"
        Me.chkCancel.Size = New System.Drawing.Size(58, 21)
        Me.chkCancel.TabIndex = 1120
        Me.chkCancel.Text = "ยกเลิก"
        Me.chkCancel.UseVisualStyleBackColor = True
        '
        'chkUseOnly
        '
        Me.chkUseOnly.AutoSize = True
        Me.chkUseOnly.Checked = True
        Me.chkUseOnly.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUseOnly.Location = New System.Drawing.Point(15, 209)
        Me.chkUseOnly.Name = "chkUseOnly"
        Me.chkUseOnly.Size = New System.Drawing.Size(78, 21)
        Me.chkUseOnly.TabIndex = 1119
        Me.chkUseOnly.Text = "เฉพาะที่ใช้"
        Me.chkUseOnly.UseVisualStyleBackColor = True
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.Location = New System.Drawing.Point(163, 209)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(62, 21)
        Me.chkAll.TabIndex = 1118
        Me.chkAll.Text = "ทั้งหมด"
        Me.chkAll.UseVisualStyleBackColor = True
        '
        'lblTotalRow
        '
        Me.lblTotalRow.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalRow.AutoSize = True
        Me.lblTotalRow.Location = New System.Drawing.Point(12, 656)
        Me.lblTotalRow.Name = "lblTotalRow"
        Me.lblTotalRow.Size = New System.Drawing.Size(43, 17)
        Me.lblTotalRow.TabIndex = 1116
        Me.lblTotalRow.Text = "จำนวน"
        '
        'BetterListView1
        '
        Me.BetterListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BetterListView1.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.BetterListView1.Location = New System.Drawing.Point(12, 242)
        Me.BetterListView1.Name = "BetterListView1"
        Me.BetterListView1.Size = New System.Drawing.Size(884, 400)
        Me.BetterListView1.TabIndex = 1117
        '
        'Timer1
        '
        '
        'SplashScreenManager1
        '
        Me.SplashScreenManager1.ClosingDelay = 500
        '
        'frmLookupOccupation
        '
        Me.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(908, 690)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.BetterListView1)
        Me.Controls.Add(Me.cmdUpdateOldToNew)
        Me.Controls.Add(Me.lblTotalRow)
        Me.Controls.Add(Me.chkCancel)
        Me.Controls.Add(Me.chkAll)
        Me.Controls.Add(Me.chkUseOnly)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmLookupOccupation"
        Me.Text = "กำหนดรหัสอาชีพ"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.cboOccupationDescOld.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboOccupationDescNew.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOccupation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents cboOccupationDescOld As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblOccupationCodeOld As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label2 As Label
    Friend WithEvents chkStatus As CheckBox
    Friend WithEvents cboOccupationDescNew As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblOccupationCodeNew As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtOccupation As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmdSave As Button
    Friend WithEvents cmdAdd As Button
    Friend WithEvents cmdUpdateOldToNew As Button
    Friend WithEvents chkCancel As CheckBox
    Friend WithEvents chkUseOnly As CheckBox
    Friend WithEvents chkAll As CheckBox
    Friend WithEvents lblTotalRow As Label
    Friend WithEvents BetterListView1 As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents Timer1 As Timer
    Friend WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
End Class

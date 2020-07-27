<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLookupEducation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLookupEducation))
        Me.cmdSearchCouple = New System.Windows.Forms.Button()
        Me.lblTotalRow = New System.Windows.Forms.Label()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.chkCancel = New System.Windows.Forms.CheckBox()
        Me.chkUseOnly = New System.Windows.Forms.CheckBox()
        Me.chkAll = New System.Windows.Forms.CheckBox()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.chkStatus = New System.Windows.Forms.CheckBox()
        Me.cboEducation = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblEducationCode = New DevExpress.XtraEditors.LabelControl()
        Me.txtEducation = New DevExpress.XtraEditors.TextEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BetterListView1 = New ComponentOwl.BetterListView.BetterListView()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.MyPCU.WaitForm1), True, True)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.cboEducation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEducation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdSearchCouple
        '
        Me.cmdSearchCouple.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSearchCouple.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdSearchCouple.Image = Global.MyPCU.My.Resources.Resources.a_refresh
        Me.cmdSearchCouple.Location = New System.Drawing.Point(596, 647)
        Me.cmdSearchCouple.Name = "cmdSearchCouple"
        Me.cmdSearchCouple.Size = New System.Drawing.Size(112, 32)
        Me.cmdSearchCouple.TabIndex = 1133
        Me.cmdSearchCouple.Text = "ปรับปรุงรหัสเดิม"
        Me.cmdSearchCouple.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdSearchCouple.UseVisualStyleBackColor = True
        Me.cmdSearchCouple.Visible = False
        '
        'lblTotalRow
        '
        Me.lblTotalRow.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalRow.AutoSize = True
        Me.lblTotalRow.Location = New System.Drawing.Point(12, 653)
        Me.lblTotalRow.Name = "lblTotalRow"
        Me.lblTotalRow.Size = New System.Drawing.Size(43, 17)
        Me.lblTotalRow.TabIndex = 1132
        Me.lblTotalRow.Text = "จำนวน"
        '
        'cmdSave
        '
        Me.cmdSave.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdSave.Image = Global.MyPCU.My.Resources.Resources.a_save
        Me.cmdSave.Location = New System.Drawing.Point(665, 201)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(43, 32)
        Me.cmdSave.TabIndex = 1131
        Me.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        Me.cmdAdd.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdAdd.Image = Global.MyPCU.My.Resources.Resources.a_add
        Me.cmdAdd.Location = New System.Drawing.Point(616, 201)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(43, 32)
        Me.cmdAdd.TabIndex = 1130
        Me.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'chkCancel
        '
        Me.chkCancel.AutoSize = True
        Me.chkCancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.chkCancel.Location = New System.Drawing.Point(99, 208)
        Me.chkCancel.Name = "chkCancel"
        Me.chkCancel.Size = New System.Drawing.Size(58, 21)
        Me.chkCancel.TabIndex = 1129
        Me.chkCancel.Text = "ยกเลิก"
        Me.chkCancel.UseVisualStyleBackColor = True
        '
        'chkUseOnly
        '
        Me.chkUseOnly.AutoSize = True
        Me.chkUseOnly.Checked = True
        Me.chkUseOnly.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUseOnly.Location = New System.Drawing.Point(15, 208)
        Me.chkUseOnly.Name = "chkUseOnly"
        Me.chkUseOnly.Size = New System.Drawing.Size(78, 21)
        Me.chkUseOnly.TabIndex = 1128
        Me.chkUseOnly.Text = "เฉพาะที่ใช้"
        Me.chkUseOnly.UseVisualStyleBackColor = True
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.Location = New System.Drawing.Point(163, 208)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(62, 21)
        Me.chkAll.TabIndex = 1127
        Me.chkAll.Text = "ทั้งหมด"
        Me.chkAll.UseVisualStyleBackColor = True
        '
        'GroupControl1
        '
        Me.GroupControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl1.Controls.Add(Me.chkStatus)
        Me.GroupControl1.Controls.Add(Me.cboEducation)
        Me.GroupControl1.Controls.Add(Me.lblEducationCode)
        Me.GroupControl1.Controls.Add(Me.txtEducation)
        Me.GroupControl1.Controls.Add(Me.Label4)
        Me.GroupControl1.Controls.Add(Me.Label1)
        Me.GroupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Card
        Me.GroupControl1.Location = New System.Drawing.Point(12, 12)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(696, 175)
        Me.GroupControl1.TabIndex = 1126
        Me.GroupControl1.Text = "กำหนดรหัสการศึกษา"
        '
        'chkStatus
        '
        Me.chkStatus.AutoSize = True
        Me.chkStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.chkStatus.Location = New System.Drawing.Point(129, 120)
        Me.chkStatus.Name = "chkStatus"
        Me.chkStatus.Size = New System.Drawing.Size(58, 21)
        Me.chkStatus.TabIndex = 1104
        Me.chkStatus.Text = "ยกเลิก"
        Me.chkStatus.UseVisualStyleBackColor = True
        '
        'cboEducation
        '
        Me.cboEducation.Location = New System.Drawing.Point(198, 80)
        Me.cboEducation.Name = "cboEducation"
        Me.cboEducation.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboEducation.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.cboEducation.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboEducation.Size = New System.Drawing.Size(389, 24)
        Me.cboEducation.TabIndex = 10
        '
        'lblEducationCode
        '
        Me.lblEducationCode.Appearance.BackColor = System.Drawing.Color.Beige
        Me.lblEducationCode.Appearance.Options.UseBackColor = True
        Me.lblEducationCode.Appearance.Options.UseTextOptions = True
        Me.lblEducationCode.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lblEducationCode.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblEducationCode.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.lblEducationCode.Location = New System.Drawing.Point(129, 79)
        Me.lblEducationCode.Name = "lblEducationCode"
        Me.lblEducationCode.Size = New System.Drawing.Size(63, 25)
        Me.lblEducationCode.TabIndex = 9
        '
        'txtEducation
        '
        Me.txtEducation.Location = New System.Drawing.Point(131, 44)
        Me.txtEducation.Name = "txtEducation"
        Me.txtEducation.Properties.Appearance.Options.UseTextOptions = True
        Me.txtEducation.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtEducation.Size = New System.Drawing.Size(458, 24)
        Me.txtEducation.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 17)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "รหัสมาตรฐาน"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(52, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "การศึกษา"
        '
        'BetterListView1
        '
        Me.BetterListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BetterListView1.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.BetterListView1.Location = New System.Drawing.Point(12, 241)
        Me.BetterListView1.Name = "BetterListView1"
        Me.BetterListView1.Size = New System.Drawing.Size(696, 400)
        Me.BetterListView1.TabIndex = 1125
        '
        'Timer1
        '
        '
        'SplashScreenManager1
        '
        Me.SplashScreenManager1.ClosingDelay = 500
        '
        'frmLookupEducation
        '
        Me.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(720, 690)
        Me.Controls.Add(Me.cmdSearchCouple)
        Me.Controls.Add(Me.lblTotalRow)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.chkCancel)
        Me.Controls.Add(Me.chkUseOnly)
        Me.Controls.Add(Me.chkAll)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.BetterListView1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmLookupEducation"
        Me.Text = "ตารางรหัสการศึกษา"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.cboEducation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEducation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdSearchCouple As Button
    Friend WithEvents lblTotalRow As Label
    Friend WithEvents cmdSave As Button
    Friend WithEvents cmdAdd As Button
    Friend WithEvents chkCancel As CheckBox
    Friend WithEvents chkUseOnly As CheckBox
    Friend WithEvents chkAll As CheckBox
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents chkStatus As CheckBox
    Friend WithEvents cboEducation As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblEducationCode As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtEducation As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents BetterListView1 As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents Timer1 As Timer
    Friend WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
End Class

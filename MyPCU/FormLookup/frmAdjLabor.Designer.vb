﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdjLabor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAdjLabor))
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chk1 = New System.Windows.Forms.CheckBox()
        Me.chkAll = New System.Windows.Forms.CheckBox()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.btnLookup = New System.Windows.Forms.Button()
        Me.lblLaborOld = New DevExpress.XtraEditors.LabelControl()
        Me.cboLabor = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblLabor = New DevExpress.XtraEditors.LabelControl()
        Me.txtLaborOld = New DevExpress.XtraEditors.TextEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chk0 = New System.Windows.Forms.CheckBox()
        Me.BetterListView1 = New ComponentOwl.BetterListView.BetterListView()
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.MyPCU.WaitForm1), True, True)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.cboLabor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLaborOld.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdSave.Image = Global.MyPCU.My.Resources.Resources.a_save
        Me.cmdSave.Location = New System.Drawing.Point(641, 129)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(43, 32)
        Me.cmdSave.TabIndex = 1153
        Me.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 558)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 17)
        Me.Label5.TabIndex = 1152
        Me.Label5.Text = "จำนวน"
        '
        'chk1
        '
        Me.chk1.AutoSize = True
        Me.chk1.ForeColor = System.Drawing.Color.Black
        Me.chk1.Location = New System.Drawing.Point(94, 135)
        Me.chk1.Name = "chk1"
        Me.chk1.Size = New System.Drawing.Size(66, 21)
        Me.chk1.TabIndex = 1151
        Me.chk1.Text = "ปรับแล้ว"
        Me.chk1.UseVisualStyleBackColor = True
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.Location = New System.Drawing.Point(175, 135)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(62, 21)
        Me.chkAll.TabIndex = 1150
        Me.chkAll.Text = "ทั้งหมด"
        Me.chkAll.UseVisualStyleBackColor = True
        '
        'GroupControl1
        '
        Me.GroupControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl1.Controls.Add(Me.btnLookup)
        Me.GroupControl1.Controls.Add(Me.lblLaborOld)
        Me.GroupControl1.Controls.Add(Me.cboLabor)
        Me.GroupControl1.Controls.Add(Me.lblLabor)
        Me.GroupControl1.Controls.Add(Me.txtLaborOld)
        Me.GroupControl1.Controls.Add(Me.Label4)
        Me.GroupControl1.Controls.Add(Me.Label1)
        Me.GroupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Card
        Me.GroupControl1.Location = New System.Drawing.Point(12, 8)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(672, 115)
        Me.GroupControl1.TabIndex = 1149
        Me.GroupControl1.Text = "กำหนดรหัสต่างด้าว"
        '
        'btnLookup
        '
        Me.btnLookup.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnLookup.Image = Global.MyPCU.My.Resources.Resources.a_add
        Me.btnLookup.Location = New System.Drawing.Point(595, 73)
        Me.btnLookup.Name = "btnLookup"
        Me.btnLookup.Size = New System.Drawing.Size(37, 28)
        Me.btnLookup.TabIndex = 1112
        Me.btnLookup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLookup.UseVisualStyleBackColor = True
        '
        'lblLaborOld
        '
        Me.lblLaborOld.Appearance.BackColor = System.Drawing.Color.Beige
        Me.lblLaborOld.Appearance.Options.UseBackColor = True
        Me.lblLaborOld.Appearance.Options.UseTextOptions = True
        Me.lblLaborOld.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lblLaborOld.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblLaborOld.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.lblLaborOld.Location = New System.Drawing.Point(131, 43)
        Me.lblLaborOld.Name = "lblLaborOld"
        Me.lblLaborOld.Size = New System.Drawing.Size(63, 25)
        Me.lblLaborOld.TabIndex = 1105
        '
        'cboLabor
        '
        Me.cboLabor.Location = New System.Drawing.Point(200, 75)
        Me.cboLabor.Name = "cboLabor"
        Me.cboLabor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboLabor.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboLabor.Size = New System.Drawing.Size(389, 24)
        Me.cboLabor.TabIndex = 10
        '
        'lblLabor
        '
        Me.lblLabor.Appearance.BackColor = System.Drawing.Color.Beige
        Me.lblLabor.Appearance.Options.UseBackColor = True
        Me.lblLabor.Appearance.Options.UseTextOptions = True
        Me.lblLabor.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lblLabor.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblLabor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.lblLabor.Location = New System.Drawing.Point(131, 75)
        Me.lblLabor.Name = "lblLabor"
        Me.lblLabor.Size = New System.Drawing.Size(63, 25)
        Me.lblLabor.TabIndex = 9
        '
        'txtLaborOld
        '
        Me.txtLaborOld.Location = New System.Drawing.Point(200, 43)
        Me.txtLaborOld.Name = "txtLaborOld"
        Me.txtLaborOld.Properties.Appearance.Options.UseTextOptions = True
        Me.txtLaborOld.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtLaborOld.Size = New System.Drawing.Size(389, 24)
        Me.txtLaborOld.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(60, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 17)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "รหัสปัจจุบัน"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(79, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "รหัสเดิม"
        '
        'chk0
        '
        Me.chk0.AutoSize = True
        Me.chk0.Checked = True
        Me.chk0.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.chk0.Location = New System.Drawing.Point(12, 135)
        Me.chk0.Name = "chk0"
        Me.chk0.Size = New System.Drawing.Size(69, 21)
        Me.chk0.TabIndex = 1148
        Me.chk0.Text = "ยังไม่ปรับ"
        Me.chk0.UseVisualStyleBackColor = True
        '
        'BetterListView1
        '
        Me.BetterListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BetterListView1.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.BetterListView1.Location = New System.Drawing.Point(12, 166)
        Me.BetterListView1.Name = "BetterListView1"
        Me.BetterListView1.Size = New System.Drawing.Size(672, 389)
        Me.BetterListView1.TabIndex = 1147
        '
        'SplashScreenManager1
        '
        Me.SplashScreenManager1.ClosingDelay = 500
        '
        'frmAdjLabor
        '
        Me.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(696, 582)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.chk1)
        Me.Controls.Add(Me.chkAll)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.chk0)
        Me.Controls.Add(Me.BetterListView1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAdjLabor"
        Me.Text = "การปรับปรุงรหัสต่างด้าวเดิม"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.cboLabor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLaborOld.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdSave As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents chk1 As CheckBox
    Friend WithEvents chkAll As CheckBox
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btnLookup As Button
    Friend WithEvents lblLaborOld As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboLabor As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblLabor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtLaborOld As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents chk0 As CheckBox
    Friend WithEvents BetterListView1 As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
End Class

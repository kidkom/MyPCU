<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfigPicture
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfigPicture))
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.optPic3 = New System.Windows.Forms.CheckBox()
        Me.optPic1 = New System.Windows.Forms.CheckBox()
        Me.optPic2 = New System.Windows.Forms.CheckBox()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.cmdImportData = New System.Windows.Forms.Button()
        Me.ProgressBarControl1 = New DevExpress.XtraEditors.ProgressBarControl()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtPic = New System.Windows.Forms.TextBox()
        Me.XtraFolderBrowserDialog1 = New DevExpress.XtraEditors.XtraFolderBrowserDialog(Me.components)
        Me.cmdApply = New System.Windows.Forms.Button()
        Me.cmdCancle = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.MyPCU.WaitForm1), True, True)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.optPic3)
        Me.GroupControl1.Controls.Add(Me.optPic1)
        Me.GroupControl1.Controls.Add(Me.optPic2)
        Me.GroupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Card
        Me.GroupControl1.Location = New System.Drawing.Point(12, 12)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(599, 133)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "กำหนดระบบเก็บไฟล์ภาพ"
        '
        'optPic3
        '
        Me.optPic3.AutoSize = True
        Me.optPic3.Location = New System.Drawing.Point(29, 88)
        Me.optPic3.Name = "optPic3"
        Me.optPic3.Size = New System.Drawing.Size(266, 21)
        Me.optPic3.TabIndex = 3
        Me.optPic3.Text = "ใช้ 2 ระบบ เก็บในฐานข้อมูล/เก็บแบบแชร์โฟลเดอร์"
        Me.optPic3.UseVisualStyleBackColor = True
        '
        'optPic1
        '
        Me.optPic1.AutoSize = True
        Me.optPic1.Location = New System.Drawing.Point(29, 34)
        Me.optPic1.Name = "optPic1"
        Me.optPic1.Size = New System.Drawing.Size(104, 21)
        Me.optPic1.TabIndex = 1
        Me.optPic1.Text = "เก็บในฐานข้อมูล"
        Me.optPic1.UseVisualStyleBackColor = True
        '
        'optPic2
        '
        Me.optPic2.AutoSize = True
        Me.optPic2.Location = New System.Drawing.Point(29, 61)
        Me.optPic2.Name = "optPic2"
        Me.optPic2.Size = New System.Drawing.Size(128, 21)
        Me.optPic2.TabIndex = 2
        Me.optPic2.Text = "เก็บแบบแชร์โฟลเดอร์"
        Me.optPic2.UseVisualStyleBackColor = True
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.cmdImportData)
        Me.GroupControl2.Controls.Add(Me.ProgressBarControl1)
        Me.GroupControl2.GroupStyle = DevExpress.Utils.GroupStyle.Card
        Me.GroupControl2.Location = New System.Drawing.Point(12, 151)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(599, 91)
        Me.GroupControl2.TabIndex = 10
        Me.GroupControl2.Text = "ปรับโอนรูปเข้าฐานข้อมูล"
        '
        'cmdImportData
        '
        Me.cmdImportData.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdImportData.Image = Global.MyPCU.My.Resources.Resources.a_play
        Me.cmdImportData.Location = New System.Drawing.Point(490, 36)
        Me.cmdImportData.Name = "cmdImportData"
        Me.cmdImportData.Size = New System.Drawing.Size(92, 30)
        Me.cmdImportData.TabIndex = 11
        Me.cmdImportData.Text = "ดำเนินการ"
        Me.cmdImportData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdImportData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdImportData.UseVisualStyleBackColor = True
        '
        'ProgressBarControl1
        '
        Me.ProgressBarControl1.Location = New System.Drawing.Point(29, 42)
        Me.ProgressBarControl1.Name = "ProgressBarControl1"
        Me.ProgressBarControl1.Size = New System.Drawing.Size(431, 18)
        Me.ProgressBarControl1.TabIndex = 0
        '
        'GroupControl3
        '
        Me.GroupControl3.Controls.Add(Me.Button2)
        Me.GroupControl3.Controls.Add(Me.Label33)
        Me.GroupControl3.Controls.Add(Me.txtPic)
        Me.GroupControl3.GroupStyle = DevExpress.Utils.GroupStyle.Card
        Me.GroupControl3.Location = New System.Drawing.Point(12, 248)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(599, 100)
        Me.GroupControl3.TabIndex = 11
        Me.GroupControl3.Text = "กำหนดที่ตั้งโฟลเดอร์ไฟล์ภภาพ"
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Image = Global.MyPCU.My.Resources.Resources.a_folder_open
        Me.Button2.Location = New System.Drawing.Point(490, 48)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(92, 30)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "Browse"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(29, 34)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(115, 17)
        Me.Label33.TabIndex = 830
        Me.Label33.Text = "ตำแหน่งที่เก็บไฟล์ภาพ"
        '
        'txtPic
        '
        Me.txtPic.Location = New System.Drawing.Point(29, 52)
        Me.txtPic.Name = "txtPic"
        Me.txtPic.Size = New System.Drawing.Size(431, 25)
        Me.txtPic.TabIndex = 829
        '
        'XtraFolderBrowserDialog1
        '
        Me.XtraFolderBrowserDialog1.SelectedPath = "XtraFolderBrowserDialog1"
        '
        'cmdApply
        '
        Me.cmdApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdApply.Image = Global.MyPCU.My.Resources.Resources.a_check3
        Me.cmdApply.Location = New System.Drawing.Point(421, 361)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(92, 30)
        Me.cmdApply.TabIndex = 9
        Me.cmdApply.Text = "Apply"
        Me.cmdApply.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdApply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'cmdCancle
        '
        Me.cmdCancle.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancle.Image = Global.MyPCU.My.Resources.Resources.a_cancle
        Me.cmdCancle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancle.Location = New System.Drawing.Point(519, 361)
        Me.cmdCancle.Name = "cmdCancle"
        Me.cmdCancle.Size = New System.Drawing.Size(92, 30)
        Me.cmdCancle.TabIndex = 8
        Me.cmdCancle.Text = "Cancel"
        Me.cmdCancle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdCancle.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOK.Image = Global.MyPCU.My.Resources.Resources.a_save
        Me.cmdOK.Location = New System.Drawing.Point(323, 361)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(92, 30)
        Me.cmdOK.TabIndex = 7
        Me.cmdOK.Text = "OK"
        Me.cmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'SplashScreenManager1
        '
        Me.SplashScreenManager1.ClosingDelay = 500
        '
        'frmConfigPicture
        '
        Me.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(623, 403)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.cmdCancle)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.GroupControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConfigPicture"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "กำหนดระบบเก็บไฟล์ภาพ"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        Me.GroupControl3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents optPic3 As System.Windows.Forms.CheckBox
    Friend WithEvents optPic1 As System.Windows.Forms.CheckBox
    Friend WithEvents optPic2 As System.Windows.Forms.CheckBox
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents cmdCancle As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents cmdImportData As System.Windows.Forms.Button
    Friend WithEvents ProgressBarControl1 As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtPic As System.Windows.Forms.TextBox
    Friend WithEvents XtraFolderBrowserDialog1 As DevExpress.XtraEditors.XtraFolderBrowserDialog
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
End Class

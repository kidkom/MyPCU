<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportTMT
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportTMT))
        Me.cmdBrowse = New System.Windows.Forms.Button()
        Me.txtFilename = New System.Windows.Forms.TextBox()
        Me.cmdImport = New System.Windows.Forms.Button()
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.MyPCU.WaitForm1), True, True)
        Me.ProgressBarControl1 = New DevExpress.XtraEditors.ProgressBarControl()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.ProgressBarControl2 = New DevExpress.XtraEditors.ProgressBarControl()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.ProgressBarControl3 = New DevExpress.XtraEditors.ProgressBarControl()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.ProgressBarControl4 = New DevExpress.XtraEditors.ProgressBarControl()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.ProgressBarControl5 = New DevExpress.XtraEditors.ProgressBarControl()
        Me.CheckBox6 = New System.Windows.Forms.CheckBox()
        Me.ProgressBarControl6 = New DevExpress.XtraEditors.ProgressBarControl()
        Me.chkAll = New System.Windows.Forms.CheckBox()
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProgressBarControl2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProgressBarControl3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProgressBarControl4.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProgressBarControl5.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProgressBarControl6.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdBrowse
        '
        Me.cmdBrowse.Image = Global.MyPCU.My.Resources.Resources.a_search
        Me.cmdBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdBrowse.Location = New System.Drawing.Point(459, 45)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.Size = New System.Drawing.Size(87, 25)
        Me.cmdBrowse.TabIndex = 32
        Me.cmdBrowse.Text = "Browse"
        Me.cmdBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdBrowse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdBrowse.UseVisualStyleBackColor = True
        '
        'txtFilename
        '
        Me.txtFilename.Location = New System.Drawing.Point(34, 45)
        Me.txtFilename.Name = "txtFilename"
        Me.txtFilename.Size = New System.Drawing.Size(419, 25)
        Me.txtFilename.TabIndex = 31
        '
        'cmdImport
        '
        Me.cmdImport.Image = Global.MyPCU.My.Resources.Resources.a_imports3
        Me.cmdImport.Location = New System.Drawing.Point(552, 45)
        Me.cmdImport.Name = "cmdImport"
        Me.cmdImport.Size = New System.Drawing.Size(87, 25)
        Me.cmdImport.TabIndex = 352
        Me.cmdImport.Text = "นำเข้า"
        Me.cmdImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdImport.UseVisualStyleBackColor = True
        '
        'SplashScreenManager1
        '
        Me.SplashScreenManager1.ClosingDelay = 500
        '
        'ProgressBarControl1
        '
        Me.ProgressBarControl1.Location = New System.Drawing.Point(34, 147)
        Me.ProgressBarControl1.Name = "ProgressBarControl1"
        Me.ProgressBarControl1.Size = New System.Drawing.Size(605, 18)
        Me.ProgressBarControl1.TabIndex = 1194
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(31, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 17)
        Me.Label4.TabIndex = 1195
        Me.Label4.Text = "เลือกไฟล์นำเข้า"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(34, 120)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(84, 21)
        Me.CheckBox1.TabIndex = 1197
        Me.CheckBox1.Text = "TMT FULL"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(34, 297)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(43, 21)
        Me.CheckBox2.TabIndex = 1199
        Me.CheckBox2.Text = "GP"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'ProgressBarControl2
        '
        Me.ProgressBarControl2.Location = New System.Drawing.Point(34, 324)
        Me.ProgressBarControl2.Name = "ProgressBarControl2"
        Me.ProgressBarControl2.Size = New System.Drawing.Size(605, 18)
        Me.ProgressBarControl2.TabIndex = 1198
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(34, 177)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(97, 21)
        Me.CheckBox3.TabIndex = 1201
        Me.CheckBox3.Text = "SUBSTANCE"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'ProgressBarControl3
        '
        Me.ProgressBarControl3.Location = New System.Drawing.Point(34, 204)
        Me.ProgressBarControl3.Name = "ProgressBarControl3"
        Me.ProgressBarControl3.Size = New System.Drawing.Size(605, 18)
        Me.ProgressBarControl3.TabIndex = 1200
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Location = New System.Drawing.Point(34, 235)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(54, 21)
        Me.CheckBox4.TabIndex = 1203
        Me.CheckBox4.Text = "VTM"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'ProgressBarControl4
        '
        Me.ProgressBarControl4.Location = New System.Drawing.Point(34, 262)
        Me.ProgressBarControl4.Name = "ProgressBarControl4"
        Me.ProgressBarControl4.Size = New System.Drawing.Size(605, 18)
        Me.ProgressBarControl4.TabIndex = 1202
        '
        'CheckBox5
        '
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.Location = New System.Drawing.Point(34, 358)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(52, 21)
        Me.CheckBox5.TabIndex = 1205
        Me.CheckBox5.Text = "GPU"
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'ProgressBarControl5
        '
        Me.ProgressBarControl5.Location = New System.Drawing.Point(34, 385)
        Me.ProgressBarControl5.Name = "ProgressBarControl5"
        Me.ProgressBarControl5.Size = New System.Drawing.Size(605, 18)
        Me.ProgressBarControl5.TabIndex = 1204
        '
        'CheckBox6
        '
        Me.CheckBox6.AutoSize = True
        Me.CheckBox6.Location = New System.Drawing.Point(34, 417)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(41, 21)
        Me.CheckBox6.TabIndex = 1207
        Me.CheckBox6.Text = "TP"
        Me.CheckBox6.UseVisualStyleBackColor = True
        '
        'ProgressBarControl6
        '
        Me.ProgressBarControl6.Location = New System.Drawing.Point(34, 444)
        Me.ProgressBarControl6.Name = "ProgressBarControl6"
        Me.ProgressBarControl6.Size = New System.Drawing.Size(605, 18)
        Me.ProgressBarControl6.TabIndex = 1206
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.Location = New System.Drawing.Point(34, 76)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(93, 21)
        Me.chkAll.TabIndex = 1208
        Me.chkAll.Text = "นำเข้าทั้งหมด"
        Me.chkAll.UseVisualStyleBackColor = True
        '
        'frmImportTMT
        '
        Me.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(681, 497)
        Me.Controls.Add(Me.chkAll)
        Me.Controls.Add(Me.CheckBox6)
        Me.Controls.Add(Me.ProgressBarControl6)
        Me.Controls.Add(Me.CheckBox5)
        Me.Controls.Add(Me.ProgressBarControl5)
        Me.Controls.Add(Me.CheckBox4)
        Me.Controls.Add(Me.ProgressBarControl4)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.ProgressBarControl3)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.ProgressBarControl2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ProgressBarControl1)
        Me.Controls.Add(Me.cmdImport)
        Me.Controls.Add(Me.cmdBrowse)
        Me.Controls.Add(Me.txtFilename)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmImportTMT"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "นำเข้ารายการ TMT"
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProgressBarControl2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProgressBarControl3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProgressBarControl4.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProgressBarControl5.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProgressBarControl6.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdBrowse As System.Windows.Forms.Button
    Friend WithEvents txtFilename As System.Windows.Forms.TextBox
    Friend WithEvents cmdImport As System.Windows.Forms.Button
    Friend WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
    Friend WithEvents ProgressBarControl1 As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents ProgressBarControl2 As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents ProgressBarControl3 As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents ProgressBarControl4 As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents CheckBox5 As System.Windows.Forms.CheckBox
    Friend WithEvents ProgressBarControl5 As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents CheckBox6 As System.Windows.Forms.CheckBox
    Friend WithEvents ProgressBarControl6 As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents chkAll As System.Windows.Forms.CheckBox
End Class

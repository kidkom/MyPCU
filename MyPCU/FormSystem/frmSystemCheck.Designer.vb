<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSystemCheck
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSystemCheck))
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.MyPCU.WaitForm1), True, True)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.cmdApply = New System.Windows.Forms.Button()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.CheckBox2)
        Me.GroupControl1.Controls.Add(Me.CheckBox1)
        Me.GroupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Card
        Me.GroupControl1.Location = New System.Drawing.Point(12, 12)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(465, 100)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "การปรับปรุงข้อมูลภายในระบบ"
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(17, 59)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(210, 21)
        Me.CheckBox2.TabIndex = 3
        Me.CheckBox2.Text = "ปรับปรุงความครอบคลุมการได้รับวัคซีน"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(17, 35)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(226, 21)
        Me.CheckBox1.TabIndex = 2
        Me.CheckBox1.Text = "ปรับปรุงคำนำหน้าเด็กที่อายุ 15 ปีบริบูรณ์"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.ListView1)
        Me.GroupControl2.Controls.Add(Me.CheckBox5)
        Me.GroupControl2.Controls.Add(Me.Label2)
        Me.GroupControl2.Controls.Add(Me.Label1)
        Me.GroupControl2.Controls.Add(Me.CheckBox3)
        Me.GroupControl2.Controls.Add(Me.CheckBox4)
        Me.GroupControl2.GroupStyle = DevExpress.Utils.GroupStyle.Card
        Me.GroupControl2.Location = New System.Drawing.Point(12, 127)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(465, 302)
        Me.GroupControl2.TabIndex = 4
        Me.GroupControl2.Text = "การปรับปรุงข้อมูลจาก MyPCU Center"
        '
        'ListView1
        '
        Me.ListView1.BackColor = System.Drawing.Color.Beige
        Me.ListView1.FullRowSelect = True
        Me.ListView1.Location = New System.Drawing.Point(16, 159)
        Me.ListView1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(431, 113)
        Me.ListView1.TabIndex = 411
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'CheckBox5
        '
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.Location = New System.Drawing.Point(17, 134)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(162, 21)
        Me.CheckBox5.TabIndex = 410
        Me.CheckBox5.Text = "ปรับปรุงตารางรหัสมาตรฐาน"
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(35, 105)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 17)
        Me.Label2.TabIndex = 409
        Me.Label2.Text = "ในฐาน SERVER มี    รายการ"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(35, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 17)
        Me.Label1.TabIndex = 408
        Me.Label1.Text = "ในฐานข้อมูลมี    รายการ"
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(17, 61)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(165, 21)
        Me.CheckBox3.TabIndex = 407
        Me.CheckBox3.Text = "ตรวจสอบรหัสสถานพยาบาล"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Location = New System.Drawing.Point(17, 37)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(138, 21)
        Me.CheckBox4.TabIndex = 406
        Me.CheckBox4.Text = "การเชื่อมต่อ SERVER "
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'SplashScreenManager1
        '
        Me.SplashScreenManager1.ClosingDelay = 500
        '
        'Timer1
        '
        '
        'cmdApply
        '
        Me.cmdApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdApply.Image = Global.MyPCU.My.Resources.Resources.a_shf2t1
        Me.cmdApply.Location = New System.Drawing.Point(354, 440)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(126, 30)
        Me.cmdApply.TabIndex = 7
        Me.cmdApply.Text = "ปรับปรุงข้อมูล"
        Me.cmdApply.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdApply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'frmSystemCheck
        '
        Me.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 482)
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSystemCheck"
        Me.ShowInTaskbar = False
        Me.Text = "ระบบกาปรับปรุงข้อมูลประจำวัน"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents CheckBox5 As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
End Class

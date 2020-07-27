<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRestore
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRestore))
        Me.XtraOpenFileDialog1 = New DevExpress.XtraEditors.XtraOpenFileDialog(Me.components)
        Me.cmdBrowse = New System.Windows.Forms.Button()
        Me.txtFilename = New System.Windows.Forms.TextBox()
        Me.chkFinger = New System.Windows.Forms.CheckBox()
        Me.chkReoder = New System.Windows.Forms.CheckBox()
        Me.chkPicture = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.chkAll = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ProgressBarControl1 = New DevExpress.XtraEditors.ProgressBarControl()
        Me.BetterListView1 = New ComponentOwl.BetterListView.BetterListView()
        Me.cmdBkup = New System.Windows.Forms.Button()
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.MyPCU.WaitForm1), True, True)
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraOpenFileDialog1
        '
        Me.XtraOpenFileDialog1.FileName = "XtraOpenFileDialog1"
        '
        'cmdBrowse
        '
        Me.cmdBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdBrowse.Image = Global.MyPCU.My.Resources.Resources.a_folder_open
        Me.cmdBrowse.Location = New System.Drawing.Point(330, 20)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.Size = New System.Drawing.Size(92, 30)
        Me.cmdBrowse.TabIndex = 839
        Me.cmdBrowse.Text = "Browse"
        Me.cmdBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdBrowse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdBrowse.UseVisualStyleBackColor = True
        '
        'txtFilename
        '
        Me.txtFilename.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFilename.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtFilename.Location = New System.Drawing.Point(13, 56)
        Me.txtFilename.Name = "txtFilename"
        Me.txtFilename.Size = New System.Drawing.Size(528, 25)
        Me.txtFilename.TabIndex = 838
        '
        'chkFinger
        '
        Me.chkFinger.AutoSize = True
        Me.chkFinger.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.chkFinger.Location = New System.Drawing.Point(292, 87)
        Me.chkFinger.Name = "chkFinger"
        Me.chkFinger.Size = New System.Drawing.Size(106, 21)
        Me.chkFinger.TabIndex = 852
        Me.chkFinger.Text = "นำเข้าลายนิ้วมือ"
        Me.chkFinger.UseVisualStyleBackColor = True
        '
        'chkReoder
        '
        Me.chkReoder.AutoSize = True
        Me.chkReoder.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.chkReoder.Location = New System.Drawing.Point(405, 111)
        Me.chkReoder.Name = "chkReoder"
        Me.chkReoder.Size = New System.Drawing.Size(115, 21)
        Me.chkReoder.TabIndex = 851
        Me.chkReoder.Text = "จัดลำดับข้อมูลใหม่"
        Me.chkReoder.UseVisualStyleBackColor = True
        '
        'chkPicture
        '
        Me.chkPicture.AutoSize = True
        Me.chkPicture.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.chkPicture.Location = New System.Drawing.Point(168, 87)
        Me.chkPicture.Name = "chkPicture"
        Me.chkPicture.Size = New System.Drawing.Size(94, 21)
        Me.chkPicture.TabIndex = 850
        Me.chkPicture.Text = "นำเข้ารูปภาพ"
        Me.chkPicture.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CheckBox3.Location = New System.Drawing.Point(12, 111)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(154, 21)
        Me.CheckBox3.TabIndex = 849
        Me.CheckBox3.Text = "เฉพาะตารางรหัสมาตรฐาน"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CheckBox2.Location = New System.Drawing.Point(168, 111)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(120, 21)
        Me.CheckBox2.TabIndex = 848
        Me.CheckBox2.Text = "เฉพาะระบบนักเรียน"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(292, 111)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(107, 21)
        Me.CheckBox1.TabIndex = 847
        Me.CheckBox1.Text = "เฉพาะระบบบัญชี"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.chkAll.Location = New System.Drawing.Point(12, 87)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(123, 21)
        Me.chkAll.TabIndex = 846
        Me.chkAll.Text = "เลือกนำกลับทุกแฟ้ม"
        Me.chkAll.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 17)
        Me.Label3.TabIndex = 853
        Me.Label3.Text = "Username"
        '
        'ProgressBarControl1
        '
        Me.ProgressBarControl1.Location = New System.Drawing.Point(13, 577)
        Me.ProgressBarControl1.Name = "ProgressBarControl1"
        Me.ProgressBarControl1.Size = New System.Drawing.Size(528, 18)
        Me.ProgressBarControl1.TabIndex = 1109
        '
        'BetterListView1
        '
        Me.BetterListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BetterListView1.CheckBoxes = ComponentOwl.BetterListView.BetterListViewCheckBoxes.TwoState
        Me.BetterListView1.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.BetterListView1.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Sortable
        Me.BetterListView1.Location = New System.Drawing.Point(12, 138)
        Me.BetterListView1.Name = "BetterListView1"
        Me.BetterListView1.Size = New System.Drawing.Size(527, 433)
        Me.BetterListView1.TabIndex = 1108
        '
        'cmdBkup
        '
        Me.cmdBkup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdBkup.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdBkup.Image = Global.MyPCU.My.Resources.Resources.a_restore
        Me.cmdBkup.Location = New System.Drawing.Point(428, 20)
        Me.cmdBkup.Name = "cmdBkup"
        Me.cmdBkup.Size = New System.Drawing.Size(113, 30)
        Me.cmdBkup.TabIndex = 1110
        Me.cmdBkup.Text = "นำกลับข้อมูล"
        Me.cmdBkup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdBkup.UseVisualStyleBackColor = True
        '
        'SplashScreenManager1
        '
        Me.SplashScreenManager1.ClosingDelay = 500
        '
        'frmRestore
        '
        Me.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(553, 602)
        Me.Controls.Add(Me.cmdBkup)
        Me.Controls.Add(Me.ProgressBarControl1)
        Me.Controls.Add(Me.BetterListView1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.chkFinger)
        Me.Controls.Add(Me.chkReoder)
        Me.Controls.Add(Me.chkPicture)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.chkAll)
        Me.Controls.Add(Me.cmdBrowse)
        Me.Controls.Add(Me.txtFilename)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRestore"
        Me.ShowInTaskbar = False
        Me.Text = "นำกลับข้อมูลที่สำรอง (Restore)"
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents XtraOpenFileDialog1 As DevExpress.XtraEditors.XtraOpenFileDialog
    Friend WithEvents cmdBrowse As System.Windows.Forms.Button
    Friend WithEvents txtFilename As System.Windows.Forms.TextBox
    Friend WithEvents chkFinger As System.Windows.Forms.CheckBox
    Friend WithEvents chkReoder As System.Windows.Forms.CheckBox
    Friend WithEvents chkPicture As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents chkAll As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ProgressBarControl1 As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents BetterListView1 As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents cmdBkup As System.Windows.Forms.Button
    Friend WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
End Class

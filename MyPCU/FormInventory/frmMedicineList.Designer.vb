<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMedicineList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMedicineList))
        Me.BetterListView1 = New ComponentOwl.BetterListView.BetterListView()
        Me.chkShowAll = New System.Windows.Forms.CheckBox()
        Me.chkShow03 = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkShow17 = New System.Windows.Forms.CheckBox()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdSearch2 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkStatus1 = New System.Windows.Forms.CheckBox()
        Me.chkStatusAll = New System.Windows.Forms.CheckBox()
        Me.chkStatus0 = New System.Windows.Forms.CheckBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.MyPCU.WaitForm1), True, True)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BetterListView1
        '
        Me.BetterListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BetterListView1.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.BetterListView1.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Sortable
        Me.BetterListView1.Location = New System.Drawing.Point(12, 77)
        Me.BetterListView1.Name = "BetterListView1"
        Me.BetterListView1.Size = New System.Drawing.Size(1036, 396)
        Me.BetterListView1.TabIndex = 1106
        '
        'chkShowAll
        '
        Me.chkShowAll.AutoSize = True
        Me.chkShowAll.Location = New System.Drawing.Point(111, 16)
        Me.chkShowAll.Name = "chkShowAll"
        Me.chkShowAll.Size = New System.Drawing.Size(62, 21)
        Me.chkShowAll.TabIndex = 1107
        Me.chkShowAll.Text = "ทั้งหมด"
        Me.chkShowAll.UseVisualStyleBackColor = True
        '
        'chkShow03
        '
        Me.chkShow03.AutoSize = True
        Me.chkShow03.Location = New System.Drawing.Point(180, 16)
        Me.chkShow03.Name = "chkShow03"
        Me.chkShow03.Size = New System.Drawing.Size(154, 21)
        Me.chkShow03.TabIndex = 1108
        Me.chkShow03.Text = "ยาในบัญชียาหลักแห่งชาติ"
        Me.chkShow03.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 17)
        Me.Label2.TabIndex = 1109
        Me.Label2.Text = "หมวดค่าบริการ"
        '
        'chkShow17
        '
        Me.chkShow17.AutoSize = True
        Me.chkShow17.Location = New System.Drawing.Point(348, 16)
        Me.chkShow17.Name = "chkShow17"
        Me.chkShow17.Size = New System.Drawing.Size(163, 21)
        Me.chkShow17.TabIndex = 1110
        Me.chkShow17.Text = "ยานอกบัญชียาหลักแห่งชาติ"
        Me.chkShow17.UseVisualStyleBackColor = True
        '
        'cmdSearch
        '
        Me.cmdSearch.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdSearch.Image = Global.MyPCU.My.Resources.Resources.a_search
        Me.cmdSearch.Location = New System.Drawing.Point(244, 43)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(31, 28)
        Me.cmdSearch.TabIndex = 1112
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtSearch.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(55, 45)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(183, 25)
        Me.txtSearch.TabIndex = 1111
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 17)
        Me.Label1.TabIndex = 1113
        Me.Label1.Text = "ค้นหา"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Button1.Image = Global.MyPCU.My.Resources.Resources.a_edit4
        Me.Button1.Location = New System.Drawing.Point(1016, 44)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(30, 26)
        Me.Button1.TabIndex = 1115
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdSearch2
        '
        Me.cmdSearch2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSearch2.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdSearch2.Image = Global.MyPCU.My.Resources.Resources.a_add
        Me.cmdSearch2.Location = New System.Drawing.Point(980, 44)
        Me.cmdSearch2.Name = "cmdSearch2"
        Me.cmdSearch2.Size = New System.Drawing.Size(30, 26)
        Me.cmdSearch2.TabIndex = 1114
        Me.cmdSearch2.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(295, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 17)
        Me.Label3.TabIndex = 1117
        Me.Label3.Text = "สถานะ"
        '
        'chkStatus1
        '
        Me.chkStatus1.AutoSize = True
        Me.chkStatus1.Checked = True
        Me.chkStatus1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkStatus1.Location = New System.Drawing.Point(341, 47)
        Me.chkStatus1.Name = "chkStatus1"
        Me.chkStatus1.Size = New System.Drawing.Size(69, 21)
        Me.chkStatus1.TabIndex = 1116
        Me.chkStatus1.Text = "ยังใช้งาน"
        Me.chkStatus1.UseVisualStyleBackColor = True
        '
        'chkStatusAll
        '
        Me.chkStatusAll.AutoSize = True
        Me.chkStatusAll.Location = New System.Drawing.Point(480, 47)
        Me.chkStatusAll.Name = "chkStatusAll"
        Me.chkStatusAll.Size = New System.Drawing.Size(62, 21)
        Me.chkStatusAll.TabIndex = 1119
        Me.chkStatusAll.Text = "ทั้งหมด"
        Me.chkStatusAll.UseVisualStyleBackColor = True
        '
        'chkStatus0
        '
        Me.chkStatus0.AutoSize = True
        Me.chkStatus0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.chkStatus0.Location = New System.Drawing.Point(416, 47)
        Me.chkStatus0.Name = "chkStatus0"
        Me.chkStatus0.Size = New System.Drawing.Size(58, 21)
        Me.chkStatus0.TabIndex = 1118
        Me.chkStatus0.Text = "ยกเลิก"
        Me.chkStatus0.UseVisualStyleBackColor = True
        '
        'Label30
        '
        Me.Label30.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label30.Location = New System.Drawing.Point(12, 476)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(43, 17)
        Me.Label30.TabIndex = 1120
        Me.Label30.Text = "จำนวน"
        '
        'SplashScreenManager1
        '
        Me.SplashScreenManager1.ClosingDelay = 500
        '
        'Timer1
        '
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "a_check6.png")
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label16.Location = New System.Drawing.Point(826, 479)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(95, 17)
        Me.Label16.TabIndex = 1124
        Me.Label16.Text = "ยาในบัญชียาหลัก"
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label13.Location = New System.Drawing.Point(959, 479)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 17)
        Me.Label13.TabIndex = 1122
        Me.Label13.Text = "ยกเลิกการใช้งาน"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.LightPink
        Me.Panel1.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Panel1.ForeColor = System.Drawing.Color.Crimson
        Me.Panel1.Location = New System.Drawing.Point(937, 480)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(16, 15)
        Me.Panel1.TabIndex = 1121
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.MyPCU.My.Resources.Resources.a_check6
        Me.PictureBox1.Location = New System.Drawing.Point(798, 476)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(22, 23)
        Me.PictureBox1.TabIndex = 1125
        Me.PictureBox1.TabStop = False
        '
        'frmMedicineList
        '
        Me.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1060, 505)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.chkStatusAll)
        Me.Controls.Add(Me.chkStatus0)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.chkStatus1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmdSearch2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.chkShow17)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chkShow03)
        Me.Controls.Add(Me.chkShowAll)
        Me.Controls.Add(Me.BetterListView1)
        Me.Name = "frmMedicineList"
        Me.ShowInTaskbar = False
        Me.Text = "รายการยาและเวชภัณฑ์"
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BetterListView1 As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents chkShowAll As System.Windows.Forms.CheckBox
    Friend WithEvents chkShow03 As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkShow17 As System.Windows.Forms.CheckBox
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmdSearch2 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkStatus1 As System.Windows.Forms.CheckBox
    Friend WithEvents chkStatusAll As System.Windows.Forms.CheckBox
    Friend WithEvents chkStatus0 As System.Windows.Forms.CheckBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class

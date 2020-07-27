<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHome
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHome))
        Me.TreeList1 = New DevExpress.XtraTreeList.TreeList()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BetterListView1 = New ComponentOwl.BetterListView.BetterListView()
        Me.txtHouseSearch = New System.Windows.Forms.TextBox()
        Me.cmdSearch1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.chkError = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdSearch2 = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.chkExpand = New System.Windows.Forms.CheckBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.MyPCU.WaitForm1), True, True)
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.TreeList1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TreeList1
        '
        Me.TreeList1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TreeList1.Location = New System.Drawing.Point(12, 40)
        Me.TreeList1.Name = "TreeList1"
        Me.TreeList1.OptionsBehavior.Editable = False
        Me.TreeList1.OptionsBehavior.ReadOnly = True
        Me.TreeList1.Size = New System.Drawing.Size(368, 582)
        Me.TreeList1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(153, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "ที่ตั้งบ้านในเขตพื้นที่รับผิดชอบ"
        '
        'BetterListView1
        '
        Me.BetterListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BetterListView1.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.BetterListView1.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Sortable
        Me.BetterListView1.Location = New System.Drawing.Point(386, 40)
        Me.BetterListView1.Name = "BetterListView1"
        Me.BetterListView1.Size = New System.Drawing.Size(654, 582)
        Me.BetterListView1.TabIndex = 1105
        '
        'txtHouseSearch
        '
        Me.txtHouseSearch.Location = New System.Drawing.Point(459, 9)
        Me.txtHouseSearch.Name = "txtHouseSearch"
        Me.txtHouseSearch.Size = New System.Drawing.Size(117, 25)
        Me.txtHouseSearch.TabIndex = 1108
        '
        'cmdSearch1
        '
        Me.cmdSearch1.Image = Global.MyPCU.My.Resources.Resources.a_search
        Me.cmdSearch1.Location = New System.Drawing.Point(582, 9)
        Me.cmdSearch1.Name = "cmdSearch1"
        Me.cmdSearch1.Size = New System.Drawing.Size(33, 25)
        Me.cmdSearch1.TabIndex = 1107
        Me.cmdSearch1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(383, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 17)
        Me.Label2.TabIndex = 1106
        Me.Label2.Text = "ค้นบ้านเลขที่"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(804, 11)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(165, 21)
        Me.CheckBox1.TabIndex = 1110
        Me.CheckBox1.Text = "แสดงเฉพาะบ้านที่ไม่มีผู้อาศัย"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'chkError
        '
        Me.chkError.AutoSize = True
        Me.chkError.Location = New System.Drawing.Point(628, 11)
        Me.chkError.Name = "chkError"
        Me.chkError.Size = New System.Drawing.Size(170, 21)
        Me.chkError.TabIndex = 1109
        Me.chkError.Text = "แสดงเฉพาะข้อมูลที่ไม่สมบูรณ์"
        Me.chkError.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Button1.Image = Global.MyPCU.My.Resources.Resources.a_edit4
        Me.Button1.Location = New System.Drawing.Point(1011, 9)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(30, 26)
        Me.Button1.TabIndex = 1112
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdSearch2
        '
        Me.cmdSearch2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSearch2.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdSearch2.Image = Global.MyPCU.My.Resources.Resources.a_add
        Me.cmdSearch2.Location = New System.Drawing.Point(975, 9)
        Me.cmdSearch2.Name = "cmdSearch2"
        Me.cmdSearch2.Size = New System.Drawing.Size(30, 26)
        Me.cmdSearch2.TabIndex = 1111
        Me.cmdSearch2.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "a_folder_close.png")
        Me.ImageList1.Images.SetKeyName(1, "a_folder_open.png")
        Me.ImageList1.Images.SetKeyName(2, "a_folder_open2.png")
        Me.ImageList1.Images.SetKeyName(3, "a_warning.png")
        Me.ImageList1.Images.SetKeyName(4, "a_transparant.png")
        '
        'chkExpand
        '
        Me.chkExpand.AutoSize = True
        Me.chkExpand.Location = New System.Drawing.Point(287, 11)
        Me.chkExpand.Name = "chkExpand"
        Me.chkExpand.Size = New System.Drawing.Size(90, 21)
        Me.chkExpand.TabIndex = 1113
        Me.chkExpand.Text = "ขยายทั้งหมด"
        Me.chkExpand.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'SplashScreenManager1
        '
        Me.SplashScreenManager1.ClosingDelay = 500
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(383, 625)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 17)
        Me.Label1.TabIndex = 1114
        Me.Label1.Text = "จำนวน"
        '
        'frmHome
        '
        Me.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1052, 657)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkExpand)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmdSearch2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.chkError)
        Me.Controls.Add(Me.txtHouseSearch)
        Me.Controls.Add(Me.cmdSearch1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BetterListView1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TreeList1)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmHome"
        Me.Text = "ข้อมูลบ้าน"
        CType(Me.TreeList1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TreeList1 As DevExpress.XtraTreeList.TreeList
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BetterListView1 As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents txtHouseSearch As System.Windows.Forms.TextBox
    Friend WithEvents cmdSearch1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents chkError As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmdSearch2 As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents chkExpand As System.Windows.Forms.CheckBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class

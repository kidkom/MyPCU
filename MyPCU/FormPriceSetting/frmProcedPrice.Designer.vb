<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProcedPrice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProcedPrice))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BetterListView1 = New ComponentOwl.BetterListView.BetterListView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.chkItem = New System.Windows.Forms.CheckBox()
        Me.chkAll = New System.Windows.Forms.CheckBox()
        Me.cboChargeItem = New DevExpress.XtraEditors.LookUpEdit()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdSearch2 = New System.Windows.Forms.Button()
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.MyPCU.WaitForm1), True, True)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.chkStatus0 = New System.Windows.Forms.CheckBox()
        Me.chkStatus1 = New System.Windows.Forms.CheckBox()
        Me.chkStatusAll = New System.Windows.Forms.CheckBox()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboChargeItem.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 568)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 17)
        Me.Label1.TabIndex = 1107
        Me.Label1.Text = "จำนวน"
        '
        'BetterListView1
        '
        Me.BetterListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BetterListView1.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.BetterListView1.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Sortable
        Me.BetterListView1.Location = New System.Drawing.Point(12, 73)
        Me.BetterListView1.Name = "BetterListView1"
        Me.BetterListView1.Size = New System.Drawing.Size(923, 492)
        Me.BetterListView1.TabIndex = 1106
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 17)
        Me.Label3.TabIndex = 1124
        Me.Label3.Text = "ค้นหา"
        '
        'cmdSearch
        '
        Me.cmdSearch.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdSearch.Image = CType(resources.GetObject("cmdSearch.Image"), System.Drawing.Image)
        Me.cmdSearch.Location = New System.Drawing.Point(321, 41)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(30, 26)
        Me.cmdSearch.TabIndex = 1123
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(57, 42)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(258, 25)
        Me.txtSearch.TabIndex = 1122
        '
        'chkItem
        '
        Me.chkItem.AutoSize = True
        Me.chkItem.Location = New System.Drawing.Point(148, 12)
        Me.chkItem.Name = "chkItem"
        Me.chkItem.Size = New System.Drawing.Size(79, 21)
        Me.chkItem.TabIndex = 1126
        Me.chkItem.Text = "เลือกหมวด"
        Me.chkItem.UseVisualStyleBackColor = True
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.Location = New System.Drawing.Point(17, 11)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(125, 21)
        Me.chkAll.TabIndex = 1125
        Me.chkAll.Text = "แสดงรายการทั้งหมด"
        Me.chkAll.UseVisualStyleBackColor = True
        '
        'cboChargeItem
        '
        Me.cboChargeItem.Location = New System.Drawing.Point(233, 10)
        Me.cboChargeItem.Name = "cboChargeItem"
        Me.cboChargeItem.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboChargeItem.Size = New System.Drawing.Size(410, 24)
        Me.cboChargeItem.TabIndex = 1127
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Button1.Image = Global.MyPCU.My.Resources.Resources.a_edit4
        Me.Button1.Location = New System.Drawing.Point(897, 41)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(38, 26)
        Me.Button1.TabIndex = 1129
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdSearch2
        '
        Me.cmdSearch2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSearch2.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdSearch2.Image = Global.MyPCU.My.Resources.Resources.a_add
        Me.cmdSearch2.Location = New System.Drawing.Point(853, 41)
        Me.cmdSearch2.Name = "cmdSearch2"
        Me.cmdSearch2.Size = New System.Drawing.Size(38, 26)
        Me.cmdSearch2.TabIndex = 1128
        Me.cmdSearch2.UseVisualStyleBackColor = True
        '
        'SplashScreenManager1
        '
        Me.SplashScreenManager1.ClosingDelay = 500
        '
        'Timer1
        '
        '
        'chkStatus0
        '
        Me.chkStatus0.AutoSize = True
        Me.chkStatus0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.chkStatus0.Location = New System.Drawing.Point(427, 44)
        Me.chkStatus0.Name = "chkStatus0"
        Me.chkStatus0.Size = New System.Drawing.Size(70, 21)
        Me.chkStatus0.TabIndex = 1132
        Me.chkStatus0.Text = "Inactive"
        Me.chkStatus0.UseVisualStyleBackColor = True
        '
        'chkStatus1
        '
        Me.chkStatus1.AutoSize = True
        Me.chkStatus1.Checked = True
        Me.chkStatus1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkStatus1.Location = New System.Drawing.Point(357, 44)
        Me.chkStatus1.Name = "chkStatus1"
        Me.chkStatus1.Size = New System.Drawing.Size(61, 21)
        Me.chkStatus1.TabIndex = 1131
        Me.chkStatus1.Text = "Active"
        Me.chkStatus1.UseVisualStyleBackColor = True
        '
        'chkStatusAll
        '
        Me.chkStatusAll.AutoSize = True
        Me.chkStatusAll.Location = New System.Drawing.Point(503, 45)
        Me.chkStatusAll.Name = "chkStatusAll"
        Me.chkStatusAll.Size = New System.Drawing.Size(62, 21)
        Me.chkStatusAll.TabIndex = 1130
        Me.chkStatusAll.Text = "ทั้งหมด"
        Me.chkStatusAll.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "a_cruch.png")
        Me.ImageList1.Images.SetKeyName(1, "a_blood.png")
        Me.ImageList1.Images.SetKeyName(2, "a_xray2.png")
        Me.ImageList1.Images.SetKeyName(3, "a_cissor.png")
        Me.ImageList1.Images.SetKeyName(4, "a_tooth.png")
        Me.ImageList1.Images.SetKeyName(5, "a_warker.png")
        Me.ImageList1.Images.SetKeyName(6, "a_massage.png")
        '
        'frmProcedPrice
        '
        Me.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(956, 594)
        Me.Controls.Add(Me.chkStatus0)
        Me.Controls.Add(Me.chkStatus1)
        Me.Controls.Add(Me.chkStatusAll)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmdSearch2)
        Me.Controls.Add(Me.cboChargeItem)
        Me.Controls.Add(Me.chkItem)
        Me.Controls.Add(Me.chkAll)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BetterListView1)
        Me.Name = "frmProcedPrice"
        Me.ShowInTaskbar = False
        Me.Text = "กำหนดรายยการหัตถการ"
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboChargeItem.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BetterListView1 As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents chkItem As System.Windows.Forms.CheckBox
    Friend WithEvents chkAll As System.Windows.Forms.CheckBox
    Friend WithEvents cboChargeItem As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmdSearch2 As System.Windows.Forms.Button
    Friend WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents chkStatus0 As System.Windows.Forms.CheckBox
    Friend WithEvents chkStatus1 As System.Windows.Forms.CheckBox
    Friend WithEvents chkStatusAll As System.Windows.Forms.CheckBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
End Class

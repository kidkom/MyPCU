<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIcd9Search
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIcd9Search))
        Me.BetterListView1 = New ComponentOwl.BetterListView.BetterListView()
        Me.chk9CM = New System.Windows.Forms.CheckBox()
        Me.chkAll = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chk10TM = New System.Windows.Forms.CheckBox()
        Me.chk10TMD = New System.Windows.Forms.CheckBox()
        Me.chk10Dental = New System.Windows.Forms.CheckBox()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblAmount = New System.Windows.Forms.Label()
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.MyPCU.WaitForm1), True, True)
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BetterListView1
        '
        Me.BetterListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BetterListView1.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.BetterListView1.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Sortable
        Me.BetterListView1.Location = New System.Drawing.Point(12, 82)
        Me.BetterListView1.Name = "BetterListView1"
        Me.BetterListView1.Size = New System.Drawing.Size(883, 474)
        Me.BetterListView1.TabIndex = 1107
        '
        'chk9CM
        '
        Me.chk9CM.AutoSize = True
        Me.chk9CM.Location = New System.Drawing.Point(143, 18)
        Me.chk9CM.Name = "chk9CM"
        Me.chk9CM.Size = New System.Drawing.Size(84, 21)
        Me.chk9CM.TabIndex = 1125
        Me.chk9CM.Text = "ICD-9-CM"
        Me.chk9CM.UseVisualStyleBackColor = True
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.Checked = True
        Me.chkAll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAll.Location = New System.Drawing.Point(75, 18)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(62, 21)
        Me.chkAll.TabIndex = 1124
        Me.chkAll.Text = "ทั้งหมด"
        Me.chkAll.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 17)
        Me.Label2.TabIndex = 1123
        Me.Label2.Text = "ค้นหาจาก"
        '
        'chk10TM
        '
        Me.chk10TM.AutoSize = True
        Me.chk10TM.Location = New System.Drawing.Point(233, 18)
        Me.chk10TM.Name = "chk10TM"
        Me.chk10TM.Size = New System.Drawing.Size(90, 21)
        Me.chk10TM.TabIndex = 1126
        Me.chk10TM.Text = "ICD-10-TM"
        Me.chk10TM.UseVisualStyleBackColor = True
        '
        'chk10TMD
        '
        Me.chk10TMD.AutoSize = True
        Me.chk10TMD.Location = New System.Drawing.Point(329, 18)
        Me.chk10TMD.Name = "chk10TMD"
        Me.chk10TMD.Size = New System.Drawing.Size(134, 21)
        Me.chk10TMD.TabIndex = 1127
        Me.chk10TMD.Text = "ICD-10-TM แผนไทย"
        Me.chk10TMD.UseVisualStyleBackColor = True
        '
        'chk10Dental
        '
        Me.chk10Dental.AutoSize = True
        Me.chk10Dental.Location = New System.Drawing.Point(469, 18)
        Me.chk10Dental.Name = "chk10Dental"
        Me.chk10Dental.Size = New System.Drawing.Size(143, 21)
        Me.chk10Dental.TabIndex = 1129
        Me.chk10Dental.Text = "ICD-10-TM ทันตกรรม"
        Me.chk10Dental.UseVisualStyleBackColor = True
        '
        'cmdSearch
        '
        Me.cmdSearch.Image = Global.MyPCU.My.Resources.Resources.a_search
        Me.cmdSearch.Location = New System.Drawing.Point(514, 50)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(33, 27)
        Me.cmdSearch.TabIndex = 1132
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(194, 51)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(314, 25)
        Me.txtSearch.TabIndex = 1131
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label17.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(10, 54)
        Me.Label17.Name = "Label17"
        Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label17.Size = New System.Drawing.Size(178, 17)
        Me.Label17.TabIndex = 1130
        Me.Label17.Text = "ใส่รหัสหรือหัตถการที่ต้องการค้นหา"
        '
        'lblAmount
        '
        Me.lblAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblAmount.AutoSize = True
        Me.lblAmount.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblAmount.ForeColor = System.Drawing.Color.Black
        Me.lblAmount.Location = New System.Drawing.Point(12, 559)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(43, 17)
        Me.lblAmount.TabIndex = 1133
        Me.lblAmount.Text = "จำนวน"
        '
        'SplashScreenManager1
        '
        Me.SplashScreenManager1.ClosingDelay = 500
        '
        'Label25
        '
        Me.Label25.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label25.Location = New System.Drawing.Point(856, 559)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(39, 17)
        Me.Label25.TabIndex = 1135
        Me.Label25.Text = "ยกเลิก"
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.LightPink
        Me.Panel4.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Panel4.ForeColor = System.Drawing.Color.Crimson
        Me.Panel4.Location = New System.Drawing.Point(834, 560)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(16, 15)
        Me.Panel4.TabIndex = 1134
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "a_check6.png")
        '
        'frmIcd9Search
        '
        Me.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(907, 596)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.lblAmount)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.chk10Dental)
        Me.Controls.Add(Me.chk10TMD)
        Me.Controls.Add(Me.chk10TM)
        Me.Controls.Add(Me.chk9CM)
        Me.Controls.Add(Me.chkAll)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BetterListView1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmIcd9Search"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds
        Me.Text = "ICD-9/ICD-10-TM Procedures Search"
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BetterListView1 As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents chk9CM As System.Windows.Forms.CheckBox
    Friend WithEvents chkAll As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chk10TM As System.Windows.Forms.CheckBox
    Friend WithEvents chk10TMD As System.Windows.Forms.CheckBox
    Friend WithEvents chk10Dental As System.Windows.Forms.CheckBox
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Public WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
End Class

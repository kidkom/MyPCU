<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLookupPrename
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLookupPrename))
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.cmdSearchCouple = New System.Windows.Forms.Button()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.optSex2 = New System.Windows.Forms.CheckBox()
        Me.optSex1 = New System.Windows.Forms.CheckBox()
        Me.chkStatus = New System.Windows.Forms.CheckBox()
        Me.cboPrename = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblPrename = New DevExpress.XtraEditors.LabelControl()
        Me.txtPrenameTh = New DevExpress.XtraEditors.TextEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPrenameEn = New DevExpress.XtraEditors.TextEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BetterListView1 = New ComponentOwl.BetterListView.BetterListView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.cboPrename.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrenameTh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrenameEn.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdSave
        '
        Me.cmdSave.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdSave.Image = Global.MyPCU.My.Resources.Resources.a_save
        Me.cmdSave.Location = New System.Drawing.Point(665, 204)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(43, 32)
        Me.cmdSave.TabIndex = 1115
        Me.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        Me.cmdAdd.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdAdd.Image = Global.MyPCU.My.Resources.Resources.a_add
        Me.cmdAdd.Location = New System.Drawing.Point(616, 204)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(43, 32)
        Me.cmdAdd.TabIndex = 1114
        Me.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'cmdSearchCouple
        '
        Me.cmdSearchCouple.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSearchCouple.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdSearchCouple.Image = Global.MyPCU.My.Resources.Resources.a_refresh
        Me.cmdSearchCouple.Location = New System.Drawing.Point(596, 650)
        Me.cmdSearchCouple.Name = "cmdSearchCouple"
        Me.cmdSearchCouple.Size = New System.Drawing.Size(112, 32)
        Me.cmdSearchCouple.TabIndex = 1113
        Me.cmdSearchCouple.Text = "ปรับปรุงรหัสเดิม"
        Me.cmdSearchCouple.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdSearchCouple.UseVisualStyleBackColor = True
        Me.cmdSearchCouple.Visible = False
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CheckBox3.Location = New System.Drawing.Point(99, 211)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(58, 21)
        Me.CheckBox3.TabIndex = 1112
        Me.CheckBox3.Text = "ยกเลิก"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Checked = True
        Me.CheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox2.Location = New System.Drawing.Point(15, 211)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(78, 21)
        Me.CheckBox2.TabIndex = 1111
        Me.CheckBox2.Text = "เฉพาะที่ใช้"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(163, 211)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(62, 21)
        Me.CheckBox1.TabIndex = 1110
        Me.CheckBox1.Text = "ทั้งหมด"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 658)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 17)
        Me.Label5.TabIndex = 1107
        Me.Label5.Text = "จำนวน"
        '
        'GroupControl1
        '
        Me.GroupControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl1.Controls.Add(Me.optSex2)
        Me.GroupControl1.Controls.Add(Me.optSex1)
        Me.GroupControl1.Controls.Add(Me.chkStatus)
        Me.GroupControl1.Controls.Add(Me.cboPrename)
        Me.GroupControl1.Controls.Add(Me.lblPrename)
        Me.GroupControl1.Controls.Add(Me.txtPrenameTh)
        Me.GroupControl1.Controls.Add(Me.Label4)
        Me.GroupControl1.Controls.Add(Me.Label1)
        Me.GroupControl1.Controls.Add(Me.Label2)
        Me.GroupControl1.Controls.Add(Me.txtPrenameEn)
        Me.GroupControl1.Controls.Add(Me.Label3)
        Me.GroupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Card
        Me.GroupControl1.Location = New System.Drawing.Point(12, 15)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(696, 175)
        Me.GroupControl1.TabIndex = 1109
        Me.GroupControl1.Text = "กำหนดรหัสคำนำหน้า"
        '
        'optSex2
        '
        Me.optSex2.AutoSize = True
        Me.optSex2.Location = New System.Drawing.Point(207, 77)
        Me.optSex2.Name = "optSex2"
        Me.optSex2.Size = New System.Drawing.Size(51, 21)
        Me.optSex2.TabIndex = 1108
        Me.optSex2.Text = "หญิง"
        Me.optSex2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.optSex2.UseVisualStyleBackColor = True
        '
        'optSex1
        '
        Me.optSex1.AutoSize = True
        Me.optSex1.Checked = True
        Me.optSex1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.optSex1.Location = New System.Drawing.Point(131, 77)
        Me.optSex1.Name = "optSex1"
        Me.optSex1.Size = New System.Drawing.Size(48, 21)
        Me.optSex1.TabIndex = 1107
        Me.optSex1.Text = "ชาย"
        Me.optSex1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.optSex1.UseVisualStyleBackColor = True
        '
        'chkStatus
        '
        Me.chkStatus.AutoSize = True
        Me.chkStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.chkStatus.Location = New System.Drawing.Point(131, 145)
        Me.chkStatus.Name = "chkStatus"
        Me.chkStatus.Size = New System.Drawing.Size(58, 21)
        Me.chkStatus.TabIndex = 1104
        Me.chkStatus.Text = "ยกเลิก"
        Me.chkStatus.UseVisualStyleBackColor = True
        '
        'cboPrename
        '
        Me.cboPrename.Location = New System.Drawing.Point(200, 108)
        Me.cboPrename.Name = "cboPrename"
        Me.cboPrename.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboPrename.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.cboPrename.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboPrename.Size = New System.Drawing.Size(389, 24)
        Me.cboPrename.TabIndex = 10
        '
        'lblPrename
        '
        Me.lblPrename.Appearance.BackColor = System.Drawing.Color.Beige
        Me.lblPrename.Appearance.Options.UseBackColor = True
        Me.lblPrename.Appearance.Options.UseTextOptions = True
        Me.lblPrename.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lblPrename.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblPrename.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.lblPrename.Location = New System.Drawing.Point(131, 107)
        Me.lblPrename.Name = "lblPrename"
        Me.lblPrename.Size = New System.Drawing.Size(63, 25)
        Me.lblPrename.TabIndex = 9
        '
        'txtPrenameTh
        '
        Me.txtPrenameTh.Location = New System.Drawing.Point(131, 44)
        Me.txtPrenameTh.Name = "txtPrenameTh"
        Me.txtPrenameTh.Properties.Appearance.Options.UseTextOptions = True
        Me.txtPrenameTh.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtPrenameTh.Size = New System.Drawing.Size(147, 24)
        Me.txtPrenameTh.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(47, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 17)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "รหัสมาตรฐาน"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(65, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "คำนำหน้า"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(317, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "คำนำหน้าภาษาอังกฤษ"
        '
        'txtPrenameEn
        '
        Me.txtPrenameEn.Location = New System.Drawing.Point(442, 44)
        Me.txtPrenameEn.Name = "txtPrenameEn"
        Me.txtPrenameEn.Properties.Appearance.Options.UseTextOptions = True
        Me.txtPrenameEn.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtPrenameEn.Size = New System.Drawing.Size(147, 24)
        Me.txtPrenameEn.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(95, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "เพศ"
        '
        'BetterListView1
        '
        Me.BetterListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BetterListView1.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.BetterListView1.Location = New System.Drawing.Point(12, 244)
        Me.BetterListView1.Name = "BetterListView1"
        Me.BetterListView1.Size = New System.Drawing.Size(696, 400)
        Me.BetterListView1.TabIndex = 1108
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "a_person2.png")
        Me.ImageList1.Images.SetKeyName(1, "a_woman.png")
        '
        'frmLookupPrename
        '
        Me.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(720, 690)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.cmdSearchCouple)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.BetterListView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmLookupPrename"
        Me.ShowInTaskbar = False
        Me.Text = "ตารางรหัสคำนำหน้า"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.cboPrename.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrenameTh.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrenameEn.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdSearchCouple As System.Windows.Forms.Button
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents optSex2 As System.Windows.Forms.CheckBox
    Friend WithEvents optSex1 As System.Windows.Forms.CheckBox
    Friend WithEvents chkStatus As System.Windows.Forms.CheckBox
    Friend WithEvents cboPrename As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblPrename As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPrenameTh As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPrenameEn As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BetterListView1 As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
End Class

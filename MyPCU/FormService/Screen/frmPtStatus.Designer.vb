﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPtStatus
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPtStatus))
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.cmdSave = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.BetterListView1 = New ComponentOwl.BetterListView.BetterListView()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.chkStatus = New System.Windows.Forms.CheckBox()
        Me.txtPrenameTh = New DevExpress.XtraEditors.TextEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ImageComboBoxEdit1 = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.txtPrenameTh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageComboBoxEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 576)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 17)
        Me.Label5.TabIndex = 1118
        Me.Label5.Text = "จำนวน"
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CheckBox3.Location = New System.Drawing.Point(96, 162)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(58, 21)
        Me.CheckBox3.TabIndex = 1117
        Me.CheckBox3.Text = "ยกเลิก"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Checked = True
        Me.CheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox2.Location = New System.Drawing.Point(12, 162)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(78, 21)
        Me.CheckBox2.TabIndex = 1116
        Me.CheckBox2.Text = "เฉพาะที่ใช้"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(160, 162)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(62, 21)
        Me.CheckBox1.TabIndex = 1115
        Me.CheckBox1.Text = "ทั้งหมด"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.ImageOptions.Image = Global.MyPCU.My.Resources.Resources.a_save
        Me.cmdSave.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdSave.Location = New System.Drawing.Point(572, 152)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(48, 31)
        Me.cmdSave.TabIndex = 1114
        '
        'cmdAdd
        '
        Me.cmdAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAdd.ImageOptions.Image = Global.MyPCU.My.Resources.Resources.a_add
        Me.cmdAdd.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdAdd.Location = New System.Drawing.Point(518, 152)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(48, 31)
        Me.cmdAdd.TabIndex = 1113
        '
        'BetterListView1
        '
        Me.BetterListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BetterListView1.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.BetterListView1.Location = New System.Drawing.Point(12, 189)
        Me.BetterListView1.Name = "BetterListView1"
        Me.BetterListView1.Size = New System.Drawing.Size(608, 384)
        Me.BetterListView1.TabIndex = 1112
        '
        'GroupControl1
        '
        Me.GroupControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl1.Controls.Add(Me.ImageComboBoxEdit1)
        Me.GroupControl1.Controls.Add(Me.Label19)
        Me.GroupControl1.Controls.Add(Me.chkStatus)
        Me.GroupControl1.Controls.Add(Me.txtPrenameTh)
        Me.GroupControl1.Controls.Add(Me.Label1)
        Me.GroupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Card
        Me.GroupControl1.Location = New System.Drawing.Point(12, 11)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(608, 135)
        Me.GroupControl1.TabIndex = 1111
        Me.GroupControl1.Text = "กำหนดสภาพผู้ป่วยที่เข้ารับบริการ"
        '
        'chkStatus
        '
        Me.chkStatus.AutoSize = True
        Me.chkStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.chkStatus.Location = New System.Drawing.Point(164, 109)
        Me.chkStatus.Name = "chkStatus"
        Me.chkStatus.Size = New System.Drawing.Size(58, 21)
        Me.chkStatus.TabIndex = 1104
        Me.chkStatus.Text = "ยกเลิก"
        Me.chkStatus.UseVisualStyleBackColor = True
        '
        'txtPrenameTh
        '
        Me.txtPrenameTh.Location = New System.Drawing.Point(164, 44)
        Me.txtPrenameTh.Name = "txtPrenameTh"
        Me.txtPrenameTh.Properties.Appearance.Options.UseTextOptions = True
        Me.txtPrenameTh.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtPrenameTh.Size = New System.Drawing.Size(348, 24)
        Me.txtPrenameTh.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "สภาพผู้ป่วยที่เข้ารับบริการ"
        '
        'ImageComboBoxEdit1
        '
        Me.ImageComboBoxEdit1.AllowDrop = True
        Me.ImageComboBoxEdit1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImageComboBoxEdit1.Location = New System.Drawing.Point(164, 76)
        Me.ImageComboBoxEdit1.Name = "ImageComboBoxEdit1"
        Me.ImageComboBoxEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ImageComboBoxEdit1.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ไม่เร่งด่วน", "1", 0), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ค่อนข้างเร่งด่วน", "2", 1), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("เร่งด่วน", "3", 2), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ฉุกเฉิน", "4", 3), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ต้องช่วยฟื้นคืนชีพ", "5", 4)})
        Me.ImageComboBoxEdit1.Size = New System.Drawing.Size(197, 24)
        Me.ImageComboBoxEdit1.TabIndex = 1310
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(89, 79)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(69, 17)
        Me.Label19.TabIndex = 1309
        Me.Label19.Text = "ความเร่งด่วน"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "a_white.png")
        Me.ImageList1.Images.SetKeyName(1, "a_green2.png")
        Me.ImageList1.Images.SetKeyName(2, "a_yellow.png")
        Me.ImageList1.Images.SetKeyName(3, "a_pink.png")
        Me.ImageList1.Images.SetKeyName(4, "a_red2.png")
        '
        'frmPtStatus
        '
        Me.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 603)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.BetterListView1)
        Me.Controls.Add(Me.GroupControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPtStatus"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "กำหนดรายการ สภาพผู้ป่วยที่เข้ารับบริการ"
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.txtPrenameTh.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageComboBoxEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label5 As Label
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents cmdSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BetterListView1 As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents chkStatus As CheckBox
    Friend WithEvents txtPrenameTh As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents ImageComboBoxEdit1 As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents Label19 As Label
    Friend WithEvents ImageList1 As ImageList
End Class

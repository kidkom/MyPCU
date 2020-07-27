<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAssetMatFix
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAssetMatFix))
        Me.BetterListView1 = New ComponentOwl.BetterListView.BetterListView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboMat = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboMatType = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboMatGroup = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BetterListView2 = New ComponentOwl.BetterListView.BetterListView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblTotal1 = New System.Windows.Forms.TextBox()
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMatType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMatGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BetterListView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BetterListView1
        '
        Me.BetterListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BetterListView1.CheckBoxes = ComponentOwl.BetterListView.BetterListViewCheckBoxes.TwoState
        Me.BetterListView1.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.BetterListView1.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Sortable
        Me.BetterListView1.Location = New System.Drawing.Point(468, 180)
        Me.BetterListView1.Name = "BetterListView1"
        Me.BetterListView1.Size = New System.Drawing.Size(412, 339)
        Me.BetterListView1.TabIndex = 1162
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(170, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 17)
        Me.Label5.TabIndex = 903
        Me.Label5.Text = "หมวดวัสดุ"
        '
        'GroupControl3
        '
        Me.GroupControl3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl3.Controls.Add(Me.NumericUpDown1)
        Me.GroupControl3.Controls.Add(Me.Label1)
        Me.GroupControl3.Controls.Add(Me.cboMat)
        Me.GroupControl3.Controls.Add(Me.cboMatType)
        Me.GroupControl3.Controls.Add(Me.cboMatGroup)
        Me.GroupControl3.Controls.Add(Me.Label7)
        Me.GroupControl3.Controls.Add(Me.Label6)
        Me.GroupControl3.Controls.Add(Me.Label5)
        Me.GroupControl3.GroupStyle = DevExpress.Utils.GroupStyle.Card
        Me.GroupControl3.Location = New System.Drawing.Point(12, 4)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(868, 152)
        Me.GroupControl3.TabIndex = 1164
        Me.GroupControl3.Text = "รายละเอียดวัสดุที่เบิก"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(234, 114)
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(66, 25)
        Me.NumericUpDown1.TabIndex = 1165
        Me.NumericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NumericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(160, 116)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 17)
        Me.Label1.TabIndex = 1164
        Me.Label1.Text = "จำนวนที่ใช้"
        '
        'cboMat
        '
        Me.cboMat.Location = New System.Drawing.Point(234, 83)
        Me.cboMat.Name = "cboMat"
        Me.cboMat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboMat.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboMat.Size = New System.Drawing.Size(430, 24)
        Me.cboMat.TabIndex = 1163
        '
        'cboMatType
        '
        Me.cboMatType.Location = New System.Drawing.Point(234, 54)
        Me.cboMatType.Name = "cboMatType"
        Me.cboMatType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboMatType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboMatType.Size = New System.Drawing.Size(430, 24)
        Me.cboMatType.TabIndex = 1162
        '
        'cboMatGroup
        '
        Me.cboMatGroup.Location = New System.Drawing.Point(234, 24)
        Me.cboMatGroup.Name = "cboMatGroup"
        Me.cboMatGroup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboMatGroup.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboMatGroup.Size = New System.Drawing.Size(430, 24)
        Me.cboMatGroup.TabIndex = 1161
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(160, 86)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 17)
        Me.Label7.TabIndex = 937
        Me.Label7.Text = "รายการวัสดุ"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(162, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 17)
        Me.Label6.TabIndex = 935
        Me.Label6.Text = "ประเภทวัสดุ"
        '
        'BetterListView2
        '
        Me.BetterListView2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BetterListView2.CheckBoxes = ComponentOwl.BetterListView.BetterListViewCheckBoxes.TwoState
        Me.BetterListView2.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.BetterListView2.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Sortable
        Me.BetterListView2.Location = New System.Drawing.Point(12, 180)
        Me.BetterListView2.Name = "BetterListView2"
        Me.BetterListView2.Size = New System.Drawing.Size(404, 339)
        Me.BetterListView2.TabIndex = 1163
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 160)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 17)
        Me.Label2.TabIndex = 1166
        Me.Label2.Text = "วัสดุใช้"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(465, 160)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 17)
        Me.Label3.TabIndex = 1167
        Me.Label3.Text = "วัสดุที่มี"
        '
        'Button1
        '
        Me.Button1.Image = Global.MyPCU.My.Resources.Resources.a_left
        Me.Button1.Location = New System.Drawing.Point(422, 265)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(40, 29)
        Me.Button1.TabIndex = 1168
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Image = Global.MyPCU.My.Resources.Resources.a_right
        Me.Button2.Location = New System.Drawing.Point(422, 300)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(40, 29)
        Me.Button2.TabIndex = 1169
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(204, 528)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 17)
        Me.Label4.TabIndex = 1171
        Me.Label4.Text = "รวมจำนวนเงิน"
        '
        'lblTotal1
        '
        Me.lblTotal1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotal1.BackColor = System.Drawing.Color.Beige
        Me.lblTotal1.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblTotal1.Location = New System.Drawing.Point(288, 525)
        Me.lblTotal1.Name = "lblTotal1"
        Me.lblTotal1.Size = New System.Drawing.Size(128, 23)
        Me.lblTotal1.TabIndex = 1170
        Me.lblTotal1.Text = "0.00"
        Me.lblTotal1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmAssetMatFix
        '
        Me.Appearance.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 579)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblTotal1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.BetterListView2)
        Me.Controls.Add(Me.BetterListView1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAssetMatFix"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "บันทึกวัสดุที่ใช้ซ่อม"
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        Me.GroupControl3.PerformLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMatType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMatGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BetterListView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BetterListView1 As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents cboMat As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboMatType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboMatGroup As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BetterListView2 As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTotal1 As System.Windows.Forms.TextBox
End Class

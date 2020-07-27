<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDepartmentEdit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDepartmentEdit))
        Me.BetterListView1 = New ComponentOwl.BetterListView.BetterListView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdSearch2 = New System.Windows.Forms.Button()
        Me.chkStatus1 = New System.Windows.Forms.CheckBox()
        Me.chkStatusAll = New System.Windows.Forms.CheckBox()
        Me.chkStatus0 = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
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
        Me.BetterListView1.Location = New System.Drawing.Point(12, 47)
        Me.BetterListView1.Name = "BetterListView1"
        Me.BetterListView1.Size = New System.Drawing.Size(586, 532)
        Me.BetterListView1.TabIndex = 1106
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(568, 15)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(30, 26)
        Me.Button1.TabIndex = 1121
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdSearch2
        '
        Me.cmdSearch2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSearch2.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdSearch2.Image = CType(resources.GetObject("cmdSearch2.Image"), System.Drawing.Image)
        Me.cmdSearch2.Location = New System.Drawing.Point(532, 15)
        Me.cmdSearch2.Name = "cmdSearch2"
        Me.cmdSearch2.Size = New System.Drawing.Size(30, 26)
        Me.cmdSearch2.TabIndex = 1120
        Me.cmdSearch2.UseVisualStyleBackColor = True
        '
        'chkStatus1
        '
        Me.chkStatus1.AutoSize = True
        Me.chkStatus1.Checked = True
        Me.chkStatus1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkStatus1.Location = New System.Drawing.Point(12, 15)
        Me.chkStatus1.Name = "chkStatus1"
        Me.chkStatus1.Size = New System.Drawing.Size(59, 21)
        Me.chkStatus1.TabIndex = 1128
        Me.chkStatus1.Text = "ใช้งาน"
        Me.chkStatus1.UseVisualStyleBackColor = True
        '
        'chkStatusAll
        '
        Me.chkStatusAll.AutoSize = True
        Me.chkStatusAll.Location = New System.Drawing.Point(141, 15)
        Me.chkStatusAll.Name = "chkStatusAll"
        Me.chkStatusAll.Size = New System.Drawing.Size(62, 21)
        Me.chkStatusAll.TabIndex = 1127
        Me.chkStatusAll.Text = "ทั้งหมด"
        Me.chkStatusAll.UseVisualStyleBackColor = True
        '
        'chkStatus0
        '
        Me.chkStatus0.AutoSize = True
        Me.chkStatus0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.chkStatus0.Location = New System.Drawing.Point(77, 15)
        Me.chkStatus0.Name = "chkStatus0"
        Me.chkStatus0.Size = New System.Drawing.Size(58, 21)
        Me.chkStatus0.TabIndex = 1129
        Me.chkStatus0.Text = "ยกเลิก"
        Me.chkStatus0.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 582)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 17)
        Me.Label1.TabIndex = 1130
        Me.Label1.Text = "จำนวน"
        '
        'frmDepartmentEdit
        '
        Me.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(610, 614)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkStatus0)
        Me.Controls.Add(Me.chkStatus1)
        Me.Controls.Add(Me.chkStatusAll)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmdSearch2)
        Me.Controls.Add(Me.BetterListView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDepartmentEdit"
        Me.ShowInTaskbar = False
        Me.Text = "กำหนดแนกการให้บริการ"
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BetterListView1 As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmdSearch2 As System.Windows.Forms.Button
    Friend WithEvents chkStatus1 As System.Windows.Forms.CheckBox
    Friend WithEvents chkStatusAll As System.Windows.Forms.CheckBox
    Friend WithEvents chkStatus0 As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class

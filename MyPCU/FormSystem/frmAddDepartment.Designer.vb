<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddDepartment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddDepartment))
        Me.lblClinic = New System.Windows.Forms.Label()
        Me.cboClinic = New DevExpress.XtraEditors.LookUpEdit()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.txtSubClinic = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkStatus = New System.Windows.Forms.CheckBox()
        CType(Me.cboClinic.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblClinic
        '
        Me.lblClinic.BackColor = System.Drawing.Color.Beige
        Me.lblClinic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblClinic.Location = New System.Drawing.Point(97, 28)
        Me.lblClinic.Name = "lblClinic"
        Me.lblClinic.Size = New System.Drawing.Size(83, 24)
        Me.lblClinic.TabIndex = 1120
        Me.lblClinic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboClinic
        '
        Me.cboClinic.Location = New System.Drawing.Point(186, 28)
        Me.cboClinic.Name = "cboClinic"
        Me.cboClinic.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboClinic.Size = New System.Drawing.Size(331, 24)
        Me.cboClinic.TabIndex = 1119
        '
        'cmdOK
        '
        Me.cmdOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOK.Image = Global.MyPCU.My.Resources.Resources.a_save
        Me.cmdOK.Location = New System.Drawing.Point(425, 120)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(92, 30)
        Me.cmdOK.TabIndex = 1121
        Me.cmdOK.Text = "บันทึก"
        Me.cmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'txtSubClinic
        '
        Me.txtSubClinic.Location = New System.Drawing.Point(97, 58)
        Me.txtSubClinic.Name = "txtSubClinic"
        Me.txtSubClinic.Size = New System.Drawing.Size(420, 25)
        Me.txtSubClinic.TabIndex = 1122
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(54, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 17)
        Me.Label3.TabIndex = 1123
        Me.Label3.Text = "แผนก"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 17)
        Me.Label1.TabIndex = 1124
        Me.Label1.Text = "แผนกย่อย"
        '
        'chkStatus
        '
        Me.chkStatus.AutoSize = True
        Me.chkStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.chkStatus.Location = New System.Drawing.Point(97, 89)
        Me.chkStatus.Name = "chkStatus"
        Me.chkStatus.Size = New System.Drawing.Size(58, 21)
        Me.chkStatus.TabIndex = 1130
        Me.chkStatus.Text = "ยกเลิก"
        Me.chkStatus.UseVisualStyleBackColor = True
        '
        'frmAddDepartment
        '
        Me.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 162)
        Me.Controls.Add(Me.chkStatus)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtSubClinic)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.lblClinic)
        Me.Controls.Add(Me.cboClinic)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAddDepartment"
        Me.Text = "เพิ่ม/แก้ไข แผนกการให้บริการ"
        CType(Me.cboClinic.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblClinic As System.Windows.Forms.Label
    Friend WithEvents cboClinic As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents txtSubClinic As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkStatus As System.Windows.Forms.CheckBox
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectDepartment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelectDepartment))
        Me.lblClinic = New System.Windows.Forms.Label()
        Me.chkClinicShow = New System.Windows.Forms.CheckBox()
        Me.cboClinic = New DevExpress.XtraEditors.LookUpEdit()
        Me.cmdOK = New System.Windows.Forms.Button()
        CType(Me.cboClinic.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblClinic
        '
        Me.lblClinic.BackColor = System.Drawing.Color.Beige
        Me.lblClinic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblClinic.Location = New System.Drawing.Point(58, 33)
        Me.lblClinic.Name = "lblClinic"
        Me.lblClinic.Size = New System.Drawing.Size(83, 24)
        Me.lblClinic.TabIndex = 1118
        Me.lblClinic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkClinicShow
        '
        Me.chkClinicShow.AutoSize = True
        Me.chkClinicShow.Location = New System.Drawing.Point(58, 63)
        Me.chkClinicShow.Name = "chkClinicShow"
        Me.chkClinicShow.Size = New System.Drawing.Size(97, 21)
        Me.chkClinicShow.TabIndex = 1117
        Me.chkClinicShow.Text = "ไม่ต้องแสดงอีก"
        Me.chkClinicShow.UseVisualStyleBackColor = True
        '
        'cboClinic
        '
        Me.cboClinic.Location = New System.Drawing.Point(147, 33)
        Me.cboClinic.Name = "cboClinic"
        Me.cboClinic.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboClinic.Size = New System.Drawing.Size(331, 24)
        Me.cboClinic.TabIndex = 1116
        '
        'cmdOK
        '
        Me.cmdOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOK.Image = Global.MyPCU.My.Resources.Resources.a_save
        Me.cmdOK.Location = New System.Drawing.Point(386, 100)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(92, 30)
        Me.cmdOK.TabIndex = 1119
        Me.cmdOK.Text = "บันทึก"
        Me.cmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'frmSelectDepartment
        '
        Me.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(529, 152)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.lblClinic)
        Me.Controls.Add(Me.chkClinicShow)
        Me.Controls.Add(Me.cboClinic)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSelectDepartment"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "กำหนดแผนกบริการ"
        CType(Me.cboClinic.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblClinic As System.Windows.Forms.Label
    Friend WithEvents chkClinicShow As System.Windows.Forms.CheckBox
    Friend WithEvents cboClinic As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cmdOK As System.Windows.Forms.Button
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGoogleMaps
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGoogleMaps))
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.txtLATITUDE = New System.Windows.Forms.TextBox()
        Me.txtLONGITUDE = New System.Windows.Forms.TextBox()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'WebBrowser1
        '
        Me.WebBrowser1.AllowWebBrowserDrop = False
        Me.WebBrowser1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WebBrowser1.Location = New System.Drawing.Point(11, 7)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 23)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(935, 617)
        Me.WebBrowser1.TabIndex = 907
        '
        'txtLATITUDE
        '
        Me.txtLATITUDE.Location = New System.Drawing.Point(110, 631)
        Me.txtLATITUDE.Name = "txtLATITUDE"
        Me.txtLATITUDE.Size = New System.Drawing.Size(146, 25)
        Me.txtLATITUDE.TabIndex = 910
        Me.txtLATITUDE.Visible = False
        '
        'txtLONGITUDE
        '
        Me.txtLONGITUDE.Location = New System.Drawing.Point(262, 631)
        Me.txtLONGITUDE.Name = "txtLONGITUDE"
        Me.txtLONGITUDE.Size = New System.Drawing.Size(146, 25)
        Me.txtLONGITUDE.TabIndex = 911
        Me.txtLONGITUDE.Visible = False
        '
        'cmdAdd
        '
        Me.cmdAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAdd.Image = Global.MyPCU.My.Resources.Resources.a_save
        Me.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAdd.Location = New System.Drawing.Point(839, 631)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(107, 30)
        Me.cmdAdd.TabIndex = 909
        Me.cmdAdd.Text = " บันทึกข้อมูล"
        Me.cmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'txtLocation
        '
        Me.txtLocation.Location = New System.Drawing.Point(154, 31)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(206, 25)
        Me.txtLocation.TabIndex = 908
        Me.txtLocation.Visible = False
        '
        'frmGoogleMaps
        '
        Me.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(955, 668)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.txtLATITUDE)
        Me.Controls.Add(Me.txtLONGITUDE)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.txtLocation)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmGoogleMaps"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds
        Me.Text = "กำหนดพิกัดบ้าน (ละติจูด, ลองจิจูด)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents txtLATITUDE As System.Windows.Forms.TextBox
    Friend WithEvents txtLONGITUDE As System.Windows.Forms.TextBox
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
End Class

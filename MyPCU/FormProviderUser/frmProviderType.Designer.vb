<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProviderType
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProviderType))
        Me.BetterListView1 = New ComponentOwl.BetterListView.BetterListView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.cboPROVIDERTYPE = New DevExpress.XtraEditors.LookUpEdit()
        Me.chkCancle = New System.Windows.Forms.CheckBox()
        Me.lblProviderCode = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblProviderType = New System.Windows.Forms.Label()
        Me.txtProviderType = New System.Windows.Forms.TextBox()
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.MyPCU.WaitForm1), True, True)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.cboPROVIDERTYPE.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BetterListView1
        '
        Me.BetterListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BetterListView1.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.BetterListView1.FontGroups = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BetterListView1.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Sortable
        Me.BetterListView1.Location = New System.Drawing.Point(12, 183)
        Me.BetterListView1.Name = "BetterListView1"
        Me.BetterListView1.Size = New System.Drawing.Size(965, 393)
        Me.BetterListView1.TabIndex = 928
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 152)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(135, 17)
        Me.Label4.TabIndex = 927
        Me.Label4.Text = "รายการประเภทผู้ให้บริการ"
        '
        'Label30
        '
        Me.Label30.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label30.Location = New System.Drawing.Point(12, 581)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(43, 17)
        Me.Label30.TabIndex = 926
        Me.Label30.Text = "จำนวน"
        '
        'cmdAdd
        '
        Me.cmdAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAdd.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdAdd.Image = Global.MyPCU.My.Resources.Resources.a_add
        Me.cmdAdd.Location = New System.Drawing.Point(892, 144)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(41, 33)
        Me.cmdAdd.TabIndex = 924
        Me.cmdAdd.UseVisualStyleBackColor = True
        Me.cmdAdd.Visible = False
        '
        'cmdEdit
        '
        Me.cmdEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEdit.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdEdit.Image = Global.MyPCU.My.Resources.Resources.a_save
        Me.cmdEdit.Location = New System.Drawing.Point(936, 144)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(41, 33)
        Me.cmdEdit.TabIndex = 925
        Me.cmdEdit.UseVisualStyleBackColor = True
        '
        'GroupControl1
        '
        Me.GroupControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl1.Controls.Add(Me.cboPROVIDERTYPE)
        Me.GroupControl1.Controls.Add(Me.chkCancle)
        Me.GroupControl1.Controls.Add(Me.lblProviderCode)
        Me.GroupControl1.Controls.Add(Me.Label3)
        Me.GroupControl1.Controls.Add(Me.Label2)
        Me.GroupControl1.Controls.Add(Me.lblProviderType)
        Me.GroupControl1.Controls.Add(Me.txtProviderType)
        Me.GroupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Card
        Me.GroupControl1.Location = New System.Drawing.Point(12, 12)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(965, 126)
        Me.GroupControl1.TabIndex = 929
        Me.GroupControl1.Text = "กำหนดประเภทผู้ให้บริการ"
        '
        'cboPROVIDERTYPE
        '
        Me.cboPROVIDERTYPE.Location = New System.Drawing.Point(235, 63)
        Me.cboPROVIDERTYPE.Name = "cboPROVIDERTYPE"
        Me.cboPROVIDERTYPE.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboPROVIDERTYPE.Size = New System.Drawing.Size(696, 24)
        Me.cboPROVIDERTYPE.TabIndex = 1114
        '
        'chkCancle
        '
        Me.chkCancle.AutoSize = True
        Me.chkCancle.ForeColor = System.Drawing.Color.Red
        Me.chkCancle.Location = New System.Drawing.Point(158, 95)
        Me.chkCancle.Name = "chkCancle"
        Me.chkCancle.Size = New System.Drawing.Size(58, 21)
        Me.chkCancle.TabIndex = 922
        Me.chkCancle.Text = "ยกเลิก"
        Me.chkCancle.UseVisualStyleBackColor = True
        '
        'lblProviderCode
        '
        Me.lblProviderCode.BackColor = System.Drawing.Color.Beige
        Me.lblProviderCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProviderCode.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblProviderCode.Location = New System.Drawing.Point(158, 31)
        Me.lblProviderCode.Name = "lblProviderCode"
        Me.lblProviderCode.Size = New System.Drawing.Size(67, 24)
        Me.lblProviderCode.TabIndex = 918
        Me.lblProviderCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 17)
        Me.Label3.TabIndex = 921
        Me.Label3.Text = "กลุ่มผู้ให้บริการมาตรฐาน"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(133, 17)
        Me.Label2.TabIndex = 920
        Me.Label2.Text = "กำหนดประเภทผู้ให้บริการ"
        '
        'lblProviderType
        '
        Me.lblProviderType.BackColor = System.Drawing.Color.Beige
        Me.lblProviderType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProviderType.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblProviderType.Location = New System.Drawing.Point(158, 62)
        Me.lblProviderType.Name = "lblProviderType"
        Me.lblProviderType.Size = New System.Drawing.Size(67, 24)
        Me.lblProviderType.TabIndex = 917
        Me.lblProviderType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtProviderType
        '
        Me.txtProviderType.Location = New System.Drawing.Point(235, 31)
        Me.txtProviderType.Name = "txtProviderType"
        Me.txtProviderType.Size = New System.Drawing.Size(471, 25)
        Me.txtProviderType.TabIndex = 919
        '
        'SplashScreenManager1
        '
        Me.SplashScreenManager1.ClosingDelay = 500
        '
        'Timer1
        '
        '
        'frmProviderType
        '
        Me.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(989, 606)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.BetterListView1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.cmdEdit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmProviderType"
        Me.ShowInTaskbar = False
        Me.ShowMdiChildCaptionInParentTitle = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ประเภทผู้ให้บริการ"
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.cboPROVIDERTYPE.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BetterListView1 As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents chkCancle As System.Windows.Forms.CheckBox
    Friend WithEvents lblProviderCode As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblProviderType As System.Windows.Forms.Label
    Friend WithEvents txtProviderType As System.Windows.Forms.TextBox
    Friend WithEvents cboPROVIDERTYPE As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class

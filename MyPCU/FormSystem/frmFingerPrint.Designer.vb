<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFingerPrint
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFingerPrint))
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.ckbRightIndex = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ckbLeftIndex = New System.Windows.Forms.CheckBox()
        Me.pbPrint4 = New System.Windows.Forms.PictureBox()
        Me.pbPrint3 = New System.Windows.Forms.PictureBox()
        Me.pbPrint2 = New System.Windows.Forms.PictureBox()
        Me.pbPrint1 = New System.Windows.Forms.PictureBox()
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.MyPCU.WaitForm1), True, True)
        CType(Me.pbPrint4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbPrint3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbPrint2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbPrint1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblInfo
        '
        Me.lblInfo.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.Location = New System.Drawing.Point(27, 225)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(360, 42)
        Me.lblInfo.TabIndex = 37
        '
        'btnSubmit
        '
        Me.btnSubmit.AutoSize = True
        Me.btnSubmit.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubmit.Image = Global.MyPCU.My.Resources.Resources.a_save
        Me.btnSubmit.Location = New System.Drawing.Point(406, 228)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(102, 27)
        Me.btnSubmit.TabIndex = 36
        Me.btnSubmit.Text = "บันทึก"
        Me.btnSubmit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSubmit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'ckbRightIndex
        '
        Me.ckbRightIndex.AutoSize = True
        Me.ckbRightIndex.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbRightIndex.Location = New System.Drawing.Point(175, 23)
        Me.ckbRightIndex.Name = "ckbRightIndex"
        Me.ckbRightIndex.Size = New System.Drawing.Size(61, 21)
        Me.ckbRightIndex.TabIndex = 34
        Me.ckbRightIndex.Text = "มือขวา"
        Me.ckbRightIndex.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(27, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 17)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "เลือกมือ :"
        '
        'ckbLeftIndex
        '
        Me.ckbLeftIndex.AutoSize = True
        Me.ckbLeftIndex.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbLeftIndex.Location = New System.Drawing.Point(94, 23)
        Me.ckbLeftIndex.Name = "ckbLeftIndex"
        Me.ckbLeftIndex.Size = New System.Drawing.Size(62, 21)
        Me.ckbLeftIndex.TabIndex = 33
        Me.ckbLeftIndex.Text = "มือซ้าย"
        Me.ckbLeftIndex.UseVisualStyleBackColor = True
        '
        'pbPrint4
        '
        Me.pbPrint4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pbPrint4.Location = New System.Drawing.Point(393, 63)
        Me.pbPrint4.Name = "pbPrint4"
        Me.pbPrint4.Size = New System.Drawing.Size(115, 144)
        Me.pbPrint4.TabIndex = 41
        Me.pbPrint4.TabStop = False
        '
        'pbPrint3
        '
        Me.pbPrint3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pbPrint3.Location = New System.Drawing.Point(272, 63)
        Me.pbPrint3.Name = "pbPrint3"
        Me.pbPrint3.Size = New System.Drawing.Size(115, 144)
        Me.pbPrint3.TabIndex = 40
        Me.pbPrint3.TabStop = False
        '
        'pbPrint2
        '
        Me.pbPrint2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pbPrint2.Location = New System.Drawing.Point(151, 63)
        Me.pbPrint2.Name = "pbPrint2"
        Me.pbPrint2.Size = New System.Drawing.Size(115, 144)
        Me.pbPrint2.TabIndex = 39
        Me.pbPrint2.TabStop = False
        '
        'pbPrint1
        '
        Me.pbPrint1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pbPrint1.Location = New System.Drawing.Point(30, 63)
        Me.pbPrint1.Name = "pbPrint1"
        Me.pbPrint1.Size = New System.Drawing.Size(115, 144)
        Me.pbPrint1.TabIndex = 38
        Me.pbPrint1.TabStop = False
        '
        'SplashScreenManager1
        '
        Me.SplashScreenManager1.ClosingDelay = 500
        '
        'frmFingerPrint
        '
        Me.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 291)
        Me.Controls.Add(Me.pbPrint4)
        Me.Controls.Add(Me.pbPrint3)
        Me.Controls.Add(Me.pbPrint2)
        Me.Controls.Add(Me.pbPrint1)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.ckbRightIndex)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ckbLeftIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmFingerPrint"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "บันทึกข้อมูลลายนิ้วมือ"
        CType(Me.pbPrint4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbPrint3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbPrint2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbPrint1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbPrint4 As System.Windows.Forms.PictureBox
    Friend WithEvents pbPrint3 As System.Windows.Forms.PictureBox
    Friend WithEvents pbPrint2 As System.Windows.Forms.PictureBox
    Friend WithEvents pbPrint1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents ckbRightIndex As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ckbLeftIndex As System.Windows.Forms.CheckBox
    Friend WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServiceQueue
    Inherits DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.FluentDesignFormContainer1 = New DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer()
        Me.CheckBox6 = New System.Windows.Forms.CheckBox()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.cboVaccineType = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpDate1 = New DevExpress.XtraEditors.DateEdit()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BetterListView1 = New ComponentOwl.BetterListView.BetterListView()
        Me.AccordionControl1 = New DevExpress.XtraBars.Navigation.AccordionControl()
        Me.AccordionControlElement1 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement2 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement3 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement4 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement5 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.FluentDesignFormControl1 = New DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl()
        Me.AccordionControlSeparator1 = New DevExpress.XtraBars.Navigation.AccordionControlSeparator()
        Me.AccordionControlSeparator2 = New DevExpress.XtraBars.Navigation.AccordionControlSeparator()
        Me.AccordionControlSeparator3 = New DevExpress.XtraBars.Navigation.AccordionControlSeparator()
        Me.AccordionControlSeparator4 = New DevExpress.XtraBars.Navigation.AccordionControlSeparator()
        Me.FluentDesignFormContainer1.SuspendLayout()
        CType(Me.cboVaccineType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpDate1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpDate1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccordionControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FluentDesignFormControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FluentDesignFormContainer1
        '
        Me.FluentDesignFormContainer1.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.FluentDesignFormContainer1.Appearance.Options.UseBackColor = True
        Me.FluentDesignFormContainer1.Controls.Add(Me.CheckBox6)
        Me.FluentDesignFormContainer1.Controls.Add(Me.CheckBox5)
        Me.FluentDesignFormContainer1.Controls.Add(Me.CheckBox4)
        Me.FluentDesignFormContainer1.Controls.Add(Me.CheckBox3)
        Me.FluentDesignFormContainer1.Controls.Add(Me.CheckBox2)
        Me.FluentDesignFormContainer1.Controls.Add(Me.CheckBox1)
        Me.FluentDesignFormContainer1.Controls.Add(Me.cboVaccineType)
        Me.FluentDesignFormContainer1.Controls.Add(Me.Label1)
        Me.FluentDesignFormContainer1.Controls.Add(Me.dtpDate1)
        Me.FluentDesignFormContainer1.Controls.Add(Me.cmdEdit)
        Me.FluentDesignFormContainer1.Controls.Add(Me.cmdAdd)
        Me.FluentDesignFormContainer1.Controls.Add(Me.Label16)
        Me.FluentDesignFormContainer1.Controls.Add(Me.Label2)
        Me.FluentDesignFormContainer1.Controls.Add(Me.BetterListView1)
        Me.FluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FluentDesignFormContainer1.Location = New System.Drawing.Point(0, 31)
        Me.FluentDesignFormContainer1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.FluentDesignFormContainer1.Name = "FluentDesignFormContainer1"
        Me.FluentDesignFormContainer1.Size = New System.Drawing.Size(897, 652)
        Me.FluentDesignFormContainer1.TabIndex = 0
        '
        'CheckBox6
        '
        Me.CheckBox6.AutoSize = True
        Me.CheckBox6.Location = New System.Drawing.Point(458, 50)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(91, 21)
        Me.CheckBox6.TabIndex = 1261
        Me.CheckBox6.Text = "รับบริการแล้ว"
        Me.CheckBox6.UseVisualStyleBackColor = True
        '
        'CheckBox5
        '
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.Location = New System.Drawing.Point(355, 50)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(97, 21)
        Me.CheckBox5.TabIndex = 1260
        Me.CheckBox5.Text = "กำลังรับบริการ"
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Checked = True
        Me.CheckBox4.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox4.Location = New System.Drawing.Point(226, 50)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(123, 21)
        Me.CheckBox4.TabIndex = 1259
        Me.CheckBox4.Text = "เฉพาะที่รอรับบริการ"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(156, 50)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(62, 21)
        Me.CheckBox3.TabIndex = 1258
        Me.CheckBox3.Text = "ทั้งหมด"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(303, 17)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(86, 21)
        Me.CheckBox2.TabIndex = 1257
        Me.CheckBox2.Text = "เฉพาะแผนก"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(226, 17)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(71, 21)
        Me.CheckBox1.TabIndex = 1256
        Me.CheckBox1.Text = "ทุกแผนก"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'cboVaccineType
        '
        Me.cboVaccineType.Location = New System.Drawing.Point(395, 15)
        Me.cboVaccineType.Name = "cboVaccineType"
        Me.cboVaccineType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboVaccineType.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.cboVaccineType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboVaccineType.Size = New System.Drawing.Size(389, 24)
        Me.cboVaccineType.TabIndex = 1255
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 17)
        Me.Label1.TabIndex = 1254
        Me.Label1.Text = "วันที่รับบริการ"
        '
        'dtpDate1
        '
        Me.dtpDate1.EditValue = Nothing
        Me.dtpDate1.Location = New System.Drawing.Point(91, 15)
        Me.dtpDate1.Name = "dtpDate1"
        Me.dtpDate1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpDate1.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpDate1.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.dtpDate1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtpDate1.Properties.EditFormat.FormatString = "dd/MM/yyyy"
        Me.dtpDate1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtpDate1.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.dtpDate1.Size = New System.Drawing.Size(128, 24)
        Me.dtpDate1.TabIndex = 1253
        '
        'cmdEdit
        '
        Me.cmdEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEdit.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdEdit.Image = Global.MyPCU.My.Resources.Resources.a_edit4
        Me.cmdEdit.Location = New System.Drawing.Point(844, 43)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(38, 26)
        Me.cmdEdit.TabIndex = 1112
        Me.cmdEdit.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        Me.cmdAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAdd.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdAdd.Image = Global.MyPCU.My.Resources.Resources.a_add
        Me.cmdAdd.Location = New System.Drawing.Point(800, 43)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(38, 26)
        Me.cmdAdd.TabIndex = 1111
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label16.Location = New System.Drawing.Point(12, 52)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(138, 17)
        Me.Label16.TabIndex = 1110
        Me.Label16.Text = "รายชื่อผู้รอเข้าคิวรับบริการ"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 617)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 17)
        Me.Label2.TabIndex = 1109
        Me.Label2.Text = "จำนวน"
        '
        'BetterListView1
        '
        Me.BetterListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BetterListView1.Font = New System.Drawing.Font("Leelawadee UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.BetterListView1.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Sortable
        Me.BetterListView1.Location = New System.Drawing.Point(12, 77)
        Me.BetterListView1.Name = "BetterListView1"
        Me.BetterListView1.Size = New System.Drawing.Size(870, 537)
        Me.BetterListView1.TabIndex = 1108
        '
        'AccordionControl1
        '
        Me.AccordionControl1.Dock = System.Windows.Forms.DockStyle.Right
        Me.AccordionControl1.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.AccordionControlElement1})
        Me.AccordionControl1.Location = New System.Drawing.Point(897, 31)
        Me.AccordionControl1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.AccordionControl1.Name = "AccordionControl1"
        Me.AccordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch
        Me.AccordionControl1.Size = New System.Drawing.Size(216, 652)
        Me.AccordionControl1.TabIndex = 1
        Me.AccordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu
        '
        'AccordionControlElement1
        '
        Me.AccordionControlElement1.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.AccordionControlElement2, Me.AccordionControlSeparator1, Me.AccordionControlElement3, Me.AccordionControlSeparator2, Me.AccordionControlElement4, Me.AccordionControlSeparator3, Me.AccordionControlElement5, Me.AccordionControlSeparator4})
        Me.AccordionControlElement1.Expanded = True
        Me.AccordionControlElement1.ImageOptions.Image = Global.MyPCU.My.Resources.Resources.a_search
        Me.AccordionControlElement1.Name = "AccordionControlElement1"
        Me.AccordionControlElement1.Text = "การค้นหา"
        '
        'AccordionControlElement2
        '
        Me.AccordionControlElement2.ImageOptions.Image = Global.MyPCU.My.Resources.Resources.a_home2
        Me.AccordionControlElement2.Name = "AccordionControlElement2"
        Me.AccordionControlElement2.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement2.Text = "ค้นหาจากที่อยู่"
        '
        'AccordionControlElement3
        '
        Me.AccordionControlElement3.ImageOptions.Image = Global.MyPCU.My.Resources.Resources.a_calendar
        Me.AccordionControlElement3.Name = "AccordionControlElement3"
        Me.AccordionControlElement3.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement3.Text = "ค้นหาจากนัดหมาย"
        '
        'AccordionControlElement4
        '
        Me.AccordionControlElement4.ImageOptions.Image = Global.MyPCU.My.Resources.Resources.a_smart_card2
        Me.AccordionControlElement4.Name = "AccordionControlElement4"
        Me.AccordionControlElement4.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement4.Text = "Smart Card"
        '
        'AccordionControlElement5
        '
        Me.AccordionControlElement5.ImageOptions.Image = Global.MyPCU.My.Resources.Resources.a_finger3
        Me.AccordionControlElement5.Name = "AccordionControlElement5"
        Me.AccordionControlElement5.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement5.Text = "ลายนิ้วมือ"
        '
        'FluentDesignFormControl1
        '
        Me.FluentDesignFormControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FluentDesignFormControl1.FluentDesignForm = Me
        Me.FluentDesignFormControl1.Location = New System.Drawing.Point(0, 0)
        Me.FluentDesignFormControl1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.FluentDesignFormControl1.Name = "FluentDesignFormControl1"
        Me.FluentDesignFormControl1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FluentDesignFormControl1.Size = New System.Drawing.Size(1113, 31)
        Me.FluentDesignFormControl1.TabIndex = 2
        Me.FluentDesignFormControl1.TabStop = False
        '
        'AccordionControlSeparator1
        '
        Me.AccordionControlSeparator1.Name = "AccordionControlSeparator1"
        '
        'AccordionControlSeparator2
        '
        Me.AccordionControlSeparator2.Name = "AccordionControlSeparator2"
        '
        'AccordionControlSeparator3
        '
        Me.AccordionControlSeparator3.Name = "AccordionControlSeparator3"
        '
        'AccordionControlSeparator4
        '
        Me.AccordionControlSeparator4.Name = "AccordionControlSeparator4"
        '
        'frmServiceQueue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1113, 683)
        Me.ControlContainer = Me.FluentDesignFormContainer1
        Me.Controls.Add(Me.FluentDesignFormContainer1)
        Me.Controls.Add(Me.AccordionControl1)
        Me.Controls.Add(Me.FluentDesignFormControl1)
        Me.FluentDesignFormControl = Me.FluentDesignFormControl1
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Name = "frmServiceQueue"
        Me.NavigationControl = Me.AccordionControl1
        Me.Text = "คัดกรองเบื้ิองต้น-จัดคิวรับบริการ"
        Me.FluentDesignFormContainer1.ResumeLayout(False)
        Me.FluentDesignFormContainer1.PerformLayout()
        CType(Me.cboVaccineType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpDate1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpDate1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BetterListView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AccordionControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FluentDesignFormControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FluentDesignFormContainer1 As DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer
    Friend WithEvents AccordionControl1 As DevExpress.XtraBars.Navigation.AccordionControl
    Friend WithEvents AccordionControlElement1 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents FluentDesignFormControl1 As DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl
    Friend WithEvents Label2 As Label
    Friend WithEvents BetterListView1 As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents cmdEdit As Button
    Friend WithEvents cmdAdd As Button
    Friend WithEvents Label16 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpDate1 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents CheckBox6 As CheckBox
    Friend WithEvents CheckBox5 As CheckBox
    Friend WithEvents CheckBox4 As CheckBox
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents cboVaccineType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents AccordionControlElement2 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement3 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement4 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement5 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlSeparator1 As DevExpress.XtraBars.Navigation.AccordionControlSeparator
    Friend WithEvents AccordionControlSeparator2 As DevExpress.XtraBars.Navigation.AccordionControlSeparator
    Friend WithEvents AccordionControlSeparator3 As DevExpress.XtraBars.Navigation.AccordionControlSeparator
    Friend WithEvents AccordionControlSeparator4 As DevExpress.XtraBars.Navigation.AccordionControlSeparator
End Class

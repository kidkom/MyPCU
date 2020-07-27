<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportPopMain
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
        Me.components = New System.ComponentModel.Container()
        Me.FluentDesignFormContainer1 = New DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.AccordionControl1 = New DevExpress.XtraBars.Navigation.AccordionControl()
        Me.AccordionControlElement1 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement2 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement4 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement3 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement5 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement6 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement7 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.FluentDesignFormControl1 = New DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl()
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.DocumentManager1 = New DevExpress.XtraBars.Docking2010.DocumentManager(Me.components)
        Me.TabbedView1 = New DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(Me.components)
        Me.FluentDesignFormContainer1.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccordionControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FluentDesignFormControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocumentManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabbedView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FluentDesignFormContainer1
        '
        Me.FluentDesignFormContainer1.Controls.Add(Me.PanelControl1)
        Me.FluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FluentDesignFormContainer1.Location = New System.Drawing.Point(297, 0)
        Me.FluentDesignFormContainer1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.FluentDesignFormContainer1.Name = "FluentDesignFormContainer1"
        Me.FluentDesignFormContainer1.Size = New System.Drawing.Size(796, 631)
        Me.FluentDesignFormContainer1.TabIndex = 0
        '
        'PanelControl1
        '
        Me.PanelControl1.Location = New System.Drawing.Point(96, 224)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(200, 100)
        Me.PanelControl1.TabIndex = 0
        '
        'AccordionControl1
        '
        Me.AccordionControl1.Dock = System.Windows.Forms.DockStyle.Left
        Me.AccordionControl1.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.AccordionControlElement1, Me.AccordionControlElement2, Me.AccordionControlElement4, Me.AccordionControlElement3, Me.AccordionControlElement5, Me.AccordionControlElement6, Me.AccordionControlElement7})
        Me.AccordionControl1.Location = New System.Drawing.Point(0, 0)
        Me.AccordionControl1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.AccordionControl1.Name = "AccordionControl1"
        Me.AccordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch
        Me.AccordionControl1.Size = New System.Drawing.Size(297, 631)
        Me.AccordionControl1.TabIndex = 1
        Me.AccordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu
        '
        'AccordionControlElement1
        '
        Me.AccordionControlElement1.ImageOptions.Image = Global.MyPCU.My.Resources.Resources.a_graph_pyramid
        Me.AccordionControlElement1.Name = "AccordionControlElement1"
        Me.AccordionControlElement1.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement1.Text = "จำนวนประชากรตามโครงสร้างอายุ"
        '
        'AccordionControlElement2
        '
        Me.AccordionControlElement2.ImageOptions.Image = Global.MyPCU.My.Resources.Resources.a_calendar
        Me.AccordionControlElement2.Name = "AccordionControlElement2"
        Me.AccordionControlElement2.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement2.Text = "จำนวนประชากรแยกตามวันเกิด"
        '
        'AccordionControlElement4
        '
        Me.AccordionControlElement4.ImageOptions.Image = Global.MyPCU.My.Resources.Resources.a_home2
        Me.AccordionControlElement4.Name = "AccordionControlElement4"
        Me.AccordionControlElement4.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement4.Text = "จำนวนประชากรแยกตามสถานะการอยู่อาศัย"
        '
        'AccordionControlElement3
        '
        Me.AccordionControlElement3.ImageOptions.Image = Global.MyPCU.My.Resources.Resources.a_occupa
        Me.AccordionControlElement3.Name = "AccordionControlElement3"
        Me.AccordionControlElement3.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement3.Text = "จำนวนประชากรจำแนกตามข้อมูลพื้นฐาน"
        '
        'AccordionControlElement5
        '
        Me.AccordionControlElement5.ImageOptions.Image = Global.MyPCU.My.Resources.Resources.a_question
        Me.AccordionControlElement5.Name = "AccordionControlElement5"
        Me.AccordionControlElement5.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement5.Text = "จำนวนประชากรในเขตฯ ตามเงื่อนไข"
        '
        'AccordionControlElement6
        '
        Me.AccordionControlElement6.ImageOptions.Image = Global.MyPCU.My.Resources.Resources.a_smoking
        Me.AccordionControlElement6.Name = "AccordionControlElement6"
        Me.AccordionControlElement6.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement6.Text = "จำนวนประชากรตามพฤติกรรมสุขภาพ"
        '
        'AccordionControlElement7
        '
        Me.AccordionControlElement7.ImageOptions.Image = Global.MyPCU.My.Resources.Resources.a_location
        Me.AccordionControlElement7.Name = "AccordionControlElement7"
        Me.AccordionControlElement7.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement7.Text = "จำนวนประชากรตาม GIS"
        '
        'FluentDesignFormControl1
        '
        Me.FluentDesignFormControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FluentDesignFormControl1.FluentDesignForm = Me
        Me.FluentDesignFormControl1.Location = New System.Drawing.Point(0, 0)
        Me.FluentDesignFormControl1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.FluentDesignFormControl1.Name = "FluentDesignFormControl1"
        Me.FluentDesignFormControl1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FluentDesignFormControl1.Size = New System.Drawing.Size(1093, 0)
        Me.FluentDesignFormControl1.TabIndex = 2
        Me.FluentDesignFormControl1.TabStop = False
        '
        'DockManager1
        '
        Me.DockManager1.Form = Me
        Me.DockManager1.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.StatusBar", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane", "DevExpress.XtraBars.TabFormControl", "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl"})
        '
        'DocumentManager1
        '
        Me.DocumentManager1.ContainerControl = Me
        Me.DocumentManager1.View = Me.TabbedView1
        Me.DocumentManager1.ViewCollection.AddRange(New DevExpress.XtraBars.Docking2010.Views.BaseView() {Me.TabbedView1})
        '
        'frmReportPopMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1093, 631)
        Me.ControlContainer = Me.FluentDesignFormContainer1
        Me.Controls.Add(Me.FluentDesignFormContainer1)
        Me.Controls.Add(Me.AccordionControl1)
        Me.Controls.Add(Me.FluentDesignFormControl1)
        Me.FluentDesignFormControl = Me.FluentDesignFormControl1
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Name = "frmReportPopMain"
        Me.NavigationControl = Me.AccordionControl1
        Me.Text = "รายงานเกี่ยวกับประชากร"
        Me.FluentDesignFormContainer1.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AccordionControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FluentDesignFormControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocumentManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabbedView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FluentDesignFormContainer1 As DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer
    Friend WithEvents AccordionControl1 As DevExpress.XtraBars.Navigation.AccordionControl
    Friend WithEvents FluentDesignFormControl1 As DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl
    Friend WithEvents AccordionControlElement1 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents DocumentManager1 As DevExpress.XtraBars.Docking2010.DocumentManager
    Friend WithEvents TabbedView1 As DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView
    Friend WithEvents AccordionControlElement2 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement4 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement3 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement5 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement6 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement7 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
End Class

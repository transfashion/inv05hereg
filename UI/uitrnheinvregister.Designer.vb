<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uitrnheinvregister
    Inherits Translib.uiBase

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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uitrnheinvregister))
        Me.ftabMain = New FlatTabControl.FlatTabControl
        Me.ftabMain_List = New System.Windows.Forms.TabPage
        Me.PnlDfMain = New System.Windows.Forms.Panel
        Me.DgvList = New System.Windows.Forms.DataGridView
        Me.PnlDfFooter = New System.Windows.Forms.Panel
        Me.bnList = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.bnPageCount = New System.Windows.Forms.ToolStripLabel
        Me.bnMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.bnMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.bnSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.bnPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.bnSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.bnMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.bnMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.bnSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.bnRefresh = New System.Windows.Forms.ToolStripButton
        Me.bnSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.bnRowCount = New System.Windows.Forms.ToolStripLabel
        Me.bnRowLimit = New System.Windows.Forms.ToolStripTextBox
        Me.PnlDfSearch = New System.Windows.Forms.Panel
        Me.obj_search_cbo_region_id = New System.Windows.Forms.ComboBox
        Me.obj_search_chk_heinvregister_id = New System.Windows.Forms.CheckBox
        Me.obj_search_txt_heinvregister_id = New System.Windows.Forms.TextBox
        Me.obj_search_chk_region_id = New System.Windows.Forms.CheckBox
        Me.obj_search_chk_season_id = New System.Windows.Forms.CheckBox
        Me.obj_search_txt_season_id = New System.Windows.Forms.TextBox
        Me.ftabMain_Data = New System.Windows.Forms.TabPage
        Me.ftabDataDetil = New FlatTabControl.FlatTabControl
        Me.ftabDataDetil_DetilItem = New System.Windows.Forms.TabPage
        Me.DgvDetilItem = New System.Windows.Forms.DataGridView
        Me.ftabDataDetil_Prop = New System.Windows.Forms.TabPage
        Me.DgvProp = New System.Windows.Forms.DataGridView
        Me.ftabDataDetil_Log = New System.Windows.Forms.TabPage
        Me.DgvLog = New System.Windows.Forms.DataGridView
        Me.ftabDataDetil_Record = New System.Windows.Forms.TabPage
        Me.lbl_rowid = New System.Windows.Forms.Label
        Me.obj_rowid = New System.Windows.Forms.TextBox
        Me.obj_heinvregister_createby = New System.Windows.Forms.TextBox
        Me.obj_heinvregister_createdate = New System.Windows.Forms.TextBox
        Me.obj_heinvregister_modifyby = New System.Windows.Forms.TextBox
        Me.obj_heinvregister_modifydate = New System.Windows.Forms.TextBox
        Me.lbl_heinvregister_createby = New System.Windows.Forms.Label
        Me.lbl_heinvregister_createdate = New System.Windows.Forms.Label
        Me.lbl_heinvregister_modifyby = New System.Windows.Forms.Label
        Me.lbl_heinvregister_modifydate = New System.Windows.Forms.Label
        Me.PnlDataMaster = New System.Windows.Forms.Panel
        Me.obj_heinvregister_isseasonupdate = New System.Windows.Forms.CheckBox
        Me.btnUpload = New System.Windows.Forms.Button
        Me.btnPasteFromSpreadSheet = New System.Windows.Forms.Button
        Me.obj_currency_id = New System.Windows.Forms.ComboBox
        Me.btn_season_id = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.obj_season_name = New System.Windows.Forms.Label
        Me.obj_season_id = New System.Windows.Forms.TextBox
        Me.line2 = New System.Windows.Forms.Label
        Me.btn_rekanan_id = New System.Windows.Forms.Button
        Me.obj_rekanan_name = New System.Windows.Forms.Label
        Me.obj_rekanan_id = New System.Windows.Forms.TextBox
        Me.lbl_heinvregister_id = New System.Windows.Forms.Label
        Me.obj_heinvregister_id = New System.Windows.Forms.TextBox
        Me.lbl_heinvregister_date = New System.Windows.Forms.Label
        Me.obj_heinvregister_date = New System.Windows.Forms.DateTimePicker
        Me.lbl_heinvregister_descr = New System.Windows.Forms.Label
        Me.obj_heinvregister_descr = New System.Windows.Forms.TextBox
        Me.obj_heinvregister_issizing = New System.Windows.Forms.CheckBox
        Me.lbl_region_id = New System.Windows.Forms.Label
        Me.obj_region_id = New System.Windows.Forms.ComboBox
        Me.lbl_branch_id = New System.Windows.Forms.Label
        Me.obj_branch_id = New System.Windows.Forms.ComboBox
        Me.lbl_season_id = New System.Windows.Forms.Label
        Me.lbl_rekanan_id = New System.Windows.Forms.Label
        Me.lbl_currency_id = New System.Windows.Forms.Label
        Me.PnlDataFooter = New System.Windows.Forms.Panel
        Me.btnGotoError = New System.Windows.Forms.Button
        Me.obj_heinvregister_isposted = New System.Windows.Forms.CheckBox
        Me.obj_heinvregister_isgenerated = New System.Windows.Forms.CheckBox
        Me.obj_heinvregister_type = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.dsMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabMain.SuspendLayout()
        Me.ftabMain_List.SuspendLayout()
        Me.PnlDfMain.SuspendLayout()
        CType(Me.DgvList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDfFooter.SuspendLayout()
        CType(Me.bnList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnList.SuspendLayout()
        Me.PnlDfSearch.SuspendLayout()
        Me.ftabMain_Data.SuspendLayout()
        Me.ftabDataDetil.SuspendLayout()
        Me.ftabDataDetil_DetilItem.SuspendLayout()
        CType(Me.DgvDetilItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabDataDetil_Prop.SuspendLayout()
        CType(Me.DgvProp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabDataDetil_Log.SuspendLayout()
        CType(Me.DgvLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabDataDetil_Record.SuspendLayout()
        Me.PnlDataMaster.SuspendLayout()
        Me.PnlDataFooter.SuspendLayout()
        Me.SuspendLayout()
        '
        'bgwListLoader
        '
        Me.bgwListLoader.WorkerReportsProgress = True
        Me.bgwListLoader.WorkerSupportsCancellation = True
        '
        'bgwDataLoader
        '
        Me.bgwDataLoader.WorkerReportsProgress = True
        Me.bgwDataLoader.WorkerSupportsCancellation = True
        '
        'bgwSave
        '
        Me.bgwSave.WorkerReportsProgress = True
        Me.bgwSave.WorkerSupportsCancellation = True
        '
        'bgwNew
        '
        Me.bgwNew.WorkerReportsProgress = True
        Me.bgwNew.WorkerSupportsCancellation = True
        '
        'bgwMasterLoaderQueue
        '
        Me.bgwMasterLoaderQueue.WorkerReportsProgress = True
        Me.bgwMasterLoaderQueue.WorkerSupportsCancellation = True
        '
        'bgwMasterLoader
        '
        Me.bgwMasterLoader.WorkerReportsProgress = True
        Me.bgwMasterLoader.WorkerSupportsCancellation = True
        '
        'bgwPrintLoader
        '
        Me.bgwPrintLoader.WorkerReportsProgress = True
        Me.bgwPrintLoader.WorkerSupportsCancellation = True
        '
        'bgwPrintWeb
        '
        Me.bgwPrintWeb.WorkerReportsProgress = True
        Me.bgwPrintWeb.WorkerSupportsCancellation = True
        '
        'bgwDelete
        '
        Me.bgwDelete.WorkerReportsProgress = True
        Me.bgwDelete.WorkerSupportsCancellation = True
        '
        'fLoadingIndicator
        '
        Me.fLoadingIndicator.Location = New System.Drawing.Point(66, 88)
        Me.fLoadingIndicator.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        '
        'ftabMain
        '
        Me.ftabMain.Controls.Add(Me.ftabMain_List)
        Me.ftabMain.Controls.Add(Me.ftabMain_Data)
        Me.ftabMain.Location = New System.Drawing.Point(2, 27)
        Me.ftabMain.Margin = New System.Windows.Forms.Padding(2)
        Me.ftabMain.myBackColor = System.Drawing.Color.White
        Me.ftabMain.Name = "ftabMain"
        Me.ftabMain.SelectedIndex = 0
        Me.ftabMain.Size = New System.Drawing.Size(747, 519)
        Me.ftabMain.TabIndex = 1
        '
        'ftabMain_List
        '
        Me.ftabMain_List.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ftabMain_List.Controls.Add(Me.PnlDfMain)
        Me.ftabMain_List.Controls.Add(Me.PnlDfFooter)
        Me.ftabMain_List.Controls.Add(Me.PnlDfSearch)
        Me.ftabMain_List.Location = New System.Drawing.Point(4, 25)
        Me.ftabMain_List.Name = "ftabMain_List"
        Me.ftabMain_List.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabMain_List.Size = New System.Drawing.Size(739, 490)
        Me.ftabMain_List.TabIndex = 0
        Me.ftabMain_List.Text = "List"
        '
        'PnlDfMain
        '
        Me.PnlDfMain.Controls.Add(Me.DgvList)
        Me.PnlDfMain.Location = New System.Drawing.Point(20, 245)
        Me.PnlDfMain.Name = "PnlDfMain"
        Me.PnlDfMain.Size = New System.Drawing.Size(704, 182)
        Me.PnlDfMain.TabIndex = 1
        '
        'DgvList
        '
        Me.DgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvList.Cursor = System.Windows.Forms.Cursors.Default
        Me.DgvList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvList.Location = New System.Drawing.Point(0, 0)
        Me.DgvList.Name = "DgvList"
        Me.DgvList.Size = New System.Drawing.Size(704, 182)
        Me.DgvList.TabIndex = 0
        '
        'PnlDfFooter
        '
        Me.PnlDfFooter.Controls.Add(Me.bnList)
        Me.PnlDfFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDfFooter.Location = New System.Drawing.Point(3, 459)
        Me.PnlDfFooter.Name = "PnlDfFooter"
        Me.PnlDfFooter.Size = New System.Drawing.Size(733, 28)
        Me.PnlDfFooter.TabIndex = 2
        '
        'bnList
        '
        Me.bnList.AddNewItem = Nothing
        Me.bnList.CountItem = Me.bnPageCount
        Me.bnList.DeleteItem = Nothing
        Me.bnList.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.bnMoveFirstItem, Me.bnMovePreviousItem, Me.bnSeparator, Me.bnPositionItem, Me.bnPageCount, Me.bnSeparator1, Me.bnMoveNextItem, Me.bnMoveLastItem, Me.bnSeparator2, Me.bnRefresh, Me.bnSeparator3, Me.bnRowCount, Me.bnRowLimit})
        Me.bnList.Location = New System.Drawing.Point(0, 3)
        Me.bnList.MoveFirstItem = Me.bnMoveFirstItem
        Me.bnList.MoveLastItem = Me.bnMoveLastItem
        Me.bnList.MoveNextItem = Me.bnMoveNextItem
        Me.bnList.MovePreviousItem = Me.bnMovePreviousItem
        Me.bnList.Name = "bnList"
        Me.bnList.PositionItem = Me.bnPositionItem
        Me.bnList.Size = New System.Drawing.Size(733, 25)
        Me.bnList.TabIndex = 2
        Me.bnList.Text = "BindingNavigator1"
        '
        'bnPageCount
        '
        Me.bnPageCount.Name = "bnPageCount"
        Me.bnPageCount.Size = New System.Drawing.Size(35, 22)
        Me.bnPageCount.Text = "of {0}"
        Me.bnPageCount.ToolTipText = "Total number of items"
        '
        'bnMoveFirstItem
        '
        Me.bnMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bnMoveFirstItem.Image = CType(resources.GetObject("bnMoveFirstItem.Image"), System.Drawing.Image)
        Me.bnMoveFirstItem.Name = "bnMoveFirstItem"
        Me.bnMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.bnMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.bnMoveFirstItem.Text = "Move first"
        '
        'bnMovePreviousItem
        '
        Me.bnMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bnMovePreviousItem.Image = CType(resources.GetObject("bnMovePreviousItem.Image"), System.Drawing.Image)
        Me.bnMovePreviousItem.Name = "bnMovePreviousItem"
        Me.bnMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.bnMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.bnMovePreviousItem.Text = "Move previous"
        '
        'bnSeparator
        '
        Me.bnSeparator.Name = "bnSeparator"
        Me.bnSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'bnPositionItem
        '
        Me.bnPositionItem.AccessibleName = "Position"
        Me.bnPositionItem.AutoSize = False
        Me.bnPositionItem.MaxLength = 5
        Me.bnPositionItem.Name = "bnPositionItem"
        Me.bnPositionItem.Size = New System.Drawing.Size(50, 21)
        Me.bnPositionItem.Text = "0"
        Me.bnPositionItem.ToolTipText = "Current position"
        '
        'bnSeparator1
        '
        Me.bnSeparator1.Name = "bnSeparator1"
        Me.bnSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'bnMoveNextItem
        '
        Me.bnMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bnMoveNextItem.Image = CType(resources.GetObject("bnMoveNextItem.Image"), System.Drawing.Image)
        Me.bnMoveNextItem.Name = "bnMoveNextItem"
        Me.bnMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.bnMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.bnMoveNextItem.Text = "Move next"
        '
        'bnMoveLastItem
        '
        Me.bnMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bnMoveLastItem.Image = CType(resources.GetObject("bnMoveLastItem.Image"), System.Drawing.Image)
        Me.bnMoveLastItem.Name = "bnMoveLastItem"
        Me.bnMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.bnMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.bnMoveLastItem.Text = "Move last"
        '
        'bnSeparator2
        '
        Me.bnSeparator2.Name = "bnSeparator2"
        Me.bnSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'bnRefresh
        '
        Me.bnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bnRefresh.Enabled = False
        Me.bnRefresh.Image = CType(resources.GetObject("bnRefresh.Image"), System.Drawing.Image)
        Me.bnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.bnRefresh.Name = "bnRefresh"
        Me.bnRefresh.Size = New System.Drawing.Size(23, 22)
        Me.bnRefresh.Text = "Refresh"
        '
        'bnSeparator3
        '
        Me.bnSeparator3.Name = "bnSeparator3"
        Me.bnSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'bnRowCount
        '
        Me.bnRowCount.Name = "bnRowCount"
        Me.bnRowCount.Size = New System.Drawing.Size(52, 22)
        Me.bnRowCount.Text = "{0} Rows"
        Me.bnRowCount.Visible = False
        '
        'bnRowLimit
        '
        Me.bnRowLimit.MaxLength = 3
        Me.bnRowLimit.Name = "bnRowLimit"
        Me.bnRowLimit.Size = New System.Drawing.Size(30, 25)
        Me.bnRowLimit.Text = "30"
        Me.bnRowLimit.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PnlDfSearch
        '
        Me.PnlDfSearch.Controls.Add(Me.obj_search_cbo_region_id)
        Me.PnlDfSearch.Controls.Add(Me.obj_search_chk_heinvregister_id)
        Me.PnlDfSearch.Controls.Add(Me.obj_search_txt_heinvregister_id)
        Me.PnlDfSearch.Controls.Add(Me.obj_search_chk_region_id)
        Me.PnlDfSearch.Controls.Add(Me.obj_search_chk_season_id)
        Me.PnlDfSearch.Controls.Add(Me.obj_search_txt_season_id)
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(733, 126)
        Me.PnlDfSearch.TabIndex = 0
        '
        'obj_search_cbo_region_id
        '
        Me.obj_search_cbo_region_id.DropDownHeight = 200
        Me.obj_search_cbo_region_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.obj_search_cbo_region_id.IntegralHeight = False
        Me.obj_search_cbo_region_id.Location = New System.Drawing.Point(464, 33)
        Me.obj_search_cbo_region_id.MaxDropDownItems = 4
        Me.obj_search_cbo_region_id.Name = "obj_search_cbo_region_id"
        Me.obj_search_cbo_region_id.Size = New System.Drawing.Size(152, 21)
        Me.obj_search_cbo_region_id.TabIndex = 14
        '
        'obj_search_chk_heinvregister_id
        '
        Me.obj_search_chk_heinvregister_id.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.obj_search_chk_heinvregister_id.Location = New System.Drawing.Point(6, 32)
        Me.obj_search_chk_heinvregister_id.Name = "obj_search_chk_heinvregister_id"
        Me.obj_search_chk_heinvregister_id.Size = New System.Drawing.Size(88, 19)
        Me.obj_search_chk_heinvregister_id.TabIndex = 0
        Me.obj_search_chk_heinvregister_id.Text = "ID"
        Me.obj_search_chk_heinvregister_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.obj_search_chk_heinvregister_id.UseVisualStyleBackColor = True
        '
        'obj_search_txt_heinvregister_id
        '
        Me.obj_search_txt_heinvregister_id.Location = New System.Drawing.Point(100, 32)
        Me.obj_search_txt_heinvregister_id.Name = "obj_search_txt_heinvregister_id"
        Me.obj_search_txt_heinvregister_id.Size = New System.Drawing.Size(178, 20)
        Me.obj_search_txt_heinvregister_id.TabIndex = 1
        '
        'obj_search_chk_region_id
        '
        Me.obj_search_chk_region_id.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.obj_search_chk_region_id.Checked = True
        Me.obj_search_chk_region_id.CheckState = System.Windows.Forms.CheckState.Checked
        Me.obj_search_chk_region_id.Enabled = False
        Me.obj_search_chk_region_id.Location = New System.Drawing.Point(370, 33)
        Me.obj_search_chk_region_id.Name = "obj_search_chk_region_id"
        Me.obj_search_chk_region_id.Size = New System.Drawing.Size(88, 19)
        Me.obj_search_chk_region_id.TabIndex = 2
        Me.obj_search_chk_region_id.Text = "Region"
        Me.obj_search_chk_region_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.obj_search_chk_region_id.UseVisualStyleBackColor = True
        '
        'obj_search_chk_season_id
        '
        Me.obj_search_chk_season_id.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.obj_search_chk_season_id.Location = New System.Drawing.Point(6, 58)
        Me.obj_search_chk_season_id.Name = "obj_search_chk_season_id"
        Me.obj_search_chk_season_id.Size = New System.Drawing.Size(88, 19)
        Me.obj_search_chk_season_id.TabIndex = 4
        Me.obj_search_chk_season_id.Text = "Season"
        Me.obj_search_chk_season_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.obj_search_chk_season_id.UseVisualStyleBackColor = True
        '
        'obj_search_txt_season_id
        '
        Me.obj_search_txt_season_id.Location = New System.Drawing.Point(100, 58)
        Me.obj_search_txt_season_id.Name = "obj_search_txt_season_id"
        Me.obj_search_txt_season_id.Size = New System.Drawing.Size(178, 20)
        Me.obj_search_txt_season_id.TabIndex = 5
        '
        'ftabMain_Data
        '
        Me.ftabMain_Data.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ftabMain_Data.Controls.Add(Me.ftabDataDetil)
        Me.ftabMain_Data.Controls.Add(Me.PnlDataMaster)
        Me.ftabMain_Data.Controls.Add(Me.PnlDataFooter)
        Me.ftabMain_Data.Location = New System.Drawing.Point(4, 25)
        Me.ftabMain_Data.Name = "ftabMain_Data"
        Me.ftabMain_Data.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabMain_Data.Size = New System.Drawing.Size(739, 490)
        Me.ftabMain_Data.TabIndex = 1
        Me.ftabMain_Data.Text = "Data"
        '
        'ftabDataDetil
        '
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_DetilItem)
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_Prop)
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_Log)
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_Record)
        Me.ftabDataDetil.Location = New System.Drawing.Point(3, 156)
        Me.ftabDataDetil.Margin = New System.Windows.Forms.Padding(0)
        Me.ftabDataDetil.myBackColor = System.Drawing.Color.WhiteSmoke
        Me.ftabDataDetil.Name = "ftabDataDetil"
        Me.ftabDataDetil.SelectedIndex = 0
        Me.ftabDataDetil.Size = New System.Drawing.Size(733, 279)
        Me.ftabDataDetil.TabIndex = 3
        '
        'ftabDataDetil_DetilItem
        '
        Me.ftabDataDetil_DetilItem.Controls.Add(Me.DgvDetilItem)
        Me.ftabDataDetil_DetilItem.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_DetilItem.Name = "ftabDataDetil_DetilItem"
        Me.ftabDataDetil_DetilItem.Size = New System.Drawing.Size(725, 250)
        Me.ftabDataDetil_DetilItem.TabIndex = 0
        Me.ftabDataDetil_DetilItem.Text = "Item"
        '
        'DgvDetilItem
        '
        Me.DgvDetilItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvDetilItem.Location = New System.Drawing.Point(3, 3)
        Me.DgvDetilItem.Name = "DgvDetilItem"
        Me.DgvDetilItem.Size = New System.Drawing.Size(719, 244)
        Me.DgvDetilItem.TabIndex = 0
        '
        'ftabDataDetil_Prop
        '
        Me.ftabDataDetil_Prop.BackColor = System.Drawing.Color.LemonChiffon
        Me.ftabDataDetil_Prop.Controls.Add(Me.DgvProp)
        Me.ftabDataDetil_Prop.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Prop.Name = "ftabDataDetil_Prop"
        Me.ftabDataDetil_Prop.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabDataDetil_Prop.Size = New System.Drawing.Size(725, 250)
        Me.ftabDataDetil_Prop.TabIndex = 0
        Me.ftabDataDetil_Prop.Text = "Property"
        '
        'DgvProp
        '
        Me.DgvProp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvProp.Location = New System.Drawing.Point(3, 3)
        Me.DgvProp.Name = "DgvProp"
        Me.DgvProp.Size = New System.Drawing.Size(719, 244)
        Me.DgvProp.TabIndex = 2
        '
        'ftabDataDetil_Log
        '
        Me.ftabDataDetil_Log.BackColor = System.Drawing.Color.Beige
        Me.ftabDataDetil_Log.Controls.Add(Me.DgvLog)
        Me.ftabDataDetil_Log.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Log.Name = "ftabDataDetil_Log"
        Me.ftabDataDetil_Log.Size = New System.Drawing.Size(725, 250)
        Me.ftabDataDetil_Log.TabIndex = 6
        Me.ftabDataDetil_Log.Text = "Log"
        '
        'DgvLog
        '
        Me.DgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvLog.Location = New System.Drawing.Point(3, 3)
        Me.DgvLog.Name = "DgvLog"
        Me.DgvLog.Size = New System.Drawing.Size(719, 244)
        Me.DgvLog.TabIndex = 2
        '
        'ftabDataDetil_Record
        '
        Me.ftabDataDetil_Record.BackColor = System.Drawing.Color.Gainsboro
        Me.ftabDataDetil_Record.Controls.Add(Me.lbl_rowid)
        Me.ftabDataDetil_Record.Controls.Add(Me.obj_rowid)
        Me.ftabDataDetil_Record.Controls.Add(Me.obj_heinvregister_createby)
        Me.ftabDataDetil_Record.Controls.Add(Me.obj_heinvregister_createdate)
        Me.ftabDataDetil_Record.Controls.Add(Me.obj_heinvregister_modifyby)
        Me.ftabDataDetil_Record.Controls.Add(Me.obj_heinvregister_modifydate)
        Me.ftabDataDetil_Record.Controls.Add(Me.lbl_heinvregister_createby)
        Me.ftabDataDetil_Record.Controls.Add(Me.lbl_heinvregister_createdate)
        Me.ftabDataDetil_Record.Controls.Add(Me.lbl_heinvregister_modifyby)
        Me.ftabDataDetil_Record.Controls.Add(Me.lbl_heinvregister_modifydate)
        Me.ftabDataDetil_Record.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Record.Name = "ftabDataDetil_Record"
        Me.ftabDataDetil_Record.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabDataDetil_Record.Size = New System.Drawing.Size(725, 250)
        Me.ftabDataDetil_Record.TabIndex = 0
        Me.ftabDataDetil_Record.Text = "Record"
        '
        'lbl_rowid
        '
        Me.lbl_rowid.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_rowid.Location = New System.Drawing.Point(326, 8)
        Me.lbl_rowid.Name = "lbl_rowid"
        Me.lbl_rowid.Size = New System.Drawing.Size(80, 20)
        Me.lbl_rowid.TabIndex = 0
        Me.lbl_rowid.Text = "rowid"
        Me.lbl_rowid.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'obj_rowid
        '
        Me.obj_rowid.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_rowid.Location = New System.Drawing.Point(412, 8)
        Me.obj_rowid.Name = "obj_rowid"
        Me.obj_rowid.ReadOnly = True
        Me.obj_rowid.Size = New System.Drawing.Size(282, 20)
        Me.obj_rowid.TabIndex = 5
        '
        'obj_heinvregister_createby
        '
        Me.obj_heinvregister_createby.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_heinvregister_createby.Location = New System.Drawing.Point(93, 8)
        Me.obj_heinvregister_createby.Name = "obj_heinvregister_createby"
        Me.obj_heinvregister_createby.ReadOnly = True
        Me.obj_heinvregister_createby.Size = New System.Drawing.Size(152, 20)
        Me.obj_heinvregister_createby.TabIndex = 6
        '
        'obj_heinvregister_createdate
        '
        Me.obj_heinvregister_createdate.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_heinvregister_createdate.Location = New System.Drawing.Point(93, 34)
        Me.obj_heinvregister_createdate.Name = "obj_heinvregister_createdate"
        Me.obj_heinvregister_createdate.ReadOnly = True
        Me.obj_heinvregister_createdate.Size = New System.Drawing.Size(152, 20)
        Me.obj_heinvregister_createdate.TabIndex = 7
        '
        'obj_heinvregister_modifyby
        '
        Me.obj_heinvregister_modifyby.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_heinvregister_modifyby.Location = New System.Drawing.Point(93, 60)
        Me.obj_heinvregister_modifyby.Name = "obj_heinvregister_modifyby"
        Me.obj_heinvregister_modifyby.ReadOnly = True
        Me.obj_heinvregister_modifyby.Size = New System.Drawing.Size(152, 20)
        Me.obj_heinvregister_modifyby.TabIndex = 8
        '
        'obj_heinvregister_modifydate
        '
        Me.obj_heinvregister_modifydate.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_heinvregister_modifydate.Location = New System.Drawing.Point(93, 86)
        Me.obj_heinvregister_modifydate.Name = "obj_heinvregister_modifydate"
        Me.obj_heinvregister_modifydate.ReadOnly = True
        Me.obj_heinvregister_modifydate.Size = New System.Drawing.Size(152, 20)
        Me.obj_heinvregister_modifydate.TabIndex = 9
        '
        'lbl_heinvregister_createby
        '
        Me.lbl_heinvregister_createby.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_heinvregister_createby.Location = New System.Drawing.Point(7, 8)
        Me.lbl_heinvregister_createby.Name = "lbl_heinvregister_createby"
        Me.lbl_heinvregister_createby.Size = New System.Drawing.Size(80, 20)
        Me.lbl_heinvregister_createby.TabIndex = 1
        Me.lbl_heinvregister_createby.Text = "Create By"
        Me.lbl_heinvregister_createby.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_heinvregister_createdate
        '
        Me.lbl_heinvregister_createdate.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_heinvregister_createdate.Location = New System.Drawing.Point(7, 34)
        Me.lbl_heinvregister_createdate.Name = "lbl_heinvregister_createdate"
        Me.lbl_heinvregister_createdate.Size = New System.Drawing.Size(80, 20)
        Me.lbl_heinvregister_createdate.TabIndex = 2
        Me.lbl_heinvregister_createdate.Text = "Create Date"
        Me.lbl_heinvregister_createdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_heinvregister_modifyby
        '
        Me.lbl_heinvregister_modifyby.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_heinvregister_modifyby.Location = New System.Drawing.Point(7, 60)
        Me.lbl_heinvregister_modifyby.Name = "lbl_heinvregister_modifyby"
        Me.lbl_heinvregister_modifyby.Size = New System.Drawing.Size(80, 20)
        Me.lbl_heinvregister_modifyby.TabIndex = 3
        Me.lbl_heinvregister_modifyby.Text = "Modify By"
        Me.lbl_heinvregister_modifyby.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_heinvregister_modifydate
        '
        Me.lbl_heinvregister_modifydate.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_heinvregister_modifydate.Location = New System.Drawing.Point(7, 86)
        Me.lbl_heinvregister_modifydate.Name = "lbl_heinvregister_modifydate"
        Me.lbl_heinvregister_modifydate.Size = New System.Drawing.Size(80, 20)
        Me.lbl_heinvregister_modifydate.TabIndex = 4
        Me.lbl_heinvregister_modifydate.Text = "Modify Date"
        Me.lbl_heinvregister_modifydate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PnlDataMaster
        '
        Me.PnlDataMaster.AutoScroll = True
        Me.PnlDataMaster.Controls.Add(Me.Label2)
        Me.PnlDataMaster.Controls.Add(Me.obj_heinvregister_type)
        Me.PnlDataMaster.Controls.Add(Me.obj_heinvregister_isseasonupdate)
        Me.PnlDataMaster.Controls.Add(Me.btnUpload)
        Me.PnlDataMaster.Controls.Add(Me.btnPasteFromSpreadSheet)
        Me.PnlDataMaster.Controls.Add(Me.obj_currency_id)
        Me.PnlDataMaster.Controls.Add(Me.btn_season_id)
        Me.PnlDataMaster.Controls.Add(Me.Label1)
        Me.PnlDataMaster.Controls.Add(Me.obj_season_name)
        Me.PnlDataMaster.Controls.Add(Me.obj_season_id)
        Me.PnlDataMaster.Controls.Add(Me.line2)
        Me.PnlDataMaster.Controls.Add(Me.btn_rekanan_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_rekanan_name)
        Me.PnlDataMaster.Controls.Add(Me.obj_rekanan_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_heinvregister_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_heinvregister_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_heinvregister_date)
        Me.PnlDataMaster.Controls.Add(Me.obj_heinvregister_date)
        Me.PnlDataMaster.Controls.Add(Me.lbl_heinvregister_descr)
        Me.PnlDataMaster.Controls.Add(Me.obj_heinvregister_descr)
        Me.PnlDataMaster.Controls.Add(Me.obj_heinvregister_issizing)
        Me.PnlDataMaster.Controls.Add(Me.lbl_region_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_region_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_branch_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_branch_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_season_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_rekanan_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_currency_id)
        Me.PnlDataMaster.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDataMaster.Location = New System.Drawing.Point(3, 3)
        Me.PnlDataMaster.Name = "PnlDataMaster"
        Me.PnlDataMaster.Size = New System.Drawing.Size(733, 150)
        Me.PnlDataMaster.TabIndex = 0
        '
        'obj_heinvregister_isseasonupdate
        '
        Me.obj_heinvregister_isseasonupdate.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Bold)
        Me.obj_heinvregister_isseasonupdate.Location = New System.Drawing.Point(571, 44)
        Me.obj_heinvregister_isseasonupdate.Name = "obj_heinvregister_isseasonupdate"
        Me.obj_heinvregister_isseasonupdate.Size = New System.Drawing.Size(102, 20)
        Me.obj_heinvregister_isseasonupdate.TabIndex = 149
        Me.obj_heinvregister_isseasonupdate.Text = "Update Season"
        '
        'btnUpload
        '
        Me.btnUpload.Location = New System.Drawing.Point(571, 125)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(151, 22)
        Me.btnUpload.TabIndex = 148
        Me.btnUpload.Text = "Upload"
        Me.btnUpload.UseVisualStyleBackColor = True
        '
        'btnPasteFromSpreadSheet
        '
        Me.btnPasteFromSpreadSheet.Location = New System.Drawing.Point(571, 97)
        Me.btnPasteFromSpreadSheet.Name = "btnPasteFromSpreadSheet"
        Me.btnPasteFromSpreadSheet.Size = New System.Drawing.Size(151, 22)
        Me.btnPasteFromSpreadSheet.TabIndex = 147
        Me.btnPasteFromSpreadSheet.Text = "Paste From SpreadSheed"
        Me.btnPasteFromSpreadSheet.UseVisualStyleBackColor = True
        '
        'obj_currency_id
        '
        Me.obj_currency_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.obj_currency_id.FormattingEnabled = True
        Me.obj_currency_id.Location = New System.Drawing.Point(416, 16)
        Me.obj_currency_id.Name = "obj_currency_id"
        Me.obj_currency_id.Size = New System.Drawing.Size(58, 21)
        Me.obj_currency_id.TabIndex = 146
        '
        'btn_season_id
        '
        Me.btn_season_id.Location = New System.Drawing.Point(546, 44)
        Me.btn_season_id.Name = "btn_season_id"
        Me.btn_season_id.Size = New System.Drawing.Size(18, 18)
        Me.btn_season_id.TabIndex = 145
        Me.btn_season_id.Text = "..."
        Me.btn_season_id.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkGray
        Me.Label1.Location = New System.Drawing.Point(459, 63)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 1)
        Me.Label1.TabIndex = 144
        '
        'obj_season_name
        '
        Me.obj_season_name.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.obj_season_name.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obj_season_name.ForeColor = System.Drawing.Color.DimGray
        Me.obj_season_name.Location = New System.Drawing.Point(465, 48)
        Me.obj_season_name.Name = "obj_season_name"
        Me.obj_season_name.Size = New System.Drawing.Size(53, 13)
        Me.obj_season_name.TabIndex = 143
        Me.obj_season_name.Text = "obj_season_name"
        '
        'obj_season_id
        '
        Me.obj_season_id.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_season_id.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.obj_season_id.Location = New System.Drawing.Point(416, 43)
        Me.obj_season_id.MaxLength = 3
        Me.obj_season_id.Name = "obj_season_id"
        Me.obj_season_id.ReadOnly = True
        Me.obj_season_id.Size = New System.Drawing.Size(43, 20)
        Me.obj_season_id.TabIndex = 142
        '
        'line2
        '
        Me.line2.BackColor = System.Drawing.Color.DarkGray
        Me.line2.Location = New System.Drawing.Point(488, 89)
        Me.line2.Margin = New System.Windows.Forms.Padding(0)
        Me.line2.Name = "line2"
        Me.line2.Size = New System.Drawing.Size(234, 1)
        Me.line2.TabIndex = 113
        '
        'btn_rekanan_id
        '
        Me.btn_rekanan_id.Location = New System.Drawing.Point(704, 70)
        Me.btn_rekanan_id.Name = "btn_rekanan_id"
        Me.btn_rekanan_id.Size = New System.Drawing.Size(18, 18)
        Me.btn_rekanan_id.TabIndex = 112
        Me.btn_rekanan_id.Text = "..."
        Me.btn_rekanan_id.UseVisualStyleBackColor = True
        '
        'obj_rekanan_name
        '
        Me.obj_rekanan_name.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.obj_rekanan_name.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obj_rekanan_name.ForeColor = System.Drawing.Color.DimGray
        Me.obj_rekanan_name.Location = New System.Drawing.Point(493, 73)
        Me.obj_rekanan_name.Name = "obj_rekanan_name"
        Me.obj_rekanan_name.Size = New System.Drawing.Size(205, 13)
        Me.obj_rekanan_name.TabIndex = 111
        Me.obj_rekanan_name.Text = "rekanan_nameg"
        '
        'obj_rekanan_id
        '
        Me.obj_rekanan_id.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_rekanan_id.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.obj_rekanan_id.Location = New System.Drawing.Point(416, 70)
        Me.obj_rekanan_id.Name = "obj_rekanan_id"
        Me.obj_rekanan_id.ReadOnly = True
        Me.obj_rekanan_id.Size = New System.Drawing.Size(72, 20)
        Me.obj_rekanan_id.TabIndex = 110
        '
        'lbl_heinvregister_id
        '
        Me.lbl_heinvregister_id.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_heinvregister_id.Location = New System.Drawing.Point(7, 13)
        Me.lbl_heinvregister_id.Name = "lbl_heinvregister_id"
        Me.lbl_heinvregister_id.Size = New System.Drawing.Size(80, 20)
        Me.lbl_heinvregister_id.TabIndex = 0
        Me.lbl_heinvregister_id.Text = "ID"
        Me.lbl_heinvregister_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'obj_heinvregister_id
        '
        Me.obj_heinvregister_id.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_heinvregister_id.Location = New System.Drawing.Point(93, 17)
        Me.obj_heinvregister_id.Name = "obj_heinvregister_id"
        Me.obj_heinvregister_id.ReadOnly = True
        Me.obj_heinvregister_id.Size = New System.Drawing.Size(152, 20)
        Me.obj_heinvregister_id.TabIndex = 1
        '
        'lbl_heinvregister_date
        '
        Me.lbl_heinvregister_date.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_heinvregister_date.Location = New System.Drawing.Point(7, 39)
        Me.lbl_heinvregister_date.Name = "lbl_heinvregister_date"
        Me.lbl_heinvregister_date.Size = New System.Drawing.Size(80, 20)
        Me.lbl_heinvregister_date.TabIndex = 2
        Me.lbl_heinvregister_date.Text = "Date"
        Me.lbl_heinvregister_date.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'obj_heinvregister_date
        '
        Me.obj_heinvregister_date.CustomFormat = "dd/MM/yyyy"
        Me.obj_heinvregister_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.obj_heinvregister_date.Location = New System.Drawing.Point(93, 43)
        Me.obj_heinvregister_date.Name = "obj_heinvregister_date"
        Me.obj_heinvregister_date.Size = New System.Drawing.Size(88, 20)
        Me.obj_heinvregister_date.TabIndex = 3
        '
        'lbl_heinvregister_descr
        '
        Me.lbl_heinvregister_descr.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_heinvregister_descr.Location = New System.Drawing.Point(7, 120)
        Me.lbl_heinvregister_descr.Name = "lbl_heinvregister_descr"
        Me.lbl_heinvregister_descr.Size = New System.Drawing.Size(80, 20)
        Me.lbl_heinvregister_descr.TabIndex = 4
        Me.lbl_heinvregister_descr.Text = "Descr"
        Me.lbl_heinvregister_descr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'obj_heinvregister_descr
        '
        Me.obj_heinvregister_descr.Location = New System.Drawing.Point(93, 124)
        Me.obj_heinvregister_descr.Name = "obj_heinvregister_descr"
        Me.obj_heinvregister_descr.Size = New System.Drawing.Size(227, 20)
        Me.obj_heinvregister_descr.TabIndex = 5
        '
        'obj_heinvregister_issizing
        '
        Me.obj_heinvregister_issizing.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Bold)
        Me.obj_heinvregister_issizing.Location = New System.Drawing.Point(416, 124)
        Me.obj_heinvregister_issizing.Name = "obj_heinvregister_issizing"
        Me.obj_heinvregister_issizing.Size = New System.Drawing.Size(102, 20)
        Me.obj_heinvregister_issizing.TabIndex = 7
        Me.obj_heinvregister_issizing.Text = "Sizing"
        '
        'lbl_region_id
        '
        Me.lbl_region_id.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_region_id.Location = New System.Drawing.Point(7, 66)
        Me.lbl_region_id.Name = "lbl_region_id"
        Me.lbl_region_id.Size = New System.Drawing.Size(80, 20)
        Me.lbl_region_id.TabIndex = 12
        Me.lbl_region_id.Text = "Region"
        Me.lbl_region_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'obj_region_id
        '
        Me.obj_region_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.obj_region_id.Location = New System.Drawing.Point(93, 70)
        Me.obj_region_id.Name = "obj_region_id"
        Me.obj_region_id.Size = New System.Drawing.Size(152, 21)
        Me.obj_region_id.TabIndex = 13
        '
        'lbl_branch_id
        '
        Me.lbl_branch_id.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_branch_id.Location = New System.Drawing.Point(7, 93)
        Me.lbl_branch_id.Name = "lbl_branch_id"
        Me.lbl_branch_id.Size = New System.Drawing.Size(80, 20)
        Me.lbl_branch_id.TabIndex = 14
        Me.lbl_branch_id.Text = "Branch"
        Me.lbl_branch_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'obj_branch_id
        '
        Me.obj_branch_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.obj_branch_id.Location = New System.Drawing.Point(93, 97)
        Me.obj_branch_id.Name = "obj_branch_id"
        Me.obj_branch_id.Size = New System.Drawing.Size(152, 21)
        Me.obj_branch_id.TabIndex = 15
        '
        'lbl_season_id
        '
        Me.lbl_season_id.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_season_id.Location = New System.Drawing.Point(330, 47)
        Me.lbl_season_id.Name = "lbl_season_id"
        Me.lbl_season_id.Size = New System.Drawing.Size(80, 20)
        Me.lbl_season_id.TabIndex = 16
        Me.lbl_season_id.Text = "Season"
        Me.lbl_season_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_rekanan_id
        '
        Me.lbl_rekanan_id.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_rekanan_id.Location = New System.Drawing.Point(330, 70)
        Me.lbl_rekanan_id.Name = "lbl_rekanan_id"
        Me.lbl_rekanan_id.Size = New System.Drawing.Size(80, 20)
        Me.lbl_rekanan_id.TabIndex = 18
        Me.lbl_rekanan_id.Text = "Rekanan"
        Me.lbl_rekanan_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_currency_id
        '
        Me.lbl_currency_id.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_currency_id.Location = New System.Drawing.Point(330, 17)
        Me.lbl_currency_id.Name = "lbl_currency_id"
        Me.lbl_currency_id.Size = New System.Drawing.Size(80, 20)
        Me.lbl_currency_id.TabIndex = 20
        Me.lbl_currency_id.Text = "Currency"
        Me.lbl_currency_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PnlDataFooter
        '
        Me.PnlDataFooter.Controls.Add(Me.btnGotoError)
        Me.PnlDataFooter.Controls.Add(Me.obj_heinvregister_isposted)
        Me.PnlDataFooter.Controls.Add(Me.obj_heinvregister_isgenerated)
        Me.PnlDataFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDataFooter.Location = New System.Drawing.Point(3, 438)
        Me.PnlDataFooter.Name = "PnlDataFooter"
        Me.PnlDataFooter.Size = New System.Drawing.Size(733, 49)
        Me.PnlDataFooter.TabIndex = 2
        '
        'btnGotoError
        '
        Me.btnGotoError.Location = New System.Drawing.Point(150, 21)
        Me.btnGotoError.Name = "btnGotoError"
        Me.btnGotoError.Size = New System.Drawing.Size(65, 22)
        Me.btnGotoError.TabIndex = 149
        Me.btnGotoError.Text = "Goto Error"
        Me.btnGotoError.UseVisualStyleBackColor = True
        '
        'obj_heinvregister_isposted
        '
        Me.obj_heinvregister_isposted.Enabled = False
        Me.obj_heinvregister_isposted.Location = New System.Drawing.Point(9, 3)
        Me.obj_heinvregister_isposted.Name = "obj_heinvregister_isposted"
        Me.obj_heinvregister_isposted.Size = New System.Drawing.Size(152, 20)
        Me.obj_heinvregister_isposted.TabIndex = 9
        Me.obj_heinvregister_isposted.Text = "Posted"
        '
        'obj_heinvregister_isgenerated
        '
        Me.obj_heinvregister_isgenerated.Enabled = False
        Me.obj_heinvregister_isgenerated.Location = New System.Drawing.Point(9, 23)
        Me.obj_heinvregister_isgenerated.Name = "obj_heinvregister_isgenerated"
        Me.obj_heinvregister_isgenerated.Size = New System.Drawing.Size(152, 20)
        Me.obj_heinvregister_isgenerated.TabIndex = 11
        Me.obj_heinvregister_isgenerated.Text = "Generated"
        '
        'obj_heinvregister_type
        '
        Me.obj_heinvregister_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.obj_heinvregister_type.Location = New System.Drawing.Point(416, 96)
        Me.obj_heinvregister_type.Name = "obj_heinvregister_type"
        Me.obj_heinvregister_type.Size = New System.Drawing.Size(137, 21)
        Me.obj_heinvregister_type.TabIndex = 150
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(330, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 20)
        Me.Label2.TabIndex = 151
        Me.Label2.Text = "Type"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'uitrnheinvregister
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackgroundworkerStatus = Translib.uiBase.EBackgroundworkerStatus.Done
        Me.Controls.Add(Me.ftabMain)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Message = "Done. "
        Me.Name = "uitrnheinvregister"
        Me.Progress = 20
        Me.Status = "Loading Data..."
        Me.Controls.SetChildIndex(Me.ftabMain, 0)
        CType(Me.dsMaster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabMain.ResumeLayout(False)
        Me.ftabMain_List.ResumeLayout(False)
        Me.PnlDfMain.ResumeLayout(False)
        CType(Me.DgvList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDfFooter.ResumeLayout(False)
        Me.PnlDfFooter.PerformLayout()
        CType(Me.bnList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnList.ResumeLayout(False)
        Me.bnList.PerformLayout()
        Me.PnlDfSearch.ResumeLayout(False)
        Me.PnlDfSearch.PerformLayout()
        Me.ftabMain_Data.ResumeLayout(False)
        Me.ftabDataDetil.ResumeLayout(False)
        Me.ftabDataDetil_DetilItem.ResumeLayout(False)
        CType(Me.DgvDetilItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabDataDetil_Prop.ResumeLayout(False)
        CType(Me.DgvProp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabDataDetil_Log.ResumeLayout(False)
        CType(Me.DgvLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabDataDetil_Record.ResumeLayout(False)
        Me.ftabDataDetil_Record.PerformLayout()
        Me.PnlDataMaster.ResumeLayout(False)
        Me.PnlDataMaster.PerformLayout()
        Me.PnlDataFooter.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub



    Friend WithEvents ftabMain_List As System.Windows.Forms.TabPage
    Friend WithEvents bnList As System.Windows.Forms.BindingNavigator
    Friend WithEvents bnMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents bnMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents bnMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents bnMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents bnPageCount As System.Windows.Forms.ToolStripLabel
    Friend WithEvents bnPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents bnRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents bnRowCount As System.Windows.Forms.ToolStripLabel
    Friend WithEvents bnRowLimit As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents bnSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents bnSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents bnSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents bnSeparator3 As System.Windows.Forms.ToolStripSeparator

    Friend WithEvents DgvDetilItem As System.Windows.Forms.DataGridView

    Friend WithEvents DgvList As System.Windows.Forms.DataGridView
    Friend WithEvents DgvLog As System.Windows.Forms.DataGridView
    Friend WithEvents DgvProp As System.Windows.Forms.DataGridView
    Friend WithEvents ftabDataDetil As FlatTabControl.FlatTabControl

    Friend WithEvents ftabDataDetil_DetilItem As System.Windows.Forms.TabPage
    Friend WithEvents ftabDataDetil_Log As System.Windows.Forms.TabPage
    Friend WithEvents ftabDataDetil_Prop As System.Windows.Forms.TabPage
    Friend WithEvents ftabDataDetil_Record As System.Windows.Forms.TabPage
    Friend WithEvents ftabMain_Data As System.Windows.Forms.TabPage

    Friend WithEvents lbl_heinvregister_id As System.Windows.Forms.Label
    Friend WithEvents lbl_heinvregister_date As System.Windows.Forms.Label
    Friend WithEvents lbl_heinvregister_descr As System.Windows.Forms.Label
    Friend WithEvents lbl_heinvregister_createby As System.Windows.Forms.Label
    Friend WithEvents lbl_heinvregister_createdate As System.Windows.Forms.Label
    Friend WithEvents lbl_heinvregister_modifyby As System.Windows.Forms.Label
    Friend WithEvents lbl_heinvregister_modifydate As System.Windows.Forms.Label
    Friend WithEvents lbl_region_id As System.Windows.Forms.Label
    Friend WithEvents lbl_branch_id As System.Windows.Forms.Label
    Friend WithEvents lbl_season_id As System.Windows.Forms.Label
    Friend WithEvents lbl_rekanan_id As System.Windows.Forms.Label
    Friend WithEvents lbl_currency_id As System.Windows.Forms.Label
    Friend WithEvents lbl_rowid As System.Windows.Forms.Label

    Friend WithEvents obj_heinvregister_id As System.Windows.Forms.TextBox
    Friend WithEvents obj_heinvregister_date As System.Windows.Forms.DateTimePicker
    Friend WithEvents obj_heinvregister_descr As System.Windows.Forms.TextBox
    Friend WithEvents obj_heinvregister_issizing As System.Windows.Forms.CheckBox
    Friend WithEvents obj_heinvregister_isposted As System.Windows.Forms.CheckBox
    Friend WithEvents obj_heinvregister_isgenerated As System.Windows.Forms.CheckBox
    Friend WithEvents obj_heinvregister_createby As System.Windows.Forms.TextBox
    Friend WithEvents obj_heinvregister_createdate As System.Windows.Forms.TextBox
    Friend WithEvents obj_heinvregister_modifyby As System.Windows.Forms.TextBox
    Friend WithEvents obj_heinvregister_modifydate As System.Windows.Forms.TextBox
    Friend WithEvents obj_region_id As System.Windows.Forms.ComboBox
    Friend WithEvents obj_branch_id As System.Windows.Forms.ComboBox
    Friend WithEvents obj_rowid As System.Windows.Forms.TextBox


    Friend WithEvents obj_search_chk_heinvregister_id As System.Windows.Forms.CheckBox
    Friend WithEvents obj_search_txt_heinvregister_id As System.Windows.Forms.TextBox
    Friend WithEvents obj_search_chk_region_id As System.Windows.Forms.CheckBox
    Friend WithEvents obj_search_chk_season_id As System.Windows.Forms.CheckBox
    Friend WithEvents obj_search_txt_season_id As System.Windows.Forms.TextBox


    Friend WithEvents PnlDataFooter As System.Windows.Forms.Panel
    Friend WithEvents PnlDataMaster As System.Windows.Forms.Panel
    Friend WithEvents PnlDfFooter As System.Windows.Forms.Panel
    Friend WithEvents PnlDfMain As System.Windows.Forms.Panel
    Friend WithEvents PnlDfSearch As System.Windows.Forms.Panel
    Public WithEvents ftabMain As FlatTabControl.FlatTabControl
    Friend WithEvents obj_search_cbo_region_id As System.Windows.Forms.ComboBox
    Friend WithEvents line2 As System.Windows.Forms.Label
    Friend WithEvents btn_rekanan_id As System.Windows.Forms.Button
    Friend WithEvents obj_rekanan_name As System.Windows.Forms.Label
    Friend WithEvents obj_rekanan_id As System.Windows.Forms.TextBox
    Friend WithEvents btn_season_id As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents obj_season_name As System.Windows.Forms.Label
    Friend WithEvents obj_season_id As System.Windows.Forms.TextBox
    Friend WithEvents obj_currency_id As System.Windows.Forms.ComboBox
    Friend WithEvents btnPasteFromSpreadSheet As System.Windows.Forms.Button
    Friend WithEvents btnUpload As System.Windows.Forms.Button
    Friend WithEvents btnGotoError As System.Windows.Forms.Button
    Friend WithEvents obj_heinvregister_isseasonupdate As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents obj_heinvregister_type As System.Windows.Forms.ComboBox

End Class


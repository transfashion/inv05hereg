Public Class uitrnheinvregister
    Public Const SelectedDefaultText As String = "-- PILIH --"
    Public Const TxtBtnPasteFromSpreadsheed As String = "Paste From SpreadSheed"
    Public Const TxtBtnPasteFromSpreadsheedCancel As String = "Cancel"

    Private startInfo As ProcessStartInfo

    Private _FormErrorProvider As ErrorProvider
    Private tblDetilItem As DataTable
    Private LastRow As Long = 0

    Public WithEvents bgwPaste As System.ComponentModel.BackgroundWorker
    Public WithEvents bgwUpload As System.ComponentModel.BackgroundWorker
    Public WithEvents bgwLoadDetil As System.ComponentModel.BackgroundWorker

    Friend ProgName As String


    Delegate Sub BackgroundworkerAddDetilItemRowsInvokeFunction(ByVal strRowContent() As String, ByVal sizing As Boolean)
    Delegate Sub BackgroundworkerMergeTableDetilItemInvokeFunction(ByVal tbl As DataTable)



#Region " Constructor "

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        MyBase.InitializeControl(Config.DeveloperDefaultSessionID, Config.DeveloperDefaultUserName, Config.WebserviceAddress, Config.DllServer, Nothing, Me.GetType().Assembly)



        Me.Title = "Register Item"
        Me.ProgName = "register_base"

        ' Customizable Form
        Me.tblList = CreateDatasetList()
        Me.tblList_Temp = CreateDatasetData()
        Me.tblDetilItem = CreateDatasetDetilItem()
        Me.tblProp = CreateDatasetProp()
        Me.tblLog = CreateDatasetLog()

        Me.LayoutUI()

        Me.PrimaryKeyObjectName = "obj_heinvregister_id"

        Me.WebserviceNS = "inv05"
        Me.WebserviceObject = "uitrnheinvregister"
        Me.WebserviceNSModule = Config.WebserviceNSModule
        Me.WebserviceObjectModule = Config.WebserviceObjectModule

        Me.ddBinding.Add("DetilItem", Me.tblDetilItem, "ftabDataDetil_DetilItem", "DgvDetilItem", False, True)
        Me.ddBinding.Add("Prop", Me.tblProp, "ftabDataDetil_Prop", "DgvProp", False, False)
        Me.ddBinding.Add("Log", Me.tblLog, "ftabDataDetil_Log", "DgvLog", True, False)

        'Data Master
        Me.dsMaster.Tables.Add("master_region")
        Me.dsMaster.Tables.Add("master_branch")
        Me.dsMaster.Tables.Add("master_currency")
        Me.dsMaster.Tables.Add("master_registertype")

        'Master Loader
        Me.MasterLoaderDelay = 50
        Me.MasterDataLoaderQueue.Add("master_region", "master_region", CreateWebService(Me.WebserviceNSGlobal, Me.WebserviceObjectGlobal, "load_regiontopparent_byuser_login"), "")
        Me.MasterDataLoaderQueue.Add("master_branch", "master_branch", CreateWebService(Me.WebserviceNSGlobal, Me.WebserviceObjectGlobal, "load_branch_byuser_login"), "")
        Me.MasterDataLoaderQueue.Add("master_currency", "master_currency", CreateWebService(Me.WebserviceNSGlobal, Me.WebserviceObjectGlobal, "load_currency_all"), "")

        'Printing
        Me.AllowPrintOnList = True
        Me.AllowPrintOnData = True
        Me.DllPrint = Config.DllPrint
        Me.DllPrintRDLC = Config.DllPrintRDLC
        Me.WebserviceDataprintLoader = CreateWebService(Me.WebserviceNSModule, Me.WebserviceObjectModule, "print")
        Me.WebserviceDataprintPageViewer = CreateWebService(Me.WebserviceNSModule, Me.WebserviceObjectModule, "print_web")


        Me._FormErrorProvider = New ErrorProvider

        Me.Height = 419
    End Sub

    Public Overrides Sub ConstructTableDetil()
        Me.ddBinding.Tables("DetilItem").Table = CreateDatasetDetilItem()
        Me.ddBinding.Tables("Prop").Table = CreateDatasetProp()
        Me.ddBinding.Tables("Log").Table = CreateDatasetLog()
    End Sub

    Public Overloads Function InitializeControl(ByVal session_id As String, ByVal username As String, ByVal webserviceaddress As String, ByVal dllserver As String, ByRef browser As Object) As Boolean
        MyBase.InitializeControl(session_id, username, webserviceaddress, dllserver, Nothing, Me.GetType().Assembly)
        Me.StartupMessage = " "
        Return True
    End Function

#End Region

#Region " Dataset Main "

    Public Shared Function CreateDatasetList() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()

        tbl.Columns.Add(New DataColumn("heinvregister_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinvregister_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("heinvregister_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinvregister_issizing", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("heinvregister_isposted", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("heinvregister_isgenerated", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("heinvregister_createby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinvregister_createdate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("heinvregister_modifyby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinvregister_modifydate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("region_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("branch_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("season_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rowid", GetType(System.String)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("heinvregister_id").DefaultValue = ""
        tbl.Columns("heinvregister_date").DefaultValue = Now()
        tbl.Columns("heinvregister_descr").DefaultValue = ""
        tbl.Columns("heinvregister_issizing").DefaultValue = False
        tbl.Columns("heinvregister_isposted").DefaultValue = False
        tbl.Columns("heinvregister_isgenerated").DefaultValue = False
        tbl.Columns("heinvregister_createby").DefaultValue = ""
        tbl.Columns("heinvregister_createdate").DefaultValue = Now()
        tbl.Columns("heinvregister_modifyby").DefaultValue = ""
        tbl.Columns("heinvregister_modifydate").DefaultValue = Now()
        tbl.Columns("region_id").DefaultValue = "0"
        tbl.Columns("branch_id").DefaultValue = "0"
        tbl.Columns("season_id").DefaultValue = "0"
        tbl.Columns("rekanan_id").DefaultValue = "0"
        tbl.Columns("currency_id").DefaultValue = "0"
        tbl.Columns("rowid").DefaultValue = ""

        tbl.PrimaryKey = New System.Data.DataColumn() {tbl.Columns("heinvregister_id")}

        Return tbl
    End Function

    Public Shared Function CreateDatasetData() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("heinvregister_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinvregister_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("heinvregister_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinvregister_type", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinvregister_issizing", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("heinvregister_isposted", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("heinvregister_isgenerated", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("heinvregister_isseasonupdate", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("heinvregister_createby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinvregister_createdate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("heinvregister_modifyby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinvregister_modifydate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("region_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("branch_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("season_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("season_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("totaldetilrows", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("rowid", GetType(System.String)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("heinvregister_id").DefaultValue = ""
        tbl.Columns("heinvregister_date").DefaultValue = Now()
        tbl.Columns("heinvregister_descr").DefaultValue = ""
        tbl.Columns("heinvregister_type").DefaultValue = "0"
        tbl.Columns("heinvregister_issizing").DefaultValue = False
        tbl.Columns("heinvregister_isposted").DefaultValue = False
        tbl.Columns("heinvregister_isgenerated").DefaultValue = False
        tbl.Columns("heinvregister_isseasonupdate").DefaultValue = False
        tbl.Columns("heinvregister_createby").DefaultValue = ""
        tbl.Columns("heinvregister_createdate").DefaultValue = Now()
        tbl.Columns("heinvregister_modifyby").DefaultValue = ""
        tbl.Columns("heinvregister_modifydate").DefaultValue = Now()
        tbl.Columns("region_id").DefaultValue = "0"
        tbl.Columns("branch_id").DefaultValue = "0"
        tbl.Columns("season_id").DefaultValue = "0"
        tbl.Columns("season_name").DefaultValue = ""
        tbl.Columns("rekanan_id").DefaultValue = "0"
        tbl.Columns("rekanan_name").DefaultValue = ""
        tbl.Columns("currency_id").DefaultValue = "USD"
        tbl.Columns("totaldetilrows").DefaultValue = 0
        tbl.Columns("rowid").DefaultValue = ""

        tbl.PrimaryKey = New System.Data.DataColumn() {tbl.Columns("heinvregister_id")}

        Return tbl
    End Function

    Public Shared Function CreateDatasetDetilItem_A() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Add(New DataColumn("heinvregister_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinvregisteritem_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("heinv_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinv_art", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinv_mat", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinv_col", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinv_size", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinv_barcode", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinv_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinv_descr", GetType(System.String)))

        tbl.Columns.Add(New DataColumn("heinv_pline", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinv_pgroup", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinv_pcategory", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinv_colordescr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinv_gender", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinv_fit", GetType(System.String)))

        tbl.Columns.Add(New DataColumn("heinv_hscode_ship", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("heinv_hscode_ina", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("heinv_plbname", GetType(System.String)))

        tbl.Columns.Add(New DataColumn("heinv_box", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinv_gtype", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinv_produk", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinv_bahan", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinv_pemeliharaan", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinv_logo", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinv_dibuatdi", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinv_other1", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinv_other2", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinv_other3", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinv_other4", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinv_other5", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinv_price", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("heinvgro_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinvgro_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinvctg_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinvctg_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinvctg_sizetag", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("branch_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("branch_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinv_isweb", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("heinv_weight", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("heinv_length", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("heinv_width", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("heinv_height", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("heinv_webdescr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("C00", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("C01", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("C02", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("C03", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("C04", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("C05", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("C06", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("C07", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("C08", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("C09", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("C10", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("C11", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("C12", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("C13", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("C14", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("C15", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("C16", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("C17", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("C18", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("C19", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("C20", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("C21", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("C22", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("C23", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("C24", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("C25", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("err", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("rowid", GetType(System.String)))

        '-------------------------------
        'Default Value:
        tbl.Columns("heinvregister_id").DefaultValue = ""
        tbl.Columns("heinvregisteritem_line").DefaultValue = 0
        tbl.Columns("heinv_id").DefaultValue = ""
        tbl.Columns("heinv_art").DefaultValue = ""
        tbl.Columns("heinv_mat").DefaultValue = ""
        tbl.Columns("heinv_col").DefaultValue = ""
        tbl.Columns("heinv_size").DefaultValue = ""
        tbl.Columns("heinv_barcode").DefaultValue = ""
        tbl.Columns("heinv_name").DefaultValue = ""
        tbl.Columns("heinv_descr").DefaultValue = ""
        tbl.Columns("heinv_pline").DefaultValue = ""
        tbl.Columns("heinv_pgroup").DefaultValue = ""
        tbl.Columns("heinv_pcategory").DefaultValue = ""
        tbl.Columns("heinv_colordescr").DefaultValue = ""
        tbl.Columns("heinv_gender").DefaultValue = ""
        tbl.Columns("heinv_fit").DefaultValue = ""
        tbl.Columns("heinv_hscode_ship").DefaultValue = 0
        tbl.Columns("heinv_hscode_ina").DefaultValue = 0
        tbl.Columns("heinv_plbname").DefaultValue = ""
        tbl.Columns("heinv_box").DefaultValue = ""
        tbl.Columns("heinv_gtype").DefaultValue = ""
        tbl.Columns("heinv_box").DefaultValue = ""
        tbl.Columns("heinv_produk").DefaultValue = ""
        tbl.Columns("heinv_bahan").DefaultValue = ""
        tbl.Columns("heinv_pemeliharaan").DefaultValue = ""
        tbl.Columns("heinv_logo").DefaultValue = ""
        tbl.Columns("heinv_dibuatdi").DefaultValue = ""
        tbl.Columns("heinv_other1").DefaultValue = ""
        tbl.Columns("heinv_other2").DefaultValue = ""
        tbl.Columns("heinv_other3").DefaultValue = ""
        tbl.Columns("heinv_other4").DefaultValue = ""
        tbl.Columns("heinv_other5").DefaultValue = ""
        tbl.Columns("heinv_price").DefaultValue = 0
        tbl.Columns("heinvgro_id").DefaultValue = ""
        tbl.Columns("heinvgro_name").DefaultValue = ""
        tbl.Columns("heinvctg_id").DefaultValue = ""
        tbl.Columns("heinvctg_name").DefaultValue = ""
        tbl.Columns("heinvctg_sizetag").DefaultValue = ""
        tbl.Columns("branch_id").DefaultValue = ""
        tbl.Columns("branch_name").DefaultValue = ""
        tbl.Columns("heinv_isweb").DefaultValue = False
        tbl.Columns("heinv_weight").DefaultValue = 0
        tbl.Columns("heinv_length").DefaultValue = 0
        tbl.Columns("heinv_width").DefaultValue = 0
        tbl.Columns("heinv_height").DefaultValue = 0
        tbl.Columns("heinv_webdescr").DefaultValue = ""
        tbl.Columns("C00").DefaultValue = 0
        tbl.Columns("C01").DefaultValue = 0
        tbl.Columns("C02").DefaultValue = 0
        tbl.Columns("C03").DefaultValue = 0
        tbl.Columns("C04").DefaultValue = 0
        tbl.Columns("C05").DefaultValue = 0
        tbl.Columns("C06").DefaultValue = 0
        tbl.Columns("C07").DefaultValue = 0
        tbl.Columns("C08").DefaultValue = 0
        tbl.Columns("C09").DefaultValue = 0
        tbl.Columns("C10").DefaultValue = 0
        tbl.Columns("C11").DefaultValue = 0
        tbl.Columns("C12").DefaultValue = 0
        tbl.Columns("C13").DefaultValue = 0
        tbl.Columns("C14").DefaultValue = 0
        tbl.Columns("C15").DefaultValue = 0
        tbl.Columns("C16").DefaultValue = 0
        tbl.Columns("C17").DefaultValue = 0
        tbl.Columns("C18").DefaultValue = 0
        tbl.Columns("C19").DefaultValue = 0
        tbl.Columns("C20").DefaultValue = 0
        tbl.Columns("C21").DefaultValue = 0
        tbl.Columns("C22").DefaultValue = 0
        tbl.Columns("C23").DefaultValue = 0
        tbl.Columns("C24").DefaultValue = 0
        tbl.Columns("C25").DefaultValue = 0
        tbl.Columns("err").DefaultValue = 99
        tbl.Columns("rowid").DefaultValue = ""

        Return tbl
    End Function

    Public Shared Function CreateDatasetDetilItem() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl = CreateDatasetDetilItem_A()
        tbl.PrimaryKey = New System.Data.DataColumn() {tbl.Columns("heinvregister_id"), tbl.Columns("heinvregisteritem_line")}
        With tbl.Columns("heinvregisteritem_line")
            .DefaultValue = DBNull.Value
            .AutoIncrement = True
            .AutoIncrementSeed = 10
            .AutoIncrementStep = 10
        End With

        Return tbl
    End Function

    Public Shared Function CreateDatasetProp() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("prop_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("prop_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("prop_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("prop_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("prop_value", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rowid", GetType(System.String)))



        '-------------------------------
        'Default Value: 
        tbl.Columns("prop_id").DefaultValue = ""
        tbl.Columns("prop_line").DefaultValue = 0
        tbl.Columns("prop_name").DefaultValue = ""
        tbl.Columns("prop_descr").DefaultValue = ""
        tbl.Columns("prop_value").DefaultValue = ""
        tbl.Columns("rowid").DefaultValue = ""

        '--------------------------------
        ' Behaviours
        tbl.PrimaryKey = New System.Data.DataColumn() {tbl.Columns("prop_id"), tbl.Columns("prop_line")}
        With tbl.Columns("prop_line")
            .DefaultValue = DBNull.Value
            .AutoIncrement = True
            .AutoIncrementSeed = 10
            .AutoIncrementStep = 10
        End With


        Return tbl
    End Function

    Public Shared Function CreateDatasetLog() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("log_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("log_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("log_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("log_action", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("log_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("log_table", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("log_lastvalue", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("log_username", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rowid", GetType(System.String)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("log_id").DefaultValue = ""
        tbl.Columns("log_line").DefaultValue = 0
        tbl.Columns("log_date").DefaultValue = Now()
        tbl.Columns("log_action").DefaultValue = ""
        tbl.Columns("log_descr").DefaultValue = ""
        tbl.Columns("log_table").DefaultValue = ""
        tbl.Columns("log_lastvalue").DefaultValue = ""
        tbl.Columns("log_username").DefaultValue = ""
        tbl.Columns("rowid").DefaultValue = ""

        '--------------------------------
        ' Behaviours
        tbl.PrimaryKey = New System.Data.DataColumn() {tbl.Columns("log_id"), tbl.Columns("log_line")}
        With tbl.Columns("log_line")
            .DefaultValue = DBNull.Value
            .AutoIncrement = True
            .AutoIncrementSeed = 10
            .AutoIncrementStep = 10
        End With

        Return tbl
    End Function

#End Region

#Region " Layout & Init UI "

    Private Function LayoutUI() As Boolean
        Me.AnchorAll(New Object() { _
            Me.ftabMain, _
            Me.ftabDataDetil, _
            Me.DgvDetilItem, _
            Me.DgvProp, _
            Me.DgvLog _
        })

        Me.PnlDfMain.Dock = DockStyle.Fill
        Me.ftabMain_SelectedIndexChanged(Me.ftabMain, New System.EventArgs)

        FormatDgvList(Me.DgvList)
        FormatDgvDetilItem(Me.DgvDetilItem)

        FormatDgvProp(Me.DgvProp)
        FormatDgvLog(Me.DgvLog)

        Me.ToolStrip1.Enabled = True
        Me.ToolStrip1.Visible = True


        Me.obj_heinvregister_isseasonupdate.Visible = False


    End Function

    Public Shared Function FormatDgvList(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format DgvMstIteminventory Columns 
        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
         { _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinvregister_id", "ID", "heinvregister_id", 100, DataGridViewContentAlignment.MiddleLeft, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinvregister_date", "Date", "heinvregister_date", 100, DataGridViewContentAlignment.MiddleLeft, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinvregister_descr", "Descr", "heinvregister_descr", 100, DataGridViewContentAlignment.MiddleLeft, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewCheckBoxColumn, "heinvregister_issizing", "Sizing", "heinvregister_issizing", 100), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewCheckBoxColumn, "heinvregister_isposted", "Posted", "heinvregister_isposted", 100), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewCheckBoxColumn, "heinvregister_isgenerated", "Gen", "heinvregister_isgenerated", 100), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinvregister_createby", "Create By", "heinvregister_createby", 100, DataGridViewContentAlignment.MiddleLeft, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinvregister_createdate", "Create Date", "heinvregister_createdate", 100, DataGridViewContentAlignment.MiddleLeft, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "region_id", "Region", "region_id", 100, DataGridViewContentAlignment.MiddleLeft, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "season_id", "Season", "season_id", 100, DataGridViewContentAlignment.MiddleLeft, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "rowid", "rowid", "rowid", 100) _
         })

        objDgv.Columns("rowid").Visible = False


        ' DgvMstIteminventory Behaviours: 
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.AutoGenerateColumns = False
        objDgv.ReadOnly = True
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        objDgv.MultiSelect = False
     
    End Function

    Public Shared Function FormatDgvDetilItem(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        { _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinvregisteritem_line", "Line", "heinvregisteritem_line", 100, DataGridViewContentAlignment.MiddleLeft, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinv_id", "ID", "heinv_id", 100, DataGridViewContentAlignment.MiddleLeft, True, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinv_art", "ART", "heinv_art", 100, DataGridViewContentAlignment.MiddleLeft, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinv_mat", "MAT", "heinv_mat", 100, DataGridViewContentAlignment.MiddleLeft, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinv_col", "COL", "heinv_col", 100, DataGridViewContentAlignment.MiddleLeft, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinv_size", "SIZE", "heinv_size", 40, DataGridViewContentAlignment.MiddleLeft, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinv_barcode", "Barcode", "heinv_barcode", 100, DataGridViewContentAlignment.MiddleLeft, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinv_name", "Name", "heinv_name", 150, DataGridViewContentAlignment.MiddleLeft, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinv_descr", "Descr", "heinv_descr", 200, DataGridViewContentAlignment.MiddleLeft, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinv_pline", "Pcp.Line", "heinv_pline", 100, DataGridViewContentAlignment.MiddleLeft, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinv_pgroup", "Pcp.Group", "heinv_pgroup", 100, DataGridViewContentAlignment.MiddleLeft, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinv_pcategory", "Pcp.Category", "heinv_pcategory", 100, DataGridViewContentAlignment.MiddleLeft, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinv_colordescr", "Color Descr", "heinv_colordescr", 100, DataGridViewContentAlignment.MiddleLeft, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinv_gender", "Gender", "heinv_gender", 100, DataGridViewContentAlignment.MiddleLeft, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinv_fit", "Fit", "heinv_fit", 100, DataGridViewContentAlignment.MiddleLeft, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinv_hscode_ship", "HSCode Ship", "heinv_hscode_ship", 100, DataGridViewContentAlignment.MiddleLeft, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinv_hscode_ina", "HSCode INA", "heinv_hscode_ina", 100, DataGridViewContentAlignment.MiddleLeft, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinv_plbname", "Nama di PLB", "heinv_plbname", 100, DataGridViewContentAlignment.MiddleLeft, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinv_box", "Box", "heinv_box", 100, DataGridViewContentAlignment.MiddleLeft, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinv_gtype", "Type", "heinv_gtype", 40, DataGridViewContentAlignment.MiddleLeft, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinv_produk", "Produk", "heinv_produk", 100, DataGridViewContentAlignment.MiddleLeft, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinv_bahan", "Bahan", "heinv_bahan", 100, DataGridViewContentAlignment.MiddleLeft, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinv_pemeliharaan", "Pemeliharaan", "heinv_pemeliharaan", 250, DataGridViewContentAlignment.MiddleLeft, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinv_logo", "Logo", "heinv_logo", 60, DataGridViewContentAlignment.MiddleLeft, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinv_dibuatdi", "Dibuat Di", "heinv_dibuatdi", 100, DataGridViewContentAlignment.MiddleLeft, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinv_isweb", "IsWeb", "heinv_isweb", 60, DataGridViewContentAlignment.MiddleCenter, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinv_weight", "Weight", "heinv_weight", 80, DataGridViewContentAlignment.MiddleRight, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinv_length", "Length", "heinv_length", 80, DataGridViewContentAlignment.MiddleRight, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinv_width", "Width", "heinv_width", 80, DataGridViewContentAlignment.MiddleRight, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinv_height", "Height", "heinv_height", 80, DataGridViewContentAlignment.MiddleRight, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinv_webdescr", "WebDescr", "heinv_webdescr", 200, DataGridViewContentAlignment.MiddleLeft, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinv_other1", "Other1", "heinv_other1", 100, DataGridViewContentAlignment.MiddleLeft, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinv_price", "Price", "heinv_price", 80, DataGridViewContentAlignment.MiddleRight, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinvctg_id", "CTG", "heinvctg_id", 70, DataGridViewContentAlignment.MiddleCenter, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinvgro_id", "GRO", "heinvgro_id", 70, DataGridViewContentAlignment.MiddleCenter, True, Color.Gainsboro), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinvgro_name", "GRONAME", "heinvgro_name", 100, DataGridViewContentAlignment.MiddleLeft, True, Color.Gainsboro), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinvctg_name", "CTGNAME", "heinvctg_name", 100, DataGridViewContentAlignment.MiddleLeft, True, Color.Gainsboro), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "heinvctg_sizetag", "TAG", "heinvctg_sizetag", 30, DataGridViewContentAlignment.MiddleCenter, True, Color.Gainsboro), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "branch_id", "Branch", "branch_id", 70, DataGridViewContentAlignment.MiddleCenter, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "branch_name", "BranchName", "branch_name", 100, DataGridViewContentAlignment.MiddleCenter, True, Color.Gainsboro), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C00", "C00", "C00", 35, DataGridViewContentAlignment.MiddleRight, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C01", "C01", "C01", 35, DataGridViewContentAlignment.MiddleRight, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C02", "C02", "C02", 35, DataGridViewContentAlignment.MiddleRight, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C03", "C03", "C03", 35, DataGridViewContentAlignment.MiddleRight, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C04", "C04", "C04", 35, DataGridViewContentAlignment.MiddleRight, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C05", "C05", "C05", 35, DataGridViewContentAlignment.MiddleRight, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C06", "C06", "C06", 35, DataGridViewContentAlignment.MiddleRight, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C07", "C07", "C07", 35, DataGridViewContentAlignment.MiddleRight, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C08", "C08", "C08", 35, DataGridViewContentAlignment.MiddleRight, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C09", "C09", "C09", 35, DataGridViewContentAlignment.MiddleRight, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C10", "C10", "C10", 35, DataGridViewContentAlignment.MiddleRight, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C11", "C11", "C11", 35, DataGridViewContentAlignment.MiddleRight, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C12", "C12", "C12", 35, DataGridViewContentAlignment.MiddleRight, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C13", "C13", "C13", 35, DataGridViewContentAlignment.MiddleRight, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C14", "C14", "C14", 35, DataGridViewContentAlignment.MiddleRight, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C15", "C15", "C15", 35, DataGridViewContentAlignment.MiddleRight, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C16", "C16", "C16", 35, DataGridViewContentAlignment.MiddleRight, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C17", "C17", "C17", 35, DataGridViewContentAlignment.MiddleRight, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C18", "C18", "C18", 35, DataGridViewContentAlignment.MiddleRight, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C19", "C19", "C19", 35, DataGridViewContentAlignment.MiddleRight, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C20", "C20", "C20", 35, DataGridViewContentAlignment.MiddleRight, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C21", "C21", "C21", 35, DataGridViewContentAlignment.MiddleRight, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C22", "C22", "C22", 35, DataGridViewContentAlignment.MiddleRight, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C23", "C23", "C23", 35, DataGridViewContentAlignment.MiddleRight, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C24", "C24", "C24", 35, DataGridViewContentAlignment.MiddleRight, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C25", "C25", "C25", 35, DataGridViewContentAlignment.MiddleRight, False, Color.White), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "ERR", "Error", "err", 60, DataGridViewContentAlignment.MiddleRight, True, Color.Gainsboro), _
              Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "rowid", "rowid", "rowid", 100) _
        })

        With objDgv.Columns("heinvregisteritem_line")
            .Width = 40
            .DefaultCellStyle.BackColor = Color.Gainsboro
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Padding = New Padding(0, 0, 5, 0)
            .ReadOnly = True
        End With

        objDgv.Columns("heinv_hscode_ina").ReadOnly = True
        objDgv.Columns("rowid").Visible = False
        objDgv.Columns("heinv_col").Frozen = True
        objDgv.Columns("ERR").DefaultCellStyle.Font = New Font("Courier New", 8, FontStyle.Regular)

        ' DgvMstIteminventory Behaviours: 
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AutoGenerateColumns = False
        objDgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText

    End Function

    Public Shared Function FormatDgvProp(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
         { _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "prop_line", "Line", "prop_line", 50), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "prop_name", "Property", "prop_name", 150), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "prop_value", "Value", "prop_value", 100), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "prop_descr", "Descr", "prop_descr", 200) _
         })

        With objDgv.Columns("prop_line")
            .DefaultCellStyle.BackColor = Color.Gainsboro
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Padding = New Padding(0, 0, 5, 0)
            .ReadOnly = True
        End With

        ' DgvMstIteminventory Behaviours: 
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AutoGenerateColumns = False
    End Function

    Public Shared Function FormatDgvLog(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
         { _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "log_line", "Line", "log_line", 50), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "log_date", "Date", "log_date", 100), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "log_action", "Action", "log_action", 150), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "log_descr", "Descr", "log_descr", 200), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "log_table", "Table", "log_table", 100), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "log_lastvalue", "LastValue", "log_lastvalue", 200), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "log_username", "Username", "log_username", 100) _
         })


        ' DgvMstIteminventory Behaviours: 
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AutoGenerateColumns = False
        objDgv.DefaultCellStyle.BackColor = Color.Gainsboro
    End Function

    Public Overrides Function BindingStop() As Boolean
        Try
            Me.obj_heinvregister_id.DataBindings.Clear()
            Me.obj_heinvregister_date.DataBindings.Clear()
            Me.obj_heinvregister_descr.DataBindings.Clear()
            Me.obj_heinvregister_type.DataBindings.Clear()
            Me.obj_heinvregister_issizing.DataBindings.Clear()
            Me.obj_heinvregister_isposted.DataBindings.Clear()
            Me.obj_heinvregister_isgenerated.DataBindings.Clear()
            Me.obj_heinvregister_isseasonupdate.DataBindings.Clear()
            Me.obj_heinvregister_createby.DataBindings.Clear()
            Me.obj_heinvregister_createdate.DataBindings.Clear()
            Me.obj_heinvregister_modifyby.DataBindings.Clear()
            Me.obj_heinvregister_modifydate.DataBindings.Clear()
            Me.obj_region_id.DataBindings.Clear()
            Me.obj_branch_id.DataBindings.Clear()
            Me.obj_season_id.DataBindings.Clear()
            Me.obj_season_name.DataBindings.Clear()
            Me.obj_rekanan_id.DataBindings.Clear()
            Me.obj_rekanan_name.DataBindings.Clear()
            Me.obj_currency_id.DataBindings.Clear()
            Me.obj_rowid.DataBindings.Clear()
        Catch ex As Exception
            MessageBox.Show("Error in function BindingStop() on Layout & Init UI" & vbCrLf & ex.Message, "BindingStop", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Public Overrides Function BindingStart() As Boolean
        Try
            Me.obj_heinvregister_id.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "heinvregister_id"))
            Me.obj_heinvregister_date.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "heinvregister_date"))
            Me.obj_heinvregister_descr.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "heinvregister_descr"))
            Me.obj_heinvregister_type.DataBindings.Add(New Binding("SelectedValue", Me.tblList_Temp, "heinvregister_type"))
            Me.obj_heinvregister_issizing.DataBindings.Add(New Binding("Checked", Me.tblList_Temp, "heinvregister_issizing"))
            Me.obj_heinvregister_isposted.DataBindings.Add(New Binding("Checked", Me.tblList_Temp, "heinvregister_isposted"))
            Me.obj_heinvregister_isgenerated.DataBindings.Add(New Binding("Checked", Me.tblList_Temp, "heinvregister_isgenerated"))
            Me.obj_heinvregister_isseasonupdate.DataBindings.Add(New Binding("Checked", Me.tblList_Temp, "heinvregister_isseasonupdate"))
            Me.obj_heinvregister_createby.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "heinvregister_createby"))
            Me.obj_heinvregister_createdate.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "heinvregister_createdate"))
            Me.obj_heinvregister_modifyby.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "heinvregister_modifyby"))
            Me.obj_heinvregister_modifydate.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "heinvregister_modifydate"))
            Me.obj_region_id.DataBindings.Add(New Binding("SelectedValue", Me.tblList_Temp, "region_id"))
            Me.obj_branch_id.DataBindings.Add(New Binding("SelectedValue", Me.tblList_Temp, "branch_id"))
            Me.obj_season_id.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "season_id"))
            Me.obj_season_name.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "season_name"))
            Me.obj_rekanan_id.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "rekanan_id"))
            Me.obj_rekanan_name.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "rekanan_name"))
            Me.obj_currency_id.DataBindings.Add(New Binding("SelectedValue", Me.tblList_Temp, "currency_id"))
            Me.obj_rowid.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "rowid"))

        Catch ex As Exception
            MessageBox.Show("Error in function BindingStart() on Layout & Init UI" & vbCrLf & ex.Message, "BindingStart", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

#End Region

#Region " Overrides Function "

    Public Overrides Function btnLoad_Click() As Boolean
        Dim CriteriaBuilder As Translib.QueryCriteria = Me.BuildListCriteria()
        Dim Criteria As String = CriteriaBuilder.Serialize()

        Me.List_CurrentPageIndex = 1
        Me.tblList.Rows.Clear()
        Me.DgvList.DataSource = Nothing
        Me.bgwListLoader.RunWorkerAsync(New Object() {CreateWebService(Me.WebserviceNSModule, Me.WebserviceObjectModule, "gridlistload"), Criteria, Me.bnRowLimit.Text})
        Return MyBase.btnLoad_Click()
    End Function

    Public Overrides Function RefreshList(ByRef bn As System.Windows.Forms.BindingNavigator, ByVal obj As System.Windows.Forms.ToolStripItem) As Boolean
        Dim CriteriaBuilder As Translib.QueryCriteria = Me.BuildListCriteria()
        Dim Criteria As String = CriteriaBuilder.Serialize()

        If Me.BindingNavigator_Click(bn, obj) Then
            Me.tblList.Rows.Clear()
            Me.DgvList.DataSource = Nothing
            Me.bgwListLoader.RunWorkerAsync(New Object() {CreateWebService(Me.WebserviceNSModule, Me.WebserviceObjectModule, "gridlistload"), Criteria, Me.bnRowLimit.Text})
        End If
    End Function

#End Region

#Region " User Defined Function "

    Public Overridable Function AddListCriteria(ByRef CriteriaBuilder As Translib.QueryCriteria) As Boolean
    End Function

    Public Overridable Function BuildListCriteria() As Translib.QueryCriteria
        Dim CriteriaBuilder As Translib.QueryCriteria = New Translib.QueryCriteria()

        ' Default Criteria
        CriteriaBuilder.AddCriteria(Me.obj_search_chk_heinvregister_id.Name, Me.obj_search_chk_heinvregister_id.Checked, Me.obj_search_txt_heinvregister_id.Text)
        CriteriaBuilder.AddCriteria(Me.obj_search_chk_region_id.Name, Me.obj_search_chk_region_id.Checked, Me.obj_search_cbo_region_id.SelectedValue)
        CriteriaBuilder.AddCriteria(Me.obj_search_chk_season_id.Name, Me.obj_search_chk_season_id.Checked, Me.obj_search_txt_season_id.Text)

        Me.AddListCriteria(CriteriaBuilder)

        Return CriteriaBuilder
    End Function

    Public Function GetCliboardText() As String
        Dim objCliboard As IDataObject = Clipboard.GetDataObject()
        With objCliboard
            If .GetDataPresent(DataFormats.Text) Then
                Return .GetData(DataFormats.Text)
            Else
                Return Nothing
            End If
        End With
    End Function

    Public Sub AddDetilItemRowsFromClipboard(ByVal strColumns() As String, ByVal sizing As Boolean)
        Dim newrow As DataRow

        Dim cCTGID, cART, cMAT, cCOL, cSIZE, cBARCODE, cNAME, cDESCR, cBOX, cGTYPE, cPRODUK, cBAHAN, cPEMELIHARAAN, cLOGO, cDIBUATDI, cOTHER, cBRANCH, cPRICE, cTAG, cC00, cC01, cC02, cC03, cC04, cC05, cC06, cC07, cC08, cC09, cC10, cC11, cC12, cC13, cC14, cC15, cC16, cC17, cC18, cC19, cC20, cC21, cC22, cC23, cC24, cC25 As String
        Dim cPCPLINE, cPCPGROUP, cPCPCATEGORY, cCOLORDESCR, cGENDER, cFIT As String
        Dim cHSCODE As String
        Dim cPLBNAME As String
        Dim cWEBENABLED, cWEIGHT, cLENGTH, cWIDTH, cHEIGHT, cWEBDESCR As Integer

        Dim CTGID, ART, MAT, COL, SIZE, BARCODE, NAME, DESCR, BOX, GTYPE, PRODUK, BAHAN, PEMELIHARAAN, LOGO, DIBUATDI, OTHER, BRANCH, PRICE, TAG, C00, C01, C02, C03, C04, C05, C06, C07, C08, C09, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25 As String
        Dim PCPLINE, PCPGROUP, PCPCATEGORY, COLORDESCR, GENDER, FIT As String
        Dim HSCODE As Int32
        Dim PLBNAME As String
        Dim WEBENABLED As String
        Dim WEIGHT, LENGTH, WIDTH, HEIGHT As String
        Dim WEBDESCR As String

        Dim COLPOS As String = ""


        ART = ""
        MAT = ""
        COL = ""
        NAME = ""


        Try

            If sizing Then
                cCTGID = 0
                cART = 1
                cMAT = 2
                cCOL = 3
                cSIZE = 4
                cBARCODE = 5
                cNAME = 6
                cDESCR = 7
                cPCPLINE = 8
                cPCPGROUP = 9
                cPCPCATEGORY = 10
                cCOLORDESCR = 11
                cGENDER = 12
                cFIT = 24
                cHSCODE = 25
                cPLBNAME = 26
                cBOX = 13
                cGTYPE = 14
                cPRODUK = 15
                cBAHAN = 16
                cPEMELIHARAAN = 17
                cLOGO = 18
                cDIBUATDI = 19
                cOTHER = 20
                cBRANCH = 21
                cPRICE = 22
                cTAG = 0
                cC00 = 23
                cC01 = 0
                cC02 = 0
                cC03 = 0
                cC04 = 0
                cC05 = 0
                cC06 = 0
                cC07 = 0
                cC08 = 0
                cC09 = 0
                cC10 = 0
                cC11 = 0
                cC12 = 0
                cC13 = 0
                cC14 = 0
                cC15 = 0
                cC16 = 0
                cC17 = 0
                cC18 = 0
                cC19 = 0
                cC20 = 0
                cC21 = 0
                cC22 = 0
                cC23 = 0
                cC24 = 0
                cC25 = 0
                cWEBENABLED = 27
                cWEIGHT = 28
                cLENGTH = 29
                cWIDTH = 30
                cHEIGHT = 31
                cWEBDESCR = 32
            Else
                cCTGID = 0
                cART = 1
                cMAT = 2
                cCOL = 3
                cSIZE = 0
                cBARCODE = 0
                cNAME = 4
                cDESCR = 5
                cBOX = 6
                cFIT = 24
                cHSCODE = 0
                cPLBNAME = 0
                cGTYPE = 7
                cPRODUK = 8
                cBAHAN = 9
                cPEMELIHARAAN = 10
                cLOGO = 11
                cDIBUATDI = 12
                cOTHER = 13
                cBRANCH = 14
                cPRICE = 15
                cTAG = 16
                cPCPLINE = 8
                cPCPGROUP = 9
                cPCPCATEGORY = 10
                cCOLORDESCR = 11
                cGENDER = 12
                cC00 = 0
                cC01 = 17
                cC02 = 18
                cC03 = 19
                cC04 = 20
                cC05 = 21
                cC06 = 22
                cC07 = 23
                cC08 = 24
                cC09 = 25
                cC10 = 26
                cC11 = 27
                cC12 = 28
                cC13 = 29
                cC14 = 30
                cC15 = 31
                cC16 = 32
                cC17 = 33
                cC18 = 34
                cC19 = 35
                cC20 = 36
                cC21 = 37
                cC22 = 38
                cC23 = 39
                cC24 = 40
                cC25 = 41


            End If

            newrow = Me.ddBinding.Tables("DetilItem").Table.NewRow()
            CTGID = Trim(strColumns(cCTGID))
            ART = Trim(strColumns(cART))

            If ART = "" Then Exit Sub


            MAT = Trim(strColumns(cMAT))
            COL = Trim(strColumns(cCOL))
            NAME = Trim(strColumns(cNAME))
            DESCR = Trim(strColumns(cDESCR))
            PCPLINE = Trim(strColumns(cPCPLINE))
            PCPGROUP = Trim(strColumns(cPCPGROUP))
            PCPCATEGORY = Trim(strColumns(cPCPCATEGORY))
            COLORDESCR = Trim(strColumns(cCOLORDESCR))
            GENDER = Trim(strColumns(cGENDER))
            BOX = Trim(strColumns(cBOX))
            GTYPE = Trim(strColumns(cGTYPE))
            PRODUK = Trim(strColumns(cPRODUK))
            BAHAN = Trim(strColumns(cBAHAN))
            PEMELIHARAAN = Trim(strColumns(cPEMELIHARAAN))
            LOGO = Trim(strColumns(cLOGO))
            DIBUATDI = Trim(strColumns(cDIBUATDI))
            OTHER = Trim(strColumns(cOTHER))
            BRANCH = Trim(strColumns(cBRANCH))
            PRICE = Trim(strColumns(cPRICE))
            TAG = Trim(strColumns(cTAG))
            FIT = Trim(strColumns(cFIT))
            HSCODE = Trim(strColumns(cHSCODE))
            PLBNAME = Trim(strColumns(cPLBNAME))
            WEBENABLED = Trim(strColumns(cWEBENABLED))
            WEIGHT = Trim(strColumns(cWEIGHT))
            LENGTH = Trim(strColumns(cLENGTH))
            WIDTH = Trim(strColumns(cWIDTH))
            HEIGHT = Trim(strColumns(cHEIGHT))
            WEBDESCR = Trim(strColumns(cWEBDESCR))


            ' Hack Logo
            If LOGO.ToUpper = "BUKAN KULIT" Then
                LOGO = ""
            ElseIf LOGO.ToUpper = "KULIT" Then
                LOGO = "KULIT"
            Else
                LOGO = ""
            End If

            COLPOS = "CTGID"
            newrow("heinvctg_id") = CTGID
            COLPOS = "ART"
            newrow("heinv_art") = ART
            COLPOS = "MAT"
            newrow("heinv_mat") = MAT
            COLPOS = "COL"
            newrow("heinv_col") = COL
            COLPOS = "NAME"
            newrow("heinv_name") = NAME

            COLPOS = "DESCR"
            newrow("heinv_descr") = DESCR

            COLPOS = "PCPLINE"
            newrow("heinv_pline") = PCPLINE

            COLPOS = "PCPGROUP"
            newrow("heinv_pgroup") = PCPGROUP
            If (PCPGROUP = "") Then
                Throw New Exception("Pricipal Group belum diisi, pada artikel " & ART)
            End If

            COLPOS = "PCPCATEGORY"
            newrow("heinv_pcategory") = PCPCATEGORY
            If (PCPCATEGORY = "") Then
                Throw New Exception("Pricipal Category belum diisi, pada artikel " & ART)
            End If

            COLPOS = "COLORDESCR"
            newrow("heinv_colordescr") = COLORDESCR
            If (PCPCATEGORY = "") Then
                Throw New Exception("Color description belum diisi, pada artikel " & ART)
            End If

            COLPOS = "GENDER"
            newrow("heinv_gender") = GENDER
            If (GENDER <> "M" And GENDER <> "W" And GENDER <> "U" And GENDER <> "K") Then
                Throw New Exception("Gender Salah, pada artikel " & ART)
            End If

            COLPOS = "FIT"
            newrow("heinv_fit") = FIT


            COLPOS = "HSCODE"
            newrow("heinv_hscode_ship") = HSCODE

            COLPOS = "PLBNAME"
            newrow("heinv_plbname") = PLBNAME

            COLPOS = "BOX"
            newrow("heinv_box") = BOX

            COLPOS = "GTYPE"
            newrow("heinv_gtype") = GTYPE
            COLPOS = "PRODUK"
            newrow("heinv_produk") = PRODUK
            COLPOS = "BAHAN"
            newrow("heinv_bahan") = BAHAN
            COLPOS = "PEMELIHARAAN"
            newrow("heinv_pemeliharaan") = PEMELIHARAAN
            COLPOS = "LOGO"
            newrow("heinv_logo") = LOGO
            COLPOS = "DIBUATDI"
            newrow("heinv_dibuatdi") = DIBUATDI
            COLPOS = "OTHER"
            newrow("heinv_other1") = OTHER
            COLPOS = "BRANCH"
            newrow("branch_id") = BRANCH
            COLPOS = "PRICE"
            newrow("heinv_price") = CDec(IIf(Trim(PRICE) = "", "0", PRICE))
            COLPOS = "WEBENABLED"
            newrow("heinv_isweb") = CInt(IIf(Trim(WEBENABLED) = "", "0", WEBENABLED))
            COLPOS = "WEIGHT"
            newrow("heinv_weight") = CDec(IIf(Trim(WEIGHT) = "", "0", WEIGHT))
            COLPOS = "LENGTH"
            newrow("heinv_length") = CDec(IIf(Trim(LENGTH) = "", "0", LENGTH))
            COLPOS = "WIDTH"
            newrow("heinv_width") = CDec(IIf(Trim(WIDTH) = "", "0", WIDTH))
            COLPOS = "HEIGHT"
            newrow("heinv_height") = CDec(IIf(Trim(HEIGHT) = "", "0", HEIGHT))
            COLPOS = "WEBDESCR"
            newrow("heinv_webdescr") = WEBDESCR

            If sizing Then
                SIZE = strColumns(cSIZE)
                BARCODE = strColumns(cBARCODE)
                C00 = strColumns(cC00)
                COLPOS = "SIZE"
                newrow("heinv_size") = SIZE
                COLPOS = "BARCODE"
                newrow("heinv_barcode") = BARCODE
                COLPOS = "C00"
                newrow("C00") = CInt(IIf(Trim(C00) = "", "0", C00))



            Else

                C01 = strColumns(cC01)
                C02 = strColumns(cC02)
                C03 = strColumns(cC03)
                C04 = strColumns(cC04)
                C05 = strColumns(cC05)
                C06 = strColumns(cC06)
                C07 = strColumns(cC07)
                C08 = strColumns(cC08)
                C09 = strColumns(cC09)
                C10 = strColumns(cC10)
                C11 = strColumns(cC11)
                C12 = strColumns(cC12)
                C13 = strColumns(cC13)
                C14 = strColumns(cC14)
                C15 = strColumns(cC15)
                C16 = strColumns(cC16)
                C17 = strColumns(cC17)
                C18 = strColumns(cC18)
                C19 = strColumns(cC19)
                C20 = strColumns(cC20)
                C21 = strColumns(cC21)
                C22 = strColumns(cC22)
                C23 = strColumns(cC23)
                C24 = strColumns(cC24)
                C25 = strColumns(cC25)

                'Masukkan ke data table
                COLPOS = "C00"
                newrow("C00") = 0
                COLPOS = "C01"
                newrow("C01") = CInt(IIf(Trim(C01) = "", "0", C01))
                COLPOS = "C02"
                newrow("C02") = CInt(IIf(Trim(C02) = "", "0", C02))
                COLPOS = "C03"
                newrow("C03") = CInt(IIf(Trim(C03) = "", "0", C03))
                COLPOS = "C04"
                newrow("C04") = CInt(IIf(Trim(C04) = "", "0", C04))
                COLPOS = "C05"
                newrow("C05") = CInt(IIf(Trim(C05) = "", "0", C05))
                COLPOS = "C06"
                newrow("C06") = CInt(IIf(Trim(C06) = "", "0", C06))
                COLPOS = "C07"
                newrow("C07") = CInt(IIf(Trim(C07) = "", "0", C07))
                COLPOS = "C08"
                newrow("C08") = CInt(IIf(Trim(C08) = "", "0", C08))
                COLPOS = "C09"
                newrow("C09") = CInt(IIf(Trim(C09) = "", "0", C09))
                COLPOS = "C10"
                newrow("C10") = CInt(IIf(Trim(C10) = "", "0", C10))
                COLPOS = "C11"
                newrow("C11") = CInt(IIf(Trim(C11) = "", "0", C11))
                COLPOS = "C12"
                newrow("C12") = CInt(IIf(Trim(C12) = "", "0", C12))
                COLPOS = "C13"
                newrow("C13") = CInt(IIf(Trim(C13) = "", "0", C13))
                COLPOS = "C14"
                newrow("C14") = CInt(IIf(Trim(C14) = "", "0", C14))
                COLPOS = "C15"
                newrow("C15") = CInt(IIf(Trim(C15) = "", "0", C15))
                COLPOS = "C16"
                newrow("C16") = CInt(IIf(Trim(C16) = "", "0", C16))
                COLPOS = "C17"
                newrow("C17") = CInt(IIf(Trim(C17) = "", "0", C17))
                COLPOS = "C18"
                newrow("C18") = CInt(IIf(Trim(C18) = "", "0", C18))
                COLPOS = "C19"
                newrow("C19") = CInt(IIf(Trim(C19) = "", "0", C19))
                COLPOS = "C20"
                newrow("C20") = CInt(IIf(Trim(C20) = "", "0", C20))
                COLPOS = "C21"
                newrow("C21") = CInt(IIf(Trim(C21) = "", "0", C21))
                COLPOS = "C22"
                newrow("C22") = CInt(IIf(Trim(C22) = "", "0", C22))
                COLPOS = "C23"
                newrow("C23") = CInt(IIf(Trim(C23) = "", "0", C23))
                COLPOS = "C24"
                newrow("C24") = CInt(IIf(Trim(C24) = "", "0", C24))
                COLPOS = "C25"
                newrow("C25") = CInt(IIf(Trim(C25) = "", "0", C25))
            End If

            COLPOS = "Err"
            newrow("err") = 99
            Me.ddBinding.Tables("DetilItem").Table.Rows.Add(newrow)



        Catch ex As Exception
            Throw New Exception(ex.Message & vbCrLf & String.Format("Posisi: ART:{0}, MAT:{1}, COL:{2}, NAME:{3}", ART, MAT, COL, NAME) & vbCrLf & "ColumnName: " & COLPOS)
        End Try

    End Sub

    Public Sub MergeTableDetilItem(ByVal tbl As DataTable)
        Dim irow As Integer
        Dim icol As Integer
        Dim colname As String
        Dim newrow As DataRow

        With Me.ddBinding.Tables("DetilItem").Table.Columns("heinvregisteritem_line")
            .DefaultValue = DBNull.Value
            .AutoIncrement = False
        End With

        For irow = 0 To tbl.Rows.Count - 1
            newrow = Me.ddBinding.Tables("DetilItem").Table.NewRow
            For icol = 0 To Me.ddBinding.Tables("DetilItem").Table.Columns.Count - 1
                colname = Me.ddBinding.Tables("DetilItem").Table.Columns(icol).ColumnName
                newrow(colname) = tbl.Rows(irow).Item(colname)
            Next
            Me.ddBinding.Tables("DetilItem").Table.Rows.Add(newrow)
        Next

        With Me.ddBinding.Tables("DetilItem").Table.Columns("heinvregisteritem_line")
            .DefaultValue = DBNull.Value
            .AutoIncrement = True
            .AutoIncrementSeed = 10
            .AutoIncrementStep = 10
        End With

    End Sub

#End Region

#Region " Default Event "

    Private Sub bnList_Click(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles bnList.ItemClicked
        Me.RefreshList(sender, e.ClickedItem)
    End Sub

    Private Sub ftabMain_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles ftabMain.Selecting
        If e.TabPage.Name = "ftabMain_Data" Then
            If Not Me.IsNew Then
                MyBase.TabMain_OpenData(Me.DgvList, Me.tblList.PrimaryKey(0).ColumnName, CreateWebService(Me.WebserviceNSModule, Me.WebserviceObjectModule, "open"))
            End If
            If Me.BackgroundworkerStatus = EBackgroundworkerStatus.Fail Then
                e.Cancel = True
            End If
        Else
            Dim res As System.Windows.Forms.DialogResult
            Dim id As String = Me.GetActiveDocumentIDValue()
            If Me.DataIsChanged(Me.tblList_Temp, Me.ddBinding) Then
                res = System.Windows.Forms.MessageBox.Show("Data in document " & id & " has changed." & vbCrLf & vbCrLf & "Do you want to save the changes ?", Me.Title, System.Windows.Forms.MessageBoxButtons.YesNoCancel, System.Windows.Forms.MessageBoxIcon.Warning)
                Select Case res
                    Case System.Windows.Forms.DialogResult.Yes
                    Case System.Windows.Forms.DialogResult.No
                        Me.CancelAllData()
                    Case System.Windows.Forms.DialogResult.Cancel
                        e.Cancel = True
                End Select
            End If
        End If
        Me.IsNew = False
    End Sub

    Private Sub ftabMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ftabMain.SelectedIndexChanged
        Dim tab As FlatTabControl.FlatTabControl = CType(sender, FlatTabControl.FlatTabControl)
        MyBase.TabMain_SetSelected(tab)
    End Sub

    Private Sub ftabDataDetil_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ftabDataDetil.SelectedIndexChanged
        Dim tab As FlatTabControl.FlatTabControl = CType(sender, FlatTabControl.FlatTabControl)
        MyBase.TabDetil_SetSelected(tab)
    End Sub


    Private Sub DgvList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvList.CellDoubleClick
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
            Exit Sub
        End If
        If Me.DgvList.CurrentRow IsNot Nothing Then
            Me.ClearData()
            Me.BackgroundworkerSaveStatus = EBackgroundworkerStatus.Init
            Me.ftabMain.SelectedIndex = 1
        End If
    End Sub

    Private Sub DgvList_RowHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvList.RowHeaderMouseDoubleClick
        If Me.DgvList.CurrentRow IsNot Nothing Then
            Me.ClearData()
            Me.BackgroundworkerSaveStatus = EBackgroundworkerStatus.Init
            Me.ftabMain.SelectedIndex = 1
        End If
    End Sub

    Private Sub DgvList_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvList.RowEnter
        Me.Datawalk_SetButtonState(sender, e.RowIndex)
    End Sub

    Private Sub DgvDetil_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)

    End Sub



#End Region

#Region " General Event "

    Private Sub ui_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.btnPasteFromSpreadSheet.Text = TxtBtnPasteFromSpreadsheed

        Me.obj_search_txt_heinvregister_id.DataBindings.Add(New Binding("Enabled", Me.obj_search_chk_heinvregister_id, "Checked"))
        Me.obj_search_cbo_region_id.DataBindings.Add(New Binding("Enabled", Me.obj_search_chk_region_id, "Checked"))
        Me.obj_search_txt_season_id.DataBindings.Add(New Binding("Enabled", Me.obj_search_chk_season_id, "Checked"))


        If Not Me.BindingContext.Contains(Me.tblList_Temp) Then
            Me.BindingStart()
        End If

        Me.startInfo = New ProcessStartInfo()
        If startInfo.EnvironmentVariables("POSENV") = "DEV" Then
            Me.Dock = DockStyle.Fill
        End If

    End Sub

    Private Sub ui_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Me.fLoadingIndicator.Close()
        Me.fLoadingIndicator.Dispose()
        Me.bgwDataLoader.Dispose()
        Me.bgwListLoader.Dispose()
        Me.bgwDelete.Dispose()
        Me.bgwMasterLoader.Dispose()
        Me.bgwMasterLoaderQueue.Dispose()
        Me.bgwNew.Dispose()
        Me.bgwPrintLoader.Dispose()
        Me.bgwPrintWeb.Dispose()
        Me.bgwSave.Dispose()

        If Me.bgwPaste IsNot Nothing Then Me.bgwPaste.Dispose()
        If Me.bgwUpload IsNot Nothing Then Me.bgwUpload.Dispose()
        If Me.bgwLoadDetil IsNot Nothing Then Me.bgwLoadDetil.Dispose()

    End Sub

    Private Sub ui_FormDataOpening(ByRef id As Object) Handles Me.FormDataOpening
        Me.BindingStop()
        Me.tblList_Temp.Clear()
        Me.ConstructTableDetil()
    End Sub

    Private Sub ui_FormDataOpened(ByVal id As Object) Handles Me.FormDataOpened
        Me._FormErrorProvider.Clear()


        Me.LastRow = 0
        Me.obj_region_id.Enabled = False
        Me.obj_heinvregister_issizing.Enabled = False
        Me.obj_heinvregister_issizing_CheckedChanged(Me.obj_heinvregister_issizing, New System.EventArgs)

        Me.btnUpload.Enabled = False
        If Me.DgvDetilItem.Rows.Count > 0 Then
            Me.btnPasteFromSpreadSheet.Enabled = False
        Else
            Me.btnPasteFromSpreadSheet.Enabled = True
        End If



        ' Load Data Detil
        Dim param As LoadDataDetilParam = New LoadDataDetilParam
        'If totaldetilrows > 100 Then
        If Me.bgwLoadDetil Is Nothing Then
            Me.bgwLoadDetil = New System.ComponentModel.BackgroundWorker
            Me.bgwLoadDetil.WorkerReportsProgress = True
            Me.bgwLoadDetil.WorkerSupportsCancellation = True
        End If


        Me.DgvDetilItem.DataSource = Nothing
        param.id = Me.obj_heinvregister_id.Text
        param.totalrows = Me.tblList_Temp.Rows(0).Item("totaldetilrows")
        Me.bgwLoadDetil.RunWorkerAsync(param)

        'End If


        Me.obj_heinvregister_issizing.Enabled = False


    End Sub

    Private Sub ui_FormMasterLoaderError(ByVal service As String, ByVal msg As String, ByVal request As String, ByVal respond As String) Handles Me.FormMasterLoaderError
        'MessageBox.Show(service & vbCrLf & msg & vbCrLf & request & vbCrLf & respond)
    End Sub

    Private Sub ui_FormMasterDataLoaded(ByVal status As Translib.uiBase.EBackgroundworkerStatus, ByVal message As String) Handles Me.FormMasterDataLoaded
        If status = EBackgroundworkerStatus.Fail Then
            MessageBox.Show(message, Me.Title, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error)
        Else
            Translib.uiBase.ComboLink(Me.obj_search_cbo_region_id, "region_id", "region_name", Me.dsMaster.Tables("master_region").Copy, True, False)

            Translib.uiBase.ComboLink(Me.obj_region_id, "region_id", "region_name", Me.dsMaster.Tables("master_region").Copy, True, False)
            Translib.uiBase.ComboLink(Me.obj_branch_id, "branch_id", "branch_name", Me.dsMaster.Tables("master_branch").Copy, True, False)
            Translib.uiBase.ComboLink(Me.obj_currency_id, "currency_id", "currency_name", Me.dsMaster.Tables("master_currency").Copy, True, False)


            ' Master Register Type
            Me.dsMaster.Tables("master_registertype").Columns.Add(New DataColumn("registertype_id", GetType(System.String)))
            Me.dsMaster.Tables("master_registertype").Columns.Add(New DataColumn("registertype_name", GetType(System.String)))
            Me.dsMaster.Tables("master_registertype").Rows.Add("O", "Order Confirmation")
            Me.dsMaster.Tables("master_registertype").Rows.Add("S", "Shipment (PO to TF Import)")
            Me.dsMaster.Tables("master_registertype").Rows.Add("D", "Other Document")

            ' heinvregister_type()
            Translib.uiBase.ComboLink(Me.obj_heinvregister_type, "registertype_id", "registertype_name", Me.dsMaster.Tables("master_registertype").Copy, True, False)


        End If
    End Sub

    Private Sub ui_BackgroundworkerDataLoaderCompleted(ByRef tabMain As FlatTabControl.FlatTabControl, ByRef tabDetil As FlatTabControl.FlatTabControl, ByVal webrespond As String) Handles Me.BackgroundworkerDataLoaderCompleted
        Dim res As String = webrespond
    End Sub

    Private Sub ui_BackgroundworkerSaveCompleted(ByVal status As Translib.uiBase.EBackgroundworkerStatus, ByVal service As String, ByVal requestheader As String, ByVal webrespond As String) Handles Me.BackgroundworkerSaveCompleted
        Dim res As String = webrespond

    End Sub


    Private Sub ui_FormSavingCheck(ByRef id As Object, ByRef service As String, ByRef datasent As Object, ByRef cancel As Boolean) Handles Me.FormSavingCheck
        Dim msgerr As String = ""
        Me._FormErrorProvider.Clear()

        Try

            If Me.obj_heinvregister_type.SelectedValue = "0" Then
                msgerr = "Register type belum diisi"
                Me._FormErrorProvider.SetError(Me.obj_heinvregister_type, msgerr)
                Throw New Exception(msgerr)
            End If

            If Me.obj_region_id.SelectedValue = "0" Then
                msgerr = "Region belum diisi"
                Me._FormErrorProvider.SetError(Me.obj_region_id, msgerr)
                Throw New Exception(msgerr)
            End If

            If Me.obj_branch_id.SelectedValue = "0" Then
                msgerr = "Branch belum diisi"
                Me._FormErrorProvider.SetError(Me.obj_branch_id, msgerr)
                Throw New Exception(msgerr)
            End If

            If Trim(Me.obj_heinvregister_descr.Text = "") Then
                msgerr = "Descr belum diisi"
                Me._FormErrorProvider.SetError(Me.obj_heinvregister_descr, msgerr)
                Throw New Exception(msgerr)
            End If

            If Me.obj_currency_id.SelectedValue = "0" Then
                msgerr = "Currency belum diisi"
                Me._FormErrorProvider.SetError(Me.obj_currency_id, msgerr)
                Throw New Exception(msgerr)
            End If

            If Trim(Me.obj_season_id.Text = "0") Or Trim(Me.obj_season_id.Text) = "" Then
                msgerr = "Season belum diisi"
                Me._FormErrorProvider.SetError(Me.obj_season_id, msgerr)
                Throw New Exception(msgerr)
            End If

            If Trim(Me.obj_rekanan_id.Text = "0") Or Trim(Me.obj_rekanan_id.Text) = "" Then
                msgerr = "Rekanan belum diisi"
                Me._FormErrorProvider.SetError(Me.obj_rekanan_id, msgerr)
                Throw New Exception(msgerr)
            End If





        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Title & " - Save Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cancel = True
        End Try
    End Sub

    Private Sub ui_FormSaving(ByRef id As Object, ByRef service As String, ByRef datasent As Object) Handles Me.FormSaving

    End Sub

    Private Sub ui_FormSaved(ByRef id As Object, ByVal respond As String, ByVal result As Translib.uiBase.EFormSaveResult, ByVal obj As Object, ByVal supressmessage As Boolean) Handles Me.FormSaved
        If Not supressmessage Then
            If result = EFormSaveResult.SaveSuccess Then
                If Me.DgvDetilItem.Rows.Count = 0 Then
                    Me.btnPasteFromSpreadSheet.Enabled = True
                Else
                    Me.btnPasteFromSpreadSheet.Enabled = False
                End If
                MessageBox.Show("Data Tersimpan", Me.Title & " - Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub ui_FormPrintPreviewExecuting(ByRef cancel As Boolean, ByRef args As Object, ByRef ids As Object, ByRef reportparams() As Microsoft.Reporting.WinForms.ReportParameter, ByRef dllfile As String, ByRef rdlcobjectname As String, ByRef webpage As String, ByRef customprinting As Boolean, ByRef customprintingclass As String) Handles Me.FormPrintPreviewExecuting
        Dim param1 As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("PARAM_00", "PARAM 00 VALUE")

        reportparams = New Microsoft.Reporting.WinForms.ReportParameter() _
                            {param1}

        args = New Object() {"agung"}

        'Disini digunakan untuk mengatur setting tampilan report
        'mengarahkan dllfile dan object name nya
        'pop up untuk pilihan2 lain
        'atau mengirimkan args untuk di hack di funcsi PrintingCustom.Print
        'misalnya untuk mencetak di dot matrik

    End Sub

    Private Sub ui_FormBeforeNew(ByRef result As Object, ByRef cancel As Boolean, ByRef args As Object) Handles Me.FormBeforeNew
        If Me.obj_search_cbo_region_id.SelectedValue = "0" Then
            MessageBox.Show("Region Belum diisi", Me.Title & " - New", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cancel = True
            Exit Sub
        End If

        Me.tblList_Temp.Columns("region_id").DefaultValue = Me.obj_search_cbo_region_id.SelectedValue
    End Sub

    Private Sub ui_FormAfterNew(ByVal result As Object, ByVal args As Object) Handles Me.FormAfterNew
        Me._FormErrorProvider.Clear()

        Me.LastRow = 0
        Me.obj_region_id.Enabled = False
        Me.obj_heinvregister_issizing.Enabled = True

        Me.btnUpload.Enabled = False
        Me.btnPasteFromSpreadSheet.Enabled = False

        Me.tbtnRowAdd.Enabled = False
        Me.tbtnRowDel.Enabled = False

        Me.obj_heinvregister_issizing.Checked = True
        Me.obj_heinvregister_issizing.Enabled = False


        Me.obj_heinvregister_issizing_CheckedChanged(Me.obj_heinvregister_issizing, New System.EventArgs)
    End Sub

    Private Sub ui_FormRowAdding(ByVal tabname As String, ByVal table As System.Data.DataTable, ByRef dialogname As String, ByRef cancel As Boolean, ByRef args As Object) Handles Me.FormRowAdding
        Me.ui_FormRowEditing(tabname, table, dialogname, cancel, args)
    End Sub

    Private Sub ui_FormRowEditing(ByVal tabname As String, ByVal table As System.Data.DataTable, ByRef dialogname As String, ByRef cancel As Boolean, ByRef args As Object) Handles Me.FormRowEditing
        Select Case tabname
        End Select
    End Sub

    Private Sub ui_FormRowDeleting(ByVal tabname As String, ByVal row As System.Windows.Forms.DataGridViewRow, ByRef confirm As Boolean, ByRef msg As String, ByRef cancel As String, ByRef args As Object) Handles Me.FormRowDeleting
        Select Case tabname
        End Select
    End Sub

#End Region

#Region " Background Worker - Paste From Spread Sheet "

    Private Sub bgwPaste_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles bgwPaste.Disposed
    End Sub

    Private Sub bgwPaste_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwPaste.DoWork
        Dim result As PasteFromSpreadSheetResult = New PasteFromSpreadSheetResult()
        Dim strRows() As String
        Dim strColumns() As String
        Dim irow As Integer


        Try
            Dim param As PasteFromSpreadSheetParam = CType(e.Argument, PasteFromSpreadSheetParam)
            result.param = param

            'Paste dari Spreadsheet
            strRows = param.strRows
            For irow = 1 To strRows.Length - 2
                strColumns = strRows(irow).Split(vbTab)
                If Me.InvokeRequired Then
                    Dim d As New BackgroundworkerAddDetilItemRowsInvokeFunction(AddressOf AddDetilItemRowsFromClipboard)
                    Me.Invoke(d, New Object() {strColumns, param.sizing})
                End If
            Next

            result.success = True
            e.Result = result
        Catch ex As Exception
            result.success = False
            result.errormessage = ex.Message
            e.Result = result
        End Try
    End Sub

    Private Sub bgwPaste_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwPaste.ProgressChanged
    End Sub

    Private Sub bgwPaste_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwPaste.RunWorkerCompleted
        Dim result As PasteFromSpreadSheetResult

        Try
            result = CType(e.Result, PasteFromSpreadSheetResult)
            If e.Cancelled Then
                MessageBox.Show("Cancel Progress")
            End If

            Me.DgvDetilItem.DataSource = Me.ddBinding.Tables("DetilItem").Table

            If Not result.success Then Throw New Exception(result.errormessage)

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Title & " - Paste From SpreadSheet", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Enabled = True
            Me.Cursor = Cursors.Arrow
            Me.btnPasteFromSpreadSheet.Enabled = False
            Me.btnUpload.Enabled = True
            Me.bgwPaste = Nothing
            Me.btnPasteFromSpreadSheet.Text = TxtBtnPasteFromSpreadsheed

            Me.obj_heinvregister_issizing.Enabled = False
        End Try
    End Sub

#End Region

#Region " Background Worker - Upload Data "

    Private Sub bgwUpload_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles bgwUpload.Disposed
    End Sub

    Private Sub bgwUpload_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwUpload.DoWork
        Dim result As UploadDataResult = New UploadDataResult()
        Dim tbl As DataTable
        Dim page, rowindex As Integer
        Dim row As DataRow
        Dim pageLength As Integer = 100
        Dim total As Integer = 0
        Dim obj As Newtonsoft.Json.JavaScriptObject
        Dim arrObj As Newtonsoft.Json.JavaScriptArray
        Dim objDet As Newtonsoft.Json.JavaScriptObject
        Dim objArrDataSent As Newtonsoft.Json.JavaScriptArray
        Dim service As String
        Dim strJson As String
        Dim wConn As Translib.WebConnection
        Dim objWebResult As Translib.WebResultObject
        Dim respond As String = ""

        Try
            Dim param As UploadDataParam = CType(e.Argument, UploadDataParam)
            result.param = param
            service = CreateWebService(Me.WebserviceNSModule, Me.WebserviceObjectModule, "upload")

            Me.Status = "Uploading Data..."


            'Ambil data
            tbl = param.Table
            If Me.InvokeRequired Then
                Dim d As New BackgroundworkerInvokeFunction(AddressOf OpenLoadingIndicator)
                Me.Invoke(d, New Object() {New Object() {service, True, "", param.id, False}, True})
            End If

            For page = 0 To tbl.Rows.Count - 1 Step pageLength
                arrObj = New Newtonsoft.Json.JavaScriptArray()
                objDet = New Newtonsoft.Json.JavaScriptObject()
                objArrDataSent = New Newtonsoft.Json.JavaScriptArray()

                Me.ReportProgress(Me.bgwUpload, 20, String.Format("rows {0} of {1}", page, tbl.Rows.Count))
                For rowindex = page To page + pageLength - 1 Step 1
                    If rowindex <= tbl.Rows.Count - 1 Then
                        total = total + 1
                        row = tbl.Rows(rowindex)
                        If row.RowState <> DataRowState.Deleted Then
                            obj = Me.AddJsonObjectFromRow(tbl, row, row.RowState)
                        Else
                            row.RejectChanges()
                            row.SetModified()
                            obj = Me.AddJsonObjectFromRow(tbl, row, DataRowState.Deleted)
                        End If
                        arrObj.Add(obj)
                    End If
                Next

                ' Kirim ke server
                objDet.Add("DetilItem", arrObj)
                objArrDataSent.Add(objDet)


                strJson = Newtonsoft.Json.JavaScriptConvert.SerializeObject(objArrDataSent)
                wConn = New Translib.WebConnection(Me.WebserviceAddress, Me.SessionID, Me.UserName)
                wConn.addtext("__ID", param.id)
                wConn.addtext("JSONDATA", strJson)
                objWebResult = WebserviceExecute(wConn, service, respond)

                If objWebResult.errors IsNot Nothing Then Throw New Exception(objWebResult.errors.ErrorMessage)
                If objWebResult.data.Count > 0 Then
                    obj = objWebResult.data(0)
                    If Not objWebResult.success Then Throw New Exception(objWebResult.errors.ErrorMessage)
                End If

            Next



            result.success = True
            e.Result = result
        Catch ex As Exception
            result.success = False
            result.errormessage = ex.Message
            e.Result = result
        End Try
    End Sub

    Private Sub bgwUpload_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwUpload.ProgressChanged
        Me.fLoadingIndicator.SetMessage(Me.Message)
        Me.fLoadingIndicator.Refresh()
    End Sub

    Private Sub bgwUpload_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwUpload.RunWorkerCompleted
        Dim result As UploadDataResult

        Try
            Me.fLoadingIndicator.Hide()
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
            Me.DisableForm(False)

            result = CType(e.Result, UploadDataResult)
            If e.Cancelled Then
                MessageBox.Show("Cancel Progress")
            End If

            If Not result.success Then Throw New Exception(result.errormessage)
            MessageBox.Show("Upload data selesai", Me.Title & " - Upload Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.btnUpload.Enabled = False
            Me.ddBinding.Tables("DetilItem").Table.AcceptChanges()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Title & " - Upload Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.btnUpload.Enabled = True
        Finally
            Me.Enabled = True
            Me.btnUpload.Cursor = Cursors.Arrow
            Me.Cursor = Cursors.Arrow
            Me.btnUpload.Text = "Upload"
            Me.bgwUpload = Nothing
        End Try

    End Sub

#End Region

#Region " Background Worker - bgwLoadDetil "

    Private Sub bgwLoadDetil_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles bgwLoadDetil.Disposed
    End Sub

    Private Sub bgwLoadDetil_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwLoadDetil.DoWork
        Dim result As LoadDataDetilResult = New LoadDataDetilResult()
        Dim service As String
        Dim tbl As DataTable = New DataTable
        Dim tblresult As DataTable = New DataTable
        Dim CriteriaBuilder As Translib.QueryCriteria
        Dim criteria As String = ""
        Dim respond As String = ""

        Try
            Dim param As LoadDataDetilParam = CType(e.Argument, LoadDataDetilParam)
            result.param = param
            service = CreateWebService(Me.WebserviceNSModule, Me.WebserviceObjectModule, "loaddatadetil")

            Me.Status = "Loading rest of Data Detil..."
            If Me.InvokeRequired Then
                Dim d As New BackgroundworkerInvokeFunction(AddressOf OpenLoadingIndicator)
                Me.Invoke(d, New Object() {New Object() {service, True, "", param.id, False}, True})
            End If

            'Dim page As Integer = CInt(param.totalrows / 100)
            Dim i As Integer

            For i = 0 To param.totalrows - 1 Step 100
                CriteriaBuilder = New Translib.QueryCriteria()
                CriteriaBuilder.AddCriteria("heinvregister_id", True, param.id)
                CriteriaBuilder.AddCriteria("offset", True, i)
                criteria = CriteriaBuilder.Serialize()

                Me.ReportProgress(Me.bgwLoadDetil, 20, String.Format("rows {0} of {1}", i, param.totalrows))
                tbl = Me.LoadDataIntoDatatable(service, criteria, respond)
                tblresult.Merge(tbl)

            Next


            ' Masukkan ke Table Detil Item
            Me.ReportProgress(Me.bgwLoadDetil, 20, "Finalizing data")
            If Me.InvokeRequired Then
                Dim d As New BackgroundworkerMergeTableDetilItemInvokeFunction(AddressOf MergeTableDetilItem)
                Me.Invoke(d, New Object() {tblresult})
            End If



            result.table = tblresult
            result.success = True
            e.Result = result
        Catch ex As Exception
            result.success = False
            result.errormessage = ex.Message
            e.Result = result
        End Try
    End Sub

    Private Sub bgwLoadDetil_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwLoadDetil.ProgressChanged
        Me.fLoadingIndicator.SetMessage(Me.Message)
        Me.fLoadingIndicator.Refresh()
    End Sub

    Private Sub bgwLoadDetil_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwLoadDetil.RunWorkerCompleted
        Dim result As LoadDataDetilResult


        Try
            Me.fLoadingIndicator.Hide()
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
            Me.DisableForm(False)

            Me.ddBinding.Tables("DetilItem").Table.AcceptChanges()
            Me.DgvDetilItem.DataSource = Me.ddBinding.Tables("DetilItem").Table


            result = CType(e.Result, LoadDataDetilResult)
            If Not result.success Then Throw New Exception(result.errormessage)


            'Me.ddBinding.Tables("DetilItem").Table.AcceptChanges()
            'Me.DgvDetilItem.DataSource = Me.ddBinding.Tables("DetilItem").Table
            'Me.DgvDetilItem.DataSource = Nothing
            'Me.ddBinding.Tables("DetilItem").Table = New DataTable
            ''Me.ddBinding.Tables("DetilItem").Table.PrimaryKey = Nothing ' New System.Data.DataColumn() {tbl.Columns("heinvregister_id"), tbl.Columns("heinvregisteritem_line")}
            ''With Me.ddBinding.Tables("DetilItem").Table.Columns("heinvregisteritem_line")
            ''    .DefaultValue = DBNull.Value
            ''    .AutoIncrement = False
            ''End With
            '' Me.ddBinding.Tables("DetilItem").Table.Columns("heinvregisteritem_line").DataType = GetType(System.Int32)
            'Me.ddBinding.Tables("DetilItem").Table.Columns.Add("heinvregisteritem_line", GetType(System.Int64))
            'Me.ddBinding.Tables("DetilItem").Table.Merge(result.table)
            'Me.ddBinding.Tables("DetilItem").Table.AcceptChanges()
            'Me.ddBinding.Tables("DetilItem").Table.PrimaryKey = New System.Data.DataColumn() {Me.ddBinding.Tables("DetilItem").Table.Columns("heinvregister_id"), Me.ddBinding.Tables("DetilItem").Table.Columns("heinvregisteritem_line")}
            'With Me.ddBinding.Tables("DetilItem").Table.Columns("heinvregisteritem_line")
            '    .DefaultValue = DBNull.Value
            '    .AutoIncrement = True
            '    .AutoIncrementSeed = 10
            '    .AutoIncrementStep = 10
            'End With
            'Me.DgvDetilItem.DataSource = Me.ddBinding.Tables("DetilItem").Table


        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Title & " - Load Data Detil", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Arrow
            Me.bgwLoadDetil = Nothing
        End Try
    End Sub

#End Region


    Private Sub btn_rekanan_id_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_rekanan_id.Click
        Dim objBtn As Button = CType(sender, Button)
        Dim objId As TextBox = New TextBox()
        Dim objName As Label = New Label()

        Dim services As String = CreateWebService(Me.WebserviceNSGlobal, Me.WebserviceObjectGlobal, "load_rekanan_all")
        Dim o As Translib.GeneralObject = New Translib.GeneralObject()
        Dim dgvcols As System.Windows.Forms.DataGridViewColumn() = New System.Windows.Forms.DataGridViewColumn() _
        { _
           Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "rekanan_id", "ID", "rekanan_id", 75), _
           Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "rekanan_name", "NAME", "rekanan_name", 150), _
           Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "rekanan_address", "ADDRESS", "rekanan_address", 250) _
        }

        Dim criteria As Translib.QueryCriteria = New Translib.QueryCriteria()


        Select Case objBtn.Name
            Case "obj_search_btn_rekanan_id"
            Case "btn_rekanan_id"
                objId = Me.obj_rekanan_id
                objName = Me.obj_rekanan_name
        End Select


        Dim result As Object
        Dim dlg As Translib.dlgBaseMaster = Me.CreateDialog(o.GetType().Assembly.GetType("Translib.dlgBaseMaster", True, True), Me.Title)
        dlg.SetSelected("rekanan_id", objId.Text, "rekanan_name", objName.Text)
        dlg.Argument = New Object() {services, criteria, dgvcols}
        result = dlg.OpenDialog(Me, Me.WebserviceAddress, Me.DLLServer, Me.UserName, Me.SessionID)

        If result Is Nothing Then Exit Sub
        objId.Text = result(0)
        objName.Text = result(1)
    End Sub

    Private Sub btn_season_id_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_season_id.Click
        Dim btn As Button = CType(sender, Button)
        Dim obj_id As TextBox = New TextBox
        Dim obj_name As Label = New Label

        Select Case btn.Name
            Case "btn_season_id"
                obj_id = Me.obj_season_id
                obj_name = Me.obj_season_name
                'Case "obj_search_btn_season_id"
                '    obj_id = Me.obj_search_txt_season_id
                '    obj_name = Me.obj_search_txt_season_name
        End Select


        Dim services As String = CreateWebService(Me.WebserviceNSGlobal, Me.WebserviceObjectGlobal, "load_season_all")
        Dim o As Translib.GeneralObject = New Translib.GeneralObject()
        Dim dgvcols As System.Windows.Forms.DataGridViewColumn() = New System.Windows.Forms.DataGridViewColumn() _
        { _
           Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "season_id", "ID", "season_id", 75), _
           Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "season_name", "NAME", "season_name", 150) _
        }

        Dim criteria As Translib.QueryCriteria = New Translib.QueryCriteria()

        Dim result As Object
        Dim dlg As Translib.dlgBaseMaster = Me.CreateDialog(o.GetType().Assembly.GetType("Translib.dlgBaseMaster", True, True), Me.Title)
        Dim selectedtext As String
        If obj_name.Text = SelectedDefaultText Then
            selectedtext = ""
        Else
            selectedtext = obj_name.Text
        End If
        dlg.SetSelected("season_id", obj_id.Text, "season_name", selectedtext)
        dlg.Argument = New Object() {services, criteria, dgvcols}
        result = dlg.OpenDialog(Me, Me.WebserviceAddress, Me.DLLServer, Me.UserName, Me.SessionID)

        If result Is Nothing Then Exit Sub
        obj_id.Text = result(0)
        obj_name.Text = result(1)
    End Sub

    Private Sub btn_PasteFromSpreadSheet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPasteFromSpreadSheet.Click

        If Me.ProgName <> "register_entry" Then
            Exit Sub
        End If

        ' jika data belum disimpan, tidak bisa btnPaste
        If Me.DataIsChanged(Me.tblList_Temp, Me.ddBinding) Then
            MessageBox.Show("Data Belum di Save." & vbCrLf & "Silakan simpan data sebelum paste data", Me.Title & " - Paste", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        ' Dim strContent As String = Me.GetCliboardText()
        Dim colSignSizing, colSignNoSizing As String
        Dim strRows() As String
        Dim strColumns() As String
        Dim icol As Integer
        Dim cnames As String = ""
        Dim strColContent As String

        strRows = Clipboard.GetText().Split(Environment.NewLine)

        'Cek baris pertama dari cliboard
        strColumns = strRows(0).Split(vbTab)
        For icol = 0 To strColumns.Length - 1
            strColContent = Trim(strColumns(icol))
            If strColContent <> "" Then
                cnames &= strColContent & "|"
            End If
        Next

        'Hasil cnames harus sesuai 
        'CTGID|ART|MAT|COL|NAME|DESCR|GTYPE|PRODUK|BAHAN|PEMELIHARAAN|LOGO|DIBUAT DI|OTHER|PRICE|TAG|C1|C2|C3|C4|C5|C6|C7|C8|C9|C1|C11|C12|C13|C14|C15|C16|C17|C18|C19|C2|C21|C22|C23|C24|C25|
        colSignNoSizing = "CTGID|ART|MAT|COL|NAME|DESCR|BOX|GTYPE|PRODUK|BAHAN|PEMELIHARAAN|LOGO|DIBUAT DI|OTHER|BRANCH|PRICE|TAG|C1|C2|C3|C4|C5|C6|C7|C8|C9|C1|C11|C12|C13|C14|C15|C16|C17|C18|C19|C2|C21|C22|C23|C24|C25|"
        colSignSizing = "CTGID|ART|MAT|COL|SIZE|BARCODE|NAME|DESCR|PRINCIPAL_LINE|PRINCIPAL_GROUP|PRINCIPAL_CATEGORY|COLOR_DESCR|GENDER|BOX|GTYPE|PRODUK|BAHAN|PEMELIHARAAN|LOGO|DIBUAT DI|OTHER|BRANCH|PRICE|QTY|FIT|HSCODE|NAMA_DI_PLB|WEBENABLED|WEIGHT|LENGTH|WIDTH|HEIGHT|WEBDESCR|"

        Try
            If Me.obj_heinvregister_issizing.Checked Then
                ' Cek apakah format data (use sizing) sama
                If cnames.ToUpper <> colSignSizing Then
                    Throw New Exception()
                End If
            Else
                ' Cek apakah format data (no sizing) sama
                If Mid(cnames.ToUpper, 1, 101) <> Mid(colSignNoSizing, 1, 101) And strColumns(40).ToUpper = "C25" Then
                    Throw New Exception()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Format data tidak sesuai" & vbCrLf & ex.Message, Me.Title & " - Paste From SpreadSheet", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try


        If Me.bgwPaste Is Nothing Then
            Me.bgwPaste = New System.ComponentModel.BackgroundWorker
            Me.bgwPaste.WorkerReportsProgress = True
            Me.bgwPaste.WorkerSupportsCancellation = True
        End If

        If Me.btnPasteFromSpreadSheet.Text = TxtBtnPasteFromSpreadsheed Then
            Dim param As PasteFromSpreadSheetParam = New PasteFromSpreadSheetParam

            param.strRows = strRows
            param.sizing = Me.obj_heinvregister_issizing.Checked

            Me.Cursor = Cursors.WaitCursor
            Me.Enabled = False
            Me.btnPasteFromSpreadSheet.Text = TxtBtnPasteFromSpreadsheedCancel
            Me.DgvDetilItem.DataSource = Nothing

            ' Run Asyncronous
            Me.bgwPaste.RunWorkerAsync(param)
        Else
            Me.bgwPaste.CancelAsync()
        End If

    End Sub

    Private Sub btn_Upload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        Dim dt_changes As DataTable = Nothing

        If Me.DataIsChanged(Me.tblList_Temp, Me.ddBinding) Then
            Me.BindingContext(Me.ddBinding.Tables("DetilItem")).EndCurrentEdit()
            dt_changes = Me.ddBinding.Tables("DetilItem").Table.GetChanges()
            If dt_changes IsNot Nothing Then
                If Me.bgwUpload Is Nothing Then
                    Me.bgwUpload = New System.ComponentModel.BackgroundWorker
                    Me.bgwUpload.WorkerReportsProgress = True
                    Me.bgwUpload.WorkerSupportsCancellation = True
                End If

                If Me.btnUpload.Text = "Upload" Then
                    Dim param As UploadDataParam = New UploadDataParam

                    param.id = Me.obj_heinvregister_id.Text
                    param.Table = dt_changes

                    Me.btnUpload.Cursor = Cursors.WaitCursor
                    Me.Cursor = Cursors.WaitCursor
                    Me.Enabled = False
                    Me.btnUpload.Text = "Cancel"

                    ' Run Asyncronous
                    Me.bgwUpload.RunWorkerAsync(param)
                Else
                    Me.bgwUpload.CancelAsync()
                End If

                'For rowIndex = 0 To dt_changes.Rows.Count - 1
                '    row = dt_changes.Rows(rowIndex)
                '    'If row.RowState <> DataRowState.Deleted Then
                '    '    obj = Me.AddJsonObjectFromRow(dt_changes, row, row.RowState)
                '    'Else
                '    '    row.RejectChanges()
                '    '    row.SetModified()
                '    '    obj = Me.AddJsonObjectFromRow(dt_changes, row, DataRowState.Deleted)
                '    'End If
                '    'arrObj.Add(obj)
                'Next
            End If

        End If
    End Sub


    Private Sub obj_heinvregister_issizing_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_heinvregister_issizing.CheckedChanged
        Dim obj As CheckBox = CType(sender, CheckBox)

        If obj.Checked Then
            ' Jika sizing
            Me.DgvDetilItem.Columns("heinv_size").Visible = True
            Me.DgvDetilItem.Columns("heinv_barcode").Visible = True
            Me.DgvDetilItem.Columns("C00").Visible = True
            Me.DgvDetilItem.Columns("C01").Visible = True
            Me.DgvDetilItem.Columns("C02").Visible = False
            Me.DgvDetilItem.Columns("C03").Visible = False
            Me.DgvDetilItem.Columns("C04").Visible = False
            Me.DgvDetilItem.Columns("C05").Visible = False
            Me.DgvDetilItem.Columns("C06").Visible = False
            Me.DgvDetilItem.Columns("C07").Visible = False
            Me.DgvDetilItem.Columns("C08").Visible = False
            Me.DgvDetilItem.Columns("C09").Visible = False
            Me.DgvDetilItem.Columns("C10").Visible = False
            Me.DgvDetilItem.Columns("C11").Visible = False
            Me.DgvDetilItem.Columns("C12").Visible = False
            Me.DgvDetilItem.Columns("C13").Visible = False
            Me.DgvDetilItem.Columns("C14").Visible = False
            Me.DgvDetilItem.Columns("C15").Visible = False
            Me.DgvDetilItem.Columns("C16").Visible = False
            Me.DgvDetilItem.Columns("C17").Visible = False
            Me.DgvDetilItem.Columns("C18").Visible = False
            Me.DgvDetilItem.Columns("C19").Visible = False
            Me.DgvDetilItem.Columns("C20").Visible = False
            Me.DgvDetilItem.Columns("C21").Visible = False
            Me.DgvDetilItem.Columns("C22").Visible = False
            Me.DgvDetilItem.Columns("C23").Visible = False
            Me.DgvDetilItem.Columns("C24").Visible = False
            Me.DgvDetilItem.Columns("C25").Visible = False

            Me.DgvDetilItem.Columns("C00").HeaderText = "Qty"
            Me.DgvDetilItem.Columns("C01").HeaderText = "Actual"
            Me.DgvDetilItem.Columns("heinv_size").Frozen = True
        Else
            Me.DgvDetilItem.Columns("heinv_size").Visible = False
            Me.DgvDetilItem.Columns("heinv_barcode").Visible = False
            Me.DgvDetilItem.Columns("C00").Visible = False
            Me.DgvDetilItem.Columns("C01").Visible = True
            Me.DgvDetilItem.Columns("C02").Visible = True
            Me.DgvDetilItem.Columns("C03").Visible = True
            Me.DgvDetilItem.Columns("C04").Visible = True
            Me.DgvDetilItem.Columns("C05").Visible = True
            Me.DgvDetilItem.Columns("C06").Visible = True
            Me.DgvDetilItem.Columns("C07").Visible = True
            Me.DgvDetilItem.Columns("C08").Visible = True
            Me.DgvDetilItem.Columns("C09").Visible = True
            Me.DgvDetilItem.Columns("C10").Visible = True
            Me.DgvDetilItem.Columns("C11").Visible = True
            Me.DgvDetilItem.Columns("C12").Visible = True
            Me.DgvDetilItem.Columns("C13").Visible = True
            Me.DgvDetilItem.Columns("C14").Visible = True
            Me.DgvDetilItem.Columns("C15").Visible = True
            Me.DgvDetilItem.Columns("C16").Visible = True
            Me.DgvDetilItem.Columns("C17").Visible = True
            Me.DgvDetilItem.Columns("C18").Visible = True
            Me.DgvDetilItem.Columns("C19").Visible = True
            Me.DgvDetilItem.Columns("C20").Visible = True
            Me.DgvDetilItem.Columns("C21").Visible = True
            Me.DgvDetilItem.Columns("C22").Visible = True
            Me.DgvDetilItem.Columns("C23").Visible = True
            Me.DgvDetilItem.Columns("C24").Visible = True
            Me.DgvDetilItem.Columns("C25").Visible = True

            Me.DgvDetilItem.Columns("C00").HeaderText = "C00"
            Me.DgvDetilItem.Columns("C01").HeaderText = "C01"
            Me.DgvDetilItem.Columns("heinv_col").Frozen = True
        End If

    End Sub

    Private Sub DgvList_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvList.CellFormatting
        Dim dgv As DataGridView = CType(sender, DataGridView)
        Dim posted As Boolean = dgv("heinvregister_isposted", e.RowIndex).Value
        Dim generated As Boolean = dgv("heinvregister_isgenerated", e.RowIndex).Value


        If generated Then
            e.CellStyle.BackColor = Color.Gainsboro
        Else
            If posted Then
                e.CellStyle.BackColor = Color.Thistle
            Else
                e.CellStyle.BackColor = Color.White
            End If
        End If
    End Sub

    Private Sub DgvDetilItem_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvDetilItem.CellFormatting
        Dim dgv As DataGridView = CType(sender, DataGridView)
        Dim cellErr As DataGridViewCell

        cellErr = dgv.Rows(e.RowIndex).Cells("err")


        If Me.obj_heinvregister_isgenerated.Checked Then
            Exit Sub
        End If

        Try
            If cellErr.Value = "7000000" Then
                e.CellStyle.BackColor = Color.Orange
            Else
                If CInt(cellErr.Value) <> 0 And CInt(cellErr.Value) <> 99 Then
                    e.CellStyle.BackColor = Color.Coral
                Else
                    '    e.CellStyle.BackColor = Nothing
                End If
            End If



        Catch ex As Exception
        End Try

    End Sub

    Private Sub btnGotoError_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGotoError.Click
        Dim i As Long
        Dim ErrNum As Integer
        Dim startrow As Long

        If Me.DgvDetilItem.CurrentRow.Index > Me.LastRow Then
            startrow = Me.DgvDetilItem.CurrentRow.Index
        Else
            startrow = Me.LastRow
        End If


        For i = startrow To Me.DgvDetilItem.Rows.Count - 1
            ErrNum = CInt(Me.DgvDetilItem.Rows(i).Cells("ERR").Value)

            If ErrNum > 0 Then
                Me.LastRow = i
                Me.DgvDetilItem.FirstDisplayedScrollingRowIndex = i
                Exit For
            End If

            If i = Me.DgvDetilItem.Rows.Count - 1 Then
                Me.LastRow = 0
            End If
        Next
    End Sub

    Private Sub obj_branch_id_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_branch_id.DropDown
        Dim cbo As ComboBox = CType(sender, ComboBox)
        Dim tbl As DataTable = New DataTable()
        Dim service As String = CreateWebService(Me.WebserviceNSGlobal, Me.WebserviceObjectGlobal, "load_branch_byuser_login")
        Dim CriteriaBuilder As Translib.QueryCriteria = New Translib.QueryCriteria()
        Dim criteria As String = ""
        Dim respond As String = ""
        Dim lastvalue As String = cbo.SelectedValue


        ' Default Criteria
        CriteriaBuilder.AddCriteria("selectall", 1, "1")
        CriteriaBuilder.AddCriteria("region_id", 1, Me.obj_region_id.SelectedValue)

        criteria = CriteriaBuilder.Serialize()
        Me.Cursor = Cursors.WaitCursor
        Try
            tbl = LoadDataIntoDatatable(service, criteria, respond)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Me.Cursor = Cursors.Arrow

        Translib.uiBase.ComboLink(cbo, "branch_id", "branch_name", tbl, True, True)

        If tbl.Select(String.Format("branch_id='{0}'", lastvalue)).Length > 0 Then
            cbo.SelectedValue = lastvalue
        End If
    End Sub

    Private Sub obj_branch_id_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_branch_id.SelectedIndexChanged

    End Sub

    Private Sub PnlDataMaster_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PnlDataMaster.Paint

    End Sub


End Class

Public Class uiBase

    Public Enum FormSaveResult
        Nochanges = 0
        SaveError = 1
        SaveSuccess = 2
    End Enum


    Private mParameter As String
    Private mBrowser As Object = Nothing


    Friend Event FormBeforeOpenRow(ByRef id As Object)
    Friend Event FormAfterOpenRow(ByRef id As Object)
    Friend Event FormBeforeSave(ByRef id As Object)
    Friend Event FormAfterSave(ByRef id As Object, ByVal result As FormSaveResult)
    Friend Event FormBeforeNew(ByRef result As Object)
    Friend Event FormAfterNew(ByVal result As Object)
    Friend Event FormAfterLoad()
    Friend Event FormBeforeDelete(ByRef id As Object)
    Friend Event FormAfterDelete(ByRef id As Object)

    Friend mUsername As String = "root"
    Friend mWebserviceAddress As String = "http://localhost/transbrowser"
    Friend mDllServer As String = "http://localhost/transbrowser"




#Region " Property "


    Public ReadOnly Property Parameter() As String
        Get
            Return mParameter
        End Get
    End Property

    Public ReadOnly Property UserName() As String
        Get
            Return mUsername
        End Get
    End Property


    Public ReadOnly Property DLLServer() As String
        Get
            Return mDllServer
        End Get
    End Property

    Public ReadOnly Property WebserviceAddress() As String
        Get
            Return mWebserviceAddress
        End Get
    End Property

    Public ReadOnly Property Browser() As Object
        Get
            Return mBrowser
        End Get
    End Property

#End Region

#Region " Overridable "

    Public Overridable Function btnNew_Click() As Boolean
    End Function

    Public Overridable Function btnSave_Click() As Boolean
    End Function

    Public Overridable Function btnPrint_Click() As Boolean
    End Function

    Public Overridable Function btnPrintPreview_Click() As Boolean
    End Function

    Public Overridable Function btnEdit_Click() As Boolean
    End Function

    Public Overridable Function btnDel_Click() As Boolean
    End Function

    Public Overridable Function btnLoad_Click() As Boolean
    End Function

    Public Overridable Function btnQuery_Click() As Boolean
    End Function

    Public Overridable Function btnRefresh_Click() As Boolean
    End Function

    Public Overridable Function btnReset_Click() As Boolean
    End Function

    Public Overridable Function btnRowAdd_Click() As Boolean
    End Function

    Public Overridable Function btnRowDel_Click() As Boolean
    End Function

    Public Overridable Function btnFirst_Click() As Boolean
    End Function

    Public Overridable Function btnPrev_Click() As Boolean
    End Function

    Public Overridable Function btnNext_Click() As Boolean
    End Function

    Public Overridable Function btnLast_Click() As Boolean
    End Function

    Public Overridable Function btnHelpTopic_Click() As Boolean
    End Function

    Public Overridable Function btnShowStatus_Click() As Boolean
    End Function

    Public Overridable Function btnShowConsole_Click() As Boolean
    End Function

    Public Overridable Function btnReserved1_Click() As Boolean
    End Function

    Public Overridable Function btnReserved2_Click() As Boolean
    End Function

    Public Overridable Function btnReserved3_Click() As Boolean
    End Function

    Public Overridable Function btnReserved4_Click() As Boolean
    End Function

    Public Overridable Function btnReserved5_Click() As Boolean
    End Function

    Public Overridable Function btnReserved6_Click() As Boolean
    End Function

#End Region

#Region " ToolStripButton Event "

    Private Sub tbtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnNew.Click
        Me.btnNew_Click()
    End Sub

    Private Sub tbtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnSave.Click
        Me.btnSave_Click()
    End Sub

    Private Sub tbtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnPrint.Click
        Me.btnPrint_Click()
    End Sub

    Private Sub tbtnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnPrintPreview.Click
        Me.btnPrintPreview_Click()
    End Sub


    Private Sub tbtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnEdit.Click
        Me.btnEdit_Click()
    End Sub

    Private Sub tbtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnDel.Click
        Me.btnDel_Click()
    End Sub


    Private Sub tbtnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnLoad.Click
        Me.btnLoad_Click()
    End Sub

    Private Sub tbtnQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnQuery.Click
        Me.btnQuery_Click()
    End Sub

    Private Sub tbtnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnRefresh.Click
        Me.btnRefresh_Click()
    End Sub

    Private Sub tbtnRowAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnRowAdd.Click
        Me.btnRowAdd_Click()
    End Sub

    Private Sub tbtnRowDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnRowDel.Click
        Me.btnRowDel_Click()
    End Sub


    Private Sub tbtnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnFirst.Click
        Me.btnFirst_Click()
    End Sub

    Private Sub tbtnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnPrev.Click
        Me.btnPrev_Click()
    End Sub

    Private Sub tbtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnNext.Click
        Me.btnNext_Click()
    End Sub

    Private Sub tbtnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnLast.Click
        Me.btnLast_Click()
    End Sub

#End Region

#Region " Syncronisasi "

    Private Sub tbtnNew_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbtnNew.EnabledChanged
        Me._SyncronizeControlEnableState("New", tbtnNew.Enabled)
    End Sub

    Private Sub tbtnSave_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbtnSave.EnabledChanged
        Me._SyncronizeControlEnableState("Save", tbtnSave.Enabled)
    End Sub

    Private Sub tbtnPrint_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbtnPrint.EnabledChanged
        Me._SyncronizeControlEnableState("Print", tbtnPrint.Enabled)
    End Sub

    Private Sub tbtnPrintPreview_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbtnPrintPreview.EnabledChanged
        Me._SyncronizeControlEnableState("PrintPreview", tbtnPrintPreview.Enabled)
    End Sub

    Private Sub tbtnDel_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbtnDel.EnabledChanged
        Me._SyncronizeControlEnableState("Delete", tbtnDel.Enabled)
    End Sub

    Private Sub tbtnLoad_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbtnLoad.EnabledChanged
        Me._SyncronizeControlEnableState("LoadData", tbtnLoad.Enabled)
    End Sub

    Private Sub tbtnQuery_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbtnQuery.EnabledChanged
        Me._SyncronizeControlEnableState("Queri", tbtnQuery.Enabled)
    End Sub

    Public Sub SyncronizeControlEnableState()
        If Me.Browser IsNot Nothing Then
            If Me.Browser.Name IsNot Nothing Then
                Me.Browser.MenuEnabled("New", tbtnNew.Enabled)
                Me.Browser.MenuEnabled("Save", tbtnSave.Enabled)
                Me.Browser.MenuEnabled("Print", tbtnPrint.Enabled)
                Me.Browser.MenuEnabled("PrintPreview", tbtnPrintPreview.Enabled)
                Me.Browser.MenuEnabled("Delete", tbtnDel.Enabled)
                Me.Browser.MenuEnabled("LoadData", tbtnLoad.Enabled)
                Me.Browser.MenuEnabled("Queri", tbtnQuery.Enabled)
            End If
        End If
    End Sub

    Public Sub _SyncronizeControlEnableState(ByVal Name As String, ByVal state As Boolean)
        If Me.Browser IsNot Nothing Then
            If Me.Browser.Name IsNot Nothing Then
                Me.Browser.MenuEnabled(Name, state)
            End If
        End If
    End Sub

#End Region

#Region " DataGridView Column Handler "

    Public Function CreateDataGridViewColumn(ByVal col As System.Windows.Forms.DataGridViewTextBoxColumn, ByVal name As String, ByVal headertext As String, ByVal datapropertyname As String, Optional ByVal width As Integer = 100) As System.Windows.Forms.DataGridViewTextBoxColumn
        col.Name = name
        col.HeaderText = headertext
        col.DataPropertyName = datapropertyname
        col.Width = width
        col.Visible = True
        col.ReadOnly = False
        Return col
    End Function

    Public Function CreateDataGridViewColumn(ByVal col As System.Windows.Forms.DataGridViewComboBoxColumn, ByVal name As String, ByVal headertext As String, ByVal datapropertyname As String, Optional ByVal width As Integer = 100) As System.Windows.Forms.DataGridViewComboBoxColumn
        col.Name = name
        col.HeaderText = headertext
        col.DataPropertyName = datapropertyname
        col.Width = width
        col.Visible = True
        col.ReadOnly = False
        Return col
    End Function

    Public Function CreateDataGridViewColumn(ByVal col As System.Windows.Forms.DataGridViewCheckBoxColumn, ByVal name As String, ByVal headertext As String, ByVal datapropertyname As String, Optional ByVal width As Integer = 100) As System.Windows.Forms.DataGridViewCheckBoxColumn
        col.Name = name
        col.HeaderText = headertext
        col.DataPropertyName = datapropertyname
        col.Width = width
        col.Visible = True
        col.ReadOnly = False
        Return col
    End Function
    Public Function CreateDataGridViewColumn(ByVal col As System.Windows.Forms.DataGridViewButtonColumn, ByVal name As String, ByVal headertext As String, ByVal datapropertyname As String, Optional ByVal width As Integer = 100) As System.Windows.Forms.DataGridViewButtonColumn
        col.Name = name
        col.HeaderText = headertext
        col.DataPropertyName = datapropertyname
        col.Width = width
        col.Visible = True
        col.ReadOnly = False
        Return col
    End Function
    Public Function CreateDataGridViewComboBinding(ByRef objDgv As System.Windows.Forms.DataGridView, ByVal columnname As String, ByVal datavalue As String, ByVal datamember As String, ByVal dt As Data.DataTable) As Boolean
        With CType(objDgv.Columns(columnname), System.Windows.Forms.DataGridViewComboBoxColumn)
            .ValueMember = datavalue
            .DisplayMember = datamember
            .DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
            .DisplayStyleForCurrentCellOnly = True
            .AutoComplete = True
            .DataSource = dt
        End With
        Return True
    End Function


#End Region

#Region " Parameter Processing "

    Public Function GetParameterCollection(ByVal ParameterString As String) As Collection
        Dim i As Integer
        Dim arrParameter() As String
        Dim tempParameterLine() As String
        Dim ParameterKey As String
        Dim ParameterValue As String
        Dim objParameters As Collection = New Collection

        'Parameter = "CHANNEL=TTV; CHANNEL_CANBE_CHANGED=0; CHANNEL_CANBE_BROWSED=0; POSTING_MODE=1; POSTING_AUTHORITY=0; UNPOSTING_AUTHORITY=1;"
        arrParameter = ParameterString.Split(";")
        If Trim(ParameterString) <> "" Then
            For i = 0 To arrParameter.Length - 1
                tempParameterLine = arrParameter(i).Split("=")
                If tempParameterLine.Length = 2 Then
                    ParameterKey = Trim(tempParameterLine(0))
                    ParameterValue = Trim(tempParameterLine(1))

                    If objParameters.Contains(ParameterKey) Then
                        objParameters.Remove(ParameterKey)
                    End If

                    objParameters.Add(ParameterValue, ParameterKey)

                End If
            Next
        End If

        Return objParameters

    End Function

    Public Function GetBolValueFromParameter(ByVal Col As Collection, ByVal key As String) As Boolean
        If Col.Contains(key) Then
            If Col(key) = "0" Or Col(key) = "1" Or Col(key) = "true" Or Col(key) = "false" Then
                If Col(key) = "0" Or Col(key) = "false" Then
                    Return False
                Else
                    Return True
                End If
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function GetIntValueFromParameter(ByVal Col As Collection, ByVal key As String) As Integer
        If Col.Contains(key) Then
            Return CType(Col(key), Integer)
        Else
            Return 0
        End If
    End Function

    Public Function GetValueFromParameter(ByVal Col As Collection, ByVal key As String) As String
        If Col.Contains(key) Then
            Return Col(key)
        Else
            Return ""
        End If
    End Function


#End Region

#Region " Control Initialisation "

    Public Function InitializeControl(ByVal username As String, ByVal webserviceaddress As String, ByRef browser As Object) As Boolean
        Me.mUsername = username
        Me.mWebserviceAddress = webserviceaddress
        Me.mBrowser = browser
        Return True
    End Function

#End Region



    Friend Function MainTabSelect(ByVal sender As Object, ByVal e As System.EventArgs) As String
        Dim obj As FlatTabControl.FlatTabControl = CType(sender, FlatTabControl.FlatTabControl)
        Select Case obj.SelectedTab.Name
            Case "ftabMain_List"
                Me.tbtnSave.Enabled = False
                Me.tbtnDel.Enabled = False
                Me.tbtnLoad.Enabled = True
                Me.tbtnQuery.Enabled = True
                Me.tbtnRowAdd.Enabled = False
                Me.tbtnRowDel.Enabled = False
                obj.TabPages.Item("ftabMain_List").BackColor = Color.WhiteSmoke
                obj.TabPages.Item("ftabMain_Data").BackColor = Color.Gainsboro

            Case "ftabMain_Data"
                Me.tbtnSave.Enabled = True
                Me.tbtnDel.Enabled = True
                Me.tbtnLoad.Enabled = False
                Me.tbtnQuery.Enabled = False
                Me.tbtnRowAdd.Enabled = True
                Me.tbtnRowDel.Enabled = True
                obj.TabPages.Item("ftabMain_List").BackColor = Color.Gainsboro
                obj.TabPages.Item("ftabMain_Data").BackColor = Color.WhiteSmoke
        End Select
        Return obj.SelectedTab.Name
    End Function

    Friend Function SetLocalization() As Boolean
        Dim myCI As New System.Globalization.CultureInfo("en-GB", False)
        Dim myCIclone As System.Globalization.CultureInfo = CType(myCI.Clone(), System.Globalization.CultureInfo)
        myCIclone.DateTimeFormat.AMDesignator = "a.m."
        myCIclone.DateTimeFormat.DateSeparator = "/"
        myCIclone.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        myCIclone.NumberFormat.CurrencySymbol = "Rp "
        myCIclone.NumberFormat.NumberDecimalDigits = 2
        System.Threading.Thread.CurrentThread.CurrentCulture = myCIclone
    End Function





    Private Sub uiBase_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.SetLocalization()
    End Sub



End Class


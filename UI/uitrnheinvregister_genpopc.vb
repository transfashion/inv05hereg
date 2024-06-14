Public Class uitrnheinvregister_genpopc
    Inherits uitrnheinvregister

    Friend WithEvents btnGenerate As ToolStripButton
    Friend WithEvents bgwGenerate As System.ComponentModel.BackgroundWorker



#Region " Constructor "

    Public Sub New()
        Me.DgvDetilItem.ReadOnly = True
    End Sub

#End Region


#Region " User Defined Function "

    Public Overrides Function AddListCriteria(ByRef CriteriaBuilder As Translib.QueryCriteria) As Boolean
        CriteriaBuilder.AddCriteria("obj_search_chk_heinvregister_isposted", True, "1")
        CriteriaBuilder.AddCriteria("obj_search_chk_heinvregister_isgenerated", True, "1")
        CriteriaBuilder.AddCriteria("obj_search_cbo_heinvregister_type", True, "S")
        Return MyBase.AddListCriteria(CriteriaBuilder)
    End Function

    Public Overloads Function SetModifierButtonDisabled() As Boolean
        Me.tbtnNew.Enabled = False
        Me.tbtnSave.Enabled = False
        Me.tbtnDel.Enabled = False
        Me.tbtnRowAdd.Enabled = False
        Me.tbtnRowDel.Enabled = False
    End Function

#End Region




#Region " General Event "

    Private Sub ui_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Me.bgwGenerate IsNot Nothing Then
            Me.bgwGenerate.Dispose()
        End If
    End Sub

    Private Sub ui_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Tambahkan tombol untuk posting
        Me.btnGenerate = New ToolStripButton()
        Me.btnGenerate.Text = "Generate"
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Visible = False
        Me.ToolStrip1.Items.Add(btnGenerate)

        Me.obj_heinvregister_type.Enabled = False
        Me.obj_branch_id.Enabled = False

        Me.SetModifierButtonDisabled()
    End Sub

    Private Sub ui_FormTabmainSelected(ByVal tabname As String) Handles Me.FormTabmainSelected
        ' Set Tombol Disabled, untuk new dan save
        Me.SetModifierButtonDisabled()

        Select Case tabname
            Case "ftabMain_List"
                Me.btnGenerate.Visible = False
            Case "ftabMain_Data"
                Me.btnGenerate.Visible = True
        End Select
    End Sub

    Private Sub ui_FormTabdetilSelected(ByVal tabname As String) Handles Me.FormTabdetilSelected
        ' Set Tombol Disabled, untuk new dan save
        Me.SetModifierButtonDisabled()
    End Sub

    Private Sub ui_FormDataOpened(ByVal id As Object) Handles Me.FormDataOpened
        'If Me.obj_heinvregister_isgenerated.Checked Then
        '    Me.btnGenerate.Enabled = False
        'Else
        '    Me.btnGenerate.Enabled = True
        'End If
        Me.btnGenerate.Enabled = True


        Me.btnPasteFromSpreadSheet.Enabled = False
        Me.DgvDetilItem.ReadOnly = True
        Me.obj_heinvregister_date.Enabled = False
        Me.obj_currency_id.Enabled = False
        Me.btn_season_id.Enabled = False



    End Sub

#End Region


#Region " Background Worker - Generate Data"

    Private Sub bgwGenerate_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles bgwGenerate.Disposed
    End Sub

    Private Sub bgwGenerate_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwGenerate.DoWork
        Dim result As GeneratePOResult = New GeneratePOResult()

        'Dim page, rowindex As Integer
        'Dim row As DataRow
        Dim pageLength As Integer = 100
        Dim total As Integer = 0
        Dim obj As Newtonsoft.Json.JavaScriptObject
        'Dim arrObj As Newtonsoft.Json.JavaScriptArray
        'Dim objDet As Newtonsoft.Json.JavaScriptObject
        Dim objArrDataSent As Newtonsoft.Json.JavaScriptArray
        Dim service As String
        Dim strJson As String
        Dim wConn As Translib.WebConnection
        Dim objWebResult As Translib.WebResultObject
        Dim respond As String = ""


        Try
            Dim param As GeneratePOParam = CType(e.Argument, GeneratePOParam)
            result.param = param

            service = CreateWebService(Me.WebserviceNSModule, Me.WebserviceObjectModule, "generatepopc")

            Me.Status = "Generating Data..."

            'Ambil data
            If Me.InvokeRequired Then
                Dim d As New BackgroundworkerInvokeFunction(AddressOf OpenLoadingIndicator)
                Me.Invoke(d, New Object() {New Object() {service, True, "", param.id, False}, True})
            End If

            objArrDataSent = New Newtonsoft.Json.JavaScriptArray()
            strJson = Newtonsoft.Json.JavaScriptConvert.SerializeObject(objArrDataSent)
            wConn = New Translib.WebConnection(Me.WebserviceAddress, Me.SessionID, Me.UserName)
            wConn.addtext("__ID", param.id)
            wConn.addtext("__PO", Trim(param.orderid))
            wConn.addtext("__PC", Trim(param.pricingid))
            ' wConn.addtext("__GENTYPE", Trim(param.generatetype))
            wConn.addtext("JSONDATA", strJson)
            objWebResult = WebserviceExecute(wConn, service, respond)


            If objWebResult.errors IsNot Nothing Then Throw New Exception(objWebResult.errors.ErrorMessage)
            If objWebResult.data.Count > 0 Then
                obj = objWebResult.data(0)
                If Not objWebResult.success Then Throw New Exception(objWebResult.errors.ErrorMessage)
            End If


            'Debug.Print(param.id)
            'For page = 0 To tbl.Rows.Count - 1 Step pageLength
            '    arrObj = New Newtonsoft.Json.JavaScriptArray()
            '    objDet = New Newtonsoft.Json.JavaScriptObject()
            '    objArrDataSent = New Newtonsoft.Json.JavaScriptArray()

            '    Me.ReportProgress(Me.bgwGenerate, 20, String.Format("rows {0} of {1}", page, tbl.Rows.Count))
            '    For rowindex = page To page + pageLength - 1 Step 1
            '        If rowindex <= tbl.Rows.Count - 1 Then
            '            total = total + 1
            '            row = tbl.Rows(rowindex)
            '            If row.RowState <> DataRowState.Deleted Then
            '                obj = Me.AddJsonObjectFromRow(tbl, row, row.RowState)
            '            Else
            '                row.RejectChanges()
            '                row.SetModified()
            '                obj = Me.AddJsonObjectFromRow(tbl, row, DataRowState.Deleted)
            '            End If
            '            arrObj.Add(obj)
            '        End If
            '    Next

            '    ' Kirim ke server
            '    objDet.Add("DetilItem", arrObj)
            '    objArrDataSent.Add(objDet)


            '    strJson = Newtonsoft.Json.JavaScriptConvert.SerializeObject(objArrDataSent)
            '    wConn = New Translib.WebConnection(Me.WebserviceAddress, Me.SessionID, Me.UserName)
            '    wConn.addtext("__ID", param.id)
            '    wConn.addtext("JSONDATA", strJson)
            '    objWebResult = WebserviceExecute(wConn, service, respond)

            '    If objWebResult.errors IsNot Nothing Then Throw New Exception(objWebResult.errors.ErrorMessage)
            '    If objWebResult.data.Count > 0 Then
            '        obj = objWebResult.data(0)
            '        If Not objWebResult.success Then Throw New Exception(objWebResult.errors.ErrorMessage)
            '    End If


            'Next

            '' Cek disini apakah telah berhasil semua digenerate
            'service = CreateWebService(Me.WebserviceNSModule, Me.WebserviceObjectModule, "generatecommit")
            'wConn = New Translib.WebConnection(Me.WebserviceAddress, Me.SessionID, Me.UserName)
            'wConn.addtext("__ID", param.id)
            'objWebResult = WebserviceExecute(wConn, service, respond)
            'If objWebResult.errors IsNot Nothing Then Throw New Exception(objWebResult.errors.ErrorMessage)
            'If objWebResult.data.Count > 0 Then
            '    obj = objWebResult.data(0)
            '    If Not objWebResult.success Then Throw New Exception(objWebResult.errors.ErrorMessage)
            'End If


            result.success = True
            e.Result = result
        Catch ex As Exception
            result.success = False
            result.errormessage = ex.Message
            e.Result = result
        End Try

    End Sub

    Private Sub bgwGenerate_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwGenerate.ProgressChanged
        Me.fLoadingIndicator.SetMessage(Me.Message)
        Me.fLoadingIndicator.Refresh()
    End Sub

    Private Sub bgwGenerate_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwGenerate.RunWorkerCompleted
        Dim result As GeneratePOResult

        Try
            Me.fLoadingIndicator.Hide()
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
            Me.DisableForm(False)

            result = CType(e.Result, GeneratePOResult)
            If e.Cancelled Then
                MessageBox.Show("Cancel Progress")
            End If

            If Not result.success Then Throw New Exception(result.errormessage)
            ' Me.btnGenerate.Enabled = False
            ' Me.obj_heinvregister_isgenerated.Checked = True
            ' Me.ddBinding.Tables("DetilItem").Table.AcceptChanges()
            ' Me.DgvList.CurrentRow.Cells("heinvregister_isgenerated").Value = True
            MessageBox.Show("Generate data selesai", Me.Title & " - Generate Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Title & " - Generate Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.btnUpload.Enabled = True
        Finally
            Me.Enabled = True
            Me.Cursor = Cursors.Arrow
            Me.bgwGenerate = Nothing
        End Try
    End Sub

#End Region




    Private Sub btnGenerate_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerate.Click

        Dim dlg As dlgSelpo = New dlgSelpo()
        dlg.ShowInTaskbar = False
        dlg.StartPosition = FormStartPosition.CenterParent


        Dim res As DialogResult = dlg.ShowDialog(Me)

        If res = DialogResult.OK Then
            Dim param As GeneratePOParam = New GeneratePOParam()

            Dim OrderId As String = dlg.OrderId
            Dim PricingId As String = dlg.PricingId

            param.id = Me.obj_heinvregister_id.Text
            param.orderid = OrderId
            param.pricingid = PricingId
            param.generatetype = dlg.GetGenerateType()

            If Me.bgwGenerate Is Nothing Then
                Me.bgwGenerate = New System.ComponentModel.BackgroundWorker
                Me.bgwGenerate.WorkerReportsProgress = True
                Me.bgwGenerate.WorkerSupportsCancellation = True
            End If

            If Me.btnGenerate.Text = "Generate" Then
                Me.Enabled = False
                Me.Cursor = Cursors.WaitCursor
                Me.bgwGenerate.RunWorkerAsync(param)
            End If

        End If

    End Sub



End Class

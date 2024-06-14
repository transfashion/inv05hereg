
Imports System.IO
Partial Class Config
End Class

Public Class uitrnheinvregister_printlabel1
    Inherits uitrnheinvregister

    Friend WithEvents btnGenerate As ToolStripButton
    Friend WithEvents bgwGenerate As System.ComponentModel.BackgroundWorker

    Private objError As System.Windows.Forms.ErrorProvider = New System.Windows.Forms.ErrorProvider()
    Dim _TXT As String

#Region "STRUKTUR"

    Public Structure LabelFormat
        Dim col1 As LabelImport
        Dim col2 As LabelImport
        Dim col3 As LabelImport

    End Structure


    Public Structure LabelImport

        Dim heinv_art As String
        Dim heinv_mat As String
        Dim heinv_col As String
        Dim combo As String

        Dim heinv_produk As String
        Dim heinv_bahan As String

        Dim heinv_pemeliharaan As String
        Dim heinv_dibuat_di As String
        Dim heinv_format As String
        Dim heinv_lainlain As String
        Dim heinv_season As String
        Dim heinv_ctg_id As String
        Dim heinv_gro_id As String
        Dim heinv_ctg_name As String
        Dim heinv_gro_name As String
        Dim picturePath As String



    End Structure

#End Region


#Region " Constructor "

    Public Sub New()

    End Sub

#End Region

#Region " User Defined Function "

    Public Overrides Function AddListCriteria(ByRef CriteriaBuilder As Translib.QueryCriteria) As Boolean
        CriteriaBuilder.AddCriteria("obj_search_chk_heinvregister_isposted", True, "1")

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
        Me.btnGenerate.Text = "Print Data"
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Visible = False
        Me.ToolStrip1.Items.Add(btnGenerate)
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

        Me.objError.Clear()




        Me.btnPasteFromSpreadSheet.Enabled = False
        Me.DgvDetilItem.ReadOnly = True
        Me.obj_heinvregister_date.Enabled = False
        Me.obj_currency_id.Enabled = False
        Me.btn_season_id.Enabled = False





        Me.obj_heinvregister_id.Enabled = False
        Me.obj_heinvregister_date.Enabled = False
        Me.obj_region_id.Enabled = False
        Me.obj_branch_id.Enabled = False
        Me.obj_heinvregister_descr.Enabled = False
        Me.obj_heinvregister_issizing.Enabled = False
        Me.obj_currency_id.Enabled = False
        Me.btn_season_id.Enabled = False
        Me.btn_rekanan_id.Enabled = False
        Me.btnPasteFromSpreadSheet.Enabled = False
        Me.btnUpload.Enabled = False



        ' Me.obj_cbo_ctg.Enabled = False

    End Sub

#End Region

#Region " Background Worker - Print Label"

    Private Sub bgwGenerate_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles bgwGenerate.Disposed
    End Sub

    Private Sub bgwGenerate_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwGenerate.DoWork
        Dim result As GenerateDataResult = New GenerateDataResult()
        Dim tbl As DataTable = New DataTable
        Dim page As Integer
        'Dim rowindex As Integer
        'Dim row As DataRow
        Dim pageLength As Integer = 100
        Dim total As Integer = 0
        Dim obj As Newtonsoft.Json.JavaScriptObject
        Dim arrObj As Newtonsoft.Json.JavaScriptArray
        Dim objDet As Newtonsoft.Json.JavaScriptObject
        Dim objArrDataSent As Newtonsoft.Json.JavaScriptArray
        Dim service As String
        'Dim strJson As String
        Dim wConn As Translib.WebConnection = New Translib.WebConnection(Me.WebserviceAddress, Me.SessionID, Me.UserName)
        Dim objWebResult As Translib.WebResultObject
        Dim respond As String = ""
        Dim n As Integer
        Dim i As Integer = 0
        Dim param As GenerateDataParam = CType(e.Argument, GenerateDataParam)



        Try


            wConn.addtext("__ID", param.id)
            service = CreateWebService(Me.WebserviceNSModule, Me.WebserviceObjectModule, "printlabel")

            objWebResult = WebserviceExecute(wConn, service, respond)
            If objWebResult.errors IsNot Nothing Then Throw New Exception(objWebResult.errors.ErrorMessage)

            n = objWebResult.data.Count
            If n > 0 Then
                For i = 0 To n - 1
                    obj = CType(objWebResult.data(i), Newtonsoft.Json.JavaScriptObject)
                    If Me.InvokeRequired Then
                        Dim d As New BackgroundworkerAddRowFromJsonObjectInvokeFunction(AddressOf AddRowFromJsonObject)
                        Me.Invoke(d, New Object() {tbl, obj, True})
                    End If
                Next
            End If



            If Me.InvokeRequired Then
                Dim d As New BackgroundworkerInvokeFunction(AddressOf OpenLoadingIndicator)
                Me.Invoke(d, New Object() {New Object() {service, True, "", param.id, False}, True})
            End If


            'result.tblResult = tbl.Copy
            For page = 0 To tbl.Rows.Count - 1 Step pageLength
                arrObj = New Newtonsoft.Json.JavaScriptArray()
                objDet = New Newtonsoft.Json.JavaScriptObject()
                objArrDataSent = New Newtonsoft.Json.JavaScriptArray()

                Me.ReportProgress(Me.bgwGenerate, 20, String.Format("rows {0} of {1}", page, tbl.Rows.Count))


            Next page


            Dim txt As String = ""

            Dim tbl_barcode As DataTable = New DataTable
            Dim datarow As DataRow


            Dim heinv_art As String = ""
            Dim heinv_mat As String = ""
            Dim heinv_col As String = ""

            Dim heinv_produk As String = ""
            Dim heinv_bahan As String = ""
            Dim heinv_pemeliharaan As String = ""
            Dim heinv_dibuat_di As String = ""
            Dim heinv_format As String = ""
            Dim heinv_lainlain As String = ""
            Dim heinv_season As String = ""
            Dim heinv_ctg_id As String = ""
            Dim heinv_gro_id As String = ""
            Dim heinv_ctg_name As String = ""
            Dim heinv_gro_name As String = ""
            Dim heinv_qty As Integer = 0

            Dim persen As Integer

            Dim combo As String = ""



            Dim delimitter As String = ""

            tbl_barcode.Columns.Add("heinv_art")
            tbl_barcode.Columns.Add("heinv_mat")
            tbl_barcode.Columns.Add("heinv_col")
            tbl_barcode.Columns.Add("combo")
            tbl_barcode.Columns.Add("heinv_produk")
            tbl_barcode.Columns.Add("heinv_bahan")
            tbl_barcode.Columns.Add("heinv_pemeliharaan")
            tbl_barcode.Columns.Add("heinv_dibuatdi")
            tbl_barcode.Columns.Add("heinv_format")
            tbl_barcode.Columns.Add("heinv_other1")
            tbl_barcode.Columns.Add("season_id")
            tbl_barcode.Columns.Add("heinvctg_id")
            tbl_barcode.Columns.Add("heinvgro_id")
            tbl_barcode.Columns.Add("heinvctg_name")
            tbl_barcode.Columns.Add("heinvgro_name")
            tbl_barcode.Columns.Add("qty")


            If tbl.Rows.Count = 0 Then MessageBox.Show("There's no row in Table!!", "No Row(s)", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) : Exit Sub


            For i = 0 To tbl.Rows.Count - 1

                persen = (i / tbl.Rows.Count) * 100
                Me.ReportProgress(Me.bgwGenerate, 20, "Finalizing data (" & persen & " %)")

                Application.DoEvents()
                heinv_art = tbl.Rows(i).Item("heinv_art")
                heinv_mat = tbl.Rows(i).Item("heinv_mat")
                heinv_col = tbl.Rows(i).Item("heinv_col")
                combo = heinv_art & "/" & heinv_mat & "/" & heinv_col

                heinv_produk = tbl.Rows(i).Item("heinv_produk")
                heinv_bahan = tbl.Rows(i).Item("heinv_bahan")
                heinv_pemeliharaan = tbl.Rows(i).Item("heinv_pemeliharaan")
                heinv_dibuat_di = tbl.Rows(i).Item("heinv_dibuatdi")
                heinv_format = tbl.Rows(i).Item("heinv_format")
                heinv_lainlain = tbl.Rows(i).Item("heinv_other1")
                heinv_season = tbl.Rows(i).Item("season_id")
                heinv_ctg_id = tbl.Rows(i).Item("heinvctg_id")
                heinv_gro_id = tbl.Rows(i).Item("heinvgro_id")
                heinv_ctg_name = tbl.Rows(i).Item("heinvctg_name")
                heinv_gro_name = tbl.Rows(i).Item("heinvgro_name")
                heinv_qty = tbl.Rows(i).Item("qty")

                For j As Integer = 1 To heinv_qty

                    datarow = tbl_barcode.NewRow
                    datarow.Item("heinv_art") = heinv_art
                    datarow.Item("heinv_mat") = heinv_mat
                    datarow.Item("heinv_col") = heinv_col
                    datarow.Item("combo") = combo
                    datarow.Item("heinv_produk") = heinv_produk
                    datarow.Item("heinv_bahan") = heinv_bahan
                    datarow.Item("heinv_pemeliharaan") = heinv_pemeliharaan
                    datarow.Item("heinv_dibuatdi") = heinv_dibuat_di
                    datarow.Item("heinv_format") = heinv_format
                    datarow.Item("heinv_other1") = heinv_lainlain
                    datarow.Item("season_id") = heinv_season
                    datarow.Item("heinvctg_id") = heinv_ctg_id
                    datarow.Item("heinvgro_id") = heinv_gro_id
                    datarow.Item("heinvctg_name") = heinv_ctg_name
                    datarow.Item("heinvgro_name") = heinv_gro_name
                    tbl_barcode.Rows.Add(datarow)

                Next j
                Application.DoEvents()
                System.Threading.Thread.Sleep(50)

            Next i




            result.tblResult = tbl_barcode

            PrintImport(tbl_barcode)



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


        Dim result As GenerateDataResult = New GenerateDataResult()
        result = e.Result
        Dim tbl As DataTable = New DataTable
        tbl = result.tblResult


        Me.Cursor = Cursors.Arrow
        Me.Enabled = True
        Me.fLoadingIndicator.Visible = False


    End Sub

#End Region


    Private Sub PrintImport(ByVal tbl_barcode As DataTable)



        Dim fullPath As String = "C:\LABEL.txt"
        Me._TXT = ""


        Dim PicturePath As String = "C:\sapi.JPG"
        Dim NOPicturePath As String = "C:\X_sapi.JPG"

        Dim obj As LabelFormat = New LabelFormat
        Dim col1 As LabelImport = New LabelImport
        Dim col2 As LabelImport = New LabelImport
        Dim col3 As LabelImport = New LabelImport


        Dim panjang_bahan As Integer

        Dim str As String

        Dim PrinterName As String = ""
        Dim dlgPrinter As New PrintDialog()
        dlgPrinter.PrinterSettings = New Drawing.Printing.PrinterSettings
        PrinterName = dlgPrinter.PrinterSettings.PrinterName



        'tbl_barcode.DefaultView.RowFilter = "heinv_format='" & tipeFormat & "'"

        'tbl_barcode.DefaultView.Sort = "heinvctg_name"
        Dim dv As DataView = tbl_barcode.DefaultView
        dv.Sort = "heinvctg_name"

        Dim persen As Integer

        If dv.Count > 0 Then

            For i As Integer = 0 To dv.Count - 1 Step 3

                persen = (i / dv.Count) * 100
                Application.DoEvents()
                Me.ReportProgress(Me.bgwGenerate, 20, "Creating Text File (" & persen & " %)")

                With col1
                    .heinv_produk = dv.Item(i).Item("heinv_produk").ToString
                    .combo = dv.Item(i).Item("combo").ToString
                    panjang_bahan = Math.Round(Strings.Len(dv.Item(i).Item("heinv_bahan").ToString) / 3)
                    .heinv_bahan = dv.Item(i).Item("heinv_bahan").ToString
                    .heinv_pemeliharaan = dv.Item(i).Item("heinv_pemeliharaan").ToString
                    .heinv_dibuat_di = (dv.Item(i).Item("heinv_dibuatdi").ToString)
                    .heinv_format = Strings.UCase(dv.Item(i).Item("heinv_format").ToString)
                    .heinv_lainlain = Strings.UCase(dv.Item(i).Item("heinv_other1").ToString)
                    .heinv_season = Strings.UCase(dv.Item(i).Item("season_id").ToString)
                    .heinv_ctg_id = Strings.UCase(dv.Item(i).Item("heinvctg_id").ToString)
                    .heinv_gro_id = Strings.UCase(dv.Item(i).Item("heinvgro_id").ToString)
                    .heinv_ctg_name = Strings.UCase(dv.Item(i).Item("heinvctg_name").ToString)
                    .heinv_gro_name = Strings.UCase(dv.Item(i).Item("heinvgro_name").ToString)
                    Select Case .heinv_format
                        Case "A"
                            .picturePath = NOPicturePath
                        Case "B"
                            .picturePath = PicturePath
                        Case "C"
                            .picturePath = NOPicturePath
                        Case "D"
                            .picturePath = PicturePath
                    End Select

                    str = .heinv_produk & "|" & .combo & "|" & .heinv_bahan & "|" & .heinv_pemeliharaan & "|" & .heinv_dibuat_di & "|" & .heinv_format & "|" & .heinv_lainlain & "|" & .heinv_season & "|" & .heinv_ctg_id & "|" & .heinv_gro_id & "|" & .heinv_ctg_name & "|" & .heinv_gro_name & "|" & .picturePath & vbNewLine
                    SaveText(str)
                End With


                If i + 1 < tbl_barcode.Rows.Count Then
                    With col2
                        .heinv_produk = dv.Item(i + 1).Item("heinv_produk").ToString
                        .combo = dv.Item(i + 1).Item("combo").ToString
                        .heinv_bahan = dv.Item(i + 1).Item("heinv_bahan").ToString
                        .heinv_pemeliharaan = dv.Item(i + 1).Item("heinv_pemeliharaan").ToString
                        .heinv_dibuat_di = (dv.Item(i + 1).Item("heinv_dibuatdi").ToString)
                        .heinv_format = Strings.UCase(dv.Item(i + 1).Item("heinv_format").ToString)
                        .heinv_lainlain = Strings.UCase(dv.Item(i + 1).Item("heinv_other1").ToString)
                        .heinv_season = Strings.UCase(dv.Item(i + 1).Item("season_id").ToString)
                        .heinv_ctg_id = Strings.UCase(dv.Item(i + 1).Item("heinvctg_id").ToString)
                        .heinv_gro_id = Strings.UCase(dv.Item(i + 1).Item("heinvgro_id").ToString)
                        .heinv_ctg_name = Strings.UCase(dv.Item(i + 1).Item("heinvctg_name").ToString)
                        .heinv_gro_name = Strings.UCase(dv.Item(i + 1).Item("heinvgro_name").ToString)
                        Select Case .heinv_format
                            Case "A"
                                .picturePath = NOPicturePath
                            Case "B"
                                .picturePath = PicturePath
                            Case "C"
                                .picturePath = NOPicturePath
                            Case "D"
                                .picturePath = PicturePath
                        End Select
                        str = .heinv_produk & "|" & .combo & "|" & .heinv_bahan & "|" & .heinv_pemeliharaan & "|" & .heinv_dibuat_di & "|" & .heinv_format & "|" & .heinv_lainlain & "|" & .heinv_season & "|" & .heinv_ctg_id & "|" & .heinv_gro_id & "|" & .heinv_ctg_name & "|" & .heinv_gro_name & "|" & .picturePath & vbNewLine
                        SaveText(str)
                    End With
                End If


                If i + 2 < tbl_barcode.Rows.Count Then
                    With col3
                        .heinv_produk = dv.Item(i + 2).Item("heinv_produk").ToString
                        .combo = dv.Item(i + 2).Item("combo").ToString
                        .heinv_bahan = dv.Item(i + 2).Item("heinv_bahan").ToString
                        .heinv_pemeliharaan = dv.Item(i + 2).Item("heinv_pemeliharaan").ToString
                        .heinv_dibuat_di = (dv.Item(i + 2).Item("heinv_dibuatdi").ToString)
                        .heinv_format = Strings.UCase(dv.Item(i + 2).Item("heinv_format").ToString)
                        .heinv_lainlain = Strings.UCase(dv.Item(i + 2).Item("heinv_other1").ToString)
                        .heinv_season = Strings.UCase(dv.Item(i + 2).Item("season_id").ToString)
                        .heinv_ctg_id = Strings.UCase(dv.Item(i + 2).Item("heinvctg_id").ToString)
                        .heinv_gro_id = Strings.UCase(dv.Item(i + 2).Item("heinvgro_id").ToString)
                        .heinv_ctg_name = Strings.UCase(dv.Item(i + 2).Item("heinvctg_name").ToString)
                        .heinv_gro_name = Strings.UCase(dv.Item(i + 2).Item("heinvgro_name").ToString)
                        Select Case .heinv_format
                            Case "A"
                                .picturePath = NOPicturePath
                            Case "B"
                                .picturePath = PicturePath
                            Case "C"
                                .picturePath = NOPicturePath
                            Case "D"
                                .picturePath = PicturePath
                        End Select
                        str = .heinv_produk & "|" & .combo & "|" & .heinv_bahan & "|" & .heinv_pemeliharaan & "|" & .heinv_dibuat_di & "|" & .heinv_format & "|" & .heinv_lainlain & "|" & .heinv_season & "|" & .heinv_ctg_id & "|" & .heinv_gro_id & "|" & .heinv_ctg_name & "|" & .heinv_gro_name & "|" & .picturePath & vbNewLine
                        SaveText(str)
                    End With

                End If


                obj.col1 = col1
                obj.col2 = col2
                obj.col3 = col3

                System.Threading.Thread.Sleep(50)

            Next


        End If


        Dim FILE_NAME As String = "C:\LABEL.txt"

        If System.IO.File.Exists(FILE_NAME) = True Then
            Dim objWriter As New System.IO.StreamWriter(FILE_NAME)
            objWriter.Write(Me._TXT)
            objWriter.Close()

        Else

        End If


    End Sub
    Public Function SaveText(ByVal strData As String, Optional ByVal ErrInfo As String = "") As String


        Me._TXT &= strData

        Return Me._TXT
    End Function


    Private Function TextTipe(ByVal tipeFormat As String, ByVal obj As LabelFormat) As String


        '    'txt = My.Resources.String1
        Dim txt As String = ""
        '    Select Case tipeFormat
        '        Case "A"
        '            'berupa txt untuk di print   format = ......
        '            txt = "{D0480,0900,0450|}" & vbCrLf
        '            txt &= "{C|}" & vbCrLf
        '            txt &= "{PV00;0014,0027,0024,0024,J,00,B|}" & vbCrLf
        '            txt &= "{PV01;0316,0027,0024,0024,J,00,B|}" & vbCrLf
        '            txt &= "{PV02;0618,0027,0024,0024,J,00,B|}" & vbCrLf
        '            txt &= "{PV03;0014,0052,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV04;0316,0052,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV05;0618,0052,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV06;0014,0076,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV07;0316,0076,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV08;0618,0076,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV09;0014,0136,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV10;0316,0136,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV11;0618,0136,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV12;0014,0199,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV13;0316,0199,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV14;0618,0199,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV15;0014,0375,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV16;0316,0375,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV17;0618,0375,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV18;0014,0415,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV19;0316,0415,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV20;0618,0415,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV21;0014,0394,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV22;0316,0394,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV23;0618,0394,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV24;0015,0111,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV25;0317,0111,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV26;0619,0111,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{RV00;" & obj.col1.heinv_produk & "|}" & vbCrLf
        '            txt &= "{RV01;" & obj.col2.heinv_produk & "|}" & vbCrLf
        '            txt &= "{RV02;" & obj.col3.heinv_produk & "|}" & vbCrLf
        '            txt &= "{RV03;" & obj.col1.combo & "|}" & vbCrLf
        '            txt &= "{RV04;" & obj.col2.combo & "|}" & vbCrLf
        '            txt &= "{RV05;" & obj.col3.combo & "|}" & vbCrLf
        '            txt &= "{RV06;" & obj.col1.heinv_ctg_id & "|}" & vbCrLf
        '            txt &= "{RV07;" & obj.col2.heinv_ctg_id & "|}" & vbCrLf
        '            txt &= "{RV08;" & obj.col3.heinv_ctg_id & "|}" & vbCrLf
        '            txt &= "{RV09;" & obj.col1.heinv_bahan & "|}" & vbCrLf
        '            txt &= "{RV10;" & obj.col2.heinv_bahan & "|}" & vbCrLf
        '            txt &= "{RV11;" & obj.col3.heinv_bahan & "|}" & vbCrLf
        '            txt &= "{RV12;" & obj.col1.heinv_pemeliharaan & "|}" & vbCrLf
        '            txt &= "{RV13;" & obj.col2.heinv_pemeliharaan & "|}" & vbCrLf
        '            txt &= "{RV14;" & obj.col3.heinv_pemeliharaan & "|}" & vbCrLf
        '            txt &= "{RV15;" & obj.col1.heinv_dibuat_di & "|}" & vbCrLf
        '            txt &= "{RV16;" & obj.col2.heinv_dibuat_di & "|}" & vbCrLf
        '            txt &= "{RV17;" & obj.col3.heinv_dibuat_di & "|}" & vbCrLf
        '            txt &= "{RV18;PT. Trans Mahagaya Jakarta|}" & vbCrLf
        '            txt &= "{RV19;PT. Trans Mahagaya Jakarta|}" & vbCrLf
        '            txt &= "{RV20;PT. Trans Mahagaya Jakarta|}" & vbCrLf
        '            txt &= "{RV21;Diimpor oleh|}" & vbCrLf
        '            txt &= "{RV22;Diimpor oleh|}" & vbCrLf
        '            txt &= "{RV23;Diimpor oleh|}" & vbCrLf
        '            txt &= "{RV24;Ukuran|}" & vbCrLf
        '            txt &= "{RV25;Ukuran|}" & vbCrLf
        '            txt &= "{RV26;Ukuran|}" & vbCrLf
        '            txt &= "{XS;I,0001,0002C6201|}" & vbCrLf
        '            txt &= "{@007;0002|}" & vbCrLf

        '        Case "B"

        '            txt = "{D0480,0900,0450|}" & vbCrLf
        '            txt &= "{C|}" & vbCrLf
        '            txt &= "{PV00;0014,0027,0024,0024,J,00,B|}" & vbCrLf
        '            txt &= "{PV01;0316,0027,0024,0024,J,00,B|}" & vbCrLf
        '            txt &= "{PV02;0618,0027,0024,0024,J,00,B|}" & vbCrLf
        '            txt &= "{PV03;0014,0052,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV04;0316,0052,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV05;0618,0052,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV06;0014,0076,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV07;0316,0076,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV08;0618,0076,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV09;0014,0124,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV10;0316,0124,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV11;0618,0124,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV12;0014,0199,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV13;0316,0199,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV14;0618,0199,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV15;0014,0375,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV16;0316,0375,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV17;0618,0375,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV18;0014,0415,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV19;0316,0415,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV20;0618,0415,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV21;0014,0394,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV22;0316,0394,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV23;0618,0394,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{RV00;" & obj.col1.heinv_produk & "|}" & vbCrLf
        '            txt &= "{RV01;" & obj.col2.heinv_produk & "|}" & vbCrLf
        '            txt &= "{RV02;" & obj.col3.heinv_produk & "|}" & vbCrLf
        '            txt &= "{RV03;" & obj.col1.combo & "|}" & vbCrLf
        '            txt &= "{RV04;" & obj.col2.combo & "|}" & vbCrLf
        '            txt &= "{RV05;" & obj.col3.combo & "|}" & vbCrLf
        '            txt &= "{RV06;" & obj.col1.heinv_ctg_id & "|}" & vbCrLf
        '            txt &= "{RV07;" & obj.col2.heinv_ctg_id & "|}" & vbCrLf
        '            txt &= "{RV08;" & obj.col3.heinv_ctg_id & "|}" & vbCrLf
        '            txt &= "{RV09;0 & obj.col1.heinv_bahan & "0}" & vbCrLf
        '            txt &= "{RV10;0 & obj.col2.heinv_bahan & "0}" & vbCrLf
        '            txt &= "{RV11;0 & obj.col3.heinv_bahan & "0}" & vbCrLf
        '            txt &= "{RV12;" & obj.col1.heinv_pemeliharaan & "|}" & vbCrLf
        '            txt &= "{RV13;" & obj.col2.heinv_pemeliharaan & "|}" & vbCrLf
        '            txt &= "{RV14;" & obj.col3.heinv_pemeliharaan & "|}" & vbCrLf
        '            txt &= "{RV15;Dibuat di Italy |}" & vbCrLf
        '            txt &= "{RV16;Dibuat di Italy |}" & vbCrLf
        '            txt &= "{RV17;Dibuat di Italy |}" & vbCrLf
        '            txt &= "{RV18;PT. Trans Mahagaya Jakarta|}" & vbCrLf
        '            txt &= "{RV19;PT. Trans Mahagaya Jakarta|}" & vbCrLf
        '            txt &= "{RV20;PT. Trans Mahagaya Jakarta|}" & vbCrLf
        '            txt &= "{RV21;Diimpor oleh|}" & vbCrLf
        '            txt &= "{RV22;Diimpor oleh|}" & vbCrLf
        '            txt &= "{RV23;Diimpor oleh|}" & vbCrLf
        '            txt &= "{XS;I,0001,0002C6201|}" & vbCrLf
        '            txt &= "{@007;0009|}"




        '        Case "C"
        '            txt = "{D0480,0900,0450|}" & vbCrLf
        '            txt &= "{C|}" & vbCrLf
        '            txt &= My.Resources.String1 & vbCrLf
        '            txt &= "{PV00;0014,0027,0024,0024,J,00,B|}" & vbCrLf
        '            txt &= "{PV01;0316,0027,0024,0024,J,00,B|}" & vbCrLf
        '            txt &= "{PV02;0618,0027,0024,0024,J,00,B|}" & vbCrLf
        '            txt &= "{PV03;0014,0052,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV04;0316,0052,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV05;0618,0052,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV06;0014,0076,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV07;0316,0076,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV08;0618,0076,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV09;0014,0136,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV10;0316,0136,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV11;0618,0136,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV12;0014,0199,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV13;0316,0199,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV14;0618,0199,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV15;0014,0375,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV16;0316,0375,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV17;0618,0375,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV18;0014,0415,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV19;0316,0415,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV20;0618,0415,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV21;0014,0394,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV22;0316,0394,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV23;0618,0394,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV24;0015,0111,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV25;0317,0111,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV26;0619,0111,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{RV00;" & obj.col1.heinv_produk & "|}" & vbCrLf
        '            txt &= "{RV01;" & obj.col2.heinv_produk & "|}" & vbCrLf
        '            txt &= "{RV02;" & obj.col3.heinv_produk & "|}" & vbCrLf
        '            txt &= "{RV03;" & obj.col1.combo & "|}" & vbCrLf
        '            txt &= "{RV04;" & obj.col2.combo & "|}" & vbCrLf
        '            txt &= "{RV05;" & obj.col3.combo & "|}" & vbCrLf
        '            txt &= "{RV06;" & obj.col1.heinv_ctg_id & "|}" & vbCrLf
        '            txt &= "{RV07;" & obj.col2.heinv_ctg_id & "|}" & vbCrLf
        '            txt &= "{RV08;" & obj.col3.heinv_ctg_id & "|}" & vbCrLf
        '            txt &= "{RV09;" & obj.col1.heinv_bahan & "|}" & vbCrLf
        '            txt &= "{RV10;" & obj.col2.heinv_bahan & "|}" & vbCrLf
        '            txt &= "{RV11;" & obj.col3.heinv_bahan & "|}" & vbCrLf
        '            txt &= "{RV12;" & obj.col1.heinv_pemeliharaan & "|}" & vbCrLf
        '            txt &= "{RV13;" & obj.col2.heinv_pemeliharaan & "|}" & vbCrLf
        '            txt &= "{RV14;" & obj.col3.heinv_pemeliharaan & "|}" & vbCrLf
        '            txt &= "{RV15;Dibuat di Italy |}" & vbCrLf
        '            txt &= "{RV16;Dibuat di Italy |}" & vbCrLf
        '            txt &= "{RV17;Dibuat di Italy |}" & vbCrLf
        '            txt &= "{RV18;PT. Trans Mahagaya Jakarta|}" & vbCrLf
        '            txt &= "{RV19;PT. Trans Mahagaya Jakarta|}" & vbCrLf
        '            txt &= "{RV20;PT. Trans Mahagaya Jakarta|}" & vbCrLf
        '            txt &= "{RV21;Diimpor oleh|}" & vbCrLf
        '            txt &= "{RV22;Diimpor oleh|}" & vbCrLf
        '            txt &= "{RV23;Diimpor oleh|}" & vbCrLf
        '            txt &= "{RV24;Ukuran : tertera di produk|}" & vbCrLf
        '            txt &= "{RV25;Ukuran : tertera di produk|}" & vbCrLf
        '            txt &= "{RV26;Ukuran : tertera di produk|}" & vbCrLf
        '            txt &= "{XS;I,0001,0002C6201|}" & vbCrLf
        '            txt &= "{@007;0007|}"


        '        Case "D"

        '            txt = "{D0480,0900,0450|}" & vbCrLf
        '            txt &= "{C|}" & vbCrLf
        '            txt &= My.Resources.String2 & vbCrLf
        '            txt &= "{PV00;0014,0027,0024,0024,J,00,B|}" & vbCrLf
        '            txt &= "{PV01;0316,0027,0024,0024,J,00,B|}" & vbCrLf
        '            txt &= "{PV02;0618,0027,0024,0024,J,00,B|}" & vbCrLf
        '            txt &= "{PV03;0014,0052,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV04;0316,0052,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV05;0618,0052,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV06;0014,0076,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV07;0316,0076,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV08;0618,0076,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV09;0014,0124,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV10;0316,0124,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV11;0618,0124,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV12;0014,0199,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV13;0316,0199,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV14;0618,0199,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV15;0014,0375,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV16;0316,0375,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV17;0618,0375,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV18;0014,0415,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV19;0316,0415,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV20;0618,0415,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV21;0014,0394,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV22;0316,0394,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{PV23;0618,0394,0021,0021,J,00,B|}" & vbCrLf
        '            txt &= "{RV00;" & obj.col1.heinv_produk & "|}" & vbCrLf
        '            txt &= "{RV01;" & obj.col2.heinv_produk & "|}" & vbCrLf
        '            txt &= "{RV02;" & obj.col3.heinv_produk & "|}" & vbCrLf
        '            txt &= "{RV03;" & obj.col1.combo & "|}" & vbCrLf
        '            txt &= "{RV04;" & obj.col2.combo & "|}" & vbCrLf
        '            txt &= "{RV05;" & obj.col3.combo & "|}" & vbCrLf
        '            txt &= "{RV06;" & obj.col1.heinv_ctg_id & "|}" & vbCrLf
        '            txt &= "{RV07;" & obj.col2.heinv_ctg_id & "|}" & vbCrLf
        '            txt &= "{RV08;" & obj.col3.heinv_ctg_id & "|}" & vbCrLf
        '            txt &= "{RV09;" & obj.col1.heinv_bahan & "|}" & vbCrLf
        '            txt &= "{RV10;" & obj.col2.heinv_bahan & "|}" & vbCrLf
        '            txt &= "{RV11;" & obj.col3.heinv_bahan & "|}" & vbCrLf
        '            txt &= "{RV12;" & obj.col1.heinv_pemeliharaan & "|}" & vbCrLf
        '            txt &= "{RV13;" & obj.col2.heinv_pemeliharaan & "|}" & vbCrLf
        '            txt &= "{RV14;" & obj.col3.heinv_pemeliharaan & " |}" & vbCrLf
        '            txt &= "{RV15;Dibuat di Italy |}" & vbCrLf
        '            txt &= "{RV16;Dibuat di Italy |}" & vbCrLf
        '            txt &= "{RV17;Dibuat di Italy |}" & vbCrLf
        '            txt &= "{RV18;PT. Trans Mahagaya Jakarta|}" & vbCrLf
        '            txt &= "{RV19;PT. Trans Mahagaya Jakarta|}" & vbCrLf
        '            txt &= "{RV20;PT. Trans Mahagaya Jakarta|}" & vbCrLf
        '            txt &= "{RV21;Diimpor oleh|}" & vbCrLf
        '            txt &= "{RV22;Diimpor oleh|}" & vbCrLf
        '            txt &= "{RV23;Diimpor oleh|}" & vbCrLf
        '            txt &= "{XS;I,0001,0002C6201|}" & vbCrLf
        '            txt &= "{@007;0011|}"

        '    End Select




        Return txt
    End Function


    Private Sub btnGenerate_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerate.Click

        If Me.bgwGenerate Is Nothing Then
            Me.bgwGenerate = New System.ComponentModel.BackgroundWorker
            Me.bgwGenerate.WorkerReportsProgress = True
            Me.bgwGenerate.WorkerSupportsCancellation = True
        End If

        If Me.btnGenerate.Text = "Print Data" Then
            Dim param As GenerateDataParam = New GenerateDataParam
            param.id = Me.obj_heinvregister_id.Text

            Me.Enabled = False
            Me.Cursor = Cursors.WaitCursor
            Me.bgwGenerate.RunWorkerAsync(param)
        End If

    End Sub


End Class
 

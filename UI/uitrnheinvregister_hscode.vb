Partial Class Config
End Class

Public Class uitrnheinvregister_hscode
    Inherits uitrnheinvregister

#Region " Constructor "

    Public Sub New()
    End Sub

#End Region

    Friend WithEvents btnDownload As ToolStripButton



#Region " User Defined Function "

    Public Overrides Function AddListCriteria(ByRef CriteriaBuilder As Translib.QueryCriteria) As Boolean
        CriteriaBuilder.AddCriteria("obj_search_chk_heinvregister_isposted", True, "0")
        CriteriaBuilder.AddCriteria("obj_search_chk_heinvregister_isgenerated", True, "0")
        Return MyBase.AddListCriteria(CriteriaBuilder)
    End Function

    Public Overloads Function SetModifierButtonDisabled() As Boolean
        Me.tbtnNew.Enabled = False
        ' Me.tbtnSave.Enabled = False
        Me.tbtnDel.Enabled = False
        Me.tbtnRowAdd.Enabled = False
        Me.tbtnRowDel.Enabled = False
    End Function

#End Region

#Region " General Event "

    Private Sub ui_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Tambahkan tombol untuk posting
        Me.btnDownload = New ToolStripButton()
        Me.btnDownload.Text = "Download"
        Me.btnDownload.Name = "btnDownload"
        Me.btnDownload.Visible = False
        ' Me.ToolStrip1.Items.Add(btnDownload)


        Me.SetModifierButtonDisabled()
        Me.btnPasteFromSpreadSheet.Enabled = False

    End Sub

    Private Sub ui_FormTabmainSelected(ByVal tabname As String) Handles Me.FormTabmainSelected
        ' Set Tombol Disabled, untuk new dan save
        Me.SetModifierButtonDisabled()

        Select Case tabname
            Case "ftabMain_List"
                Me.btnDownload.Visible = False
            Case "ftabMain_Data"
                Me.btnDownload.Visible = True
        End Select
    End Sub

    Private Sub ui_FormTabdetilSelected(ByVal tabname As String) Handles Me.FormTabdetilSelected
        ' Set Tombol Disabled, untuk new dan save
        Me.SetModifierButtonDisabled()
    End Sub

    Private Sub ui_FormDataOpened(ByVal id As Object) Handles Me.FormDataOpened
        If Me.obj_heinvregister_isposted.Checked Then
            'Me.btnPost.Enabled = False
        Else
            'Me.btnPost.Enabled = True
        End If

        Me.DgvDetilItem.ReadOnly = False
        For Each dgcol As DataGridViewColumn In Me.DgvDetilItem.Columns
            If (dgcol.Name <> "heinv_hscode_ina") Then
                dgcol.ReadOnly = True
            Else
                dgcol.ReadOnly = False
            End If
        Next
    End Sub


#End Region


    Private Sub btn_PasteFromSpreadSheet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPasteFromSpreadSheet.Click
        Dim headerCols As String
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

        headerCols = "Line|ID|ART|MAT|COL|SIZE|Barcode|Name|Descr|Pcp.Line|Pcp.Group|Pcp.Category|Color Descr|Gender|Fit|HSCode Ship|HSCode INA|Nama di PLB|Box|Type|Produk|Bahan|Pemeliharaan|Logo|Dibuat Di|Other1|Price|CTG|GRO|GRONAME|CTGNAME|TAG|Branch|BranchName|Qty|Actual|Error|"
        If Mid(cnames.ToUpper(), 1, Len(headerCols)) <> Mid(headerCols.ToUpper(), 1, Len(headerCols)) Then
            MessageBox.Show("Format data tidak sesuai", Me.Title & " - Paste From SpreadSheet", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If


        Dim dt As DataTable = Me.DgvDetilItem.DataSource
        Dim irow As Integer
        For irow = 1 To strRows.Length - 2
            strColumns = strRows(irow).Split(vbTab)
            Dim hscode_ina As String = strColumns(16)
            Dim line = strColumns(0)

            Dim dr() = dt.Select("heinvregisteritem_line='" & line & "'")
            If (dr.Length > 0) Then
                Dim int_hscode_ina As Int32 = Int32.Parse(hscode_ina)
                dr(0)("heinv_hscode_ina") = int_hscode_ina
            End If

        Next

        Me.DgvDetilItem.EndEdit()

    End Sub

    Private Sub btn_Download_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDownload.Click

    End Sub

End Class

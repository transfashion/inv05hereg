Partial Class Config
End Class

Public Class uitrnheinvregister_post
    Inherits uitrnheinvregister

    Friend WithEvents btnPost As ToolStripButton



#Region " Constructor "

    Public Sub New()


        Me.DgvDetilItem.ReadOnly = True
    End Sub

#End Region


#Region " User Defined Function "

    Public Overrides Function AddListCriteria(ByRef CriteriaBuilder As Translib.QueryCriteria) As Boolean
        CriteriaBuilder.AddCriteria("obj_search_chk_heinvregister_isposted", True, "0")
        CriteriaBuilder.AddCriteria("obj_search_chk_heinvregister_isgenerated", True, "0")
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

    Private Sub ui_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Tambahkan tombol untuk posting
        Me.btnPost = New ToolStripButton()
        Me.btnPost.Text = "Post"
        Me.btnPost.Name = "btnPost"
        Me.btnPost.Visible = False
        Me.ToolStrip1.Items.Add(btnPost)


        Me.SetModifierButtonDisabled()
    End Sub

    Private Sub ui_FormTabmainSelected(ByVal tabname As String) Handles Me.FormTabmainSelected
        ' Set Tombol Disabled, untuk new dan save
        Me.SetModifierButtonDisabled()

        Select Case tabname
            Case "ftabMain_List"
                Me.btnPost.Visible = False
            Case "ftabMain_Data"
                Me.btnPost.Visible = True
        End Select
    End Sub

    Private Sub ui_FormTabdetilSelected(ByVal tabname As String) Handles Me.FormTabdetilSelected
        ' Set Tombol Disabled, untuk new dan save
        Me.SetModifierButtonDisabled()
    End Sub

    Private Sub ui_FormDataOpened(ByVal id As Object) Handles Me.FormDataOpened
        If Me.obj_heinvregister_isposted.Checked Then
            Me.btnPost.Enabled = False
        Else
            Me.btnPost.Enabled = True
        End If
    End Sub


#End Region


    Private Sub btnPost_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPost.Click
        'Cek apakah masih ada error
        Dim iRow As Integer
        For iRow = 0 To Me.DgvDetilItem.Rows.Count - 1
            If Me.DgvDetilItem.Rows(iRow).Cells("ERR").Value <> 0 Then
                MessageBox.Show("Masih ada data yang belum sesuai," & vbCrLf & "silakan diperbaiki terlebih dahulu", Me.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        Next

        Dim wConn As Translib.WebConnection = New Translib.WebConnection(Me.WebserviceAddress, Me.SessionID, Me.UserName)
        Dim objWebResult As Translib.WebResultObject
        Dim obj As Newtonsoft.Json.JavaScriptObject
        Dim service As String = CreateWebService(Me.WebserviceNSModule, Me.WebserviceObjectModule, "ppost")
        Dim respond As String = ""
        Dim __ID As Object = Me.GetActiveDocumentIDValue()
        Dim failed As Boolean
        Dim post As Boolean
        Dim message As String


        If Me.Controls.ContainsKey("ftabMain") Then
            If Me.Controls("ftabMain").Controls.ContainsKey("ftabMain_Data") Then
                Me.Controls("ftabMain").Controls("ftabMain_Data").Focus()
            End If
        End If

        If Me.DataIsChanged(Me.tblList_Temp, Me.ddBinding) Then
            MessageBox.Show("Data Belum di Save." & vbCrLf & "Silakan simpan data sebelum posting", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Try
            Me.Cursor = Cursors.WaitCursor
            Me.Enabled = False

            wConn.addtext("__ID", __ID)
            wConn.addtext("__ACTION", "POST")
            objWebResult = WebserviceExecute(wConn, service, respond)
            If objWebResult.errors IsNot Nothing Then Throw New ExceptionPostingError(objWebResult.errors.ErrorMessage)
            If objWebResult.data.Count > 0 Then
                obj = CType(objWebResult.data(0), Newtonsoft.Json.JavaScriptObject)
                failed = CBool(obj.Item("failed"))
                post = CBool(obj.Item("post"))
                message = obj.Item("message")
                If Not failed And post Then
                    Me.btnPost.Enabled = False
                    Me.obj_heinvregister_isposted.Checked = True
                    Me.DgvList.CurrentRow.Cells("heinvregister_isposted").Value = True
                    MessageBox.Show(message, Me.Text & " - Post", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As ExceptionPostingError
            MessageBox.Show(ex.Message, Me.Title & " - Post", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show(Mid(respond, 1, 1000) & vbCrLf & vbCrLf & ex.Message, Me.Title & " - Post", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Arrow
            Me.Enabled = True
        End Try
    End Sub



End Class
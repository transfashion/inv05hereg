Partial Class Config
End Class

Public Class uitrnheinvregister_packinglist
    Inherits uitrnheinvregister
 
#Region " General Event "

    Private Sub uitrnheinvregister_entry_FormAfterNew(ByVal result As Object, ByVal args As Object) Handles Me.FormAfterNew
        Me.tbtnRowAdd.Enabled = True
        Me.tbtnRowDel.Enabled = True
    End Sub

    Private Sub uitrnheinvregister_entry_FormBeforeNew(ByRef result As Object, ByRef cancel As Boolean, ByRef args As Object) Handles Me.FormBeforeNew
        Me.tbtnRowAdd.Enabled = True
        Me.tbtnRowDel.Enabled = True
    End Sub

    Private Sub ui_FormDataOpened(ByVal id As Object) Handles Me.FormDataOpened
        Me.tbtnRowAdd.Enabled = True
        Me.tbtnRowDel.Enabled = True

        If Me.obj_heinvregister_isposted.Checked Then
            Me.tbtnSave.Enabled = False
            Me.tbtnDel.Enabled = False
            Me.btnPasteFromSpreadSheet.Enabled = False
        Else
            Me.tbtnSave.Enabled = True
            Me.tbtnDel.Enabled = True
            Me.tbtnRowAdd.Enabled = True

        End If
    End Sub

#End Region

End Class

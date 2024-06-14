Module INV05HEREG

    Public Structure PasteFromSpreadSheetParam
        Dim id As String
        Dim strRows() As String
        Dim sizing As Boolean
        Dim message As String
        Dim success As Boolean
        Dim errormessage As String
    End Structure

    Public Structure PasteFromSpreadSheetResult
        Dim id As String
        Dim param As PasteFromSpreadSheetParam
        Dim message As String
        Dim success As Boolean
        Dim errormessage As String
    End Structure



    Public Structure UploadDataParam
        Dim id As String
        Dim Table As DataTable
        Dim message As String
        Dim success As Boolean
        Dim errormessage As String
    End Structure

    Public Structure UploadDataResult
        Dim id As String
        Dim param As UploadDataParam
        Dim message As String
        Dim success As Boolean
        Dim errormessage As String
    End Structure


    Public Structure LoadDataDetilParam
        Dim id As String
        Dim totalrows As Decimal
        Dim message As String
        Dim success As Boolean
        Dim errormessage As String
    End Structure

    Public Structure LoadDataDetilResult
        Dim id As String
        Dim param As LoadDataDetilParam
        Dim table As DataTable
        Dim message As String
        Dim success As Boolean
        Dim errormessage As String
    End Structure

    Public Structure GenerateDataParam
        Dim id As String
        Dim Table As DataTable
        Dim message As String
        Dim success As Boolean
        Dim errormessage As String
    End Structure

    Public Structure GenerateDataResult
        Dim id As String
        Dim param As GenerateDataParam
        Dim message As String
        Dim success As Boolean
        Dim errormessage As String
        Dim tblResult As DataTable
    End Structure





    Public Structure GeneratePOParam
        Dim id As String
        Dim orderid As String
        Dim pricingid As String
        Dim generatetype As Integer
        Dim message As String
        Dim success As Boolean
        Dim errormessage As String
    End Structure

    Public Structure GeneratePOResult
        Dim id As String
        Dim param As GeneratePOParam
        Dim message As String
        Dim success As Boolean
        Dim errormessage As String
        Dim tblResult As DataTable
    End Structure

End Module




Public Class ExceptionPostingError
    Inherits Exception

    Private mMessage As String

    Public Overloads ReadOnly Property Message() As String
        Get
            Return mMessage
        End Get
    End Property

    Public Sub New(ByVal message As String)
        mMessage = message
    End Sub

End Class

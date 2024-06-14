Public Class Config

    ''''Development purpose only
    Public Shared BrowserVersion As String = "1.0.4.456"
    Public Shared DeveloperDefaultSessionID As String = "1234567890"
    Public Shared DeveloperDefaultUserName As String = "transdev"
    Public Shared DllServer As String = "http://localhost:8084/crossroads/frontend/lib"
    Public Shared WebserviceAddress As String = "http://localhost:8084/crossroads/frontend"
    'Public Shared WebserviceAddress As String = "http://webservice.transmahagaya.com/crossroads/frontend"

    ' Runtime Config
    Public Shared DllPrint As String = "INV05HEORDERBATCHPRN.PHP"
    Public Shared DllPrintRDLC As String = "INV05HEORDERBATCHPRN.uiheorderbatch_print.rdlc"
    Public Shared WebserviceNSModule As String = "inv05"
    Public Shared WebserviceObjectModule As String = "uitrnheinvregister"


End Class

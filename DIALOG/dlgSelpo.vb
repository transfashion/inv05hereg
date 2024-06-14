Public Class dlgSelpo

    Public Const GENERATE_PO As Integer = 1
    Public Const GENERATE_PRICING As Integer = 2


    Private GenerateType As Integer


    Public ReadOnly Property GetGenerateType() As Integer
        Get
            Return Me.GenerateType
        End Get
    End Property


    Public ReadOnly Property OrderId() As String
        Get
            Return Me.TextBox1.Text
        End Get
    End Property

    Public ReadOnly Property PricingId() As String
        Get
            Return Me.TextBox2.Text
        End Get
    End Property

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click

        If (Trim(Me.TextBox1.Text) = "") Then
            MessageBox.Show("No PO belum diisi", "Generate PO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.TextBox1.Focus()
            Exit Sub
        End If

        If (Trim(Me.TextBox2.Text) = "") Then
            MessageBox.Show("No Pricing belum diisi", "Generate Pricing", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.TextBox2.Focus()
            Exit Sub
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()


    End Sub



End Class
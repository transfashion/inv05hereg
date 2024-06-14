<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Test
    Inherits Translib.uiBase

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'bgwListLoader
        '
        Me.bgwListLoader.WorkerReportsProgress = True
        Me.bgwListLoader.WorkerSupportsCancellation = True
        '
        'bgwDataLoader
        '
        Me.bgwDataLoader.WorkerReportsProgress = True
        Me.bgwDataLoader.WorkerSupportsCancellation = True
        '
        'bgwSave
        '
        Me.bgwSave.WorkerReportsProgress = True
        Me.bgwSave.WorkerSupportsCancellation = True
        '
        'fLoadingIndicator
        '
        Me.fLoadingIndicator.Location = New System.Drawing.Point(44, 58)
        Me.fLoadingIndicator.ShowInTaskbar = False
        Me.fLoadingIndicator.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        '
        'Test
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Name = "Test"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

End Class

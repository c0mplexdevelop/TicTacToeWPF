Class MainWindow

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Debug.WriteLine("Initialized")

    End Sub
    Private Sub borderOnClick(sender As Object, ev As MouseButtonEventArgs)
        'Dim border As Border = TryCast(sender, Border)
        'Dim row As Integer = CInt(border.GetValue(Grid.RowProperty))
        'Dim col As Integer = CInt(border.GetValue(Grid.ColumnProperty))
        'Debug.WriteLine("Clicked4")
        Debug.WriteLine("Clicky2")
        Dim border As Border = TryCast(sender, Border)

    Private Sub Window_MouseDown(sender As Object, e As MouseButtonEventArgs)
        If (e.ChangedButton = MouseButton.Left) Then
            Me.DragMove()
        End If
    End Sub
End Class

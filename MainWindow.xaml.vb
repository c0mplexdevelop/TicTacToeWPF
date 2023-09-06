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

        ' Retrieve the coordinate of the mouse position.
        Dim pt As Point = ev.GetPosition(CType(sender, UIElement))

        ' Perform the hit test against a given portion of the visual object tree.
        Dim result As HitTestResult = VisualTreeHelper.HitTest(border, pt)

        If result IsNot Nothing Then
            ' Perform action on hit visual object.
        End If
    End Sub
End Class

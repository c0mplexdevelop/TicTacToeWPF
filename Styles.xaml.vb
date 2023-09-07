Option Strict On

Public Class Styles

    Private game As TTT

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        game = TryCast(Application.Current.MainWindow.DataContext, TTT)
    End Sub

    Private Sub borderOnClick(sender As Object, e As MouseButtonEventArgs)
        Dim border As Border = TryCast(sender, Border)
        Dim row As Integer = Grid.GetRow(border)
        Dim col As Integer = Grid.GetColumn(border)

        Debug.WriteLine($"Clicky clackity at {row}-ity {col}-ity")
    End Sub
End Class

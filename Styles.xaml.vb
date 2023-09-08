Option Strict On
Imports System.Windows.Threading

Public Class Styles

    Private game As TTT

    Private window As Window = Application.Current.MainWindow

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        game = TryCast(window.DataContext, TTT)
    End Sub

    Private Sub borderOnClick(sender As Border, e As MouseButtonEventArgs)
        Dim border As Border = sender
        Dim row As Integer = Grid.GetRow(border) - 2
        Dim col As Integer = Grid.GetColumn(border)

        Debug.WriteLine($"Clicky clackity at {row}-ity {col}-ity")

        If Not game.CheckIfEmpty(row, col) Then
            Debug.WriteLine("Position taken!")
            Return
        End If

        game.SetPieceToPosition(row, col)
        AddLetter(border, game.Turn)
        If game.CheckIfLetterWon() Then
            Debug.WriteLine($"{game.Turn} Won!")
            CloseApplicationAfterDelay()
            Return
        End If
        game.SwitchTurns()
    End Sub

    Private Sub AddLetter(border As Border, currentTurn As String)
        Dim dock As New DockPanel()
        Dim text As New TextBlock() With {
            .Text = currentTurn,
            .Style = CType(window.FindResource("TurnStyle"), Style)
        }
        dock.Children.Add(text)
        border.Child = dock

    End Sub
    Public Sub CloseApplicationAfterDelay()
        Dim timer As New DispatcherTimer()
        timer.Interval = TimeSpan.FromSeconds(2)
        AddHandler timer.Tick, AddressOf Timer_Tick
        timer.Start()
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs)
        Dim timer As DispatcherTimer = CType(sender, DispatcherTimer)
        timer.Stop
        Windows.Application.Current.Shutdown()
    End Sub
End Class

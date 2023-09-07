Option Strict On

Imports System.ComponentModel

Public Class TTT
    Implements INotifyPropertyChanged

    Private currentTurn As String = "X"

    Private Const EMPTY_SPACE = " "

    Private board(,) As String = New String(2, 2) {
        {EMPTY_SPACE, EMPTY_SPACE, EMPTY_SPACE},
        {EMPTY_SPACE, EMPTY_SPACE, EMPTY_SPACE},
        {EMPTY_SPACE, EMPTY_SPACE, EMPTY_SPACE}
    }

    Public Property Turn As String
        Get
            Return currentTurn
        End Get
        Set(value As String)
            currentTurn = value
            NotifyPropertyChanged("Turn")
        End Set
    End Property

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Private Sub NotifyPropertyChanged(info As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
    End Sub

    Private Function CheckIfEmpty(row As Integer, col As Integer) As Boolean
        Return board(row, col) = EMPTY_SPACE
    End Function

    Private Sub SetPieceToPosition(row As Integer, col As Integer)
        board(row, col) = currentTurn
    End Sub
End Class

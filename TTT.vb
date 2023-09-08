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

    Public Function CheckIfEmpty(row As Integer, col As Integer) As Boolean
        Return board(row, col) = EMPTY_SPACE
    End Function

    Public Sub SetPieceToPosition(row As Integer, col As Integer)
        board(row, col) = currentTurn
    End Sub

    Public Sub SwitchTurns()
        Turn = If(Turn = "X", "O", "X")
    End Sub

    Public Function CheckIfLetterWon() As Boolean
        Return CheckIfRowWon() OrElse CheckIfColWon() OrElse CheckIfLeftDiagonalWon() OrElse CheckIfRightDiagonalWon()
    End Function

    Private Function CheckIfRowWon() As Boolean
        For row = 0 To board.GetUpperBound(0)
            If board(row, 0) <> EMPTY_SPACE AndAlso board(row, 0) = board(row, 1) AndAlso board(row, 1) = board(row, 2) Then
                Return True
            End If
        Next

        Return False
    End Function

    Private Function CheckIfColWon() As Boolean
        For col = 0 To board.GetUpperBound(0)
            If board(0, col) <> EMPTY_SPACE AndAlso board(0, col) = board(1, col) AndAlso board(1, col) = board(2, col) Then
                Return True
            End If
        Next

        Return False
    End Function


    ' Diagonals are based from the most bottom part of the board
    Private Function CheckIfLeftDiagonalWon() As Boolean
        Return board(0, 0) <> EMPTY_SPACE AndAlso board(0, 0) = board(1, 1) AndAlso board(1, 1) = board(2, 2)
    End Function

    Private Function CheckIfRightDiagonalWon() As Boolean
        Return board(0, 2) <> EMPTY_SPACE AndAlso board(0, 2) = board(1, 1) AndAlso board(1, 1) = board(2, 0)
    End Function
End Class

Option Strict On

Imports System.ComponentModel

Public Class TTT
    Implements INotifyPropertyChanged

    Private currentTurn As String = "X"

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

    Private Sub NotifyPropertyChanged(ByVal info As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
    End Sub

End Class

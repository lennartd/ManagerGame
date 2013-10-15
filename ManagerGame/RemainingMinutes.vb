Imports System.ComponentModel

Public Class RemainingMinutes
    Implements INotifyPropertyChanged


    Public Sub New()

        _remainingMinutes = 200

        If AllTeams.Teams.Count = 0 Then
            Exit Sub
        End If

        For i = 0 To AllTeams.Teams(CurrentTeamIndex).TeamPlayers.Players.Count - 1

            _remainingMinutes -= AllTeams.Teams(CurrentTeamIndex).TeamPlayers.Players(i).PlayerRotationMinutes
        Next
    End Sub

    Private _remainingMinutes As Integer
    Public Property RotationRemainingMinutes() As Integer
        Get
            Return _remainingMinutes
        End Get
        Set(ByVal value As Integer)
            _remainingMinutes = value
            RaiseProp("RotationRemainingMinutes")
        End Set
    End Property


    Public Sub RaiseProp(ByVal propertie As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(Propertie))
    End Sub

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
End Class

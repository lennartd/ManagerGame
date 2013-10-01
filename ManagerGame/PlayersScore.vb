Imports System.ComponentModel

Public Class PlayersScore
    Implements INotifyPropertyChanged

    ReadOnly _randomClass As New Random()

    Public Sub New()

    End Sub

    Public Sub New(ByVal players As PlayersList)


        _total = Nothing
        Dim playerPoints As Integer

        For i = 0 To players.Players.Count - 1

            If i > 11 Then
                playerPoints = 0
            Else

                Dim playerPotentialPoints As Integer = players.Players(i).PlayerRating * players.Players(i).PlayerRotationMinutes

                If players.Players(i).PlayerRotationNumber <= 5 Then

                    Dim playerPositionNumber As Integer = GetPlayerPositionNumber(players.Players(i).PlayerPosition)
                    Dim playerSecondPositionNumber As Integer = GetPlayerPositionNumber(players.Players(i).PlayerSecondPosition)

                    If players.Players(i).PlayerRotationNumber = playerPositionNumber Then
                        playerPotentialPoints = playerPotentialPoints * 1.1 ' + 10 %
                    ElseIf players.Players(i).PlayerRotationNumber = playerSecondPositionNumber Then
                        playerPotentialPoints = playerPotentialPoints ' + 0 %
                    Else
                        playerPotentialPoints = playerPotentialPoints * 0.6 ' - 40 %
                    End If

                End If

                Const factor As Double = 0.003
                Dim playerAveragePoints As Integer = playerPotentialPoints * factor

                Randomize()



                Dim min As Integer
                Dim max As Integer

                Dim randomNumber As Integer = _randomClass.Next(1, 100)

                Select Case randomNumber
                    Case 0 To 10
                        If playerAveragePoints - 10 < 0 Then
                            min = 0
                        Else
                            min = playerAveragePoints - 10
                        End If
                        If playerAveragePoints - 5 < 0 Then
                            max = 0
                        Else
                            max = playerAveragePoints - 5
                        End If
                    Case 90 To 100
                        min = playerAveragePoints + 5
                        max = playerAveragePoints + 10
                    Case Else
                        If playerAveragePoints - 5 < 0 Then
                            min = 0
                        Else
                            min = playerAveragePoints - 5
                        End If
                        max = playerAveragePoints + 5
                End Select

                playerPoints = Int(Rnd() * (max - min + 1) + min)
            End If

            For j = 0 To AllPlayers.Players.Count - 1

                If AllPlayers.Players(j).ToString = players.Players(i).ToString Then

                    AllPlayers.Players(j).PlayerPointsLastGame = playerPoints
                End If
            Next

            _total += playerPoints
        Next


    End Sub

    Private _total As Integer
    Public Property PlayerScoreTotal() As Integer
        Get
            Return _total
        End Get
        Set(ByVal value As Integer)
            _total = value
            RaiseProp("PlayerScoreTotal")
        End Set
    End Property


    Public Sub RaiseProp(ByVal propertie As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(Propertie))
    End Sub

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
End Class

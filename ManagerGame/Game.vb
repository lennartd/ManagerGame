Imports System.ComponentModel

Public Class Game
    Implements INotifyPropertyChanged


    Public Sub New()

    End Sub

    Public Sub New(ByVal opponentHome As Team, ByVal opponentGuest As Team, ByVal totalScore As Score)
        _opponentHome = opponentHome : _opponentGuest = opponentGuest : _totalScore = totalScore
    End Sub


    Private _opponentHome As Team
    Public Property GameOpponentHome() As Team
        Get
            Return _opponentHome
        End Get
        Set(ByVal value As Team)
            _opponentHome = value
            RaiseProp("GameOpponentHome")
        End Set
    End Property

    Private _opponentGuest As Team
    Public Property GameOpponentGuest() As Team
        Get
            Return _opponentGuest
        End Get
        Set(ByVal value As Team)
            _opponentGuest = value
            RaiseProp("GameOpponentGuest")
        End Set
    End Property

    Private _totalScore As Score
    Public Property GameTotalScore() As Score
        Get
            Return _totalScore
        End Get
        Set(ByVal value As Score)
            _totalScore = value
            RaiseProp("GameTotalScore")
        End Set
    End Property


    Public Overrides Function ToString() As String
        Return GameOpponentHome.ToString & " vs. " & GameOpponentGuest.ToString
    End Function


    Public Sub RaiseProp(ByVal propertie As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(Propertie))
    End Sub

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

End Class

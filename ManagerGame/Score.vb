Imports System.ComponentModel

Public Class Score
    Implements INotifyPropertyChanged

    Public Sub New()
    End Sub

    'TODO: eventuell falsch??
    Public Sub New(ByVal scorehome As PlayersScore, ByVal guest As PlayersScore)
        _home = scorehome : _guest = guest
    End Sub

    Private _home As PlayersScore
    Public Property ScoreHome() As PlayersScore
        Get
            Return _home
        End Get
        Set(ByVal value As PlayersScore)
            _home = value
            RaiseProp("ScoreHome")
        End Set
    End Property

    Private _guest As PlayersScore
    Public Property ScoreGuest() As PlayersScore
        Get
            Return _guest
        End Get
        Set(ByVal value As PlayersScore)
            _guest = value
            RaiseProp("ScoreGuest")
        End Set
    End Property


    Public Sub RaiseProp(ByVal propertie As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(Propertie))
    End Sub

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
End Class

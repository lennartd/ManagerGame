Imports System.ComponentModel

Public Class Team
    Implements INotifyPropertyChanged

    Public Sub New()

    End Sub

    Public Sub New(ByVal name As String, ByVal players As PlayersList, ByVal coach As Coach, _
                   ByVal money As Integer, ByVal wins As Integer, ByVal losses As Integer, _
                   ByVal additionalSalary As Integer)
        _name = name : _players = players : _players = players : _coach = coach : _money = money
        _wins = wins : _losses = losses : _additionalSalary = additionalSalary
    End Sub

    Private _name As String
    Public Property TeamName() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
            RaiseProp("TeamName")
        End Set
    End Property

    Private _players As New PlayersList
    Public Property TeamPlayers() As PlayersList
        Get
            Return _players
        End Get
        Set(ByVal value As PlayersList)
            _players = value
            RaiseProp("TeamPlayers")
        End Set
    End Property

    Private _coach As Coach
    Public Property TeamCoach() As Coach
        Get
            Return _coach
        End Get
        Set(ByVal value As Coach)
            _coach = value
            RaiseProp("TeamCoach")
        End Set
    End Property

    Private _money As Integer
    Public Property TeamMoney() As Integer
        Get
            Return _money
        End Get
        Set(ByVal value As Integer)
            _money = value
            RaiseProp("TeamMoney")
        End Set
    End Property

    Private _wins As Integer
    Public Property TeamWins() As Integer
        Get
            Return _wins
        End Get
        Set(ByVal value As Integer)
            _wins = value
            RaiseProp("TeamWins")
        End Set
    End Property

    Private _losses As Integer
    Public Property TeamLosses() As Integer
        Get
            Return _losses
        End Get
        Set(ByVal value As Integer)
            _losses = value
            RaiseProp("TeamLosses")
        End Set
    End Property

    Private _additionalSalary As Integer
    Public Property TeamAdditionalSalary() As Integer
        Get
            Return _additionalSalary
        End Get
        Set(ByVal value As Integer)
            _additionalSalary = value
            RaiseProp("TeamAdditionalSalary")
        End Set
    End Property



    Public Overrides Function ToString() As String
        Return TeamName
    End Function

    Public Sub RaiseProp(ByVal propertie As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(Propertie))
    End Sub

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
End Class

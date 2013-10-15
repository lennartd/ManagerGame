Imports System.ComponentModel

Public Class ClassesContainer
    Implements INotifyPropertyChanged


    Public Sub New()

    End Sub

    Public Sub New(ByVal coaches As CoachesList, ByVal daysofplay As DaysOfPlayList, ByVal emails As EmailsList, ByVal games As GamesList, _
                   ByVal offers As OffersList, ByVal players As PlayersList, ByVal teams As TeamsList, ByVal publicproperties As PublicProperties, _
                   ByVal remainingminutes As RemainingMinutesList, ByVal availableplayers As PlayersList, ByVal availablecoaches As CoachesList)
        _coaches = coaches : _daysofPlay = daysofplay : _emails = emails : _games = games : _offers = offers : _players = players : _teams = teams
        _publicproperties = publicproperties : _remainingminutes = remainingminutes : _availableplayers = availableplayers : _availablecoaches = availablecoaches
    End Sub

    Private _coaches As CoachesList
    Public Property ClassesContainerCoaches() As CoachesList
        Get
            Return _coaches
        End Get
        Set(ByVal value As CoachesList)
            _coaches = value
            RaiseProp("ClassesContainerCoaches")
        End Set
    End Property

    Private _daysofPlay As DaysOfPlayList
    Public Property ClassesContainerDaysOfPlay() As DaysOfPlayList
        Get
            Return _daysofPlay
        End Get
        Set(ByVal value As DaysOfPlayList)
            _daysofPlay = value
            RaiseProp("ClassesContainerDaysOfPlay")
        End Set
    End Property

    Private _emails As EmailsList
    Public Property ClassesContainerEmails() As EmailsList
        Get
            Return _emails
        End Get
        Set(ByVal value As EmailsList)
            _emails = value
            RaiseProp("ClassesContainerEmails")
        End Set
    End Property
    Private _games As GamesList

    Public Property ClassesContainerGames() As GamesList
        Get
            Return _games
        End Get
        Set(ByVal value As GamesList)
            _games = value
            RaiseProp("ClassesContainerGames")
        End Set
    End Property

    Private _offers As OffersList
    Public Property ClassesContainerOffers() As OffersList
        Get
            Return _offers
        End Get
        Set(ByVal value As OffersList)
            _offers = value
            RaiseProp("ClassesContainerOffers")
        End Set
    End Property

    Private _players As PlayersList
    Public Property ClassesContainerPlayers() As PlayersList
        Get
            Return _players
        End Get
        Set(ByVal value As PlayersList)
            _players = value
            RaiseProp("ClassesContainerPlayers")
        End Set
    End Property

    Private _teams As TeamsList
    Public Property ClassesContainerTeams() As TeamsList
        Get
            Return _teams
        End Get
        Set(ByVal value As TeamsList)
            _teams = value
            RaiseProp("ClassesContainerTeams")
        End Set
    End Property

    Private _publicproperties As PublicProperties
    Public Property ClassesContainerPublicProperties() As PublicProperties
        Get
            Return _publicproperties
        End Get
        Set(ByVal value As PublicProperties)
            _publicproperties = value
            RaiseProp("ClassesContainerPublicProperties")
        End Set
    End Property


    Private _remainingminutes As RemainingMinutesList
    Public Property ClassesContainerRemainingMinutes() As RemainingMinutesList
        Get
            Return _remainingminutes
        End Get
        Set(ByVal value As RemainingMinutesList)
            _remainingminutes = value
            RaiseProp("ClassesContainerRemainingMinutes")
        End Set
    End Property

    Private _availableplayers As PlayersList
    Public Property ClassesContainerAvailablePlayers() As PlayersList
        Get
            Return _availableplayers
        End Get
        Set(ByVal value As PlayersList)
            _availableplayers = value
            RaiseProp("ClassesContainerAvailablePlayers")
        End Set
    End Property

    Private _availablecoaches As CoachesList
    Public Property ClassesContainerAvailableCoaches() As CoachesList
        Get
            Return _availablecoaches
        End Get
        Set(ByVal value As CoachesList)
            _availablecoaches = value
            RaiseProp("ClassesContainerAvailableCoaches")
        End Set
    End Property

    Public Sub RaiseProp(ByVal propertie As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertie))
    End Sub

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
End Class

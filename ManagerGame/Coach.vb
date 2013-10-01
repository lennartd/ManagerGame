Imports System.ComponentModel

Public Class Coach
    Implements INotifyPropertyChanged


    Public Sub New()

        _firstName = Nothing
    End Sub

    Public Sub New(ByVal firstName As String, ByVal lastName As String, ByVal birthday As String, _
                   ByVal nationality As String, ByVal rating As Integer, ByVal currentTeam As String, _
                   ByVal salary As Integer, ByVal offers As OffersList)
        _firstName = firstName : _lastName = lastName : _birthday = birthday : _nationality = nationality
        _rating = rating : _currentTeam = currentTeam : _salary = salary : _offers = offers
    End Sub


    Private _firstName As String
    Public Property CoachFirstName() As String
        Get
            Return _firstName
        End Get
        Set(ByVal value As String)
            _firstName = value
            RaiseProp("CoachFirstName")
        End Set
    End Property

    Private _lastName As String
    Public Property CoachLastName() As String
        Get
            Return _lastName
        End Get
        Set(ByVal value As String)
            _lastName = value
            RaiseProp("CoachLastName")
        End Set
    End Property

    Private _birthday As String
    Public Property CoachBirthday() As String
        Get
            Return _birthday
        End Get
        Set(ByVal value As String)
            _birthday = value
            RaiseProp("CoachBirthday")
        End Set
    End Property

    Private _nationality As String
    Public Property CoachNationality() As String
        Get
            Return _nationality
        End Get
        Set(ByVal value As String)
            _nationality = value
            RaiseProp("CoachNationality")
        End Set
    End Property

    Private _rating As Integer
    Public Property CoachRating() As Integer
        Get
            Return _rating
        End Get
        Set(ByVal value As Integer)
            _rating = value
            RaiseProp("CoachRating")
        End Set
    End Property

    Private _currentTeam As String
    Public Property CoachCurrentTeam() As String
        Get
            Return _currentTeam
        End Get
        Set(ByVal value As String)
            _currentTeam = value
            RaiseProp("CoachCurrentTeam")
        End Set
    End Property


    Private _salary As Integer
    Public Property CoachSalary() As Integer
        Get
            Return _salary
        End Get
        Set(ByVal value As Integer)
            _salary = value
            RaiseProp("CoachSalary")
        End Set
    End Property

    Private _offers As New OffersList
    Public Property CoachOffers() As OffersList
        Get
            Return _offers
        End Get
        Set(ByVal value As OffersList)
            _offers = value
            RaiseProp("CoachOffers")
        End Set
    End Property





    Public Overrides Function ToString() As String
        Return _firstName & " " & _lastName
    End Function

    Public Sub RaiseProp(ByVal propertie As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(Propertie))
    End Sub

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
End Class

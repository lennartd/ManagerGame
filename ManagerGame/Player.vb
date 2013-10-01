Imports System.ComponentModel

Public Class Player
    Implements INotifyPropertyChanged

    Public Sub New()

    End Sub

    Public Sub New(ByVal firstName As String, ByVal lastName As String, ByVal birthday As String, ByVal nationality As String, _
                   ByVal size As Integer, ByVal weight As Integer, ByVal position As String,
                   ByVal secondPosition As String, ByVal rating As Integer, ByVal currentTeam As String, ByVal salary As Integer, _
                   ByVal contractUntil As Integer, ByVal rotationNumber As Integer, ByVal rotationMinutes As Integer, ByVal offers As OffersList, _
                   ByVal pointsLastGame As Integer)
        _firstName = firstName : _lastName = lastName : _position = position : _rating = rating
        _secondPosition = secondPosition : _birthday = birthday
        _salary = salary : _rotationNumber = rotationNumber : _rotationMinutes = rotationMinutes
        _nationality = nationality : _size = size : _weight = weight : _contractUntil = contractUntil
        _currentTeam = currentTeam : _offers = offers : _pointsLastGame = pointsLastGame
    End Sub

    Private _firstName As String
    Public Property PlayerFirstName() As String
        Get
            Return _firstName
        End Get
        Set(ByVal value As String)
            _firstName = value
            RaiseProp("PlayerFirstName")
        End Set
    End Property

    Private _lastName As String
    Public Property PlayerLastName() As String
        Get
            Return _lastName
        End Get
        Set(ByVal value As String)
            _lastName = value
            RaiseProp("PlayerLastName")
        End Set
    End Property

    Private _birthday As String
    Public Property PlayerBirthday() As String
        Get
            Return _birthday
        End Get
        Set(ByVal value As String)
            _birthday = value
            RaiseProp("PlayerBirthday")
        End Set
    End Property

    Private _nationality As String
    Public Property PlayerNationality() As String
        Get
            Return _nationality
        End Get
        Set(ByVal value As String)
            _nationality = value
            RaiseProp("PlayerNationality")
        End Set
    End Property


    Private _size As Integer
    Public Property PlayerSize() As Integer
        Get
            Return _size
        End Get
        Set(ByVal value As Integer)
            _size = value
            RaiseProp("PlayerSize")
        End Set
    End Property


    Private _weight As Integer
    Public Property PlayerWeight() As Integer
        Get
            Return _weight
        End Get
        Set(ByVal value As Integer)
            _weight = value
            RaiseProp("PlayerWeight")
        End Set
    End Property


    Private _position As String
    Public Property PlayerPosition() As String
        Get
            Return _position
        End Get
        Set(ByVal value As String)
            _position = value
            RaiseProp("PlayerPosition")
        End Set
    End Property

    Private _secondPosition As String
    Public Property PlayerSecondPosition() As String
        Get
            Return _secondPosition
        End Get
        Set(ByVal value As String)
            _secondPosition = value
            RaiseProp("PlayerSecondPosition")
        End Set
    End Property


    Private _rating As Integer
    Public Property PlayerRating() As Integer
        Get
            Return _rating
        End Get
        Set(ByVal value As Integer)
            _rating = value
            RaiseProp("PlayerRating")
        End Set
    End Property

    Private _currentTeam As String
    Public Property PlayerCurrentTeam() As String
        Get
            Return _currentTeam
        End Get
        Set(ByVal value As String)
            _currentTeam = value
            RaiseProp("PlayerCurrentTeam")
        End Set
    End Property

    Private _salary As Integer
    Public Property PlayerSalary() As Integer
        Get
            Return _salary
        End Get
        Set(ByVal value As Integer)
            _salary = value
            RaiseProp("PlayerSalary")
        End Set
    End Property

    Private _contractUntil As Integer
    Public Property PlayerContractUntil() As Integer
        Get
            Return _contractUntil
        End Get
        Set(ByVal value As Integer)
            _contractUntil = value
            RaiseProp("PlayerContractUntil")
        End Set
    End Property


    Private _rotationNumber As Integer
    Public Property PlayerRotationNumber() As Integer
        Get
            Return _rotationNumber
        End Get
        Set(ByVal value As Integer)
            _rotationNumber = value
            RaiseProp("PlayerRotationNumber")
        End Set
    End Property

    Private _rotationMinutes As Integer
    Public Property PlayerRotationMinutes() As Integer
        Get
            Return _rotationMinutes
        End Get
        Set(ByVal value As Integer)
            _rotationMinutes = value
            RaiseProp("PlayerRotationMinutes")
        End Set
    End Property

    Private _offers As New OffersList
    Public Property PlayerOffers() As OffersList
        Get
            Return _offers
        End Get
        Set(ByVal value As OffersList)
            _offers = value
            RaiseProp("PlayerOffers")
        End Set
    End Property

    Private _pointsLastGame As Integer
    Public Property PlayerPointsLastGame() As Integer
        Get
            Return _pointsLastGame
        End Get
        Set(ByVal value As Integer)
            _pointsLastGame = value
            RaiseProp("PlayerPointsLastGame")
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

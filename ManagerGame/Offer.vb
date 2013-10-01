Imports System.ComponentModel

Public Class Offer
    Implements INotifyPropertyChanged


    Public Sub New()

    End Sub

    Public Sub New(ByVal playerName As String, ByVal currentTeamName As String, ByVal madeDate As Date, _
                   ByVal lastDealtDate As Date, ByVal redemption As String, ByVal salary As String, ByVal biddingTeam As String, _
                   ByVal contractUntil As Integer, ByVal status As Integer)
        _redemption = redemption : _salary = salary : _biddingTeam = biddingTeam : _madeDate = madeDate
        _status = status : _playerName = playerName : _contractUntil = contractUntil
        _currentTeamName = currentTeamName : _lastDealtDate = lastDealtDate
    End Sub

    Private _playerName As String
    Public Property OfferPlayerName() As String
        Get
            Return _playerName
        End Get
        Set(ByVal value As String)
            _playerName = value
            RaiseProp("OfferPlayerName")
        End Set
    End Property

    Private _currentTeamName As String
    Public Property OfferCurrentTeamName() As String
        Get
            Return _currentTeamName
        End Get
        Set(ByVal value As String)
            _currentTeamName = value
            RaiseProp("OfferCurrentTeamName")
        End Set
    End Property



    Private _madeDate As Date
    Public Property OfferMadeDate() As Date
        Get
            Return _madeDate
        End Get
        Set(ByVal value As Date)
            _madeDate = value
            RaiseProp("OfferMadeDate")
        End Set
    End Property

    Private _lastDealtDate As Date
    Public Property OfferLastDealtDate() As Date
        Get
            Return _lastDealtDate
        End Get
        Set(ByVal value As Date)
            _lastDealtDate = value
            RaiseProp("OfferLastDealtDate")
        End Set
    End Property


    Private _redemption As Integer
    Public Property OfferRedemption() As Integer
        Get
            Return _redemption
        End Get
        Set(ByVal value As Integer)
            _redemption = value
            RaiseProp("OfferRedemption")
        End Set
    End Property

    Private _salary As Integer
    Public Property OfferSalary() As Integer
        Get
            Return _salary
        End Get
        Set(ByVal value As Integer)
            _salary = value
            RaiseProp("OfferSalary")
        End Set
    End Property

    Private _biddingTeam As String
    Public Property OfferBiddingTeam() As String
        Get
            Return _biddingTeam
        End Get
        Set(ByVal value As String)
            _biddingTeam = value
            RaiseProp("OfferBiddingTeam")
        End Set
    End Property

    Private _contractUntil As Integer
    Public Property OfferContractUntil() As Integer
        Get
            Return _contractUntil
        End Get
        Set(ByVal value As Integer)
            _contractUntil = value
            RaiseProp("OfferContractUntil")
        End Set
    End Property


    Private _status As Integer
    Public Property OfferStatus() As Integer
        Get
            Return _status
        End Get
        Set(ByVal value As Integer)
            _status = value
            RaiseProp("OfferStatus")
        End Set
    End Property
    'Converter: Public function ConvertStatusToString



    Public Overrides Function ToString() As String
        Return OfferPlayerName
    End Function


    Public Sub RaiseProp(ByVal propertie As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(Propertie))
    End Sub

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

End Class

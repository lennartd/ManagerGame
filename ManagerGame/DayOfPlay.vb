Imports System.ComponentModel

Public Class DayOfPlay
    Implements INotifyPropertyChanged


    Public Sub New()

    End Sub

    Public Sub New(ByVal number As Integer, ByVal actualDate As Date, ByVal games As GamesList)
        _number = number : _actualDate = actualDate : _games = games
    End Sub

    Private _number As Integer
    Public Property DayOfPlayNumber() As Integer
        Get
            Return _number
        End Get
        Set(ByVal value As Integer)
            _number = value
            RaiseProp("DayOfPlayNumber")
        End Set
    End Property

    Private _actualDate As Date
    Public Property DayOfPlayActualDate() As Date
        Get
            Return _actualDate
        End Get
        Set(ByVal value As Date)
            _actualDate = value
            RaiseProp("DayOfPlayActualDate")
        End Set
    End Property


    Private _games As GamesList
    Public Property DayOfPlayGames() As GamesList
        Get
            Return _games
        End Get
        Set(ByVal value As GamesList)
            _games = value
            RaiseProp("DayOfPlayGames")
        End Set
    End Property



    Public Sub RaiseProp(ByVal propertie As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(Propertie))
    End Sub

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
End Class

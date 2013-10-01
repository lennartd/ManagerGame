Imports System.ComponentModel

Public Class PublicProperties
    Implements INotifyPropertyChanged


    Public Sub New()

    End Sub

    Public Sub New(ByVal currentDate As Date)
        _currentDate = currentDate
    End Sub

    Private _currentDate As Date
    Public Property PublicPropertyCurrentDate() As Date
        Get
            Return _currentDate
        End Get
        Set(ByVal value As Date)
            _currentDate = value
            RaiseProp("PublicPropertyCurrentDate")
        End Set
    End Property

    Public Sub RaiseProp(ByVal propertie As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(Propertie))
    End Sub

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
End Class

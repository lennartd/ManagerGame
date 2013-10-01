Imports System.Collections.ObjectModel

Public Class GamesList

    Private _games As New ObservableCollection(Of Game)
    Public Property Games() As ObservableCollection(Of Game)
        Get
            Return _Games
        End Get
        Set(ByVal value As ObservableCollection(Of Game))
            _Games = value
        End Set
    End Property

End Class

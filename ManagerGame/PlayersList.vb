Imports System.Collections.ObjectModel

Public Class PlayersList

    Private _players As New ObservableCollection(Of Player)
    Public Property Players() As ObservableCollection(Of Player)
        Get
            Return _Players
        End Get
        Set(ByVal value As ObservableCollection(Of Player))
            _Players = value
        End Set
    End Property



End Class

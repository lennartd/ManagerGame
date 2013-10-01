Imports System.Collections.ObjectModel

Public Class TeamsList

    Private _teams As New ObservableCollection(Of Team)
    Public Property Teams() As ObservableCollection(Of Team)
        Get
            Return _Teams
        End Get
        Set(ByVal value As ObservableCollection(Of Team))
            _Teams = value
        End Set
    End Property



End Class

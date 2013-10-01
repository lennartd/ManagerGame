Imports System.Collections.ObjectModel

Public Class CoachesList

    Private _coaches As New ObservableCollection(Of Coach)
    Public Property Coaches() As ObservableCollection(Of Coach)
        Get
            Return _Coaches
        End Get
        Set(ByVal value As ObservableCollection(Of Coach))
            _Coaches = value
        End Set
    End Property

End Class

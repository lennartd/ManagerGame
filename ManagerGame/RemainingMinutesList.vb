Imports System.Collections.ObjectModel

Public Class RemainingMinutesList

    Private _remainingMinutes As New ObservableCollection(Of RemainingMinutes)
    Public Property RemainingMinutes() As ObservableCollection(Of RemainingMinutes)
        Get
            Return _RemainingMinutes
        End Get
        Set(ByVal value As ObservableCollection(Of RemainingMinutes))
            _RemainingMinutes = value
        End Set
    End Property

End Class

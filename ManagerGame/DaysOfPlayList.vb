Imports System.Collections.ObjectModel

Public Class DaysOfPlayList

    Private _daysOfPlay As New ObservableCollection(Of DayOfPlay)
    Public Property DaysOfPlay() As ObservableCollection(Of DayOfPlay)
        Get
            Return _DaysOfPlay
        End Get
        Set(ByVal value As ObservableCollection(Of DayOfPlay))
            _DaysOfPlay = value
        End Set
    End Property
End Class

Imports System.Collections.ObjectModel

Public Class EmailsList

    Private _emails As New ObservableCollection(Of Email)
    Public Property Emails() As ObservableCollection(Of Email)
        Get
            Return _emails
        End Get
        Set(ByVal value As ObservableCollection(Of Email))
            _emails = value
        End Set
    End Property

End Class

Imports System.Collections.ObjectModel

Public Class OffersList

    Private _offers As New ObservableCollection(Of Offer)
    Public Property Offers() As ObservableCollection(Of Offer)
        Get
            Return _Offers
        End Get
        Set(ByVal value As ObservableCollection(Of Offer))
            _Offers = value
        End Set
    End Property
End Class

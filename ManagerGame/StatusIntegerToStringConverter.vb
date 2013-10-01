' ReSharper disable once CheckNamespace
Public Class StatusIntegerToStringConverter
    Implements IValueConverter


    Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As Globalization.CultureInfo) As Object Implements IValueConverter.Convert
        '__________________________
        '
        '0 : OfferMade
        '1 : RedemptionDeclined
        '2 : RedemptionAccepted
        '3 : SalaryDeclined
        '4 : SalaryAccepted
        '5 : TransferSucessfull
        '6 : TransferFailed
        '
        '__________________________

        Dim status As Integer = DirectCast(value, Integer)
        Dim statusString As String = Nothing

        Select Case status

            Case 0
                statusString = "Das Angebot wurde versendet."
            Case 1
                statusString = "Die Ablösesumme wurde abgelehnt."
            Case 2
                statusString = "Die Ablösesumme wurde akzeptiert."
            Case 3
                statusString = "Das Gehalt wurde abgelehnt."
            Case 4
                statusString = "Das Gehalt wurde angenommen."
            Case 5
                statusString = "Der Transfer war erfolgreich."
            Case 6
                statusString = "Der Transfer ist gescheitert."

        End Select


        Return statusString

    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
        Return Nothing
    End Function

End Class

' ReSharper disable once CheckNamespace
Public Class CoachRatingToSalaryEuroConverter
    Implements IValueConverter


    Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As Globalization.CultureInfo) As Object Implements IValueConverter.Convert
        Dim rating As Integer = DirectCast(value, Integer)
        Dim salary As Integer = Nothing
        Select Case rating
            Case rating >= 90
                salary = 7000
                Exit Select
            Case Is >= 80
                salary = 5500
                Exit Select
            Case rating >= 70
                salary = 4500
                Exit Select
            Case rating >= 60
                salary = 3500
                Exit Select
            Case rating >= 50
                salary = 2500
                Exit Select
            Case rating >= 40
                salary = 1250
                Exit Select
        End Select

        Return salary & " €"
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
        Return Nothing
    End Function

End Class

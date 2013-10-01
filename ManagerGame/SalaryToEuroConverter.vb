' ReSharper disable once CheckNamespace
Public Class SalaryToEuroConverter
    Implements IValueConverter


    Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As Globalization.CultureInfo) As Object Implements IValueConverter.Convert
        Dim salary As Integer = DirectCast(value, Integer)
        Return salary & " €"
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
        Dim salaryEuro As String = DirectCast(value, String)

        Return CInt(salaryEuro.Split(" ")(0))
    End Function
End Class

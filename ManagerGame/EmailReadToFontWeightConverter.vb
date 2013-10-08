Public Class EmailReadToFontWeightConverter
    Implements IValueConverter

    Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As Globalization.CultureInfo) As Object Implements IValueConverter.Convert
        Dim emailRead As Boolean = DirectCast(value, Boolean)

        If emailRead = True Then
            Return FontWeights.Normal
        Else
            Return FontWeights.Bold
        End If
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
        Return Nothing
    End Function
End Class

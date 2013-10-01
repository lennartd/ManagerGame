' ReSharper disable once CheckNamespace
Public Class TeamCoachTobtnReleaseCoachContentConverter
    Implements IValueConverter


    Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As Globalization.CultureInfo) As Object Implements IValueConverter.Convert

        Dim currentCoach As Coach = DirectCast(value, Coach)

        Dim coachName As String = currentCoach.ToString

        If coachName = " " Then
            Return "Trainer einstellen"
        Else
            Return "Trainer entlassen"
        End If
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
        Return Nothing
    End Function
End Class

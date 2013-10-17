' ReSharper disable once CheckNamespace
Public Class PlayerCurrentTeamToDirectionConverter
    Implements IValueConverter

    Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As Globalization.CultureInfo) As Object Implements IValueConverter.Convert

        Dim currentTeamName As String = DirectCast(value, String)

        If currentTeamName = AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamName Then

            Return "Eingehend"
        Else
            Return "Ausgehend"

        End If

    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
        Return Nothing
    End Function
End Class

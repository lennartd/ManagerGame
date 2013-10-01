' ReSharper disable once CheckNamespace
Public Class GamesToFontWeightConverter
    Implements IMultiValueConverter
    'To borderthickness!

    Public Function Convert1(values() As Object, targetType As Type, parameter As Object, culture As Globalization.CultureInfo) As Object Implements IMultiValueConverter.Convert
        Dim gameOpponentHome As String = values(0).ToString
        Dim gameOpponentGuest As String = values(1).ToString

        If gameOpponentHome.Contains(AllTeams.Teams(CurrentTeamIndex).TeamName) Or _
            gameOpponentGuest.Contains(AllTeams.Teams(CurrentTeamIndex).TeamName) Then

            Dim thickness As New Thickness(2)
            Return thickness
        Else
            Dim thickness As New Thickness(0)
            Return thickness
        End If
    End Function

    Public Function ConvertBack(value As Object, targetTypes() As Type, parameter As Object, culture As Globalization.CultureInfo) As Object() Implements IMultiValueConverter.ConvertBack
        Return Nothing
    End Function
End Class

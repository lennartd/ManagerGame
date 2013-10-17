' ReSharper disable once CheckNamespace
Public Class NewGameWindow

    Private Sub WindowNewGame_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        DataContext = AllTeams
    End Sub

    Private Sub btnStartNewGame_Click(sender As Object, e As RoutedEventArgs)

        If cmbbxSelectTeam.Text = Nothing Then
            MsgBox("Team wählen!")
            Exit Sub
        End If

        For i = 0 To AllTeams.Teams.Count - 1

            If AllTeams.Teams(i).TeamName = cmbbxSelectTeam.Text Then
                AllPublicProperties.PublicPropertyCurrentTeamIndex = i
            End If
        Next


        Dim w As New GameWindow
        w.Show()

        Close()
    End Sub
End Class

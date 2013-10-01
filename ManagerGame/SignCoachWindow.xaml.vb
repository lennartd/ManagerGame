' ReSharper disable once CheckNamespace
Public Class SignCoachWindow

    Private Sub SignCoachWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        lstvwCoaches.DataContext = AvailableCoaches
        btnSignCoach.DataContext = lstvwCoaches
    End Sub

    Private Sub btnSignCoach_Click(sender As Object, e As RoutedEventArgs)

        Dim coachName As String = lstvwCoaches.SelectedItem.ToString
        Dim coachIndex = Nothing

        Dim converter As New CoachRatingToSalaryEuroConverter
        Dim converter2 As New SalaryToEuroConverter

        For i = 0 To AllCoaches.Coaches.Count - 1

            If coachName = AllCoaches.Coaches(i).ToString Then

                coachIndex = 1
            End If
        Next

        'coach salary
        'btn with converter enabled


        Dim result As MessageBoxResult = MsgBox(coachName & " wirklich für " & _
                                                converter.Convert(AllCoaches.Coaches(coachIndex).CoachRating, Nothing, Nothing, _
                                                                  Nothing) & " einstellen?", _
                                                MsgBoxStyle.YesNoCancel)

        If result = MessageBoxResult.Yes Then

            For i = 0 To AvailableCoaches.Coaches.Count - 1

                If coachName = AvailableCoaches.Coaches(i).ToString Then

                    AllTeams.Teams(CurrentTeamIndex).TeamCoach = AvailableCoaches.Coaches(i)
                    AllTeams.Teams(CurrentTeamIndex).TeamCoach.CoachSalary = converter2.ConvertBack(converter.Convert(AllCoaches.Coaches(coachIndex).CoachRating, Nothing, Nothing, Nothing), Nothing, Nothing, Nothing)

                    AvailableCoaches.Coaches.RemoveAt(i)
                End If
            Next

            Dim w = TryCast(Application.Current.Windows.Cast(Of Window)().FirstOrDefault(Function(window) TypeOf window Is GameWindow), GameWindow)

            w.stckpnCoach.DataContext = Nothing
            w.stckpnCoach.DataContext = AllTeams.Teams(CurrentTeamIndex).TeamCoach

            w.Close()

            Dim w2 As New GameWindow
            w2.Show()

            Close()
        End If
    End Sub
End Class

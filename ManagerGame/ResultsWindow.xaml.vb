' ReSharper disable once CheckNamespace
Public Class ResultsWindow

    Dim _currentDayOfPlayIndex As Integer

    Private Sub ResultsWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        For i = 0 To AllDaysOfPlay.DaysOfPlay.Count - 1

            If AllDaysOfPlay.DaysOfPlay(i).DayOfPlayActualDate = AllPublicProperties.PublicPropertyCurrentDate.AddDays(-1) Then

                lstbxGamesToday.DataContext = AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames
                _currentDayOfPlayIndex = i
            End If
        Next

        cmbbxChooseTeam.SelectedIndex = 0

        grdGame.Visibility = Visibility.Hidden

    End Sub

    Private Sub lstbxGamesToday_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles lstbxGamesToday.SelectionChanged

        If lstbxGamesToday.SelectedItem Is Nothing Then
            grdGame.Visibility = Visibility.Hidden
        Else
            grdGame.Visibility = Visibility.Visible
        End If

        lblSelectedGame.DataContext = AllDaysOfPlay.DaysOfPlay(_currentDayOfPlayIndex).DayOfPlayGames.Games(lstbxGamesToday.SelectedIndex)

        Dim selectedItem As ComboBoxItem = cmbbxChooseTeam.SelectedItem

        If selectedItem.Content.ToString = "Heim" Then
            grdStats.DataContext = AllDaysOfPlay.DaysOfPlay(_currentDayOfPlayIndex).DayOfPlayGames.Games(lstbxGamesToday.SelectedIndex).GameOpponentHome.TeamPlayers
        ElseIf selectedItem.Content.ToString = "Auswärts" Then
            grdStats.DataContext = AllDaysOfPlay.DaysOfPlay(_currentDayOfPlayIndex).DayOfPlayGames.Games(lstbxGamesToday.SelectedIndex).GameOpponentGuest.TeamPlayers
        End If

    End Sub


    Private Sub cmbbxChooseTeam_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cmbbxChooseTeam.SelectionChanged

        If lstbxGamesToday.SelectedItem Is Nothing Then
            Exit Sub
        End If

        Dim selectedItem As ComboBoxItem = cmbbxChooseTeam.SelectedItem

        If selectedItem.Content.ToString = "Heim" Then
            grdStats.DataContext = AllDaysOfPlay.DaysOfPlay(_currentDayOfPlayIndex).DayOfPlayGames.Games(lstbxGamesToday.SelectedIndex).GameOpponentHome.TeamPlayers
        ElseIf selectedItem.Content.ToString = "Auswärts" Then
            grdStats.DataContext = AllDaysOfPlay.DaysOfPlay(_currentDayOfPlayIndex).DayOfPlayGames.Games(lstbxGamesToday.SelectedIndex).GameOpponentGuest.TeamPlayers
        End If

    End Sub
End Class

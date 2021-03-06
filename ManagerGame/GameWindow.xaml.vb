﻿Imports System
Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Data
Imports System.Collections.Specialized


Public Class GameWindow

    Dim _lstvwRotationNeedsToBeSorted As Boolean = True

    Private Sub GameWindow_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        If Saved = True Then
            Saved = False
            Exit Sub
        End If
        Dim result As MsgBoxResult = MsgBox("Wollen Sie das Spiel Speichern? Wenn Sie das Spiel nicht speichern gehen alle ungespeicherten Änderungen verloren!", _
                                            MsgBoxStyle.YesNoCancel, "Speichern?")

        If result = MsgBoxResult.Yes Then
            e.Cancel = True
            Dim w As New SaveWindow
            w.Show()
        ElseIf result = MsgBoxResult.No Then
            e.Cancel = False
            Application.Current.Shutdown()
        Else
            e.Cancel = True
        End If

    End Sub

    Private Sub GameWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded

        lstvwRotation.DataContext = AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers

        lblRemainingMinutes.DataContext = AllRemainingMinutes.RemainingMinutes(0) 'korrekt?

        stckpnCoach.DataContext = AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamCoach

        btnReleaseCoach.DataContext = AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex)

        lblCurrentDate.DataContext = AllPublicProperties


        For i = 0 To AllDaysOfPlay.DaysOfPlay.Count - 1

            If AllDaysOfPlay.DaysOfPlay(i).DayOfPlayActualDate = AllPublicProperties.PublicPropertyCurrentDate Then

                lstbxGamesToday.DataContext = AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames
            End If
        Next


        btnNewEmails.DataContext = AllEmails

        AddHandler DirectCast(lstvwRotation.Items, INotifyCollectionChanged).CollectionChanged, AddressOf lstbxRotation_ItemsChanged

    End Sub

    Private Sub lstbxRotation_ItemsChanged(sender As Object, e As NotifyCollectionChangedEventArgs)
        If _lstvwRotationNeedsToBeSorted = True Then
            _lstvwRotationNeedsToBeSorted = False
            SortlstvwRotations()
        End If
    End Sub


    Private Sub SortlstvwRotations()

        ' Get the default view from the listview  
        Dim view As ICollectionView = CollectionViewSource.GetDefaultView(lstvwRotation.ItemsSource)

        view.SortDescriptions.Clear()
        view.SortDescriptions.Add(New SortDescription("PlayerRotationNumber", ListSortDirection.Ascending))
    End Sub

    Private Sub btnUp_Click(sender As Object, e As RoutedEventArgs)
        If lstvwRotation.SelectedIndex > 0 Then


            Dim selectedPlayerNewRotationNumber As Integer = Nothing
            Dim selectedPlayerName As String = lstvwRotation.SelectedValue.ToString

            For i = 0 To AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players.Count - 1

                If selectedPlayerName = AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players(i).ToString Then

                    AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players(i).PlayerRotationNumber -= 1
                    selectedPlayerNewRotationNumber = AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players(i).PlayerRotationNumber
                End If

            Next



            For i = 0 To AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players.Count - 1

                If selectedPlayerNewRotationNumber = AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players(i).PlayerRotationNumber Then

                    If Not selectedPlayerName = AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players(i).ToString Then
                        AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players(i).PlayerRotationNumber += 1
                    End If

                End If


            Next

            SortlstvwRotations()
        End If
    End Sub

    Private Sub btnDown_Click(sender As Object, e As RoutedEventArgs)
        If lstvwRotation.SelectedIndex < lstvwRotation.Items.Count - 1 Then


            Dim selectedPlayerNewRotationNumber As Integer = Nothing
            Dim selectedPlayerName As String = lstvwRotation.SelectedValue.ToString

            For i = 0 To AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players.Count - 1

                If selectedPlayerName = AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players(i).ToString Then

                    AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players(i).PlayerRotationNumber += 1
                    selectedPlayerNewRotationNumber = AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players(i).PlayerRotationNumber
                End If

            Next


            For i = 0 To AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players.Count - 1

                If selectedPlayerNewRotationNumber = AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players(i).PlayerRotationNumber Then

                    If Not selectedPlayerName = AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players(i).ToString Then
                        AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players(i).PlayerRotationNumber -= 1
                    End If

                End If


            Next

            SortlstvwRotations()

        End If




    End Sub

    Private Sub btnIncreaseMinutes_Click(sender As Object, e As RoutedEventArgs)

        If lstvwRotation.SelectedIndex < 0 Then
            Exit Sub
        End If

        Dim allMinutes As Integer = 0
        For i = 0 To AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players.Count - 1
            allMinutes += AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players(i).PlayerRotationMinutes
        Next

        Dim selectedPlayerName As String = lstvwRotation.SelectedValue.ToString

        For i = 0 To AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players.Count - 1

            If selectedPlayerName = AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players(i).ToString Then

                If allMinutes < 200 AndAlso AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players(i).PlayerRotationMinutes < 40 Then
                    AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players(i).PlayerRotationMinutes += 1
                    AllRemainingMinutes.RemainingMinutes(0).RotationRemainingMinutes -= 1
                End If

            End If

        Next

    End Sub

    Private Sub btnDecreaseMinutes_Click(sender As Object, e As RoutedEventArgs)
        If lstvwRotation.SelectedIndex < 0 Then
            Exit Sub
        End If

        For i = 0 To AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players.Count - 1
        Next

        Dim selectedPlayerName As String = lstvwRotation.SelectedValue.ToString

        For i = 0 To AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players.Count - 1

            If selectedPlayerName = AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players(i).ToString Then

                If AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players(i).PlayerRotationMinutes > 0 Then
                    AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players(i).PlayerRotationMinutes -= 1
                    AllRemainingMinutes.RemainingMinutes(0).RotationRemainingMinutes += 1
                End If

            End If

        Next
    End Sub






    Private Sub btnBuyPlayer_Click(sender As Object, e As RoutedEventArgs)

        If AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players.Count >= 15 Then

            MsgBox("Der Kader hat bereits 15 Spieler.")
            Exit Sub
        End If

        Dim w As New BuyPlayerWindow
        w.Show()

    End Sub

    Private Sub btnReleasePlayer_Click(sender As Object, e As RoutedEventArgs)

        Dim selectedPlayerName As String
        Dim selectedPlayerRotationNumber As Integer = Nothing

        Try
            selectedPlayerName = lstvwRotation.SelectedItem.ToString
        Catch
            Exit Sub 'no item selected
        End Try

        Dim result As MessageBoxResult = MsgBox(selectedPlayerName & _
                                                " wirklich entlassen? (Das Gehalt muss weiter gezahlt werden!)", _
                                                MsgBoxStyle.YesNoCancel)

        If result = MessageBoxResult.Yes Then

            For i = 0 To AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players.Count - 1

                If selectedPlayerName = AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players(i).ToString Then

                    selectedPlayerRotationNumber = AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players(i).PlayerRotationNumber

                    AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamAdditionalSalary += _
                        AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players(i).PlayerSalary

                    AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players.RemoveAt(i)
                    Exit For
                End If
            Next


            For i = 0 To AllPlayers.Players.Count - 1

                If selectedPlayerName = AllPlayers.Players(i).ToString Then

                    AllPlayers.Players(i).PlayerCurrentTeam = Nothing
                    AllPlayers.Players(i).PlayerSalary = Nothing
                    AllPlayers.Players(i).PlayerContractUntil = Nothing
                    AllPlayers.Players(i).PlayerRotationNumber = Nothing
                    AllPlayers.Players(i).PlayerRotationMinutes = Nothing

                    AvailablePlayers.Players.Add(AllPlayers.Players(i))
                End If
            Next


            For i = 0 To AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players.Count - 1

                If AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players(i).PlayerRotationNumber > selectedPlayerRotationNumber Then

                    AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players(i).PlayerRotationNumber -= 1
                End If
            Next

        End If
    End Sub

    Private Sub btnReleaseCoach_Click(sender As Object, e As RoutedEventArgs)

        If btnReleaseCoach.Content = "Trainer entlassen" Then

            Dim result As MessageBoxResult = MsgBox(AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamCoach.ToString & _
                                                    " wirklich entlassen? (Das Gehalt muss weiter gezahlt werden!)", _
                                                    MsgBoxStyle.YesNoCancel)

            If result = MessageBoxResult.Yes Then

                For i = 0 To AllCoaches.Coaches.Count - 1

                    If AllCoaches.Coaches(i).ToString = AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamCoach.ToString Then

                        AllCoaches.Coaches(i).CoachSalary = Nothing
                        AvailableCoaches.Coaches.Add(AllCoaches.Coaches(i))

                    End If
                Next

                AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamAdditionalSalary += AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamCoach.CoachSalary

                AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamCoach = New Coach


                stckpnCoach.DataContext = Nothing
                stckpnCoach.DataContext = AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamCoach

                stckpnCoach.Visibility = Visibility.Collapsed

            End If

        Else
            'new window SignCoachWindow

            Dim w As New SignCoachWindow
            w.Show()


        End If
    End Sub

    Private Sub btnTransferNegotiations_Click(sender As Object, e As RoutedEventArgs)
        'new window TransferNegotiationsWindow

        Dim w As New TransferNegotiationsWindow
        w.Show()

    End Sub




    Private Sub btnNextDay_Click(sender As Object, e As RoutedEventArgs)

        'msgbox if currentteam has games today
        For i = 0 To AllDaysOfPlay.DaysOfPlay.Count - 1

            If AllDaysOfPlay.DaysOfPlay(i).DayOfPlayActualDate = AllPublicProperties.PublicPropertyCurrentDate Then

                For j = 0 To AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games.Count - 1

                    If AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.ToString = AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamName Or _
                        AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.ToString = AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamName Then

                        Dim result As MsgBoxResult = MsgBox("Die " & AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamName _
                                                            & " haben heute ein Spiel. Simulation fortfahren?", _
                                                            MsgBoxStyle.YesNoCancel)

                        If Not result = MsgBoxResult.Yes Then
                            Exit Sub
                        End If

                        If CheckSimuulateGamesRequirements() = False Then
                            Exit Sub
                        End If
                    End If
                Next
            End If
        Next

        'simulate all games
        Dim currentDayOfPlayIndex As Integer = Nothing
        For i = 0 To AllDaysOfPlay.DaysOfPlay.Count - 1
            If AllDaysOfPlay.DaysOfPlay(i).DayOfPlayActualDate = AllPublicProperties.PublicPropertyCurrentDate Then

                currentDayOfPlayIndex = i
            End If
        Next

        For i = 0 To AllDaysOfPlay.DaysOfPlay(currentDayOfPlayIndex).DayOfPlayGames.Games.Count - 1

            AllDaysOfPlay.DaysOfPlay(currentDayOfPlayIndex).DayOfPlayGames.Games(i).GameTotalScore.ScoreHome = New PlayersScore( _
                AllDaysOfPlay.DaysOfPlay(currentDayOfPlayIndex).DayOfPlayGames.Games(i).GameOpponentHome.TeamPlayers)
            AllDaysOfPlay.DaysOfPlay(currentDayOfPlayIndex).DayOfPlayGames.Games(i).GameTotalScore.ScoreGuest = New PlayersScore( _
                AllDaysOfPlay.DaysOfPlay(currentDayOfPlayIndex).DayOfPlayGames.Games(i).GameOpponentGuest.TeamPlayers)

        Next

        'do transfers


        For i = 0 To AllOffers.Offers.Count - 1

            Dim currentPlayer As Player = Nothing

            For j = 0 To AllPlayers.Players.Count - 1

                If AllPlayers.Players(j).ToString = AllOffers.Offers(i).OfferPlayerName Then
                    currentPlayer = AllPlayers.Players(j)
                End If
            Next


            Dim playerIsOnCurrentTeam As Boolean = False
            For j = 0 To AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players.Count - 1

                If AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players(j).ToString = currentPlayer.ToString Then
                    playerIsOnCurrentTeam = True
                End If
            Next



            If CheckIfOfferShouldBeDealtWith(AllOffers.Offers(i).OfferLastDealtDate) = True Then

                'deal with offer
                'TODO: simulate transfers between ui teams
                Select Case AllOffers.Offers(i).OfferStatus
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

                    Case 0
                        If playerIsOnCurrentTeam = True Then
                            Exit Select
                        End If
                        If AllOffers.Offers(i).OfferRedemption > 0 Then

                            If CheckRedemption(currentPlayer.PlayerRating, AllOffers.Offers(i).OfferRedemption) = True Then
                                AllOffers.Offers(i).OfferStatus = 2
                            Else
                                AllOffers.Offers(i).OfferStatus = 1
                            End If
                        Else
                            If CheckSalary(currentPlayer.PlayerRating, AllOffers.Offers(i).OfferSalary) = True Then
                                AllOffers.Offers(i).OfferStatus = 4
                            Else
                                AllOffers.Offers(i).OfferStatus = 3
                            End If
                        End If
                        UpdateOfferLastDealtDate(i)
                        SendEmail(AllOffers.Offers(i).OfferCurrentTeamName, AllOffers.Offers(i).OfferStatus, AllOffers.Offers(i))
                    Case 2
                        If CheckSalary(currentPlayer.PlayerRating, AllOffers.Offers(i).OfferSalary) = True Then
                            AllOffers.Offers(i).OfferStatus = 4
                        Else
                            AllOffers.Offers(i).OfferStatus = 3
                        End If
                        UpdateOfferLastDealtDate(i)
                        SendEmail(AllOffers.Offers(i).OfferCurrentTeamName, AllOffers.Offers(i).OfferStatus, AllOffers.Offers(i))
                End Select

            End If

        Next

        

        Dim gamesToday As Boolean = False
        Dim gamesTomorrow As Boolean = False

        For i = 0 To AllDaysOfPlay.DaysOfPlay.Count - 1

            If AllDaysOfPlay.DaysOfPlay(i).DayOfPlayActualDate = AllPublicProperties.PublicPropertyCurrentDate Then

                lstbxGamesToday.DataContext = AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames
                gamesToday = True
            End If
            If AllDaysOfPlay.DaysOfPlay(i).DayOfPlayActualDate = AllPublicProperties.PublicPropertyCurrentDate.AddDays(1) Then

                lstbxGamesToday.DataContext = AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames
                gamesTomorrow = True
            End If
        Next



        If gamesTomorrow = True Then
            For i = 0 To AllDaysOfPlay.DaysOfPlay.Count - 1

                If AllDaysOfPlay.DaysOfPlay(i).DayOfPlayActualDate = AllPublicProperties.PublicPropertyCurrentDate.AddDays(1) Then

                    lstbxGamesToday.DataContext = AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames
                End If
            Next
        Else
            lstbxGamesToday.DataContext = Nothing
        End If



        'next day
        AllPublicProperties.PublicPropertyCurrentDate = AllPublicProperties.PublicPropertyCurrentDate.AddDays(1)

        If gamesToday = True Then
            Dim w As New ResultsWindow
            w.Show()
        End If



    End Sub

#Region "CheckSimulateGameRequirements"
    Private Function CheckSimuulateGamesRequirements() As Boolean

        If AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamCoach.CoachLastName = Nothing Then
            MsgBox("Deine Mannschaft kann ohne Trainer nicht antreten!")
            Return False
        ElseIf Not AllRemainingMinutes.RemainingMinutes(0).RotationRemainingMinutes = 0 Then
            MsgBox("Du musst alle verbleibenden Minuten deiner Rotation vergeben!")
            Return False
        ElseIf GetNumberOfPlayersWithMinutes() >= 12 Then
            MsgBox("Es dürfen maximal 12 Spieler deiner Mannschaft in der Rotation stehen!")
            Return False
        ElseIf GetNumberOfGermanPlayers() < 6 Then
            MsgBox("Es müssen mindesten 6 Spieler in deiner Rotation Deutsche sein!")
            Return False
        ElseIf CheckIfStaringFiveHasMinutes() = False Then
            MsgBox("Jeder Spieler deiner Starting 5 muss in der Rotation stehen!")
            Return False
        End If
        Return True
    End Function

    Private Function CheckIfStaringFiveHasMinutes() As Boolean
        For i = 0 To AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players.Count - 1

            If AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players(i).PlayerRotationNumber <= 5 Then

                If AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players(i).PlayerRotationMinutes = 0 Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Private Function GetNumberOfGermanPlayers() As Integer
        Dim count As Integer = 0
        For i = 0 To AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players.Count - 1

            If AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players(i).PlayerRotationNumber <= 12 Then
                If AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players(i).PlayerNationality = "Deutschland" Then
                    count += 1
                End If
            End If
        Next
        Return count
    End Function

    Private Function GetNumberOfPlayersWithMinutes() As Integer
        Dim count As Integer = 0
        For i = 0 To AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players.Count - 1

            If AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players(i).PlayerRotationMinutes > 0 Then
                count += 1
            End If
        Next
        Return count
    End Function
#End Region

    Private Sub UpdateOfferLastDealtDate(ByVal offerIndex As Integer)

        AllOffers.Offers(offerIndex).OfferLastDealtDate = AllPublicProperties.PublicPropertyCurrentDate

    End Sub

    Private Function CheckIfOfferShouldBeDealtWith(ByVal lastDealtDate As Date) As Boolean
        Dim difference As Long = DateDiff("d", lastDealtDate, AllPublicProperties.PublicPropertyCurrentDate)
        Select Case difference
            Case 0 To 1
                Return False
            Case 2 To 6
                Const max As Single = 1
                If CInt(Math.Ceiling(Rnd() * max)) = 0 Then 'from 0 to 1
                    Return True
                Else
                    Return False
                End If
            Case Else
                Return True
        End Select
    End Function


    Private Sub btnNewEmails_Click(sender As Object, e As RoutedEventArgs)

        Dim w As New EmailsWindow
        w.Show()
    End Sub
End Class

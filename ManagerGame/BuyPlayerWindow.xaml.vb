' ReSharper disable once CheckNamespace
Public Class BuyPlayerWindow

    Dim _playerName As String
    Dim _playerIndex As Integer

    Private Sub BuyPlayerWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded


        lstvwPlayers.DataContext = AllPlayers
        cmbbxChooseSelection.SelectedIndex = 0

        btnStartTransfer.DataContext = lstvwPlayers

        lblName.DataContext = lstvwPlayers

        txtbxRedemptionValue.DataContext = sldrRedemption
        txtbxSalaryValue.DataContext = sldrSalary

    End Sub

    Private Sub cmbbxitemAllPlayers_Selected(sender As Object, e As RoutedEventArgs)

        lstvwPlayers.DataContext = AllPlayers
    End Sub

    Private Sub cmbbxitemAvailablePlayers_Selected(sender As Object, e As RoutedEventArgs) Handles cmbbxitemAvailablePlayers.Selected

        lstvwPlayers.DataContext = AvailablePlayers
    End Sub


    Private Sub btnStartTransfer_Click(sender As Object, e As RoutedEventArgs)

        sldrRedemption.Value = 0
        sldrSalary.Value = 0

        _playerName = lstvwPlayers.SelectedItem.ToString

        For i = 0 To AllPlayers.Players.Count - 1

            If _playerName = AllPlayers.Players(i).ToString Then

                _playerIndex = i

                If AllPlayers.Players(i).PlayerCurrentTeam = Nothing Then

                    lblStatus.DataContext = "vertragslos"
                    stckpnlRedemption.IsEnabled = False
                Else
                    lblStatus.DataContext = "Vertrag bis " & AllPlayers.Players(i).PlayerContractUntil
                    stckpnlRedemption.IsEnabled = True
                End If
            End If

        Next


        For i = 0 To AllTeams.Teams(CurrentTeamIndex).TeamPlayers.Players.Count - 1

            If _playerName = AllTeams.Teams(CurrentTeamIndex).TeamPlayers.Players(i).ToString Then

                MsgBox(_playerName & " ist bereits bei den " & AllTeams.Teams(CurrentTeamIndex).TeamName & "!")
                Exit Sub
            End If
        Next

        For i = 0 To AllPlayers.Players(_playerIndex).PlayerOffers.Offers.Count - 1

            If AllPlayers.Players(_playerIndex).PlayerOffers.Offers(i).OfferBiddingTeam = AllTeams.Teams(CurrentTeamIndex).TeamName Then

                If Not AllPlayers.Players(_playerIndex).PlayerOffers.Offers(i).OfferStatus = 6 Then
                    MsgBox("Die " & AllTeams.Teams(CurrentTeamIndex).TeamName & " haben " & _
                           _playerName & " bereits ein Angebot unterbreitet!")
                    Exit Sub
                End If

            End If
        Next

        grdRow1.IsEnabled = False
        grdRow2.IsEnabled = False

        grdRow3.Visibility = Visibility.Visible

    End Sub

    Private Sub btnBack_Click(sender As Object, e As RoutedEventArgs)

        grdRow1.IsEnabled = True
        grdRow2.IsEnabled = True

        grdRow3.Visibility = Visibility.Hidden

    End Sub



    Private Sub btnMakeOffer_Click(sender As Object, e As RoutedEventArgs)

        If txtbxContractUntil.Text = Nothing Then
            MsgBox("Vertragsdauer angeben!")
            Exit Sub
        End If

        Dim contractUntil As Integer
        Try
            contractUntil = CInt(txtbxContractUntil.Text)
        Catch
            MsgBox("Vertragsdauer als Jahr angeben")
            Exit Sub
        End Try

        If Not contractUntil > AllPublicProperties.PublicPropertyCurrentDate.Year Or Not contractUntil < (AllPublicProperties.PublicPropertyCurrentDate.Year + 6) Then
            MsgBox("Vertragsdauer mind. 1 Jahr und max. 5 Jahre")
            Exit Sub
        End If


        Dim playerTeamName As String = Nothing

        For i = 0 To AllTeams.Teams.Count - 1

            For j = 0 To AllTeams.Teams(i).TeamPlayers.Players.Count - 1

                If _playerName = AllTeams.Teams(i).TeamPlayers.Players(j).ToString Then

                    playerTeamName = AllTeams.Teams(i).TeamName
                End If
            Next
        Next

        Dim newOffer As New Offer(_playerName, playerTeamName, AllPublicProperties.PublicPropertyCurrentDate, AllPublicProperties.PublicPropertyCurrentDate, txtbxRedemptionValue.Text, _
                               txtbxSalaryValue.Text, AllTeams.Teams(CurrentTeamIndex).TeamName, _
                               contractUntil, 0)

        AllPlayers.Players(_playerIndex).PlayerOffers.Offers.Add(newOffer)

        For i = 0 To AllTeams.Teams(CurrentTeamIndex).TeamPlayers.Players.Count - 1

            If _playerName = AllTeams.Teams(CurrentTeamIndex).TeamPlayers.Players(i).ToString Then
                AllTeams.Teams(CurrentTeamIndex).TeamPlayers.Players(i).PlayerOffers.Offers.Add(newOffer)
            End If

        Next


        If Not AllPlayersWithOffers.Players.Contains(AllPlayers.Players(_playerIndex)) Then

            AllPlayersWithOffers.Players.Add(AllPlayers.Players(_playerIndex))
        End If

        AllOffers.Offers.Add(newOffer)


        MsgBox("Das Angebot wurde erfolgreich versendet.")

        grdRow1.IsEnabled = True
        grdRow2.IsEnabled = True
        grdRow3.Visibility = Visibility.Hidden
    End Sub


End Class

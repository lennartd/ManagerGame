' ReSharper disable once CheckNamespace
Public Class TransferNegotiationsWindow

    Dim _allCurrentTeamOffers As OffersList

    Dim _selectedPlayerName As String
    Dim _selectedPlayerIndex As Integer

    Private Sub TransferNegotiationsWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded

        _allCurrentTeamOffers = New OffersList

        For i = 0 To AllOffers.Offers.Count - 1

            If AllOffers.Offers(i).OfferBiddingTeam = AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamName Then

                _allCurrentTeamOffers.Offers.Add(AllOffers.Offers(i))
            Else

                For j = 0 To AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players.Count - 1

                    If AllOffers.Offers(i).OfferPlayerName = AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamPlayers.Players(j).ToString Then

                        _allCurrentTeamOffers.Offers.Add(AllOffers.Offers(i))
                    End If
                Next

            End If
        Next

        lstvwPlayers.DataContext = _allCurrentTeamOffers

        stckpnlWorkOntransfers.DataContext = lstvwPlayers
    End Sub

    Private Sub lstvwPlayers_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles lstvwPlayers.SelectionChanged

        Try
            _selectedPlayerName = lstvwPlayers.SelectedItem.ToString
        Catch
            Exit Sub
        End Try

        For i = 0 To _allCurrentTeamOffers.Offers.Count - 1

            If _selectedPlayerName = _allCurrentTeamOffers.Offers(i).OfferPlayerName Then

                _selectedPlayerIndex = i
                Exit For
            End If
        Next

        Dim methodsListArray() As List(Of String) = GetTransferMethods(_allCurrentTeamOffers.Offers(_selectedPlayerIndex).OfferStatus)

        If _allCurrentTeamOffers.Offers(_selectedPlayerIndex).OfferCurrentTeamName = AllTeams.Teams(AllPublicProperties.PublicPropertyCurrentTeamIndex).TeamName Then
            cmbbxSelectMethods.DataContext = methodsListArray(1)
        Else
            cmbbxSelectMethods.DataContext = methodsListArray(0)

        End If



    End Sub

    Private Sub btnSend_Click(sender As Object, e As RoutedEventArgs)

        If cmbbxSelectMethods.SelectedIndex = -1 Then
            MsgBox("Methode auswählen!")
            Exit Sub
        End If

        Dim methodText As String = cmbbxSelectMethods.SelectedItem.ToString

        Dim newValue As Integer
        If Not txtbxNewValue.Text = Nothing Then
            Try
                newValue = CInt(txtbxNewValue.Text)
            Catch
                MsgBox("Der Wert der Textbox muss eine Zahl sein!")
                Exit Sub
            End Try
            If newValue < 500 Then
                MsgBox("Der Wert der Textbox ist zu klein.")
                Exit Sub
            End If
        End If


        Dim offerStatus As Integer = _allCurrentTeamOffers.Offers(_selectedPlayerIndex).OfferStatus
        Dim allOffersIndex As Integer = Nothing

        For i = 0 To AllOffers.Offers.Count - 1
            If _selectedPlayerName = AllOffers.Offers(i).OfferPlayerName Then
                allOffersIndex = i
            End If
        Next

        Dim biddingTeam As String = _allCurrentTeamOffers.Offers(_selectedPlayerIndex).OfferBiddingTeam
        Dim currentTeam As String = _allCurrentTeamOffers.Offers(_selectedPlayerIndex).OfferCurrentTeamName

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


        Select Case offerStatus

            Case 0
                If methodText = "Angebot zurückziehen" Then
                    _allCurrentTeamOffers.Offers(_selectedPlayerIndex).OfferStatus = 6
                    AllOffers.Offers(allOffersIndex).OfferStatus = 6
                ElseIf methodText = "Ablösesumme zustimmen" Then
                    _allCurrentTeamOffers.Offers(_selectedPlayerIndex).OfferStatus = 2
                    AllOffers.Offers(allOffersIndex).OfferStatus = 2
                ElseIf methodText = "Höhere Ablösesumme fordern" Then
                    _allCurrentTeamOffers.Offers(_selectedPlayerIndex).OfferStatus = 1
                    AllOffers.Offers(allOffersIndex).OfferStatus = 1
                ElseIf methodText = "Transfer ablehnen" Then
                    _allCurrentTeamOffers.Offers(_selectedPlayerIndex).OfferStatus = 6
                    AllOffers.Offers(allOffersIndex).OfferStatus = 6
                End If
            Case 1
                If methodText = "Angebot zurückziehen" Then
                    _allCurrentTeamOffers.Offers(_selectedPlayerIndex).OfferStatus = 6
                    AllOffers.Offers(allOffersIndex).OfferStatus = 6
                ElseIf methodText = "Ablösesumme erhöhen" Then
                    _allCurrentTeamOffers.Offers(_selectedPlayerIndex).OfferStatus = 0
                    AllOffers.Offers(allOffersIndex).OfferStatus = 0
                    _allCurrentTeamOffers.Offers(_selectedPlayerIndex).OfferRedemption = txtbxNewValue.Text
                    AllOffers.Offers(allOffersIndex).OfferRedemption = txtbxNewValue.Text
                ElseIf methodText = "Transfer ablehnen" Then
                    _allCurrentTeamOffers.Offers(_selectedPlayerIndex).OfferStatus = 6
                    AllOffers.Offers(allOffersIndex).OfferStatus = 6
                End If
            Case 2
                If methodText = "Angebot zurückziehen" Then
                    _allCurrentTeamOffers.Offers(_selectedPlayerIndex).OfferStatus = 6
                    AllOffers.Offers(allOffersIndex).OfferStatus = 6
                End If
            Case 3
                If methodText = "Gehalt erhöhen" Then
                    _allCurrentTeamOffers.Offers(_selectedPlayerIndex).OfferStatus = 2
                    AllOffers.Offers(allOffersIndex).OfferStatus = 2
                    _allCurrentTeamOffers.Offers(_selectedPlayerIndex).OfferSalary = txtbxNewValue.Text
                    AllOffers.Offers(allOffersIndex).OfferSalary = txtbxNewValue.Text
                ElseIf methodText = "Angebot zurückziehen" Then
                    _allCurrentTeamOffers.Offers(_selectedPlayerIndex).OfferStatus = 6
                    AllOffers.Offers(allOffersIndex).OfferStatus = 6
                End If
            Case 4
                If methodText = "Transfer zustimmen" Then
                    For i = 0 To AllTeams.Teams.Count - 1
                        If currentTeam = AllTeams.Teams(i).TeamName Then
                            For j = 0 To AllTeams.Teams(i).TeamPlayers.Players.Count - 1
                                If _selectedPlayerName = AllTeams.Teams(i).TeamPlayers.Players(j).ToString Then
                                    AllTeams.Teams(i).TeamPlayers.Players.RemoveAt(j)
                                End If
                            Next
                            AllTeams.Teams(i).TeamMoney += _allCurrentTeamOffers.Offers(_selectedPlayerIndex).OfferRedemption
                        ElseIf biddingTeam = AllTeams.Teams(i).TeamName Then
                            For j = 0 To AllPlayers.Players.Count - 1
                                If _selectedPlayerName = AllPlayers.Players(j).ToString Then

                                    AllPlayers.Players(j).PlayerContractUntil = _allCurrentTeamOffers.Offers(_selectedPlayerIndex).OfferContractUntil
                                    AllPlayers.Players(j).PlayerCurrentTeam = _allCurrentTeamOffers.Offers(_selectedPlayerIndex).OfferBiddingTeam
                                    AllPlayers.Players(j).PlayerRotationMinutes = 0
                                    Dim maxRotationNumber As Integer = 0
                                    For k = 0 To AllTeams.Teams(i).TeamPlayers.Players.Count - 1
                                        If AllTeams.Teams(i).TeamPlayers.Players(k).PlayerRotationNumber > maxRotationNumber Then
                                            maxRotationNumber = AllTeams.Teams(i).TeamPlayers.Players(k).PlayerRotationNumber
                                        End If
                                    Next
                                    AllPlayers.Players(j).PlayerRotationNumber = (maxRotationNumber + 1)
                                    AllPlayers.Players(j).PlayerSalary = _allCurrentTeamOffers.Offers(_selectedPlayerIndex).OfferSalary

                                    AllTeams.Teams(i).TeamPlayers.Players.Add(AllPlayers.Players(j))
                                    AllTeams.Teams(i).TeamMoney -= _allCurrentTeamOffers.Offers(_selectedPlayerIndex).OfferRedemption
                                End If
                            Next
                        End If
                    Next
                    _allCurrentTeamOffers.Offers(_selectedPlayerIndex).OfferStatus = 5
                    AllOffers.Offers(allOffersIndex).OfferStatus = 5
                ElseIf methodText = "Angebot zurückziehen" Then
                    _allCurrentTeamOffers.Offers(_selectedPlayerIndex).OfferStatus = 6
                    AllOffers.Offers(allOffersIndex).OfferStatus = 6
                End If

        End Select

        _allCurrentTeamOffers.Offers(_selectedPlayerIndex).OfferLastDealtDate = AllPublicProperties.PublicPropertyCurrentDate
        AllOffers.Offers(allOffersIndex).OfferLastDealtDate = AllPublicProperties.PublicPropertyCurrentDate

        stckpnlWorkOntransfers.Visibility = Visibility.Hidden

    End Sub
End Class

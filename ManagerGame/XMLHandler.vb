Imports System.Xml

Public Class XmlHandler

    ReadOnly _enc As New Text.UnicodeEncoding
    Dim _xmlwriter As XmlTextWriter

    Public Sub Save(ByVal path As String)

        _xmlwriter = New XmlTextWriter(path, _enc)

        With _xmlwriter

            .WriteStartDocument()

            .WriteStartElement("Data")

            .WriteStartElement("Coaches")

            For i = 0 To AllCoaches.Coaches.Count - 1

                .WriteStartElement("Coach")

                .WriteAttributeString("FirstName", AllCoaches.Coaches(i).CoachFirstName)
                .WriteAttributeString("LastName", AllCoaches.Coaches(i).CoachLastName)
                .WriteAttributeString("Birthday", AllCoaches.Coaches(i).CoachBirthday)
                .WriteAttributeString("Nationality", AllCoaches.Coaches(i).CoachNationality)
                .WriteAttributeString("Rating", AllCoaches.Coaches(i).CoachRating)
                .WriteAttributeString("CurrentTeam", AllCoaches.Coaches(i).CoachCurrentTeam)
                .WriteAttributeString("Salary", AllCoaches.Coaches(i).CoachSalary)

                'offers?

                .WriteEndElement() 'Coach
            Next

            .WriteEndElement() 'Coaches

            .WriteStartElement("DaysOfPlay")

            For i = 0 To AllDaysOfPlay.DaysOfPlay.Count - 1

                .WriteStartElement("DayOfPlay")

                .WriteAttributeString("Number", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayNumber)
                .WriteAttributeString("ActualDate", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayActualDate)
                'games?

                .WriteEndElement() 'DayOfPlay
            Next

            .WriteEndElement() 'DaysOfPlay

            .WriteStartElement("Emails")

            For i = 0 To AllEmails.Emails.Count - 1

                .WriteStartElement("Email")

                .WriteAttributeString("Date", AllEmails.Emails(i).EmailDate)
                .WriteAttributeString("From", AllEmails.Emails(i).EmailFrom)
                .WriteAttributeString("Subject", AllEmails.Emails(i).EmailSubject)
                .WriteAttributeString("Content", AllEmails.Emails(i).EmailContent)
                .WriteAttributeString("Read", AllEmails.Emails(i).EmailRead)

                .WriteEndElement() 'Email
            Next

            .WriteEndElement() 'Emails

            .WriteStartElement("Games")

            For i = 0 To AllGames.Games.Count - 1

                .WriteStartElement("Game")

                'opponenthome
                'opponentguest
                'totalscore

                .WriteEndElement() 'Game
            Next

            .WriteEndElement() 'Games

            .WriteStartElement("Offers")

            For i = 0 To AllOffers.Offers.Count - 1

                .WriteStartElement("Offer")

                .WriteAttributeString("PlayerName", AllOffers.Offers(i).OfferPlayerName)
                .WriteAttributeString("CurrentTeamName", AllOffers.Offers(i).OfferCurrentTeamName)
                .WriteAttributeString("MadeDate", AllOffers.Offers(i).OfferMadeDate)
                .WriteAttributeString("LastDealtDate", AllOffers.Offers(i).OfferLastDealtDate)
                .WriteAttributeString("Redemption", AllOffers.Offers(i).OfferRedemption)
                .WriteAttributeString("Salary", AllOffers.Offers(i).OfferSalary)
                .WriteAttributeString("BiddingTeam", AllOffers.Offers(i).OfferBiddingTeam)
                .WriteAttributeString("ContractUntil", AllOffers.Offers(i).OfferContractUntil)
                .WriteAttributeString("Status", AllOffers.Offers(i).OfferStatus)

                .WriteEndElement() 'Offer
            Next

            .WriteEndElement() 'Offers

            .WriteStartElement("Players")

            For i = 0 To AllPlayers.Players.Count - 1

                .WriteStartElement("Player")

                .WriteAttributeString("FirstName", AllPlayers.Players(i).PlayerFirstName)
                .WriteAttributeString("LastName", AllPlayers.Players(i).PlayerLastName)
                .WriteAttributeString("Birthday", AllPlayers.Players(i).PlayerBirthday)
                .WriteAttributeString("Nationality", AllPlayers.Players(i).PlayerNationality)
                .WriteAttributeString("Size", AllPlayers.Players(i).PlayerSize)
                .WriteAttributeString("Weight", AllPlayers.Players(i).PlayerWeight)
                .WriteAttributeString("Position", AllPlayers.Players(i).PlayerPosition)
                .WriteAttributeString("SecondPosition", AllPlayers.Players(i).PlayerSecondPosition)
                .WriteAttributeString("Rating", AllPlayers.Players(i).PlayerRating)
                .WriteAttributeString("CurrentTeam", AllPlayers.Players(i).PlayerCurrentTeam)
                .WriteAttributeString("Salary", AllPlayers.Players(i).PlayerSalary)
                .WriteAttributeString("ContractUntil", AllPlayers.Players(i).PlayerContractUntil)
                .WriteAttributeString("RotationNumber", AllPlayers.Players(i).PlayerRotationNumber)
                .WriteAttributeString("RotationMinutes", AllPlayers.Players(i).PlayerRotationMinutes)
                .WriteAttributeString("PointsLastGame", AllPlayers.Players(i).PlayerPointsLastGame)
                'Offers

                .WriteEndElement() 'Player
            Next

            .WriteEndElement() 'Players

            .WriteStartElement("Teams")

            For i = 0 To AllTeams.Teams.Count - 1

                .WriteStartElement("Team")

                .WriteAttributeString("", AllTeams.Teams(i).TeamName)
                .WriteAttributeString("", AllTeams.Teams(i).TeamMoney)
                .WriteAttributeString("", AllTeams.Teams(i).TeamWins)
                .WriteAttributeString("", AllTeams.Teams(i).TeamLosses)
                .WriteAttributeString("", AllTeams.Teams(i).TeamAdditionalSalary)
                'Players
                'Coach

                .WriteEndElement() 'Team
            Next

            .WriteEndElement() 'Teams

            .WriteEndElement() 'Data

            .Close()
        End With

    End Sub


    Public Sub Load()
        Throw New NotImplementedException
    End Sub





End Class

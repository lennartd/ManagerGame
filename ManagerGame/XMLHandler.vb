Imports System.Xml

Public Class XmlHandler

    ReadOnly _enc As New Text.UnicodeEncoding
    Dim _xmlwriter As XmlTextWriter

    Public Sub Save(ByVal path As String)

        _xmlwriter = New XmlTextWriter(path, _enc)

        With _xmlwriter

            .WriteStartDocument()

            .WriteStartElement("Data")

            '-----------------------------------------------------------------------------------
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

                .WriteStartElement("Offers")

                For j = 0 To AllCoaches.Coaches(i).CoachOffers.Offers.Count - 1

                    .WriteStartElement("Offer")

                    .WriteAttributeString("PlayerName", AllCoaches.Coaches(i).CoachOffers.Offers(j).OfferPlayerName)
                    .WriteAttributeString("CurrentTeamName", AllCoaches.Coaches(i).CoachOffers.Offers(j).OfferCurrentTeamName)
                    .WriteAttributeString("MadeDate", AllCoaches.Coaches(i).CoachOffers.Offers(j).OfferMadeDate)
                    .WriteAttributeString("LastDealtDate", AllCoaches.Coaches(i).CoachOffers.Offers(j).OfferLastDealtDate)
                    .WriteAttributeString("Redemption", AllCoaches.Coaches(i).CoachOffers.Offers(j).OfferRedemption)
                    .WriteAttributeString("Salary", AllCoaches.Coaches(i).CoachOffers.Offers(j).OfferSalary)
                    .WriteAttributeString("BiddingTeam", AllCoaches.Coaches(i).CoachOffers.Offers(j).OfferBiddingTeam)
                    .WriteAttributeString("ContractUntil", AllCoaches.Coaches(i).CoachOffers.Offers(j).OfferContractUntil)
                    .WriteAttributeString("Status", AllCoaches.Coaches(i).CoachOffers.Offers(j).OfferStatus)

                    .WriteEndElement() 'Offer
                Next


            .WriteEndElement() 'Offers

            .WriteEndElement() 'Coach
            Next

            .WriteEndElement() 'Coaches
            '----------------------------------------------------------------------------------------------------------
            .WriteStartElement("DaysOfPlay")

            For i = 0 To AllDaysOfPlay.DaysOfPlay.Count - 1

                .WriteStartElement("DayOfPlay")

                .WriteAttributeString("Number", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayNumber)
                .WriteAttributeString("ActualDate", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayActualDate)

                .WriteStartElement("Games")

                For j = 0 To AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games.Count - 1

                    .WriteStartElement("Game")

                    .WriteStartElement("OpponentHome")


                    .WriteAttributeString("Name", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamName)
                    .WriteAttributeString("Money", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamMoney)
                    .WriteAttributeString("Wins", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamWins)
                    .WriteAttributeString("Losses", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamLosses)
                    .WriteAttributeString("AdditionalSalary", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamAdditionalSalary)

                    .WriteStartElement("Players")

                    For k = 0 To AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamPlayers.Players.Count - 1

                        .WriteStartElement("Player")

                        .WriteAttributeString("FirstName", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamPlayers.Players(k).PlayerFirstName)
                        .WriteAttributeString("LastName", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamPlayers.Players(k).PlayerLastName)
                        .WriteAttributeString("Birthday", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamPlayers.Players(k).PlayerBirthday)
                        .WriteAttributeString("Nationality", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamPlayers.Players(k).PlayerNationality)
                        .WriteAttributeString("Size", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamPlayers.Players(k).PlayerSize)
                        .WriteAttributeString("Weight", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamPlayers.Players(k).PlayerWeight)
                        .WriteAttributeString("Position", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamPlayers.Players(k).PlayerPosition)
                        .WriteAttributeString("SecondPosition", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamPlayers.Players(k).PlayerSecondPosition)
                        .WriteAttributeString("Rating", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamPlayers.Players(k).PlayerRating)
                        .WriteAttributeString("CurrentTeam", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamPlayers.Players(k).PlayerCurrentTeam)
                        .WriteAttributeString("Salary", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamPlayers.Players(k).PlayerSalary)
                        .WriteAttributeString("ContractUntil", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamPlayers.Players(k).PlayerContractUntil)
                        .WriteAttributeString("RotationNumber", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamPlayers.Players(k).PlayerRotationNumber)
                        .WriteAttributeString("RotationMinutes", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamPlayers.Players(k).PlayerRotationMinutes)
                        .WriteAttributeString("PointsLastGame", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamPlayers.Players(k).PlayerPointsLastGame)

                        .WriteStartElement("Offers")

                        For l = 0 To AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamPlayers.Players(k).PlayerOffers.Offers.Count - 1

                            .WriteStartElement("Offer")

                            .WriteAttributeString("PlayerName", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamPlayers.Players(k).PlayerOffers.Offers(l).OfferPlayerName)
                            .WriteAttributeString("CurrentTeamName", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamPlayers.Players(k).PlayerOffers.Offers(l).OfferCurrentTeamName)
                            .WriteAttributeString("MadeDate", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamPlayers.Players(k).PlayerOffers.Offers(l).OfferMadeDate)
                            .WriteAttributeString("LastDealtDate", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamPlayers.Players(k).PlayerOffers.Offers(l).OfferLastDealtDate)
                            .WriteAttributeString("Redemption", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamPlayers.Players(k).PlayerOffers.Offers(l).OfferRedemption)
                            .WriteAttributeString("Salary", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamPlayers.Players(k).PlayerOffers.Offers(l).OfferSalary)
                            .WriteAttributeString("BiddingTeam", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamPlayers.Players(k).PlayerOffers.Offers(l).OfferBiddingTeam)
                            .WriteAttributeString("ContractUntil", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamPlayers.Players(k).PlayerOffers.Offers(l).OfferContractUntil)
                            .WriteAttributeString("Status", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamPlayers.Players(k).PlayerOffers.Offers(l).OfferStatus)

                            .WriteEndElement() 'Offer
                        Next

                        .WriteEndElement() 'Offers

                        .WriteEndElement() 'Player
                    Next

                    .WriteEndElement() 'Players

                    .WriteStartElement("Coach")

                    .WriteAttributeString("FirstName", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamCoach.CoachFirstName)
                    .WriteAttributeString("LastName", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamCoach.CoachLastName)
                    .WriteAttributeString("Birthday", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamCoach.CoachBirthday)
                    .WriteAttributeString("Nationality", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamCoach.CoachNationality)
                    .WriteAttributeString("Rating", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamCoach.CoachRating)
                    .WriteAttributeString("CurrentTeam", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamCoach.CoachCurrentTeam)
                    .WriteAttributeString("Salary", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamCoach.CoachSalary)

                    .WriteStartElement("Offers")

                    For k = 0 To AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamCoach.CoachOffers.Offers.Count - 1

                        .WriteStartElement("Offer")

                        .WriteAttributeString("PlayerName", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamCoach.CoachOffers.Offers(k).OfferPlayerName)
                        .WriteAttributeString("CurrentTeamName", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamCoach.CoachOffers.Offers(k).OfferCurrentTeamName)
                        .WriteAttributeString("MadeDate", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamCoach.CoachOffers.Offers(k).OfferMadeDate)
                        .WriteAttributeString("LastDealtDate", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamCoach.CoachOffers.Offers(k).OfferLastDealtDate)
                        .WriteAttributeString("Redemption", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamCoach.CoachOffers.Offers(k).OfferRedemption)
                        .WriteAttributeString("Salary", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamCoach.CoachOffers.Offers(k).OfferSalary)
                        .WriteAttributeString("BiddingTeam", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamCoach.CoachOffers.Offers(k).OfferBiddingTeam)
                        .WriteAttributeString("ContractUntil", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamCoach.CoachOffers.Offers(k).OfferContractUntil)
                        .WriteAttributeString("Status", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentHome.TeamCoach.CoachOffers.Offers(k).OfferStatus)

                        .WriteEndElement() 'Offer
                    Next

                    .WriteEndElement() 'Offers

                    .WriteEndElement() 'Coach

                    .WriteEndElement() 'OpponentHome

                    .WriteStartElement("OpponentGuest")


                    .WriteAttributeString("Name", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamName)
                    .WriteAttributeString("Money", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamMoney)
                    .WriteAttributeString("Wins", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamWins)
                    .WriteAttributeString("Losses", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamLosses)
                    .WriteAttributeString("AdditionalSalary", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamAdditionalSalary)

                    .WriteStartElement("Players")

                    For k = 0 To AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamPlayers.Players.Count - 1

                        .WriteStartElement("Player")

                        .WriteAttributeString("FirstName", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamPlayers.Players(k).PlayerFirstName)
                        .WriteAttributeString("LastName", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamPlayers.Players(k).PlayerLastName)
                        .WriteAttributeString("Birthday", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamPlayers.Players(k).PlayerBirthday)
                        .WriteAttributeString("Nationality", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamPlayers.Players(k).PlayerNationality)
                        .WriteAttributeString("Size", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamPlayers.Players(k).PlayerSize)
                        .WriteAttributeString("Weight", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamPlayers.Players(k).PlayerWeight)
                        .WriteAttributeString("Position", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamPlayers.Players(k).PlayerPosition)
                        .WriteAttributeString("SecondPosition", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamPlayers.Players(k).PlayerSecondPosition)
                        .WriteAttributeString("Rating", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamPlayers.Players(k).PlayerRating)
                        .WriteAttributeString("CurrentTeam", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamPlayers.Players(k).PlayerCurrentTeam)
                        .WriteAttributeString("Salary", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamPlayers.Players(k).PlayerSalary)
                        .WriteAttributeString("ContractUntil", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamPlayers.Players(k).PlayerContractUntil)
                        .WriteAttributeString("RotationNumber", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamPlayers.Players(k).PlayerRotationNumber)
                        .WriteAttributeString("RotationMinutes", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamPlayers.Players(k).PlayerRotationMinutes)
                        .WriteAttributeString("PointsLastGame", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamPlayers.Players(k).PlayerPointsLastGame)

                        .WriteStartElement("Offers")

                        For l = 0 To AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamPlayers.Players(k).PlayerOffers.Offers.Count - 1

                            .WriteStartElement("Offer")

                            .WriteAttributeString("PlayerName", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamPlayers.Players(k).PlayerOffers.Offers(l).OfferPlayerName)
                            .WriteAttributeString("CurrentTeamName", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamPlayers.Players(k).PlayerOffers.Offers(l).OfferCurrentTeamName)
                            .WriteAttributeString("MadeDate", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamPlayers.Players(k).PlayerOffers.Offers(l).OfferMadeDate)
                            .WriteAttributeString("LastDealtDate", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamPlayers.Players(k).PlayerOffers.Offers(l).OfferLastDealtDate)
                            .WriteAttributeString("Redemption", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamPlayers.Players(k).PlayerOffers.Offers(l).OfferRedemption)
                            .WriteAttributeString("Salary", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamPlayers.Players(k).PlayerOffers.Offers(l).OfferSalary)
                            .WriteAttributeString("BiddingTeam", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamPlayers.Players(k).PlayerOffers.Offers(l).OfferBiddingTeam)
                            .WriteAttributeString("ContractUntil", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamPlayers.Players(k).PlayerOffers.Offers(l).OfferContractUntil)
                            .WriteAttributeString("Status", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamPlayers.Players(k).PlayerOffers.Offers(l).OfferStatus)

                            .WriteEndElement() 'Offer
                        Next

                        .WriteEndElement() 'Offers

                        .WriteEndElement() 'Player
                    Next

                    .WriteEndElement() 'Players

                    .WriteStartElement("Coach")

                    .WriteAttributeString("FirstName", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamCoach.CoachFirstName)
                    .WriteAttributeString("LastName", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamCoach.CoachLastName)
                    .WriteAttributeString("Birthday", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamCoach.CoachBirthday)
                    .WriteAttributeString("Nationality", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamCoach.CoachNationality)
                    .WriteAttributeString("Rating", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamCoach.CoachRating)
                    .WriteAttributeString("CurrentTeam", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamCoach.CoachCurrentTeam)
                    .WriteAttributeString("Salary", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamCoach.CoachSalary)

                    .WriteStartElement("Offers")

                    For k = 0 To AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamCoach.CoachOffers.Offers.Count - 1

                        .WriteStartElement("Offer")

                        .WriteAttributeString("PlayerName", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamCoach.CoachOffers.Offers(k).OfferPlayerName)
                        .WriteAttributeString("CurrentTeamName", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamCoach.CoachOffers.Offers(k).OfferCurrentTeamName)
                        .WriteAttributeString("MadeDate", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamCoach.CoachOffers.Offers(k).OfferMadeDate)
                        .WriteAttributeString("LastDealtDate", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamCoach.CoachOffers.Offers(k).OfferLastDealtDate)
                        .WriteAttributeString("Redemption", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamCoach.CoachOffers.Offers(k).OfferRedemption)
                        .WriteAttributeString("Salary", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamCoach.CoachOffers.Offers(k).OfferSalary)
                        .WriteAttributeString("BiddingTeam", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamCoach.CoachOffers.Offers(k).OfferBiddingTeam)
                        .WriteAttributeString("ContractUntil", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamCoach.CoachOffers.Offers(k).OfferContractUntil)
                        .WriteAttributeString("Status", AllDaysOfPlay.DaysOfPlay(i).DayOfPlayGames.Games(j).GameOpponentGuest.TeamCoach.CoachOffers.Offers(k).OfferStatus)

                        .WriteEndElement() 'Offer
                    Next

                    .WriteEndElement() 'Offers

                    .WriteEndElement() 'Coach

                    .WriteEndElement() 'OpponentGuest

                    .WriteStartElement("TotalScore")

                    'TODO: Refactor this!
                    Try
                        .WriteAttributeString("Home", AllGames.Games(i).GameTotalScore.ScoreHome.PlayerScoreTotal)
                    Catch
                        .WriteAttributeString("Home", "0")
                    End Try
                    Try
                        .WriteAttributeString("Guest", AllGames.Games(i).GameTotalScore.ScoreGuest.PlayerScoreTotal)
                    Catch
                        .WriteAttributeString("Guest", "0")
                    End Try


                    .WriteEndElement() 'TotalScore

                    .WriteEndElement() 'Game

                Next

                .WriteEndElement() 'Games

                .WriteEndElement() 'DayOfPlay
            Next

            .WriteEndElement() 'DaysOfPlay
            '-----------------------------------------------------------------------------------------------------------------
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
            '-------------------------------------------------------------------------------------------------------------------
            .WriteStartElement("Games")

            For i = 0 To AllGames.Games.Count - 1

                .WriteStartElement("Game")

                .WriteStartElement("OpponentHome")


                .WriteAttributeString("Name", AllGames.Games(i).GameOpponentHome.TeamName)
                .WriteAttributeString("Money", AllGames.Games(i).GameOpponentHome.TeamMoney)
                .WriteAttributeString("Wins", AllGames.Games(i).GameOpponentHome.TeamWins)
                .WriteAttributeString("Losses", AllGames.Games(i).GameOpponentHome.TeamLosses)
                .WriteAttributeString("AdditionalSalary", AllGames.Games(i).GameOpponentHome.TeamAdditionalSalary)

                .WriteStartElement("Players")

                For j = 0 To AllGames.Games(i).GameOpponentHome.TeamPlayers.Players.Count - 1

                    .WriteStartElement("Player")

                    .WriteAttributeString("FirstName", AllGames.Games(i).GameOpponentHome.TeamPlayers.Players(j).PlayerFirstName)
                    .WriteAttributeString("LastName", AllGames.Games(i).GameOpponentHome.TeamPlayers.Players(j).PlayerLastName)
                    .WriteAttributeString("Birthday", AllGames.Games(i).GameOpponentHome.TeamPlayers.Players(j).PlayerBirthday)
                    .WriteAttributeString("Nationality", AllGames.Games(i).GameOpponentHome.TeamPlayers.Players(j).PlayerNationality)
                    .WriteAttributeString("Size", AllGames.Games(i).GameOpponentHome.TeamPlayers.Players(j).PlayerSize)
                    .WriteAttributeString("Weight", AllGames.Games(i).GameOpponentHome.TeamPlayers.Players(j).PlayerWeight)
                    .WriteAttributeString("Position", AllGames.Games(i).GameOpponentHome.TeamPlayers.Players(j).PlayerPosition)
                    .WriteAttributeString("SecondPosition", AllGames.Games(i).GameOpponentHome.TeamPlayers.Players(j).PlayerSecondPosition)
                    .WriteAttributeString("Rating", AllGames.Games(i).GameOpponentHome.TeamPlayers.Players(j).PlayerRating)
                    .WriteAttributeString("CurrentTeam", AllGames.Games(i).GameOpponentHome.TeamPlayers.Players(j).PlayerCurrentTeam)
                    .WriteAttributeString("Salary", AllGames.Games(i).GameOpponentHome.TeamPlayers.Players(j).PlayerSalary)
                    .WriteAttributeString("ContractUntil", AllGames.Games(i).GameOpponentHome.TeamPlayers.Players(j).PlayerContractUntil)
                    .WriteAttributeString("RotationNumber", AllGames.Games(i).GameOpponentHome.TeamPlayers.Players(j).PlayerRotationNumber)
                    .WriteAttributeString("RotationMinutes", AllGames.Games(i).GameOpponentHome.TeamPlayers.Players(j).PlayerRotationMinutes)
                    .WriteAttributeString("PointsLastGame", AllGames.Games(i).GameOpponentHome.TeamPlayers.Players(j).PlayerPointsLastGame)

                    .WriteStartElement("Offers")

                    For k = 0 To AllGames.Games(i).GameOpponentHome.TeamPlayers.Players(j).PlayerOffers.Offers.Count - 1

                        .WriteStartElement("Offer")

                        .WriteAttributeString("PlayerName", AllGames.Games(i).GameOpponentHome.TeamPlayers.Players(j).PlayerOffers.Offers(k).OfferPlayerName)
                        .WriteAttributeString("CurrentTeamName", AllGames.Games(i).GameOpponentHome.TeamPlayers.Players(j).PlayerOffers.Offers(k).OfferCurrentTeamName)
                        .WriteAttributeString("MadeDate", AllGames.Games(i).GameOpponentHome.TeamPlayers.Players(j).PlayerOffers.Offers(k).OfferMadeDate)
                        .WriteAttributeString("LastDealtDate", AllGames.Games(i).GameOpponentHome.TeamPlayers.Players(j).PlayerOffers.Offers(k).OfferLastDealtDate)
                        .WriteAttributeString("Redemption", AllGames.Games(i).GameOpponentHome.TeamPlayers.Players(j).PlayerOffers.Offers(k).OfferRedemption)
                        .WriteAttributeString("Salary", AllGames.Games(i).GameOpponentHome.TeamPlayers.Players(j).PlayerOffers.Offers(k).OfferSalary)
                        .WriteAttributeString("BiddingTeam", AllGames.Games(i).GameOpponentHome.TeamPlayers.Players(j).PlayerOffers.Offers(k).OfferBiddingTeam)
                        .WriteAttributeString("ContractUntil", AllGames.Games(i).GameOpponentHome.TeamPlayers.Players(j).PlayerOffers.Offers(k).OfferContractUntil)
                        .WriteAttributeString("Status", AllGames.Games(i).GameOpponentHome.TeamPlayers.Players(j).PlayerOffers.Offers(k).OfferStatus)

                        .WriteEndElement() 'Offer
                    Next

                    .WriteEndElement() 'Offers

                    .WriteEndElement() 'Player
                Next

                .WriteEndElement() 'Players

                .WriteStartElement("Coach")

                .WriteAttributeString("FirstName", AllGames.Games(i).GameOpponentHome.TeamCoach.CoachFirstName)
                .WriteAttributeString("LastName", AllGames.Games(i).GameOpponentHome.TeamCoach.CoachLastName)
                .WriteAttributeString("Birthday", AllGames.Games(i).GameOpponentHome.TeamCoach.CoachBirthday)
                .WriteAttributeString("Nationality", AllGames.Games(i).GameOpponentHome.TeamCoach.CoachNationality)
                .WriteAttributeString("Rating", AllGames.Games(i).GameOpponentHome.TeamCoach.CoachRating)
                .WriteAttributeString("CurrentTeam", AllGames.Games(i).GameOpponentHome.TeamCoach.CoachCurrentTeam)
                .WriteAttributeString("Salary", AllGames.Games(i).GameOpponentHome.TeamCoach.CoachSalary)

                .WriteStartElement("Offers")

                For j = 0 To AllGames.Games(i).GameOpponentHome.TeamCoach.CoachOffers.Offers.Count - 1

                    .WriteStartElement("Offer")

                    .WriteAttributeString("PlayerName", AllGames.Games(i).GameOpponentHome.TeamCoach.CoachOffers.Offers(j).OfferPlayerName)
                    .WriteAttributeString("CurrentTeamName", AllGames.Games(i).GameOpponentHome.TeamCoach.CoachOffers.Offers(j).OfferCurrentTeamName)
                    .WriteAttributeString("MadeDate", AllGames.Games(i).GameOpponentHome.TeamCoach.CoachOffers.Offers(j).OfferMadeDate)
                    .WriteAttributeString("LastDealtDate", AllGames.Games(i).GameOpponentHome.TeamCoach.CoachOffers.Offers(j).OfferLastDealtDate)
                    .WriteAttributeString("Redemption", AllGames.Games(i).GameOpponentHome.TeamCoach.CoachOffers.Offers(j).OfferRedemption)
                    .WriteAttributeString("Salary", AllGames.Games(i).GameOpponentHome.TeamCoach.CoachOffers.Offers(j).OfferSalary)
                    .WriteAttributeString("BiddingTeam", AllGames.Games(i).GameOpponentHome.TeamCoach.CoachOffers.Offers(j).OfferBiddingTeam)
                    .WriteAttributeString("ContractUntil", AllGames.Games(i).GameOpponentHome.TeamCoach.CoachOffers.Offers(j).OfferContractUntil)
                    .WriteAttributeString("Status", AllGames.Games(i).GameOpponentHome.TeamCoach.CoachOffers.Offers(j).OfferStatus)

                    .WriteEndElement() 'Offer
                Next

                .WriteEndElement() 'Offers

                .WriteEndElement() 'Coach

                .WriteEndElement() 'OpponentHome

                .WriteStartElement("OpponentGuest")


                .WriteAttributeString("Name", AllGames.Games(i).GameOpponentGuest.TeamName)
                .WriteAttributeString("Money", AllGames.Games(i).GameOpponentGuest.TeamMoney)
                .WriteAttributeString("Wins", AllGames.Games(i).GameOpponentGuest.TeamWins)
                .WriteAttributeString("Losses", AllGames.Games(i).GameOpponentGuest.TeamLosses)
                .WriteAttributeString("AdditionalSalary", AllGames.Games(i).GameOpponentGuest.TeamAdditionalSalary)

                .WriteStartElement("Players")

                For j = 0 To AllGames.Games(i).GameOpponentGuest.TeamPlayers.Players.Count - 1

                    .WriteStartElement("Player")

                    .WriteAttributeString("FirstName", AllGames.Games(i).GameOpponentGuest.TeamPlayers.Players(j).PlayerFirstName)
                    .WriteAttributeString("LastName", AllGames.Games(i).GameOpponentGuest.TeamPlayers.Players(j).PlayerLastName)
                    .WriteAttributeString("Birthday", AllGames.Games(i).GameOpponentGuest.TeamPlayers.Players(j).PlayerBirthday)
                    .WriteAttributeString("Nationality", AllGames.Games(i).GameOpponentGuest.TeamPlayers.Players(j).PlayerNationality)
                    .WriteAttributeString("Size", AllGames.Games(i).GameOpponentGuest.TeamPlayers.Players(j).PlayerSize)
                    .WriteAttributeString("Weight", AllGames.Games(i).GameOpponentGuest.TeamPlayers.Players(j).PlayerWeight)
                    .WriteAttributeString("Position", AllGames.Games(i).GameOpponentGuest.TeamPlayers.Players(j).PlayerPosition)
                    .WriteAttributeString("SecondPosition", AllGames.Games(i).GameOpponentGuest.TeamPlayers.Players(j).PlayerSecondPosition)
                    .WriteAttributeString("Rating", AllGames.Games(i).GameOpponentGuest.TeamPlayers.Players(j).PlayerRating)
                    .WriteAttributeString("CurrentTeam", AllGames.Games(i).GameOpponentGuest.TeamPlayers.Players(j).PlayerCurrentTeam)
                    .WriteAttributeString("Salary", AllGames.Games(i).GameOpponentGuest.TeamPlayers.Players(j).PlayerSalary)
                    .WriteAttributeString("ContractUntil", AllGames.Games(i).GameOpponentGuest.TeamPlayers.Players(j).PlayerContractUntil)
                    .WriteAttributeString("RotationNumber", AllGames.Games(i).GameOpponentGuest.TeamPlayers.Players(j).PlayerRotationNumber)
                    .WriteAttributeString("RotationMinutes", AllGames.Games(i).GameOpponentGuest.TeamPlayers.Players(j).PlayerRotationMinutes)
                    .WriteAttributeString("PointsLastGame", AllGames.Games(i).GameOpponentGuest.TeamPlayers.Players(j).PlayerPointsLastGame)

                    .WriteStartElement("Offers")

                    For k = 0 To AllGames.Games(i).GameOpponentGuest.TeamPlayers.Players(j).PlayerOffers.Offers.Count - 1

                        .WriteStartElement("Offer")

                        .WriteAttributeString("PlayerName", AllGames.Games(i).GameOpponentGuest.TeamPlayers.Players(j).PlayerOffers.Offers(k).OfferPlayerName)
                        .WriteAttributeString("CurrentTeamName", AllGames.Games(i).GameOpponentGuest.TeamPlayers.Players(j).PlayerOffers.Offers(k).OfferCurrentTeamName)
                        .WriteAttributeString("MadeDate", AllGames.Games(i).GameOpponentGuest.TeamPlayers.Players(j).PlayerOffers.Offers(k).OfferMadeDate)
                        .WriteAttributeString("LastDealtDate", AllGames.Games(i).GameOpponentGuest.TeamPlayers.Players(j).PlayerOffers.Offers(k).OfferLastDealtDate)
                        .WriteAttributeString("Redemption", AllGames.Games(i).GameOpponentGuest.TeamPlayers.Players(j).PlayerOffers.Offers(k).OfferRedemption)
                        .WriteAttributeString("Salary", AllGames.Games(i).GameOpponentGuest.TeamPlayers.Players(j).PlayerOffers.Offers(k).OfferSalary)
                        .WriteAttributeString("BiddingTeam", AllGames.Games(i).GameOpponentGuest.TeamPlayers.Players(j).PlayerOffers.Offers(k).OfferBiddingTeam)
                        .WriteAttributeString("ContractUntil", AllGames.Games(i).GameOpponentGuest.TeamPlayers.Players(j).PlayerOffers.Offers(k).OfferContractUntil)
                        .WriteAttributeString("Status", AllGames.Games(i).GameOpponentGuest.TeamPlayers.Players(j).PlayerOffers.Offers(k).OfferStatus)

                        .WriteEndElement() 'Offer
                    Next

                    .WriteEndElement() 'Offers

                    .WriteEndElement() 'Player
                Next

                .WriteEndElement() 'Players

                .WriteStartElement("Coach")

                .WriteAttributeString("FirstName", AllGames.Games(i).GameOpponentGuest.TeamCoach.CoachFirstName)
                .WriteAttributeString("LastName", AllGames.Games(i).GameOpponentGuest.TeamCoach.CoachLastName)
                .WriteAttributeString("Birthday", AllGames.Games(i).GameOpponentGuest.TeamCoach.CoachBirthday)
                .WriteAttributeString("Nationality", AllGames.Games(i).GameOpponentGuest.TeamCoach.CoachNationality)
                .WriteAttributeString("Rating", AllGames.Games(i).GameOpponentGuest.TeamCoach.CoachRating)
                .WriteAttributeString("CurrentTeam", AllGames.Games(i).GameOpponentGuest.TeamCoach.CoachCurrentTeam)
                .WriteAttributeString("Salary", AllGames.Games(i).GameOpponentGuest.TeamCoach.CoachSalary)

                .WriteStartElement("Offers")

                For j = 0 To AllGames.Games(i).GameOpponentGuest.TeamCoach.CoachOffers.Offers.Count - 1

                    .WriteStartElement("Offer")

                    .WriteAttributeString("PlayerName", AllGames.Games(i).GameOpponentGuest.TeamCoach.CoachOffers.Offers(j).OfferPlayerName)
                    .WriteAttributeString("CurrentTeamName", AllGames.Games(i).GameOpponentGuest.TeamCoach.CoachOffers.Offers(j).OfferCurrentTeamName)
                    .WriteAttributeString("MadeDate", AllGames.Games(i).GameOpponentGuest.TeamCoach.CoachOffers.Offers(j).OfferMadeDate)
                    .WriteAttributeString("LastDealtDate", AllGames.Games(i).GameOpponentGuest.TeamCoach.CoachOffers.Offers(j).OfferLastDealtDate)
                    .WriteAttributeString("Redemption", AllGames.Games(i).GameOpponentGuest.TeamCoach.CoachOffers.Offers(j).OfferRedemption)
                    .WriteAttributeString("Salary", AllGames.Games(i).GameOpponentGuest.TeamCoach.CoachOffers.Offers(j).OfferSalary)
                    .WriteAttributeString("BiddingTeam", AllGames.Games(i).GameOpponentGuest.TeamCoach.CoachOffers.Offers(j).OfferBiddingTeam)
                    .WriteAttributeString("ContractUntil", AllGames.Games(i).GameOpponentGuest.TeamCoach.CoachOffers.Offers(j).OfferContractUntil)
                    .WriteAttributeString("Status", AllGames.Games(i).GameOpponentGuest.TeamCoach.CoachOffers.Offers(j).OfferStatus)

                    .WriteEndElement() 'Offer
                Next

                .WriteEndElement() 'Offers

                .WriteEndElement() 'Coach

                .WriteEndElement() 'OpponentGuest

                .WriteStartElement("TotalScore")

                'TODO: Refactor this!
                Try
                    .WriteAttributeString("Home", AllGames.Games(i).GameTotalScore.ScoreHome.PlayerScoreTotal)
                Catch
                    .WriteAttributeString("Home", "0")
                End Try
                Try
                    .WriteAttributeString("Guest", AllGames.Games(i).GameTotalScore.ScoreGuest.PlayerScoreTotal)
                Catch
                    .WriteAttributeString("Guest", "0")
                End Try


                .WriteEndElement() 'TotalScore

                .WriteEndElement() 'Game

            Next

            .WriteEndElement() 'Games
            '---------------------------------------------------------------------------------------------
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

                .WriteStartElement("Offers")

                For j = 0 To AllPlayers.Players(i).PlayerOffers.Offers.Count - 1

                    .WriteStartElement("Offer")

                    .WriteAttributeString("PlayerName", AllPlayers.Players(i).PlayerOffers.Offers(j).OfferPlayerName)
                    .WriteAttributeString("CurrentTeamName", AllPlayers.Players(i).PlayerOffers.Offers(j).OfferCurrentTeamName)
                    .WriteAttributeString("MadeDate", AllPlayers.Players(i).PlayerOffers.Offers(j).OfferMadeDate)
                    .WriteAttributeString("LastDealtDate", AllPlayers.Players(i).PlayerOffers.Offers(j).OfferLastDealtDate)
                    .WriteAttributeString("Redemption", AllPlayers.Players(i).PlayerOffers.Offers(j).OfferRedemption)
                    .WriteAttributeString("Salary", AllPlayers.Players(i).PlayerOffers.Offers(j).OfferSalary)
                    .WriteAttributeString("BiddingTeam", AllPlayers.Players(i).PlayerOffers.Offers(j).OfferBiddingTeam)
                    .WriteAttributeString("ContractUntil", AllPlayers.Players(i).PlayerOffers.Offers(j).OfferContractUntil)
                    .WriteAttributeString("Status", AllPlayers.Players(i).PlayerOffers.Offers(j).OfferStatus)

                    .WriteEndElement() 'Offer
                Next

                .WriteEndElement() 'Offers

                .WriteEndElement() 'Player
            Next

            .WriteEndElement() 'Players
            '-------------------------------------------------------------------------------------------------------------------
            .WriteStartElement("Teams")

            For i = 0 To AllTeams.Teams.Count - 1

                .WriteStartElement("Team")

                .WriteAttributeString("Name", AllTeams.Teams(i).TeamName)
                .WriteAttributeString("Money", AllTeams.Teams(i).TeamMoney)
                .WriteAttributeString("Wins", AllTeams.Teams(i).TeamWins)
                .WriteAttributeString("Losses", AllTeams.Teams(i).TeamLosses)
                .WriteAttributeString("AdditionalSalary", AllTeams.Teams(i).TeamAdditionalSalary)

                .WriteStartElement("Players")

                For j = 0 To AllTeams.Teams(i).TeamPlayers.Players.Count - 1

                    .WriteStartElement("Player")

                    .WriteAttributeString("FirstName", AllTeams.Teams(i).TeamPlayers.Players(j).PlayerFirstName)
                    .WriteAttributeString("LastName", AllTeams.Teams(i).TeamPlayers.Players(j).PlayerLastName)
                    .WriteAttributeString("Birthday", AllTeams.Teams(i).TeamPlayers.Players(j).PlayerBirthday)
                    .WriteAttributeString("Nationality", AllTeams.Teams(i).TeamPlayers.Players(j).PlayerNationality)
                    .WriteAttributeString("Size", AllTeams.Teams(i).TeamPlayers.Players(j).PlayerSize)
                    .WriteAttributeString("Weight", AllTeams.Teams(i).TeamPlayers.Players(j).PlayerWeight)
                    .WriteAttributeString("Position", AllTeams.Teams(i).TeamPlayers.Players(j).PlayerPosition)
                    .WriteAttributeString("SecondPosition", AllTeams.Teams(i).TeamPlayers.Players(j).PlayerSecondPosition)
                    .WriteAttributeString("Rating", AllTeams.Teams(i).TeamPlayers.Players(j).PlayerRating)
                    .WriteAttributeString("CurrentTeam", AllTeams.Teams(i).TeamPlayers.Players(j).PlayerCurrentTeam)
                    .WriteAttributeString("Salary", AllTeams.Teams(i).TeamPlayers.Players(j).PlayerSalary)
                    .WriteAttributeString("ContractUntil", AllTeams.Teams(i).TeamPlayers.Players(j).PlayerContractUntil)
                    .WriteAttributeString("RotationNumber", AllTeams.Teams(i).TeamPlayers.Players(j).PlayerRotationNumber)
                    .WriteAttributeString("RotationMinutes", AllTeams.Teams(i).TeamPlayers.Players(j).PlayerRotationMinutes)
                    .WriteAttributeString("PointsLastGame", AllTeams.Teams(i).TeamPlayers.Players(j).PlayerPointsLastGame)

                    .WriteStartElement("Offers")

                    For k = 0 To AllPlayers.Players(i).PlayerOffers.Offers.Count - 1

                        .WriteStartElement("Offer")

                        .WriteAttributeString("PlayerName", AllTeams.Teams(i).TeamPlayers.Players(j).PlayerOffers.Offers(k).OfferPlayerName)
                        .WriteAttributeString("CurrentTeamName", AllTeams.Teams(i).TeamPlayers.Players(j).PlayerOffers.Offers(k).OfferCurrentTeamName)
                        .WriteAttributeString("MadeDate", AllTeams.Teams(i).TeamPlayers.Players(j).PlayerOffers.Offers(k).OfferMadeDate)
                        .WriteAttributeString("LastDealtDate", AllTeams.Teams(i).TeamPlayers.Players(j).PlayerOffers.Offers(k).OfferLastDealtDate)
                        .WriteAttributeString("Redemption", AllTeams.Teams(i).TeamPlayers.Players(j).PlayerOffers.Offers(k).OfferRedemption)
                        .WriteAttributeString("Salary", AllTeams.Teams(i).TeamPlayers.Players(j).PlayerOffers.Offers(k).OfferSalary)
                        .WriteAttributeString("BiddingTeam", AllTeams.Teams(i).TeamPlayers.Players(j).PlayerOffers.Offers(k).OfferBiddingTeam)
                        .WriteAttributeString("ContractUntil", AllTeams.Teams(i).TeamPlayers.Players(j).PlayerOffers.Offers(k).OfferContractUntil)
                        .WriteAttributeString("Status", AllTeams.Teams(i).TeamPlayers.Players(j).PlayerOffers.Offers(k).OfferStatus)

                        .WriteEndElement() 'Offer
                    Next

                    .WriteEndElement() 'Offers

                    .WriteEndElement() 'Player
                Next

                .WriteEndElement() 'Players

                .WriteStartElement("Coach")

                .WriteAttributeString("FirstName", AllTeams.Teams(i).TeamCoach.CoachFirstName)
                .WriteAttributeString("LastName", AllTeams.Teams(i).TeamCoach.CoachLastName)
                .WriteAttributeString("Birthday", AllTeams.Teams(i).TeamCoach.CoachBirthday)
                .WriteAttributeString("Nationality", AllTeams.Teams(i).TeamCoach.CoachNationality)
                .WriteAttributeString("Rating", AllTeams.Teams(i).TeamCoach.CoachRating)
                .WriteAttributeString("CurrentTeam", AllTeams.Teams(i).TeamCoach.CoachCurrentTeam)
                .WriteAttributeString("Salary", AllTeams.Teams(i).TeamCoach.CoachSalary)

                .WriteStartElement("Offers")

                For j = 0 To AllTeams.Teams(i).TeamCoach.CoachOffers.Offers.Count - 1

                    .WriteStartElement("Offer")

                    .WriteAttributeString("PlayerName", AllTeams.Teams(i).TeamCoach.CoachOffers.Offers(j).OfferPlayerName)
                    .WriteAttributeString("CurrentTeamName", AllTeams.Teams(i).TeamCoach.CoachOffers.Offers(j).OfferCurrentTeamName)
                    .WriteAttributeString("MadeDate", AllTeams.Teams(i).TeamCoach.CoachOffers.Offers(j).OfferMadeDate)
                    .WriteAttributeString("LastDealtDate", AllTeams.Teams(i).TeamCoach.CoachOffers.Offers(j).OfferLastDealtDate)
                    .WriteAttributeString("Redemption", AllTeams.Teams(i).TeamCoach.CoachOffers.Offers(j).OfferRedemption)
                    .WriteAttributeString("Salary", AllTeams.Teams(i).TeamCoach.CoachOffers.Offers(j).OfferSalary)
                    .WriteAttributeString("BiddingTeam", AllTeams.Teams(i).TeamCoach.CoachOffers.Offers(j).OfferBiddingTeam)
                    .WriteAttributeString("ContractUntil", AllTeams.Teams(i).TeamCoach.CoachOffers.Offers(j).OfferContractUntil)
                    .WriteAttributeString("Status", AllTeams.Teams(i).TeamCoach.CoachOffers.Offers(j).OfferStatus)

                    .WriteEndElement() 'Offer
                Next

                .WriteEndElement() 'Offers

                .WriteEndElement() 'Coach

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

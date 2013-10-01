Class Application

    ' Ereignisse auf Anwendungsebene wie Startup, Exit und DispatcherUnhandledException
    ' können in dieser Datei verarbeitet werden.



    Private Sub Application_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup

        CurrentTeamIndex = Nothing
        AllPlayersWithOffers = New PlayersList
        AllOffers = New OffersList
        CurrentDate = #1/1/2000#

        Dim player1 As New Player("Tanner", "Smith", "30.03.1990", "USA", 196, 95, "SG", "", 80, "MHP Riesen Ludwigsburg", 3500, 2014, 1, 20, New OffersList, 0)
        Dim player2 As New Player("Patrick", "Flomo", "19.07.1980", "Deutschland", 203, 101, "PF", "C", 73, "MHP Riesen Ludwigsburg", 2500, 2015, 2, 1, New OffersList, 0)
        Dim player3 As New Player("Tim", "Koch", "01.02.1989", "Deutschland", 196, 90, "SF", "", 67, "MHP Riesen Ludwigsburg", 1500, 2017, 3, 1, New OffersList, 0)
        Dim player4 As New Player("Johannes", "Joos", "11.01.1995", "Deutschland", 204, 95, "PF", "", 61, "MHP Riesen Ludwigsburg", 600, 2016, 4, 0, New OffersList, 0)
        Dim player5 As New Player("Adam", "Waleskowski", "19.11.1982", "Deutschland", 203, 104, "PF", "", 72, "MHP Riesen Ludwigsburg", 2300, 2015, 5, 1, New OffersList, 0)
        Dim player6 As New Player("Austin", "Dufault", "03.01.1990", "USA", 205, 103, "PF", "", 80, "MHP Riesen Ludwigsburg", 3550, 2014, 6, 20, New OffersList, 0)
        Dim player7 As New Player("Mario", "Stojic", "06.05.1980", "Deutschland", 198, 100, "SG", "SF", 82, "MHP Riesen Ludwigsburg", 4500, 2015, 7, 20, New OffersList, 0)
        Dim player8 As New Player("Gregory", "Echenique", "23.11.1990", "Venezuela", 206, 118, "C", "", 85, "MHP Riesen Ludwigsburg", 4600, 2015, 8, 26, New OffersList, 0)
        Dim player9 As New Player("C.J.", "Harris", "19.02.1991", "USA", 191, 86, "PG", "SG", 82, "MHP Riesen Ludwigsburg", 3300, 2014, 9, 25, New OffersList, 0)
        Dim player10 As New Player("Keaton", "Grant", "08.12.1986", "USA", 193, 90, "SG", "", 86, "MHP Riesen Ludwigsburg", 5000, 2014, 10, 30, New OffersList, 0)


        Dim player11 As New Player("Chevon", "Troutman", "25.11.1981", "USA", 202, 100, "PF", "C", 90, "FC Bayern München Basketball", 5900, 2015, 1, 25, New OffersList, 0)

        Dim playersLudwigsburg As New PlayersList()
        playersLudwigsburg.Players.Add(player1)
        playersLudwigsburg.Players.Add(player2)
        playersLudwigsburg.Players.Add(player3)
        playersLudwigsburg.Players.Add(player4)
        playersLudwigsburg.Players.Add(player5)
        playersLudwigsburg.Players.Add(player6)
        playersLudwigsburg.Players.Add(player7)
        playersLudwigsburg.Players.Add(player8)
        playersLudwigsburg.Players.Add(player9)
        playersLudwigsburg.Players.Add(player10)

        Dim playersMünchen As New PlayersList()
        playersMünchen.Players.Add(player11)

        AllPlayers = New PlayersList
        AllPlayers.Players.Add(player1)
        AllPlayers.Players.Add(player2)
        AllPlayers.Players.Add(player3)
        AllPlayers.Players.Add(player4)
        AllPlayers.Players.Add(player5)
        AllPlayers.Players.Add(player6)
        AllPlayers.Players.Add(player7)
        AllPlayers.Players.Add(player8)
        AllPlayers.Players.Add(player9)
        AllPlayers.Players.Add(player10)
        AllPlayers.Players.Add(player11)


        Dim coach1 As New Coach("John", "Patrick", "29.02.1968", "USA", 85, "MHP Riesen Ludwigsburg", 5500, New OffersList)
        Dim coach2 As New Coach("Svetislav", "Pesic", "28.08.1994", "Serbien", 96, "FC Bayern München Basketball", 7000, New OffersList)

        Dim coaches As New CoachesList
        coaches.Coaches.Add(coach1)
        coaches.Coaches.Add(coach2)

        AllCoaches = coaches


        Dim team1 As New Team("MHP Riesen Ludwigsburg", playersLudwigsburg, coach1, 2000000, 0, 0, 0)
        Dim team2 As New Team("FC Bayern München Basketball", playersMünchen, coach2, 5000000, 0, 0, 0)

        Dim team3 As New Team("Brose Baskets Bamberg", New PlayersList, New Coach, 4000000, 0, 0, 0)
        Dim team4 As New Team("EWE Baskets Oldenburg", New PlayersList, New Coach, 3000000, 0, 0, 0)

        Dim teams As New TeamsList
        teams.Teams.Add(team1)
        teams.Teams.Add(team2)
        teams.Teams.Add(team3)
        teams.Teams.Add(team4)

        AllTeams = teams


        Dim remainingMinutes As New RemainingMinutes()

        Dim remainingMinutesList As New RemainingMinutesList
        remainingMinutesList.RemainingMinutes.Add(remainingMinutes)

        AllRemainingMinutes = remainingMinutesList



        Dim availablePlayers As PlayersList = New PlayersList

        For i = 0 To AllPlayers.Players.Count - 1

            If AllPlayers.Players(i).PlayerContractUntil = Nothing Then

                availablePlayers.Players.Add(AllPlayers.Players(i))
            End If

        Next

        PlayerContainer.AvailablePlayers = AvailablePlayers

        Dim availableCoaches As New CoachesList

        For i = 0 To AllCoaches.Coaches.Count - 1

            If AllCoaches.Coaches(i).CoachCurrentTeam = Nothing Then
                availableCoaches.Coaches.Add(AllCoaches.Coaches(i))
            End If
        Next

        CoachContainer.AvailableCoaches = availableCoaches


        Dim game1 As New Game(team1, team2, New Score)
        Dim game2 As New Game(team3, team4, New Score)

        Dim gamesDay1 As New GamesList
        gamesDay1.Games.Add(game1)
        gamesDay1.Games.Add(game2)

        Dim games As New GamesList
        games.Games.Add(game1)
        games.Games.Add(game2)

        AllGames = games


        Dim dayOfPlay1 As New DayOfPlay(1, #1/1/2000#, gamesDay1)

        Dim daysOfPlayList As New DaysOfPlayList
        daysOfPlayList.DaysOfPlay.Add(dayOfPlay1)

        AllDaysOfPlay = daysOfPlayList


        Dim publicProperties1 As New PublicProperties(#1/1/2000#)
        AllPublicProperties = publicProperties1

        AllEmails = New EmailsList()
    End Sub
End Class

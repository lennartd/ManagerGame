Class Application

    ' Ereignisse auf Anwendungsebene wie Startup, Exit und DispatcherUnhandledException
    ' können in dieser Datei verarbeitet werden.



    Private Sub Application_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup

       


        '_______________________________________________________________________________________________________________________________________________


        AllCoaches = New CoachesList()
        AllDaysOfPlay = New DaysOfPlayList()
        AllEmails = New EmailsList()
        AllGames = New GamesList()
        AllOffers = New OffersList()
        AllPlayers = New PlayersList()
        AllTeams = New TeamsList()
        AllRemainingMinutes = New RemainingMinutesList()
        AllPublicProperties = New PublicProperties()
        AllPlayersWithOffers = New PlayersList()
        AvailableCoaches = New CoachesList()
        AvailablePlayers = New PlayersList()

        '_______________________________________________________________________________________________________________________________________________

        AllClassesContainer = New ClassesContainer(AllCoaches, AllDaysOfPlay, AllEmails, AllGames, AllOffers, AllPlayers, AllTeams, AllPublicProperties, _
                                                   AllRemainingMinutes, AvailablePlayers, AvailableCoaches, AllPlayersWithOffers)

    End Sub
End Class

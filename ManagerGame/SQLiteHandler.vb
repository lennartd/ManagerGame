Imports System.Data

Public Class SqLiteHandler

    ReadOnly _sqlitedatabase As SQLiteDatabase = New SQLiteDatabase("C:\Users\Anwender\Downloads\ManagerGameData")

    Dim _allGames1 As GamesList = New GamesList()
    Dim _allGames2 As GamesList = New GamesList()

    Public Sub GetData()

        Dim tablenames As List(Of String) = New List(Of String)()
        tablenames.Add("AllCoaches")
        tablenames.Add("AllPlayers")
        tablenames.Add("AllTeams")
        tablenames.Add("Games1")
        tablenames.Add("Games2")
        tablenames.Add("AllDaysOfPlay")
        tablenames.Add("AllPublicProperties")

        For i = 0 To tablenames.Count - 1


            Dim result As DataTable = New DataTable()
            Try
                Dim query As String = "select * from " & tablenames(i)
                result = _sqlitedatabase.GetDataTable(query)

            Catch e As Exception

            End Try

            Select Case result.TableName
                Case "AllCoaches"
                    GetAllCoaches(result)
                Case "AllTeams"
                    GetAllTeams(result)
                Case "Games1", "Games2"
                    Dim number As Integer = CInt(result.TableName.Split("s")(1))
                    GetGames(result, number)
                Case "AllPlayers"
                    GetAllPlayers(result)
                Case "AllDaysOfPlay"
                    GetAllDaysOfPlay(result)
                Case "AllPublicProperties"
                    GetAllPublicProperties(result)
            End Select
        Next

    End Sub

    Private Sub GetAllPublicProperties(ByVal result As DataTable)

        Dim currentdate As Date = Nothing

        Dim publicproperties As PublicProperties = New PublicProperties()

        For Each datarow As DataRow In result.Rows

            For j = 0 To result.Columns.Count - 1

                Select Case result.Columns(j).ColumnName
                    Case "CurrentDate"
                        currentdate = datarow(j)
                End Select
            Next
            publicproperties.PublicPropertyCurrentDate = currentdate
        Next
        AllPublicProperties = publicproperties
    End Sub

    Private Sub GetAllDaysOfPlay(ByVal result As DataTable)

        Dim number As Integer = Nothing
        Dim actualdate As Date = Nothing

        Dim daysofplay As DaysOfPlayList = New DaysOfPlayList()

        For Each datarow As DataRow In result.Rows

            For j = 0 To result.Columns.Count - 1

                Select Case result.Columns(j).ColumnName
                    Case "Number"
                        number = datarow(j)
                    Case "ActualDate"
                        actualdate = datarow(j)
                End Select
            Next

            Dim games As GamesList = New GamesList()

            Select Case number
                Case 1
                    games = _allGames1
                Case 2
                    games = _allGames2
            End Select

            daysofplay.DaysOfPlay.Add(New DayOfPlay(number, actualdate, games))
        Next
        AllDaysOfPlay = daysofplay
    End Sub

    Private Sub GetAllPlayers(ByVal result As DataTable)

        Dim firstname As String = Nothing
        Dim lastname As String = Nothing
        Dim birthday As String = Nothing
        Dim nationality As String = Nothing
        Dim size As Integer = Nothing
        Dim weight As Integer = Nothing
        Dim position As String = Nothing
        Dim secondposition As String = Nothing
        Dim rating As Integer = Nothing
        Dim currentteam As String = Nothing
        Dim salary As Integer = Nothing
        Dim contractuntil As Integer = Nothing
        Dim rotationnumber As Integer = Nothing
        Dim rotationminutes As Integer = Nothing
        Dim pointslastgame As Integer = Nothing

        Dim players As PlayersList = New PlayersList()

        For Each datarow As DataRow In result.Rows

            For j = 0 To result.Columns.Count - 1

                Select Case result.Columns(j).ColumnName
                    Case "FirstName"
                        firstname = datarow(j)
                    Case "LastName"
                        lastname = datarow(j)
                    Case "Birthday"
                        birthday = datarow(j)
                    Case "Nationality"
                        nationality = datarow(j)
                    Case "Size"
                        size = datarow(j)
                    Case "Weight"
                        weight = datarow(j)
                    Case "Position"
                        position = datarow(j)
                    Case "SecondPosition"
                        If Not datarow(j) Is DBNull.Value Then
                            secondposition = datarow(j)
                        End If
                    Case "Rating"
                        rating = datarow(j)
                    Case "CurrentTeam"
                        If Not datarow(j) Is DBNull.Value Then
                            currentteam = datarow(j)
                        End If
                    Case "Salary"
                        If Not datarow(j) Is DBNull.Value Then
                            salary = datarow(j)
                        End If
                    Case "ContractUntil"
                        If Not datarow(j) Is DBNull.Value Then
                            contractuntil = datarow(j)
                        End If
                    Case "RotationNumber"
                        If Not datarow(j) Is DBNull.Value Then
                            rotationnumber = datarow(j)
                        End If
                    Case "RotationMinutes"
                        If Not datarow(j) Is DBNull.Value Then
                            rotationminutes = datarow(j)
                        End If
                    Case "PointsLastGame"
                        If Not datarow(j) Is DBNull.Value Then
                            pointslastgame = datarow(j)
                        End If
                End Select
            Next
            players.Players.Add(New Player(firstname, lastname, birthday, nationality, size, weight, position, secondposition, rating, currentteam, _
                                           salary, contractuntil, rotationnumber, rotationminutes, New OffersList, pointslastgame))
        Next
        AllPlayers = players

        For i = 0 To AllPlayers.Players.Count - 1

            If AllPlayers.Players(i).PlayerCurrentTeam = Nothing Then
                AvailablePlayers.Players.Add(AllPlayers.Players(i))
            End If
        Next

    End Sub

    Private Sub GetGames(ByVal result As DataTable, ByVal number As Integer)

        Dim opponenthome As String = Nothing
        Dim opponentguest As String = Nothing

        Dim games As GamesList = New GamesList()

        For Each datarow As DataRow In result.Rows

            For j = 0 To result.Columns.Count - 1

                Select Case result.Columns(j).ColumnName
                    Case "OpponentHome"
                        opponenthome = datarow(j)
                    Case "OpponentGuest"
                        opponentguest = datarow(j)
                End Select
            Next

            Dim opponenthometeam As Team = New Team()
            Dim opponentguestteam As Team = New Team()

            For i = 0 To AllTeams.Teams.Count - 1

                If opponenthome = AllTeams.Teams(i).TeamName Then
                    opponenthometeam = AllTeams.Teams(i)
                End If
                If opponentguest = AllTeams.Teams(i).TeamName Then
                    opponentguestteam = AllTeams.Teams(i)
                End If
            Next

            games.Games.Add(New Game(opponenthometeam, opponentguestteam, New Score()))
            AllGames.Games.Add(New Game(opponenthometeam, opponentguestteam, New Score()))
        Next

        Select Case number
            Case 1
                _allGames1 = games
            Case 2
                _allGames2 = games
        End Select
    End Sub

    Private Sub GetAllTeams(ByVal result As DataTable)

        Dim name As String = Nothing
        Dim money As Integer = Nothing
        Dim wins As Integer = Nothing
        Dim losses As Integer = Nothing
        Dim additionalsalary As Integer = Nothing

        Dim teams As TeamsList = New TeamsList()

        For Each datarow As DataRow In result.Rows

            For j = 0 To result.Columns.Count - 1

                Select Case result.Columns(j).ColumnName
                    Case "Name"
                        name = datarow(j)
                    Case "Money"
                        money = datarow(j)
                    Case "Wins"
                        wins = datarow(j)
                    Case "Losses"
                        losses = datarow(j)
                    Case "AdditionalSalary"
                        additionalsalary = datarow(j)
                End Select
            Next

            Dim teamplayers As PlayersList = New PlayersList()

            For i = 0 To AllPlayers.Players.Count - 1

                If name = AllPlayers.Players(i).PlayerCurrentTeam Then

                    teamplayers.Players.Add(AllPlayers.Players(i))
                End If
            Next

            Dim teamcoach As Coach = New Coach()

            For i = 0 To AllCoaches.Coaches.Count - 1

                If name = AllCoaches.Coaches(i).CoachCurrentTeam Then

                    teamcoach = AllCoaches.Coaches(i)
                End If
            Next

            teams.Teams.Add(New Team(name, teamplayers, teamcoach, money, wins, losses, additionalsalary))
        Next
        AllTeams = teams
    End Sub

    Private Sub GetAllCoaches(ByVal result As DataTable)

        Dim firstname As String = Nothing
        Dim lastname As String = Nothing
        Dim birthday As String = Nothing
        Dim nationality As String = Nothing
        Dim rating As Integer = Nothing
        Dim currentteam As String = Nothing
        Dim salary As Integer = Nothing

        Dim coaches As CoachesList = New CoachesList()

        For Each datarow As DataRow In result.Rows

            For j = 0 To result.Columns.Count - 1

                Select Case result.Columns(j).ColumnName
                    Case "FirstName"
                        firstname = datarow(j)
                    Case "LastName"
                        lastname = datarow(j)
                    Case "Birthday"
                        birthday = datarow(j)
                    Case "Nationality"
                        nationality = datarow(j)
                    Case "Rating"
                        rating = datarow(j)
                    Case "CurrentTeam"
                        If Not datarow(j) Is DBNull.Value Then
                            currentteam = datarow(j)
                        End If
                    Case "Salary"
                        If Not datarow(j) Is DBNull.Value Then
                            salary = datarow(j)
                        End If
                End Select
            Next
            coaches.Coaches.Add(New Coach(firstname, lastname, birthday, nationality, rating, currentteam, salary, New OffersList()))
        Next
        AllCoaches = coaches

        For i = 0 To AllCoaches.Coaches.Count - 1

            If AllCoaches.Coaches(i).CoachCurrentTeam = Nothing Then

                AvailableCoaches.Coaches.Add(AllCoaches.Coaches(i))
            End If
        Next

    End Sub

End Class

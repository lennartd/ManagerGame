Imports System.IO
Imports System.Xml.Serialization

Public Class XmlHandler

    Public Sub Save(ByVal path As String)

        AllClassesContainer = New ClassesContainer(AllCoaches, AllDaysOfPlay, AllEmails, AllGames, AllOffers, AllPlayers, AllTeams, AllPublicProperties, _
                                           AllRemainingMinutes, AvailablePlayers, AvailableCoaches, AllPlayersWithOffers)

        'Serialize object to a text file.
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(AllClassesContainer.GetType())
        Try
            x.Serialize(objStreamWriter, AllClassesContainer)
        Catch ex As Exception
            MsgBox("Fehler beim Schreiben der Datei!")
        End Try

        objStreamWriter.Close()
    End Sub


    Public Sub Load(ByVal path As String)

        'Deserialize text file to a new object.
        Dim classescontainer As New ClassesContainer
        Dim objStreamReader As New StreamReader(path)
        Dim x As New XmlSerializer(classescontainer.GetType())
        Try
            classescontainer = x.Deserialize(objStreamReader)
        Catch ex As Exception
            MsgBox("Fehler beim Lesen der Datei!")
        End Try

        objStreamReader.Close()

        classescontainer.InitializeOriginalObjects()
        AllClassesContainer = classescontainer

    End Sub


End Class

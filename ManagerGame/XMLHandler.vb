Imports System.IO
Imports System.Xml.Serialization

Public Class XmlHandler

    Public Sub Save(ByVal path As String)

        AllClassesContainer = New ClassesContainer(AllCoaches, AllDaysOfPlay, AllEmails, AllGames, AllOffers, AllPlayers, AllTeams, AllPublicProperties, _
                                           AllRemainingMinutes, AvailablePlayers, AvailableCoaches, AllPlayersWithOffers)

        'Serialize object to a text file.
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(AllClassesContainer.GetType())
        x.Serialize(objStreamWriter, AllClassesContainer)
        objStreamWriter.Close()
    End Sub


    Public Sub Load(ByVal path As String)

        'Deserialize text file to a new object.
        Dim classescontainer As New ClassesContainer
        Dim objStreamReader As New StreamReader(path)
        Dim x As New XmlSerializer(classescontainer.GetType())
        classescontainer = x.Deserialize(objStreamReader)
        objStreamReader.Close()

        classescontainer.InitializeOriginalObjects()
        AllClassesContainer = classescontainer

    End Sub


End Class

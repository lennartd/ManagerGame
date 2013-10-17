Imports System.IO

Public Class SaveWindow

    Private Sub SaveWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded

        If Not Directory.Exists(SaveDirectory) Then
            Directory.CreateDirectory(SaveDirectory)
        End If

        ' make a reference to a directory
        Dim directoryInfo As New DirectoryInfo(SaveDirectory)
        Dim fileInfos As FileInfo() = directoryInfo.GetFiles()

        'list the names of all files in the specified directory
        Dim savedfiledlist As List(Of String) = (From fileInfo In fileInfos Select fileInfo.Name.Split(".")(0)).ToList()

        lstbxSavedItems.DataContext = savedfiledlist
    End Sub

    Private Sub lstbxSavedItems_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles lstbxSavedItems.SelectionChanged
        txtbxFileName.Text = lstbxSavedItems.SelectedItem
    End Sub

    Private Sub btnSave_Click(sender As Object, e As RoutedEventArgs)

        Dim filename = SaveDirectory & "\" & txtbxFileName.Text & ".xml"

        If CheckFilename(filename) = False Then
            MsgBox("Ungültiger Dateiname!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Try
            Dim xmlhandler As New XmlHandler
            xmlhandler.Save(filename)
        Catch ex As Exception
            MsgBox("Fehler beim Speichern der Datei! Bitte erneut versuchen!")
            Saved = False
            Exit Sub
        End Try

        Saved = True
        Application.Current.Shutdown()
    End Sub
End Class

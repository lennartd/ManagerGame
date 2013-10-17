Imports System.IO

Public Class LoadWindow

    Private Sub LoadWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded

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

    Private Sub btnLoad_Click(sender As Object, e As RoutedEventArgs)

        Dim filename = SaveDirectory & "\" & lstbxSavedItems.SelectedItem.ToString() & ".xml"

        Try
            Dim xmlhandler As New XmlHandler
            xmlhandler.Load(filename)
        Catch ex As Exception
            MsgBox("Fehler beim Laden der Datei! Bitte erneut versuchen!")
            Exit Sub
        End Try

        Dim mainwindow = TryCast(Application.Current.Windows.Cast(Of Window)().FirstOrDefault(Function(window) TypeOf window Is MainWindow), MainWindow)
        mainwindow.Hide()

        Close()

        Dim w As New GameWindow
        w.Show()
    End Sub
End Class

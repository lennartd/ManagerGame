' ReSharper disable once CheckNamespace
Class MainWindow

    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded

        DataContext = AllTeams.Teams(0)
    End Sub

    Private Sub btnNewGame_Click(sender As Object, e As RoutedEventArgs)
        Dim w As New NewGameWindow
        w.Show()
    End Sub

    Private Sub btnLoadGame_Click(sender As Object, e As RoutedEventArgs)

    End Sub
End Class

Public Class EmailsWindow

    Private Sub EmailsWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded

        lstbxAllEmails.DataContext = AllEmails
    End Sub
End Class

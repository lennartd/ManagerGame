Public Class EmailsWindow

    Private Sub EmailsWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded

        lstbxAllEmails.DataContext = AllEmails

        lstbxAllEmails.SelectedIndex = 0
    End Sub

    Private Sub lstbxAllEmails_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)

        Dim selectedIndex As Integer = lstbxAllEmails.SelectedIndex

        grdCurrentEmail.DataContext = AllEmails.Emails(selectedIndex)
    End Sub

End Class

Public Class EmailToMessageConverter
    Implements IValueConverter

    Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As Globalization.CultureInfo) As Object Implements IValueConverter.Convert
        Dim emails As ObjectModel.ObservableCollection(Of Email) = DirectCast(value, ObjectModel.ObservableCollection(Of Email))
        Dim newEmails As Integer = 0
        For i = 0 To emails.Count - 1
            If emails(i).EmailRead = False Then
                newEmails += 1
            End If
        Next
        If newEmails = 1 Then
            Return newEmails & " neue Nachricht."
        Else
            Return newEmails & " neue Nachrichten."
        End If

    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
        Return Nothing
    End Function
End Class
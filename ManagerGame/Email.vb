Imports System.ComponentModel

Public Class Email
    Implements INotifyPropertyChanged

    Public Sub New()

    End Sub

    Public Sub New(ByVal dateOfEmail As Date, ByVal from As String, ByVal subject As String, ByVal content As String)
        _date = dateOfEmail : _from = from : _subject = subject : _content = content
    End Sub

    Private _date As Date
    Public Property EmailDate() As Date
        Get
            Return _date
        End Get
        Set(ByVal value As Date)
            _date = value
            RaiseProp("EmailDate")
        End Set
    End Property

    Private _from As String
    Public Property EmailFrom() As String
        Get
            Return _from
        End Get
        Set(ByVal value As String)
            _from = value
            RaiseProp("EmailFrom")
        End Set
    End Property

    Private _subject As String
    Public Property EmailSubject() As String
        Get
            Return _subject
        End Get
        Set(ByVal value As String)
            _subject = value
            RaiseProp("EmailSubject")
        End Set
    End Property

    Private _content As String
    Public Property EmailContent() As String
        Get
            Return _content
        End Get
        Set(ByVal value As String)
            _content = value
            RaiseProp("EmailContent")
        End Set
    End Property


    Public Sub RaiseProp(ByVal propertie As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertie))
    End Sub

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

End Class

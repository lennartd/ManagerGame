' ReSharper disable once CheckNamespace
Module PublicVariablesContainer

    Public AllPublicProperties As PublicProperties


    Public CurrentTeamIndex As Integer

    Public AllRemainingMinutes As RemainingMinutesList

    Public AllPlayersWithOffers As PlayersList

    Public CurrentDate As Date

    Public Function GetTransferMethods(ByVal status As Integer)

        '__________________________
        '
        '0 : OfferMade
        '1 : RedemptionDeclined
        '2 : RedemptionAccepted
        '3 : SalaryDeclined
        '4 : SalaryAccepted
        '5 : TransferSucessfull
        '6 : TransferFailed
        '
        '__________________________

        Dim methodsBiddingTeam As New List(Of String)
        Dim methodsCurrentTeam As New List(Of String)

        Select Case status

            Case 0
                methodsBiddingTeam.Add("Angebot zurückziehen")

                methodsCurrentTeam.Add("Ablösesumme zustimmen")
                methodsCurrentTeam.Add("Höhere Ablösesumme fordern")
                methodsCurrentTeam.Add("Transfer ablehnen")

            Case 1
                methodsBiddingTeam.Add("Angebot zurückziehen")
                methodsBiddingTeam.Add("Ablösesumme erhöhen")

                methodsCurrentTeam.Add("Transfer ablehnen")
            Case 2
                methodsBiddingTeam.Add("Angebot zurückziehen")
            Case 3
                methodsBiddingTeam.Add("Gehalt erhöhen")
                methodsBiddingTeam.Add("Angebot zurückziehen")
            Case 4
                methodsBiddingTeam.Add("Transfer zustimmen")
                methodsBiddingTeam.Add("Angebot zurückziehen")
        End Select

        Dim methodsListArray(1) As List(Of String)
        methodsListArray(0) = methodsBiddingTeam
        methodsListArray(1) = methodsCurrentTeam

        Return methodsListArray
    End Function


    Public Function GetPlayerPositionNumber(ByVal playerPosition As String) As Integer

        Select Case playerPosition
            Case "PG"
                Return 1
            Case "SG"
                Return 2
            Case "SF"
                Return 3
            Case "PF"
                Return 4
            Case "C"
                Return 5
            Case Else
                Return Nothing
        End Select
    End Function

    Public Function CheckRedemption(ByVal rating As Integer, ByVal redemption As Integer) As Boolean
        'return true if appropriate according to rating, else return false

        'TODO: adapt factor!
        Const factor As Integer = 1500 'rating to appropriate redemption

        If (rating * factor) > redemption Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function CheckSalary(ByVal rating As Integer, ByVal salary As Integer) As Boolean
        'return true if appropriate according to rating, else return false

        'TODO: adapt factor!
        Const factor As Integer = 1000 'rating to appropriate salary

        If (rating * factor) > salary Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Sub SendEmail(ByVal from As String, ByVal type As Integer, ByVal offer As Offer)
        '__________________________
        '
        '0 : OfferMade
        '1 : RedemptionDeclined
        '2 : RedemptionAccepted
        '3 : SalaryDeclined
        '4 : SalaryAccepted
        '5 : TransferSucessfull
        '6 : TransferFailed
        '
        '__________________________

        Dim subject As String = "Transferverhandlungen über " & offer.OfferPlayerName
        Dim content As String = "Sehr geehrte Damen und Herren," & vbNewLine & vbNewLine

        Select Case type
            Case 0
                Throw New NotImplementedException
            Case 1
                content = content & "leider müssen wir Ihr Angebot an " & offer.OfferPlayerName & " aufgrund einer zu niedrigen Ablösesumme ablehnen."
            Case 2
                content = content & "wir nehmen Ihre Ablösesumme an. Nun muss jedoch noch " & offer.OfferPlayerName & " über das angebotene Gehalt entscheiden."
            Case 3
                content = content & offer.OfferPlayerName & " hat Ihr angebotenes Gehalt als zu niedrig empfunden. Bitte machen Sie ein neues Angebot."
            Case 4
                content = content & offer.OfferPlayerName & " hat Ihr angebotenes Gehalt angenommen und würde sich freuen, wenn er Teil Ihres Teams werden könnte. Sie müssen dem Transfer nur noch final zustimmen."
            Case 5
                content = content & offer.OfferPlayerName & "ist heute zum Team gestoßen und ist ab sofort einsatzbereit."
            Case 6
                content = content & "die Transferverhandlungen über " & offer.OfferPlayerName & "sind gescheitert."
        End Select

        content = content & vbNewLine & "Mit freundlichen Grüßen"

        AllEmails.Emails.Add(New Email(CurrentDate, from, subject, content, False))
    End Sub

End Module

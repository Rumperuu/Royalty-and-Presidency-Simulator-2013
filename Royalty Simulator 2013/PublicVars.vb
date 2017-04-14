Module PublicVars

    Public Months(12) As Integer
    Public PhilMode As Boolean = False
    Public Class Player
        Public PhilMode As Boolean = False
        Public Name As String
        Public Age As Integer
        Public DeathAge As Integer = 0
        '1 = male, 0 = female
        Public Gender As Integer
        Public Birthplace As String
        Public Respect As Integer = 50
        Public RuleDays As Integer = 0
        Public RuleMonths As Integer = 0
        Public RuleYears As Integer = 0
        Public Knowledge As Integer = 0
        Public Happiness As Integer = 50
        Public PlebspottingTrips, ResearchSeshes, Holidays, GoodHolidays, BadHolidays, PoloGames, PoloGamesWon, PoloGamesLost, PartiesHosted, GoodPartiesHosted, BadPartiesHosted, FilmNights, GoodFilmNights, BadFilmNights As Integer
        Public CurrGovernment As Integer = 0
        Public ElectionNum As Integer = 0
        Public CurrYear As Integer = 0
        Public CurrMonth As Integer = 0
        Public GDP As Long = 0
        Public Partner As String
        Dim CCount As Integer = 1
        Dim YearsTilElection As Integer = 0
        Dim YearsofGovt As Integer = 0
        Public AbdicationThreats As Integer = 0
        Public GDPTerm As String
        Sub Elections()
            ElectionNum = ElectionNum + 1
            YearsTilElection = CInt(Int(5 * Rnd()) + 1)
            YearsofGovt = 0
            If ThePlayer.Respect <= 20 Then
                CurrGovernment = CInt(Int(10 * Rnd()))
            Else
                CurrGovernment = CInt(Int(9 * Rnd()))
            End If
            DefaultView.lblCurrentParty.Text = "Gov't: " & Government(CurrGovernment)
        End Sub
        Sub GoingsOn()
            CCount = CCount - 1
            If CCount = 0 Then
                ThePlayer.RuleDays = ThePlayer.RuleDays + 1
                If AtWarWithFrance = True Then
                    LivesLost = LivesLost + CInt(Int(40 * Rnd()))
                    AtWarWithFranceForDays = AtWarWithFranceForDays + 1
                End If
                If UnifiedIreland = True Then
                    Dim IRAattack As Integer = CInt(Int(10 * Rnd()))
                    If IRAattack = 1 Then
                        IRAAssassinations = IRAAssassinations + 1
                    End If
                End If
                If ThePlayer.RuleDays > Months(CurrMonth) Then
                    CurrMonth = CurrMonth + 1
                    ThePlayer.RuleDays = 1
                    ThePlayer.RuleMonths = ThePlayer.RuleMonths + 1
                    If AtWarWithFrance = True Then

                        AtWarWithFranceForDays = 1
                        AtWarWithFranceForMonths = AtWarWithFranceForMonths + 1
                    End If
                    If CurrMonth > 11 Then
                        YearsofGovt = YearsofGovt + 1
                        CurrYear = CurrYear + 1
                        ThePlayer.RuleMonths = 0
                        ThePlayer.RuleYears = ThePlayer.RuleYears + 1
                        CurrMonth = 0
                        If (YearsofGovt > YearsTilElection) And (ParliamentDissolved = False) Then
                            Elections()
                        End If
                        If AtWarWithFrance = True Then
                            AtWarWithFranceForMonths = 0
                            AtWarWithFranceForYears = AtWarWithFranceForYears + 1
                        End If
                        ThePlayer.Age = ThePlayer.Age + 1
                        If ThePlayer.Age = ThePlayer.DeathAge Then
                            ThePlayer.Death("Died of Old Age")
                        End If
                    End If
                End If
                If ThePlayer.Gender = 1 Then
                    DefaultView.lblRuleLength.Text = "King for: "
                    Recreation.lblRuleLength.Text = "King for: "
                    ViewCharacter.lblRuleLength.Text = "King for: "
                ElseIf ThePlayer.Gender = 0 Then
                    DefaultView.lblRuleLength.Text = "Queen for: "
                    Recreation.lblRuleLength.Text = "Queen for: "
                    ViewCharacter.lblRuleLength.Text = "Queen for: "
                End If
                DefaultView.lblRuleLength.Text = DefaultView.lblRuleLength.Text & ThePlayer.RuleDays & " days, " & ThePlayer.RuleMonths & " months, " & ThePlayer.RuleYears & " years"
                DefaultView.lblDate.Text = ThePlayer.RuleDays & " " & TheMonth(CurrMonth) & " " & CurrYear
                Recreation.lblRuleLength.Text = Recreation.lblRuleLength.Text & ThePlayer.RuleDays & " days, " & ThePlayer.RuleMonths & " months, " & ThePlayer.RuleYears & " years"
                Recreation.lblDate.Text = ThePlayer.RuleDays & " " & TheMonth(CurrMonth) & " " & CurrYear
                ViewCharacter.lblRuleLength.Text = ViewCharacter.lblRuleLength.Text & ThePlayer.RuleDays & " days, " & ThePlayer.RuleMonths & " months, " & ThePlayer.RuleYears & " years"
                ViewCharacter.lblDate.Text = ThePlayer.RuleDays & " " & TheMonth(CurrMonth) & " " & CurrYear

                If AtWarWithFrance = True Then
                    AtWarWithFranceFor = AtWarWithFranceForDays & " days, " & AtWarWithFranceForMonths & " months, " & AtWarWithFranceForYears & " years"
                End If

                CCount = 10

                Randomize()

                '0 = increase, 1 = decrease
                Dim IncDecGDP As Integer = CInt(Int(2 * Rnd()))
                If IncDecGDP = 0 Then
                    GDP = GDP + CInt(Int(100000 * Rnd()))
                ElseIf IncDecGDP = 1 Then
                    GDP = GDP - CInt(Int(100000 * Rnd()))
                End If

                DefaultView.lblGDP.Text = GDPTerm & GDP.ToString("###,###,###,###")
            End If
        End Sub
        Public Sub Death(ByVal CauseofDeath As String)
            MusicPlayer.PlayDeath()
            DefaultView.Close()
            ViewCharacter.Close()
            Recreation.Close()
            DeathForm.lblCauseofDeath.Text = "GAME OVER: " & CauseofDeath
            DeathForm.Show()
        End Sub
        '//DECREES\\ 
        Public ParliamentDissolved As Boolean = False
        Public YearParliamentDissolved As Integer
        Public CommonersExecuted As Integer = 0
        Public AtWarWithFrance As Boolean = False
        Public AtWarWithFranceForDays As Integer = 0
        Public AtWarWithFranceForMonths As Integer = 0
        Public AtWarWithFranceForYears As Integer = 0
        Public AtWarWithFranceFor As String = "0 days, 0 months, 0 years"
        Public YearWarDeclared As Integer = 0
        Public LivesLost As Integer = 0
        Public MonumentsErected As Integer = 0
        Public ArgieButthurtLevel As Integer = -1
        Public FalklandMonumentsWeight As Integer = 0
        Public SunkFalklands As Boolean = False
        Public UnifiedIreland As Boolean = False
        Public AttemptstoUnifyIreland As Integer = 0
        Public LivesLostIreland As Integer = 0
        Public YearIrelandUnified As Integer = 0
        Public IRAAssassinations As Integer = 0
        Public PercentageofHorseConsuls As Integer = 0
        Public PercentageEmpireRetaken As Integer = 0
        Public CanadaRetaken As Integer = 0
        Public ColoniesRetaken As Integer = 0
        Public CarribeanRetaken As Integer = 0
        Public SouthAfricaRetaken As Integer = 0
        Public OtherAfricaRetaken As Integer = 0
        Public MiddleEastRetaken As Integer = 0
        Public IndiaRetaken As Integer = 0
        Public OtherAsiaRetaken As Integer = 0
        Public AustraliaRetaken As Integer = 0
        Public WorldTaken As Integer = 0
        Public AttemptstoRetakeEmpire As Integer = 0
        Public AttemptstoTakeWorld As Integer = 0
        Public LivesLostEmpire As Integer = 0
        Public LivesLostTakeWorld As Integer = 0
        Public YearEmpireRetaken As Integer = 0
        Public YearWorldTaken As Integer = 0
        Public ChurchesFormed As Integer
        Public MadeofGlass As Boolean = False
        Public WivesBeheaded As Integer = 0
        Public ThingsDeclaredPunishableByDeath As Integer = 0
    End Class
    Public CanadaVal As Integer = 15
    Public ColoniesVal As Integer = 9
    Public CarribeanVal As Integer = 8
    Public SouthAfricaVal As Integer = 12
    Public OtherAfricaVal As Integer = 14
    Public MiddleEastVal As Integer = 13
    Public IndiaVal As Integer = 15
    Public OtherAsiaVal As Integer = 9
    Public AustraliaVal As Integer = 5
    Public Government(10) As String
    Public TheMonth(12) As String
    Public ArgieButthurt(14) As String
    Public ThePlayer As New Player
    Sub ResizeText(ByVal lblLabel As Label)
        Dim f As Font
        Dim g As Graphics
        Dim s As SizeF
        Dim Faktor, FaktorX, FaktorY As Single

        If lblLabel.Text.Length = 0 Then Return

        g = lblLabel.CreateGraphics
        s = g.MeasureString(lblLabel.Text, lblLabel.Font, lblLabel.Width)
        g.Dispose()

        FaktorX = lblLabel.Width / s.Width
        FaktorY = lblLabel.Height / s.Height

        If FaktorX > FaktorY Then
            Faktor = FaktorY
        Else
            Faktor = FaktorX
        End If

        f = lblLabel.Font
        lblLabel.Font = New Font(f.Name, f.SizeInPoints * Faktor)
    End Sub
    Public Sub HappinessCheck()
        If ThePlayer.Happiness <= 0 Then
            ThePlayer.Death("You Committed Suicide")
        End If
    End Sub
    Public Sub RespectCheck()
        If ThePlayer.Respect <= 0 Then
            If ThePlayer.ParliamentDissolved = False Then
                ThePlayer.Death("Republic of the British Isles Formed, Monarch Ousted")
            ElseIf ThePlayer.ParliamentDissolved = True Then
                ThePlayer.Death("English Revolution, Monarch Beheaded")
            End If
        End If
    End Sub
    Public Sub NewPlayer()
        With ThePlayer
            .DeathAge = 0
            .Respect = 50
            .RuleDays = 1
            .RuleMonths = 0
            .RuleYears = 0
            .Knowledge = 0
            .Happiness = 50
            .PlebspottingTrips = 0
            .ResearchSeshes = 0
            .Holidays = 0
            .GoodHolidays = 0
            .BadHolidays = 0
            .PoloGames = 0
            .PoloGamesWon = 0
            .PoloGamesLost = 0
            .PartiesHosted = 0
            .GoodPartiesHosted = 0
            .BadPartiesHosted = 0
            .FilmNights = 0
            .GoodFilmNights = 0
            .BadFilmNights = 0
            .CurrGovernment = 0
            .ElectionNum = 0
            .CurrYear = 0
            .CurrMonth = 0
            .GDP = 2316000000000
            .AbdicationThreats = 0
            .GDPTerm = "GDP: $"
            '//DECREES\\ 
            .ParliamentDissolved = False
            .YearParliamentDissolved = 0
            .CommonersExecuted = 0
            .AtWarWithFrance = False
            .AtWarWithFranceForDays = 0
            .AtWarWithFranceForMonths = 0
            .AtWarWithFranceForYears = 0
            .AtWarWithFranceFor = "0 days, 0 months, 0 years"
            .YearWarDeclared = 0
            .LivesLost = 0
            .MonumentsErected = 0
            .ArgieButthurtLevel = -1
            .FalklandMonumentsWeight = 0
            .SunkFalklands = False
            .UnifiedIreland = False
            .AttemptstoUnifyIreland = 0
            .LivesLostIreland = 0
            .YearIrelandUnified = 0
            .IRAAssassinations = 0
            .PercentageofHorseConsuls = 0
            .PercentageEmpireRetaken = 0
            .CanadaRetaken = 0
            .ColoniesRetaken = 0
            .CarribeanRetaken = 0
            .SouthAfricaRetaken = 0
            .OtherAfricaRetaken = 0
            .MiddleEastRetaken = 0
            .IndiaRetaken = 0
            .OtherAsiaRetaken = 0
            .AustraliaRetaken = 0
            .WorldTaken = 0
            .AttemptstoTakeWorld = 0
            .AttemptstoRetakeEmpire = 0
            .LivesLostEmpire = 0
            .LivesLostTakeWorld = 0
            .YearEmpireRetaken = 0
            .YearWorldTaken = 0
            .ChurchesFormed = 0
            .MadeofGlass = False
            .WivesBeheaded = 0
            .ThingsDeclaredPunishableByDeath = 0
        End With
        Dim CCount As Integer = 1
        Dim YearsTilElection = 0
        Dim YearsofGovt = 0
    End Sub
End Module

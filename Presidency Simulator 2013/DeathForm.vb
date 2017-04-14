Public Class DeathForm
    Dim RankVal As Integer = 0
    Dim Rank As Char
    Private Sub DeathForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Populate()

        GetRank()
        If RankVal < 15 Then
            Rank = "F"
            picRank.Image = My.Resources.RankF
        ElseIf (RankVal < 30) And (RankVal >= 15) Then
            Rank = "E"
            picRank.Image = My.Resources.RankE
        ElseIf (RankVal < 45) And (RankVal >= 30) Then
            Rank = "D"
            picRank.Image = My.Resources.RankD
        ElseIf (RankVal < 60) And (RankVal >= 45) Then
            Rank = "C"
            picRank.Image = My.Resources.RankC
        ElseIf (RankVal < 75) And (RankVal >= 60) Then
            Rank = "B"
            picRank.Image = My.Resources.RankB
        ElseIf (RankVal < 90) And (RankVal >= 75) Then
            Rank = "A"
            picRank.Image = My.Resources.RankA
        ElseIf RankVal > 90 Then
            Rank = "S"
            picRank.Image = My.Resources.RankS
        End If
    End Sub

    Private Sub DeathForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        lblCauseofDeath.Location = New Point((Me.Width / 100) * 5, (Me.Height / 100) * 1)

        lstStats.Width = (Me.Width / 100) * 90
        lstStats.Height = (Me.Height / 100) * 80
        lstStats.Location = New Point((Me.Width / 100) * 5, (Me.Height / 100) * 6)
        lstStats.ColumnWidth = lstStats.Width / 2 - ((Me.Width / 100) * 5)

        btnMainMenu.Width = (Me.Width / 7) * 5
        btnMainMenu.Height = (Me.Height / 100) * 10
        btnMainMenu.Location = New Point((Me.Width / 100) * 5, (Me.Height / 100) * 87)

        lblRank.Location = New Point((Me.Width / 5) * 4, (Me.Height / 100) * 95)

        picRank.Height = Me.Height / 7
        picRank.Width = picRank.Height
        picRank.Location = New Point((Me.Width / 10) * 9, (Me.Height / 100) * 85)
    End Sub
    Sub GetRank()
        If ThePlayer.Happiness > 100 Then
            ThePlayer.Happiness = 100
        End If
        RankVal = RankVal + (ThePlayer.Happiness / 10)

        If ThePlayer.Respect > 150 Then
            ThePlayer.Respect = 150
        End If
        RankVal = RankVal + (ThePlayer.Respect / 10)

        If ThePlayer.Knowledge > 100 Then
            ThePlayer.Knowledge = 100
        End If
        RankVal = RankVal + (ThePlayer.Happiness / 10)

        If (ThePlayer.PlebspottingTrips > 0) Then
            RankVal = RankVal + 2.5
        End If
        If (ThePlayer.ResearchSeshes > 0) Then
            RankVal = RankVal + 1.5
        End If
        If (ThePlayer.Holidays > 0) Then
            RankVal = RankVal + 1.5
        End If
        If (ThePlayer.PoloGames > 0) Then
            RankVal = RankVal + 1.5
        End If
        If (ThePlayer.PartiesHosted > 0) Then
            RankVal = RankVal + 1.5
        End If
        If (ThePlayer.FilmNights > 0) Then
            RankVal = RankVal + 1.5
        End If
        If ThePlayer.ParliamentDissolved = True Then
            RankVal = RankVal + 10
            If ThePlayer.UnifiedIreland = True Then
                RankVal = RankVal + 5
            End If
            If ThePlayer.WorldTaken = True Then
                RankVal = RankVal + 35
            End If
        End If
        If ThePlayer.ArgieButthurtLevel = 13 Then
            RankVal = RankVal + 5
        End If
    End Sub
    Sub Populate()
        Dim Title As String = ""
        Title = "President"
        With lstStats.Items
            .Add("--GENERAL--")
            .Add("Name: " & Title & " " & ThePlayer.Name)
            .Add(Title & " for : " & ThePlayer.RuleDays & " days, " & ThePlayer.RuleMonths & " months, " & ThePlayer.RuleYears & " years")
            .Add("Party: " & ThePlayer.Party)
            .Add("Happiness: " & ThePlayer.Happiness)
            .Add("Respect: " & ThePlayer.Respect)
            .Add("Knowledge: " & ThePlayer.Knowledge)
            .Add("Birthplace: " & ThePlayer.Birthplace)
            .Add(ThePlayer.GDPTerm & ThePlayer.GDP.ToString("###,###,###,###"))
            If ThePlayer.ParliamentDissolved = False Then
                .Add("Current government: " & Government(ThePlayer.CurrGovernment))
            ElseIf ThePlayer.ParliamentDissolved = True Then
                .Add("Current government: Congress dissolved in " & ThePlayer.YearParliamentDissolved)
            End If
            .Add("Number of elections held during reign: " & ThePlayer.ElectionNum)
            .Add("Number of resignation threats: " & ThePlayer.AbdicationThreats)
            .Add("--RECREATION--")
            .Add("Equalspotting trips: " & ThePlayer.PlebspottingTrips)
            .Add("Research sessions: " & ThePlayer.ResearchSeshes)
            .Add("Holidays gone on: " & ThePlayer.Holidays)
            .Add("Good holidays: " & ThePlayer.GoodHolidays)
            .Add("Bad holidays: " & ThePlayer.BadHolidays)
            .Add("NFL games played: " & ThePlayer.PoloGames)
            .Add("NFL games won: " & ThePlayer.PoloGamesWon)
            .Add("NFL games lost: " & ThePlayer.PoloGamesLost)
            .Add("Sick White House parties hosted: " & ThePlayer.PartiesHosted)
            .Add("Successful parties: " & ThePlayer.GoodPartiesHosted)
            .Add("Unsuccessful parties: " & ThePlayer.BadPartiesHosted)
            .Add("Film nights in with the " & ThePlayer.Partner & ": " & ThePlayer.FilmNights)
            .Add("Good film nights: " & ThePlayer.GoodFilmNights)
            .Add("Bad film nights: " & ThePlayer.GoodFilmNights)
            .Add("--DECREES--")
            .Add("Commoners executed: " & ThePlayer.CommonersExecuted)
            If ThePlayer.AtWarWithFrance = True Then
                .Add("At war with Communism: Of course!")
                .Add("At war with Communism for: " & ThePlayer.AtWarWithFranceFor)
                .Add("Lives lost in the unending America-Communism War of " & ThePlayer.YearWarDeclared & ": " & ThePlayer.LivesLost)
            ElseIf (ThePlayer.AtWarWithFrance = False) And (ThePlayer.WorldTaken = True) And (ThePlayer.AtWarWithFranceForDays > 0) Then
                .Add("At war with Communism: Communism? Do you mean New Capitalism?")
                .Add("At war with France for: " & ThePlayer.AtWarWithFranceFor)
                .Add("Lives lost in the now-ended America-Communism War of " & ThePlayer.YearWarDeclared & ": " & ThePlayer.LivesLost)
            ElseIf (ThePlayer.AtWarWithFrance = False) And (ThePlayer.WorldTaken = True) And (ThePlayer.AtWarWithFranceForDays = 0) Then
                .Add("At war with Communism: Communism? Do you mean New Capitalism?")
            ElseIf (ThePlayer.AtWarWithFrance = False) And (ThePlayer.WorldTaken = False) Then
                .Add("At war with Communism: No")
            End If
            If ThePlayer.MonumentsErected > 0 Then
                If ThePlayer.SunkFalklands = False Then
                    .Add("Monuments erected on Texas: " & ThePlayer.MonumentsErected)
                    .Add("Weight of Texas monuments: " & ThePlayer.FalklandMonumentsWeight & "kg")
                ElseIf ThePlayer.SunkFalklands = True Then
                    .Add("Monuments erected on the former Texas: " & ThePlayer.MonumentsErected)
                    .Add("Weight of Texas monuments: Unknown")
                End If
                .Add("Mexican butthurt level: " & ArgieButthurt(ThePlayer.ArgieButthurtLevel))
            End If
            If ThePlayer.UnifiedIreland = True Then
                .Add("Dakotas united: Finally")
                .Add("Year Dakotas unified: " & ThePlayer.YearIrelandUnified)
                .Add("Attempts to unify Dakotas: " & ThePlayer.AttemptstoUnifyIreland)
                .Add("Lives lost attempting to unify the Dakotas: " & ThePlayer.LivesLostIreland)
                .Add("Dakotan nationalist assassinations: " & ThePlayer.IRAAssassinations)
            ElseIf ThePlayer.UnifiedIreland = False Then
                .Add("Dakotas united: No")
                If ThePlayer.AttemptstoUnifyIreland > 0 Then
                    .Add("Attempts to unify Dakotas: " & ThePlayer.AttemptstoUnifyIreland)
                    .Add("Lives lost attempting to unify the Dakotas: " & ThePlayer.LivesLostIreland)
                End If
            End If
            .Add("Percentage of equine consuls: " & ThePlayer.PercentageofHorseConsuls & "%")
            If ThePlayer.WorldTaken = 1 Then
                .Add("World taken: USA! USA!")
            ElseIf ThePlayer.WorldTaken = 0 Then
                .Add("World taken: Working on it")
            End If
            .Add("Attempts to take over the world: " & ThePlayer.AttemptstoTakeWorld)
            .Add("Lives lost taking over the world: " & ThePlayer.LivesLostTakeWorld)
            If ThePlayer.WorldTaken = 1 Then
                .Add("Year world taken over: " & ThePlayer.YearWorldTaken)
            End If

            .Add("Churches formed: " & ThePlayer.ChurchesFormed)
            If ThePlayer.MadeofGlass = True Then
                .Add("Gone snooker loopy: Yes")
            ElseIf ThePlayer.MadeofGlass = False Then
                .Add("Gone snooker loopy: Not completely")
            End If
            .Add(ThePlayer.Partner & "s beheaded: " & ThePlayer.WivesBeheaded)
            .Add("Things declared punishable by death: " & ThePlayer.ThingsDeclaredPunishableByDeath)
        End With
    End Sub
    Private Sub btnMainMenu_Click(sender As Object, e As EventArgs) Handles btnMainMenu.Click
        MainMenu.Show()
        Me.Close()
    End Sub
End Class
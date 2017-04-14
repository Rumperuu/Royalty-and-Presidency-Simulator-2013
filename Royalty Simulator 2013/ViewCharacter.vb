Public Class ViewCharacter
    Dim Count As Integer = 10
    Private Sub ViewCharacter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ThePlayer.PhilMode = True Then
            picMonarch.Image = My.Resources.KingPhil
        ElseIf ThePlayer.PhilMode = False Then
            If ThePlayer.Gender = 1 Then
                picMonarch.Image = My.Resources.King
            ElseIf ThePlayer.Gender = 0 Then
                picMonarch.Image = My.Resources.Queen
            End If
        End If

        If ThePlayer.Gender = 1 Then
            lblName.Text = "King "
            lblRuleLength.Text = "King for: "
        ElseIf ThePlayer.Gender = 0 Then
            lblName.Text = "Queen "
            lblRuleLength.Text = "Queen for: "
        End If

        lblName.Text = lblName.Text & ThePlayer.Name

        lblRuleLength.Text = lblRuleLength.Text & ThePlayer.RuleDays & " days, " & ThePlayer.RuleMonths & " months, " & ThePlayer.RuleYears & " years"

        PopulateListbox()

        tmrAdvanceDay.Enabled = True
    End Sub
    Private Sub ViewCharacter_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        picMonarch.Width = Screen.PrimaryScreen.Bounds.Height

        pnlMenu.Height = Screen.PrimaryScreen.Bounds.Height
        pnlMenu.Width = (Screen.PrimaryScreen.Bounds.Width - picMonarch.Width)
        pnlMenu.Location = New Point(picMonarch.Width, pnlMenu.Location.Y)

        lblName.Location = New Point((pnlMenu.Width / 100) * 10, (pnlMenu.Height / 100) * 6)

        lblRuleLength.Location = New Point((pnlMenu.Width / 100) * 10, (pnlMenu.Height / 100) * 9)

        lblDate.Location = New Point((pnlMenu.Width - lblDate.Width) - ((pnlMenu.Width / 100) * 10), (pnlMenu.Height / 100) * 6)

        btnBack.Width = pnlMenu.Width / 2
        btnBack.Location = New Point((pnlMenu.Width / 100) * 25, (pnlMenu.Height / 100) * 92)

        lstStats.Height = pnlMenu.Height - (pnlMenu.Height / 4)
        lstStats.Width = pnlMenu.Width - ((pnlMenu.Width / 100) * 20)
        lstStats.Location = New Point((pnlMenu.Width / 100) * 10, (pnlMenu.Height / 100) * 14)
    End Sub

    Private Sub tmrAdvanceDay_Tick(sender As Object, e As EventArgs) Handles tmrAdvanceDay.Tick
        ThePlayer.GoingsOn()
    End Sub

    Sub PopulateListbox()
        With lstStats.Items
            .Add("--GENERAL--")
            .Add("Happiness: " & ThePlayer.Happiness)
            .Add("Respect: " & ThePlayer.Respect)
            .Add("Knowledge: " & ThePlayer.Knowledge)
            .Add("Birthplace: " & ThePlayer.Birthplace)
            .Add(ThePlayer.GDPTerm & ThePlayer.GDP.ToString("###,###,###,###"))
            If ThePlayer.ParliamentDissolved = False Then
                .Add("Current government: " & Government(ThePlayer.CurrGovernment))
            ElseIf ThePlayer.ParliamentDissolved = True Then
                .Add("Current government: Parliament dissolved in " & ThePlayer.YearParliamentDissolved)
            End If
            .Add("Number of elections held during reign: " & ThePlayer.ElectionNum)
            .Add("Number of abdication threats: " & ThePlayer.AbdicationThreats)
            .Add("--RECREATION--")
            .Add("Plebspotting trips: " & ThePlayer.PlebspottingTrips)
            .Add("Research sessions: " & ThePlayer.ResearchSeshes)
            .Add("Holidays gone on: " & ThePlayer.Holidays)
            .Add("Good holidays: " & ThePlayer.GoodHolidays)
            .Add("Bad holidays: " & ThePlayer.BadHolidays)
            .Add("Polo games played: " & ThePlayer.PoloGames)
            .Add("Polo games won: " & ThePlayer.PoloGamesWon)
            .Add("Polo games lost: " & ThePlayer.PoloGamesLost)
            .Add("Sick castle parties hosted: " & ThePlayer.PartiesHosted)
            .Add("Successful parties: " & ThePlayer.GoodPartiesHosted)
            .Add("Unsuccessful parties: " & ThePlayer.BadPartiesHosted)
            .Add("Film nights in with the " & ThePlayer.Partner & ": " & ThePlayer.FilmNights)
            .Add("Good film nights: " & ThePlayer.GoodFilmNights)
            .Add("Bad film nights: " & ThePlayer.GoodFilmNights)
            .Add("--DECREES--")
            .Add("Commoners executed: " & ThePlayer.CommonersExecuted)
            If ThePlayer.AtWarWithFrance = True Then
                .Add("At war with France: Of course!")
                .Add("At war with France for: " & ThePlayer.AtWarWithFranceFor)
                .Add("Lives lost in the unending Anglo-French War of " & ThePlayer.YearWarDeclared & ": " & ThePlayer.LivesLost)
            ElseIf (ThePlayer.AtWarWithFrance = False) And (ThePlayer.WorldTaken = True) And (ThePlayer.AtWarWithFranceForDays > 0) Then
                .Add("At war with France: France? Do you mean New Grimsby?")
                .Add("At war with France for: " & ThePlayer.AtWarWithFranceFor)
                .Add("Lives lost in the now-ended Anglo-French War of " & ThePlayer.YearWarDeclared & ": " & ThePlayer.LivesLost)
            ElseIf (ThePlayer.AtWarWithFrance = False) And (ThePlayer.WorldTaken = True) And (ThePlayer.AtWarWithFranceForDays = 0) Then
                .Add("At war with France: France? Do you mean New Grimsby?")
            ElseIf (ThePlayer.AtWarWithFrance = False) And (ThePlayer.WorldTaken = False) Then
                .Add("At war with France: No")
            End If
            If ThePlayer.MonumentsErected > 0 Then
                If ThePlayer.SunkFalklands = False Then
                    .Add("Monuments erected on the Falklands: " & ThePlayer.MonumentsErected)
                    .Add("Weight of Falklands monuments: " & ThePlayer.FalklandMonumentsWeight & "kg")
                ElseIf ThePlayer.SunkFalklands = True Then
                    .Add("Monuments erected on the former Falklands: " & ThePlayer.MonumentsErected)
                    .Add("Weight of Falklands monuments: Unknown")
                End If
                .Add("Argentine butthurt level: " & ArgieButthurt(ThePlayer.ArgieButthurtLevel))
            End If
            If ThePlayer.UnifiedIreland = True Then
                .Add("Ireland united: Finally")
                .Add("Year Ireland unified: " & ThePlayer.YearIrelandUnified)
                .Add("Attempts to unify Ireland: " & ThePlayer.AttemptstoUnifyIreland)
                .Add("Lives lost attempting to unify Ireland: " & ThePlayer.LivesLostIreland)
                .Add("Republican assassinations: " & ThePlayer.IRAAssassinations)
            ElseIf ThePlayer.UnifiedIreland = False Then
                .Add("Ireland united: No")
                If ThePlayer.AttemptstoUnifyIreland > 0 Then
                    .Add("Attempts to unify Ireland: " & ThePlayer.AttemptstoUnifyIreland)
                    .Add("Lives lost attempting to unify Ireland: " & ThePlayer.LivesLostIreland)
                End If
            End If
            .Add("Percentage of equine consuls: " & ThePlayer.PercentageofHorseConsuls & "%")
            .Add("Percentage of Empire retaken: " & ThePlayer.PercentageEmpireRetaken & "%")
            If ThePlayer.CanadaRetaken = 0 Then
                .Add("Canada status: Free")
            ElseIf ThePlayer.CanadaRetaken = 1 Then
                .Add("Canada status: Under British control")
            End If

            If ThePlayer.ColoniesRetaken = 0 Then
                .Add("Thirteen Colonies status: Free")
            ElseIf ThePlayer.ColoniesRetaken = 1 Then
                .Add("Thirteen Colonies status: Under British control")
            End If
            If ThePlayer.CarribeanRetaken = 0 Then
                .Add("Caribbean status: Free")
            ElseIf ThePlayer.CarribeanRetaken = 1 Then
                .Add("Caribbean status: Under British control")
            End If
            If ThePlayer.SouthAfricaRetaken = 0 Then
                .Add("South Africa status: Free")
            ElseIf ThePlayer.SouthAfricaRetaken = 1 Then
                .Add("South Africa status: Under British control")
            End If
            If ThePlayer.OtherAfricaRetaken = 0 Then
                .Add("Other bits of Africa status: Free")
            ElseIf ThePlayer.OtherAfricaRetaken = 1 Then
                .Add("Other bits of Africa status: Under British control")
            End If
            If ThePlayer.MiddleEastRetaken = 0 Then
                .Add("Middle-East status: Free")
            ElseIf ThePlayer.MiddleEastRetaken = 1 Then
                .Add("Middle-East status: Under British control")
            End If
            If ThePlayer.IndiaRetaken = 0 Then
                .Add("India status: Free")
            ElseIf ThePlayer.IndiaRetaken = 1 Then
                .Add("India status: Under British control")
            End If
            If ThePlayer.OtherAsiaRetaken = 0 Then
                .Add("Other bits of Asia status: Free")
            ElseIf ThePlayer.OtherAsiaRetaken = 1 Then
                .Add("Other bits of Asia status: Under British control")
            End If
            If ThePlayer.AustraliaRetaken = 0 Then
                .Add("Australia status: Free")
            ElseIf ThePlayer.AustraliaRetaken = 1 Then
                .Add("Australia status: Under British control")
            End If
            If ThePlayer.AttemptstoRetakeEmpire > 0 Then
                .Add("Attempts to retake Empire: " & ThePlayer.AttemptstoRetakeEmpire)
                .Add("Lives lost retaking Empire: " & ThePlayer.LivesLostEmpire)
            End If
            If ThePlayer.PercentageEmpireRetaken = 100 Then
                .Add("Year Empire retaken: " & ThePlayer.YearEmpireRetaken)
                If ThePlayer.WorldTaken = 1 Then
                    .Add("World taken: For England")
                ElseIf ThePlayer.WorldTaken = 0 Then
                    .Add("World taken: Working on it")
                End If
                .Add("Attempts to take over the world: " & ThePlayer.AttemptstoTakeWorld)
                .Add("Lives lost taking over the world: " & ThePlayer.LivesLostTakeWorld)
                If ThePlayer.WorldTaken = 1 Then
                    .Add("Year world taken over: " & ThePlayer.YearWorldTaken)
                End If
            End If
            .Add("Churches formed: " & ThePlayer.ChurchesFormed)
            If ThePlayer.MadeofGlass = True Then
                .Add("Gone snooker loopy: Yes")
            ElseIf ThePlayer.MadeofGlass = False Then
                .Add("Gone snooker loopy: Not completely")
            End If
            .Add("Wives beheaded: " & ThePlayer.WivesBeheaded)
            .Add("Things declared punishable by death: " & ThePlayer.ThingsDeclaredPunishableByDeath)
        End With
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        DefaultView.Show()
        Me.Close()
    End Sub
End Class
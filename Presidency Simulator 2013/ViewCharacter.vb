Public Class ViewCharacter
    Dim Count As Integer = 10
    Private Sub ViewCharacter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ThePlayer.Gender = 1 Then
            picMonarch.Image = My.Resources.King
        ElseIf ThePlayer.Gender = 0 Then
            picMonarch.Image = My.Resources.Queen
        End If

        lblName.Text = "President "
        lblRuleLength.Text = "President for: "

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

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        DefaultView.Show()
        Me.Close()
    End Sub
End Class
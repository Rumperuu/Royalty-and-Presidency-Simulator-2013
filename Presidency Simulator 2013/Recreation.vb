Public Class Recreation
    Dim Count As Integer = 10
    Dim DispGDP As String
    Dim Positiveadjective(10) As String
    Dim Negativeadjective(10) As String
    Dim TooManyParties As Integer
    Dim PartyCount As Integer = 0
    Private Sub Recreation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tmrAdvanceDay.Enabled = True

        If ThePlayer.Gender = 1 Then
            picMonarch.Image = My.Resources.King
        ElseIf ThePlayer.Gender = 0 Then
            picMonarch.Image = My.Resources.Queen
        End If

        btnFilmNight.Text = "Film Night with the " & ThePlayer.Partner & ", Maybe Get Some McDonalds in or Something"
        If ThePlayer.Gender = 1 Then
            lblFilmNight.Text = "FILM NIGHT WITH THE FIRST LADY"
        ElseIf ThePlayer.Gender = 0 Then
            lblFilmNight.Text = "FILM NIGHT WITH THE FIRST GENTLEMAN"
        End If

        lblFilmNightPizzas.Text = "MAYBE GET SOME MCDONALDS IN OR SOMETHING"

        Positiveadjective(0) = " fab"
        Positiveadjective(1) = " jolly"
        Positiveadjective(2) = " good"
        Positiveadjective(3) = " pleasant"
        Positiveadjective(4) = "n enjoyable"
        Positiveadjective(5) = " fun"
        Positiveadjective(6) = "n aight"
        Positiveadjective(7) = "n okay"
        Positiveadjective(8) = " lovely"
        Positiveadjective(9) = " brill"

        Negativeadjective(0) = " negative"
        Negativeadjective(1) = " blunderous"
        Negativeadjective(2) = " naff"
        Negativeadjective(3) = "n unpleasant"
        Negativeadjective(4) = " shoddy"
        Negativeadjective(5) = " poor"
        Negativeadjective(6) = "n awful"
        Negativeadjective(7) = " neutral"
        Negativeadjective(8) = " gypsy-filled"
        Negativeadjective(9) = " shambolic"

        TooManyParties = CInt(Int(10 * Rnd()) + 1)
    End Sub

    Private Sub Recreation_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        picMonarch.Width = Screen.PrimaryScreen.Bounds.Height

        pnlMenu.Height = Screen.PrimaryScreen.Bounds.Height
        pnlMenu.Width = (Screen.PrimaryScreen.Bounds.Width - picMonarch.Width)
        pnlMenu.Location = New Point(picMonarch.Width, pnlMenu.Location.Y)

        lblName.Location = New Point((pnlMenu.Width / 100) * 10, (pnlMenu.Height / 100) * 6)

        lblRuleLength.Location = New Point((pnlMenu.Width / 100) * 10, (pnlMenu.Height / 100) * 9)

        lblDate.Location = New Point((pnlMenu.Width - lblDate.Width) - ((pnlMenu.Width / 100) * 10), (pnlMenu.Height / 100) * 6)

        lblRecreation.Location = New Point((pnlMenu.Width / 2) - (lblRecreation.Width / 2), (pnlMenu.Height / 100) * 12)

        btnPlebspotting.Width = pnlMenu.Width - ((pnlMenu.Width / 100) * 20)
        btnPlebspotting.Location = New Point((pnlMenu.Width / 100) * 10, (pnlMenu.Height / 100) * 20)

        btnResearch.Width = pnlMenu.Width - ((pnlMenu.Width / 100) * 20)
        btnResearch.Location = New Point((pnlMenu.Width / 100) * 10, (pnlMenu.Height / 100) * 32)

        btnHoliday.Width = pnlMenu.Width - ((pnlMenu.Width / 100) * 20)
        btnHoliday.Location = New Point((pnlMenu.Width / 100) * 10, (pnlMenu.Height / 100) * 44)

        btnPolo.Width = pnlMenu.Width - ((pnlMenu.Width / 100) * 20)
        btnPolo.Location = New Point((pnlMenu.Width / 100) * 10, (pnlMenu.Height / 100) * 56)

        btnParty.Width = pnlMenu.Width - ((pnlMenu.Width / 100) * 20)
        btnParty.Location = New Point((pnlMenu.Width / 100) * 10, (pnlMenu.Height / 100) * 68)

        btnFilmNight.Width = pnlMenu.Width - ((pnlMenu.Width / 100) * 20)
        btnFilmNight.Location = New Point((pnlMenu.Width / 100) * 10, (pnlMenu.Height / 100) * 80)

        btnBack.Width = pnlMenu.Width / 2
        btnBack.Location = New Point((pnlMenu.Width / 100) * 25, (pnlMenu.Height / 100) * 92)

        '//RESEARCH\\

        pnlResearch.Height = Screen.PrimaryScreen.Bounds.Height / 3
        pnlResearch.Width = Screen.PrimaryScreen.Bounds.Width / 2.5
        pnlResearch.Location = New Point((Screen.PrimaryScreen.Bounds.Width + 1), (Screen.PrimaryScreen.Bounds.Height + 1))

        picResearch.Width = pnlResearch.Height
        picResearch.Height = picResearch.Width

        lblResearch.Width = pnlResearch.Width - picResearch.Width
        lblResearch.Location = New Point(picResearch.Width, (pnlResearch.Height / 100) * 10)
        ResizeText(lblResearch)

        lblResearchDesc.Width = pnlResearch.Width - picResearch.Width
        lblResearchDesc.Height = (pnlResearch.Height / 100) * 50
        lblResearchDesc.Location = New Point(picResearch.Width, (pnlResearch.Height / 100) * 25)
        ResizeText(lblResearchDesc)

        btnResearchOK.Width = (pnlResearch.Width - picResearch.Width) / 4
        btnResearchOK.Location = New Point(picResearch.Width + (((pnlResearch.Width - picResearch.Width) / 8) * 3), (pnlResearch.Height / 100) * 80)


        '//HOLIDAY\\

        pnlHoliday.Height = Screen.PrimaryScreen.Bounds.Height / 3
        pnlHoliday.Width = Screen.PrimaryScreen.Bounds.Width / 2.5
        pnlHoliday.Location = New Point((Screen.PrimaryScreen.Bounds.Width + 1), (Screen.PrimaryScreen.Bounds.Height + 1))

        picHoliday.Width = pnlHoliday.Height
        picHoliday.Height = pnlHoliday.Width

        lblHoliday.Width = pnlHoliday.Width - picHoliday.Width
        lblHoliday.Location = New Point(picHoliday.Width, (pnlHoliday.Height / 100) * 10)
        ResizeText(lblHoliday)

        lblHolidayWhere.Width = pnlHoliday.Width - picHoliday.Width
        lblHolidayWhere.Location = New Point(picHoliday.Width, (pnlHoliday.Height / 100) * 25)
        ResizeText(lblHolidayWhere)

        cmboHoliday.Width = (pnlHoliday.Width - picHoliday.Width) - ((pnlHoliday.Width - picHoliday.Width) / 100) * 20
        cmboHoliday.Location = New Point(picHoliday.Width + (((pnlHoliday.Width - picHoliday.Width) / 100) * 10), (pnlHoliday.Height / 100) * 40)

        btnHolidayGo.Width = (pnlHoliday.Width - picHoliday.Width) / 4
        btnHolidayGo.Location = New Point(picHoliday.Width + (((pnlHoliday.Width - picHoliday.Width) / 8) * 3), (pnlHoliday.Height / 100) * 55)

        lblHolidayDesc.Width = pnlHoliday.Width - picHoliday.Width
        lblHolidayDesc.Height = (pnlHoliday.Height / 100) * 50
        lblHolidayDesc.Location = New Point(picHoliday.Width, (pnlHoliday.Height / 100) * 25)
        ResizeText(lblHolidayDesc)

        btnHolidayOK.Width = (pnlHoliday.Width - picHoliday.Width) / 4
        btnHolidayOK.Location = New Point(picHoliday.Width + (((pnlHoliday.Width - picHoliday.Width) / 8) * 3), (pnlHoliday.Height / 100) * 80)

        '//POLO\\

        pnlPolo.Height = Screen.PrimaryScreen.Bounds.Height / 3
        pnlPolo.Width = Screen.PrimaryScreen.Bounds.Width / 2.5
        pnlPolo.Location = New Point((Screen.PrimaryScreen.Bounds.Width + 1), (Screen.PrimaryScreen.Bounds.Height + 1))

        picPolo.Width = pnlPolo.Height
        picPolo.Height = picPolo.Width

        lblPolo.Width = pnlPolo.Width - picPolo.Width
        lblPolo.Location = New Point(picPolo.Width, (pnlPolo.Height / 100) * 10)
        ResizeText(lblPolo)

        lblPoloDesc.Width = pnlPolo.Width - picPolo.Width
        lblPoloDesc.Height = (pnlPolo.Height / 100) * 50
        lblPoloDesc.Location = New Point(picPolo.Width, (pnlPolo.Height / 100) * 25)
        ResizeText(lblPoloDesc)

        btnPoloOK.Width = (pnlPolo.Width - picPolo.Width) / 4
        btnPoloOK.Location = New Point(picPolo.Width + (((pnlPolo.Width - picPolo.Width) / 8) * 3), (pnlPolo.Height / 100) * 80)

        '//PARTY\\

        pnlParty.Height = Screen.PrimaryScreen.Bounds.Height / 3
        pnlParty.Width = Screen.PrimaryScreen.Bounds.Width / 2.5
        pnlParty.Location = New Point((Screen.PrimaryScreen.Bounds.Width + 1), (Screen.PrimaryScreen.Bounds.Height + 1))

        picParty.Width = pnlParty.Height
        picParty.Height = picParty.Width

        lblParty.Width = pnlParty.Width - picParty.Width
        lblParty.Location = New Point(picParty.Width, (pnlParty.Height / 100) * 10)
        ResizeText(lblParty)

        lblPartyDesc.Width = pnlParty.Width - picParty.Width
        lblPartyDesc.Height = (pnlParty.Height / 100) * 50
        lblPartyDesc.Location = New Point(picParty.Width, (pnlParty.Height / 100) * 25)
        ResizeText(lblPartyDesc)

        btnPartyOK.Width = (pnlParty.Width - picParty.Width) / 4
        btnPartyOK.Location = New Point(picParty.Width + (((pnlParty.Width - picParty.Width) / 8) * 3), (pnlParty.Height / 100) * 80)

        '//FILM NIGHT\\

        If ThePlayer.Gender = 1 Then
            picFilmNight.Image = My.Resources.FilmNightKing
        ElseIf ThePlayer.Gender = 0 Then
            picFilmNight.Image = My.Resources.FilmNightQueen
        End If

        pnlFilmNight.Height = Screen.PrimaryScreen.Bounds.Height / 3
        pnlFilmNight.Width = Screen.PrimaryScreen.Bounds.Width / 2
        pnlFilmNight.Location = New Point((Screen.PrimaryScreen.Bounds.Width + 1), (Screen.PrimaryScreen.Bounds.Height + 1))

        picFilmNight.Width = pnlFilmNight.Height
        picFilmNight.Height = picFilmNight.Width

        lblFilmNight.Width = pnlFilmNight.Width - picFilmNight.Width
        lblFilmNight.Location = New Point(picFilmNight.Width, (pnlFilmNight.Height / 100) * 8)
        ResizeText(lblFilmNight)

        lblFilmNightPizzas.Width = pnlFilmNight.Width - picFilmNight.Width
        lblFilmNightPizzas.Location = New Point(picFilmNight.Width, (pnlFilmNight.Height / 100) * 20)
        ResizeText(lblFilmNightPizzas)

        lblFilmNightDesc.Width = pnlFilmNight.Width - picFilmNight.Width
        lblFilmNightDesc.Height = (pnlFilmNight.Height / 100) * 50
        lblFilmNightDesc.Location = New Point(picFilmNight.Width, (pnlFilmNight.Height / 100) * 25)
        ResizeText(lblFilmNightDesc)

        btnFilmNightOK.Width = (pnlFilmNight.Width - picFilmNight.Width) / 4
        btnFilmNightOK.Location = New Point(picFilmNight.Width + (((pnlFilmNight.Width - picFilmNight.Width) / 8) * 3), (pnlFilmNight.Height / 100) * 80)
    End Sub

    Private Sub tmrAdvanceDay_Tick(sender As Object, e As EventArgs) Handles tmrAdvanceDay.Tick
        ThePlayer.GoingsOn()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        DefaultView.Show()
        Me.Close()
    End Sub

    '//RESEARCH\\
    Private Sub btnResearch_Click(sender As Object, e As EventArgs) Handles btnResearch.Click
        Dim RespectVal As Integer
        Dim KnowledgeVal As Integer

        ThePlayer.Researchseshes = ThePlayer.Researchseshes + 1

        KnowledgeVal = CInt(Int(6 * Rnd()) + 1)
        RespectVal = CInt(Int(6 * Rnd()) + 1)

        ThePlayer.Respect = ThePlayer.Respect - RespectVal
        ThePlayer.Knowledge = ThePlayer.Knowledge + KnowledgeVal

        lblResearchDesc.Text = "You study intently for days. Your reclusiveness results in a -" & RespectVal & " drop in respect, but you gain +" & KnowledgeVal & " knowledge"

        pnlResearch.Location = New Point(Screen.PrimaryScreen.Bounds.Width / 3, Screen.PrimaryScreen.Bounds.Height / 3)
    End Sub
    Private Sub btnResearchOK_Click(sender As Object, e As EventArgs) Handles btnResearchOK.Click
        pnlResearch.Location = New Point((Screen.PrimaryScreen.Bounds.Width + 1), (Screen.PrimaryScreen.Bounds.Height + 1))
    End Sub

    '//HOLIDAY\\
    Private Sub btnHoliday_Click(sender As Object, e As EventArgs) Handles btnHoliday.Click
        lblHolidayDesc.Visible = False
        btnHolidayOK.Visible = False
        lblHolidayWhere.Visible = True
        cmboHoliday.Visible = True
        btnHolidayGo.Visible = True
        cmboHoliday.SelectedItem = Nothing
        btnHolidayGo.Enabled = False
        pnlHoliday.Location = New Point(Screen.PrimaryScreen.Bounds.Width / 3, Screen.PrimaryScreen.Bounds.Height / 3)
    End Sub
    Private Sub btnHolidayGo_Click(sender As Object, e As EventArgs) Handles btnHolidayGo.Click
        lblHolidayWhere.Visible = False
        cmboHoliday.Visible = False
        btnHolidayGo.Visible = False
        lblHolidayDesc.Visible = True
        btnHolidayOK.Visible = True

        If ThePlayer.CurrMonth < 11 Then
            ThePlayer.AtWarWithFranceForMonths = ThePlayer.AtWarWithFranceForMonths + 1
            ThePlayer.CurrMonth = ThePlayer.CurrMonth + 1
            ThePlayer.RuleMonths = ThePlayer.RuleMonths + 1
        ElseIf ThePlayer.CurrMonth >= 12 Then
            ThePlayer.AtWarWithFranceForMonths = 0
            ThePlayer.AtWarWithFranceForYears = ThePlayer.AtWarWithFranceForYears + 1
            ThePlayer.CurrMonth = 0
            ThePlayer.CurrYear = ThePlayer.CurrYear + 1
            ThePlayer.RuleYears = ThePlayer.RuleYears + 1
            ThePlayer.Age = ThePlayer.Age + 1
            If ThePlayer.Age = ThePlayer.DeathAge Then
                ThePlayer.Death("Died of Old Age")
            End If
        End If

        lblRuleLength.Text = "President for: "

        lblRuleLength.Text = lblRuleLength.Text & ThePlayer.RuleDays & " days, " & ThePlayer.RuleMonths & " months, " & ThePlayer.RuleYears & " years"
        lblDate.Text = ThePlayer.RuleDays & " " & TheMonth(ThePlayer.CurrMonth) & " " & ThePlayer.CurrYear

        Dim Country As String = cmboHoliday.SelectedItem
        Dim HappinessVal As Integer = CInt(Int(15 * Rnd()) + 1)

        ThePlayer.Holidays = ThePlayer.Holidays + 1

        If (ThePlayer.AtWarWithFrance = True) And ((Country = "China") Or (Country = "Cuba") Or (Country = "Vietnam") Or (Country = "North Korea")) Then
            Dim RespectVal As Integer = CInt(Int(25 * Rnd()) + 1)
            lblHolidayDesc.Text = "You foolishly go on on holiday to " & Country & ". For percieved consorting with the enemy, you lose -" & RespectVal & " respect and -" & HappinessVal & " happiness."
            ResizeText(lblHolidayDesc)
            ThePlayer.Respect = ThePlayer.Respect - RespectVal
            ThePlayer.Happiness = ThePlayer.Happiness - HappinessVal
            HappinessCheck()
            ThePlayer.Respect = ThePlayer.Respect - 20
        ElseIf Country = "United States" Then
            Dim SatOnByAmerican As Integer = CInt(Int(100 * Rnd()))
            If SatOnByAmerican = 1 Then
                lblHolidayDesc.Text = "You have a lovely holiday in the US until you are sat on by a rotund American gentleman/woman/blob. You are dead."
                ThePlayer.Death("You Were Crushed to Death by a Fattie")
            End If
        Else
            Dim HolidayResult As Integer = CInt(Int(3 * Rnd()) + 1)
            Dim Adjective As Integer = CInt(Int(10 * Rnd()))
            If (HolidayResult = 1) Or (HolidayResult = 2) Then
                ThePlayer.GoodHolidays = ThePlayer.GoodHolidays + 1
                ThePlayer.Happiness = ThePlayer.Happiness + HappinessVal
                lblHolidayDesc.Text = "You have a" & Positiveadjective(Adjective) & " holiday in " & Country & ". You gain +" & HappinessVal & " happiness."
            ElseIf HolidayResult = 3 Then
                ThePlayer.BadHolidays = ThePlayer.BadHolidays + 1
                ThePlayer.Happiness = ThePlayer.Happiness - HappinessVal
                lblHolidayDesc.Text = "You have a" & Negativeadjective(Adjective) & " holiday in " & Country & ". You lose -" & HappinessVal & " happiness."

            End If
        End If
        ResizeText(lblHolidayDesc)
        HappinessCheck()
    End Sub
    Private Sub btnHolidayOK_Click(sender As Object, e As EventArgs) Handles btnHolidayOK.Click
        pnlHoliday.Location = New Point((Screen.PrimaryScreen.Bounds.Width + 1), (Screen.PrimaryScreen.Bounds.Height + 1))
    End Sub
    Private Sub cmboHoliday_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmboHoliday.SelectedIndexChanged
        btnHolidayGo.Enabled = True
    End Sub

    '//POLO\\
    Private Sub btnPolo_Click(sender As Object, e As EventArgs) Handles btnPolo.Click
        Dim DeathByPolo As Integer = CInt(Int(60 * Rnd()))

        ThePlayer.PoloGames = ThePlayer.PoloGames + 1

        If DeathByPolo = 1 Then
            lblPoloDesc.Text = "Farts"
            ThePlayer.Death("You Were Killed in a Tragic NFL Accident")
        Else
            Dim HappinessVal As Integer = CInt(Int(15 * Rnd()) + 1)
            Dim PoloResult As Integer = CInt(Int(3 * Rnd()) + 1)
            Dim Adjective As Integer = CInt(Int(10 * Rnd()))

            If (PoloResult = 1) Or (PoloResult = 2) Then
                ThePlayer.Happiness = ThePlayer.Happiness + HappinessVal
                ThePlayer.PoloGamesWon = ThePlayer.PoloGamesWon + 1
                lblPoloDesc.Text = "You have a" & Positiveadjective(Adjective) & " NFL game. You gain +" & HappinessVal & " happiness."
            ElseIf PoloResult = 3 Then
                ThePlayer.Happiness = ThePlayer.Happiness - HappinessVal
                ThePlayer.PoloGamesLost = ThePlayer.PoloGamesLost + 1
                lblPoloDesc.Text = "You have a" & Negativeadjective(Adjective) & " NFL game. You lose -" & HappinessVal & " happiness."
            End If
        End If
        pnlPolo.Location = New Point(Screen.PrimaryScreen.Bounds.Width / 3, Screen.PrimaryScreen.Bounds.Height / 3)

        HappinessCheck()
    End Sub
    Private Sub btnPoloOK_Click(sender As Object, e As EventArgs) Handles btnPoloOK.Click
        pnlPolo.Location = New Point((Screen.PrimaryScreen.Bounds.Width + 1), (Screen.PrimaryScreen.Bounds.Height + 1))
    End Sub

    '//PARTY\\
    Private Sub btnParty_Click(sender As Object, e As EventArgs) Handles btnParty.Click
        Dim DeathByPolo As Integer = CInt(Int(60 * Rnd()))

        PartyCount = PartyCount + 1

        ThePlayer.PartiesHosted = ThePlayer.PartiesHosted + 1

        If PartyCount > TooManyParties Then
            lblPartyDesc.Text = "Unfortunately, you find out too late that you have a weak and womanly liver. You die of alcohol poisoning."
            ThePlayer.Death("You Died of Alcoholism")
        Else
            Dim HappinessVal As Integer = CInt(Int(20 * Rnd()) + 1)
            Dim RespectVal As Integer = CInt(Int(15 * Rnd()) + 1)
            Dim PartyResult As Integer = CInt(Int(3 * Rnd()) + 1)
            Dim Adjective As Integer = CInt(Int(10 * Rnd()))

            If (PartyResult = 1) Or (PartyResult = 2) Then
                ThePlayer.GoodPartiesHosted = ThePlayer.GoodPartiesHosted + 1
                ThePlayer.Happiness = ThePlayer.Happiness + HappinessVal
                lblPartyDesc.Text = "You have a" & Positiveadjective(Adjective) & " party. You gain +" & HappinessVal & " happiness."
            ElseIf PartyResult = 3 Then
                ThePlayer.BadPartiesHosted = ThePlayer.BadPartiesHosted + 1
                ThePlayer.Happiness = ThePlayer.Happiness - HappinessVal
                lblPartyDesc.Text = "You have a" & Negativeadjective(Adjective) & " party. You lose -" & HappinessVal & " happiness. Your people judge you for your partying ways, you lose -" & RespectVal & " respect."
            End If
        End If

        ResizeText(lblPartyDesc)
        pnlParty.Location = New Point(Screen.PrimaryScreen.Bounds.Width / 3, Screen.PrimaryScreen.Bounds.Height / 3)

        HappinessCheck()
    End Sub
    Private Sub btnPartyOK_Click(sender As Object, e As EventArgs) Handles btnPartyOK.Click
        pnlParty.Location = New Point((Screen.PrimaryScreen.Bounds.Width + 1), (Screen.PrimaryScreen.Bounds.Height + 1))
    End Sub

    '//FILM NIGHT\\
    Private Sub btnFilmNight_Click(sender As Object, e As EventArgs) Handles btnFilmNight.Click
        Dim HappinessVal As Integer = CInt(Int(5 * Rnd()) + 1)
        Dim SadnessVal As Integer = CInt(Int(10 * Rnd()) + 1)
        Dim FilmNightResult As Integer = CInt(Int(10 * Rnd()) + 1)
        Dim WhatWentWrong(5) As String

        ThePlayer.FilmNights = ThePlayer.FilmNights + 1

        WhatWentWrong(0) = "punch the " & ThePlayer.Partner & " in the face trying to reach across for a slice of pizza"
        WhatWentWrong(1) = "call the " & ThePlayer.Partner & " fat"
        WhatWentWrong(2) = "insult the " & ThePlayer.Partner & "'s mother"
        WhatWentWrong(3) = "fart out a right rimsplitter during a romantic scene and then attempt to Dutch oven the " & ThePlayer.Partner
        WhatWentWrong(4) = "order McDonalds with toppings that the " & ThePlayer.Partner & " is terribly allergic to, and can't restrain your laughter as they start spluttering"

        Dim WentWrong As Integer = CInt(Int(5 * Rnd()))

        If FilmNightResult = 1 Then
            ThePlayer.BadFilmNights = ThePlayer.BadFilmNights + 1
            ThePlayer.Happiness = ThePlayer.Happiness - SadnessVal
            lblFilmNightDesc.Text = "You accidentally " & WhatWentWrong(WentWrong) & ". You both go to bed angry and you lose -" & SadnessVal & " happiness. Also you dress up as a king."
        Else
            ThePlayer.GoodFilmNights = ThePlayer.GoodFilmNights + 1
            ThePlayer.Happiness = ThePlayer.Happiness + HappinessVal
            lblFilmNightDesc.Text = " You have a sweet yet uneventful night in. You gain +" & HappinessVal & " happiness. Also you dress up as a king."
        End If

        ResizeText(lblFilmNightDesc)
        ResizeText(lblFilmNight)

        pnlFilmNight.Location = New Point(Screen.PrimaryScreen.Bounds.Width / 3, Screen.PrimaryScreen.Bounds.Height / 3)

        HappinessCheck()
    End Sub
    Private Sub btnFilmNightOK_Click(sender As Object, e As EventArgs) Handles btnFilmNightOK.Click
        pnlFilmNight.Location = New Point((Screen.PrimaryScreen.Bounds.Width + 1), (Screen.PrimaryScreen.Bounds.Height + 1))
    End Sub

    Private Sub btnPlebspotting_Click(sender As Object, e As EventArgs) Handles btnPlebspotting.Click
        ThePlayer.Respect = ThePlayer.Respect + 20
        ThePlayer.PlebspottingTrips = ThePlayer.PlebspottingTrips + 1
        MsgBox("Equalspotting coming soon" & vbCrLf & vbCrLf & "Here's +20 respect")
    End Sub
End Class
Public Class DefaultView
    Dim Count As Integer = 10
    Dim DispGDP As String
    Dim ChurchNames1(10) As String
    Dim ChurchNames2(10) As String
    Dim ChurchNames3(10) As String
    Dim Prophets(10) As String
    Dim Values1(10) As String
    Dim Values2(10) As String
    Dim Values3(10) As String
    Dim ChurchArrayed As Boolean = False
    Dim DeathAction(10) As String
    Dim DeathAdjective(10) As String
    Dim DeathCondition(10) As String
    Dim DeathArrayed As Boolean = False
    Private Sub DefaultView_Load(sender As Object, e As EventArgs) Handles Me.Load
        If ThePlayer.CurrYear Mod 4 = 0 Then
            Months(1) = 29
        ElseIf ThePlayer.CurrYear Mod 4 <> 0 Then
            Months(1) = 28
        End If

        picAbdicator.BackgroundImage = My.Resources.Abdicator

        If ThePlayer.Gender = 1 Then
            picMonarch.Image = My.Resources.King
        ElseIf ThePlayer.Gender = 0 Then
            picMonarch.Image = My.Resources.Queen
        End If

        If ThePlayer.ParliamentDissolved = False Then
            grpDecrees.Enabled = False
            lblCurrentParty.Text = "Gov't: " & Government(ThePlayer.CurrGovernment)
        ElseIf ThePlayer.ParliamentDissolved = True Then
            lblCurrentParty.Visible = False
            grpDecrees.Enabled = True
            btnDissolveParliament.Visible = False

            btnExecuteCommoner.Text = "Execute a Commoner"
            btnFrance.Text = "Declare War on Communism"
            btnFalklands.Text = "Erect Monument on Texas"
            btnFalklands.Font = New Font("Times New Roman", 9)
            btnIreland.Text = "Unify Dakotas"
            btnPromote.Text = "Promote Horse as Consul"
            btnEmpire.Text = "Take Over the World"
            If ThePlayer.WorldTaken = 1 Then
                btnEmpire.Enabled = False
            End If
            btnChurch.Text = "Create New Church"
            btnGlass.Text = "Become Made of Glass"
            btnWife.Text = "Behead " & ThePlayer.Partner
            btnDeath.Text = "Declare Something Punishable by Death"
            btnDeath.Font = New Font("Times New Roman", 7)
            If ThePlayer.UnifiedIreland = True Then
                btnIreland.Enabled = False
            End If
            If ThePlayer.MadeofGlass = True Then
                btnGlass.Enabled = False
            End If
        End If

        lblRespect.Text = "Respect: " & ThePlayer.Respect

        lblName.Text = "President "
        lblRuleLength.Text = "President for: "

        lblName.Text = lblName.Text & ThePlayer.Name

        lblRuleLength.Text = lblRuleLength.Text & ThePlayer.RuleDays & " days, " & ThePlayer.RuleMonths & " months, " & ThePlayer.RuleYears & " years"

        lblGDP.Text = ThePlayer.GDPTerm & ThePlayer.GDP.ToString("###,###,###,###")

        tmrAdvanceDay.Enabled = True
    End Sub
    Private Sub DefaultView_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        picMonarch.Width = Screen.PrimaryScreen.Bounds.Height

        pnlMenu.Height = Screen.PrimaryScreen.Bounds.Height
        pnlMenu.Width = (Screen.PrimaryScreen.Bounds.Width - picMonarch.Width)
        pnlMenu.Location = New Point(picMonarch.Width, pnlMenu.Location.Y)

        lblName.Location = New Point((pnlMenu.Width / 100) * 10, (pnlMenu.Height / 100) * 6)

        lblRuleLength.Location = New Point((pnlMenu.Width / 100) * 10, (pnlMenu.Height / 100) * 9)

        lblDate.Location = New Point((pnlMenu.Width - lblDate.Width) - ((pnlMenu.Width / 100) * 10), (pnlMenu.Height / 100) * 6)

        btnCalendar.Width = pnlMenu.Width - ((pnlMenu.Width / 100) * 20)
        btnCalendar.Location = New Point((pnlMenu.Width / 100) * 10, (pnlMenu.Height / 100) * 12)

        grpInfo.Width = pnlMenu.Width - ((pnlMenu.Width / 100) * 20)
        grpInfo.Height = (pnlMenu.Width / 100) * 20
        grpInfo.Location = New Point((pnlMenu.Width / 100) * 10, (pnlMenu.Height / 100) * 19)

        lblGDP.Location = New Point((grpInfo.Width / 100) * 5, (grpInfo.Height / 100) * 20)

        lblRespect.Location = New Point((grpInfo.Width / 100) * 5, (grpInfo.Height / 100) * 45)

        lblCurrentParty.Location = New Point((grpInfo.Width / 100) * 5, (grpInfo.Height / 100) * 70)

        btnCharacter.Width = (grpInfo.Width / 100) * 47.5
        btnCharacter.Height = (grpInfo.Height / 100) * 80
        btnCharacter.Location = New Point((grpInfo.Width / 100) * 50, (grpInfo.Height / 100) * 12.5)

        btnRecreation.Width = pnlMenu.Width - ((pnlMenu.Width / 100) * 20)
        btnRecreation.Location = New Point((pnlMenu.Width / 100) * 10, (pnlMenu.Height / 100) * 38)

        btnDissolveParliament.Width = pnlMenu.Width - ((pnlMenu.Width / 100) * 20)
        btnDissolveParliament.Location = New Point((pnlMenu.Width / 100) * 10, (pnlMenu.Height / 100) * 44)

        grpDecrees.Width = pnlMenu.Width - ((pnlMenu.Width / 100) * 30)
        grpDecrees.Height = (pnlMenu.Width / 100) * 40
        grpDecrees.Location = New Point((pnlMenu.Width / 100) * 15, (pnlMenu.Height / 100) * 50)

        btnExecuteCommoner.Width = grpDecrees.Width - ((grpDecrees.Width / 100) * 60)
        btnExecuteCommoner.Height = (grpDecrees.Height / 100) * 16
        btnExecuteCommoner.Location = New Point((grpDecrees.Width / 100) * 5, (grpDecrees.Height / 100) * 12)

        btnFrance.Width = grpDecrees.Width - ((grpDecrees.Width / 100) * 60)
        btnFrance.Height = (grpDecrees.Height / 100) * 16
        btnFrance.Location = New Point((grpDecrees.Width / 100) * 55, (grpDecrees.Height / 100) * 12)

        btnFalklands.Width = grpDecrees.Width - ((grpDecrees.Width / 100) * 60)
        btnFalklands.Height = (grpDecrees.Height / 100) * 16
        btnFalklands.Location = New Point((grpDecrees.Width / 100) * 5, (grpDecrees.Height / 100) * 28)

        btnIreland.Width = grpDecrees.Width - ((grpDecrees.Width / 100) * 60)
        btnIreland.Height = (grpDecrees.Height / 100) * 16
        btnIreland.Location = New Point((grpDecrees.Width / 100) * 55, (grpDecrees.Height / 100) * 28)

        btnPromote.Width = grpDecrees.Width - ((grpDecrees.Width / 100) * 60)
        btnPromote.Height = (grpDecrees.Height / 100) * 16
        btnPromote.Location = New Point((grpDecrees.Width / 100) * 5, (grpDecrees.Height / 100) * 44)

        btnEmpire.Width = grpDecrees.Width - ((grpDecrees.Width / 100) * 60)
        btnEmpire.Height = (grpDecrees.Height / 100) * 16
        btnEmpire.Location = New Point((grpDecrees.Width / 100) * 55, (grpDecrees.Height / 100) * 44)

        btnChurch.Width = grpDecrees.Width - ((grpDecrees.Width / 100) * 60)
        btnChurch.Height = (grpDecrees.Height / 100) * 16
        btnChurch.Location = New Point((grpDecrees.Width / 100) * 5, (grpDecrees.Height / 100) * 60)

        btnGlass.Width = grpDecrees.Width - ((grpDecrees.Width / 100) * 60)
        btnGlass.Height = (grpDecrees.Height / 100) * 16
        btnGlass.Location = New Point((grpDecrees.Width / 100) * 55, (grpDecrees.Height / 100) * 60)

        btnWife.Width = grpDecrees.Width - ((grpDecrees.Width / 100) * 60)
        btnWife.Height = (grpDecrees.Height / 100) * 16
        btnWife.Location = New Point((grpDecrees.Width / 100) * 5, (grpDecrees.Height / 100) * 76)

        btnDeath.Width = grpDecrees.Width - ((grpDecrees.Width / 100) * 60)
        btnDeath.Height = (grpDecrees.Height / 100) * 16
        btnDeath.Location = New Point((grpDecrees.Width / 100) * 55, (grpDecrees.Height / 100) * 76)

        btnAbdicate.Width = pnlMenu.Width - ((pnlMenu.Width / 100) * 20)
        btnAbdicate.Location = New Point((pnlMenu.Width / 100) * 10, (pnlMenu.Height / 100) * 86)

        btnMainMenu.Width = pnlMenu.Width / 2
        btnMainMenu.Location = New Point((pnlMenu.Width / 100) * 25, (pnlMenu.Height / 100) * 92)

        pnlAbdication.Height = Screen.PrimaryScreen.Bounds.Height / 3
        pnlAbdication.Width = Screen.PrimaryScreen.Bounds.Width / 2.5
        pnlAbdication.Location = New Point((Screen.PrimaryScreen.Bounds.Width + 1), (Screen.PrimaryScreen.Bounds.Height + 1))

        picAbdicator.Width = pnlAbdication.Height
        picAbdicator.Height = picAbdicator.Width

        lblAbdicationAreYouSure.Width = pnlAbdication.Width - picAbdicator.Width
        lblAbdicationAreYouSure.Location = New Point(picAbdicator.Width, (pnlAbdication.Height / 100) * 10)
        ResizeText(lblAbdicationAreYouSure)

        lblAbdication.Width = pnlAbdication.Width - picAbdicator.Width
        lblAbdication.Height = (pnlAbdication.Height / 100) * 50
        lblAbdication.Location = New Point(picAbdicator.Width, (pnlAbdication.Height / 100) * 25)
        ResizeText(lblAbdication)

        btnAbdicationYes.Width = (pnlAbdication.Width - picAbdicator.Width) / 4
        btnAbdicationYes.Location = New Point(picAbdicator.Width + ((pnlAbdication.Width - picAbdicator.Width) / 4), (pnlAbdication.Height / 100) * 80)

        btnAbdicationNo.Width = (pnlAbdication.Width - picAbdicator.Width) / 4
        btnAbdicationNo.Location = New Point(picAbdicator.Width + ((pnlAbdication.Width - picAbdicator.Width) / 2), (pnlAbdication.Height / 100) * 80)

        pnlDissolve.Height = Screen.PrimaryScreen.Bounds.Height / 3
        pnlDissolve.Width = Screen.PrimaryScreen.Bounds.Width / 2.5
        pnlDissolve.Location = New Point((Screen.PrimaryScreen.Bounds.Width + 1), (Screen.PrimaryScreen.Bounds.Height + 1))

        picDissolve.Width = pnlDissolve.Height
        picDissolve.Height = picDissolve.Width

        lblDissolve.Width = pnlDissolve.Width - picDissolve.Width
        lblDissolve.Location = New Point(picDissolve.Width, (pnlDissolve.Height / 100) * 10)
        ResizeText(lblDissolve)

        lblDissolveDesc.Width = pnlDissolve.Width - picDissolve.Width
        lblDissolveDesc.Height = (pnlDissolve.Height / 100) * 50
        lblDissolveDesc.Location = New Point(picDissolve.Width, (pnlDissolve.Height / 100) * 25)
        ResizeText(lblDissolveDesc)

        btnDissolveYes.Width = lblDissolveDesc.Width / 2
        btnDissolveYes.Location = New Point(lblDissolveDesc.Location.X, (pnlDissolve.Height / 100) * 80)

        btnDissolveNo.Width = lblDissolveDesc.Width / 2
        btnDissolveNo.Location = New Point(lblDissolveDesc.Location.X + (lblDissolveDesc.Width / 2), (pnlDissolve.Height / 100) * 80)

        btnDissolveOK.Width = (pnlDissolve.Width - picDissolve.Width) / 4
        btnDissolveOK.Location = New Point(picDissolve.Width + (((pnlDissolve.Width - picDissolve.Width) / 8) * 3), (pnlDissolve.Height / 100) * 80)

        pnlExecute.Height = Screen.PrimaryScreen.Bounds.Height / 3
        pnlExecute.Width = Screen.PrimaryScreen.Bounds.Width / 2.5
        pnlExecute.Location = New Point((Screen.PrimaryScreen.Bounds.Width + 1), (Screen.PrimaryScreen.Bounds.Height + 1))

        picExecute.Width = pnlExecute.Height
        picExecute.Height = picExecute.Width

        lblExecute.Width = pnlExecute.Width - picExecute.Width
        lblExecute.Location = New Point(picExecute.Width, (pnlExecute.Height / 100) * 10)
        ResizeText(lblExecute)

        lblExecuteDesc.Width = pnlExecute.Width - picExecute.Width
        lblExecuteDesc.Height = (pnlExecute.Height / 100) * 50
        lblExecuteDesc.Location = New Point(picExecute.Width, (pnlExecute.Height / 100) * 25)
        ResizeText(lblExecuteDesc)

        btnExecuteOK.Width = (pnlExecute.Width - picExecute.Width) / 4
        btnExecuteOK.Location = New Point(picExecute.Width + (((pnlExecute.Width - picExecute.Width) / 8) * 3), (pnlExecute.Height / 100) * 80)

        pnlFrance.Height = Screen.PrimaryScreen.Bounds.Height / 3
        pnlFrance.Width = Screen.PrimaryScreen.Bounds.Width / 2.5
        pnlFrance.Location = New Point((Screen.PrimaryScreen.Bounds.Width + 1), (Screen.PrimaryScreen.Bounds.Height + 1))

        picFrance.Width = pnlFrance.Height
        picFrance.Height = picFrance.Width

        lblFrance.Width = pnlFrance.Width - picFrance.Width
        lblFrance.Location = New Point(picFrance.Width, (pnlFrance.Height / 100) * 10)
        ResizeText(lblFrance)

        lblFranceDesc.Width = pnlFrance.Width - picFrance.Width
        lblFranceDesc.Height = (pnlFrance.Height / 100) * 50
        lblFranceDesc.Location = New Point(picFrance.Width, (pnlFrance.Height / 100) * 25)
        ResizeText(lblFranceDesc)

        btnFranceOK.Width = (pnlFrance.Width - picFrance.Width) / 4
        btnFranceOK.Location = New Point(picFrance.Width + (((pnlFrance.Width - picFrance.Width) / 8) * 3), (pnlFrance.Height / 100) * 80)

        pnlFalklands.Height = Screen.PrimaryScreen.Bounds.Height / 3
        pnlFalklands.Width = Screen.PrimaryScreen.Bounds.Width / 2.5
        pnlFalklands.Location = New Point((Screen.PrimaryScreen.Bounds.Width + 1), (Screen.PrimaryScreen.Bounds.Height + 1))

        picFalklands.Width = pnlFalklands.Height
        picFalklands.Height = picFalklands.Width

        lblFalklands.Width = pnlFalklands.Width - picFalklands.Width
        lblFalklands.Location = New Point(picFalklands.Width, (pnlFalklands.Height / 100) * 10)
        ResizeText(lblFalklands)

        lblFalklandsDesc.Width = pnlFalklands.Width - picFalklands.Width
        lblFalklandsDesc.Height = (pnlFalklands.Height / 100) * 50
        lblFalklandsDesc.Location = New Point(picFalklands.Width, (pnlFalklands.Height / 100) * 25)
        ResizeText(lblFalklandsDesc)

        btnFalklandsOK.Width = (pnlFalklands.Width - picFalklands.Width) / 4
        btnFalklandsOK.Location = New Point(picFalklands.Width + (((pnlFalklands.Width - picFalklands.Width) / 8) * 3), (pnlFalklands.Height / 100) * 80)

        pnlIreland.Height = Screen.PrimaryScreen.Bounds.Height / 3
        pnlIreland.Width = Screen.PrimaryScreen.Bounds.Width / 2.5
        pnlIreland.Location = New Point((Screen.PrimaryScreen.Bounds.Width + 1), (Screen.PrimaryScreen.Bounds.Height + 1))

        picIreland.Width = pnlIreland.Height
        picIreland.Height = picIreland.Width

        lblIreland.Width = pnlIreland.Width - picIreland.Width
        lblIreland.Location = New Point(picIreland.Width, (pnlIreland.Height / 100) * 10)
        ResizeText(lblIreland)

        lblIrelandDesc.Width = pnlIreland.Width - picIreland.Width
        lblIrelandDesc.Height = (pnlIreland.Height / 100) * 50
        lblIrelandDesc.Location = New Point(picIreland.Width, (pnlIreland.Height / 100) * 25)
        ResizeText(lblIrelandDesc)

        btnIrelandOK.Width = (pnlIreland.Width - picIreland.Width) / 4
        btnIrelandOK.Location = New Point(picIreland.Width + (((pnlIreland.Width - picIreland.Width) / 8) * 3), (pnlIreland.Height / 100) * 80)

        pnlHorse.Height = Screen.PrimaryScreen.Bounds.Height / 3
        pnlHorse.Width = Screen.PrimaryScreen.Bounds.Width / 2.5
        pnlHorse.Location = New Point((Screen.PrimaryScreen.Bounds.Width + 1), (Screen.PrimaryScreen.Bounds.Height + 1))

        picHorse.Width = pnlHorse.Height
        picHorse.Height = picHorse.Width

        lblHorse.Width = pnlHorse.Width - picHorse.Width
        lblHorse.Location = New Point(picHorse.Width, (pnlHorse.Height / 100) * 10)
        ResizeText(lblHorse)

        lblHorseDesc.Width = pnlHorse.Width - picHorse.Width
        lblHorseDesc.Height = (pnlHorse.Height / 100) * 50
        lblHorseDesc.Location = New Point(picHorse.Width, (pnlHorse.Height / 100) * 25)
        ResizeText(lblHorseDesc)

        btnHorseOK.Width = (pnlHorse.Width - picHorse.Width) / 4
        btnHorseOK.Location = New Point(picHorse.Width + (((pnlHorse.Width - picHorse.Width) / 8) * 3), (pnlHorse.Height / 100) * 80)

        pnlChurch.Height = Screen.PrimaryScreen.Bounds.Height / 3
        pnlChurch.Width = Screen.PrimaryScreen.Bounds.Width / 2.5
        pnlChurch.Location = New Point((Screen.PrimaryScreen.Bounds.Width + 1), (Screen.PrimaryScreen.Bounds.Height + 1))

        picChurch.Width = pnlChurch.Height
        picChurch.Height = picChurch.Width

        lblChurch.Width = pnlChurch.Width - picChurch.Width
        lblChurch.Location = New Point(picChurch.Width, (pnlChurch.Height / 100) * 10)
        ResizeText(lblChurch)

        lblChurchDesc.Width = pnlChurch.Width - picChurch.Width
        lblChurchDesc.Height = (pnlChurch.Height / 100) * 50
        lblChurchDesc.Location = New Point(picChurch.Width, (pnlChurch.Height / 100) * 25)
        ResizeText(lblChurchDesc)

        btnChurchOK.Width = (pnlChurch.Width - picChurch.Width) / 4
        btnChurchOK.Location = New Point(picChurch.Width + (((pnlChurch.Width - picChurch.Width) / 8) * 3), (pnlChurch.Height / 100) * 80)

        pnlGlass.Height = Screen.PrimaryScreen.Bounds.Height / 3
        pnlGlass.Width = Screen.PrimaryScreen.Bounds.Width / 2.5
        pnlGlass.Location = New Point((Screen.PrimaryScreen.Bounds.Width + 1), (Screen.PrimaryScreen.Bounds.Height + 1))

        picGlass.Width = pnlGlass.Height
        picGlass.Height = picGlass.Width

        lblGlass.Width = pnlGlass.Width - picGlass.Width
        lblGlass.Location = New Point(picGlass.Width, (pnlGlass.Height / 100) * 10)
        ResizeText(lblGlass)

        lblGlassDesc.Width = pnlGlass.Width - picGlass.Width
        lblGlassDesc.Height = (pnlGlass.Height / 100) * 50
        lblGlassDesc.Location = New Point(picGlass.Width, (pnlGlass.Height / 100) * 25)
        ResizeText(lblGlassDesc)

        btnGlassOK.Width = (pnlGlass.Width - picGlass.Width) / 4
        btnGlassOK.Location = New Point(picGlass.Width + (((pnlGlass.Width - picGlass.Width) / 8) * 3), (pnlGlass.Height / 100) * 80)

        pnlWife.Height = Screen.PrimaryScreen.Bounds.Height / 3
        pnlWife.Width = Screen.PrimaryScreen.Bounds.Width / 2.5
        pnlWife.Location = New Point((Screen.PrimaryScreen.Bounds.Width + 1), (Screen.PrimaryScreen.Bounds.Height + 1))

        picWife.Width = pnlWife.Height
        picWife.Height = picWife.Width

        lblWife.Width = pnlWife.Width - picWife.Width
        lblWife.Location = New Point(picWife.Width, (pnlWife.Height / 100) * 10)
        If ThePlayer.Gender = 1 Then
            lblWife.Text = "BEHEAD WIFE"
        ElseIf ThePlayer.Gender = 0 Then
            lblWife.Text = "BEHEAD HUSBAND"
        End If
        ResizeText(lblWife)

        lblWifeDesc.Width = pnlWife.Width - picWife.Width
        lblWifeDesc.Height = (pnlWife.Height / 100) * 50
        lblWifeDesc.Location = New Point(picWife.Width, (pnlWife.Height / 100) * 25)
        ResizeText(lblWifeDesc)

        btnWifeOK.Width = (pnlWife.Width - picWife.Width) / 4
        btnWifeOK.Location = New Point(picWife.Width + (((pnlWife.Width - picWife.Width) / 8) * 3), (pnlWife.Height / 100) * 80)

        pnlDeath.Height = Screen.PrimaryScreen.Bounds.Height / 3
        pnlDeath.Width = Screen.PrimaryScreen.Bounds.Width / 2.5
        pnlDeath.Location = New Point((Screen.PrimaryScreen.Bounds.Width + 1), (Screen.PrimaryScreen.Bounds.Height + 1))

        picDeath.Width = pnlDeath.Height
        picDeath.Height = picDeath.Width

        lblDeath.Width = pnlDeath.Width - picDeath.Width
        lblDeath.Location = New Point(picDeath.Width, (pnlDeath.Height / 100) * 10)
        ResizeText(lblDeath)

        lblDeathDesc.Width = pnlDeath.Width - picDeath.Width
        lblDeathDesc.Height = (pnlDeath.Height / 100) * 50
        lblDeathDesc.Location = New Point(picDeath.Width, (pnlDeath.Height / 100) * 25)
        ResizeText(lblDeathDesc)

        btnDeathOK.Width = (pnlDeath.Width - picDeath.Width) / 4
        btnDeathOK.Location = New Point(picDeath.Width + (((pnlDeath.Width - picDeath.Width) / 8) * 3), (pnlDeath.Height / 100) * 80)

        pnlEmpire.Height = Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 4)
        pnlEmpire.Width = Screen.PrimaryScreen.Bounds.Width / 2
        pnlEmpire.Location = New Point((Screen.PrimaryScreen.Bounds.Width + 1), (Screen.PrimaryScreen.Bounds.Height + 1))

        picEmpire.Width = pnlEmpire.Width
        picEmpire.Height = (pnlEmpire.Height / 100) * 45

        pnlEmpireRetaken.Width = pnlEmpire.Width / 4
        pnlEmpireRetaken.Height = (pnlEmpire.Height - picEmpire.Height) - (pnlEmpire.Height / 100) * 10
        pnlEmpireRetaken.Location = New Point((pnlEmpire.Width / 100) * 4, pnlEmpire.Height / 2)

        lblEmpire.Width = (pnlEmpire.Width / 3)
        lblEmpire.Location = New Point(pnlEmpire.Width / 3, (pnlEmpire.Height / 100) * 45)
        ResizeText(lblEmpire)

        lblWhichCountry.Width = (pnlEmpire.Width / 5) * 3
        lblWhichCountry.Location = New Point(pnlEmpire.Width / 3, (pnlEmpire.Height / 100) * 54)
        ResizeText(lblWhichCountry)

        cmboCountry.Width = (pnlEmpire.Width / 5) * 2.5
        cmboCountry.Location = New Point(pnlEmpire.Width / 3, (pnlEmpire.Height / 100) * 60)

        lblChanceofSuccess.Width = (pnlEmpire.Width / 6)
        lblChanceofSuccess.Location = New Point((pnlEmpire.Width / 6) * 5, (pnlEmpire.Height / 100) * 57)
        ResizeText(lblChanceofSuccess)

        lblDifficulty.Width = (pnlEmpire.Width / 6)
        lblDifficulty.Location = New Point((pnlEmpire.Width / 6) * 5, (pnlEmpire.Height / 100) * 59)
        ResizeText(lblDifficulty)

        btnAttack.Width = (pnlEmpire.Width / 5) * 3
        btnAttack.Location = New Point(pnlEmpire.Width / 3, (pnlEmpire.Height / 100) * 68)

        lblEmpireDesc.Width = (pnlEmpire.Width / 5) * 3.25
        lblEmpireDesc.Height = (pnlEmpire.Height / 100) * 36
        lblEmpireDesc.Location = New Point(pnlEmpire.Width / 3, (pnlEmpire.Height / 100) * 50)
        ResizeText(lblEmpireDesc)

        btnEmpireOK.Width = pnlEmpire.Width / 4
        btnEmpireOK.Location = New Point((pnlEmpire.Width / 2) - (btnEmpireOK.Width / 2), (pnlEmpire.Height / 100) * 90)
    End Sub

    Private Sub btnMainMenu_Click(sender As Object, e As EventArgs) Handles btnMainMenu.Click
        MainMenu.Show()
        Me.Close()
    End Sub

    Private Sub tmrAdvanceDay_Tick(sender As Object, e As EventArgs) Handles tmrAdvanceDay.Tick
        ThePlayer.GoingsOn()
    End Sub

    Private Sub btnAbdicate_Click(sender As Object, e As EventArgs) Handles btnAbdicate.Click
        tmrAdvanceDay.Enabled = False
        MusicPlayer.PlayAbdication()
        pnlAbdication.Location = New Point(Screen.PrimaryScreen.Bounds.Width / 3, Screen.PrimaryScreen.Bounds.Height / 3)
        ThePlayer.AbdicationThreats = ThePlayer.AbdicationThreats + 1
    End Sub
    Private Sub btnAbdicationYes_Click(sender As Object, e As EventArgs) Handles btnAbdicationYes.Click
        ThePlayer.Death("You Resigned")
    End Sub
    Private Sub btnAbdicationNo_Click(sender As Object, e As EventArgs) Handles btnAbdicationNo.Click
        tmrAdvanceDay.Enabled = True
        pnlAbdication.Location = New Point((Screen.PrimaryScreen.Bounds.Width + 1), (Screen.PrimaryScreen.Bounds.Height + 1))
    End Sub

    Private Sub btnRecreation_Click(sender As Object, e As EventArgs) Handles btnRecreation.Click
        Recreation.Show()
        Me.Close()
    End Sub

    Private Sub btnCharacter_Click(sender As Object, e As EventArgs) Handles btnCharacter.Click
        ViewCharacter.Show()
        Me.Close()
    End Sub

    Private Sub btnDissolveParliament_Click(sender As Object, e As EventArgs) Handles btnDissolveParliament.Click
        If ThePlayer.Respect >= 100 Then
            ThePlayer.YearParliamentDissolved = ThePlayer.CurrYear
            ThePlayer.ParliamentDissolved = True
            lblCurrentParty.Visible = False
            grpDecrees.Enabled = True
            btnDissolveParliament.Visible = False
            btnDissolveYes.Visible = False
            btnDissolveNo.Visible = False
            btnDissolveOK.Visible = True

            ThePlayer.GDPTerm = "Wealth: $"

            btnExecuteCommoner.Text = "Execute a Commoner"
            btnFrance.Text = "Declare War on Communism"
            btnFalklands.Text = "Erect Monument on Texas"
            btnFalklands.Font = New Font("Times New Roman", 9)
            btnIreland.Text = "Unify Dakotas"
            btnPromote.Text = "Promote Horse as Consul"
            btnEmpire.Text = "Take Over the World"
            btnChurch.Text = "Create New Church"
            btnGlass.Text = "Become Made of Glass"
            btnWife.Text = "Behead " & ThePlayer.Partner
            btnDeath.Text = "Declare Something Punishable by Death"
            btnDeath.Font = New Font("Times New Roman", 7)

            If ThePlayer.Gender = 1 Then
                picDissolve.BackgroundImage = My.Resources.King
            ElseIf ThePlayer.Gender = 0 Then
                picDissolve.BackgroundImage = My.Resources.Queen
            End If
            lblDissolveDesc.Text = "You attempt to dissolve Congress and rule by decree. Thanks to the huge amount of respect you have accrued, it all goes off without a hitch."
        ElseIf ThePlayer.Respect < 100 Then
            lblDissolveDesc.Text = "You consider attempting to dissolve Congress and ruling by decree. Your lack of respect gives you pause, however. Are you sure you want to try this?"
            btnDissolveYes.Visible = True
            btnDissolveNo.Visible = True
            btnDissolveOK.Visible = False
            picDissolve.BackgroundImage = My.Resources.CharlesI
        End If

        pnlDissolve.Location = New Point(Screen.PrimaryScreen.Bounds.Width / 3, Screen.PrimaryScreen.Bounds.Height / 3)
    End Sub
    Private Sub btnDissolveYes_Click(sender As Object, e As EventArgs) Handles btnDissolveYes.Click
        ThePlayer.Death("It All Went a Bit King Charles I for You")
    End Sub
    Private Sub btnDissolveNo_Click(sender As Object, e As EventArgs) Handles btnDissolveNo.Click
        pnlDissolve.Location = New Point((Screen.PrimaryScreen.Bounds.Width + 1), (Screen.PrimaryScreen.Bounds.Height + 1))
    End Sub
    Private Sub btnDissolveOK_Click(sender As Object, e As EventArgs) Handles btnDissolveOK.Click
        pnlDissolve.Location = New Point((Screen.PrimaryScreen.Bounds.Width + 1), (Screen.PrimaryScreen.Bounds.Height + 1))
    End Sub

    Private Sub btnExecuteCommoner_Click(sender As Object, e As EventArgs) Handles btnExecuteCommoner.Click
        lblExecute.Font = New Font("Times New Roman", 20)
        Dim RespectVal As Integer = CInt(Int(20 * Rnd()))
        ThePlayer.CommonersExecuted = ThePlayer.CommonersExecuted + 1
        ThePlayer.Respect = ThePlayer.Respect - RespectVal
        RespectCheck()
        lblRespect.Text = "Respect: " & ThePlayer.Respect
        lblExecuteDesc.Text = "You execute a lowly commoner right in front of his peers for little reason. You lose -" & RespectVal & " respect."
        pnlExecute.Location = New Point(Screen.PrimaryScreen.Bounds.Width / 3, Screen.PrimaryScreen.Bounds.Height / 3)
    End Sub
    Private Sub btnExecuteOK_Click(sender As Object, e As EventArgs) Handles btnExecuteOK.Click
        pnlExecute.Location = New Point((Screen.PrimaryScreen.Bounds.Width + 1), (Screen.PrimaryScreen.Bounds.Height + 1))
    End Sub

    Private Sub btnFrance_Click(sender As Object, e As EventArgs) Handles btnFrance.Click
        ThePlayer.AtWarWithFrance = True
        ThePlayer.YearWarDeclared = ThePlayer.CurrYear
        pnlFrance.Location = New Point(Screen.PrimaryScreen.Bounds.Width / 3, Screen.PrimaryScreen.Bounds.Height / 3)
    End Sub
    Private Sub btnFranceOK_Click(sender As Object, e As EventArgs) Handles btnFranceOK.Click
        pnlFrance.Location = New Point((Screen.PrimaryScreen.Bounds.Width + 1), (Screen.PrimaryScreen.Bounds.Height + 1))
    End Sub

    Private Sub btnFalklands_Click(sender As Object, e As EventArgs) Handles btnFalklands.Click
        If ThePlayer.SunkFalklands = False Then
            If ThePlayer.ArgieButthurtLevel < 13 Then
                ThePlayer.MonumentsErected = ThePlayer.MonumentsErected + 1
                ThePlayer.FalklandMonumentsWeight = ThePlayer.FalklandMonumentsWeight + CInt(Int(1000 * Rnd()))
                ThePlayer.ArgieButthurtLevel = ThePlayer.ArgieButthurtLevel + 1
            ElseIf ThePlayer.ArgieButthurtLevel = 13 Then
                lblFalklandsDesc.Text = "You erect another monument on Texas. So enraged, the Mexicans launch an invasion of the state. The combined weight of the monuments and a single Mexican soldier called Paco sinks the state into the ocean."
                ThePlayer.SunkFalklands = True
                picFalklands.BackgroundImage = My.Resources.SinkingFalklands
                ResizeText(lblFalklandsDesc)
            End If
        ElseIf ThePlayer.SunkFalklands = True Then
            lblFalklandsDesc.Text = "You drop a monument into the rough area of ocean where Texas used to be. It causes a satisfying splash."
            picFalklands.BackgroundImage = My.Resources.SunkFalklands
            ResizeText(lblFalklandsDesc)
        End If
        pnlFalklands.Location = New Point(Screen.PrimaryScreen.Bounds.Width / 3, Screen.PrimaryScreen.Bounds.Height / 3)
    End Sub
    Private Sub btnFalklandsOK_Click(sender As Object, e As EventArgs) Handles btnFalklandsOK.Click
        pnlFalklands.Location = New Point((Screen.PrimaryScreen.Bounds.Width + 1), (Screen.PrimaryScreen.Bounds.Height + 1))
    End Sub

    Private Sub btnIreland_Click(sender As Object, e As EventArgs) Handles btnIreland.Click
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

        Dim IrelandUnified As Integer = CInt(Int(3 * Rnd()) + 1)
        If IrelandUnified <> 1 Then
            Dim RespectVal As Integer = CInt(Int(30 * Rnd()))
            Dim DeadSoldiers As Integer = CInt(Int(200 * Rnd()) + 1)
            ThePlayer.Respect = ThePlayer.Respect - RespectVal
            RespectCheck()
            lblRespect.Text = "Respect: " & ThePlayer.Respect
            ThePlayer.LivesLostIreland = ThePlayer.LivesLostIreland + DeadSoldiers
            ThePlayer.AttemptstoUnifyIreland = ThePlayer.AttemptstoUnifyIreland + 1
            picIreland.BackgroundImage = My.Resources.Irelandlose
            lblIrelandDesc.Text = "You attempt to unify the Dakotas. It goes poorly, " & DeadSoldiers & " American soldiers die and you lose -" & RespectVal & " respect."
        ElseIf IrelandUnified = 1 Then
            Dim RespectVal As Integer = CInt(Int(60 * Rnd()))
            Dim DeadSoldiers As Integer = CInt(Int(50 * Rnd()))
            ThePlayer.Respect = ThePlayer.Respect + RespectVal
            lblRespect.Text = "Respect: " & ThePlayer.Respect
            ThePlayer.LivesLostIreland = ThePlayer.LivesLostIreland + DeadSoldiers
            ThePlayer.AttemptstoUnifyIreland = ThePlayer.AttemptstoUnifyIreland + 1
            ThePlayer.YearIrelandUnified = ThePlayer.CurrYear
            picIreland.BackgroundImage = My.Resources.Irelandwin
            lblIrelandDesc.Text = "You attempt to unify the Dakotas. It goes well, only " & DeadSoldiers & " American soldiers die and you gain +" & RespectVal & " respect."
            ThePlayer.UnifiedIreland = True
            btnIreland.Enabled = False
        End If
        pnlIreland.Location = New Point(Screen.PrimaryScreen.Bounds.Width / 3, Screen.PrimaryScreen.Bounds.Height / 3)
    End Sub
    Private Sub btnIrelandOK_Click(sender As Object, e As EventArgs) Handles btnIrelandOK.Click
        pnlIreland.Location = New Point((Screen.PrimaryScreen.Bounds.Width + 1), (Screen.PrimaryScreen.Bounds.Height + 1))
    End Sub

    Private Sub btnPromote_Click(sender As Object, e As EventArgs) Handles btnPromote.Click
        If ThePlayer.PercentageofHorseConsuls <> 100 Then
            ThePlayer.PercentageofHorseConsuls = ThePlayer.PercentageofHorseConsuls + 50
            lblHorseDesc.Text = "You promote a horse to the position of consul. " & ThePlayer.PercentageofHorseConsuls & "% of all consuls in the land are now horses, as it should be."
        ElseIf ThePlayer.PercentageofHorseConsuls = 100 Then
            lblHorseDesc.Font = New Font("Times New Roman", 18)
            lblHorseDesc.Text = "You attempt to promote another horse to the position of consul before realising every consul is a horse already. You try replacing one horse with a different horse but alas, the magic is gone."
            ResizeText(lblHorseDesc)
        End If
        pnlHorse.Location = New Point(Screen.PrimaryScreen.Bounds.Width / 3, Screen.PrimaryScreen.Bounds.Height / 3)
    End Sub
    Private Sub btnHorseOK_Click(sender As Object, e As EventArgs) Handles btnHorseOK.Click
        pnlHorse.Location = New Point((Screen.PrimaryScreen.Bounds.Width + 1), (Screen.PrimaryScreen.Bounds.Height + 1))
    End Sub

    Private Sub btnEmpire_Click(sender As Object, e As EventArgs) Handles btnEmpire.Click
        cmboCountry.Items.Clear()
        cmboCountry.Text = ""
        lblDifficulty.Text = ""

        lblTheWorld.Visible = True
        cmboCountry.Items.Add("The World")
        lblTheWorld.ForeColor = Color.Red

        lblRetaken.Text = "0%"

        cmboCountry.Enabled = True
        btnAttack.Visible = True
        lblEmpireDesc.Visible = False
        btnEmpireOK.Visible = False
        btnAttack.Enabled = False

        pnlEmpire.Location = New Point(Screen.PrimaryScreen.Bounds.Width / 4, Screen.PrimaryScreen.Bounds.Height / 8)
    End Sub
    Private Sub btnAttack_Click(sender As Object, e As EventArgs) Handles btnAttack.Click
        Dim DeadSoldiers As Integer = 0
        Dim RespectVal As Integer = 0
        Dim Result As Integer = 0

        cmboCountry.Enabled = False
        btnAttack.Visible = False
        lblEmpireDesc.Visible = True
        btnEmpireOK.Visible = True

        Result = CInt(Int(100 * Rnd()) + 1)

        If cmboCountry.SelectedItem = "The World" Then
            ThePlayer.CurrYear = ThePlayer.CurrYear + 6
            ThePlayer.RuleYears = ThePlayer.RuleYears + 6
            ThePlayer.Age = ThePlayer.Age + 6
            ThePlayer.AtWarWithFranceForYears = ThePlayer.AtWarWithFranceForYears + 6
            If ThePlayer.Age = ThePlayer.DeathAge Then
                ThePlayer.Death("Died of Old Age")
            End If
            lblRuleLength.Text = "President for: "
            lblRuleLength.Text = lblRuleLength.Text & ThePlayer.RuleDays & " days, " & ThePlayer.RuleMonths & " months, " & ThePlayer.RuleYears & " years"
            lblDate.Text = ThePlayer.RuleDays & " " & TheMonth(ThePlayer.CurrMonth) & " " & ThePlayer.CurrYear

            If Result <= 20 Then
                ThePlayer.AtWarWithFrance = False
                btnFrance.Enabled = False
                DeadSoldiers = CInt(Int(10000 * Rnd()))
                RespectVal = CInt(Int(400 * Rnd()))
                ThePlayer.Respect = ThePlayer.Respect + RespectVal
                lblEmpireDesc.Text = "You attempt to do the same thing you do every night, Pinky: Try to take over the world. Against all the odds, it goes well, only " & DeadSoldiers.ToString("##,###") & " American soldiers are killed and you gain +" & RespectVal & " respect."
                ThePlayer.WorldTaken = 1
                lblTheWorld.ForeColor = Color.Green
                ThePlayer.YearWorldTaken = ThePlayer.CurrYear
            ElseIf Result > 20 Then
                DeadSoldiers = CInt(Int(50000 * Rnd()))
                RespectVal = CInt(Int(30 * Rnd()))
                ThePlayer.Respect = ThePlayer.Respect - RespectVal
                RespectCheck()
                lblEmpireDesc.Text = "You attempt to do the same thing you do every night, Pinky: Try to take over the world. As is so often the way, it goes poorly. " & DeadSoldiers.ToString("##,###") & " American soldiers are killed and you lose -" & RespectVal & " respect."
            End If
            ThePlayer.AttemptstoTakeWorld = ThePlayer.AttemptstoTakeWorld + 1
            ThePlayer.LivesLostTakeWorld = ThePlayer.LivesLostTakeWorld + DeadSoldiers
        End If

        lblRespect.Text = "Respect: " & ThePlayer.Respect
    End Sub
    Private Sub btnEmpireOK_Click(sender As Object, e As EventArgs) Handles btnEmpireOK.Click
        If ThePlayer.WorldTaken = 1 Then
            btnEmpire.Enabled = False
        End If
        pnlEmpire.Location = New Point((Screen.PrimaryScreen.Bounds.Width + 1), (Screen.PrimaryScreen.Bounds.Height + 1))
    End Sub
    Private Sub cmboCountry_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmboCountry.SelectedIndexChanged
        If cmboCountry.SelectedItem = "The World" Then
            lblDifficulty.Text = "20%"
        End If

        If cmboCountry.SelectedItem <> "" Then
            btnAttack.Enabled = True
        ElseIf cmboCountry.SelectedItem = "" Then
            btnAttack.Enabled = False
        End If
    End Sub

    Private Sub btnChurch_Click(sender As Object, e As EventArgs) Handles btnChurch.Click
        If ChurchArrayed = False Then
            ChurchArray()
            ChurchArrayed = True
        End If
        ThePlayer.ChurchesFormed = ThePlayer.ChurchesFormed + 1
        lblChurchDesc.Text = "You create a new church, the " & ChurchNames1(10 * Rnd()) & " " & ChurchNames2(10 * Rnd()) & " of " & ChurchNames3(10 * Rnd()) & ", based around the teachings of " & Prophets(10 * Rnd()) & " and the values of " & Values1(10 * Rnd()) & ", " & Values2(10 * Rnd()) & " and " & Values3(10 * Rnd()) & "."
        ResizeText(lblChurchDesc)

        pnlChurch.Location = New Point(Screen.PrimaryScreen.Bounds.Width / 3, Screen.PrimaryScreen.Bounds.Height / 3)
    End Sub
    Private Sub btnChurchOK_Click(sender As Object, e As EventArgs) Handles btnChurchOK.Click
        pnlChurch.Location = New Point((Screen.PrimaryScreen.Bounds.Width + 1), (Screen.PrimaryScreen.Bounds.Height + 1))
    End Sub

    Private Sub btnGlass_Click(sender As Object, e As EventArgs) Handles btnGlass.Click
        ThePlayer.MadeofGlass = True
        pnlGlass.Location = New Point(Screen.PrimaryScreen.Bounds.Width / 3, Screen.PrimaryScreen.Bounds.Height / 3)
        btnGlass.Enabled = False
    End Sub
    Private Sub btnGlassOK_Click(sender As Object, e As EventArgs) Handles btnGlassOK.Click
        pnlGlass.Location = New Point((Screen.PrimaryScreen.Bounds.Width + 1), (Screen.PrimaryScreen.Bounds.Height + 1))
    End Sub

    Private Sub btnWife_Click(sender As Object, e As EventArgs) Handles btnWife.Click
        lblWifeDesc.Text = "The current " & ThePlayer.Partner & " gets the chop, but luckily for your love life, nothing's a bigger turn-on than absolute dictatorship, and you have a new partner before the last one's head has even hit the floor."
        ThePlayer.WivesBeheaded = ThePlayer.WivesBeheaded + 1
        pnlWife.Location = New Point(Screen.PrimaryScreen.Bounds.Width / 3, Screen.PrimaryScreen.Bounds.Height / 3)
    End Sub
    Private Sub btnWifeOK_Click(sender As Object, e As EventArgs) Handles btnWifeOK.Click
        pnlWife.Location = New Point((Screen.PrimaryScreen.Bounds.Width + 1), (Screen.PrimaryScreen.Bounds.Height + 1))
    End Sub

    Private Sub btnDeath_Click(sender As Object, e As EventArgs) Handles btnDeath.Click
        If DeathArrayed = False Then
            DeathArray()
            DeathArrayed = True
        End If
        lblDeathDesc.Text = "You decide there are too many things out there not punishable by death. To alleviate this, you declare that " & DeathAction(10 * Rnd()) & " " & DeathAdjective(10 * Rnd()) & " " & DeathCondition(10 * Rnd()) & " is now a capital offence."
        ThePlayer.ThingsDeclaredPunishableByDeath = ThePlayer.ThingsDeclaredPunishableByDeath + 1
        ResizeText(lblDeathDesc)
        pnlDeath.Location = New Point(Screen.PrimaryScreen.Bounds.Width / 3, Screen.PrimaryScreen.Bounds.Height / 3)
    End Sub
    Private Sub btnDeathOK_Click(sender As Object, e As EventArgs) Handles btnDeathOK.Click
        pnlDeath.Location = New Point((Screen.PrimaryScreen.Bounds.Width + 1), (Screen.PrimaryScreen.Bounds.Height + 1))
    End Sub

    Sub ChurchArray()
        ChurchNames1(0) = "Blessed"
        ChurchNames1(1) = "Holy"
        ChurchNames1(2) = "Pungent"
        ChurchNames1(3) = "Fast"
        ChurchNames1(4) = "Indomitable"
        ChurchNames1(5) = "Unfathomable"
        ChurchNames1(6) = "Rotund"
        ChurchNames1(7) = "Compelling"
        ChurchNames1(8) = "Thrilling"
        ChurchNames1(9) = "Believing"

        ChurchNames2(0) = "Brothers"
        ChurchNames2(1) = "Sisters"
        ChurchNames2(2) = "Chums"
        ChurchNames2(3) = "Friends"
        ChurchNames2(4) = "Pals"
        ChurchNames2(5) = "Gentlemen"
        ChurchNames2(6) = "Bros"
        ChurchNames2(7) = "Chaps"
        ChurchNames2(8) = "Buggerers"
        ChurchNames2(9) = "lads"

        ChurchNames3(0) = "Zanzibar"
        ChurchNames3(1) = "Eternity"
        ChurchNames3(2) = "God"
        ChurchNames3(3) = "the Lord"
        ChurchNames3(4) = "Foreveriality"
        ChurchNames3(5) = "Time"
        ChurchNames3(6) = "Nature"
        ChurchNames3(7) = "Gaia"
        ChurchNames3(8) = "Spacetime"
        ChurchNames3(9) = ThePlayer.Name

        Prophets(0) = "Rumps"
        Prophets(1) = "Phil"
        Prophets(2) = "Mr Brown"
        Prophets(3) = "some guy"
        Prophets(4) = "Bill and Ted"
        Prophets(5) = "the voices in your head"
        Prophets(6) = "Albert Camus"
        Prophets(7) = "Plato"
        Prophets(8) = "Thomas Aquinas"
        Prophets(9) = "Ludwig Wittgenstein"

        Values1(0) = "nihilism"
        Values1(1) = "being excellent to each other"
        Values1(2) = "existentialism"
        Values1(3) = "fundamentalism"
        Values1(4) = "ismism"
        Values1(5) = "Islamism"
        Values1(6) = "pacifism"
        Values1(7) = "being an arsehole"
        Values1(8) = "stuff"
        Values1(9) = "militarism"

        Values2(0) = "partying on"
        Values2(1) = "being a nice guy"
        Values2(2) = "anarchism"
        Values2(3) = "statism"
        Values2(4) = "things"
        Values2(5) = "quietism"
        Values2(6) = "minarchism"
        Values2(7) = "absurdism"
        Values2(8) = "surrealism"
        Values2(9) = "Dadaism"

        Values3(0) = "whatever"
        Values3(1) = "farts"
        Values3(2) = "dudes"
        Values3(3) = "abandonment"
        Values3(4) = "homelessness"
        Values3(5) = "sillyness"
        Values3(6) = "seriousness"
        Values3(7) = "chips"
        Values3(8) = "value"
        Values3(9) = "up"
    End Sub
    Sub DeathArray()
        DeathAction(0) = "eating"
        DeathAction(1) = "looking"
        DeathAction(2) = "feeling"
        DeathAction(3) = "existing"
        DeathAction(4) = "jumping"
        DeathAction(5) = "thinking"
        DeathAction(6) = "considering things"
        DeathAction(7) = "talking"
        DeathAction(8) = "chewing"
        DeathAction(9) = "running"

        DeathAdjective(0) = "loudly"
        DeathAdjective(1) = "irritatingly"
        DeathAdjective(2) = "thoroughly"
        DeathAdjective(3) = "quietly"
        DeathAdjective(4) = "upwardly"
        DeathAdjective(5) = "positively"
        DeathAdjective(6) = "negatively"
        DeathAdjective(7) = "ambiguously"
        DeathAdjective(8) = "randomly"
        DeathAdjective(9) = "without provocation"

        DeathCondition(0) = "on a Tuesday"
        DeathCondition(1) = "on the Sabbath"
        DeathCondition(2) = "without a permit"
        DeathCondition(3) = "without humming the national anthem"
        DeathCondition(4) = "whilst slapping yourself"
        DeathCondition(5) = "whilst jumping"
        DeathCondition(6) = "whilst existing"
        DeathCondition(7) = "without rotating"
        DeathCondition(8) = "and eating a turtle"
        DeathCondition(9) = "whilst looking in the direction of Mecca"
    End Sub

    Private Sub btnCalendar_Click(sender As Object, e As EventArgs) Handles btnCalendar.Click
        MsgBox("Calendar and event scheduling coming soon")
    End Sub
End Class
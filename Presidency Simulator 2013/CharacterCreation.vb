Public Class CharacterCreation

    Private Sub CharacterCreation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NewPlayer()
        radMale.Checked = True
        radDem.Checked = True
    End Sub
    Private Sub radMale_CheckedChanged(sender As Object, e As EventArgs) Handles radMale.CheckedChanged
        ThePlayer.Gender = 1
        picMonarch.Image = My.Resources.King
    End Sub
    Private Sub radFemale_CheckedChanged(sender As Object, e As EventArgs) Handles radFemale.CheckedChanged
        ThePlayer.Gender = 0
        picMonarch.Image = My.Resources.Queen
    End Sub
    Private Sub btnQuitGame_Click(sender As Object, e As EventArgs) Handles btnMainMenu.Click
        MainMenu.Show()
        Me.Close()
    End Sub
    Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click
        ThePlayer.CurrYear = Year(Now)

        ThePlayer.DeathAge = 100 + CInt(Int((50) * Rnd()) + 1)

        If txtName.Text <> "" Then
            ThePlayer.Name = txtName.Text
        ElseIf txtName.Text = "" Then
            ThePlayer.Name = "The Nameless One"
        End If
        ThePlayer.Age = numAge.Text
        If cmboBirthplace.Text = "" Then
            ThePlayer.Birthplace = "Death Valley, USA"
        ElseIf cmboBirthplace.Text <> "" Then
            ThePlayer.Birthplace = cmboBirthplace.SelectedItem
        End If

        If ThePlayer.Gender = 1 Then
            ThePlayer.Partner = "First Lady"
        ElseIf ThePlayer.Gender = 0 Then
            ThePlayer.Partner = "First Gentleman"
        End If

        ThePlayer.Elections()

        Intro.Show()
        Me.Close()
    End Sub
    Private Sub CharacterCreation_Resize(sender As Object, e As EventArgs) Handles Me.Resize


        pnlMenu.Height = Screen.PrimaryScreen.Bounds.Height
        pnlMenu.Width = (Screen.PrimaryScreen.Bounds.Width - picMonarch.Width)
        pnlMenu.Location = New Point(picMonarch.Width, pnlMenu.Location.Y)

        picMonarch.Height = pnlMenu.Height
        picMonarch.Width = Screen.PrimaryScreen.Bounds.Height

        lblName.Location = New Point((pnlMenu.Width / 100) * 10, (pnlMenu.Height / 100) * 40)
        ResizeText(lblName)

        txtName.Width = pnlMenu.Width - ((pnlMenu.Width / 100) * 20)
        txtName.Location = New Point((pnlMenu.Width / 100) * 10, (pnlMenu.Height / 100) * 45)

        lblAge.Location = New Point((pnlMenu.Width / 100) * 10, (pnlMenu.Height / 100) * 50)
        ResizeText(lblAge)

        lblParty.Location = New Point((pnlMenu.Width / 100) * 50, (pnlMenu.Height / 100) * 50)
        ResizeText(lblParty)

        radDem.Location = New Point((pnlMenu.Width / 100) * 50, (pnlMenu.Height / 100) * 55)

        radRep.Location = New Point((pnlMenu.Width / 100) * 75, (pnlMenu.Height / 100) * 55)

        numAge.Width = pnlMenu.Width - ((pnlMenu.Width / 100) * 60)
        numAge.Location = New Point((pnlMenu.Width / 100) * 10, (pnlMenu.Height / 100) * 55)

        lblBirthplace.Location = New Point((pnlMenu.Width / 100) * 10, (pnlMenu.Height / 100) * 60)
        ResizeText(lblBirthplace)

        cmboBirthplace.Width = pnlMenu.Width - ((pnlMenu.Width / 100) * 20)
        cmboBirthplace.Location = New Point((pnlMenu.Width / 100) * 10, (pnlMenu.Height / 100) * 65)
        cmboBirthplace.DropDownHeight = (pnlMenu.Height / 100) * 100

        lblGender.Location = New Point((pnlMenu.Width / 100) * 10, (pnlMenu.Height / 100) * 70)
        ResizeText(lblGender)

        radMale.Location = New Point((pnlMenu.Width / 100) * 10, (pnlMenu.Height / 100) * 75)

        radFemale.Location = New Point((pnlMenu.Width / 100) * 45, (pnlMenu.Height / 100) * 75)

        btnPlay.Width = txtName.Width
        btnPlay.Location = New Point((pnlMenu.Width / 100) * 10, (pnlMenu.Height / 100) * 82)

        btnMainMenu.Width = btnPlay.Width / 2
        btnMainMenu.Location = New Point(btnPlay.Location.X + (btnPlay.Width / 4), (pnlMenu.Height / 100) * 90)

        picRoyaltySimulatorLogo.Width = txtName.Width
        picRoyaltySimulatorLogo.Height = (pnlMenu.Height / 100) * 30
        picRoyaltySimulatorLogo.Location = New Point((pnlMenu.Width / 100) * 10, (pnlMenu.Height / 100) * 10)
    End Sub

    Private Sub radDem_CheckedChanged(sender As Object, e As EventArgs) Handles radDem.CheckedChanged
        ThePlayer.Party = "Democrat"
    End Sub

    Private Sub radRep_CheckedChanged(sender As Object, e As EventArgs) Handles radRep.CheckedChanged
        ThePlayer.Party = "Republican"
    End Sub
End Class
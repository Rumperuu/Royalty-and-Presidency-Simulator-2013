Public Class MainMenu
    Private Sub btnQuitGame_Click(sender As Object, e As EventArgs) Handles btnQuitGame.Click
        SplashScreen.Close()
    End Sub

    Private Sub btnNewGame_Click(sender As Object, e As EventArgs) Handles btnNewGame.Click
        CharacterCreation.Show()
        Me.Close()
    End Sub

    Private Sub MainMenu_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        picCoatofArms.Width = Screen.PrimaryScreen.Bounds.Height

        pnlMenu.Height = Screen.PrimaryScreen.Bounds.Height
        pnlMenu.Width = (Screen.PrimaryScreen.Bounds.Width - picCoatofArms.Width)
        pnlMenu.Location = New Point(picCoatofArms.Width, pnlMenu.Location.Y)

        btnNewGame.Width = pnlMenu.Width - ((pnlMenu.Width / 100) * 20)
        btnNewGame.Location = New Point((pnlMenu.Width / 100) * 10, (pnlMenu.Height / 100) * 44)

        btnLoadGame.Width = pnlMenu.Width - ((pnlMenu.Width / 100) * 20)
        btnLoadGame.Location = New Point((pnlMenu.Width / 100) * 10, (pnlMenu.Height / 100) * 58)

        btnQuitGame.Width = btnNewGame.Width / 2
        btnQuitGame.Location = New Point(btnNewGame.Location.X + (btnNewGame.Width / 4), (pnlMenu.Height / 100) * 86)

        picRoyaltySimulatorLogo.Width = btnNewGame.Width
        picRoyaltySimulatorLogo.Height = (pnlMenu.Height / 100) * 30
        picRoyaltySimulatorLogo.Location = New Point((pnlMenu.Width / 100) * 10, (pnlMenu.Height / 100) * 10)
    End Sub

    Private Sub btnLoadGame_Click(sender As Object, e As EventArgs) Handles btnLoadGame.Click
        MsgBox("Saving and loading coming soon")
    End Sub

    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MusicPlayer.PlayRuleBritannia()
    End Sub
End Class

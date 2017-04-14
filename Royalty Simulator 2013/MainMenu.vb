Public Class MainMenu
    Dim Count As Integer = 1
    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If PhilMode = False Then
            DeactivatePhilMode()
        ElseIf PhilMode = True Then
            ActivatePhilMode()
        End If
    End Sub
    Private Sub btnPhilMode_Click(sender As Object, e As EventArgs) Handles btnPhilMode.Click
        If PhilMode = False Then
            PhilMode = True
            ActivatePhilMode()
        ElseIf PhilMode = True Then
            PhilMode = False
            DeactivatePhilMode()
        End If
    End Sub
    Private Sub btnQuitGame_Click(sender As Object, e As EventArgs) Handles btnQuitGame.Click
        SplashScreen.Close()
    End Sub
    Private Sub tmrAnimatePhil_Tick(sender As Object, e As EventArgs) Handles tmrAnimatePhil.Tick
        Randomize()
        Count = Count - 1
        If Count = 0 Then
            picPhil1.Location = New Point(CInt(Int((10 * Rnd()) + (Screen.PrimaryScreen.Bounds.Width / 100) * 1.5625)), CInt(Int((10 * Rnd()) + Screen.PrimaryScreen.Bounds.Height / 100) * 1.30208333333))
            picPhil2.Location = New Point(CInt(Int((10 * Rnd()) + (Screen.PrimaryScreen.Bounds.Width / 100) * 47)), CInt(Int((10 * Rnd()) + Screen.PrimaryScreen.Bounds.Height / 100) * 1.30208333333))
            Count = 1
        End If
    End Sub
    Sub ActivatePhilMode()
        MusicPlayer.PlayBuckInHammPalace()

        tmrAnimatePhil.Enabled = True
        picPhil1.Visible = True
        picPhil2.Visible = True

        btnNewGame.ForeColor = Color.Yellow
        btnNewGame.Font = New Font(btnNewGame.Font, FontStyle.Bold)
        btnLoadGame.ForeColor = Color.Yellow
        btnLoadGame.Font = New Font(btnLoadGame.Font, FontStyle.Bold)
        picCoatofArms.Image = My.Resources.PhilCoatofArms
        btnPhilMode.Text = "Disable Phil Mode"
        btnPhilMode.ForeColor = Color.DarkGray
        btnPhilMode.Font = New Font(btnPhilMode.Font, FontStyle.Regular)
    End Sub
    Sub DeactivatePhilMode()
        MusicPlayer.PlayRuleBritannia()

        tmrAnimatePhil.Enabled = False
        picPhil1.Visible = False
        picPhil2.Visible = False

        btnNewGame.ForeColor = Color.DarkGray
        btnNewGame.Font = New Font(btnNewGame.Font, FontStyle.Regular)
        btnLoadGame.ForeColor = Color.DarkGray
        btnLoadGame.Font = New Font(btnLoadGame.Font, FontStyle.Regular)
        picCoatofArms.Image = My.Resources.UKCoatofArms
        btnPhilMode.Text = "PHIL MODE"
        btnPhilMode.ForeColor = Color.Yellow
        btnPhilMode.Font = New Font(btnPhilMode.Font, FontStyle.Bold)
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

        btnPhilMode.Width = btnNewGame.Width / 2
        btnPhilMode.Location = New Point(btnNewGame.Location.X + (btnNewGame.Width / 2), (pnlMenu.Height / 100) * 50)

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
End Class

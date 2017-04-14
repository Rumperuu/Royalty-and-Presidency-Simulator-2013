Public Class Intro
    Dim Count As Integer = 1
    Dim IntroText As String
    Dim CurrLetter As String
    Dim Letter As Integer = 1
    Private Sub Intro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.Audio.Stop()
            MusicPlayer.PlayGodSavetheKing()
        IntroText = "You are " & ThePlayer.Name & ", the " & ThePlayer.Party & " Presidential candidate." & vbCrLf & vbCrLf _
        & "The former president is ousted as a crook, and you go on to win the next election in a landslide." & vbCrLf & vbCrLf & "The year is " & ThePlayer.CurrYear & "." & vbCrLf _
        & "So begins the presidency of " & ThePlayer.Name & "." & vbCrLf & vbCrLf & "My country, 'tis of thee."
        lblIntro.Text = ""
        tmrText.Enabled = True
    End Sub
    Private Sub tmrText_Tick(sender As Object, e As EventArgs) Handles tmrText.Tick
        Count = Count - 1
        If Count = 0 Then
            Try
                CurrLetter = Mid(IntroText, Letter, 3)
                lblIntro.Text = lblIntro.Text & CurrLetter
                Count = 1
                Letter = Letter + 3
            Catch
                tmrText.Enabled = False
            End Try
        End If
    End Sub
    Private Sub Intro_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        lblIntro.Width = Screen.PrimaryScreen.Bounds.Width - ((Screen.PrimaryScreen.Bounds.Width / 100) * 20)
        lblIntro.Height = Screen.PrimaryScreen.Bounds.Height - ((Screen.PrimaryScreen.Bounds.Height / 100) * 30)
        lblIntro.Location = New Point((Screen.PrimaryScreen.Bounds.Width / 100) * 10, (Screen.PrimaryScreen.Bounds.Height / 100) * 15)
        btnContinue.Width = (Screen.PrimaryScreen.Bounds.Width / 100) * 30
        btnContinue.Location = New Point(((Screen.PrimaryScreen.Bounds.Width / 2) - (btnContinue.Width / 2)), (Screen.PrimaryScreen.Bounds.Height - ((Screen.PrimaryScreen.Bounds.Height / 100) * 10)))
    End Sub

    Private Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        DefaultView.Show()
        Me.Close()
    End Sub
End Class
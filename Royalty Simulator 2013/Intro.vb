Public Class Intro
    Dim Count As Integer = 1
    Dim IntroText As String
    Dim CurrLetter As String
    Dim Letter As Integer = 1
    Dim Save As String
    Private Sub Intro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.Audio.Stop()
        If ThePlayer.PhilMode = True Then
            MusicPlayer.PlayOneLove()
            IntroText = "You wake up one morning as Phil, somehow now king of the United Kingdom of Great Britain and Northern Ireland." & vbCrLf & vbCrLf _
            & "Your first royal act should probably be to bestow riches and knighthoods upon any royal subject dedicated enough to make you your own mode in a royalty simulator." & vbCrLf & vbCrLf _
            & "The year is " & ThePlayer.CurrYear & "." & vbCrLf & "So begins the rule of Phil." & vbCrLf & vbCrLf & "God save the king."
            btnContinue.Text = "Agree to bestow gifts and continue"
        ElseIf ThePlayer.PhilMode = False Then
            If ThePlayer.Gender = 1 Then
                MusicPlayer.PlayGodSavetheKing()
                Save = "king."
            ElseIf ThePlayer.Gender = 0 Then
                MusicPlayer.PlayGodSavetheQueen()
                Save = "queen."
            End If
            IntroText = "You are " & ThePlayer.Name & ", next in line to the throne of the United Kingdom of Great Britain and Northern Ireland." & vbCrLf & vbCrLf _
            & "News reaches you of the death of the former monarch in a tragic horse polo accident." & vbCrLf & vbCrLf & "The year is " & ThePlayer.CurrYear & "." & vbCrLf _
            & "So begins the rule of " & ThePlayer.Name & "." & vbCrLf & vbCrLf & "God save the " & Save
        End If
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
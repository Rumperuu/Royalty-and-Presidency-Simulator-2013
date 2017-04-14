Public Class MusicPlayer
    Public Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLength As Integer, ByVal hwndCallback As Integer) As Integer
    Dim musicAlias As String
    Dim musicPath As String
    Dim Track As Integer
    Sub PlayRuleBritannia()
        My.Computer.Audio.Stop()
        My.Computer.Audio.Play(My.Resources.RuleBritannia, AudioPlayMode.BackgroundLoop)
    End Sub
    Sub PlayGodSavetheKing()
        My.Computer.Audio.Stop()
        My.Computer.Audio.Play(My.Resources.GodSavetheKing, AudioPlayMode.BackgroundLoop)
    End Sub
    Sub PlayGodSavetheQueen()
        My.Computer.Audio.Stop()
        My.Computer.Audio.Play(My.Resources.GodSavetheQueen, AudioPlayMode.BackgroundLoop)
    End Sub
    Sub PlayOneLove()
        My.Computer.Audio.Stop()
        My.Computer.Audio.Play(My.Resources.OneLove, AudioPlayMode.BackgroundLoop)
    End Sub
    Sub PlayBuckInHammPalace()
        My.Computer.Audio.Stop()
        My.Computer.Audio.Play(My.Resources.BukInHammPalace, AudioPlayMode.BackgroundLoop)
    End Sub
    Sub PlayAbdication()
        My.Computer.Audio.Play(My.Resources.AutoDestructSequenceArmed, AudioPlayMode.WaitToComplete)
        If ThePlayer.PhilMode = True Then
            PlayOneLove()
        ElseIf ThePlayer.PhilMode = False Then
            If ThePlayer.Gender = 1 Then
                PlayGodSavetheKing()
            ElseIf ThePlayer.Gender = 0 Then
                PlayGodSavetheQueen()
            End If
        End If
    End Sub
    Sub PlayDeath()
        My.Computer.Audio.Stop()
        If ThePlayer.PhilMode = True Then
            My.Computer.Audio.Play(My.Resources.YouAreDead, AudioPlayMode.BackgroundLoop)
        ElseIf ThePlayer.PhilMode = False Then
            My.Computer.Audio.Play(My.Resources.LastPost, AudioPlayMode.BackgroundLoop)
        End If
    End Sub
End Class
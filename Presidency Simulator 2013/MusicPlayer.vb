Public Class MusicPlayer
    Public Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLength As Integer, ByVal hwndCallback As Integer) As Integer
    Dim musicAlias As String
    Dim musicPath As String
    Dim Track As Integer
    Sub PlayRuleBritannia()
        My.Computer.Audio.Stop()
        My.Computer.Audio.Play(My.Resources.battle_hymn_of_the_republic, AudioPlayMode.BackgroundLoop)
    End Sub
    Sub PlayGodSavetheKing()
        My.Computer.Audio.Stop()
        My.Computer.Audio.Play(My.Resources.Mormon_Tabernacle_Choir___The_Star_Spangled_Banner, AudioPlayMode.BackgroundLoop)
    End Sub
    Sub PlayAbdication()
        My.Computer.Audio.Play(My.Resources.AutoDestructSequenceArmed, AudioPlayMode.WaitToComplete)
        PlayGodSavetheKing()
    End Sub
    Sub PlayDeath()
        My.Computer.Audio.Stop()
        My.Computer.Audio.Play(My.Resources.taps, AudioPlayMode.BackgroundLoop)
    End Sub
End Class
Public Class SplashScreen
    Dim Count As Integer = 0
    Dim LiesP1(22) As String
    Dim LiesP2(22) As String
    Dim Check As Integer = 0
    Private Sub SplashScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Lies()

        MonthsSet()

        GovtSet()

        ArgieSet()

        Randomize()
        lblLies.Text = LiesP1(22 * Rnd()) & " " & LiesP2(22 * Rnd())

        tmrLoading.Enabled = True

        MusicPlayer.Hide()
    End Sub
    Sub Lies()
        LiesP1(0) = "undoing"
        LiesP1(1) = "triangulating"
        LiesP1(2) = "decoding"
        LiesP1(3) = "turtling"
        LiesP1(4) = "calculating"
        LiesP1(5) = "transcoding"
        LiesP1(6) = "observing"
        LiesP1(7) = "translating"
        LiesP1(8) = "hypothesising"
        LiesP1(9) = "polymorphing"
        LiesP1(10) = "flipping"
        LiesP1(11) = "reticulating"
        LiesP1(12) = "phalanging"
        LiesP1(13) = "turborizing"
        LiesP1(14) = "compelling"
        LiesP1(15) = "uttering"
        LiesP1(16) = "fondling"
        LiesP1(17) = "guessing"
        LiesP1(18) = "chundling"
        LiesP1(19) = "bundling"
        LiesP1(20) = "rastafaring"
        LiesP1(21) = "ripping"

        LiesP2(0) = "everything"
        LiesP2(1) = "code"
        LiesP2(2) = "sums"
        LiesP2(3) = "hexagons"
        LiesP2(4) = "rolls"
        LiesP2(5) = "beeps"
        LiesP2(6) = "compulsion"
        LiesP2(7) = "singularity engine"
        LiesP2(8) = "boops"
        LiesP2(9) = "the machine spirit"
        LiesP2(10) = "observance"
        LiesP2(11) = "splines"
        LiesP2(12) = "guesses"
        LiesP2(13) = "stuff"
        LiesP2(14) = "things"
        LiesP2(15) = "dreams"
        LiesP2(16) = "reticules"
        LiesP2(17) = "decoders"
        LiesP2(18) = "bipbops"
        LiesP2(19) = "kinematics"
        LiesP2(20) = "twaddleplops"
        LiesP2(21) = "royalty"
    End Sub
    Sub MonthsSet()
        Months(0) = 31
        Months(2) = 31
        Months(3) = 30
        Months(4) = 31
        Months(5) = 30
        Months(6) = 31
        Months(7) = 31
        Months(8) = 30
        Months(9) = 31
        Months(10) = 30
        Months(11) = 31

        TheMonth(0) = "January"
        TheMonth(1) = "February"
        TheMonth(2) = "March"
        TheMonth(3) = "April"
        TheMonth(4) = "May"
        TheMonth(5) = "June"
        TheMonth(6) = "July"
        TheMonth(7) = "August"
        TheMonth(8) = "September"
        TheMonth(9) = "October"
        TheMonth(10) = "November"
        TheMonth(11) = "December"
    End Sub
    Sub GovtSet()
        Government(0) = "MRLP"
        Government(1) = "Labour"
        Government(2) = "Lib Dems"
        Government(3) = "BNP"
        Government(4) = "Conservative"
        Government(5) = "UKIP"
        Government(6) = "SNP"
        Government(7) = "Plaid Cymru"
        Government(8) = "Green Party"
        Government(9) = "Republican"
    End Sub
    Sub ArgieSet()
        ArgieButthurt(0) = "Ruffled"
        ArgieButthurt(1) = "Miffed"
        ArgieButthurt(2) = "Peeved"
        ArgieButthurt(3) = "Irritated"
        ArgieButthurt(4) = "Annoyed"
        ArgieButthurt(5) = "Affronted"
        ArgieButthurt(6) = "Angered"
        ArgieButthurt(7) = "Liviv"
        ArgieButthurt(8) = "Furious"
        ArgieButthurt(9) = "Maddened with rage"
        ArgieButthurt(10) = "Frothing at the mouth"
        ArgieButthurt(11) = "Eye-twitchingly angry"
        ArgieButthurt(12) = "Screaming obscenities at the elderly"
        ArgieButthurt(13) = "Colon crucified"
    End Sub

    Private Sub tmrLoading_Tick(sender As Object, e As EventArgs) Handles tmrLoading.Tick
        If Count < 100 Then
            If Count < 95 Then
                Count = Count + CInt(Int(5 * Rnd()))
            ElseIf Count >= 95 Then
                Count = Count + CInt(Int((100 - Count) * Rnd()) + 1)
            End If
            lblLoading.Text = Count & "%"
            If Count > Check Then
                Check = Check + 10
                Randomize()
                lblLies.Text = LiesP1(12 * Rnd()) & " " & LiesP2(12 * Rnd())
            End If
        Else
            tmrLoading.Enabled = False
            Me.Hide()
            MainMenu.Show()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Count = 100
    End Sub
End Class
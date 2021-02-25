Public Class Form1
    Dim msec As Long
    Dim ende As Boolean
    Dim dbase As Long
    Dim cd As Date

    Sub alarmup()
        NotifyIcon1.ShowBalloonTip(5000)
        MsgBox("Times up! Please stop the timer, otherwise will alarm after 5 min.", vbInformation + vbSystemModal)
        If Not ende Then
            msec = 300
            Timer2.Enabled = True
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MsgBox(DateDiff("n", DateTime.Now, CDate(Format(DateTime.Now, "yyyy/MM/dd") & " 13:00")))
        'NotifyIcon1.ShowBalloonTip(2000)
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer1.Enabled = True
        cd = CDate(Format(DateTimePicker1.Value.Date, "yyyy/MM/dd") & " " & DateTimePicker2.Text)
        'MsgBox(Timer1.Enabled)
        ende = False
        'MsgBox(DateTimePicker2.Text)
        'MsgBox(Format(DateTimePicker1.Value.Date, "yyyy/MM/dd") & " " & DateTimePicker2.Text)
        dbase = DateDiff("s", DateTime.Now, cd)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim d As Long
        d = DateDiff("s", DateTime.Now, cd)
        'MsgBox(d)
        If d <= 0 Then
            Timer1.Enabled = False
            Label2.Text = "Times up!"
            ProgressBar1.Value = ProgressBar1.Minimum
            alarmup()
        Else
            Dim m As Long
            Dim s As Long
            s = d Mod 60
            m = Math.Floor(d / 60)
            Label2.Text = "Time remaining: " & m.ToString("00") & ":" & s.ToString("00")
            ProgressBar1.Value = Math.Ceiling((d * 100) / dbase)
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        msec = msec - 1
        If msec = 0 Then
            Timer2.Enabled = False
            alarmup()
        End If
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        ende = True
    End Sub
End Class

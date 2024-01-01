Public Class Reminder
    Private Sub Reminder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call CenterToScreen()
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False

    End Sub

    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        DPT.RemCase = 0
        DPT.SaveFile()
        Me.Dispose()


    End Sub

    Private Sub DSave_Click(sender As Object, e As EventArgs) Handles DSave.Click
        Me.Dispose()
        DPT.Dispose()

    End Sub

    Private Sub Close_Click(sender As Object, e As EventArgs) Handles Close.Click
        Me.Dispose()
    End Sub
End Class
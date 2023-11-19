Public Class TestInfo
    Private Sub TestInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call CenterToScreen()
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.TopMost = True
        Me.MinimizeBox = False


    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class
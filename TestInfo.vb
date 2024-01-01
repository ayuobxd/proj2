Public Class TestInfo
    Public ourDevice As List(Of DPT.DeviseStr)
    Public SelD As Integer
    Public testn As String
    Public testd As DateTime
    Private Sub TestInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call CenterToScreen()
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.TopMost = True
        Me.MinimizeBox = False


        LoadT()

    End Sub

    Public Sub LoadT()
        TextBox1.Text = testn

        TextBox2.Text = ourDevice.Item(SelD).Name
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("Default")
        TextBox3.Text = ourDevice.Item(SelD).standard
    End Sub
    Public Sub SaveT()
        testn = TextBox1.Text
        testd = DateTimePicker1.Value

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SaveT()
        Me.Dispose()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()

    End Sub
End Class
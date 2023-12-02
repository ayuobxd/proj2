Public Class Layers

    Public ourLayers As List(Of Menu.LayerDta)

    Public Sub LoadLayers()
        CheckedListBox1.Items.Clear()

        For i = 0 To ourLayers.Count - 1
            CheckedListBox1.Items.Add(ourLayers.Item(i).Name)
        Next i

    End Sub

    Private Sub Layers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.BackColor = Color.Black
        LoadLayers()

    End Sub

    Private Sub Panel1_Click(sender As Object, e As EventArgs) Handles Panel1.Click
        Dim cDialog As New ColorDialog()
        cDialog.Color = Panel1.BackColor ' initial selection is current color.

        If (cDialog.ShowDialog() = DialogResult.OK) Then
            Panel1.BackColor = cDialog.Color ' update with user selected color.
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim P As Menu.LayerDta
        P.Name = TextBox1.Text
        P.R = Panel1.BackColor.R
        P.G = Panel1.BackColor.G
        P.B = Panel1.BackColor.B
        ourLayers.Add(P)
        LoadLayers()
    End Sub
End Class
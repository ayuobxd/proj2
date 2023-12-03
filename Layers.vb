Public Class Layers

    Public ourLayers As List(Of Menu.LayerDta)
    Public LayerN
    Public LayerC As New List(Of Integer)


    Public Sub LoadLayers()
        CheckedListBox1.Items.Clear()

        For i = 0 To ourLayers.Count - 1
            CheckedListBox1.Items.Add(ourLayers.Item(i).Name)
            If LayerC.Contains(i) Then
                CheckedListBox1.SetItemChecked(i, True)
            Else
                CheckedListBox1.SetItemChecked(i, False)
            End If


        Next i







    End Sub

    Private Sub Layers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.BackColor = Color.Black
        LoadLayers()



    End Sub

    Private Sub Panel1_Click(sender As Object, e As EventArgs) Handles Panel1.Click
        Dim cDialog As New ColorDialog()
        cDialog.Color = Panel1.BackColor

        If (cDialog.ShowDialog() = DialogResult.OK) Then
            Panel1.BackColor = cDialog.Color
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
        LayerN = ourLayers.Count
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim cheq As New Text.StringBuilder
        LayerC.Clear()
        For Each item In CheckedListBox1.CheckedIndices
            'cheq.Clear()
            'cheq.Append(item)

            LayerC.Add(item)


        Next




    End Sub
End Class
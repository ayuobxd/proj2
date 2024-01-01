Public Class InputData

    Public ourData As List(Of DPT.DataStr)
    Public layersInput As List(Of DPT.LayerDta)
    Public OurDevices As List(Of DPT.DeviseStr)
    Public Dev As Integer
    Public Sub Calculate()
        Console.WriteLine(Dev)
        Console.WriteLine(OurDevices.Item(0).Hammer)
        Console.WriteLine(OurDevices.Item(1).Hammer)
        Console.WriteLine(OurDevices.Item(2).Hammer)
        Dim Rd As Double
        Dim Qd As Double
        Dim Mh As Double = OurDevices.Item(Dev).Hammer
        Dim G As Double = 9.81
        Dim H As Double = OurDevices.Item(Dev).FallingH / 100
        Dim A As Double = OurDevices.Item(Dev).AOfCone * 100
        Dim e As Double
        Dim Mt As Double = OurDevices.Item(Dev).AnvilGuide

        For i = 0 To DataGridView1.RowCount - 2
            DataGridView1.Rows(i).Cells(0).Value = 0.2 * (i + 1)
            DataGridView1.Rows(i).Cells(1).Value = 20
            e = 0.2 / DataGridView1.Rows(i).Cells(2).Value
            Rd = ((Mh * G * H) / (A * e))
            DataGridView1.Rows(i).Cells(3).Value = Rd
            Qd = Rd * (Mh / (Mh + Mt))
            DataGridView1.Rows(i).Cells(4).Value = Qd

        Next i





    End Sub




    Public Sub SaveDataGrid()

        ourData.Clear()

        For i = 0 To DataGridView1.RowCount - 1
            Dim P As DPT.DataStr
            P.depth = DataGridView1.Rows(i).Cells(0).Value
            P.notch = DataGridView1.Rows(i).Cells(1).Value
            P.Nb = DataGridView1.Rows(i).Cells(2).Value
            P.rd = DataGridView1.Rows(i).Cells(3).Value
            P.qd = DataGridView1.Rows(i).Cells(4).Value

            ourData.Add(P)

        Next i

    End Sub

    Public Sub LoadDataGrid()

        Dim A, B, C, D, F As Double
        For i = 0 To ourData.Count - 2
            Dim row As String()
            A = ourData.Item(i).depth
            B = ourData.Item(i).notch
            C = ourData.Item(i).Nb
            D = ourData.Item(i).rd
            F = ourData.Item(i).qd

            row = New String() {A, B, C, D, F}
            DataGridView1.Rows.Add(row)

            Calculate()
        Next i


    End Sub

    Private Sub InputData_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call CenterToScreen()
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.TopMost = True
        Me.MinimizeBox = False
        DataGridView1.ColumnCount = 5
        DataGridView1.Columns(0).Name = "Depthe (m)"
        DataGridView1.Columns(1).Name = "Notches (cm)"
        DataGridView1.Columns(2).Name = "N of blows"
        DataGridView1.Columns(3).Name = "rd (bar)"
        DataGridView1.Columns(4).Name = "qd (bar)"


        ComboBox1.Items.Clear()

        For i = 0 To layersInput.Count - 1
            ComboBox1.Items.Add(layersInput.Item(i).Name)
        Next i
        ComboBox1.Text = "Select from..."






        LoadDataGrid()



    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        SaveDataGrid()
        Me.Dispose()
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Me.Dispose()

    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        Calculate()

    End Sub
End Class
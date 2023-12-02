Public Class InputData

    Public ourData As List(Of Menu.DataStr)
    Public Array As List(Of List(Of Menu.DataStr2))()




    Public Sub SaveDataGrid()


        For i = 0 To DataGridView1.RowCount - 1
            Dim P As Menu.DataStr
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









        If ourData.Count = 0 Then
            Dim A As Double = 0
            Dim B As Integer = 20
            Dim C As Integer = 0
            Dim D As Integer = 0
            Dim F As Integer = 0
            For i = 0 To 50
                Dim row As String()
                Dim randomValue1 As Integer
                Dim randomValue2 As Double
                Dim randomValue3 As Double
                randomValue3 = CInt(((6 - (2) + 1) * Rnd())) + (2)
                randomValue2 = CInt(((30 - (4) + 1) * Rnd())) + (4)
                randomValue1 = CInt(Math.Floor((14 - (0) + 1) * Rnd())) + (0)
                row = New String() {A, B, C, D, F}
                DataGridView1.Rows.Add(row)
                A += 0.2
                B = 20
                C = randomValue1
                D = randomValue2
                F = randomValue3
            Next i
            'Temp
        ElseIf ourData.Count > 0 Then
            LoadDataGrid()

        End If

    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        SaveDataGrid()
        Me.Dispose()
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Me.Dispose()

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

    End Sub
End Class
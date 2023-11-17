Public Class InputData
    Private Sub InputData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call CenterToScreen()
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = MaximizeBox.Equals(0)


    End Sub


    Function GetTable() As DataTable

        Console.WriteLine(DataGridView1.RowCount) '3 4
        Console.WriteLine(DataGridView1.ColumnCount) '5
        Dim List(((DataGridView1.RowCount) - 1), 5) As Double
        For i = 0 To ((DataGridView1.RowCount) - 2)
            For j = 0 To 4
                List(i, j) = CDbl(DataGridView1.Rows(i).Cells(j).Value)

            Next j
            Console.WriteLine(",{0},{1},{2},{3},{4}", List(i, 0), List(i, 1), List(i, 2), List(i, 3), List(i, 4))
        Next i

    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GetTable()
    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        GetTable()
    End Sub

End Class
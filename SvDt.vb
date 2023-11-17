Public Class SvDt

    Public Shared Data(InputData.DataGridView1.RowCount, 4) As Double
    Public Shared lg As Integer
    Public Shared ld As Integer

    Public Shared Sub GetTable()




        lg = InputData.DataGridView1.RowCount - 2
        ld = InputData.DataGridView1.ColumnCount - 1
        ReDim Data(lg, ld)
        For i = 0 To lg
            For j = 0 To ld
                Data(i, j) = CDbl(InputData.DataGridView1.Rows(i).Cells(j).Value)
                Console.WriteLine(Data(i, j))
            Next j

        Next i




    End Sub
End Class

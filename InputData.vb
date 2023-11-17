Public Class InputData

    Private Sub InputData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call CenterToScreen()
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = MaximizeBox.Equals(0)

        DataGridView1.ColumnCount = 5
        DataGridView1.Columns(0).Name = "Depthe (m)"
        DataGridView1.Columns(1).Name = "Notches (cm)"
        DataGridView1.Columns(2).Name = "N of blows"
        DataGridView1.Columns(3).Name = "rd (bar)"
        DataGridView1.Columns(4).Name = "qd (bar)"

        Console.WriteLine(SvDt.Data.Length)
        If SvDt.Data.Length > 5 Then
            For i = 0 To SvDt.lg
                Dim row As String()
                row = New String() {SvDt.Data(i, 0), SvDt.Data(i, 1), SvDt.Data(i, 2), SvDt.Data(i, 3), SvDt.Data(i, 4)}
                DataGridView1.Rows.Add(row)
            Next i
        End If

    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SvDt.GetTable()
        Me.Dispose()
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub
End Class
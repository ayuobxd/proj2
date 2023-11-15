Public Class Menu

    Dim x01 As Integer = 20
    Dim y01 As Integer = 20
    Dim x02 As Integer = 20
    Dim y02 As Integer = 20
    'lines drawing
    Dim x1 As Integer
    Dim x2 As Integer
    Dim y1 As Integer
    Dim y2 As Integer
    'counters
    Dim i As Integer
    Dim j As Integer
    Dim r As Integer
    Dim t As Integer = 1
    Dim o As Integer
    'line numbers
    Dim LengthL As Integer
    Dim LengthC As Integer
    Dim l As Integer
    'spacers
    Dim ex As Integer
    Dim ey As Integer

    Dim n As Integer
    Dim m As Integer

    Dim P1 As Point
    Dim P2 As Point

    Dim data As Double

    Dim ListDeoth As List(Of Double)
    Dim ListNotches As List(Of Integer)
    Dim ListBlowsN As List(Of Integer)
    Dim ListRd As List(Of Integer)
    Dim ListQd As List(Of Integer)

    Function GetTable() As DataTable
        ' Create new DataTable instance and clear it.
        Dim table As New DataTable
        table.Clear()
        ' Create columns in the DataTable.


        ' Add rows with those columns filled in the DataTable.


        Console.WriteLine()
        l = CInt(InputData.DataGridView1.RowCount) - 1
        r = 0
        o = 0
        Do Until r = l
            Do Until o = 5




                o += 1
            Loop
            r += 1
        Loop



            Return table
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call CenterToScreen()
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = MaximizeBox.Equals(0)



    End Sub

    Sub CloseAll()
        TestInfo.Dispose()
        Device.Dispose()
        InputData.Visible = False
    End Sub

    Private Sub TestInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestInfoToolStripMenuItem.Click
        CloseAll()
        TestInfo.Visible = True
    End Sub

    Private Sub DeviceInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeviceInfoToolStripMenuItem.Click
        CloseAll()
        Device.Visible = True
    End Sub

    Private Sub DirectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DirectToolStripMenuItem.Click
        CloseAll()
        InputData.Visible = True
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        Try
            Dim mygraphics As Graphics = e.Graphics
            Dim MyPenB As Pen
            Dim MyPenR As Pen
            Dim pn As New Pen(Me.ForeColor)
            MyPenB = New Pen(Brushes.Black, 1)
            MyPenR = New Pen(Brushes.Red, 1)
            MyPenR.DashStyle = Drawing2D.DashStyle.Dash
            pn.Width = 10
            pn.DashStyle = Drawing2D.DashStyle.Dash

            Dim fnt As New Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Point)
            x1 = 0
            x2 = 0
            y1 = 0
            y2 = 0
            l = CInt(InputData.DataGridView1.RowCount) - 1
            r = 0
            LengthL = 0
            LengthC = 0
            Do Until r = l
                t = CInt(InputData.DataGridView1.Rows(r).Cells(0).Value)
                If t > LengthC Then
                    LengthC = t

                End If
                r += 1
            Loop

            r = 0
            Do Until r = l
                t = CInt(InputData.DataGridView1.Rows(r).Cells(1).Value)
                If t > LengthL Then
                    LengthL = t

                End If
                r += 1
            Loop




            n = Math.Ceiling(LengthL / 10)
            m = Math.Ceiling(LengthC / 10)

            ex = 0
            ey = 0
            i = 0
            j = 0
            Do Until i > 10

                mygraphics.DrawLine(MyPenB, 0 + x01, y1 + y01, 500 + x01, y2 + y01)
                mygraphics.DrawString(ex, fnt, Brushes.Black, 515 + x01, y2 + y01)
                y1 += 50
                y2 += 50
                i += 1
                ex += m
            Loop

            Do Until j > 10

                mygraphics.DrawLine(MyPenB, x1 + x02, 0 + y02, x2 + x02, 500 + y02)
                mygraphics.DrawString(ey, fnt, Brushes.Black, x2 + x02, 515 + y02)
                x1 += 50
                x2 += 50
                j += 1
                ey += n
            Loop
            r = 1
            Do Until r = l

                P1.Y = ((InputData.DataGridView1.Rows(r - 1).Cells(0).Value) * 50) / m
                P1.X = ((InputData.DataGridView1.Rows(r - 1).Cells(1).Value) * 50) / n
                P2.Y = ((InputData.DataGridView1.Rows(r).Cells(0).Value) * 50) / m
                P2.X = ((InputData.DataGridView1.Rows(r).Cells(1).Value) * 50) / n
                mygraphics.DrawLine(MyPenR, P1.X + x02, P1.Y + y02, P2.X + x02, P2.Y + y02)
                r += 1
            Loop
        Catch ex As Exception
        End Try

    End Sub
    Private Sub Form1_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
        PictureBox1.Invalidate()
        Console.WriteLine("COLUMNS: {0}", table.Columns.Count)
        Console.WriteLine("ROWS: {0}", table.Rows.Count)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        PictureBox1.Invalidate()
    End Sub


End Class

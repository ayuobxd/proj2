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


    'line numbers
    Dim LengthL As Integer
    Dim LengthC As Integer

    'spacers
    Dim ex As Integer
    Dim ey As Integer

    Dim n As Integer
    Dim m As Integer

    Dim P1 As Point
    Dim P2 As Point





    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call CenterToScreen()
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False



    End Sub



    Sub CloseAll()
        TestInfo.Dispose()
        Device.Dispose()
        InputData.Dispose()
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
        SvDt.GetTable()
    End Sub



    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        Try
            Dim mygraphics As Graphics = e.Graphics
            Dim MyPenB As Pen
            Dim MyPenR As Pen

            MyPenB = New Pen(Brushes.Black, 1)
            MyPenR = New Pen(Brushes.Red, 3)
            MyPenR.DashStyle = Drawing2D.DashStyle.Dash


            Dim fnt As New Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Point)


            LengthL = 0
            LengthC = 0
            For i = 0 To SvDt.lg


                If (SvDt.Data(i, 0)) > LengthC Then
                    LengthC = SvDt.Data(i, 0)
                End If
                If (SvDt.Data(i, 1)) > LengthL Then
                    LengthL = SvDt.Data(i, 1)
                End If
            Next i

            n = Math.Ceiling(LengthL / 10)
            m = Math.Ceiling(LengthC / 10)

            x1 = 0
            x2 = 0
            y1 = 0
            y2 = 0

            ex = 0
            ey = 0

            For i = 0 To 10

                mygraphics.DrawLine(MyPenB, 0, y1, 500, y2)
                mygraphics.DrawString(ex, fnt, Brushes.Black, 515, y2)
                y1 += 50
                y2 += 50
                ex = ex + m

                mygraphics.DrawLine(MyPenB, x1, 0, x2, 500)
                mygraphics.DrawString(ey, fnt, Brushes.Black, x2, 515)
                x1 += 50
                x2 += 50
                ey += n

            Next i

            For i = 1 To SvDt.lg
                P1.X = ((SvDt.Data(i - 1, 1) * 50) / n)
                P1.Y = ((SvDt.Data(i - 1, 0) * 50) / m)

                P2.X = ((SvDt.Data(i, 1) * 50) / n)
                P2.Y = ((SvDt.Data(i, 0) * 50) / m)

                mygraphics.DrawLine(MyPenR, P1.X + x02, P1.Y + y02, P2.X + x02, P2.Y + y02)

            Next i
        Catch ex As Exception
        End Try

    End Sub


    Private Sub DynamicPointResistanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DynamicPointResistanceToolStripMenuItem.Click
        PictureBox1.Invalidate()
    End Sub
End Class

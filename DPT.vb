Public Class Menu
    Public Structure DataStr
        Public depth, notch, Nb, rd, qd As Double
    End Structure

    Public Structure DataStr2
        Public layer As String
        Public depth, notch, Nb, rd, qd As Double
    End Structure

    Public Structure LayerDta
        Public Name, R, G, B As String
    End Structure

    Public Structure DeviseStr
        Public Name, Hammer, AnvilGuide, rodes, FallingH, AOfCone, LOfRodes, Notches, standard As String
    End Structure

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
    Dim LengthL As Double
    Dim LengthC As Double

    'spacers
    Dim ex As Double
    Dim ey As Double

    Dim n As Double
    Dim m As Double

    Dim P1 As Point
    Dim P2 As Point
    Dim tempArray As List(Of List(Of DataStr2))()

    Dim Donee As New List(Of DataStr)
    Dim Devices As New List(Of DeviseStr)
    Dim Layer As New List(Of LayerDta)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call CenterToScreen()
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False

        Label2.Text = "."
        Label3.Text = "."
        Label4.Text = "."
        Label5.Text = "."
        Label6.Text = "."
        Label7.Text = "."
        Label9.Text = "."

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
        Dim Frm As New Device
        Frm.ourDevice = Devices
        Frm.ShowDialog()
        Devices = Frm.ourDevice
        Frm.Dispose()
        PictureBox1.Invalidate()
    End Sub

    Private Sub DirectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DirectToolStripMenuItem.Click
        CloseAll()
        Dim Frm As New InputData
        Frm.ourData = Donee
        Frm.ShowDialog()
        Donee = Frm.ourData
        Frm.Dispose()
        PictureBox1.Invalidate()
    End Sub

    Private Sub LayersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LayersToolStripMenuItem.Click
        CloseAll()
        Dim Frm As New Layers
        Frm.ourLayers = Layer
        Frm.ShowDialog()
        Layer = Frm.ourLayers
        Frm.Dispose()
        PictureBox1.Invalidate()
    End Sub

    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        Try
            Dim mygraphics As Graphics = e.Graphics
            Dim MyPenB As Pen
            Dim MyPenR As Pen

            MyPenB = New Pen(Brushes.Black, 1)
            MyPenR = New Pen(Brushes.Red, 3)
            MyPenR.DashStyle = Drawing2D.DashStyle.Dash
            MyPenB.Color = Color.FromArgb(0, 0, 0)
            MyPenB.Color = Color.FromArgb(0, 0, 0)
            Dim fnt As New Font("Cambria", 10, FontStyle.Regular, GraphicsUnit.Point)


            LengthL = 0
            LengthC = 0
            For i = 0 To Donee.Count - 2


                If (Donee.Item(i).depth) > LengthC Then
                    LengthC = Donee.Item(i).depth
                End If
                If (Donee.Item(i).rd) > LengthL Then
                    LengthL = Donee.Item(i).rd
                End If
            Next i

            n = Math.Ceiling(LengthL / 10)
            If LengthC < 10 Then
                m = (Math.Ceiling(LengthC)) / 10
            Else
                m = Math.Ceiling(LengthC / 10)
            End If

            x1 = 0
            x2 = 0
            y1 = 0
            y2 = 0

            ex = 0
            ey = 0

            For i = 0 To 10

                mygraphics.DrawLine(MyPenB, 0 + x01, y1 + y01, 200 + x01, y2 + y01)
                mygraphics.DrawString(ex, fnt, Brushes.Black, 215 + x01, y2 + y01)
                y1 += 50
                y2 += 50
                ex = ex + m

                mygraphics.DrawLine(MyPenB, x1 + x01, 0 + y01, x2 + x01, 500 + y01)
                mygraphics.DrawString(ey, fnt, Brushes.Black, x2 + x01, 515 + y01)
                x1 += 20
                x2 += 20
                ey += n

            Next i

            For i = 1 To Donee.Count - 2

                P1.X = ((Donee.Item(i - 1).rd * 20) / n)
                P1.Y = ((Donee.Item(i - 1).depth * 50) / m)

                P2.X = ((Donee.Item(i).rd * 20) / n)
                P2.Y = ((Donee.Item(i).depth * 50) / m)

                mygraphics.DrawLine(MyPenR, P1.X + x02, P1.Y + y02, P2.X + x02, P2.Y + y02)

            Next i
        Catch ex As Exception
        End Try

    End Sub


    Private Sub DynamicPointResistanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DynamicPointResistanceToolStripMenuItem.Click
        PictureBox1.Invalidate()
    End Sub


End Class

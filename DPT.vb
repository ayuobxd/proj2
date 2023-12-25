Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Public Class DPT
    Public Structure DataStr
        Public depth, notch, Nb, rd, qd As Double
    End Structure

    Public Structure LayerDta
        Public Name, R, G, B As String
    End Structure

    Public Structure DeviseStr
        Public Name, Hammer, AnvilGuide, rodes, FallingH, AOfCone, LOfRodes, Notches, standard As String
    End Structure


    Dim Notes As String

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



    Dim Donee As New List(Of DataStr)
    Dim Devices As New List(Of DeviseStr)
    Dim Layer As New List(Of LayerDta)

    Public LayersNum As Integer
    Dim LayersChk As New List(Of Integer)
    Dim DevP As Integer = 0

    Dim State As Integer
    Dim LeftS As Integer
    Dim RightS As Integer
    Dim Full As Integer

    Dim TextW As String



    Public TestName As String
    Public TestDate As DateTime

    Dim FileName As String = ""
    Dim SvAs As Boolean = False
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

        'LayersChk.Add("Default")

        Dim P As DeviseStr
        P.Name = "BORRO-B2"
        P.Hammer = 63.5
        P.AnvilGuide = 4.3
        P.rodes = 6.28
        P.FallingH = 50
        P.AOfCone = 15.2
        P.LOfRodes = 1
        P.Notches = 20
        P.standard = "NF P 94-155"
        Devices.Add(P)



    End Sub

    Sub CloseAll()
        TestInfo.Dispose()
        Device.Dispose()
        InputData.Dispose()
    End Sub



    Private Sub TestInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestInfoToolStripMenuItem.Click
        CloseAll()

        Dim Frm As New TestInfo
        Frm.ourDevice = Devices
        Frm.SelD = DevP

        'Frm.testd = TestDate
        Frm.testn = TestName
        Frm.ShowDialog()
        TestName = Frm.testn
        'TestDate = Frm.testd
        Frm.Dispose()
    End Sub

    Private Sub DeviceInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeviceInfoToolStripMenuItem.Click
        CloseAll()
        Dim Frm As New Device
        Frm.ourDevice = Devices
        Frm.SelDev = DevP
        Frm.ShowDialog()
        Devices = Frm.ourDevice
        DevP = Frm.SelDev
        Frm.Dispose()

    End Sub

    Private Sub DirectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DirectToolStripMenuItem.Click
        CloseAll()
        Dim Frm As New InputData
        Frm.ourData = Donee
        Frm.OurDevices = Devices
        Frm.Dev = DevP
        Frm.layersInput = Layer
        Frm.ShowDialog()
        Donee = Frm.ourData
        Devices = Frm.OurDevices
        DevP = Frm.Dev
        Layer = Frm.layersInput
        Frm.Dispose()

    End Sub

    Private Sub LayersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LayersToolStripMenuItem.Click
        ''CloseAll()
        'Dim Frm As New Layers
        'Frm.ourLayers = Layer
        'Frm.LayerC = New List(Of Integer)(LayersChk)
        'Frm.LayerN = LayersNum
        'Frm.ShowDialog()
        'Layer = Frm.ourLayers
        'LayersChk = New List(Of Integer)(Frm.LayerC)
        'LayersNum = Frm.LayerN
        'Frm.Dispose()

    End Sub







    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint

        Dim D As New List(Of Double)
        Dim X As New List(Of Double)
        Dim Y As New List(Of Double)
        Dim Z As New List(Of Double)

        Dim list1 As New List(Of Double)
        Dim list2 As New List(Of Double)


        D.Clear()
        X.Clear()
        Z.Clear()
        Y.Clear()

        list1.Clear()


        For i = 0 To Donee.Count - 1
            Dim a As Double = Donee.Item(i).depth
            Dim b As Double = Donee.Item(i).rd
            Dim c As Double = Donee.Item(i).qd
            Dim f As Double = Donee.Item(i).Nb

            D.Add(a)
            X.Add(b)
            Y.Add(c)
            Z.Add(f)

        Next


        If State = 1 Then
            If Full = 1 Then
                list1 = X
                TextW = "rd (MPa)"
            ElseIf Full = 2 Then
                list1 = Y
                TextW = "qd (MPa)"
            ElseIf Full = 3 Then
                list1 = Z
                TextW = "Number Of Blows"
            End If
            Try

                Dim mygraphics As Graphics = e.Graphics

                Dim MyPenB As Pen
                Dim MyPenR As Pen

                MyPenB = New Pen(Brushes.Black, 1)
                MyPenR = New Pen(Brushes.Red, 3)
                MyPenR.DashStyle = Drawing2D.DashStyle.Dash
                MyPenB.Color = Color.FromArgb(0, 0, 0)

                Dim fnt As New Font("Cambria", 10, FontStyle.Regular, GraphicsUnit.Point)

                LengthL = 0
                LengthC = 0
                For i = 0 To list1.Count - 2


                    If (D(i)) > LengthC Then
                        LengthC = D(i)
                    End If
                    If (list1(i)) > LengthL Then
                        LengthL = list1(i)
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

                    mygraphics.DrawLine(MyPenB, 0 + x01, y1 + y01, 500 + x01, y2 + y01)
                    mygraphics.DrawString(ex, fnt, Brushes.Black, 515 + x01, y2 + y01)
                    y1 += 50
                    y2 += 50
                    ex = ex + m

                    mygraphics.DrawLine(MyPenB, x1 + x01, 0 + y01, x2 + x01, 500 + y01)
                    mygraphics.DrawString(ey, fnt, Brushes.Black, x2 + x01, 515 + y01)
                    x1 += 50
                    x2 += 50
                    ey += n

                Next i

                For i = 1 To Donee.Count - 2

                    P1.X = ((list1(i - 1) * 50) / n)
                    P1.Y = ((D(i - 1) * 50) / m)

                    P2.X = ((list1(i) * 50) / n)
                    P2.Y = ((D(i) * 50) / m)

                    mygraphics.DrawLine(MyPenR, P1.X + x02, P1.Y + y02, P2.X + x02, P2.Y + y02)

                Next i

                mygraphics.DrawString(TextW, fnt, Brushes.Black, 250 - 2 * TextW.Length, 2)
                mygraphics.RotateTransform(90)
                mygraphics.DrawString("Depth (m)", fnt, Brushes.Black, 250, -20)
                mygraphics.ResetTransform()

            Catch ex As Exception
            End Try

            '----------------------------------------------------------------------------------------------------------
        ElseIf State = 2 Then
            If LeftS = 1 Then
                list1 = X
                TextW = "rd (MPa)"
            ElseIf LeftS = 2 Then
                list1 = Y
                TextW = "qd (MPa)"
            ElseIf LeftS = 3 Then
                list1 = Z
                TextW = "Number Of Blows"
            End If
            If LeftS = 1 Or LeftS = 2 Or LeftS = 3 Then
                Try

                    Dim mygraphics As Graphics = e.Graphics

                    Dim MyPenB As Pen
                    Dim MyPenR As Pen

                    MyPenB = New Pen(Brushes.Black, 1)
                    MyPenR = New Pen(Brushes.Red, 3)
                    MyPenR.DashStyle = Drawing2D.DashStyle.Dash
                    MyPenR.Color = Color.FromArgb(0, 0, 255)

                    Dim fnt As New Font("Cambria", 10, FontStyle.Regular, GraphicsUnit.Point)

                    LengthL = 0
                    LengthC = 0
                    For i = 0 To list1.Count - 2


                        If (D(i)) > LengthC Then
                            LengthC = D(i)
                        End If
                        If (list1(i)) > LengthL Then
                            LengthL = list1(i)
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

                        P1.X = ((list1(i - 1) * 20) / n)
                        P1.Y = ((D(i - 1) * 50) / m)

                        P2.X = ((list1(i) * 20) / n)
                        P2.Y = ((D(i) * 50) / m)

                        mygraphics.DrawLine(MyPenR, P1.X + x02, P1.Y + y02, P2.X + x02, P2.Y + y02)

                    Next i
                    mygraphics.DrawString(TextW, fnt, Brushes.Black, 100 - 2 * TextW.Length, 2)
                    mygraphics.RotateTransform(90)
                    mygraphics.DrawString("Depth (m)", fnt, Brushes.Black, 250, -20)
                    mygraphics.ResetTransform()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                End Try
            End If

            If RightS = 1 Then
                list2 = X
                TextW = "rd (MPa)"
            ElseIf RightS = 2 Then
                list2 = Y
                TextW = "qd (MPa)"
            ElseIf RightS = 3 Then
                list2 = Z
                TextW = "Number Of Blows"
            End If

            If RightS = 1 Or RightS = 2 Or RightS = 3 Then
                Try

                    Dim mygraphics As Graphics = e.Graphics

                    Dim MyPenB As Pen
                    Dim MyPenR As Pen

                    MyPenB = New Pen(Brushes.Black, 1)
                    MyPenR = New Pen(Brushes.Red, 3)
                    MyPenR.DashStyle = Drawing2D.DashStyle.Dash
                    MyPenR.Color = Color.FromArgb(0, 255, 0)

                    Dim fnt As New Font("Cambria", 10, FontStyle.Regular, GraphicsUnit.Point)

                    LengthL = 0
                    LengthC = 0
                    For i = 0 To list2.Count - 2


                        If (D(i)) > LengthC Then
                            LengthC = D(i)
                        End If
                        If (list2(i)) > LengthL Then
                            LengthL = list2(i)
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

                        mygraphics.DrawLine(MyPenB, 300 + x01, y1 + y01, 500 + x01, y2 + y01)
                        mygraphics.DrawString(ex, fnt, Brushes.Black, 215 + x01 + 300, y2 + y01)
                        y1 += 50
                        y2 += 50
                        ex += m

                        mygraphics.DrawLine(MyPenB, x1 + x01 + 300, 0 + y01, x2 + x01 + 300, 500 + y01)
                        mygraphics.DrawString(ey, fnt, Brushes.Black, x2 + x01 + 300, 515 + y01)
                        x1 += 20
                        x2 += 20
                        ey += n

                    Next i

                    For i = 1 To Donee.Count - 2

                        P1.X = ((list2(i - 1) * 20) / n)
                        P1.Y = ((D(i - 1) * 50) / m)

                        P2.X = ((list2(i) * 20) / n)
                        P2.Y = ((D(i) * 50) / m)

                        mygraphics.DrawLine(MyPenR, P1.X + x02 + 300, P1.Y + y02, P2.X + x02 + 300, P2.Y + y02)

                    Next i
                    mygraphics.DrawString(TextW, fnt, Brushes.Black, 400 - 2 * TextW.Length, 2)
                    mygraphics.RotateTransform(90)
                    mygraphics.DrawString("Depth (m)", fnt, Brushes.Black, 250, -320)
                    mygraphics.ResetTransform()
                Catch ex As Exception
                End Try
            End If


        End If




    End Sub

    Sub Write()
        RichTextBox1.Text = Notes


        Label2.Text = TestName
        Label3.Text = TestDate
        Label4.Text = "."
        Label5.Text = "."
        Label6.Text = "."
        Label7.Text = "."
        Label9.Text = "."


    End Sub




    Private Sub Space1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Space1ToolStripMenuItem.Click

        State = 2
        RightS = 1
        Full = 0
        PictureBox1.Invalidate()

    End Sub

    Private Sub LeftSpaceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LeftSpaceToolStripMenuItem.Click
        State = 2
        LeftS = 1
        Full = 0
        PictureBox1.Invalidate()
    End Sub

    Private Sub FullSpaceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FullSpaceToolStripMenuItem.Click
        State = 1
        Full = 1
        LeftS = 0
        RightS = 0
        PictureBox1.Invalidate()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        State = 2
        RightS = 2
        Full = 0
        PictureBox1.Invalidate()
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        State = 2
        LeftS = 2
        Full = 0
        PictureBox1.Invalidate()
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        State = 1
        Full = 2
        LeftS = 0
        RightS = 0
        PictureBox1.Invalidate()
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        State = 2
        RightS = 3
        Full = 0
        PictureBox1.Invalidate()
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click
        State = 2
        LeftS = 3
        Full = 0
        PictureBox1.Invalidate()
    End Sub
    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem8.Click
        State = 1
        Full = 3
        LeftS = 0
        RightS = 0
        PictureBox1.Invalidate()
    End Sub




    Public Sub SaveFile()

        If FileName = "" Or SvAs Then
            Dim saveFileDialog1 As New SaveFileDialog()
            SvAs = False

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            saveFileDialog1.FilterIndex = 2
            saveFileDialog1.RestoreDirectory = True

            If saveFileDialog1.ShowDialog() = DialogResult.OK Then
                FileName = saveFileDialog1.FileName

            Else
                Exit Sub

            End If

        End If







        Dim ourdeviceVect() As DataStr = Donee.ToArray
        Dim Lenthm As Integer = ourdeviceVect.Count - 1
        Dim SNotes As String = Notes
        Dim fileNumber As Integer = FreeFile()

        FileOpen(fileNumber, FileName, OpenMode.Binary)

        FilePut(fileNumber, Lenthm)
        FilePutObject(fileNumber, SNotes)
        FilePut(fileNumber, ourdeviceVect)

        FileClose(fileNumber)


    End Sub





    Public Sub LoadFile()
        Dim fd As OpenFileDialog = New OpenFileDialog()


        fd.Title = "Open File Dialog"

        fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            FileName = fd.FileName
            Dim ourdeviceVect() As DataStr
            Dim SNotes As String
            Dim fileNumber As Integer = FreeFile()
            Dim Lenthm As Integer

            FileOpen(fileNumber, FileName, OpenMode.Binary)

            FileGet(fileNumber, Lenthm)
            FileGetObject(fileNumber, SNotes)
            ReDim ourdeviceVect(Lenthm)
            FileGet(fileNumber, ourdeviceVect)

            FileClose(fileNumber)
            Notes = SNotes
            Donee = ourdeviceVect.ToList
            Write()

        End If


    End Sub




    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        SaveFile()
    End Sub
    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        SvAs = True
        SaveFile()
    End Sub
    Private Sub OpenTestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenTestToolStripMenuItem.Click
        LoadFile()
    End Sub

    Private Sub RichTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles RichTextBox1.KeyDown
        Notes = RichTextBox1.Text
    End Sub


End Class

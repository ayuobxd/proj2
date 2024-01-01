Imports System.IO


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


    Dim Close = False
    Public RemCase As Integer = 99999


    'Starting Pos
    Dim x01 As Integer = 20
    Dim y01 As Integer = 20
    Dim x02 As Integer = 20
    Dim y02 As Integer = 20

    'lines drawing
    Dim x1 As Integer
    Dim x2 As Integer
    Dim y1 As Integer
    Dim y2 As Integer


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


    'Data
    Public Donee As New List(Of DataStr)
    Public Devices As New List(Of DeviseStr)
    Public Layer As New List(Of LayerDta)

    Public LayersNum As Integer
    Dim LayersChk As New List(Of Integer)
    Dim DevP As Integer = 0


    'Graph Drawing
    Dim State As Integer
    Dim LeftS As Integer
    Dim RightS As Integer
    Dim Full As Integer
    Dim TextW As String



    'Test Info
    Public TestName As String
    Public TestDate As DateTime
    'Save File
    Dim FileName As String = ""
    Dim SvAs As Boolean = False
    Public Notes As String = " "
    Dim MaxQd As Double
    Dim MaxRd As Double
    Dim MaxQdDepth As Double
    Dim MaxDepth As Double

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
        Frm.testd = TestDate
        Frm.testn = TestName
        Frm.ShowDialog()
        TestName = Frm.testn
        TestDate = Frm.testd
        Frm.Dispose()

        Write()



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

        Write()

        CloseAll()
        Dim Frm2 As New InputData
        Frm2.ourData = Donee
        Frm2.OurDevices = Devices
        Frm2.Dev = DevP
        Frm2.layersInput = Layer
        Frm2.ShowDialog()
        Donee = Frm2.ourData
        Devices = Frm2.OurDevices
        DevP = Frm2.Dev
        Layer = Frm2.layersInput
        Frm2.Dispose()

        Write()

        PictureBox1.Invalidate()
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

        Write()

        PictureBox1.Invalidate()
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


        Dim mygraphics As Graphics = e.Graphics

        Dim MyPenB As Pen
        Dim MyPenR As Pen

        MyPenB = New Pen(Brushes.Black, 1)
        MyPenR = New Pen(Brushes.Red, 3)


        If State = 1 Then
            If Full = 1 Then
                list1 = X
                TextW = "rd (MPa)"
                MyPenR.Color = Color.FromArgb(255, 0, 0)
            ElseIf Full = 2 Then
                list1 = Y
                TextW = "qd (MPa)"
                MyPenR.Color = Color.FromArgb(0, 255, 0)
            ElseIf Full = 3 Then
                list1 = Z
                TextW = "Number Of Blows"
                MyPenR.Color = Color.FromArgb(0, 0, 255)
            End If
            Try




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
                MyPenR.Color = Color.FromArgb(255, 0, 0)
            ElseIf LeftS = 2 Then
                list1 = Y
                TextW = "qd (MPa)"
                MyPenR.Color = Color.FromArgb(0, 255, 0)
            ElseIf LeftS = 3 Then
                list1 = Z
                TextW = "Number Of Blows"
                MyPenR.Color = Color.FromArgb(0, 0, 255)
            End If
            If LeftS = 1 Or LeftS = 2 Or LeftS = 3 Then
                Try



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
                MyPenR.Color = Color.FromArgb(255, 0, 0)
            ElseIf RightS = 2 Then
                list2 = Y
                TextW = "qd (MPa)"
                MyPenR.Color = Color.FromArgb(0, 255, 0)
            ElseIf RightS = 3 Then
                list2 = Z
                TextW = "Number Of Blows"
                MyPenR.Color = Color.FromArgb(0, 0, 255)
            End If

            If RightS = 1 Or RightS = 2 Or RightS = 3 Then
                Try



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

        MaxQd = 0
        MaxRd = 0
        MaxQdDepth = 0
        MaxDepth = 0

        Dim PosMax As Integer
        For i = 0 To Donee.Count - 1
            If MaxRd < Donee.Item(i).rd Then
                MaxRd = Donee.Item(i).rd
            End If
            If MaxQd < Donee.Item(i).qd Then
                MaxQd = Donee.Item(i).qd
                PosMax = i
                MaxQdDepth = Donee.Item(i).depth
            End If
            If MaxDepth < Donee.Item(i).depth Then
                MaxDepth = Donee.Item(i).depth
            End If

        Next i

        Label2.Text = TestName
        Label3.Text = TestDate
        Label4.Text = MaxRd.ToString("N3") & " MPa"
        Label5.Text = MaxQd.ToString("N3") & " MPa"
        Label6.Text = MaxQdDepth & " m"
        Label7.Text = MaxDepth & " m"
        Label9.Text = Devices.Item(DevP).standard

    End Sub

    Sub ClearAll()

        Donee.Clear()

        Devices.Clear()

        Layer.Clear()

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

        LayersNum = 0
        LayersChk.Clear()
        DevP = 0



        State = 99999
        LeftS = 99999
        RightS = 99999
        Full = 99999
        TextW = 99999

        'Test Info
        TestName = ""
        TestDate = Date.Now
        'Save File
        FileName = ""

        Notes = ""
        MaxQd = 0
        MaxRd = 0
        MaxQdDepth = 0
        MaxDepth = 0

        Label2.Text = "."
        Label3.Text = "."
        Label4.Text = "."
        Label5.Text = "."
        Label6.Text = "."
        Label7.Text = "."
        Label9.Text = "."
        RichTextBox1.Text = Notes
        PictureBox1.Invalidate()

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

        Dim ourDeviceVect() As DeviseStr = Devices.ToArray
        Dim ourDoneeVect() As DataStr = Donee.ToArray
        Dim LenthDonne As Integer = ourDoneeVect.Count - 1
        Dim LenthDevice As Integer = ourDeviceVect.Count - 1


        Dim SDev As Integer = DevP
        Dim SNotes As String = Notes
        Dim SDate As String = CStr(TestDate)
        Dim SName As String = TestName
        Dim fileNumber As Integer = FreeFile()

        FileOpen(fileNumber, FileName, OpenMode.Binary)

        FilePut(fileNumber, LenthDonne)
        FilePut(fileNumber, ourDoneeVect)

        FilePut(fileNumber, LenthDevice)
        FilePut(fileNumber, ourDeviceVect)

        FilePut(fileNumber, SDev)

        FilePutObject(fileNumber, SNotes)
        FilePutObject(fileNumber, SDate)
        FilePutObject(fileNumber, SName)



        FileClose(fileNumber)

        If RemCase = 0 Then
            Me.Dispose()

        End If

    End Sub


    Public Sub LoadFile()
        Dim fd As OpenFileDialog = New OpenFileDialog()


        fd.Title = "Open File Dialog"

        fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            FileName = fd.FileName
            Dim ourDeviceVect() As DeviseStr
            Dim ourDonneVect() As DataStr
            Dim SNotes As String
            Dim SDate As String
            Dim SName As String
            Dim SDev As Integer


            Dim fileNumber As Integer = FreeFile()

            Dim LenthDonne As Integer
            Dim LenthDevice As Integer

            FileOpen(fileNumber, FileName, OpenMode.Binary)

            FileGet(fileNumber, LenthDonne)
            ReDim ourDonneVect(LenthDonne)
            FileGet(fileNumber, ourDonneVect)

            FileGet(fileNumber, LenthDevice)
            ReDim ourDeviceVect(LenthDevice)
            FileGet(fileNumber, ourDeviceVect)

            FileGet(fileNumber, SDev)

            FileGetObject(fileNumber, SNotes)
            FileGetObject(fileNumber, SDate)
            FileGetObject(fileNumber, SName)

            FileClose(fileNumber)

            Notes = SNotes
            TestDate = CDate(SDate)
            TestName = SName
            DevP = SDev


            Donee = ourDonneVect.ToList
            Devices = ourDeviceVect.ToList

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

    Private Sub NewTestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewTestToolStripMenuItem.Click


        ClearAll()
    End Sub

    Private Sub PDFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PDFToolStripMenuItem.Click
        DrawBitmap()
        PDF.Visible = True
    End Sub

    Sub DrawBitmap()
        For o = 1 To 2
            For p = 1 To 3
                Full = p
                State = o
                For k = 1 To 3


                    LeftS = p
                    RightS = k
                    Dim PhotoNum As Integer
                    PhotoNum += 1
                    Using bmp As Bitmap = New Bitmap(560, 560)

                        Using g As Graphics = Graphics.FromImage(bmp)


                            g.Clear(Color.White)


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

                            Dim MyPenB As Pen
                            Dim MyPenR As Pen

                            MyPenB = New Pen(Brushes.Black, 1)
                            MyPenR = New Pen(Brushes.Red, 3)

                            Dim fnt As New Font("Cambria", 10, FontStyle.Regular, GraphicsUnit.Point)

                            If State = 1 Then
                                If Full = 1 Then
                                    list1 = X
                                    TextW = "rd (MPa)"
                                    MyPenR.Color = Color.FromArgb(255, 0, 0)
                                ElseIf Full = 2 Then
                                    list1 = Y
                                    TextW = "qd (MPa)"
                                    MyPenR.Color = Color.FromArgb(0, 255, 0)
                                ElseIf Full = 3 Then
                                    list1 = Z
                                    TextW = "Number Of Blows"
                                    MyPenR.Color = Color.FromArgb(0, 0, 255)
                                End If
                                Try

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

                                        g.DrawLine(MyPenB, 0 + x01, y1 + y01, 500 + x01, y2 + y01)
                                        g.DrawString(ex, fnt, Brushes.Black, 515 + x01, y2 + y01)
                                        y1 += 50
                                        y2 += 50
                                        ex = ex + m

                                        g.DrawLine(MyPenB, x1 + x01, 0 + y01, x2 + x01, 500 + y01)
                                        g.DrawString(ey, fnt, Brushes.Black, x2 + x01, 515 + y01)
                                        x1 += 50
                                        x2 += 50
                                        ey += n

                                    Next i

                                    For i = 1 To Donee.Count - 2

                                        P1.X = ((list1(i - 1) * 50) / n)
                                        P1.Y = ((D(i - 1) * 50) / m)

                                        P2.X = ((list1(i) * 50) / n)
                                        P2.Y = ((D(i) * 50) / m)

                                        g.DrawLine(MyPenR, P1.X + x02, P1.Y + y02, P2.X + x02, P2.Y + y02)

                                    Next i

                                    g.DrawString(TextW, fnt, Brushes.Black, 250 - 2 * TextW.Length, 2)
                                    g.RotateTransform(90)
                                    g.DrawString("Depth (m)", fnt, Brushes.Black, 250, -20)
                                    g.ResetTransform()


                                Catch ex As Exception
                                End Try

                                '----------------------------------------------------------------------------------------------------------
                            ElseIf State = 2 Then
                                If LeftS = 1 Then
                                    list1 = X
                                    TextW = "rd (MPa)"
                                    MyPenR.Color = Color.FromArgb(255, 0, 0)
                                ElseIf LeftS = 2 Then
                                    list1 = Y
                                    TextW = "qd (MPa)"
                                    MyPenR.Color = Color.FromArgb(0, 255, 0)
                                ElseIf LeftS = 3 Then
                                    list1 = Z
                                    TextW = "Number Of Blows"
                                    MyPenR.Color = Color.FromArgb(0, 0, 255)
                                End If
                                If LeftS = 1 Or LeftS = 2 Or LeftS = 3 Then
                                    Try

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

                                            g.DrawLine(MyPenB, 0 + x01, y1 + y01, 200 + x01, y2 + y01)
                                            g.DrawString(ex, fnt, Brushes.Black, 215 + x01, y2 + y01)
                                            y1 += 50
                                            y2 += 50
                                            ex = ex + m

                                            g.DrawLine(MyPenB, x1 + x01, 0 + y01, x2 + x01, 500 + y01)
                                            g.DrawString(ey, fnt, Brushes.Black, x2 + x01, 515 + y01)
                                            x1 += 20
                                            x2 += 20
                                            ey += n

                                        Next i

                                        For i = 1 To Donee.Count - 2

                                            P1.X = ((list1(i - 1) * 20) / n)
                                            P1.Y = ((D(i - 1) * 50) / m)

                                            P2.X = ((list1(i) * 20) / n)
                                            P2.Y = ((D(i) * 50) / m)

                                            g.DrawLine(MyPenR, P1.X + x02, P1.Y + y02, P2.X + x02, P2.Y + y02)

                                        Next i
                                        g.DrawString(TextW, fnt, Brushes.Black, 100 - 2 * TextW.Length, 2)
                                        g.RotateTransform(90)
                                        g.DrawString("Depth (m)", fnt, Brushes.Black, 250, -20)
                                        g.ResetTransform()

                                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                                    Catch ex As Exception
                                    End Try
                                End If

                                If RightS = 1 Then
                                    list2 = X
                                    TextW = "rd (MPa)"
                                    MyPenR.Color = Color.FromArgb(255, 0, 0)
                                ElseIf RightS = 2 Then
                                    list2 = Y
                                    TextW = "qd (MPa)"
                                    MyPenR.Color = Color.FromArgb(0, 255, 0)
                                ElseIf RightS = 3 Then
                                    list2 = Z
                                    TextW = "Number Of Blows"
                                    MyPenR.Color = Color.FromArgb(0, 0, 255)
                                End If

                                If RightS = 1 Or RightS = 2 Or RightS = 3 Then
                                    Try
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

                                            g.DrawLine(MyPenB, 300 + x01, y1 + y01, 500 + x01, y2 + y01)
                                            g.DrawString(ex, fnt, Brushes.Black, 215 + x01 + 300, y2 + y01)
                                            y1 += 50
                                            y2 += 50
                                            ex += m

                                            g.DrawLine(MyPenB, x1 + x01 + 300, 0 + y01, x2 + x01 + 300, 500 + y01)
                                            g.DrawString(ey, fnt, Brushes.Black, x2 + x01 + 300, 515 + y01)
                                            x1 += 20
                                            x2 += 20
                                            ey += n

                                        Next i

                                        For i = 1 To Donee.Count - 2

                                            P1.X = ((list2(i - 1) * 20) / n)
                                            P1.Y = ((D(i - 1) * 50) / m)

                                            P2.X = ((list2(i) * 20) / n)
                                            P2.Y = ((D(i) * 50) / m)

                                            g.DrawLine(MyPenR, P1.X + x02 + 300, P1.Y + y02, P2.X + x02 + 300, P2.Y + y02)

                                        Next i
                                        g.DrawString(TextW, fnt, Brushes.Black, 400 - 2 * TextW.Length, 2)
                                        g.RotateTransform(90)
                                        g.DrawString("Depth (m)", fnt, Brushes.Black, 250, -320)
                                        g.ResetTransform()


                                    Catch ex As Exception
                                    End Try
                                End If
                            End If
                        End Using
                        Dim dirctory As String = CStr(PhotoNum) & ".png"
                        bmp.Save(dirctory, Imaging.ImageFormat.Png)
                    End Using
                Next k
            Next p
        Next o

        Using bmp As Bitmap = New Bitmap(560, 260)

            Using gg As Graphics = Graphics.FromImage(bmp)


                gg.Clear(Color.White)
                Dim fnt As New Font("Cambria", 10, FontStyle.Italic, GraphicsUnit.Point)

                gg.DrawString("Text Name: " & TestName, fnt, Brushes.Black, 20, 0)

                gg.DrawString("Text Date: " & TestDate, fnt, Brushes.Black, 20, 20)

                gg.DrawString("Max rd: " & MaxRd.ToString("N3") & "MPa", fnt, Brushes.Black, 20, 40)

                gg.DrawString("Max qd: " & MaxQd.ToString("N3") & "MPa", fnt, Brushes.Black, 20, 60)

                gg.DrawString("Max qd respective depth: " & MaxQdDepth & "m", fnt, Brushes.Black, 20, 80)

                gg.DrawString("Max depth: " & MaxDepth & "m", fnt, Brushes.Black, 20, 100)

                gg.DrawString("Test type: " & Devices.Item(DevP).standard, fnt, Brushes.Black, 20, 120)


                If Notes.Length > 1 Then
                    Dim lengthN As Integer = Math.Ceiling(Notes.Length / 50)

                    Dim start As Integer = 0
                    gg.DrawString("Notes: ", fnt, Brushes.Black, 20, 140)
                    For i = 1 To lengthN
                        Dim l As Integer
                        If Notes.Length >= i * 50 Then
                            l = 50

                        ElseIf Notes.Length < i * 50 Then
                            l = Notes.Length - (i - 1) * 50
                        End If
                        Dim substring As String = Notes.Substring(start, l)
                        start += 50
                        gg.DrawString(substring & "-", fnt, Brushes.Black, 55, 120 + (i * 20))
                    Next i
                End If
            End Using
            Dim dirctory As String = "0.png"
            bmp.Save(dirctory, Imaging.ImageFormat.Png)
        End Using
    End Sub



    Private Sub PNGToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PNGToolStripMenuItem.Click
        DrawBitmap()

        Dim filedir As String
        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.RestoreDirectory = True

        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            filedir = saveFileDialog1.FileName
            If Not Directory.Exists(filedir) Then

                Directory.CreateDirectory(filedir)

                My.Computer.FileSystem.CopyFile("1.png", filedir & "\" & "rd.png")
                My.Computer.FileSystem.CopyFile("4.png", filedir & "\" & "qd.png")
                My.Computer.FileSystem.CopyFile("7.png", filedir & "\" & "nb.png")
                My.Computer.FileSystem.CopyFile("11.png", filedir & "\" & "rd-qd.png")
                My.Computer.FileSystem.CopyFile("12.png", filedir & "\" & "rd-nb.png")
                My.Computer.FileSystem.CopyFile("15.png", filedir & "\" & "qd-nb.png")
                MsgBox("Exported Successfully.", MsgBoxStyle.Information)
            End If
        End If

    End Sub
    Public Function ExcelColName(ByVal Col As Integer) As String
        If Col < 0 And Col > 256 Then
            MsgBox("Invalid Argument", MsgBoxStyle.Critical)
            Return Nothing
            Exit Function
        End If
        Dim i As Integer
        Dim r As Integer
        Dim S As String
        If Col <= 26 Then
            S = Chr(Col + 64)
        Else
            r = Col Mod 26
            i = System.Math.Floor(Col / 26)
            If r = 0 Then
                r = 26
                i = i - 1
            End If
            S = Chr(i + 64) & Chr(r + 64)
        End If
        ExcelColName = S
    End Function

    Sub ExportExcel()

        Dim filedir As String
        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.RestoreDirectory = True
        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            filedir = saveFileDialog1.FileName

            Dim sheetIndex As Integer
            Dim Ex As Object
            Dim Wb As Object
            Dim Ws As Object
            Ex = CreateObject("Excel.Application")
            Wb = Ex.workbooks.add
            Dim col, row As Integer
            Dim rawData(Donee.Count, 5) As Object
            rawData(0, 0) = "Depth (m)"
            rawData(0, 1) = "Notches (cm)"
            rawData(0, 2) = "Number Of Blows"
            rawData(0, 3) = "rd (MPa)"
            rawData(0, 4) = "qd (MPa)"
            For i = 0 To Donee.Count - 2
                rawData(i + 1, 0) = Donee.Item(i).depth
                rawData(i + 1, 1) = Donee.Item(i).notch
                rawData(i + 1, 2) = Donee.Item(i).Nb
                rawData(i + 1, 3) = Donee.Item(i).rd
                rawData(i + 1, 4) = Donee.Item(i).qd
            Next
            Dim finalColLetter As String = String.Empty
            finalColLetter = ExcelColName(5)
            sheetIndex += 1
            Ws = Wb.Worksheets(sheetIndex)
            Dim excelRange As String = String.Format("A1:{0}{1}", finalColLetter, Donee.Count + 1)
            Ws.Range(excelRange, Type.Missing).Value2 = rawData
            Ws = Nothing
            Wb.SaveAs(filedir & ".xlsx")
            Wb.Close(True)
            Wb = Nothing

            Ex.Quit()
            Ex = Nothing

            GC.Collect()
            MsgBox("Exported Successfully.", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub EXCELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCELToolStripMenuItem.Click
        ExportExcel()
    End Sub



    Private Sub DPT_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Select Case e.CloseReason
            Case CloseReason.ApplicationExitCall
                e.Cancel = False

            Case CloseReason.FormOwnerClosing
                e.Cancel = False

            Case CloseReason.MdiFormClosing
                e.Cancel = False

            Case CloseReason.None
                e.Cancel = False

            Case CloseReason.TaskManagerClosing
                e.Cancel = False

            Case CloseReason.UserClosing
                Reminder.Visible = True
                If Close Then
                    e.Cancel = False
                End If

                e.Cancel = True
                Me.Visible = True


            Case CloseReason.WindowsShutDown
                e.Cancel = False

        End Select

    End Sub
End Class

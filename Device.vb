Imports System.Text.RegularExpressions

Public Class Device


    Public ourDevice As List(Of Menu.DeviseStr)
    Public SelDev As Integer

    Public Function IsNotNull() As Boolean
        If TextBox1.TextLength < 1 Or
           TextBox2.TextLength < 1 Or
           TextBox3.TextLength < 1 Or
           TextBox4.TextLength < 1 Or
           TextBox5.TextLength < 1 Or
           TextBox6.TextLength < 1 Or
           TextBox7.TextLength < 1 Or
           TextBox8.TextLength < 1 Or
           TextBox9.TextLength < 1 Then
            Return False
        End If
        Return True

    End Function

    Public Function IsNumeric(ValString As String) As Boolean
        ValString = CStr(ValString.Replace(" ", ""))
        For i = 0 To ValString.Length - 1
            Dim Car As String = ValString.Chars(i)
            If Not (Car = "0" Or Car = "1" Or Car = "2" Or Car = "3" Or Car = "4" Or Car = "5" Or Car = "6" Or Car = "7" Or Car = "8" Or Car = "9" Or Car = ".") Then

                Return False
            End If
        Next
        Return True
    End Function

    Public Sub SaveDevices()
        Dim P As Menu.DeviseStr
        If Not IsNumeric(TextBox8.Text) Or
            Not IsNumeric(TextBox7.Text) Or
            Not IsNumeric(TextBox6.Text) Or
            Not IsNumeric(TextBox5.Text) Or
            Not IsNumeric(TextBox4.Text) Or
            Not IsNumeric(TextBox3.Text) Or
            Not IsNumeric(TextBox2.Text) Or
             Not IsNotNull() Then

            MsgBox("The inputed text is not valid")
            Exit Sub
        End If
        P.Name = TextBox1.Text
        P.Hammer = TextBox2.Text
        P.AnvilGuide = TextBox3.Text
        P.rodes = TextBox4.Text
        P.FallingH = TextBox5.Text
        P.AOfCone = TextBox6.Text
        P.LOfRodes = TextBox7.Text
        P.Notches = TextBox8.Text
        P.standard = TextBox9.Text
        ourDevice.Add(P)
    End Sub

    Public Sub ModifyDevices()
        Dim Pos As Integer
        If Not isNumeric(TextBox8.Text) Or
            Not isNumeric(TextBox7.Text) Or
            Not isNumeric(TextBox6.Text) Or
            Not isNumeric(TextBox5.Text) Or
            Not isNumeric(TextBox4.Text) Or
            Not isNumeric(TextBox3.Text) Or
            Not isNumeric(TextBox2.Text) Then
            MsgBox("The inputed text is not a number")
            Exit Sub
        End If
        For i = 0 To ourDevice.Count - 1
            If (ourDevice.Item(i).Name = TextBox1.Text) Then
                Pos = i
            End If
        Next i
        ourDevice.RemoveAt(Pos)
        SaveDevices()
    End Sub

    Public Sub LoadDevices()


        ComboBox1.Items.Clear()
        'default Device


        'default Device
        For i = 0 To ourDevice.Count - 1
            ComboBox1.Items.Add(ourDevice.Item(i).Name)
        Next i
        ComboBox1.Text = "Select from..."
    End Sub

    Public Sub Remove()
        If SelDev >= 0 And ourDevice.Count > 0 Then
            ourDevice.RemoveAt(SelDev)
            LoadDevices()
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox7.Text = ""
            TextBox8.Text = ""
            TextBox9.Text = ""
        End If
    End Sub

    Private Sub Device_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call CenterToScreen()
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.TopMost = True
        Me.MinimizeBox = False
        LoadDevices()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Found As Boolean = False

        For i = 0 To ourDevice.Count - 1
            If (ourDevice.Item(i).Name = TextBox1.Text) Then
                Found = True
            End If
        Next i

        If Found Then
            ModifyDevices()
        Else
            SaveDevices()
        End If

        LoadDevices()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        SelDev = ComboBox1.SelectedIndex
        TextBox1.Text = ourDevice.Item(SelDev).Name
        TextBox2.Text = ourDevice.Item(SelDev).Hammer
        TextBox3.Text = ourDevice.Item(SelDev).AnvilGuide
        TextBox4.Text = ourDevice.Item(SelDev).rodes
        TextBox5.Text = ourDevice.Item(SelDev).FallingH
        TextBox6.Text = ourDevice.Item(SelDev).AOfCone
        TextBox7.Text = ourDevice.Item(SelDev).LOfRodes
        TextBox8.Text = ourDevice.Item(SelDev).Notches
        TextBox9.Text = ourDevice.Item(SelDev).standard
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Remove()
    End Sub

End Class
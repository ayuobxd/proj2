Imports System.Text.RegularExpressions

Public Class Device


    Public ourDevice As List(Of Menu.DeviseStr)
    Public isv As Boolean



    Public Function isNumeric(ValString As String) As Boolean
        ValString = ValString.Replace(" ", "")
        For i = 0 To ValString.Length
            Dim Car As String = ValString.Chars(i)
            If Not (Car = "0" Or Car = "1" Or Car = "2" Or Car = "3" Or Car = "4" Or Car = "5" Or Car = "6" Or Car = "7" Or Car = "8" Or Car = "9" Or Car = ".") Then

                Return False
            End If
        Next
        Return True
    End Function


    Public Sub SaveDevices()
        Dim P As Menu.DeviseStr
        If (Not isNumeric(TextBox8.Text)) Then
            '(Not isNumeric(TextBox7.Text)) AndAlso
            '(Not isNumeric(TextBox6.Text)) AndAlso
            '(Not isNumeric(TextBox5.Text)) AndAlso
            '(Not isNumeric(TextBox4.Text)) AndAlso
            '(Not isNumeric(TextBox3.Text)) AndAlso
            '(Not isNumeric(TextBox2.Text)) Then
            MsgBox("The inputed text is not a number")
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

        For i = 0 To ourDevice.Count - 2
            If TextBox1.Text = ourDevice.Item(i).Name Then
                Pos = i
            End If
        Next i
        ourDevice.RemoveAt(Pos)
        SaveDevices()
    End Sub

    Public Sub LoadDevices()
        ComboBox1.Items.Clear()


        For i = 0 To ourDevice.Count - 1

            ComboBox1.Items.Add(ourDevice.Item(i).Name)

        Next i
        ComboBox1.Text = "Select from..."


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


        Next

        If Found Then
            ModifyDevices()
        Else
            SaveDevices()
        End If

        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        LoadDevices()





    End Sub





End Class
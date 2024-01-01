Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports Microsoft.VisualBasic
Imports iText.Kernel.Pdf
Imports iText.Layout
Imports iText.Layout.Element
Imports iText.IO.Image
Imports iText.Kernel.Geom
Imports iText.Kernel.Utils

Public Class PDF

    Dim listP As New List(Of String)






    Private Sub PDF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckedListBox1.Items.Add("Dynamic Point Resistance")
        CheckedListBox1.Items.Add("Unit Point Resistance")
        CheckedListBox1.Items.Add("Number Of Blows")
        CheckedListBox1.Items.Add("Data Table")




    End Sub

    Private Sub Add_Click(sender As Object, e As EventArgs) Handles Add.Click
        If CheckedListBox1.GetItemChecked(0) Or CheckedListBox1.GetItemChecked(1) Or CheckedListBox1.GetItemChecked(2) Or CheckedListBox1.GetItemChecked(3) Then
            Dim check As String = ""
            For i = 0 To CheckedListBox1.Items.Count - 1
                If CheckedListBox1.GetItemChecked(i) Then
                    check = check & i
                End If

            Next i

            listP.Add(check)
            load()

        End If

    End Sub




    Sub load()
        Dim A, B As String

        ListBox1.Items.Clear()

        For i = 0 To listP.Count - 1
            A = "Paper N: " & i + 1
            If listP(i) = "0" Then
                B = " rd"
            ElseIf listP(i) = "1" Then
                B = " qd"
            ElseIf listP(i) = "2" Then
                B = " Number Of Blows"
            ElseIf listP(i) = "3" Then
                B = " Data Table"
            ElseIf listP(i) = "01" Then
                B = " rd,qd"
            ElseIf listP(i) = "02" Then
                B = " rd,Number Of Blows"
            ElseIf listP(i) = "12" Then
                B = " qd,Number Of Blows"
            End If

            ListBox1.Items.Add(A & B)

        Next
    End Sub

    Sub restain()
        For i = 0 To CheckedListBox1.Items.Count - 1
            Dim Check As Integer = 2
            If CheckedListBox1.GetItemChecked(i) Then

                For j = 0 To CheckedListBox1.Items.Count - 1
                    If CheckedListBox1.GetItemChecked(j) Then

                        If Check > 0 Then
                            Check -= 1
                        ElseIf Check = 0 Then

                            CheckedListBox1.SetItemChecked(CheckedListBox1.SelectedIndex, False)
                        End If

                    End If



                Next j

            End If

        Next i

        If CheckedListBox1.GetItemChecked(0) Or CheckedListBox1.GetItemChecked(1) Or CheckedListBox1.GetItemChecked(2) Then
            CheckedListBox1.SetItemChecked(3, False)
        ElseIf CheckedListBox1.GetItemChecked(3) Then
            CheckedListBox1.SetItemChecked(0, False)
            CheckedListBox1.SetItemChecked(1, False)
            CheckedListBox1.SetItemChecked(2, False)


        End If
    End Sub

    Sub CreatePdf()
        Dim filedir As String

        Dim saveFileDialog1 As New SaveFileDialog()


        saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"

        saveFileDialog1.FilterIndex = 2
        saveFileDialog1.RestoreDirectory = True

        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            filedir = saveFileDialog1.FileName
            Dim pdfdoc As New Document()
            Dim pdfW As PdfWriter = PdfWriter.GetInstance(pdfdoc, New FileStream(filedir & ".pdf", FileMode.Create))
            pdfdoc.Open()


            For i = 0 To listP.Count - 1

                If listP(i) = "0" Then
                    pdfdoc.NewPage()
                    Dim img As Image = Image.GetInstance("1.png")
                    img.ScaleAbsolute(500, 500)
                    pdfdoc.Add(img)
                    Dim img2 As Image = Image.GetInstance("0.png")
                    img2.ScaleAbsolute(500, 260)
                    pdfdoc.Add(img2)

                ElseIf listP(i) = "1" Then
                    pdfdoc.NewPage()
                    Dim img As Image = Image.GetInstance("4.png")
                    img.ScaleAbsolute(500, 500)
                    pdfdoc.Add(img)
                    Dim img2 As Image = Image.GetInstance("0.png")
                    img2.ScaleAbsolute(500, 260)
                    pdfdoc.Add(img2)

                ElseIf listP(i) = "2" Then
                    pdfdoc.NewPage()
                    Dim img As Image = Image.GetInstance("7.png")
                    img.ScaleAbsolute(500, 500)
                    pdfdoc.Add(img)
                    Dim img2 As Image = Image.GetInstance("0.png")
                    img2.ScaleAbsolute(500, 260)
                    pdfdoc.Add(img2)

                ElseIf listP(i) = "3" Then
                    pdfdoc.NewPage()
                    Dim table As New PdfPTable(5)
                    Dim cell As New PdfPCell
                    cell.Colspan = 5
                    cell.HorizontalAlignment = 1
                    table.AddCell(cell)
                    table.AddCell("Depth (m)")
                    table.AddCell("Notches (cm)")
                    table.AddCell("Number Of Blows")
                    table.AddCell("rd (MPa)")
                    table.AddCell("qd (MPa)")

                    For j = 0 To DPT.Donee.Count - 2
                        table.AddCell(DPT.Donee.Item(j).depth)
                        table.AddCell(DPT.Donee.Item(j).notch)
                        table.AddCell(DPT.Donee.Item(j).Nb)
                        table.AddCell(DPT.Donee.Item(j).rd.ToString("N3"))
                        table.AddCell(DPT.Donee.Item(j).qd.ToString("N3"))
                    Next j
                    pdfdoc.Add(table)
                ElseIf listP(i) = "01" Then
                    pdfdoc.NewPage()
                    Dim img As Image = Image.GetInstance("11.png")
                    img.ScaleAbsolute(500, 500)
                    pdfdoc.Add(img)
                    Dim img2 As Image = Image.GetInstance("0.png")
                    img2.ScaleAbsolute(500, 260)
                    pdfdoc.Add(img2)

                ElseIf listP(i) = "02" Then
                    pdfdoc.NewPage()
                    Dim img As Image = Image.GetInstance("12.png")
                    img.ScaleAbsolute(500, 500)
                    pdfdoc.Add(img)
                    Dim img2 As Image = Image.GetInstance("0.png")
                    img2.ScaleAbsolute(500, 260)
                    pdfdoc.Add(img2)

                ElseIf listP(i) = "12" Then
                    pdfdoc.NewPage()
                    Dim img As Image = Image.GetInstance("15.png")
                    img.ScaleAbsolute(500, 500)
                    pdfdoc.Add(img)
                    Dim img2 As Image = Image.GetInstance("0.png")
                    img2.ScaleAbsolute(500, 260)
                    pdfdoc.Add(img2)

                End If
            Next i

            pdfdoc.Close()
            MsgBox("Exported Successfully.", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub CheckedListBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles CheckedListBox1.MouseUp
        restain()
    End Sub

    Private Sub CheckedListBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles CheckedListBox1.KeyUp
        restain()
    End Sub

    Private Sub Export_Click(sender As Object, e As EventArgs) Handles Export.Click
        If listP.Count > 0 Then
            CreatePdf()

        Else
            MsgBox("Add at least one paper.")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click


        If ListBox1.SelectedIndex > -1 And ListBox1.SelectedIndex < listP.Count + 1 Then
            Console.WriteLine(ListBox1.SelectedIndex)
            listP.RemoveAt(ListBox1.SelectedIndex)
            load()
        End If


    End Sub
End Class
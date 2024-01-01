<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PDF
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PDF))
        Me.Export = New System.Windows.Forms.Button()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.Add = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'Export
        '
        Me.Export.Location = New System.Drawing.Point(52, 144)
        Me.Export.Name = "Export"
        Me.Export.Size = New System.Drawing.Size(108, 32)
        Me.Export.TabIndex = 0
        Me.Export.Text = "Export PDF"
        Me.Export.UseVisualStyleBackColor = True
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Location = New System.Drawing.Point(12, 17)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(204, 89)
        Me.CheckedListBox1.TabIndex = 1
        '
        'Add
        '
        Me.Add.Location = New System.Drawing.Point(52, 112)
        Me.Add.Name = "Add"
        Me.Add.Size = New System.Drawing.Size(108, 32)
        Me.Add.TabIndex = 3
        Me.Add.Text = "Add Page"
        Me.Add.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(52, 176)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(108, 32)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Remove Page"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Location = New System.Drawing.Point(222, 17)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(204, 180)
        Me.ListBox1.TabIndex = 6
        '
        'PDF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(445, 213)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Add)
        Me.Controls.Add(Me.CheckedListBox1)
        Me.Controls.Add(Me.Export)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "PDF"
        Me.Text = "PDF"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Export As Button
    Friend WithEvents CheckedListBox1 As CheckedListBox
    Friend WithEvents Add As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents ListBox1 As ListBox
End Class

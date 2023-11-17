<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InputData
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InputData))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Dep = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Notches = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Blows = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Dep, Me.Notches, Me.Blows, Me.Rd, Me.qd})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(804, 482)
        Me.DataGridView1.TabIndex = 0
        '
        'Dep
        '
        Me.Dep.HeaderText = "Depthe (m)"
        Me.Dep.MinimumWidth = 6
        Me.Dep.Name = "Dep"
        '
        'Notches
        '
        Me.Notches.HeaderText = "Notches (cm)"
        Me.Notches.MinimumWidth = 6
        Me.Notches.Name = "Notches"
        '
        'Blows
        '
        Me.Blows.HeaderText = "N of Blows "
        Me.Blows.MinimumWidth = 6
        Me.Blows.Name = "Blows"
        '
        'Rd
        '
        Me.Rd.HeaderText = "rd (bar)"
        Me.Rd.MinimumWidth = 6
        Me.Rd.Name = "Rd"
        '
        'qd
        '
        Me.qd.HeaderText = "qd (bar)"
        Me.qd.MinimumWidth = 6
        Me.qd.Name = "qd"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(722, 518)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(94, 28)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(609, 518)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(94, 28)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'InputData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 567)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "InputData"
        Me.Text = "InputData"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Dep As DataGridViewTextBoxColumn
    Friend WithEvents Notches As DataGridViewTextBoxColumn
    Friend WithEvents Blows As DataGridViewTextBoxColumn
    Friend WithEvents Rd As DataGridViewTextBoxColumn
    Friend WithEvents qd As DataGridViewTextBoxColumn
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class

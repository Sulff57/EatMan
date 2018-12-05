<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.NouveauJeuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ScoreTxt = New System.Windows.Forms.Label
        Me.ScoreNb = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NouveauJeuToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(896, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'NouveauJeuToolStripMenuItem
        '
        Me.NouveauJeuToolStripMenuItem.Name = "NouveauJeuToolStripMenuItem"
        Me.NouveauJeuToolStripMenuItem.Size = New System.Drawing.Size(86, 20)
        Me.NouveauJeuToolStripMenuItem.Text = "Nouveau jeu"
        '
        'ScoreTxt
        '
        Me.ScoreTxt.AutoSize = True
        Me.ScoreTxt.BackColor = System.Drawing.SystemColors.Info
        Me.ScoreTxt.ForeColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ScoreTxt.Location = New System.Drawing.Point(796, 53)
        Me.ScoreTxt.Name = "ScoreTxt"
        Me.ScoreTxt.Size = New System.Drawing.Size(44, 13)
        Me.ScoreTxt.TabIndex = 1
        Me.ScoreTxt.Text = "SCORE"
        '
        'ScoreNb
        '
        Me.ScoreNb.AutoSize = True
        Me.ScoreNb.BackColor = System.Drawing.SystemColors.Info
        Me.ScoreNb.Location = New System.Drawing.Point(796, 97)
        Me.ScoreNb.Name = "ScoreNb"
        Me.ScoreNb.Size = New System.Drawing.Size(13, 13)
        Me.ScoreNb.TabIndex = 2
        Me.ScoreNb.Text = "0"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MidnightBlue
        Me.ClientSize = New System.Drawing.Size(896, 511)
        Me.Controls.Add(Me.ScoreNb)
        Me.Controls.Add(Me.ScoreTxt)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents NouveauJeuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScoreTxt As System.Windows.Forms.Label
    Friend WithEvents ScoreNb As System.Windows.Forms.Label

End Class

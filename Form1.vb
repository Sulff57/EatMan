Public Class Form1

    Const taillePacman = 20
    Const tailleBille = 10
    Const score_niveau = 15 'points ajouté à chaque passage de niveau à multiplier par le level
    Const vitesse_base = 4

    Dim level As Integer = 1
    Dim vitesse_var As Integer = vitesse_base
    Dim nbBillesJaunes As Integer = 20 'Billes à avaler
    Dim nbBillesRouges As Integer = 6 'Billes à éviter
    Dim pos_x As Integer = 200
    Dim pos_y As Integer = 200



    Dim surface As New Rectangle(20, 46, 900, 500)
    'surface dans laquelle la boule peut se déplacer
    'la taille de la fenêtre et les bordures s'ajustent automatiquement

    Dim lesMursRouges As New Collection
    Dim lesBillesJaunes As New Collection
    Dim lesBillesRouges As New Collection
    Dim pacman_dessin As New Rectangle(pos_x, pos_y, taillePacman, taillePacman)

    Dim x, y, i As Integer

    Dim touchePressee As System.Windows.Forms.Keys


    Private Shared myTimer As New System.Windows.Forms.Timer()





    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler myTimer.Tick, AddressOf Timer1_Tick
        myTimer.Interval = 20

        Me.Height = surface.Height + 102 'on adapte les dimensions de la fenêtre en fonction de la surface
        Me.Width = surface.Width + 200

        ScoreTxt.Location() = New Point(surface.Width + 100, 50) 'on adapte également la position du score en fonction de la surface
        ScoreNb.Location() = New Point(surface.Width + 100, 80)







        'création de la collection de murs à ne pas toucher
        '(les dessins seront fait après à partir de celle-ci)


        lesMursRouges.Add(New Rectangle(surface.Width * 0.25, 100, 30, 125))
        lesMursRouges.Add(New Rectangle(surface.Width * 0.25, 100, 125, 30))
        lesMursRouges.Add(New Rectangle(surface.Width * 0.75, 100, 30, 125))
        lesMursRouges.Add(New Rectangle((surface.Width * 0.75) - 100, 100, 125, 30))
        lesMursRouges.Add(New Rectangle(surface.Width * 0.25, 350, 30, 125))
        lesMursRouges.Add(New Rectangle(surface.Width * 0.25, 450, 125, 30))
        lesMursRouges.Add(New Rectangle(surface.Width * 0.75, 355, 30, 125))
        lesMursRouges.Add(New Rectangle((surface.Width * 0.75) - 100, 450, 125, 30))


    End Sub

    Private Sub reset_jeu()
        'vidage des collections
        lesBillesJaunes = Nothing
        lesBillesRouges = Nothing

        lesBillesJaunes = New Collection
        lesBillesRouges = New Collection

        'réinitialisation du score
        ScoreNb.Text = 0
        add_score(0)

        'réinitialisation de la position de pacman
        reset_position()

        'réinitialisation niveau
        level = 1

        vitesse_var = vitesse_base

        generer_billes("bleues")
        For x = 1 To nbBillesRouges
            generer_billes("rouges")

        Next
    End Sub

    Private Sub reset_position()
        pos_x = 200
        pos_y = 200
        touchePressee = Keys.Pause
    End Sub

    Private Sub generer_billes(ByVal couleur As String)
        Dim coordonnees_x, coordonnees_y As Integer
        Dim bille_collision As Boolean

        'initialiser moteur de nombre aleatoire
        Randomize(My.Computer.Clock.LocalTime.Millisecond)




        i = 1
        While (i <= nbBillesJaunes) 'pour chaque bille
            bille_collision = False

            coordonnees_x = Rnd() * 698 'on génère des coordonnées aléatoires


            coordonnees_y = Rnd() * 520


            Dim bille As New Rectangle(coordonnees_x, coordonnees_y, tailleBille, tailleBille)


            'on va vérifier que la bille est générée à une location disponible


            'vérification de l'intersections avec les murs rouge
            For x = 1 To lesMursRouges.Count
                If lesMursRouges(x).IntersectsWith(bille) Then
                    bille_collision = True
                    'i = i - 1
                End If
            Next

            'vérification de l'intersections avec les murs bleus (qui délimitent la surface)
            If Not surface.Contains(bille) Then
                bille_collision = True
            End If

            'vérification de l'intersections avec les billes jaunes déjà générées
            For x = 1 To lesBillesJaunes.Count
                If lesBillesJaunes(x).IntersectsWith(bille) Then
                    bille_collision = True

                End If
            Next


            'vérification de l'intersections avec les billes rouges

            For x = 1 To lesBillesRouges.Count
                If lesBillesRouges(x).IntersectsWith(bille) Then
                    bille_collision = True
                End If
            Next

            'vérification de l'intersection avec le pacman
            If bille.IntersectsWith(pacman_dessin) Then
                bille_collision = True
            End If



            'et on y met la bille
            If Not bille_collision Then
                i = i + 1
                If couleur.Contains("bleues") Then
                    lesBillesJaunes.Add(bille)
                Else
                    lesBillesRouges.Add(bille)
                End If
            End If

        End While


    End Sub



    Private Sub moustique_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim pacman_dessin As New Rectangle(pos_x, pos_y, taillePacman, taillePacman)

        ' dessin de la boule
        e.Graphics.FillEllipse(Brushes.Yellow, pacman_dessin)


        'dessin des murs (adjacents à la surface)

        e.Graphics.FillRectangle(Brushes.Blue, New Rectangle(surface.Left - 20, surface.Top, 20, surface.Height)) 'dessin du mur gauche
        e.Graphics.FillRectangle(Brushes.Blue, New Rectangle(surface.Right, surface.Top, 20, surface.Height)) 'dessin du mur droit
        e.Graphics.FillRectangle(Brushes.Blue, New Rectangle(surface.Left - 20, surface.Top - 22, surface.Width + 40, 24)) 'dessin du mur haut
        e.Graphics.FillRectangle(Brushes.Blue, New Rectangle(surface.Left - 20, surface.Bottom - 2, surface.Width + 40, 20)) 'dessin du mur bas

        For x = 1 To lesMursRouges.Count
            e.Graphics.FillRectangle(Brushes.Red, lesMursRouges(x))
        Next

        For x = 1 To lesBillesJaunes.Count
            e.Graphics.FillEllipse(Brushes.Yellow, lesBillesJaunes(x))
        Next
        For x = 1 To lesBillesRouges.Count
            e.Graphics.FillEllipse(Brushes.Red, lesBillesRouges(x))
        Next
        ' murs

        If (pos_x < 0) Then
            pos_x = 698
        ElseIf (pos_x > 698) Then
            pos_x = 0 - taillePacman
        End If
    End Sub

    Private Sub moustique_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.Right Then
            touchePressee = Keys.Right
        End If
        If e.KeyData = Keys.Left Then
            touchePressee = Keys.Left
        End If
        If e.KeyData = Keys.Up Then
            touchePressee = Keys.Up
        End If
        If e.KeyData = Keys.Down Then
            touchePressee = Keys.Down
        End If
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'exécuté chaque tick
        deplacement()
        Me.FindForm.Refresh()
    End Sub
    Public Sub deplacement()
        ' on va créer un rectangle temporaire pour prévoir la collision suivante
        Dim test_x, test_y As Integer


        test_x = pos_x
        test_y = pos_y


        Select Case touchePressee
            Case Keys.Right
                test_x = pos_x + vitesse_var
            Case Keys.Left
                test_x = pos_x - vitesse_var
            Case Keys.Up
                test_y = pos_y - vitesse_var
            Case Keys.Down
                test_y = pos_y + vitesse_var
        End Select


        'on lui affecte sa position suivante théorique
        Dim rect_test As New Rectangle(test_x, test_y, taillePacman, taillePacman)

        'on teste s'il y aura collision,
        'suivant le résultat on va bouger le vrai eatman ou pas

        Dim intersection As Boolean = False
        'en cas d'intersection trouvée, la variable passera a true et on stope le traitement




        'on test si le rectangle est bien dans la suface
        If Not surface.Contains(rect_test) Then
            intersection = True
        End If

        'ou s'il touche un mur rouge
        For x = 1 To lesMursRouges.Count Step +1
            If lesMursRouges(x).IntersectsWith(rect_test) Then
                stoper_jeu()
                Exit For
            End If
        Next



        If Not intersection Then
            pos_x = test_x
            pos_y = test_y
        End If

        intersec()

    End Sub


    Private Sub intersec()
        Dim pactest As New Rectangle(pos_x, pos_y, 20, 20)


        For x = 1 To lesBillesJaunes.Count
            If lesBillesJaunes(x).IntersectsWith(pactest) Then
                myTimer.Stop()
                myTimer.Start()
                lesBillesJaunes.Remove(x)
                add_score(vitesse_var)

                If lesBillesJaunes.Count = 0 Then
                    generer_billes("bleues")
                    vitesse_var += 2
                    level += 1
                    'nombreBilles = nombreBilles + 2
                    add_score(score_niveau * level)
                    reset_position()
                    MsgBox("Niveau " & level.ToString, MsgBoxStyle.Information)

                End If
                Exit For
            End If
        Next

        For x = 1 To lesBillesRouges.Count
            If lesBillesRouges(x).IntersectsWith(pactest) Then
                stoper_jeu()
            End If
        Next

    End Sub

    Private Sub stoper_jeu()
        myTimer.Stop()
        MsgBox("PERDU", MsgBoxStyle.Information)
        MsgBox("Score :" & ScoreNb.Text, MsgBoxStyle.Exclamation)

    End Sub



    Private Sub add_score(ByVal points As Integer)
        Dim ancienne_valeur As String
        Dim nouvelle_valeur As Integer

        ancienne_valeur = ScoreNb.Text
        nouvelle_valeur = Int(ancienne_valeur) + points

        ScoreNb.Text = nouvelle_valeur
    End Sub
    Private Sub NouveauJeuToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NouveauJeuToolStripMenuItem.Click
        reset_jeu()
        myTimer.Start()
    End Sub


End Class

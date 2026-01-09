Projet Tappy (Flappy Bird)

Apprentissage sur une architecture commune (SignalHub, GameManager), les transitions, Parallax et enregistrement de donnée permanante.

Elément découvert:
    Code Commun -> Gestion de code commun dans un système "Globals" (SignalHub, Scoremanager, GameManager)
    Gestion de donné permanente -> Permet de stocker le score ou autre information dans un fichier (Scoremanager)
    Création d'une Resource -> Permet de gérer une donnée comme un score (HighScoreResource)
    Parallax -> Créer un décor qui bouge lors du gameplay (Godot)
    Gestion de la gravité -> Permet de prendre en compte la gravité sur un Body (Plane)
    Animation Player plus poussé -> Permet de déclencer un script pendant l'animation (ComplexChange)
    Gestion plus poussé des signaux -> La gestion des abonnements et des désabonnement du signal (Pipes)
    Découverte de l'élément character body -> Permet de mettre une gravité et de gérer les collisions différenment d'une area 2D (Plane)
    Création de Barrier -> Permet de blouer le joueur voir le 'tuer' si il touche le bord (Scene:Barrier, code: Plane - isFloor() )
    Découverte sur le mouvement -> Pour un character body, il faut utiliser le move and slide pour le déplacement

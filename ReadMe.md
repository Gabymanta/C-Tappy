# 🎮 Projet Tappy (Flappy Bird)

## 📖 Description
Ce projet est une implémentation du célèbre jeu Flappy Bird dans Godot. Il m'a permis d'explorer différentes architectures et systèmes essentiels au développement de jeux vidéo.

## 🚀 Fonctionnalités implémentées

### 🏗️ Architecture système
- **Code commun centralisé** : Création d'un système "Globals" pour gérer les éléments partagés (`SignalHub`, `ScoreManager`, `GameManager`)
- **Gestion des transitions** : Système de transitions fluides entre les différents états du jeu
- **Communication par signaux** : Utilisation avancée des signaux Godot avec gestion des abonnements/désabonnements (`Pipes`)

### 💾 Persistance des données
- **Stockage permanent** : Sauvegarde des scores et autres informations dans des fichiers (`ScoreManager`)
- **Resources personnalisées** : Création d'une `HighScoreResource` pour gérer les données de score de manière structurée

### 🎨 Éléments visuels
- **Effet Parallax** : Implémentation d'un décor qui défile pendant le gameplay pour créer une illusion de profondeur
- **Animations avancées** : Utilisation d'`AnimationPlayer` avec déclenchement de scripts pendant les animations (`ComplexChange`)

### 🕹️ Gameplay & Physique
- **Gestion de la gravité** : Application et contrôle de la gravité sur un objet physique (`Plane`)
- **CharacterBody2D** : Découverte et utilisation de l'élément `CharacterBody2D` pour une gestion différente des collisions
- **Mouvement avec CharacterBody** : Utilisation de `move_and_slide()` pour les déplacements avec collisions
- **Barrières de jeu** : Création de zones limitant le joueur (`Scene:Barrier`) avec mécanique de "game over" en cas de collision (`Plane - isFloor()`)

## 📚 Apprentissages clés

### 🏗️ Architecture
- **SignalHub** : Centralisation de la communication entre différents composants du jeu
- **GameManager** : Orchestration des états et du flux général du jeu
- **Système modulaire** : Séparation des responsabilités pour un code maintenable

### 🔧 Technicité Godot
- **Resources personnalisées** : Création de types de données réutilisables et configurables
- **CharacterBody vs Area2D** : Compréhension des différences fondamentales entre ces deux types de nœuds
- **Physique intégrée** : Lever de l'utilisation du moteur physique de Godot plutôt que des implémentations manuelles

### 🎮 Game Design
- **Feedback visuel** : Importance des animations et effets pour le ressenti du joueur
- **Contrôles réactifs** : Gestion précise des entrées utilisateur pour un gameplay satisfaisant
- **Boucle de jeu** : Structure claire des états (menu, jeu, game over, score)
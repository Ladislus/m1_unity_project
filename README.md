# Projet Unity Ladislas WALCAK 

## **Concept**  
Le concept de base est très fortement inspiré des jeux Shoot'Em Up de type "Bullet Hell", et plus particulièrement de Ikaruga sur DreamCast (Notamment pour le système de couleur de bouclier). C'est donc un Space shooter en top-down view.

## **Ce qui est implémenté**

### **Le joueur**
Le jeu permet de déplacer le vaisseau à l'aide des contrôles tactiles du téléphone. L'utilisation d'un premier doigt permet le déplacment sur l'axe horizontal du vaisseau, et l'utilisation d'un second doigt permet le changement de couleur du bouclier du vaisseau (quand celui-ci est présent) grâce à une simple pression. Le changement de couleur du bouclier permet de se rendre invulnérable au projectiles de la même couleur que le bouclier. Le bouclier à donc une barre de vie, qui n'est pas représentée sur le HUD du joueur, mais est représentée par l'animation du vaisseau, notamment l'ajout de dégats sur son sprite.

### **Les Armes**
Le jeu dispose de plusieurs armes disponibles qui sont actuellement au nombre de trois. Ces armes ont des statistiques différentes (vitesse des projectiles, nombre de projectiles, direction des projectiles et cooldown). Le tir est réalisé de manière automatique lorsque le cooldown de l'arme est fini.

### **Les ennemis**

#### **Aliens**
Le jeu dispose de 4 sprites différents pour les aliens. Ces aliens sont générés de manière aléatoire sur la scene avec une arme aléatoire, et ils ne disposent que d'un unique point de vie.

#### **Asteroids**
Le jeu dispose de 3 astéroids différents ayant des tailles différentes, générés et ajoutés de manière aléatoire sur la scene. Parmis ces 3 astéroids, ceux de petites tailles sont destructibles par les projectiles.

## **Ce qui autait dû être implémenté**

### **Différents déplacements pour les ennemis**
Actuellement, les différents aliens se déplacent de manière linéaire du haut vers le bas. Des déplacements différents et variés avaient été envisagés, mais par manque d'idées, et de par le fait que cela rendrait l'équilibrage du jeu encore plus dur qu'il ne l'est déjà, l'idée a été repoussée en "optionnelle".

### **Déplacement en fonction de l'orientation**
Lors de la création des tirs, j'avais dans l'idée que la direction en Z du sprite modifie la direction des tirs (les tirs devaient se déplacer dans la direction donnée par leur rotation en Z). Cependant, par manque de temps et de connaissances sur le fonctionnement des Quaternions et de la physique de déplacement, j'ai transformé cette idée en fonctionnalitée "optionnelle", qui n'a au final pas été réalisée par manque de temps.

### **Dégats aléatoires des armes**
Dans le concept original, les ennemies devaient être dotés de barre de vie distinctes. De plus, les différentes armes devaient infliger des dégats différents selon l'arme choisie. Cependant, afin de rendre le jeu jouable, j'ai préféré faire en sorte que les ennemis meurent en un seul coup. Des vestiges de cette idées se trouvent encore dans le code (Attributs des différentes armes).

### **Apparition de boss**
La création d'un boss, avec un sprite unique, et une très grande barre de vie a été envisagé. Cependant, par manque d'assets libres, de temps et de connaissances (création des assets, animations, sons ...), l'idée a été repoussée en "optionnelle", mais n'a pas vu le jour.

### **Animations**
L'amélioration des animations (notamment la création d'animations pour les ennemis, les impacts des projectiles, la destruction des astéroids) n'a pas été réalisée par manque de temps et de capacités en animations.

## **Difficultées**

### **Trouver une idée**
Une des plus grande difficulté à été de trouver une idée qui conviendrait à ce projet, pouvant ếtre réalisé dans le temps donné avec mes faibles connaissances sur Unity.

### **Déplacement du joueur**
Lors de la création du script de déplacement du joueur, j'ai dans un premier temps voulu insérer un Rigidbody2D ansi que le script de déplacement au sein du emptyGameObject contenant le vaisseau et son bouclier. Cependant, cela n'a pas été possible car le script ne s'activait pas et provoquait un erreur. Pour remédier à cela, j'ai du insérer le script de déplacement au sein du Sprite du vaisseau, et créer un autre script ainsi qu'un Rigidbody2D pour le bouclier, afin qu'il suive le vaisseau.

### **Affichage des scores**
Pour ce qui est de l'affichage des scores, c'est l'obtention d'une référence vers les champs de texte qui m'a poser problème. En derniers recours, j'ai utiliser le FindWithTag, associé avec une pair de tags. Comme le FindWithTag n'est pas éxecuté dans une fonction lancé lors de chaque frame comme un Update mais dans un fonction ponctuelle, j'ai trouvé cela acceptable.

### **Équilibrage du jeu**
Étant inspiré des jeux de type "Bullet Hell", ce jeu est donc pensé pour être très difficile. C'est par exemple pour cela que les projectiles alliés sont détruits lors de la collision avec les astéroids, mais que les projectiles ennemis, eux, passent à travers. Cependant, l'équilibrage doit quand même permettre à la plupart des personnes de jouer. De plus, le facteur aléatoire (apparition des monstres, couleurs des armes, bonus, ...) rend l'équilibrage est encore plus dur à réaslier que sur des jeux au niveaux préfaits, pouvant créer des scénarios dans lequel il est impossible de gagner. Des systèmes tels que des frames d'invulnérabilités pourraient être ajoutées pour rendre le jeux plus accessible.

## **Liens**

Pour ce qui est des assets, la grande majoritée proviennent du pack "Kenney Game Asset 1", obtenu sur Itch.io au sein du Bundle "Bundle for Racial Justice and Equality" datant de Juin 2020.

*Font*:  
 - https://www.fontspace.com/paladins-font-f32777  

*Autres assets (sprites, musiques, SFX, ...)*:  
 - https://assetstore.unity.com/packages/2d/textures-materials/galaxia-2d-space-shooter-sprite-pack-1-64944
 - https://medimongames.itch.io/pixel-spaceships-hd
 - https://kenney.itch.io/kenney-game-assets-1  

De plus, quelques tutoriaux ont été utilisés pour certains élément du jeux, notamment [ce tutoriel](https://www.youtube.com/watch?v=Oadq-IrOazg) de la chaine youtube Brackeys pour la réalisation de la transition entre les scenes.
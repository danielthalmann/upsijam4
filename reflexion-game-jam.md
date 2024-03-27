# Réflexions pour la prochaine Jam


## Points positifs

### Respect au sein de l’équipe

En dormant 3 à 5 heures par nuit et en travaillant +15h par jour, sans compter le stress sur la fin, il est facile de devenir irritable. Je suis content que tout le monde ait gardé son calme et que l’ambiance soit reste bonne durant toute la Jam.

### Diversification des talents et des responsabilités

Plusieurs personnes savaient autant dessiner que programmer, mais lorsque les tâches étaient attribuées chaque personne se concentrait sur sa tâche sans empiéter sur celles des autres. Non-seulement c’est plus efficace, mais c’est aussi plus agréable parce qu’avoir des tâches précises signifie qu’on passe plus rapidement d’une tâche à l’autre avec la sensation d’avancer et d’avoir des tâches variées.

### Synchronisation des horaires

Même si les horaires étaient libres et que tout le monde prenait des pauses selon ses besoins, on finissait aux mêmes heures, on mangeait ensemble, etc. Je pense que c’est important parce que ce sont des moments où l’on prend du recul sur l’état du jeux, on échange nos avancées et on discute des choses à faire.

## Améliorations possibles

### Respect de la thématique

#### Problème

Vote négatifs sur la question : le jeu respecte-t-il le thème ?

#### Solution

Organiser une session de brainstorming plus structurée :

1. Chaque personne écrit un maximum d’idées individuellement durant 5mn
2. Les idées sont mises en commun et de nouvelles idées apparaissent
3. On sélectionne l’idée qui nous semble la meilleure
4. Si durant l’exploration de la meilleure idée on se rend compte que le thème est difficile à respecter, ne pas hésiter à changer. Il vaut mieux changer d’idée après 15mn de discussion qu’après 15h de développement.

### Amusement durant le jeu

#### Problème

Le jeu n’était pas suffisamment distrayant, comme en témoigne la mauvaise note.

Je pense que cela vient du dynamisme du jeu. Le fermier est lent, on passe la plupart du temps à marcher à 5km/h dans l’enclos. Jouer à marcher est ennuyeux !

Certains bons jeux sont lents, par exemple le cube rempli d’énigmes. La différence c’est qu’avec le cube l’esprit est occupé à réfléchir. La tête ou les doigts, quelque chose doit travailler pour éviter l’ennui.

#### Solution

Il faut se demander « que doit-on faire durant le jeux ? » Si la réponse est « se déplacer lentement » il faut revoir la dynamique.

Dans notre cas il serait difficile d’en faire un puzzle (sauf à changer grandement le jeu). Il aurait fallut donner plus de dynamisme au jeux avec un fermier qui court, des poule-garou qui se jettent sur les poules saines et un fermier qui doit éviter les poules-garou.

Ou alors en faire un jeux de dexterité avec un drag’n’drop des poules dans l’enclos pendant que l’infection se propage rapidement.

### Animations

#### Problème

Il y avait très peu d’animations dans le jeux, uniquement la marche pour le fermier et les poule-garou.

Cela vient entre autres des difficultés pour intégrer les assets et les animations. Par exemple des animations pour le même personnage étaient faites sur des mesh différentes, des origines au mauvais endroit, des animations trop difficiles à intégrer dans le jeux (ex. jeter la poule, attraper une poule).

#### Solution

Dans blender on peut créer des actions pour attacher plusieurs animations à la même mesh. Dans Unity en FBX chaque action sera une nouvelle animation que l’on peut gérer indépendemment. Il est bien de garder certains éléments en tant qu’objet indépendant pour qu’on puisse les suivre depuis le code, par exemple les mains du fermier (ou un empty fixé sur les mains).

Les graphistes devraient aussi travailler sur Unity. Cela permet de vérifier que l’objet est correctement exporté, qu’il a les bonnes dimensions, que l’origine est au bon endroit, etc. Ça permet aussi d’éviter que les autres membres de l’équipe doivent retoucher les objets .fbx et .fbx.meta (pour éviter les conflits).

### Indications sur les actions

#### Problème

Dans les commentaire on a vu que beaucoup de gens ignorent qu’il est possible de lancer plus fort en maintenant la touche **espace** appuyée.

#### Solution

Toujours donner une indications lors d’une action. Ci-dessous une liste des actions et ce que l’on aurait pu faire pour les améliorer.

##### Déplacer le fermier

Les déplacements sont claires parce que le personnage change de direction, une animation se lance et le fermier se déplace dans la direction voulue. Le mouvement du fermier aurait pu être plus fluide lorsqu’il se tourne, nous aurions pu réutiliser l’algorithme utilisé pour les poules.

##### Attraper une poule

Attraper une poule est OK parce que la poule est téléportée sous le bras du fermier. Par contre on aurait du ajouter un indicateur qu’une poule est prête à être portée (elle bat des ailes, le fermer avance les bras, …) et indiquer plus clairement que le fermier tient la poule, ce n’était pas toujours évident à voir.

##### Lancer une poule

On ne voit pas du tout que maintenir **espace** impacte le jeux. Il faut donner une indication que quelque chose est en train de se passer. Une barre de progression est possible, mais le mieux est d’avoir une indication dans l’univers du jeux.

On peut avoir la séquence suivante :

1. Approcher une poule → la poule bat des ailes et le fermier avance ses bras. On voit que le fermier est prêt à attraper cette poule.
2. Clique sur **espace** → le fermier lève ses bras et tient la poule avec les bras tendus au-dessus de sa tête. Maintenant on voit clairement que le fermier tient une poule.
3. Appui prolongé sur **espace** → le fermier ne se déplace plus et tire de plus en plus ses bras vers l’arrière et courbe de plus en plus le dos. On voit que maintenir la touche espace impacte le jeux et la position du fermier indique qu’il s’apprête à lancer de plus en plus fort.
4. Relacher la touche **espace** → Les bras du fermier reviennent brusquement en avant et lancent la poule.

Ces 4 actions du fermier peuvent être faites avec une seule animation où les bras du fermier partent d’en bas et se lèvent loin derrière sa tête avec le dos courbé. On joue la première partie de l’animation pour attraper une poule. On joue lentement la seconde partie pour charger le lancer. On joue l’animation en sens inverse et en accéléré pour lancer.

Il faut aussi positionner dans Blender un empty qui suit les mains du fermier (ou avoir les mains en objets séparés), ça permet de positionner la poule à l’emplacement de cet empty même durant une animation.

### Conflits sur git

#### Problème

Nous avons eu plusieurs conflits sur git, et même des projets qui ne fonctionnent plus. Par chance c’est arrivé vers la fin de la Jam, mais ça aurait pu arriver en plein milieu !

#### Solution

- Chaque personne travail sur sa propre branche. On lance fetch et rebase depuis la branche principale avant de merger la notre sur la principale. Si un merge vers la branche principale crée des problème on peut facilement supprimer ce commit de la branche principale et réessayer.
- Un fichier est géré par une seule personne. Même s’il s’agit simplement de cocher une option c’est à cette personne de le faire. Autrement Unity change plusieurs choses dans le fichier et si quelqu’un d’autre coche une option il y aura des conflits compliqués à résoudre. Ça n’empêche pas de transférer la responsabilité du fichier à quelqu’un d’autre si besoin.

### Distribution du travail

#### Problème

Dans l’ensemble on a bien géré, je trouve. L’équipe artistique pousse des assets que l’équipe dév. utilise et les domaines étaient clairement attribués. Par contre tous les talents n’étaient pas correctement exploités, notamment à cause du pair-programming.

Le pair-programming est indiqué lorsqu’on souhaite avoir un code de haute qualité, lorsqu’il faut développer un algorithme compliqué, ou lorsqu’on souhaite que les membres d’une équipe comprennent le code les uns des autres.

Par contre il n’est pas indiqué pour du rapide programming comme dans une game-jam. C’est une double perte de temps parce que d’une part 2 personnes s’occupent d’un problème (alors qu’une personne peut très bien le faire assez facilement), d’autre part parce que des décisions sans incidences sont débattues telles que le nommage d’une fonction ou la bonne façon d’itérer sur une liste.

#### Solution

Chaque personne utilise son propre ordinateur pour avancer sur sa propre problématique. On doit s’entre-aider occasionnellement lorsqu’on est bloqué·e ; on ne doit pas passer tout la Jam à seconder quelqu’un d’autre.

### Taille et placement de l'UI

#### Problème

Les éléments de l'UI apparaissent au mauvais endroit, parfois trop petits, parfois trop grands selon la taille de l'écran.

#### Solution

Peut-être que le UI Toolkit permet un meilleur placement et redimensionnement des images.

## À faire durant la Jam

### Régulièrement tester le jeu

Il peut y avoir une grande différence entre ce que l'on prévoit dans notre tête et la réalité. Il est important de tester le jeux régulièrement pour vérifier que la game design reste intéressant.

Pour cela il est utile d'avoir un jeux jouable au plus vite, même si les assets ne sont pas encore prêts et que l'on contrôle un cube au milieux de sphères.

Il est également important de commencer par la mécanique principale. Si l'important est de pouvoir lancer un objet et que le déplacement est secondaire, commencer par tester le lancer.

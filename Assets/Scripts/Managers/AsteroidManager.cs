using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

// Gestionnaire des astéroids au cours de la partie
public class AsteroidManager : MonoBehaviour {

    // Chance d'apparition d'un astéroid lorsque
    // le nombre maximal n'est pas atteint [0; 100]
    public float spawnChance;
    // Cooldown entre l'apparition de deux astéroids
    public float cooldown;
    // Nombre maximum d'astéroids simultannés
    public int maxAsteroid;

    // Liste des préfabs des astéroids
    public List<GameObject> asteroidPrefabs;

    // Event invoqué lors de la destruction d'un astéroid
    private UnityEvent asteroidEvent;

    private int asteroidCount = 0;
    private float bottom;
    private float cooldownStatus;

    void Awake() {
        this.bottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;

        this.cooldownStatus = this.cooldown;

        this.asteroidEvent = new UnityEvent();
        // Ajout de la méthode 'asteroidDied' à l'event
        this.asteroidEvent.AddListener(asteroidDied);
    }

    void Update() {
        // Si le nombre maximum d'astéroid n'est pas atteint ...
        if (this.asteroidCount < maxAsteroid) {
            // ... Si le cooldown d'apparition est fini
            // Chaque astéroid déjà présent diminue les chances d'apparition :
            // Aléatoire entre [0; 100 + (20 x nombre d'astéroid)]
            // Si le chiffre aléatoire est inférieur à la chance d'apparition ...
            if (cooldownStatus <= 0f && (Random.Range(0, 100 + (20 * this.asteroidCount)) <= this.spawnChance)) {
                // ... Reset le cooldown
                this.cooldownStatus = this.cooldown;
                // ... Fait apparaitre un nouvel astéroid
                spawnNew();
            // Sinon si le cooldown n'est pas fini ...
            } else {
                // ... Décrémente le cooldown
                this.cooldownStatus -= Time.deltaTime;
            }    
        }
    }

    void spawnNew() {
        ++this.asteroidCount;
        // Selection aléatoire d'une des préfabs des astéroids
        int selectedPrefab = Random.Range(0, this.asteroidPrefabs.Count);
        GameObject asteroid = GameObject.Instantiate(
            this.asteroidPrefabs[selectedPrefab],
            // Apparition de l'astéroid sous le zone de jeu
            // Le script de déplacement des astéroids s'occupera de
            // faire réapparaitre l'astéroid en haut de la zone de jeu,
            // avec un position aléatoire défini dans les paramètre publics
            // de ce script (évite les doublons)
            new Vector3(0, bottom - 10f, 0),
            Quaternion.identity
        );
        // Ajout de l'event dans le script de gestion de la vie des astéroids
        asteroid.GetComponent<lifeAsteroid>().asteroidEvent = this.asteroidEvent;
    }

    // Fonction enregistrer dans l'event permettant
    // de décrémenter le nombre d'astéroids lors de la destruction
    // de l'un d'eux, ainsi que de jouer un son d'explosion
    void asteroidDied() {
        --this.asteroidCount;
        SoundManager.Instance.playSound(Sounds.EXPLOSION);
    }
}

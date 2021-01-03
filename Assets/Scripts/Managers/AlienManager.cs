using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

// Gestionnaire des astéroids au cours de la partie
public class AlienManager : MonoBehaviour {

    // Chance d'apparition d'un alien lorsque
    // le nombre maximal n'est pas atteint [0; 100]
    public float spawnChance;
    // Cooldown entre l'apparition de deux aliens
    public float cooldown;
    // Nombre maximum d'aliens simultannés
    public int maxEnemy;

    // Chances d'apparition d'un powerups lors
    // de la mort d'un des aliens [0: 100]
    public float spawnChanceIonGun;
    public float spawnChanceLaserGun;
    public float spawnChanceMachineGun;

    // Liste des préfabs des aliens
    public List<GameObject> alienPrefabs;

    // Préfabs des powerups
    public GameObject ionGunPrefab;
    public GameObject laserGunPrefab;
    public GameObject machineGunPrefab;

    // Event invoqué lors de la destruction d'un alien
    private UnityEvent alienEvent;

    private int enemyCount = 0;
    private float top;
    private float bottom;
    private float right;
    private float left;
    private float cooldownStatus;

    void Awake() {        
        this.top = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
        this.bottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        this.left = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        this.right = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        this.cooldownStatus = this.cooldown;

        this.alienEvent = new UnityEvent();
        // Ajout de la méthode 'asteroidDied' à l'event
        this.alienEvent.AddListener(alienDied);
        // Ajout de la méthode 'spawnPowerup' à l'event
        this.alienEvent.AddListener(spawnPowerup);
    }

    // Lors du lancement de la partie, initialise le score
    void Start() {
        ScoreManager.Instance.startGame();
    }


    void Update() {
        // Si le nombre maximum d'alien n'est pas atteint ...
        if (this.enemyCount < maxEnemy) {
            // ... Si le cooldown d'apparition est fini
            // Chaque alien déjà présent diminue les chances d'apparition :
            // Aléatoire entre [0; 100 + (20 x nombre d'alien)]
            // Si le chiffre aléatoire est inférieur à la chance d'apparition ...
            if (cooldownStatus <= 0f && (Random.Range(0, 100 + (20 * this.enemyCount)) <= this.spawnChance)) {
                // ... Reset le cooldown
                this.cooldownStatus = this.cooldown;
                // ... Fait apparaitre un nouvel alien
                spawnNew();
            // Sinon si le cooldown n'est pas fini ...
            } else {
                // ... Décrémente le cooldown
                this.cooldownStatus -= Time.deltaTime;
            }    
        }
    }

    void spawnNew() {
        ++this.enemyCount;
        // Selection aléatoire d'une des préfabs des aliens
        int selectedPrefab = Random.Range(0, this.alienPrefabs.Count);
        GameObject alien = GameObject.Instantiate(
            this.alienPrefabs[selectedPrefab],
            // Apparition de l'alien sous le zone de jeu
            // Le script de déplacement des aliens s'occupera de
            // faire réapparaitre l'alien en haut de la zone de jeu,
            // avec un position aléatoire défini dans les paramètre publics
            // de ce script (évite les doublons)
            new Vector3(0, bottom - 10f, 0),
            Quaternion.identity
        );
        // Ajout de l'event dans le script de gestion de la vie des aliens
        alien.GetComponent<lifeAlien>().alienEvent = this.alienEvent;
    }

    // Fonction enregistrer dans l'event permettant
    // de décrémenter le nombre d'alien lors de la destruction
    // de l'un d'eux, ainsi que de jouer un son d'explosion, 
    // et d'ajouter 100 points
    void alienDied() {
        --this.enemyCount;
        SoundManager.Instance.playSound(Sounds.EXPLOSION);
        ScoreManager.Instance.AddPoints(100);
    }

    void createPowerup(GameObject prefab) {
        GameObject.Instantiate(
            prefab,
            new Vector3(
                Random.Range(this.left + 0.5f, this.right - 0.5f),
                this.top + 2f,
                0
            ),
            Quaternion.identity
        );
    }

    // Fonction permettant de faire apparaitre ou non un
    // powerup, ainsi que lequel faire apparaitre
    void spawnPowerup() {
        float rand = Random.Range(0f, 100f);
        if (rand <= this.spawnChanceIonGun) createPowerup(this.ionGunPrefab);
        else if (rand <= (this.spawnChanceIonGun + this.spawnChanceLaserGun)) createPowerup(this.laserGunPrefab);
        else if (rand <= (this.spawnChanceIonGun + this.spawnChanceLaserGun + this.spawnChanceMachineGun)) createPowerup(this.machineGunPrefab);
    }
}

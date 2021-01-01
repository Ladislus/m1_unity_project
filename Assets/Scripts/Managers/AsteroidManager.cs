using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class AsteroidManager : MonoBehaviour {

    public float spawnChance;
    public float cooldown;
    public int maxAsteroid;

    public List<GameObject> asteroidPrefabs;

    private GameObject gameController;
    private SoundManager soundManager;

    private UnityEvent asteroidEvent;

    private int asteroidCount = 0;
    private float bottom;
    private float cooldownStatus;

    void Awake() {
        this.gameController = GameObject.FindWithTag("GameController");
        this.soundManager = this.gameController.GetComponent<SoundManager>();

        this.bottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;

        this.cooldownStatus = this.cooldown;

        this.asteroidEvent = new UnityEvent();
        this.asteroidEvent.AddListener(asteroidDied);
    }

    void Update() {
        if (this.asteroidCount < maxAsteroid) {
            if (cooldownStatus <= 0f && (Random.Range(0, 100 + (20 * this.asteroidCount)) <= this.spawnChance)) {
                this.cooldownStatus = this.cooldown;
                spawnNew();
            } else {
                this.cooldownStatus -= Time.deltaTime;
            }    
        }
    }

    void spawnNew() {
        ++this.asteroidCount;
        int selectedPrefab = Random.Range(0, this.asteroidPrefabs.Count);
        GameObject asteroid = GameObject.Instantiate(
            this.asteroidPrefabs[selectedPrefab],
            new Vector3(0, bottom - 10f, 0),
            Quaternion.identity
        );
        asteroid.GetComponent<lifeAsteroid>().asteroidEvent = this.asteroidEvent;
    }

    void asteroidDied() {
        --this.asteroidCount;
        this.soundManager.playSound(Sounds.EXPLOSION);
    }
}

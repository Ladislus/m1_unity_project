using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class AlienManager : MonoBehaviour {

    public float spawnChance;
    public float cooldown;
    public int maxEnemy;

    public List<GameObject> alienPrefabs;

    private GameObject gameController;
    private SoundManager soundManager;
    private ScoreManager scoreManager;

    private UnityEvent alienEvent;

    private int enemyCount = 0;
    private float bottom;
    private float cooldownStatus;

    void Awake() {
        this.gameController = GameObject.FindWithTag("GameController");
        this.soundManager = this.gameController.GetComponent<SoundManager>();
        this.scoreManager = this.gameController.GetComponent<ScoreManager>();
        
        this.bottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;

        this.cooldownStatus = this.cooldown;

        this.alienEvent = new UnityEvent();
        this.alienEvent.AddListener(alienDied);
    }

    void Start() {
        this.scoreManager.startGame();
    }

    void Update() {
        if (this.enemyCount < maxEnemy) {
            if (cooldownStatus <= 0f && (Random.Range(0, 100 + (20 * this.enemyCount)) <= this.spawnChance)) {
                this.cooldownStatus = this.cooldown;
                spawnNew();
            } else {
                this.cooldownStatus -= Time.deltaTime;
            }    
        }
    }

    void spawnNew() {
        ++this.enemyCount;
        int selectedPrefab = Random.Range(0, this.alienPrefabs.Count);
        GameObject alien = GameObject.Instantiate(
            this.alienPrefabs[selectedPrefab],
            new Vector3(0, bottom - 10f, 0),
            Quaternion.identity
        );
        alien.GetComponent<lifeAlien>().alienEvent = this.alienEvent;
    }

    void alienDied() {
        --this.enemyCount;
        this.soundManager.playSound(Sounds.EXPLOSION);
        this.scoreManager.AddPoints(100);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class AlienManager : MonoBehaviour {

    public float spawnChance;
    public float cooldown;
    public int maxEnemy;

    public float spawnChanceIonGun;
    public float spawnChanceLaserGun;
    public float spawnChanceMachineGun;

    public List<GameObject> alienPrefabs;

    public GameObject ionGunPrefab;
    public GameObject laserGunPrefab;
    public GameObject machineGunPrefab;

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
        this.alienEvent.AddListener(alienDied);
        this.alienEvent.AddListener(spawnPowerup);
    }

    void Start() {
        ScoreManager.Instance.startGame();
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

    void spawnPowerup() {
        float rand = Random.Range(0f, 100f);
        if (rand <= this.spawnChanceIonGun) createPowerup(this.ionGunPrefab);
        else if (rand <= (this.spawnChanceIonGun + this.spawnChanceLaserGun)) createPowerup(this.laserGunPrefab);
        else if (rand <= (this.spawnChanceIonGun + this.spawnChanceLaserGun + this.spawnChanceMachineGun)) createPowerup(this.machineGunPrefab);
    }
}

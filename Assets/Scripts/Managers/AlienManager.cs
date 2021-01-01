using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienManager : MonoBehaviour {

    public float spawnChance;
    public float spawnField;
    public int maxEnemy;

    public List<GameObject> alienPrefabs;

    private ScoreManager scoreManager;

    private int enemyCount = 0;

    private float top;

    void Awake() {
        this.scoreManager = GameObject.FindWithTag("GameController").GetComponent<ScoreManager>();
        this.top = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    }

    void Start() {
        this.scoreManager.startGame();
    }

    void Update() {
        if (shouldSpawn()) spawnNew();
    }

    bool shouldSpawn() {
        if (this.enemyCount < this.maxEnemy) return true;
        return false;
    }

    void spawnNew() {
        int selected = Random.Range(0, 3);
    }
}

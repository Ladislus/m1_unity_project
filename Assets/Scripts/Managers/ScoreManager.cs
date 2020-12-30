using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    private static ScoreManager _instance;

    private int highscore;
    private int score = 0;

    void Awake() {
        if (_instance == null) { 
            _instance = this;
            DontDestroyOnLoad(this.gameObject); 
        }
        else Destroy(this); 

        this.highscore = PlayerPrefs.GetInt("highscore", 0);
        // TODO
        GameObject.FindWithTag("Score").GetComponent<Text>().text = "" + this.highscore; 
    }

    void AddPoint(int points) {
        this.score += points;
    }

    void EndGame() {
        if (this.score > this.highscore) {
            this.highscore = score;
            PlayerPrefs.SetInt("highscore", this.score);
            // TODO
            GameObject.FindWithTag("Score").GetComponent<Text>().text = "" + this.highscore; 
        }
        this.score = 0;
    }
}

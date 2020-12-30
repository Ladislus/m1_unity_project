using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    private static ScoreManager _instance;

    public Text highscore_text;

    private int highscore;
    private int score = 0;

    void Awake() {
        if (_instance == null) { 
            _instance = this;
            DontDestroyOnLoad(this.gameObject); 
        }
        else Destroy(this); 

        this.highscore = PlayerPrefs.GetInt("highscore", 0);
        this.highscore_text.text = "" + this.highscore;
    }

    void AddPoint(int points) {
        this.score += points;
    }

    void EndGame() {
        if (this.score > this.highscore) {
            this.highscore = score;
            PlayerPrefs.SetInt("highscore", this.score);
            this.highscore_text.text = "" + this.highscore;
        }
        this.score = 0;
    }
}

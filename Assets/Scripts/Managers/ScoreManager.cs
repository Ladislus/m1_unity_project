using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    private static ScoreManager _instance;

    private int highscore;
    private int score = 0;

    private Text scoreDisplay;

    void Awake() {
        if (_instance == null) { 
            _instance = this;
            DontDestroyOnLoad(this.gameObject); 
        }
        else Destroy(this); 

        this.highscore = PlayerPrefs.GetInt("highscore", 0);
        GameObject.FindWithTag("Highscore").GetComponent<Text>().text = "" + this.highscore; 
    }

    public void startGame() {
        this.scoreDisplay = GameObject.FindWithTag("Score").GetComponent<Text>();
        this.scoreDisplay.text = "" + this.score;
    }

    public void AddPoints(int points) {
        this.score += points;
        this.scoreDisplay.text = "" + this.score;
    }

    public void endGame() {
        if (this.score > this.highscore) {
            this.highscore = score;
            PlayerPrefs.SetInt("highscore", this.score);
            GameObject.FindWithTag("NewHighscore").GetComponent<Text>().enabled = true; 
        }
        GameObject.FindWithTag("Score").GetComponent<Text>().text = "" + this.score; 
        GameObject.FindWithTag("Highscore").GetComponent<Text>().text = "" + this.highscore; 
        this.score = 0;
    }
}

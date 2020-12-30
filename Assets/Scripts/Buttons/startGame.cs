using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour {

    private GameObject gameManager;

    void Awake() {
        this.gameManager = GameObject.FindWithTag("GameController");
    }

    public void OnClick() {
        // FIXME
        this.gameManager.GetComponent<SoundManager>().playClick();
        SceneManager.LoadSceneAsync("Game");
    }
}

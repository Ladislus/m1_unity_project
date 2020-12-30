using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour {

    public GameObject gameManager;

    public void OnClick() {
        this.gameManager.GetComponent<SoundManager>().playClick();
        SceneManager.LoadSceneAsync("Game");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundControl : MonoBehaviour {

    private GameObject gameManager;

    void Awake() {
        this.gameManager = GameObject.Find("GameManager");
    }

    public void Onclick() {
        this.gameManager.GetComponent<SoundManager>().toggleMusic();
    }
}

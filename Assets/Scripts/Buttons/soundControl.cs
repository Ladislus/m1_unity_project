using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundControl : MonoBehaviour {

    private SoundManager soundManager;

    void Awake() {
        this.soundManager = GameObject.FindWithTag("GameController").GetComponent<SoundManager>();
    }

    public void Onclick() {
        this.soundManager.toggleMusic();
    }
}

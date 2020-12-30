using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startGame : MonoBehaviour {

    public LevelFader fader;

    private SoundManager soundManager;

    void Awake() {
        this.soundManager = GameObject.FindWithTag("GameController").GetComponent<SoundManager>();
    }

    public void OnClick() {
        this.soundManager.playSound(SoundManager.CLICK);
        this.fader.fadeOutToLevel("Game");
    }
}

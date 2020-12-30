using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startGame : MonoBehaviour {

    public SoundManager soundManager;
    public LevelFader fader;

    public void OnClick() {
        // FIXME
        this.soundManager.playClick();
        this.fader.fadeOutToLevel("Game");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startGame : MonoBehaviour {

    public LevelFader fader;

    public void OnClick() {
        SoundManager.Instance.playSound(Sounds.CLICK);
        this.fader.fadeOutToLevel("Game");
    }
}

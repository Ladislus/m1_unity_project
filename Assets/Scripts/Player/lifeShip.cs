using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeShip : MonoBehaviour {

    public LevelFader fader;

    public Collider2D shipCollider;
    public fadeOut fadeOutScript;

    public void hit() {
        this.shipCollider.enabled = false;
        this.fadeOutScript.enabled = true;
        SoundManager.Instance.playSound(Sounds.EXPLOSION);
        this.fader.fadeOutToLevel("End");
    }
}

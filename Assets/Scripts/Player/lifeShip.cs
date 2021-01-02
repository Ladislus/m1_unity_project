﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeShip : MonoBehaviour {

    //TODO
    public LevelFader fader;

    public Collider2D collider;
    public fadeOut fadeOutScript;

    public void hit() {
        this.collider.enabled = false;
        this.fadeOutScript.enabled = true;
        GameObject.FindWithTag("GameController").GetComponent<SoundManager>().playSound(Sounds.EXPLOSION);
        this.fader.fadeOutToLevel("End");
    }
}
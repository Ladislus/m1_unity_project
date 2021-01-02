﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class lifeAlien : MonoBehaviour {

    public Collider2D alienCollider;
    public fadeOut fadeOutScript;

    public UnityEvent alienEvent;

    public void hit() {
        this.alienCollider.enabled = false;
        this.fadeOutScript.enabled = true;
        if (this.alienEvent != null) this.alienEvent.Invoke();
        else Debug.LogWarning("AlienEvent is null");
    }
}

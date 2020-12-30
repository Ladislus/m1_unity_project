﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerAsteroid : MonoBehaviour {

    public fadeOut fadeOutScript;
    public Collider2D collider;
    public Rigidbody2D rigidbody;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Shield" || other.tag == "Ship") {
            this.collider.enabled = false;
            this.rigidbody.velocity = Vector2.zero;
            this.fadeOutScript.enabled = true;
        }
    }
}
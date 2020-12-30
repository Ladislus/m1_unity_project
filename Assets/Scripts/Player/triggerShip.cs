using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerShip : MonoBehaviour {

    public Collider2D collider;
    public fadeOut fadeOutScript;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Asteroid") {
            this.collider.enabled = false;
            this.fadeOutScript.enabled = true;
        }
    }
}

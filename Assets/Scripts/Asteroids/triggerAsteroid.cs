using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class triggerAsteroid : MonoBehaviour {

    public lifeAsteroid lifeAsteroid;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Shield" || other.tag == "Ship") {
            this.lifeAsteroid.hit();
        }
    }
}

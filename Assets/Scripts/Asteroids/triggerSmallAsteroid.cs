using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerSmallAsteroid : MonoBehaviour {

    public lifeAsteroid lifeAsteroid;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Projectile") {
            this.lifeAsteroid.hit();
        }
    }
}

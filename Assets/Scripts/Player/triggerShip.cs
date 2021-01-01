using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerShip : MonoBehaviour {

    public lifeShip lifeShip;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Asteroid" || other.tag == "Alien") {
            this.lifeShip.hit();
        }
    }
}

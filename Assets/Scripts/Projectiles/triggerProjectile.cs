using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerProjectile : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Alien" || other.tag == "Asteroid") {
            if (other.tag == "Alien") {
                other.gameObject.GetComponent<lifeAlien>().hit();
            }
            this.GetComponent<Collider2D>().enabled = false;
            this.GetComponent<fadeOut>().enabled = true;
        }
    }
}

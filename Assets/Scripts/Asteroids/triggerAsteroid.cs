using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerAsteroid : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.name == "Shield") {
            collider.gameObject.GetComponent<lifeShield>().hit();
            this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            this.gameObject.GetComponent<fadeOut>().enabled = true;
        }
        if (collider.name == "Ship") {
            collider.gameObject.GetComponent<fadeOut>().enabled = true;
        }
    }
}

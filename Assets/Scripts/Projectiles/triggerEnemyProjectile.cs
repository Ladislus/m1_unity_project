using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerEnemyProjectile : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Shield" || other.tag == "Ship") {
            if (other.tag == "Shield" && other.gameObject.GetComponent<colorShield>().color != this.GetComponent<colorProjectile>().color) {
                other.gameObject.GetComponent<lifeShield>().hit();
            }
            this.GetComponent<Collider2D>().enabled = false;
            this.GetComponent<fadeOut>().enabled = true;
        }
    }
}
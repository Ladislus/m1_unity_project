using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerAlien : MonoBehaviour {

    public lifeAlien lifeAlien;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Shield" || other.tag == "Ship") {
            this.lifeAlien.hit();
        }
    }

}

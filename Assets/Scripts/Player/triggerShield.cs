using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerShield : MonoBehaviour {
    
    public lifeShield lifeShieldScript;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Asteroid") {
            this.lifeShieldScript.hit();
        }    
    }
}

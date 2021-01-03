using UnityEngine;

// Trigger du bouclier
public class triggerShield : MonoBehaviour {
    
    // Script de gestion de la vie du bouclier
    public lifeShield lifeShieldScript;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Asteroid" || other.tag == "Alien") {
            this.lifeShieldScript.hit();
        }    
    }
}

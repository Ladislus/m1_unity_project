using UnityEngine;

// Trigger du vaisseau
public class triggerShip : MonoBehaviour {

    // Script de gestion de la vie du vaisseau
    public lifeShip lifeShip;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Asteroid" || other.tag == "Alien") {
            this.lifeShip.hit();
        }
    }
}

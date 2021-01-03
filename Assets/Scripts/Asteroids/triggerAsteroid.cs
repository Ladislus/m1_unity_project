using UnityEngine;

// Trigger des astéroids
public class triggerAsteroid : MonoBehaviour {

    // Script de gestion de la vie des astéroids
    public lifeAsteroid lifeAsteroid;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Shield" || other.tag == "Ship") {
            this.lifeAsteroid.hit();
        }
    }
}

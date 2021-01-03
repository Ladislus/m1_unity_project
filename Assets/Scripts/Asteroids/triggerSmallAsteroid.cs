using UnityEngine;

// Trigger des petits astéroids
public class triggerSmallAsteroid : MonoBehaviour {

    // Script de gestion de la vie des astéroids
    public lifeAsteroid lifeAsteroid;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Projectile") {
            // Destruction des petits astéroids
            // lors de la collision avec les projetiles
            this.lifeAsteroid.hit();
        }
    }
}

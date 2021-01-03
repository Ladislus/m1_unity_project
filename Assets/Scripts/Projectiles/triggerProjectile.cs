using UnityEngine;

// Trigger pour les projectiles alliés
public class triggerProjectile : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Alien" || other.tag == "Asteroid") {
            if (other.tag == "Alien") {
                other.gameObject.GetComponent<lifeAlien>().hit();
            }
            // Désactivation du collider, puis fadeout & destruction de l'objet
            // (GetComponent car les projectiles sont générés à la volée)
            this.GetComponent<Collider2D>().enabled = false;
            this.GetComponent<fadeOut>().enabled = true;
        }
    }
}
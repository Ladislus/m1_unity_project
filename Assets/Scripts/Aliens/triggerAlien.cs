using UnityEngine;

// Trigger des aliens
public class triggerAlien : MonoBehaviour {

    // Script de gestion de la vie des aliens
    public lifeAlien lifeAlien;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Shield" || other.tag == "Ship") {
            this.lifeAlien.hit();
        }
    }

}

using UnityEngine;

// Trigger pour les projectiles ennemis
public class triggerEnemyProjectile : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Shield" || other.tag == "Ship") {
            // Si le shield n'a pas la même couleur que le projectile, endommage le joueur
            if (other.tag == "Shield" && other.gameObject.GetComponent<colorShield>().color != this.GetComponent<colorProjectile>().color) {
                other.gameObject.GetComponent<lifeShield>().hit();
            }
            if (other.tag == "Ship") {
                other.gameObject.GetComponent<lifeShip>().hit();
            }
            // Désactivation du collider, puis fadeout & destruction de l'objet
            // (GetComponent car les projectiles sont générés à la volée)
            this.GetComponent<Collider2D>().enabled = false;
            this.GetComponent<fadeOut>().enabled = true;
        }
    }
}
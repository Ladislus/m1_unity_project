using UnityEngine;

// Trigger des powerups
public class triggerPowerup : MonoBehaviour {

    public Collider2D powerupCollider;
    public fadeOut fadeOutScript;

    public Guns gun;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ship" || other.tag == "Shield") {
            if (other.tag == "Ship") {
                // Si l'on collide avec le vaisseau, le vaisseau change d'arme
                other.gameObject.GetComponent<shootPlayer>().setGun(this.gun);
            } else {
                // Si l'on collide avec le bouclier, il faut d'abords récupérer le vaisseau
                // Player
                // 	↳ Child(0) : Ship
                // 	↳ Child(1) : Shield
                other.gameObject.transform.parent.gameObject.transform.GetChild(0).GetComponent<shootPlayer>().setGun(this.gun);
            }
            // Désactivation du collider, fadeout & destruction de l'objet + son
            this.powerupCollider.enabled = false;
            this.fadeOutScript.enabled = true;
            SoundManager.Instance.playSound(Sounds.POWERUP);
        }
    }
}

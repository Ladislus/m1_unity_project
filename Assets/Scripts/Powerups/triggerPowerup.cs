using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerPowerup : MonoBehaviour {

    public Collider2D powerupCollider;
    public fadeOut fadeOutScript;

    public Guns gun;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ship" || other.tag == "Shield") {
            if (other.tag == "Ship") {
                other.gameObject.GetComponent<shootPlayer>().setGun(this.gun);
            } else {
                other.gameObject.transform.parent.gameObject.transform.GetChild(0).GetComponent<shootPlayer>().setGun(this.gun);
            }
            this.powerupCollider.enabled = false;
            this.fadeOutScript.enabled = true;
            SoundManager.Instance.playSound(Sounds.POWERUP);
        }
    }
}

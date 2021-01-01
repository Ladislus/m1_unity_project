using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeShield : MonoBehaviour {
    
    public fadeOut fadeOutScript;
    public Animator shipAnimator;
    public Collider2D shieldCollider;
    public Collider2D shipCollider;

    private SoundManager soundManager;

    private int lifePoints = 3;

    void Awake() {
        this.soundManager = GameObject.FindWithTag("GameController").GetComponent<SoundManager>();
    }

    public void hit() {
        if (this.lifePoints == 0) {
            this.shieldCollider.enabled = false;
            this.fadeOutScript.enabled = true;
            this.shipCollider.enabled = true;
        } else {
            this.shipAnimator.SetInteger("Life", --this.lifePoints);
        }
        this.soundManager.playSound(Sounds.DAMAGE);
    }
}

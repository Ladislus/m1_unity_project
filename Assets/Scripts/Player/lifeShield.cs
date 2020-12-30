using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeShield : MonoBehaviour {
    
    public fadeOut fadeout_script;

    public Animator shipAnimator;
    public BoxCollider2D shipCollider;

    private SoundManager soundManager;

    private int life_points = 3;

    void Awake() {
        this.soundManager = GameObject.FindWithTag("GameController").GetComponent<SoundManager>();
    }

    public void hit() {
        if (this.life_points == 0) {
            this.fadeout_script.enabled = true;
            this.shipCollider.enabled = true;
        } else {
            this.soundManager.playDamage();
            --this.life_points;
            this.shipAnimator.SetInteger("Life", this.life_points);
        }
    }

}

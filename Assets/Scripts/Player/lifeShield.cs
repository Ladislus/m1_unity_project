using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeShield : MonoBehaviour {
    
    public Animator shipAnimator;

    private GameObject gameManager;

    private int life_points = 3;

    void Awake() {
        this.gameManager = GameObject.FindWithTag("GameController");
    }

    public void hit() {
        if (this.life_points == 0) {
            Destroy(this.gameObject);
        } else {
            this.gameManager.GetComponent<SoundManager>().playDamage();
            this.life_points--;
            this.shipAnimator.SetInteger("Life", this.life_points);
        }
    }

}

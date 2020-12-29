using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorShield : MonoBehaviour {

    public Sprite blue_shield;
    public Sprite green_sprite;

    private SPColor color = ShieldColor.Blue;

    private SpriteRenderer sr;

    void Start() {
        this.sr = GetComponent<SpriteRenderer>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (this.color == SPColor.Blue) {
                this.color = SPColor.Green;
                this.sr.sprite = this.green_sprite;
            } else {
                this.color = SPColor.Blue;
                this.sr.sprite = blue_shield;
            }
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorShield : MonoBehaviour {

    public Sprite blue_shield;
    public Sprite green_sprite;

    public SpriteRenderer spriteRenderer;

    public SPColor color = SPColor.Blue;

    void Update() {
        if (Input.touchCount > 1 && Input.GetTouch(1).phase == TouchPhase.Began) {
            if (this.color == SPColor.Blue) {
                this.color = SPColor.Green;
                this.spriteRenderer.sprite = this.green_sprite;
            } else {
                this.color = SPColor.Blue;
                this.spriteRenderer.sprite = blue_shield;
            }
        }
    }
}

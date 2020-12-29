using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun {

    private Transform transform;

    private float cooldown;
    private float current_cooldown;

    private float min_damages;
    private float max_damages;


    private SPColor color;

    public Gun(Transform transform, float cooldown, float min_damages, float max_damages, SPColor color) {
        this.cooldown = cooldown;
        this.current_cooldown = cooldown;

        this.min_damages = min_damages;
        this.max_damages = max_damages;

        this.transform = transform;

        this.color = SPColor;
    }

    public void isReady(float elapsedTime) {
        this.current_cooldown -= elapsedTime;
        if (this.current_cooldown <= 0) {
            shoot();
            this.current_cooldown = this.cooldown;
        }
    }

    public abstract void shoot();
}

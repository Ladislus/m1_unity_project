using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun {

    protected GameObject bluePrefab;
    protected GameObject greenPrefab;

    protected Transform transform;

    protected float cooldown;
    protected float current_cooldown;

    protected SPColor color;

    public Gun(Transform transform, float cooldown, SPColor color, GameObject bluePrefab, GameObject greenPrefab) {
        this.cooldown = cooldown;
        this.current_cooldown = cooldown;

        this.bluePrefab = bluePrefab;
        this.greenPrefab = greenPrefab;

        this.transform = transform;

        this.color = color;
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

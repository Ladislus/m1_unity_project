using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : IGun {

    public float cooldown;
    public float min_damages;
    public float max_damages;

    private float current_cooldown = cooldown;

    void cooldown() {
        this.current_cooldown = this.current_cooldown - Time.deltaTime;
        if (this.current_cooldown <= 0) {
            shoot();
            this.current_cooldown = this.cooldown;
        }
    }
}

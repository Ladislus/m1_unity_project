using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun {

    protected GameObject bluePrefab;
    protected GameObject greenPrefab;

    protected Transform transform;

    protected float cooldown;
    protected float current_cooldown;

    protected float min_damages;
    protected float max_damages;

    protected SPColor color;

    public Gun(Transform transform, float cooldown, float min_damages, float max_damages, SPColor color, GameObject bluePrefab, GameObject greenPrefab) {
        this.cooldown = cooldown;
        this.current_cooldown = cooldown;

        this.bluePrefab = bluePrefab;
        this.greenPrefab = greenPrefab;

        this.min_damages = min_damages;
        this.max_damages = max_damages;

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

    public void shoot() {

        GameObject selectedPrefab;
        if (this.color == SPColor.Blue) selectedPrefab = this.bluePrefab;
        else selectedPrefab = this.greenPrefab;

        Quaternion target_rotation;
        if (this.transform.eulerAngles.z < -90 || this.transform.eulerAngles.z > 90) {
            target_rotation = Quaternion.Euler(
                this.transform.eulerAngles.x,
                this.transform.eulerAngles.y,
                -180
            );
        } else {
            target_rotation = Quaternion.Euler(
                this.transform.eulerAngles.x,
                this.transform.eulerAngles.y,
                0
            );
        }

        Object.Instantiate(
            selectedPrefab,
            new Vector3(
                    this.transform.position.x,
                    this.transform.position.y + 0.5f,
                    this.transform.position.z
                ),
            target_rotation
        );
    }
}

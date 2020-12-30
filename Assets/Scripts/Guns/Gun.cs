using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun {

    private GameObject prefab;

    private Transform transform;

    private float cooldown;
    private float cooldownStatus;

    private float minDamages;
    private float maxDamages;

    private SPColor color;

    public Gun(Transform transform, float cooldown, float minDamages, float maxDamages, SPColor color, GameObject prefab) {
        this.cooldown = cooldown;
        this.cooldownStatus = cooldown;

        this.prefab = prefab;

        this.minDamages = minDamages;
        this.maxDamages = maxDamages;

        this.transform = transform;

        this.color = color;
    }

    public bool isReady(float elapsedTime) {
        this.cooldownStatus -= elapsedTime;
        if (this.cooldownStatus <= 0) {
            this.cooldownStatus = this.cooldown;
            return true;
        }
        return false;
    }

    public void shoot() {

        Quaternion targetRotation;
        if (this.transform.eulerAngles.z < -90 || this.transform.eulerAngles.z > 90) {
            targetRotation = Quaternion.Euler(
                this.transform.eulerAngles.x,
                this.transform.eulerAngles.y,
                -180
            );
        } else {
            targetRotation = Quaternion.Euler(
                this.transform.eulerAngles.x,
                this.transform.eulerAngles.y,
                0
            );
        }

        Object.Instantiate(
            this.prefab,
            new Vector3(
                    this.transform.position.x,
                    this.transform.position.y + 0.5f,
                    this.transform.position.z
                ),
            targetRotation
        );
    }
}

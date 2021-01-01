using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun {

    private GameObject prefab;

    private float cooldown;
    private float cooldownStatus;

    private float minDamages;
    private float maxDamages;

    public SPColor color;

    protected Vector2 speed;

    protected Transform transform;

    protected SoundManager soundManager;

    public Gun(SoundManager soundManager, Transform transform, Vector2 speed, float cooldown, float minDamages, float maxDamages, SPColor color, GameObject prefab) {
        this.cooldown = cooldown;
        this.cooldownStatus = cooldown;

        this.prefab = prefab;

        this.minDamages = minDamages;
        this.maxDamages = maxDamages;

        this.transform = transform;

        this.speed = speed;

        this.color = color;

        this.soundManager = soundManager;
    }

    public bool isReady(float elapsedTime) {
        this.cooldownStatus -= elapsedTime;
        if (this.cooldownStatus <= 0) {
            this.cooldownStatus = this.cooldown;
            return true;
        }
        return false;
    }

    public GameObject createProjectile(bool isEnemy) {
        if (!isEnemy) {
            return GameObject.Instantiate(
                this.prefab,
                new Vector3(
                    this.transform.position.x,
                    this.transform.position.y + 0.5f,
                    this.transform.position.z
                ),
                Quaternion.Euler(
                    this.transform.eulerAngles.x,
                    this.transform.eulerAngles.y,
                    0
                )
            );
        } else {
            return GameObject.Instantiate(
                this.prefab,
                new Vector3(
                    this.transform.position.x,
                    this.transform.position.y - 0.5f,
                    this.transform.position.z
                ),
                Quaternion.Euler(
                    this.transform.eulerAngles.x,
                    this.transform.eulerAngles.y,
                    180
                )
            );
        }
    }

    public virtual void shoot(bool isEnemy) {
        GameObject projectile = createProjectile(isEnemy);
        if (!isEnemy) {
            projectile.GetComponent<Rigidbody2D>().velocity = this.speed;
            projectile.AddComponent<triggerProjectile>();
        } else {
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(this.speed.x, -this.speed.y);
            projectile.AddComponent<triggerEnemyProjectile>();
        }
    }
}
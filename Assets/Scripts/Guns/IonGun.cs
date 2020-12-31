using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IonGun : Gun {

    private const float zone = 5f;

    public IonGun(Transform transform, Vector2 speed, float cooldown, float minDamages, float maxDamages, SPColor color, GameObject prefab)
    : base(transform, speed, cooldown, minDamages, maxDamages, color, prefab) {}

    public override void shoot() {
        GameObject projectile = createProjectile();
        if ((this.transform.eulerAngles.z % 360) < 90 || (this.transform.eulerAngles.z % 360) > 270) {
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(this.speed.x, this.speed.y);
        } else {
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(this.speed.x, -this.speed.y);
        }

        projectile = createProjectile();
        if ((this.transform.eulerAngles.z % 360) < 90 || (this.transform.eulerAngles.z % 360) > 270) {
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(-this.speed.x, this.speed.y);
        } else {
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(-this.speed.x, -this.speed.y);
        }

        projectile = createProjectile();
        if ((this.transform.eulerAngles.z % 360) < 90 || (this.transform.eulerAngles.z % 360) > 270) {
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, this.speed.y);
        } else {
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -this.speed.y);
        }

        this.soundManager.playSound(SoundManager.IONGUN);
    }
}

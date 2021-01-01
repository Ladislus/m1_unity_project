using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IonGun : Gun {

    private const float zone = 5f;

    public IonGun(SoundManager soundManager, Transform transform, Vector2 speed, float cooldown, float minDamages, float maxDamages, SPColor color, GameObject prefab)
    : base(soundManager, transform, speed, cooldown, minDamages, maxDamages, color, prefab) {}

    public override void shoot(bool isEnemy) {
        GameObject projectile = createProjectile(isEnemy);
        if (!isEnemy) {
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(this.speed.x, this.speed.y);
            projectile.AddComponent<triggerProjectile>();
        } else {
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(this.speed.x, -this.speed.y);
            projectile.AddComponent<triggerEnemyProjectile>();
        }

        projectile = createProjectile(isEnemy);
        if (!isEnemy) {
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(-this.speed.x, this.speed.y);
            projectile.AddComponent<triggerProjectile>();
        } else {
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(-this.speed.x, -this.speed.y);
            projectile.AddComponent<triggerEnemyProjectile>();
        }

        projectile = createProjectile(isEnemy);
        if (!isEnemy) {
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, this.speed.y);
            projectile.AddComponent<triggerProjectile>();
        } else {
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -this.speed.y);
            projectile.AddComponent<triggerEnemyProjectile>();
        }

        this.soundManager.playSound(Sounds.IONGUN);
    }
}

using UnityEngine;

public class IonGun : Gun {

    public IonGun(Transform transform, Vector2 speed, float cooldown, float minDamages, float maxDamages, SPColor color, GameObject prefab)
    : base(transform, speed, cooldown, minDamages, maxDamages, color, prefab) {}

    // Fonction de tir avec l'arme
    // Création de trois projectiles en cône
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

        SoundManager.Instance.playSound(Sounds.IONGUN);
    }
}

using UnityEngine;

public abstract class Gun {

    // Préfab du projectile créé par l'arme
    private GameObject prefab;

    // Cooldown de tir de l'arme
    private float cooldown;
    private float cooldownStatus;

    // Dommages minimums et maximums
    // de l'arme (pas encore implémenté)
    private float minDamages;
    private float maxDamages;

    // Couleur des projectiles de l'arme
    // (Legacy)
    public SPColor color;

    // Vitesse de déplacement des
    // projectiles de l'arme
    protected Vector2 speed;

    // Position du vaisseau lors du tir
    protected Transform transform;

    public Gun(Transform transform, Vector2 speed, float cooldown, float minDamages, float maxDamages, SPColor color, GameObject prefab) {
        this.cooldown = cooldown;
        this.cooldownStatus = cooldown;

        this.prefab = prefab;

        this.minDamages = minDamages;
        this.maxDamages = maxDamages;

        this.transform = transform;

        this.speed = speed;

        this.color = color;
    }

    // Fonction permettant de savoir si 
    // le cooldown est fini
    public bool isReady(float elapsedTime) {
        // Décrément du cooldown
        this.cooldownStatus -= elapsedTime;
        // Si le cooldown est arrivé à 0 ...
        if (this.cooldownStatus <= 0) {
            // return true & reset le cooldown
            this.cooldownStatus = this.cooldown;
            return true;
        }
        // Sinon, return false
        return false;
    }

    // Fonction de création du projectile
    public GameObject createProjectile(bool isEnemy) {
        // Si l'entité est ennemie ...
        if (!isEnemy) {
            // ... Créer un projectile orienté vers le haut
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
        // ... Sinon, créer un projectile orienté vers le bas
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

    // Fonction de tir
    public virtual void shoot(bool isEnemy) {
        // Création du projectile
        GameObject projectile = createProjectile(isEnemy);
        // Si le projectile est allié ...
        if (!isEnemy) {
            // ... Ajout du déplacement vers le haut
            projectile.GetComponent<Rigidbody2D>().velocity = this.speed;
            // ... Ajout du trigger des projectiles alliés
            // (Les projectiles alliés ne doivent pas collide
            // avec le bouclier/vaisseau du joueur)
            projectile.AddComponent<triggerProjectile>();
        // Sinon ...
        } else {
            // ... Ajout du déplacement vers le bas
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(this.speed.x, -this.speed.y);
            // ... Ajout du trigger des projectiles ennemis
            // (Les projectiles ennemies ne doivent pas collide
            // avec les astéroids et les autres aliens)
            projectile.AddComponent<triggerEnemyProjectile>();
        }
    }
}
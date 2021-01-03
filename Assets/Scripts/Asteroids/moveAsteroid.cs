using UnityEngine;

// Script de déplacement des astéroids
public class moveAsteroid : MonoBehaviour {

    // Vitesse de chite des astéroids
    public float speed;
    // Vitesse minimum & maximum
    public float minSpeed;
    public float maxSpeed;
    // Vitesse de rotation des astéroids
    public float spinSpeed;
    // hauteur maximale à laquelle les
    // astéroids peuvent réapparaitre
    public float respawnField;

    public Rigidbody2D rigidBody;

    public SpriteRenderer spriteRenderer;

    private float height;
    private float width;

    private float top;
    private float bottom;
    private float left;
    private float right;

    private float smooth = 5.0f;

    private bool spinDirection;

    void Start() {

        this.rigidBody.velocity = new Vector2(0, -this.speed);

        this.top = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
        this.bottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        this.left = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        this.right = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        this.height = this.spriteRenderer.bounds.size.y;
        this.width = this.spriteRenderer.bounds.size.x;

        this.selectSpinRotation();
    }

    void Update() { 
        // Continue la rotation de l'astéroid
        this.rotate();

        // Si l'astéroid est sorti de l'écran en base, le fait
        // réapparaitre à une position aléatoire en haut
        if (this.transform.position.y + (this.height / 2) < this.bottom) {
            this.transform.position = new Vector3(
                Random.Range(this.left + (this.width / 2), this.right - (this.width / 2)),
                Random.Range(this.top + (this.height / 2), this.top + (this.height / 2) + this.respawnField),
                this.transform.position.z
            );
            // Selection aléatoire de la nouvelle vitesse
            this.speed = Random.Range(this.minSpeed, this.maxSpeed);
            this.rigidBody.velocity = new Vector2(Random.Range(-0.5f, 0.5f), -this.speed);
            // Selection aléatoire du nouveau sens de rotation 
            this.selectSpinRotation();
        }
    }

    // Fonction de selection aléatoire du sens de rotation (50/50)
    private void selectSpinRotation() {
        float randomized = Random.Range(0f, 1f);
        if (randomized >= 0.5f) this.spinDirection = true;
        else this.spinDirection = false;
    }

    // Fonction de rotation de l'astéroid appliqué chaque frame
    private void rotate() {
        // Si l'astéroid tourne vers la droite,
        // incrémente la rotation
        if (this.spinDirection) {
            Quaternion target = Quaternion.Euler(
                this.transform.eulerAngles.x,
                this.transform.eulerAngles.y,
                this.transform.eulerAngles.z + (this.speed * this.spinSpeed)
            );
            // Créer une transition de 'this.transform.rotation' vers 'target'
            // de manière lisse (en fonction du temps)
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, target, Time.deltaTime * smooth);
        // Si l'astéroid tourne vers la gauche,
        // décrémente la rotation
        } else {
            Quaternion target = Quaternion.Euler(
                this.transform.eulerAngles.x,
                this.transform.eulerAngles.y,
                this.transform.eulerAngles.z - (this.speed * this.spinSpeed)
            );
            // Créer une transition de 'this.transform.rotation' vers 'target'
            // de manière lisse (en fonction du temps)
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, target, Time.deltaTime * smooth);
        }
    }
}

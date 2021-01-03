using UnityEngine;

// Script de gestion du déplacement du vaisseau
public class movePlayer : MonoBehaviour {

    // Vitesse de déplacement du vaisseau
    public float speed;
    // Angle maximum de rotation
    public float tiltAngle;

    private float left;
    private float right;
    private float width;

    // Coeficient permettant une rotation lisse
    private float smooth = 5.0f;

    public Rigidbody2D rigidBody;
    public SpriteRenderer spriteRenderer;

    void Start() {
        this.left = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        this.right = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        this.width = this.spriteRenderer.bounds.size.x;
    }

    void Update() {
        float moveHorizontal = 0f;
        // Si le joueur touche l'écran avec au moins un doigt ...
        if (Input.touchCount > 0) {
            // ... Récupère la position du premier doigt (en coordonnée du monde)
            float horizontalPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).x;
            // ... Récupère la différence de position X entre le doigt et le vaisseau,
            // normalisé entre [-1; 1] (Permet de remplacer le Input.GetAxis("Horizontal)) 
            moveHorizontal = Mathf.Clamp(-this.transform.position.x + horizontalPosition, -1f, 1f);
        }

        // Applique le déplacement sur le vaisseau
        this.rigidBody.velocity = new Vector2(this.speed * moveHorizontal, 0);

        // Création d'un Quaternion pour la rotation du vaisseau
        Quaternion target = Quaternion.Euler(
            this.transform.eulerAngles.x,
            this.transform.eulerAngles.y,
            // Rotation vers les cotés, plus ou moins
            // grand en fonction de la vitesse du vaisseau
            0 - (moveHorizontal * this.tiltAngle)
        );

        // Créer une transition de 'this.transform.rotation' vers 'target'
        // de manière lisse (en fonction du temps)
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, target, Time.deltaTime * smooth);

        // Empêche le vaisseau de sortir à gauche
        if (this.transform.position.x - (this.width / 2) < this.left) {
            this.transform.position = new Vector3(
                this.left + (this.width / 2),
                this.transform.position.y,
                this.transform.position.z
            );
        // Empêche le vaisseau de sortir à droite
        } else if (this.transform.position.x + (this.width / 2) > this.right) {
            this.transform.position = new Vector3(
                this.right - (this.width / 2),
                this.transform.position.y,
                this.transform.position.z
            );
        }
    }
}

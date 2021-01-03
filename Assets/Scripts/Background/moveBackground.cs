using UnityEngine;

public class moveBackground : MonoBehaviour {

    // Transform du GameObject de fond
    // dérrière lequel réapparaitre    
    public Transform respawn;

    public Rigidbody2D rigidBody;
    public SpriteRenderer spriteRenderer;

    // Vitesse de défilement du fond
    public float speed;
    
    private float height;
    
    private float bottom;

    void Start() {
        this.rigidBody.velocity = new Vector2(0, -this.speed);

        this.bottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;

        this.height = this.spriteRenderer.bounds.size.y;
    }


    void Update() {
        // Si le fond est sorti de l'écran, le fait réapparaitre
        // en haut, dérrière le fond 'respawn'
        if (this.transform.position.y + (this.height / 2) < this.bottom) {
            this.transform.position = new Vector3(
                this.transform.position.x,
                this.respawn.transform.position.y + (this.height) - 0.1f,
                this.transform.position.z
            );
        }
    }
}

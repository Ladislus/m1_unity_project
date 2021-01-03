using UnityEngine;

// Script permettant de supprimer les
// projectiles sortis de la zone de jeu
public class cleanProjectile : MonoBehaviour {
    
    public SpriteRenderer spriteRenderer;

    // Hauteur à laquelle les projectiles
    // doivent être détruit s'ils la dépassent
    public float topCleanZone;

    private float height;
    private float width;

    private float top;
    private float bottom;
    private float left;
    private float right;

    void Start() {
        this.top = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
        this.bottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        this.left = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        this.right = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        this.height = this.spriteRenderer.bounds.size.y;
        this.width = this.spriteRenderer.bounds.size.x;
    }

    void Update() {
        // Si les projectiles sortent sur les cotés, on les détruit
        if ((this.transform.position.x + (this.width / 2) < left) ||
            (this.transform.position.x - (this.width / 2) > right)) {
                Destroy(this.gameObject);
            }
        // Si les projectiles sortent en bas, on les détruit
        // Pour la limite haute, il ne faut pas détruire les projectiles
        // des ennemis qui ne sont pas encore dans l'écran
        // Si topCleanZone est inférieur à la zone d'apparition des aliens,
        // leurs projectiles seront instantannément détruit
        if ((this.transform.position.y + (this.height / 2) < bottom) ||
            (this.transform.position.y - (this.width / 2) > top + this.topCleanZone)) {
                Destroy(this.gameObject);
            }
    }
}

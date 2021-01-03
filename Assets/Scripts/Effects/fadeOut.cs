using UnityEngine;

public class fadeOut : MonoBehaviour {
    
    // Vitesse de disparition
    // du GameObject
    public float fadeSpeed = 5;

    public SpriteRenderer spriteRenderer;

    void Update() {
        // Incrémente la transparence du sprite
        Color c = this.spriteRenderer.color;
        c.a -= this.fadeSpeed * Time.deltaTime;
        this.spriteRenderer.color = c;
        // Lors que l'objet a completement disparu, le détruit 
        if (this.spriteRenderer.color.a < 0) Destroy(this.gameObject);
    }
}

using UnityEngine;

// Script de gestion de la couleur du bouclier
public class colorShield : MonoBehaviour {

    public Sprite blue_shield;
    public Sprite green_sprite;

    public SpriteRenderer spriteRenderer;

    // Couleur du bouclier
    public SPColor color = SPColor.Blue;

    void Update() {
        // Si le joueur touche l'écran avec deux doigts,
        // change la couleur du bouclier(première frame du touché)
        if (Input.touchCount > 1 && Input.GetTouch(1).phase == TouchPhase.Began) {
            if (this.color == SPColor.Blue) {
                this.color = SPColor.Green;
                this.spriteRenderer.sprite = this.green_sprite;
            } else {
                this.color = SPColor.Blue;
                this.spriteRenderer.sprite = blue_shield;
            }
        }
    }
}

using UnityEngine;

// Script de gestion de la vie du bouclier
public class lifeShield : MonoBehaviour {
    
    public fadeOut fadeOutScript;
    // Animator du vaisseau permettant de changer
    // l'animation du vaisseau (apparition de dégats
    // sur le vaisseau)
    public Animator shipAnimator;
    public Collider2D shieldCollider;
    // Collider du vaisseau
    public Collider2D shipCollider;

    // Nombre de points de vie du bouclier
    private int lifePoints = 3;

    public void hit() {
        // Si le bouclier n'a plus de vie, le collider est désactivé
        // et le GameObject detruit, et le collider du vaisseau est activé
        if (this.lifePoints == 0) {
            this.shieldCollider.enabled = false;
            this.fadeOutScript.enabled = true;
            this.shipCollider.enabled = true;
        } else {
            // Changement du paramètre de l'animator du vaisseau
            // pour changer l'animation
            this.shipAnimator.SetInteger("Life", --this.lifePoints);
        }
        // Son de dommage
        SoundManager.Instance.playSound(Sounds.DAMAGE);
    }
}

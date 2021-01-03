using UnityEngine;

// Script de gestion de la vie du vaisseau
public class lifeShip : MonoBehaviour {

    // Fader permettant le changement de scene
    // lors de la destruction du vaisseau
    public LevelFader fader;

    public Collider2D shipCollider;
    public fadeOut fadeOutScript;

    public void hit() {
        // Désactivation du collider, fadeout & destruction de l'objet,
        // son et fade vers l'affichage des scores finaux
        this.shipCollider.enabled = false;
        this.fadeOutScript.enabled = true;
        SoundManager.Instance.playSound(Sounds.EXPLOSION);
        this.fader.fadeOutToLevel("End");
    }
}

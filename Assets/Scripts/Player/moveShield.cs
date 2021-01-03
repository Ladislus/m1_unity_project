using UnityEngine;

// Script de déplacement du bouclier
public class moveShield : MonoBehaviour {

    // Transform du vaisseau
    public Transform shipTransform;

    void Update() {
        // Déplace le bouclier au même endroit que le vaisseau
        // (légèrement décalé sur vers le haut)
        this.transform.position = new Vector3(
            shipTransform.position.x,
            shipTransform.position.y + 0.2f,
            shipTransform.position.z
        );
        // Applique la même rotation que celle du vaisseau
        this.transform.rotation = this.shipTransform.rotation;
    }
}

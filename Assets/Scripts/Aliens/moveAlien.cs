using UnityEngine;

// Script de déplacement des aliens
public class moveAlien : MonoBehaviour {

    // Vitesse de déplacement des aliens 
    public Vector2 speed;

    public Rigidbody2D rigidBody;

    void Start() {
        this.rigidBody.velocity = new Vector2(this.speed.x, -this.speed.y);
    }
}

using UnityEngine;

// Script de déplacement des powerups
public class movePowerup : MonoBehaviour {

    // La vitesse de chute des powerups
    public float speed;

    public Rigidbody2D rigidBody;

    void Start() {
        this.rigidBody.velocity = new Vector2(0, -this.speed);
    }
}

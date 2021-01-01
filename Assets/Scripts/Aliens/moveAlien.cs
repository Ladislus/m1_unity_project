using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAlien : MonoBehaviour {

    public Vector2 speed;

    public Rigidbody2D rigidBody;

    void Start() {
        this.rigidBody.velocity = new Vector2(this.speed.x, -this.speed.y);
    }
}

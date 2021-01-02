using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePowerup : MonoBehaviour {

    public float speed;

    public Rigidbody2D rigidBody;

    void Start() {
        this.rigidBody.velocity = new Vector2(0, -this.speed);
    }
}

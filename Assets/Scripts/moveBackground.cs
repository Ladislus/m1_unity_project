using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBackground : MonoBehaviour {
    
    public Transform respawn;

    public float speed;
    
    private float height;
    private float bottom;

    void Start() {
        
        GetComponent<RigidBody2D>().velocity = new Vector2(0, -this.speed);

        this.bottom = Camera.main.ViewToWorldPoint(new Vector(0, 0, 0)).y;
        this.height = GetComponent<SpriteRenderer>().bounds.size.y;
    }


    void Update()
    {
        
    }
}

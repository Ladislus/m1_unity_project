using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBackground : MonoBehaviour {
    
    public Transform respawn;

    public float speed;
    
    private float height;
    private float bottom;

    void Start() {
        
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, -this.speed);

        this.bottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        this.height = GetComponent<SpriteRenderer>().bounds.size.y;
    }


    void Update()
    {
        if (this.transform.position.y + (this.height / 2) < this.bottom) {
            this.transform.position = new Vector3(
                this.transform.position.x,
                this.respawn.transform.position.y + (this.height),
                this.transform.position.z
            );
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBullet : MonoBehaviour {
    
    public float speed;

    void Start() {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, this.speed);    
    }
}

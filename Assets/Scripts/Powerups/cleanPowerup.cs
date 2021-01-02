using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cleanPowerup : MonoBehaviour {

    public SpriteRenderer spriteRenderer;

    private float bottom;
    private float height;
    
    void Start() {
        this.bottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;

        this.height = this.spriteRenderer.bounds.size.y;        
    }

    void Update() {
       if (this.transform.position.y + (this.height / 2) < bottom) {
           Destroy(this.gameObject);
       }
    }
}

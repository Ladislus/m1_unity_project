using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cleanProjectile : MonoBehaviour {
    private float height;
    private float width;

    private float top;
    private float bottom;
    private float left;
    private float right;

    void Start() {
        this.top = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
        this.bottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        this.left = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        this.right = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        this.height = GetComponent<SpriteRenderer>().bounds.size.y;
        this.width = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update() {
        if ((this.transform.position.x + (this.width / 2) < left) ||
            (this.transform.position.x - (this.width / 2) > right)) {
                Destroy(this.gameObject);
            }
        if ((this.transform.position.y + (this.height / 2) < bottom) ||
            (this.transform.position.y - (this.width / 2) > top)) {
                Destroy(this.gameObject);
            }
    }
}

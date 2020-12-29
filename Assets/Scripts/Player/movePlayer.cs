using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour {

    public float speed;

    private float left;
    private float right;
    private float width;

    private Rigidbody2D rb;

    void Start() {
        this.left = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        this.right = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        this.width = GetComponent<SpriteRenderer>().bounds.size.x;

        this.rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        this.rb.velocity = new Vector2(this.speed * Input.GetAxis("Horizontal"), 0);

        if (this.transform.position.x - (this.width / 2) < this.left) {
            this.transform.position = new Vector3(
                this.left + (this.width / 2),
                this.transform.position.y,
                this.transform.position.z
            );
        } else if (this.transform.position.x + (this.width / 2) > this.right) {
            this.transform.position = new Vector3(
                this.right - (this.width / 2),
                this.transform.position.y,
                this.transform.position.z
            );
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour {

    public float speed;
    public float tiltAngle;

    private float left;
    private float right;
    private float width;

    private float smooth = 5.0f;

    public Rigidbody2D rigidBody;
    public SpriteRenderer spriteRenderer;

    void Start() {
        this.left = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        this.right = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        this.width = this.spriteRenderer.bounds.size.x;
    }

    // Update is called once per frame
    void Update() {
        this.rigidBody.velocity = new Vector2(this.speed * Input.GetAxis("Horizontal"), 0);

        Quaternion target = Quaternion.Euler(
            this.transform.eulerAngles.x,
            this.transform.eulerAngles.y,
            0 - (Input.GetAxis("Horizontal") * this.tiltAngle)
        );

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, target, Time.deltaTime * smooth);

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

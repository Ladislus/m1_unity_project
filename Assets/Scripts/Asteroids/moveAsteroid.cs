using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAsteroid : MonoBehaviour {

    public float speed;
    public float minSpeed;
    public float maxSpeed;
    public float spinSpeed;
    public float respawnField;

    public Rigidbody2D rigidBody;

    private float height;
    private float width;

    private float top;
    private float bottom;
    private float left;
    private float right;

    private float smooth = 5.0f;

    private bool spinDirection;

    void Start() {

        this.rigidBody.velocity = new Vector2(0, -this.speed);

        this.top = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
        this.bottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        this.left = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        this.right = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        this.height = GetComponent<SpriteRenderer>().bounds.size.y;
        this.width = GetComponent<SpriteRenderer>().bounds.size.x;

        this.selectSpinRotation();
    }


    void Update() { 

        this.rotate();

        if (this.transform.position.y + (this.height / 2) < this.bottom) {
            this.transform.position = new Vector3(
                Random.Range(this.left + (this.width / 2), this.right - (this.width / 2)),
                Random.Range(this.top + (this.height / 2), this.top + (this.height / 2) + this.respawnField),
                this.transform.position.z
            );

            this.speed = Random.Range(this.minSpeed, this.maxSpeed);
            this.rigidBody.velocity = new Vector2(0, -this.speed);

            this.selectSpinRotation();
        }
    }

    private void selectSpinRotation() {
        float randomized = Random.Range(0f, 1f);
        if (randomized >= 0.5f) this.spinDirection = true;
        else this.spinDirection = false;
    }

    private void rotate() {
        if (this.spinDirection) {
            Quaternion target = Quaternion.Euler(
                this.transform.eulerAngles.x,
                this.transform.eulerAngles.y,
                this.transform.eulerAngles.z + (this.speed * this.spinSpeed)
            );

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, target, Time.deltaTime * smooth);
        } else {
            Quaternion target = Quaternion.Euler(
                this.transform.eulerAngles.x,
                this.transform.eulerAngles.y,
                this.transform.eulerAngles.z - (this.speed * this.spinSpeed)
            );

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, target, Time.deltaTime * smooth);
        }
    }
}

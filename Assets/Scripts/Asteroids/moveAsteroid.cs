using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAsteroid : MonoBehaviour {

    public float speed;
    public float min_speed;
    public float max_speed;
    public float spin_speed;
    public float respawn_field;

    public Rigidbody2D rb;

    private float height;
    private float width;

    private float top;
    private float bottom;
    private float left;
    private float right;

    private float smooth = 5.0f;

    private bool spin_direction;

    void Start() {

        this.rb.velocity = new Vector2(0, -this.speed);

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
                Random.Range(this.top + (this.height / 2), this.top + (this.height / 2) + this.respawn_field),
                this.transform.position.z
            );

            this.speed = Random.Range(this.min_speed, this.max_speed);
            this.rb.velocity = new Vector2(0, -this.speed);

            this.selectSpinRotation();
        }
    }

    private void selectSpinRotation() {
        float randomized = Random.Range(0f, 1f);
        if (randomized >= 0.5f) this.spin_direction = true;
        else this.spin_direction = false;
    }

    private void rotate() {
        if (this.spin_direction) {
            Quaternion target = Quaternion.Euler(
                this.transform.eulerAngles.x,
                this.transform.eulerAngles.y,
                this.transform.eulerAngles.z + (this.speed * this.spin_speed)
            );

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, target, Time.deltaTime * smooth);
        } else {
            Quaternion target = Quaternion.Euler(
                this.transform.eulerAngles.x,
                this.transform.eulerAngles.y,
                this.transform.eulerAngles.z - (this.speed * this.spin_speed)
            );

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, target, Time.deltaTime * smooth);
        }
    }
}

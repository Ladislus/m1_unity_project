using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnAlien : MonoBehaviour {

    public float respawnField;

    public SpriteRenderer spriteRenderer;

    private float top;
    private float bottom;
    private float left;
    private float right;

    private float height;
    private float width;

    void Awake() {
        this.top = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
        this.bottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        this.left = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        this.right = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        this.width = this.spriteRenderer.bounds.size.x;
        this.height = this.spriteRenderer.bounds.size.y;
    }

    void Update() {
        if (this.transform.position.y + (this.height / 2) < this.bottom) {
            this.transform.position = new Vector3(
                Random.Range(this.left + (this.width / 2), this.right - (this.width / 2)),
                Random.Range(this.top + (this.height / 2), this.top + (this.height / 2) + this.respawnField),
                this.transform.position.z
            );
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeOut : MonoBehaviour {
    public float fade_speed;

    private SpriteRenderer sr;

    void Start() {
        this.sr = GetComponent<SpriteRenderer>();
    }

    void Update() {
        Color c = this.sr.color;
        c.a -= this.fade_speed;
        this.sr.color = c;
        if (this.sr.color.a < 0) Destroy(this.gameObject);
    }
}

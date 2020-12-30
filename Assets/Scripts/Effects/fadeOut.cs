using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeOut : MonoBehaviour {
    
    public float fade_speed = 5;

    public SpriteRenderer sr;

    void Update() {
        Color c = this.sr.color;
        c.a -= this.fade_speed * Time.deltaTime;
        this.sr.color = c;
        if (this.sr.color.a < 0) Destroy(this.gameObject);
    }
}

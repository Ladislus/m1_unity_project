using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeOut : MonoBehaviour {
    
    public float fadeSpeed = 5;

    public SpriteRenderer spriteRenderer;

    void Update() {
        Color c = this.spriteRenderer.color;
        c.a -= this.fadeSpeed * Time.deltaTime;
        this.spriteRenderer.color = c;
        if (this.spriteRenderer.color.a < 0) Destroy(this.gameObject);
    }
}

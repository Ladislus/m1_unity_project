using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class lifeAsteroid : MonoBehaviour {

    public fadeOut fadeOutScript;
    public Collider2D collider;
    public Rigidbody2D rigidbody;

    public UnityEvent asteroidEvent;

    public void hit() {
        this.collider.enabled = false;
        this.rigidbody.velocity = Vector2.zero;
        this.fadeOutScript.enabled = true;
        this.asteroidEvent.Invoke();
    }
}

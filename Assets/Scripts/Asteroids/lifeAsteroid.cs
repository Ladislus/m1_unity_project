using UnityEngine.Events;
using UnityEngine;

// Script de gestion de la vie des astéroids
public class lifeAsteroid : MonoBehaviour {

    public fadeOut fadeOutScript;
    public Collider2D asteroidCollider;
    public Rigidbody2D rigidBody;

    public UnityEvent asteroidEvent;

    public void hit() {
        // Désactivation du collider, immobilisation
        // de l'astéroid, puis fadeOut
        this.asteroidCollider.enabled = false;
        this.rigidBody.velocity = Vector2.zero;
        this.fadeOutScript.enabled = true;
        if (this.asteroidEvent != null) this.asteroidEvent.Invoke();
        else Debug.LogWarning("AsteroidEvent is null");
    }
}

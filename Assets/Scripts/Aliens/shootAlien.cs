using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootAlien : MonoBehaviour {

    private Gun gun;

    void Start() {
        Guns randomGun = (Guns) Random.Range(0, System.Enum.GetNames(typeof(Guns)).Length);

        SPColor randomColor;
        if (Random.Range(0f, 1f) < 0.5f) { randomColor = SPColor.Green; }
        else randomColor = SPColor.Blue;

        this.gun = GunFactory.Instance.make(randomGun, this.transform, randomColor);
    }

    void Update() {
        if (this.gun.isReady(Time.deltaTime)) {
            this.gun.shoot(true);
        }
    }
}

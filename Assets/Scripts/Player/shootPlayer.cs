using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootPlayer : MonoBehaviour {

    private Gun gun;

    void Start() {
        this.gun = GunFactory.Instance.make(Guns.MACHINEGUN, this.transform, SPColor.Blue);
    }

    void Update() {
        if (this.gun.isReady(Time.deltaTime)) {
            this.gun.shoot(false);
        }
    }

    public void setGun(Guns newGun) {
        SPColor randomColor;
        if (Random.Range(0f, 1f) < 0.5f) randomColor = SPColor.Blue;
        else randomColor = SPColor.Green;

        this.gun = GunFactory.Instance.make(newGun, this.transform, randomColor);
    }
}

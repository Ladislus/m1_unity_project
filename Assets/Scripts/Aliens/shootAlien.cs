using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootAlien : MonoBehaviour {

    private GunFactory gunFactory;

    private Gun gun;

    void Awake() {
        this.gunFactory = GameObject.FindWithTag("GameController").GetComponent<GunFactory>();

        Guns randomGun = (Guns) Random.Range(0, System.Enum.GetNames(typeof(Guns)).Length);
        SPColor randomColor = (SPColor) Random.Range(0, System.Enum.GetNames(typeof(SPColor)).Length);

        this.gun = this.gunFactory.make(randomGun, this.transform, randomColor);
    }

    void Update() {
        if (this.gun.isReady(Time.deltaTime)) {
            this.gun.shoot(true);
        }
    }
}

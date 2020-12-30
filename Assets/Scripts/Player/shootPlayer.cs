using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootPlayer : MonoBehaviour {

    private GunFactory gunFactory;

    private Gun gun;

    void Awake() {
        this.gunFactory = GameObject.FindWithTag("GameController").GetComponent<GunFactory>();
    }

    void Start() {
        this.gun = this.gunFactory.make(GunFactory.MACHINEGUN, this.transform, SPColor.Blue);
    }

    void Update() {
        if (this.gun.isReady(Time.deltaTime)) {
            this.gun.shoot();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootPlayer : MonoBehaviour {

    public GameObject blueOrb;
    public GameObject greenOrb;
    public GameObject blueBullet;
    public GameObject greenBullet;
    public GameObject blueLaser;
    public GameObject greenLaser;

    private Gun gun;

    void Start() {
        this.gun = GunFactory.make(GunFactory.MACHINEGUN, this.transform, SPColor.Blue, this.blueBullet, this.greenBullet);
    }

    void Update() {
        this.gun.isReady(Time.deltaTime);
    }
}

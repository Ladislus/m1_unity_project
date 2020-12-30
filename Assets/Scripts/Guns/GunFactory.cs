using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFactory : MonoBehaviour {

    public GameObject blueOrb;
    public GameObject greenOrb;
    public GameObject blueBullet;
    public GameObject greenBullet;
    public GameObject blueLaser;
    public GameObject greenLaser;

    public const int MACHINEGUN = 0;
    public const int LASERGUN = 1;
    public const int IONGUN = 2;

    public Gun make(int gunType, Transform transform, SPColor color) {
        switch (gunType) {
            case MACHINEGUN:
                if (color == SPColor.Blue) return getMG(transform, color, this.blueBullet);
                return getMG(transform, color, this.greenBullet);
            case LASERGUN:
                if (color == SPColor.Blue) return getLG(transform, color, this.blueLaser);
                return getLG(transform, color, this.greenLaser);
            default:
            case IONGUN:
                if (color == SPColor.Blue) return getIG(transform, color, this.blueOrb);
                return getIG(transform, color, this.greenOrb);
        }
    }

    private MachineGun getMG(Transform transform, SPColor color, GameObject prefab) {
        return new MachineGun(transform, 0.3f, 1.0f, 1.5f, color, prefab);
    }

    private LaserGun getLG(Transform transform, SPColor color, GameObject prefab) {
        return new LaserGun(transform, 0.6f, 1.2f, 1.7f, color, prefab);
    }

    private IonGun getIG(Transform transform, SPColor color, GameObject prefab) {
        return new IonGun(transform, 0.15f, 0.8f, 0.1f, color, prefab);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Guns { MACHINEGUN, LASERGUN, IONGUN }

public class GunFactory : MonoBehaviour {

    public GameObject blueOrb;
    public GameObject greenOrb;
    public GameObject blueBullet;
    public GameObject greenBullet;
    public GameObject blueLaser;
    public GameObject greenLaser;

    private SoundManager soundManager;

    void Awake() {
        this.soundManager = this.gameObject.GetComponent<SoundManager>();
    }

    public Gun make(Guns gunType, Transform transform, SPColor color) {
        switch (gunType) {
            case Guns.MACHINEGUN:
                if (color == SPColor.Blue) return getMG(transform, color, this.blueBullet);
                return getMG(transform, color, this.greenBullet);
            case Guns.LASERGUN:
                if (color == SPColor.Blue) return getLG(transform, color, this.blueLaser);
                return getLG(transform, color, this.greenLaser);
            default:
            case Guns.IONGUN:
                if (color == SPColor.Blue) return getIG(transform, color, this.blueOrb);
                return getIG(transform, color, this.greenOrb);
        }
    }

    private MachineGun getMG(Transform transform, SPColor color, GameObject prefab) {
        return new MachineGun(this.soundManager, transform, new Vector2(0f, 10f), 0.5f, 1.0f, 1.5f, color, prefab);
    }

    private LaserGun getLG(Transform transform, SPColor color, GameObject prefab) {
        return new LaserGun(this.soundManager, transform, new Vector2(0f, 20f), 0.7f, 1.2f, 1.7f, color, prefab);
    }

    private IonGun getIG(Transform transform, SPColor color, GameObject prefab) {
        return new IonGun(this.soundManager, transform, new Vector2(2f, 5f), 0.4f, 0.8f, 0.1f, color, prefab);
    }
}

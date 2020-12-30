using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFactory {

    public const int MACHINEGUN = 0;
    public const int LASERGUN = 1;
    public const int IONGUN = 2;

    public static Gun make(int gunType, Transform transform, SPColor color, GameObject bluePrefab, GameObject greenPrefab) {
        switch (gunType) {
            case MACHINEGUN:
                return getMG(transform, color, bluePrefab, greenPrefab);
            case LASERGUN:
                return getLG(transform, color, bluePrefab, greenPrefab);
            case IONGUN:
                return getIG(transform, color, bluePrefab, greenPrefab);
            default:
                return getMG(transform, color, bluePrefab, greenPrefab);
        }
    }

    private static MachineGun getMG(Transform transform, SPColor color, GameObject bluePrefab, GameObject greenPrefab) {
        return new MachineGun(transform, 0.3f, 1.0f, 1.5f, color, bluePrefab, greenPrefab);
    }

    private static LaserGun getLG(Transform transform, SPColor color, GameObject bluePrefab, GameObject greenPrefab) {
        return new LaserGun(transform, 0.6f, 1.2f, 1.7f, color, bluePrefab, greenPrefab);
    }

    private static IonGun getIG(Transform transform, SPColor color, GameObject bluePrefab, GameObject greenPrefab) {
        return new IonGun(transform, 0.15f, 0.8f, 0.1f, color, bluePrefab, greenPrefab);
    }
}

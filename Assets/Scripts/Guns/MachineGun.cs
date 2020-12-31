using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Gun {
    public MachineGun(Transform transform, Vector2 speed, float cooldown, float minDamages, float maxDamages, SPColor color, GameObject prefab)
    : base(transform, speed, cooldown, minDamages, maxDamages, color, prefab) {}

    public override void shoot() {
        base.shoot();
        this.soundManager.playSound(SoundManager.MACHINEGUN);
    }
}

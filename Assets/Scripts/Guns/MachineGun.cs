using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Gun {
    public MachineGun(SoundManager soundManager, Transform transform, Vector2 speed, float cooldown, float minDamages, float maxDamages, SPColor color, GameObject prefab)
    : base(soundManager, transform, speed, cooldown, minDamages, maxDamages, color, prefab) {}

    public override void shoot(bool isEnemy) {
        base.shoot(isEnemy);
        this.soundManager.playSound(Sounds.MACHINEGUN);
    }
}

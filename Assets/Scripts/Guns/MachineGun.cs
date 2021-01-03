using UnityEngine;

public class MachineGun : Gun {
    public MachineGun(Transform transform, Vector2 speed, float cooldown, float minDamages, float maxDamages, SPColor color, GameObject prefab)
    : base(transform, speed, cooldown, minDamages, maxDamages, color, prefab) {}

    public override void shoot(bool isEnemy) {
        base.shoot(isEnemy);
        SoundManager.Instance.playSound(Sounds.MACHINEGUN);
    }
}

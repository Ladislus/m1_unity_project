using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Gun {
    public MachineGun(Transform transform, float cooldown, float minDamages, float maxDamages, SPColor color, GameObject prefab)
    : base(transform, cooldown, minDamages, maxDamages, color, prefab) {}
}

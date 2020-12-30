using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Gun {
    public MachineGun(Transform transform, float cooldown, float min_damages, float max_damages, SPColor color, GameObject bluePrefab, GameObject greenPrefab)
    : base(transform, cooldown, min_damages, max_damages, color, bluePrefab, greenPrefab) {}
}

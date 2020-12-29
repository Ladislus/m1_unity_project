using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Gun {

    public MachineGun(Transform transform, SPColor color) : base(transform, 0.3f, 1.0f, 1.3f) {
        this.color = color;
    }

    public override void shoot() {
        GameObject.Instantiate(
            Resources.Load("Projectiles/Bullet"),
            new Vector3(
                    this.transform.position.x,
                    this.transform.position.y + 1.0f,
                    this.transform.position.z
                ),
            Quaternion.identity
        );
    }
}

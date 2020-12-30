using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Gun {

    public MachineGun(Transform transform, SPColor color, GameObject bluePrefab, GameObject greenPrefab) : base(transform, 0.3f, color, bluePrefab, greenPrefab) {}

    public override void shoot() {

        GameObject selectedPrefab;
        if (this.color == SPColor.Blue) selectedPrefab = this.bluePrefab;
        else selectedPrefab = this.greenPrefab;

        Quaternion target_rotation;
        if (this.transform.eulerAngles.z < -90 || this.transform.eulerAngles.z > 90) {
            target_rotation = Quaternion.Euler(
                this.transform.eulerAngles.x,
                this.transform.eulerAngles.y,
                -180
            );
        } else {
            target_rotation = Quaternion.Euler(
                this.transform.eulerAngles.x,
                this.transform.eulerAngles.y,
                0
            );
        }

        Object.Instantiate(
            selectedPrefab,
            new Vector3(
                    this.transform.position.x,
                    this.transform.position.y + 0.5f,
                    this.transform.position.z
                ),
            target_rotation
            //Quaternion.identity
        );
    }
}

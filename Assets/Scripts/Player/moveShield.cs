using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveShield : MonoBehaviour {

    public Transform ship;

    void Update() {
        this.transform.position = new Vector3(
            ship.position.x,
            ship.position.y + 0.2f,
            ship.position.z
        );

        this.transform.rotation = this.ship.rotation;
    }
}

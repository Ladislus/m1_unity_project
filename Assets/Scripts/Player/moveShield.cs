using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveShield : MonoBehaviour {

    public Transform shipTransform;

    void Update() {
        this.transform.position = new Vector3(
            shipTransform.position.x,
            shipTransform.position.y + 0.2f,
            shipTransform.position.z
        );

        this.transform.rotation = this.shipTransform.rotation;
    }
}

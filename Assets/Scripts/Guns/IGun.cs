using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGun : MonoBehaviour {
    void cooldown();
    void shoot();
}

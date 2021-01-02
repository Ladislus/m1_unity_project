using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndManager : MonoBehaviour {
    void Awake() {
        ScoreManager.Instance.endGame();
    }
}

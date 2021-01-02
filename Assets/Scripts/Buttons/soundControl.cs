using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundControl : MonoBehaviour {
    public void Onclick() {
        SoundManager.Instance.toggleMusic();
    }
}

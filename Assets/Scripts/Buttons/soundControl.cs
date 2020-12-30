using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundControl : MonoBehaviour {

    public GameObject gameManager;

    public void Onclick() {
        this.gameManager.GetComponent<SoundManager>().toggleMusic();
    }
}

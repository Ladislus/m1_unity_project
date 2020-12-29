using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    private static SoundManager _instance;

    public AudioClip music;

    public AudioClip click;

    public AudioClip damage;
    public AudioClip explosion1;
    public AudioClip explosion2;
    public AudioClip explosion3;
    public AudioClip explosion4;
    public AudioClip explosion5;
    public AudioClip explosion6;
    public AudioClip explosion7;

    public AudioClip powerup;

    public AudioClip machinegun;
    public AudioClip lasergun;
    public AudioClip iongun;

    void Awake() {
        if (_instance == null) { 
            _instance = this;
            DontDestroyOnLoad(this.gameObject); 
        }
        else Destroy(this); 
    }
}

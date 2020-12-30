using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    private static SoundManager _instance;

    public AudioClip music;

    public AudioClip click;

    public AudioClip damage;
    public List<AudioClip> explosions;

    public AudioClip powerup;

    public AudioClip machinegun;
    public AudioClip lasergun;
    public AudioClip iongun;

    public AudioSource music_source;

    void Awake() {
        if (_instance == null) { 
            _instance = this;
            DontDestroyOnLoad(this.gameObject); 
        } else Destroy(this);
    }

    private void playClip(AudioClip clip) {
        AudioSource.PlayClipAtPoint(clip, new Vector3(0, 0, 0));
    }

    public void toggleMusic() {
        this.music_source.mute = !this.music_source.mute;
    }

    public void playClick() {
        playClip(this.click);
    }

    public void playDamage() {
        playClip(this.damage);
    }
}

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

    private AudioSource music_source;

    void Awake() {
        if (_instance == null) { 
            _instance = this;
            DontDestroyOnLoad(this.gameObject); 
        } else Destroy(this);

        this.music_source = this.gameObject.AddComponent<AudioSource>() as AudioSource;
        this.music_source.transform.position = new Vector3(0, 0, 0);
        this.music_source.clip = this.music;
        this.music_source.loop = true;
        this.music_source.Play();
    }

    private void playClip(AudioClip clip) {
        AudioSource.PlayClipAtPoint(clip, new Vector3(0, 0, 0));
    }

    public void toggleMusic() {
        if (this.music_source.volume > 0.5f) this.music_source.volume = 0.0f;
        else this.music_source.volume = 1.0f;
    }

    public void playClick() {
        playClip(this.click);
    }

    public void playDamage() {
        playClip(this.damage);
    }
}

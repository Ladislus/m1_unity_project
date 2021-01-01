using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sounds { CLICK, DAMAGE, EXPLOSION, POWERUP, MACHINEGUN, LASERGUN, IONGUN }

public class SoundManager : MonoBehaviour {

    private static SoundManager _instance;

    public AudioClip music;

    public AudioClip click;

    public AudioClip damage;
    public List<AudioClip> explosions;

    public AudioClip powerUp;

    public AudioClip machineGun;
    public AudioClip laserGun;
    public AudioClip ionGun;

    public AudioSource musicSource;

    void Awake() {
        if (_instance == null) { 
            _instance = this;
            DontDestroyOnLoad(this.gameObject); 
        } else Destroy(this);
    }

    private void playClip(AudioClip clip) {
        AudioSource.PlayClipAtPoint(clip, Vector3.zero);
    }

    public void toggleMusic() {
        this.musicSource.mute = !this.musicSource.mute;
    }

    public void playSound(Sounds sound) {
        switch (sound) {
            case Sounds.CLICK:
                playClip(this.click);
                break;
            case Sounds.DAMAGE:
                playClip(this.damage);
                break;
            case Sounds.EXPLOSION:
                int selected = Random.Range(0, this.explosions.Count - 1);
                playClip(this.explosions[selected]);
                break;
            case Sounds.POWERUP:
                playClip(this.powerUp);
                break;
            case Sounds.MACHINEGUN:
                playClip(this.machineGun);
                break;
            case Sounds.LASERGUN:
                playClip(this.laserGun);
                break;
            default:
            case Sounds.IONGUN:
                playClip(this.ionGun);
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    private static SoundManager _instance;

    public AudioClip music;

    public const int CLICK = 0;
    public AudioClip click;

    public const int DAMAGE = 1;
    public AudioClip damage;
    public const int EXPLOSION = 2;
    public List<AudioClip> explosions;

    public const int POWERUP = 3;
    public AudioClip powerUp;

    public const int MACHINEGUN = 4;
    public AudioClip machineGun;
    public const int LASERGUN = 5;
    public AudioClip laserGun;
    public const int IONGUN = 6;
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

    public void playSound(int sound) {
        switch (sound) {
            case CLICK:
                playClip(this.click);
                break;
            case DAMAGE:
                playClip(this.damage);
                break;
            case EXPLOSION:
                int selected = Random.Range(0, this.explosions.Count - 1);
                playClip(this.explosions[selected]);
                break;
            case POWERUP:
                playClip(this.powerUp);
                break;
            case MACHINEGUN:
                playClip(this.machineGun);
                break;
            case LASERGUN:
                playClip(this.laserGun);
                break;
            default:
            case IONGUN:
                playClip(this.ionGun);
                break;
        }
    }
}

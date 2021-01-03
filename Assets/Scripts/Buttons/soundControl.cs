using UnityEngine;

// Script du bouton de mute de la musique
public class soundControl : MonoBehaviour {
    public void Onclick() {
        SoundManager.Instance.toggleMusic();
    }
}

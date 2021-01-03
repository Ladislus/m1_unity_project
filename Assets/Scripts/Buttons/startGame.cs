using UnityEngine;

// Script du bouton de lancement de partie
public class startGame : MonoBehaviour {

    public LevelFader fader;

    public void OnClick() {
        SoundManager.Instance.playSound(Sounds.CLICK);
        this.fader.fadeOutToLevel("Game");
    }
}

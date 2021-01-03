using UnityEngine;
using UnityEngine.SceneManagement;

// Script de gestion du fader permettant la transition
// lisse entre plusieurs scenes du jeu
public class LevelFader : MonoBehaviour {

    // L'animator du fader
    public Animator faderAnimator;

    // 
    private string targetLevel;

    // Fonction permettant le lancement du fadeOut
    // avec la scene à charger
    public void fadeOutToLevel(string level_name) {
        this.targetLevel = level_name;
        this.faderAnimator.SetTrigger("FadeOutNeeded");
    }

    // Fonction exécutée lors de la fin de
    // l'application permettant le chargement de
    // la nouvelle scene
    public void onFadeOutComplete() {
        SceneManager.LoadScene(this.targetLevel);
    }
}

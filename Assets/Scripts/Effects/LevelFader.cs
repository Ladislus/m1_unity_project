using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFader : MonoBehaviour {

    public Animator faderAnimator;

    private string targetLevel;

    public void fadeOutToLevel(string level_name) {
        this.targetLevel = level_name;
        this.faderAnimator.SetTrigger("FadeOutNeeded");
    }

    public void onFadeOutComplete() {
        SceneManager.LoadScene(this.targetLevel);
    }
}

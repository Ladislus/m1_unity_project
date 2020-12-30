﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFader : MonoBehaviour {

    public Animator faderAnimator;

    private string target_level;

    public void fadeOutToLevel(string level_name) {
        this.target_level = level_name;
        this.faderAnimator.SetTrigger("FadeOutNeeded");
    }

    public void onFadeOutComplete() {
        SceneManager.LoadScene(this.target_level);
    }
}

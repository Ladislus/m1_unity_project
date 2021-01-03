using UnityEngine;

// Manager de la scene d'affichage des scores
public class EndManager : MonoBehaviour {
    void Awake() {
        ScoreManager.Instance.endGame();
    }
}

using UnityEngine;
using UnityEngine.UI;

// Script singleton de gestion du score
public class ScoreManager : MonoBehaviour {

    // Instance singleton du manager
    private static ScoreManager _instance;

    // Property permettant la récupération en 
    // readonly de l'instance du singleton
    public static ScoreManager Instance { get { return _instance; } }

    private int highscore;
    private int score = 0;


    private Text scoreDisplay;

    void Awake() {
        if (_instance == null) { 
            _instance = this;
            DontDestroyOnLoad(this.gameObject); 
        }
        else Destroy(this); 

        // Chargement du highscore du joueur sur le device,
        // 0 si aucun n'existe
        this.highscore = PlayerPrefs.GetInt("highscore", 0);
        // Récupération du champ texte contenant le score,
        // sur la page de menu et affichage du highscore
        GameObject.FindWithTag("Highscore").GetComponent<Text>().text = "" + this.highscore; 
    }

    // Fonction lancée au départ de chaque partie
    // Permet de mettre l'affichage du score à 0, et
    // récupérer une référence vers l'affichage
    public void startGame() {
        this.scoreDisplay = GameObject.FindWithTag("Score").GetComponent<Text>();
        this.scoreDisplay.text = "" + this.score;
    }

    // Ajout de points et mise à jour
    // de l'affichage du score
    public void AddPoints(int points) {
        this.score += points;
        this.scoreDisplay.text = "" + this.score;
    }

    // Fonctino lancée sur l'écran de fin de partie
    public void endGame() {
        // Si le score est supérieur au highscore actuel,
        // sauvegarde du nouveau highscore et affichage du texte
        // de nouveau highscore
        if (this.score > this.highscore) {
            this.highscore = score;
            PlayerPrefs.SetInt("highscore", this.score);
            GameObject.FindWithTag("NewHighscore").GetComponent<Text>().enabled = true; 
        }
        // Affichage du score de la partie, et du highscore
        GameObject.FindWithTag("Score").GetComponent<Text>().text = "" + this.score; 
        GameObject.FindWithTag("Highscore").GetComponent<Text>().text = "" + this.highscore;
        // Reset du score 
        this.score = 0;
    }
}

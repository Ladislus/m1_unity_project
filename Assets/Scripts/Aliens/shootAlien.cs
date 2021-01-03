using UnityEngine;

// Script de gestion du tir des aliens
public class shootAlien : MonoBehaviour {

    private Gun gun;

    void Start() {
        // Selection d'une arme aléatoire
        Guns randomGun = (Guns) Random.Range(0, System.Enum.GetNames(typeof(Guns)).Length);

        // Selection d'une couleur aléatoire
        SPColor randomColor;
        if (Random.Range(0f, 1f) < 0.5f) { randomColor = SPColor.Green; }
        else randomColor = SPColor.Blue;

        // Création de l'arme avec la Factory Singleton
        this.gun = GunFactory.Instance.make(randomGun, this.transform, randomColor);
    }

    void Update() {
        // Si le cooldown de l'arme est fini,
        // lance le tir de l'arme
        if (this.gun.isReady(Time.deltaTime)) {
            this.gun.shoot(true);
        }
    }
}

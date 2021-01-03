using UnityEngine;

// Script de gestion du tir du joueur
public class shootPlayer : MonoBehaviour {

    // Arme actuelle du joueur
    private Gun gun;

    void Start() {
        // Lors du lancement de la partie, utilisation du GunFactory
        // Singleton pour équiper le joueur de MachineGun bleu 
        this.gun = GunFactory.Instance.make(Guns.MACHINEGUN, this.transform, SPColor.Blue);
    }

    void Update() {
        // Si le cooldown de l'arme est fini, tir avec l'arme
        if (this.gun.isReady(Time.deltaTime)) this.gun.shoot(false);
    }

    // Fonction de changement d'arme
    public void setGun(Guns newGun) {
        // Selection aléatoire de la couleur (50/50)
        SPColor randomColor;
        if (Random.Range(0f, 1f) < 0.5f) randomColor = SPColor.Blue;
        else randomColor = SPColor.Green;

        // Utilisation du GunFactory Singleton pour équiper la nouvelle arme
        this.gun = GunFactory.Instance.make(newGun, this.transform, randomColor);
    }
}

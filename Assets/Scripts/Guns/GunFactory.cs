using UnityEngine;

// Énumération des différentes armes disponibles
public enum Guns { MACHINEGUN, LASERGUN, IONGUN }

// Factory Singleton permettant la création des armes
// La fonction de création des armes n'est pas static
// car elle a besoin des préfabs des projectiles
public class GunFactory : MonoBehaviour {

    // Instance singleton du manager
    private static GunFactory _instance;

    // Property permettant la récupération en 
    // readonly de l'instance du singleton
    public static GunFactory Instance { get { return _instance; } }

    // Références vers les préfabs des projectiles
    public GameObject blueOrb;
    public GameObject greenOrb;
    public GameObject blueBullet;
    public GameObject greenBullet;
    public GameObject blueLaser;
    public GameObject greenLaser;

    void Awake() {
        if (_instance == null) { 
            _instance = this;
            DontDestroyOnLoad(this.gameObject); 
        } else Destroy(this);
    }

    // Fonction de création des armes
    public Gun make(Guns gunType, Transform transform, SPColor color) {
        switch (gunType) {
            case Guns.MACHINEGUN:
                if (color == SPColor.Blue) return getMG(transform, color, this.blueBullet);
                return getMG(transform, color, this.greenBullet);
            case Guns.LASERGUN:
                if (color == SPColor.Blue) return getLG(transform, color, this.blueLaser);
                return getLG(transform, color, this.greenLaser);
            default:
            case Guns.IONGUN:
                if (color == SPColor.Blue) return getIG(transform, color, this.blueOrb);
                return getIG(transform, color, this.greenOrb);
        }
    }

    // Fonction de création de la MachineGun avec les paramètre de l'arme
    private MachineGun getMG(Transform transform, SPColor color, GameObject prefab) {
        return new MachineGun(transform, new Vector2(0f, 10f), 0.5f, 1.0f, 1.5f, color, prefab);
    }

    // Fonction de création de la LaserGun avec les paramètre de l'arme
    private LaserGun getLG(Transform transform, SPColor color, GameObject prefab) {
        return new LaserGun(transform, new Vector2(0f, 20f), 0.7f, 1.2f, 1.7f, color, prefab);
    }

    // Fonction de création de la IonGun avec les paramètre de l'arme
    private IonGun getIG(Transform transform, SPColor color, GameObject prefab) {
        return new IonGun(transform, new Vector2(2f, 5f), 0.4f, 0.8f, 0.1f, color, prefab);
    }
}

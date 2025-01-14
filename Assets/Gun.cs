using UnityEngine;

public class Pistol : MonoBehaviour
{
    public Camera playerCamera;  // La cam�ra de joueur
    public GameObject bulletPrefab;  // Le projectile du pistolet
    public Transform shootingPoint;  // Le point o� les balles sont tir�es
    public float bulletSpeed = 20f;  // La vitesse du projectile
    public int maxAmmo = 12;  // Le nombre de balles par chargeur
    private int currentAmmo;  // Le nombre de balles restantes
    public float fireRate = 0.5f;  // Temps entre chaque tir (en secondes)
    private float nextFireTime = 0f;  // Le temps auquel vous pouvez tirer � nouveau

    void Start()
    {
        // Initialiser les munitions
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        // Tirer si on appuie sur le bouton du tir (clic gauche de la souris ou bouton de tir)
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime && currentAmmo > 0)
        {
            Shoot();
            Debug.Log("Tire");
        }

        // Recharger le pistolet
        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo)
        {
            Reload();
        }
    }

    void Shoot()
    {
        // Calculer le temps du prochain tir pour g�rer la cadence
        nextFireTime = Time.time + fireRate;

        // D�cr�menter le nombre de munitions
        currentAmmo--;

        // Cr�er une balle et la propulser
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.linearVelocity = playerCamera.transform.forward * bulletSpeed;
        Debug.Log("Tire23");

        // Optionnel : Jouer un son de tir ou une animation (si n�cessaire)
        // Exemple : AudioSource.PlayClipAtPoint(shootSound, transform.position);
    }

    void Reload()
    {
        currentAmmo = maxAmmo;
        // Optionnel : Jouer une animation de recharge ou un son.
    }
}

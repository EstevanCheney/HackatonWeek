using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 10f;  // Durée de vie de la balle avant de disparaître

    void Start()
    {
        Destroy(gameObject, lifetime);  // Détruire la balle après un certain temps
    }

    void OnCollisionEnter(Collision collision)
    {
        // Vous pouvez détecter ici des collisions avec des ennemis, des murs, etc.
        // Exemple : si la balle touche un ennemi, infliger des dégâts
        if (collision.gameObject.CompareTag("Zombie"))
        {
            // Infliger des dégâts à l'ennemi
            collision.gameObject.GetComponent<ZombieIA>().TakeDamage(10);
        }
        Debug.Log("Collision");
        // Détruire la balle lorsqu'elle touche un objet
        Destroy(gameObject);
    }
}

using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 10f;  // Dur�e de vie de la balle avant de dispara�tre

    void Start()
    {
        Destroy(gameObject, lifetime);  // D�truire la balle apr�s un certain temps
    }

    void OnCollisionEnter(Collision collision)
    {
        // Vous pouvez d�tecter ici des collisions avec des ennemis, des murs, etc.
        // Exemple : si la balle touche un ennemi, infliger des d�g�ts
        if (collision.gameObject.CompareTag("Zombie"))
        {
            // Infliger des d�g�ts � l'ennemi
            collision.gameObject.GetComponent<ZombieIA>().TakeDamage(10);
        }
        Debug.Log("Collision");
        // D�truire la balle lorsqu'elle touche un objet
        Destroy(gameObject);
    }
}

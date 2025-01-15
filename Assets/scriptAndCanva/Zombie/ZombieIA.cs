using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class ZombieIA : MonoBehaviour
{
    NavMeshAgent _agent;
    Animator _animator;

    public GameObject _Target;

    public GameObject _TargetLook;

    //Maximum de points de vie
    public int maxHitPoint = 5;

    //Points de vie actuels
    public int hitPoint = 0;



    // Start is called before the first frame update
    void Start()
    {
        hitPoint = maxHitPoint;
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();

        _Target = GameObject.FindGameObjectWithTag("Player");

        if (_Target == null)
        {
            Debug.LogError("Player not found, please ensure the target has the tag 'Player'.");
        }

        if (!_agent.isOnNavMesh)
        {
            Debug.LogError("Zombie is not on the NavMesh.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_Target != null && _animator.GetBool("Dead") == false)
        {
            // Définir la destination du zombie
            _agent.SetDestination(_Target.transform.position);

            // Si le zombie est assez proche du joueur, il arrête de marcher

            if (_agent.velocity.x == 0 && _agent.velocity.y == 0 && _agent.velocity.z == 0)
            {
                _animator.SetBool("walk", false);
                // On peut ici ajouter des animations pour une attaque par exemple.
            }
            else
            {
                _animator.SetBool("walk", true);
            }
        }

        if (_TargetLook != null && _animator.GetBool("Dead") == false)
        {
            _TargetLook.transform.LookAt(_Target.transform);

            transform.rotation = Quaternion.Euler(0f, _TargetLook.transform.eulerAngles.y, 0f);
        }
    }

    //Permet de recevoir des dommages
    public void GetDamage(int damage)
    {
        //Applique les dommages aux points de vies actuels
        hitPoint -= damage;

        //Si les point de vie sont inférieurs à 1 = Supprime l'objet
        if (hitPoint < 1)
        {
            _animator = GetComponentInChildren<Animator>();
            if (_animator != null)
            {
                _animator.SetBool("Dead", true);

                _agent.SetDestination(_agent.transform.position);
            }

            //Destroy(gameObject);
        }
    }
}

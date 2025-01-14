using UnityEngine;
using UnityEngine.AI;

public class ZombieIA : MonoBehaviour
{
    NavMeshAgent _agent;
    Animator _animator;

    public GameObject _Target;

    public GameObject _TargetLook;


    // Start is called before the first frame update
    void Start()
    {
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
        if (_Target != null)
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

        _TargetLook.transform.LookAt(_Target.transform);

        transform.rotation= Quaternion.Euler(0f,_TargetLook.transform.eulerAngles.y,0f);
    }
}

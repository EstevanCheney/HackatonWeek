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

    public int maxHitPoint = 5;

    public int hitPoint = 0;

    public bool CanShoot;

    public float maxDistance = 10f;

    private float nextDamage;
    void Start()
    {
        hitPoint = maxHitPoint;
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();

        CanShoot = false;

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
            float distanceToTarget = Vector3.Distance(transform.position, _Target.transform.position);

            if (distanceToTarget > 10f)
            {
                _agent.SetDestination(_agent.transform.position);
                _animator.SetBool("Nomoove", true);
                return;
            }
            else
            {
                _animator.SetBool("Nomoove", false);
                _agent.SetDestination(_Target.transform.position);


                if (_agent.velocity.x == 0 && _agent.velocity.y == 0 && _agent.velocity.z == 0)
                {
                    _animator.SetBool("walk", false);

                    if (Time.time > nextDamage)
                    {
                        HealthBar[] health = FindObjectsOfType<HealthBar>();

                        foreach (HealthBar healthPlayer in health)
                        {
                            healthPlayer.Damage(10f);
                        }
                        nextDamage = Time.time + 0.5f;
                    }
                }
                else
                {
                    _animator.SetBool("walk", true);
                }
            }
        }

        if (_TargetLook != null && _animator.GetBool("Dead") == false)
        {
            _TargetLook.transform.LookAt(_Target.transform);

            transform.rotation = Quaternion.Euler(0f, _TargetLook.transform.eulerAngles.y, 0f);
        }
    }

    public void GetDamage(int damage)
    {
        if (CanShoot)
        {

            hitPoint -= damage;

            if (hitPoint < 1)
            {
                _animator = GetComponentInChildren<Animator>();
                if (_animator != null)
                {
                    _animator.SetBool("Dead", true);

                    _agent.SetDestination(_agent.transform.position);
                }

            }
        }
    }
}

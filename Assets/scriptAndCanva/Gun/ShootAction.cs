using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAction : MonoBehaviour
{
    public int gunDamage = 1;

    public float weaponRange = 200f;

    public float hitForce = 100f;

    private Camera fpsCam;

    public float fireRate = 0.25f;

    private float nextFire;

    public LayerMask layerMask;


    void Start()
    {
        fpsCam = GetComponentInParent<Camera>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
 
            nextFire = Time.time + fireRate;

            print(nextFire);

            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

            RaycastHit hit;


            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange, layerMask))
            {
                print("Target");

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * hitForce);

                    if (hit.collider.gameObject.GetComponent<ZombieIA>() != null)
                    {
                        hit.collider.gameObject.GetComponent<ZombieIA>().GetDamage(gunDamage);
                    }
                }
            }
        }
    }
}
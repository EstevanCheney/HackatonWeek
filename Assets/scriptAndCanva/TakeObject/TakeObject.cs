using Unity.Hierarchy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class TakeObject : MonoBehaviour 
{
    [SerializeField]
    private float pickupRange = 2.6f;

    public pickupBehaviour playerPickupBehaviour;

    [SerializeField]
    private GameObject pickupText;

    [SerializeField]
    private LayerMask layerMask;
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, pickupRange))
        {
            if(hit.transform.CompareTag("Item"))
            {
                pickupText.SetActive(true);

                if (Input.GetKeyDown(KeyCode.F))
                {
                    playerPickupBehaviour.DoPickup(hit.transform.gameObject.GetComponent<Item>());
                }
            }
        } else {
            pickupText.SetActive(false);
        }
    }
}

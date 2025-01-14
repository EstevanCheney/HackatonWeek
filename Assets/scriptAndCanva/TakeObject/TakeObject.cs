using Unity.Hierarchy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeObject : MonoBehaviour 
{
    [SerializeField]
    private float pickupRange = 2.6f;

    public Inventory inventory;

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
                    inventory.content.Add(hit.transform.gameObject.GetComponent<Item>().item);
                    Destroy(hit.transform.gameObject);
                }
            }
        } else {
            pickupText.SetActive(false);
        }
    }
}

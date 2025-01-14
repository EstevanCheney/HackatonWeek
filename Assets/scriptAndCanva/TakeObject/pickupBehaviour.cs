using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupBehaviour : MonoBehaviour
{
    [SerializeField]
    private Inventory inventory;

    public void DoPickup(Item item)
    {
        if (inventory.isFull())
        {
            Debug.Log("Inventory full, can't pick up : " + item.name);
            return;
        }

        inventory.addItem(item.itemData);
        Destroy(item.gameObject);
    }
}

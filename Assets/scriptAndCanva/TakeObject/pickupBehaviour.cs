using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehaviour : MonoBehaviour
{
    [SerializeField]
    private Inventory inventory;

    private Item currentItem;

    public void DoPickup(Item item)
    {
        if (inventory.isFull())
        {
            Debug.Log("Inventory full, can't pick up : " + item.name);
            return;
        }

        inventory.addItem(currentItem.item);
        Destroy(currentItem.gameObject);
    }
}

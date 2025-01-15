using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupBehaviour : MonoBehaviour
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

        currentItem = item;

        inventory.addItem(item.itemData);
        Destroy(item.gameObject);
    }

    public void AddItemToInventory()
    {
        inventory.addItem(currentItem.itemData);
        Destroy(currentItem.gameObject);

        currentItem = null;
    }
}

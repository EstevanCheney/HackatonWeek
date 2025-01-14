using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class Slot : MonoBehaviour
{
    public ItemData item;
    public Image itemVisual;

    public void ClickOnSlot()
    {
        Inventory.instance.OpenActionPanel(item);
    }
}

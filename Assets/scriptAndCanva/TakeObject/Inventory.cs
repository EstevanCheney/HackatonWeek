using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Diagnostics;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    public List<ItemData> content = new List<ItemData>();

    [SerializeField]
    private GameObject InventoryPanel;

    [SerializeField]
    private Transform inventorySlotParent;

    [SerializeField]
    private GameObject actionPanel;

    [SerializeField]
    private GameObject useButton;

    [SerializeField]
    private FirstPersonController player;
    public static Inventory instance;
    private ItemData itemCurrentlySelected;

    const int InventorySize = 12;
    private void Start()
    {
        RefreshContent();
    }
    public void addItem(ItemData item)
    {
        content.Add(item);
        RefreshContent();
    }

    private void Update ()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            InventoryPanel.SetActive(!InventoryPanel.activeSelf);
            if (InventoryPanel.activeSelf == false)
            {
                Cursor.lockState = CursorLockMode.Locked;
                player.cameraCanMove = true;
                CloseActionPanel();
            }
            else if (InventoryPanel.activeSelf == true) {
                Cursor.lockState = CursorLockMode.None;
                player.cameraCanMove = false;
            }
        }
    }

    private void RefreshContent()
    {
        for (int i = 0; i < content.Count; i++)
        {
            inventorySlotParent.GetChild(i).GetChild(0).GetComponent<Image>().sprite = content[i].visual;
        }
    }

    public bool isFull()
    {
        return InventorySize == content.Count;
    }

    public void OpenActionPanel(ItemData item)
    {
        itemCurrentlySelected = item;

        if (item == null)
        {
            actionPanel.SetActive(false);
            return;
        }
        actionPanel.SetActive(true);
    }

    public void CloseActionPanel()
    {
        actionPanel.SetActive(false);
    }

    public void UseActionButton()
    {
        CloseActionPanel();
    }
}

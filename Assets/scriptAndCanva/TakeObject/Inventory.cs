using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Diagnostics;
using UnityEngine.InputSystem;

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
    private GameObject textCathedrale;

    [SerializeField]
    private GameObject textGare;

    [SerializeField]
    private GameObject textTour;

    [SerializeField]
    private GameObject textMaisonRose;

    [SerializeField]
    private GameObject textVille;

    [SerializeField]
    private Sprite emptySlotVisual;

    [SerializeField]
    private Transform dropPoint;

    [SerializeField]
    private FirstPersonController player;
    public static Inventory instance;
    private ItemData itemCurrentlySelected;

    const int InventorySize = 12;
    private void Awake()
    {
        instance = this;
    }
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
           Slot currentSlot = inventorySlotParent.GetChild(i).GetComponent<Slot>();

            currentSlot.item = content[i];
            currentSlot.itemVisual.sprite = content[i].visual;
        }
    }

    public bool isFull()
    {
        return InventorySize == content.Count;
    }

    public void OpenActionPanel(ItemData item)
    {
        if (item == null)
        {
            actionPanel.SetActive(false);
            return;
        }
        itemCurrentlySelected = item;
        actionPanel.SetActive(true);
    }

    public void CloseActionPanel()
    {
        actionPanel.SetActive(false);
    }

    public void UseActionButton()
    {
        GameObject instantiatedItem = Instantiate(itemCurrentlySelected.prefab);

        UnityEngine.Debug.Log(instantiatedItem.name);
        if (instantiatedItem.name == "ImageCat�dral 1(Clone)")
        {
            textCathedrale.SetActive(true);
        }
        else
        {
            textCathedrale.SetActive(false);
        }
        if (instantiatedItem.name == "ImageGare 1(Clone)")
        {
            textGare.SetActive(true);
        }
        else
        {
            textGare.SetActive(false);
        }
        if (instantiatedItem.name == "ImageMaisonRose 1(Clone)")
        {
            textMaisonRose.SetActive(true);
        }
        else
        {
            textMaisonRose.SetActive(false);
        }
        if (instantiatedItem.name == "ImageTour 1(Clone)")
        {
            textTour.SetActive(true);
        }
        else
        {
            textTour.SetActive(false);
        }
        if (instantiatedItem.name == "ImageVille 1(Clone)")
        {
            textVille.SetActive(true);
        }
        else
        {
            textVille.SetActive(false);
        }

        instantiatedItem.transform.position = dropPoint.position;
        CloseActionPanel();
        InventoryPanel.SetActive(false);
        InspectObject[] rotations = FindObjectsOfType<InspectObject>();

        foreach (InspectObject rotation in rotations)
        {
            rotation.canRotate = true;
        }

        FirstPersonController[] players = FindObjectsOfType<FirstPersonController>();

        foreach (FirstPersonController camera in players)
        {
            camera.playerCanMove = false;
        }
        Cursor.lockState = CursorLockMode.Locked;
    }
}

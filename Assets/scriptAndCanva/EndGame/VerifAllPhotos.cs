using NUnit.Framework;
using UnityEngine;

public class VerifAllPhotos : MonoBehaviour
{
    [SerializeField]
    private Inventory inventory;

    [SerializeField]
    private GameObject Lu;

    [SerializeField]
    private GameObject BoxToBunker;

    [SerializeField]
    private GameObject textToEnter;

    [SerializeField]
    private GameObject NarrationSystem;

    [SerializeField]
    private GameObject StandaloneNarration;

    private int count = 0;
    public bool StartEnd = false;

    void Update()
    {
        count = 0;
        for (int i = 0; i < inventory.content.Count && count != 5; i++)
        {
            if (inventory.content[i].name == "Photo Cathédrale")
            {
                count++;
            }
            else if (inventory.content[i].name == "Photo Gare")
            {
                count++;
            }
            else if (inventory.content[i].name == "Photo Maison Rose")
            {
                count++;
            }
            else if (inventory.content[i].name == "Photo Tour")
            {
                count++;
            }
            else if (inventory.content[i].name == "Photo Ville")
            {
                count++;
            }
        }
        if (count == 5)
        {
            StartEnd = true;
            Lu.SetActive(true);
            NarrationSystem.SetActive(true);
            StandaloneNarration.SetActive(true);
            textToEnter.SetActive(false);
            BoxToBunker.SetActive(false);
        }
    }
}

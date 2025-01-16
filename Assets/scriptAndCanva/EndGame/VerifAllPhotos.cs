using NUnit.Framework;
using UnityEngine;

public class VerifAllPhotos : MonoBehaviour
{
    [SerializeField]
    private Inventory inventory;
    private int count = 0;
    public bool StartEnd = false;

    void Update()
    {
        count = 0;
        for (int i = 0; i < inventory.content.Count; i++) {
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
        if (count == 5) {
            StartEnd = true;
        }
        Debug.Log(count);
    }
}

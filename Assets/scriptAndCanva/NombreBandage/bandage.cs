using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
    public GameObject interactionMessage;
    public TextMeshProUGUI bandageText;
    private bool isPlayerNearby = false;
    private bool isCollected = false;

    void Start()
    {
        interactionMessage.SetActive(false);
        bandageText.text = "0/1";
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.F) && !isCollected)
        {
            CollectObject();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            interactionMessage.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            interactionMessage.SetActive(false);
        }
    }

    void CollectObject()
    {
        isCollected = true;
        interactionMessage.SetActive(false);
        bandageText.text = "1/1";
        Destroy(gameObject);
    }
}

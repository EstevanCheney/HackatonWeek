using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    private Collider HitBox;

    [SerializeField]
    private GameObject interactionMessage;

    [SerializeField]
    private VerifAllPhotos end;

    private bool isPlayerIsIn = false;

    private void Update()
    {
        OnTriggerEnter(HitBox);
        OnTriggerExit(HitBox);
        if (isPlayerIsIn && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("Bunker final");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerIsIn = true;
            interactionMessage.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerIsIn = false;
            interactionMessage.SetActive(false);
        }
    }
}

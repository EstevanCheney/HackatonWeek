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

    private bool isPlayerIsIn;

    private void Update()
    {
        OnTriggerEnter(HitBox);
        OnTriggerExit(HitBox);
        if (isPlayerIsIn && Input.GetKeyDown(KeyCode.F) && end.StartEnd)
        {
            SceneManager.LoadScene("Bunker final");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && end.StartEnd)
        {
            isPlayerIsIn = true;
            interactionMessage.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && end.StartEnd)
        {
            isPlayerIsIn = false;
            interactionMessage.SetActive(false);
        }
    }
}

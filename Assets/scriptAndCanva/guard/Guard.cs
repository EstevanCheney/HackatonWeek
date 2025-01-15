using System.Collections;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public Camera mainCamera;
    public Transform focusPoint;
    public float zoomSpeed = 2f;
    public GameObject dialogueUI;
    public GameObject player;
    private bool isPlayerNearby = false;
    private FirstPersonController playerMovement;

        private void Start()
    {
        if (player != null)
        {
            playerMovement = player.GetComponent<FirstPersonController>();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            StartZoomAndDialogue();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            StopZoom();
        }
    }

    private void StartZoomAndDialogue()
    {
        if (mainCamera != null && focusPoint != null)
        {
            DisablePlayerMovement();
            StartCoroutine(ZoomToNPC());
        }
        if (dialogueUI != null)
        {
            dialogueUI.SetActive(true);
        }
    }

        private void DisablePlayerMovement()
    {
        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }
    }

    private void EnablePlayerMovement()
    {
        if (playerMovement != null)
        {
            playerMovement.enabled = true;
        }
    }

    private void StopZoom()
    {
        if (dialogueUI != null)
        {
            dialogueUI.SetActive(false);
        }
    }

    private IEnumerator ZoomToNPC()
    {
        Vector3 originalPosition = mainCamera.transform.position;
        Quaternion originalRotation = mainCamera.transform.rotation;

        Vector3 targetPosition = focusPoint.position - focusPoint.forward * 1f;
        Quaternion targetRotation = Quaternion.LookRotation(focusPoint.position - mainCamera.transform.position);

        float progress = 0;
        while (progress < 1 && isPlayerNearby)
        {
            progress += Time.deltaTime * zoomSpeed;
            mainCamera.transform.position = Vector3.Lerp(originalPosition, targetPosition, progress);
            mainCamera.transform.rotation = Quaternion.Lerp(originalRotation, targetRotation, progress);
            yield return null;
        }
    }
}

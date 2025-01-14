using UnityEngine;

public class BunkerDoorInteraction : MonoBehaviour
{
    public Transform doorTransform;
    public float rotationAngle = 180f;
    public float moveDistance = 5f;
    public float animationDuration = 5f; 

    private bool isOpen = false;

        private bool isPlayerNearby = false;
    private bool isAnimating = false;

    public GameObject interactionMessage;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    void Start()
    {
        interactionMessage.SetActive(false);
        initialPosition = doorTransform.position;
        initialRotation = doorTransform.rotation;
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.F) && !isAnimating)
        {
            if (isOpen)
            {
                StartCoroutine(CloseDoor());
            }
            else
            {
                StartCoroutine(OpenDoor());
            }
        }
    }

    private System.Collections.IEnumerator OpenDoor()
    {
        isAnimating = true;

        float elapsedTime = 0f;

        Quaternion startRotation = doorTransform.rotation;
        Quaternion targetRotation = startRotation * Quaternion.Euler(0f, 0f, rotationAngle);

        Vector3 startPosition = doorTransform.position;
        Vector3 targetPosition = startPosition + new Vector3(-moveDistance, 0f, 0f);

        while (elapsedTime < animationDuration)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / animationDuration;

            doorTransform.rotation = Quaternion.Slerp(startRotation, targetRotation, progress);
            doorTransform.position = Vector3.Lerp(startPosition, targetPosition, progress);

            yield return null;
        }

        doorTransform.rotation = targetRotation;
        doorTransform.position = targetPosition;

        isOpen = true;
        isAnimating = false;
    }

    private System.Collections.IEnumerator CloseDoor()
    {
        isAnimating = true;

        float elapsedTime = 0f;

        Quaternion startRotation = doorTransform.rotation;
        Quaternion targetRotation = initialRotation;

        Vector3 startPosition = doorTransform.position;
        Vector3 targetPosition = initialPosition;

        while (elapsedTime < animationDuration)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / animationDuration;

            doorTransform.rotation = Quaternion.Slerp(startRotation, targetRotation, progress);
            doorTransform.position = Vector3.Lerp(startPosition, targetPosition, progress);

            yield return null;
        }

        doorTransform.rotation = targetRotation;
        doorTransform.position = targetPosition;

        isOpen = false;
        isAnimating = false;
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
}


using UnityEngine;

public class ElevatorFinal : MonoBehaviour
{
    public Transform elevatorTransform;
    public float moveDistance = 5f;
    public float animationDuration = 5f;
    public KeyCode activationKey = KeyCode.F;
    private bool isOpen = false;
    private bool isPlayerNearby = false;
    private bool isAnimating = false;
    private Vector3 initialPosition;
    private Transform playerTransform;
    private CharacterController playerController;

    void Start()
    {
        initialPosition = elevatorTransform.position;
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(activationKey) && !isAnimating)
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

        Vector3 startPosition = elevatorTransform.position;
        Vector3 targetPosition = startPosition + new Vector3(0f, -moveDistance, 0f);

        while (elapsedTime < animationDuration)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / animationDuration;

            elevatorTransform.position = Vector3.Lerp(startPosition, targetPosition, progress);

            if (playerTransform != null)
            {
                Vector3 playerPosition = playerTransform.position;
                playerPosition.y = elevatorTransform.position.y;
                playerTransform.position = playerPosition;
            }

            yield return null;
        }

        elevatorTransform.position = targetPosition;

        isOpen = true;
        isAnimating = false;
    }

    private System.Collections.IEnumerator CloseDoor()
    {
        isAnimating = true;

        float elapsedTime = 0f;

        Vector3 startPosition = elevatorTransform.position;
        Vector3 targetPosition = initialPosition;

        while (elapsedTime < animationDuration)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / animationDuration;

            elevatorTransform.position = Vector3.Lerp(startPosition, targetPosition, progress);

            if (playerTransform != null)
            {
                Vector3 playerPosition = playerTransform.position;
                playerPosition.y = elevatorTransform.position.y;
                playerTransform.position = playerPosition;
            }

            yield return null;
        }

        elevatorTransform.position = targetPosition;

        isOpen = false;
        isAnimating = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            playerTransform = other.transform;
            playerController = other.GetComponent<CharacterController>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            playerTransform = null;
            playerController = null;
        }
    }
}

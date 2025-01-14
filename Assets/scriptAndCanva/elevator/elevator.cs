using UnityEngine;

public class elevator : MonoBehaviour
{

    public Transform elevatorTransform;
    public float moveDistance = 5f;
    public float animationDuration = 5f; 
    private bool isOpen = false;
    private bool isPlayerNearby = false;
    private bool isAnimating = false;
    private Vector3 initialPosition;
    void Start()
    {
         initialPosition = elevatorTransform.position;
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

        Vector3 startPosition = elevatorTransform.position;
        Vector3 targetPosition = startPosition + new Vector3(0f, moveDistance, 0f);

        while (elapsedTime < animationDuration)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / animationDuration;

            elevatorTransform.position = Vector3.Lerp(startPosition, targetPosition, progress);

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
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class EnterTank : MonoBehaviour
{
    [SerializeField]
    private Collider HitBox;

    [SerializeField]
    private GameObject interactionMessage;

    [SerializeField]
    private VerifAllPhotos end;

    private bool isPlayerIsIn;
    public PlayableDirector playableDirector;

    private void Update()
    {
        OnTriggerEnter(HitBox);
        OnTriggerExit(HitBox);
        if (isPlayerIsIn && Input.GetKeyDown(KeyCode.F)) {
            end.FinalSceneTank(playableDirector);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && end.StartEnd == true)
        {
            isPlayerIsIn = true;
            interactionMessage.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && end.StartEnd == true)
        {
            isPlayerIsIn = false;
            interactionMessage.SetActive(false);
        }
    }
}

using UnityEngine;
using UnityEngine.Playables;

public class FinalScreen : MonoBehaviour
{
    [SerializeField]
    private Collider HitBox;

    [SerializeField]
    private GameObject FinalSreen;

    [SerializeField]
    private VerifAllPhotos end;

    private bool isTankIsIn;

    private void Update()
    {
        OnTriggerEnter(HitBox);
        OnTriggerExit(HitBox);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tank"))
        {
            isTankIsIn = true;
            FinalSreen.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Tank"))
        {
            isTankIsIn = false;
            FinalSreen.SetActive(false);
        }
    }
}

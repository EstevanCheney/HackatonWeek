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
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && end.StartEnd == true)
        {
            isTankIsIn = true;
            Debug.Log(isTankIsIn);
            FinalSreen.SetActive(true);
        }
    }

}

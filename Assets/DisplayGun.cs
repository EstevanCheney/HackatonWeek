using UnityEngine;
using UnityEngine.AI;

public class HideObjectFromCamera : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject objectToHide;

    private int originalCullingMask;

    public bool Isdisplay;


    void Start()
    {
        if (mainCamera == null || objectToHide == null)
        {
            Debug.LogError("La cam�ra ou l'objet � masquer n'est pas assign�.");
            return;
        }

        objectToHide.layer = LayerMask.NameToLayer("HiddenObject");

        originalCullingMask = mainCamera.cullingMask;

        mainCamera.cullingMask &= ~(1 << LayerMask.NameToLayer("HiddenObject"));
        Isdisplay = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Isdisplay)
            {
                HideObjectFromCameraMethod(); 
                Isdisplay = false;

                ZombieIA[] zombies = FindObjectsOfType<ZombieIA>();

                foreach (ZombieIA zombie in zombies)
                {
                    zombie.CanShoot = false;
                }
            }
            else
            {
                ShowObjectToCamera();
                Isdisplay = true;

                ZombieIA[] zombies = FindObjectsOfType<ZombieIA>();

                foreach (ZombieIA zombie in zombies)
                {
                    zombie.CanShoot = true;
                }
            }
        }
    }

    public void HideObjectFromCameraMethod()
    {
        mainCamera.cullingMask &= ~(1 << LayerMask.NameToLayer("HiddenObject"));
    }

    public void ShowObjectToCamera()
    {
        mainCamera.cullingMask = originalCullingMask;
    }
}

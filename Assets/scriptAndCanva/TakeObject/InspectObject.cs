using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using static UnityEditor.FilePathAttribute;
using System;

public class InspectObject : MonoBehaviour
{
    [SerializeField]
    private GameObject actualObject;

    [SerializeField]
    private FirstPersonController player;

    [SerializeField]
    private GameObject text;

    public bool canRotate = false;
    private float horizontalSpeed = 2;
    private float verticalSpeed = 2;

    void Update()
    {
        if (canRotate == true)
        {
            float h = horizontalSpeed * Input.GetAxis("Mouse X");
            float v = verticalSpeed * Input.GetAxis("Mouse Y");
            actualObject.transform.Rotate(v, 0, h);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && canRotate == true)
        {
            text.SetActive(false);
            Destroy(actualObject);
            canRotate = false;
            FirstPersonController[] players = FindObjectsOfType<FirstPersonController>();

            foreach (FirstPersonController camera in players)
            {
                camera.playerCanMove = true;
                camera.cameraCanMove = true;
            }
        }
    }
}
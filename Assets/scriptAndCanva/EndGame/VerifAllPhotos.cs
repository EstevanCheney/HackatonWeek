using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System;
using UnityEngine.Playables;

public class VerifAllPhotos : MonoBehaviour
{
    [SerializeField]
    private Inventory inventory;

    [SerializeField]
    private GameObject Lu;

    [SerializeField]
    private GameObject BoxToBunker;

    [SerializeField]
    private GameObject textToEnter;

    [SerializeField]
    private GameObject NarrationSystem;

    [SerializeField]
    private GameObject StandaloneNarration;

    [SerializeField]
    private GameObject tank;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject canva;

    [SerializeField]
    private GameObject finalPoint;

    private int count = 0;
    public bool StartEnd = false;

    void Update()
    {
        count = 0;
        for (int i = 0; i < inventory.content.Count && count != 5; i++)
        {
            if (inventory.content[i].name == "Photo Cathédrale")
            {
                count++;
            }
            else if (inventory.content[i].name == "Photo Gare")
            {
                count++;
            }
            else if (inventory.content[i].name == "Photo Maison Rose")
            {
                count++;
            }
            else if (inventory.content[i].name == "Photo Tour")
            {
                count++;
            }
            else if (inventory.content[i].name == "Photo Ville")
            {
                count++;
            }
        }
        if (count == 5)
        {
            StartEnd = true;
            Lu.SetActive(true);
            NarrationSystem.SetActive(true);
            StandaloneNarration.SetActive(true);
            textToEnter.SetActive(false);
            BoxToBunker.SetActive(false);
            tank.SetActive(true);
        }
    }

    public void FinalSceneTank(PlayableDirector playableDirector)
    {
        if (StartEnd) {
            FirstPersonController[] players = FindObjectsOfType<FirstPersonController>();
            foreach (FirstPersonController camera in players)
            {
                camera.playerCanMove = false;
                camera.cameraCanMove = false;
            }
            player.GetComponent<Rigidbody>().isKinematic = true;
            player.GetComponent<FirstPersonController>().enabled = false;
            player.transform.position = finalPoint.transform.position;
            player.transform.rotation = finalPoint.transform.rotation;
            playableDirector.Play();
            canva.SetActive(false);
        }
    }
}

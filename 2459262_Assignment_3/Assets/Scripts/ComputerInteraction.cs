using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ComputerInteraction : MonoBehaviour
{
    public GameObject interactionPanel;
    private bool isPlayerNearby = false;

    private void Start()
    {
        interactionPanel.SetActive(false);
    }

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
           //might not use
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactionPanel.SetActive(true); 
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactionPanel.SetActive(false);
            isPlayerNearby = false;
        }
    }
}

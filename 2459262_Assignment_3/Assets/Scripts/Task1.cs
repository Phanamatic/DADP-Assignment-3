using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task1 : MonoBehaviour
{
    public GameObject interactionIcon;
    public GameObject colorMatchPanel;
    private bool isPlayerNearby = false;

    private PlayerController playerController; 

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();  // Assuming there is only one PlayerController in the scene.
    }

    void Update()
    {
        if(isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            ToggleTaskPanel();
        }
    }

    private void ToggleTaskPanel()
    {
        bool isActive = colorMatchPanel.activeSelf;
        colorMatchPanel.SetActive(!isActive);  // Toggle the panel state

        if (playerController != null)
        {
            playerController.TogglePlayerMovement(isActive);  // If panel was active, now it's closed so enable movement. Otherwise, disable movement.
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            interactionIcon.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            interactionIcon.SetActive(false);
        }
    }
}

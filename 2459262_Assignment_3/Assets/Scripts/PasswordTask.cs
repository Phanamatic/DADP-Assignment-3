using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Ensure you've imported TextMesh Pro

public class PasswordTask : MonoBehaviour
{
    public GameObject interactionIcon;
    public GameObject passwordPanel;
    public GameObject incorrectResponsePanel;
    public TextMeshProUGUI inputField;
    private bool isPlayerNearby = false;
    public string correctPassword = "age"; // Set this to whatever the correct password is

    public GameObject doorObject;

    void Update()
    {
        if(isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            passwordPanel.SetActive(true);
        }
    }

    public void SubmitPassword()
    {
        if(inputField.text == correctPassword)
        {
            Debug.Log("Correct password, trying to hide the door.");
            doorObject.SetActive(false); 
            passwordPanel.SetActive(false);
            this.enabled = false;
        }
        else
        {
            Debug.Log("Wrong password, showing incorrect panel.");
            Debug.Log($"Entered password: '{inputField.text}'");
            incorrectResponsePanel.SetActive(true);
        }
    }

    public void PasswordBroken()
    {
        doorObject.SetActive(false);   
        passwordPanel.SetActive(false); 
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationArea : MonoBehaviour
{
    public GameObject panel;   
    public GameObject door;        

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && door.activeInHierarchy)
        {
            panel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(false);
        }
    }
}

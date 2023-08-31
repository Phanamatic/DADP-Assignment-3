using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTrigger : MonoBehaviour
{
    public GameObject eIconQuad; // Drag your Quad with the "E" icon here

    public GameObject doorObject;

    private void Start()
    {
        eIconQuad.SetActive(false); // hide it initially
    }

    private void OnTriggerEnter(Collider other)
    {
    if (other.CompareTag("Player") && doorObject.activeInHierarchy) 
    {
        eIconQuad.SetActive(true);
    }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            eIconQuad.SetActive(false); // hide the icon when player leaves
        }
    }
}
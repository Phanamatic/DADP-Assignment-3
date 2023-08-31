using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public GameObject correctColorBox; // Assign in Inspector

    public bool isCorrectlyFilled = false;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == correctColorBox)
        {
            eventData.pointerDrag.transform.position = transform.position; // Position the color box onto the slot
            isCorrectlyFilled = true; // Mark the slot as correctly filled
        }
        else
        {
            isCorrectlyFilled = false;
        }
    }
}
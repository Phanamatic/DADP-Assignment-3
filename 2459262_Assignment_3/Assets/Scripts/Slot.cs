using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public GameObject correctColorBox;

    public bool isCorrectlyFilled = false;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == correctColorBox)
        {
            eventData.pointerDrag.transform.position = transform.position;
            isCorrectlyFilled = true;
        }
        else
        {
            isCorrectlyFilled = false;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waypoint : MonoBehaviour
{
    public Transform target;
    public Camera playerCamera;

    private RectTransform rectTransform;
    private Vector2 screenCenter;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
    }

    private void Update()
    {
        UpdateWaypointPosition();
    }

    void UpdateWaypointPosition()
{
    Vector3 screenPosition = playerCamera.WorldToScreenPoint(target.position);
    
    Vector2 screenPos2D = new Vector2(screenPosition.x, screenPosition.y);
    
    Vector2 direction = (screenPos2D - screenCenter).normalized;
    
    if (screenPosition.z <= 0)
    {
        direction *= -1;
        screenPos2D = screenCenter + direction * 1000;
        
        if (screenPos2D.y > screenCenter.y)
        {
            screenPos2D.y = Screen.height - rectTransform.rect.height / 2;
        }
        else
        {
            screenPos2D.y = 0 + rectTransform.rect.height / 2;
        }
    }

    float clampedX = Mathf.Clamp(screenPos2D.x, 0 + rectTransform.rect.width / 2, Screen.width - rectTransform.rect.width / 2);
    
    rectTransform.position = new Vector2(clampedX, screenPos2D.y);
}


}

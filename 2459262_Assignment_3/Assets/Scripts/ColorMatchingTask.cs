using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorMatchingTask : MonoBehaviour
{
    public GameObject taskPanel;
    public Slot[] colorSlots;

    public int Room1Tasks = 0;

    public GameObject finalDoor;

    private bool taskCompleted = false;

    public GameObject colorMatchPanel;

    public List<Slot> slots;

    private PlayerController playerController;

    public TextMeshProUGUI taskCompletionText;

    public Image taskProgressBar;

    public GameObject taskQuad;
    

    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (IsTaskComplete() && !taskCompleted)
        {
            taskCompleted = true;
            taskPanel.SetActive(false);
            Room1Tasks++;
            Room1Tasks++;
            Room1Tasks++;
            Room1Tasks++;
            Room1Tasks++;
            
            playerController.TogglePlayerMovement(true);
            taskCompletionText.text = $"Tasks Completed: {Room1Tasks}/5";

            float progress = Room1Tasks / 5.0f;
            taskProgressBar.fillAmount = progress;
            taskQuad.SetActive(false);
            
            if (Room1Tasks >= 5)
            {
                finalDoor.SetActive(false);
            }
        }
    }

    bool IsTaskComplete()
    {
        foreach (var slot in colorSlots)
        {
            if (!slot.isCorrectlyFilled)
                return false;
        }
        return true;
    }

    private void CheckTaskCompletion()
    {
        foreach (Slot slot in slots)
        {
            if (!slot.isCorrectlyFilled)
            {
                return;
            }
        }

        
        taskCompleted = true;

        colorMatchPanel.SetActive(false);
    }
}

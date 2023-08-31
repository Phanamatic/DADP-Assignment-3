using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorMatchingTask : MonoBehaviour
{
    public GameObject taskPanel;
    public Slot[] colorSlots; // Assign in Inspector

    public static int Room1Tasks = 0;

    public Animator doorAnimator; // Animator for the door, with an animation named "OpenDoor"

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
            if (Room1Tasks >= 3)
            {
                doorAnimator.Play("OpenDoor");
            }

            playerController.TogglePlayerMovement(true);
            taskCompletionText.text = $"Tasks Completed: {Room1Tasks}/5";

            float progress = Room1Tasks / 3.0f;  // This will give a value between 0 and 1
            taskProgressBar.fillAmount = progress;
            taskQuad.SetActive(false);
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
            return;  // If any slot is not correctly filled, we just return
        }
    }

    // If we've reached here, all slots are correctly filled
    taskCompleted = true;

    // Hide the panel
    colorMatchPanel.SetActive(false);
    }
}

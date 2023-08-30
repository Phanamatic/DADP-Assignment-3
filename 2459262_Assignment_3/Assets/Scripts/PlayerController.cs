using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 2f;
    public float gravity = -9.81f; // Gravity force, can adjust if needed.
    public float jumpHeight = 2.0f;

    private CharacterController characterController;
    private Vector3 velocity;  // Vector3 to store our downward force in (gravity)
    private bool isGrounded;
   // private float groundCheckDistance = 0.4f;
    private float pitch = 0f;

    public float sprintSpeedMultiplier = 1.5f; // Sprinting increases speed by this factor
    public bool isSprinting = false;

    public Image healthBarFill;
    public Image oxygenBarFill;
    public RawImage mapDisplay;

    private float maxHealth = 100f;
    private float maxOxygen = 100f;

    private PlayerStatus playerStatus;

    private bool isDead = false;

    public bool IsPlayerAlive()
    {
    return !isDead;
    }

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // lock the cursor to the center of the screen
        playerStatus = GetComponent<PlayerStatus>();

    }

    void Update()
    {
        if (isDead) return; 

        isGrounded = characterController.isGrounded; // This checks if the character is on the ground
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;  // This ensures that the character is "stuck" to the ground
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
        isSprinting = true;
        }
        else
        {
        isSprinting = false;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float currentSpeed = isSprinting ? speed * sprintSpeedMultiplier : speed;  // Use isSprinting to adjust speed
        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * currentSpeed * Time.deltaTime); 

        // Jumping logic
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        // Handle mouse look
        float yaw = Input.GetAxis("Mouse X") * mouseSensitivity;
        float pitchDelta = Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch - pitchDelta, -90f, 90f); // restrict pitch to prevent over rotation

        transform.Rotate(Vector3.up * yaw);
        Camera.main.transform.localEulerAngles = new Vector3(pitch, 0f, 0f);

        healthBarFill.fillAmount = playerStatus.health / maxHealth;
        oxygenBarFill.fillAmount = playerStatus.oxygen / maxOxygen;


        void UpdateMapDisplay()
    {
    // Update your map display logic here
    }
    }
}

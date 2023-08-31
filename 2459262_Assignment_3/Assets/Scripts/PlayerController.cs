using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 2f;
    public float gravity = -9.81f;
    public float jumpHeight = 2.0f;

    private CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;
   // private float groundCheckDistance = 0.4f;
    private float pitch = 0f;

    public float sprintSpeedMultiplier = 1.5f;
    public bool isSprinting = false;

    public Image healthBarFill;
    public Image oxygenBarFill;
    public RawImage mapDisplay;

    private float maxHealth = 100f;
    private float maxOxygen = 100f;

    private PlayerStatus playerStatus;

    private bool isDead = false;

    public bool canMove = true; 

    public bool IsPlayerAlive()
    {
    return !isDead;
    }

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        playerStatus = GetComponent<PlayerStatus>();

    }

    void Update()
    {
        if (isDead || !canMove) return;

        isGrounded = characterController.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
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
        float currentSpeed = isSprinting ? speed * sprintSpeedMultiplier : speed;
        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * currentSpeed * Time.deltaTime); 

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        float yaw = Input.GetAxis("Mouse X") * mouseSensitivity;
        float pitchDelta = Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch - pitchDelta, -90f, 90f);

        transform.Rotate(Vector3.up * yaw);
        Camera.main.transform.localEulerAngles = new Vector3(pitch, 0f, 0f);

        healthBarFill.fillAmount = playerStatus.health / maxHealth;
        oxygenBarFill.fillAmount = playerStatus.oxygen / maxOxygen;
    }

    public void TogglePlayerMovement(bool enable)
    {
        canMove = enable;
        Cursor.lockState = enable ? CursorLockMode.Locked : CursorLockMode.None;
    }
}

using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public float health = 100f;
    public float oxygen = 100f;
    public float oxygenDepletionRate = 100.0f;
    public bool isInOxygenZone = false;

    private PlayerController playerController;

    private bool isDead = false;
    public GameObject deathScreenUI;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        HandleOxygenDepletion();
        HandleHealthDepletion();
    }

    void HandleOxygenDepletion()
    {
    float adjustment = oxygenDepletionRate * Time.deltaTime;

    if (!isInOxygenZone)
    {
        if (playerController.isSprinting)
        {
            adjustment *= 2;
        }
        oxygen = Mathf.Clamp(oxygen - adjustment, 0, 100);
    }
    else
    {
        oxygen = Mathf.Clamp(oxygen + adjustment, 0, 100);
    }
    }

    void HandleHealthDepletion()
    {
    if(oxygen <= 0)
    {
        health -= oxygenDepletionRate * Time.deltaTime;
        health = Mathf.Clamp(health, 0, 100);

        if(health <= 0 && !isDead)
        {
            PlayerDeath();
        }
    }
    }

    void PlayerDeath()
    {
    isDead = true;
    deathScreenUI.SetActive(true); 
    playerController.enabled = false;
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true; 
    }
}

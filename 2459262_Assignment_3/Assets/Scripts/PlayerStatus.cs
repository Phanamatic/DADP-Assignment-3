using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public float health = 100f;
    public float oxygen = 100f;
    public float oxygenDepletionRate = 2.0f; // oxygen depletes by this amount per second
    public bool isInOxygenZone = false; // check if player is in an oxygen zone

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
            adjustment *= 2;  // double the depletion rate
        }
        oxygen = Mathf.Clamp(oxygen - adjustment, 0, 100);
    }
    else
    {
        // Replenish the oxygen when in the oxygen zone.
        // You can use a different rate for replenishment if needed.
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

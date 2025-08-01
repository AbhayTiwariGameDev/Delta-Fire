using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets; // Assuming you have a namespace for your starter assets

public class PlayerHealth : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] int startingHealth = 5;
    [SerializeField] CinemachineVirtualCamera deathVirtualCamera;
    [SerializeField] Image[] shieldBars; // Assuming you have a UI with shield bars
    [SerializeField] GameObject gameOverContainer; // GameObject to show when the player dies

    int currentHealth;
    int gameOverVirtualCameraPriority = 20;

    void Awake()
    {
        currentHealth = startingHealth;
        AdjustShieldUI(); // Initialize shield UI
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        AdjustShieldUI();

        if (currentHealth <= 0)
        {
            PlayerGameOver();
        }

    }

    void PlayerGameOver()
    {
        deathVirtualCamera.Priority = gameOverVirtualCameraPriority;
        gameOverContainer.SetActive(true); // Show game over UI
        StarterAssetsInputs starterAssetsInputs = FindFirstObjectByType<StarterAssetsInputs>();
        starterAssetsInputs.SetCursorState(false);

        Destroy(this.gameObject);
    }

    void AdjustShieldUI()
    {
        for (int i = 0; i < shieldBars.Length; i++)
        {
            if (i < currentHealth)
            {
                shieldBars[i].gameObject.SetActive(true); // Show shield bar
            }
            else
            {
                shieldBars[i].gameObject.SetActive(false); // Hide shield bar
            }
        }
    }
    
}

using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] GameObject robotExplosionVFX;
    [SerializeField] int startingHealth = 3;

    int currentHealth;

    GameManager gm;
    AudioSource audioSource;

    void Awake()
    {
        currentHealth = startingHealth;
        audioSource  = GetComponent<AudioSource>();
        gm           = FindFirstObjectByType<GameManager>();

        // ✅ COUNT THIS ENEMY THE MOMENT IT SPAWNS
        gm.AdjustEnemiesLeft(+1);
    }

    // ✅ IF THE OBJECT IS EVER DESTROYED (for ANY reason) we guarantee the “‑1”
    void OnDestroy()
    {
        // If the scene is unloading, gm might already be null – safe‑guard it.
        if (gm != null)
            gm.AdjustEnemiesLeft(-1);
    }

    // ------------ existing damage logic -------------
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            gm.AdjustScore(startingHealth);   // reward points
            SelfDestruct();
        }
    }

    public void SelfDestruct()
    {
        Instantiate(robotExplosionVFX, transform.position, Quaternion.identity);

        // Play the clip at the world‑point so it survives this object’s destruction
        if (audioSource != null && audioSource.clip != null)
            AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);

        Destroy(gameObject);
    }
}

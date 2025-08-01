using System.Collections;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    [SerializeField] GameObject robotPrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float spawnTime = 5f;
    PlayerHealth playerHealth;
    void Start()
    {
        playerHealth = FindFirstObjectByType<PlayerHealth>();
        StartCoroutine(SpawnRoutine());
    }
    IEnumerator SpawnRoutine()
    {
        while (playerHealth)
        { 
        Instantiate(robotPrefab, spawnPoint.position, transform.rotation);
        yield return new WaitForSeconds(spawnTime);
    }
    }
}

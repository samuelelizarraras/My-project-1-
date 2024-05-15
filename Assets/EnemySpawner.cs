using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject lightEnemyPrefab; // Prefab for the light enemy
    public GameObject mediumEnemyPrefab; // Prefab for the medium enemy
    public GameObject heavyEnemyPrefab; // Prefab for the heavy enemy

    public float spawnInterval = 5f; // Interval between spawns
    private float nextSpawnTime; // Time of the next spawn

    void Start()
    {
        // Set the initial spawn time
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
        // Check if it's time to spawn an enemy
        if (Time.time >= nextSpawnTime)
        {
            // Reset the next spawn time
            nextSpawnTime = Time.time + spawnInterval;

            // Spawn a random enemy type
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        // Randomly select an enemy type
        int enemyType = Random.Range(0, 3); // 0: light, 1: medium, 2: heavy

        // Spawn the selected enemy type
        GameObject enemyPrefab = null;
        switch (enemyType)
        {
            case 0:
                enemyPrefab = lightEnemyPrefab;
                break;
            case 1:
                enemyPrefab = mediumEnemyPrefab;
                break;
            case 2:
                enemyPrefab = heavyEnemyPrefab;
                break;
        }

        if (enemyPrefab != null)
        {
            // Spawn the enemy
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }
}

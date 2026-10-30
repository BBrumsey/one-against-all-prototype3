using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;

    public int totalEnemies = 5;
    public float spawnInterval = 2f;

    private int enemiesSpawned;
    private float nextSpawnTime;

    void Update()
    {
        if (enemiesSpawned >= totalEnemies)
        {
            return;
        }

        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();

            enemiesSpawned++;
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        Instantiate(
            enemyPrefab,
            spawnPoint.position,
            Quaternion.identity
        );
    }
}
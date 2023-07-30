using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Prefab;  // The prefab of the enemy object to spawn
    public float spawnInterval = 1f;  // The interval between each enemy spawn
    public int spawnCount = 10;  // The number of enemies to spawn
    public float spawnDuration = 10f;  // The duration of enemy spawning in seconds


    private int currentSpawnCount;  // Counter for the number of enemies spawned
    private float spawnTimer;  // Timer for enemy spawning

    public Transform targetTransform;  // The target for the enemy to go towards
    
    private void Start()
    {
        spawnTimer = spawnInterval;
        currentSpawnCount = 0;
        StartCoroutine(SpawnEnemies());
    }



    private IEnumerator SpawnEnemies()
    {
        while (currentSpawnCount < spawnCount && spawnTimer <= spawnDuration)
        {
            yield return new WaitForSeconds(spawnInterval);

            SpawnEnemy();
            currentSpawnCount++;
            spawnTimer += spawnInterval;
        }
    }

    private void SpawnEnemy()
    {
        GameObject enemy = Instantiate(Prefab, transform.position, Quaternion.identity);
        EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();

        if (enemyMovement != null)
            {
                enemyMovement.target = targetTransform;
            }


    }
}

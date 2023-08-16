using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerX2 : MonoBehaviour
{

    public GameObject enemy;
    public float spawnRate = 1f;
    private float nextSpawn;

    
    void Update()
    {
        if (nextSpawn < Time.time)
        {
            GameObject enemySpawned = Instantiate(enemy, this.transform.position, Quaternion.identity);
            nextSpawn = Time.time + spawnRate;
        }
    }
}

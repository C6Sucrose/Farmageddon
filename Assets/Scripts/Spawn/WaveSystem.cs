using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public Transform boss;
        public int noEnemies;
        public float spawnRate;
        public bool isBoss;
    }

    public enum SpawnState { Spawn, Wait, Count };
    private SpawnState state =  SpawnState.Count;
    public Transform[] spawnPoints;
    public Transform target;
    public Transform bossSpawnPoint;

    public Wave[] waves;
    public float timeToNextWave = 5f;
    private int nextWave = 0;
    private float waveCountDown;
    private float aliveCountDown = 1f;

    void Start()
    {
        waveCountDown = timeToNextWave;
    }

    void Update()
    {
        if (state == SpawnState.Wait)
        {
            if (!IsAlive())
            {
                WaveComplete();
            }
            else
            {
                return;
            }
        }
        

        if (waveCountDown <= 0)
        {
            if (state != SpawnState.Spawn)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountDown -= Time.deltaTime;
        }
    }

    IEnumerator SpawnWave (Wave wave)
    {
        state = SpawnState.Spawn;

        if (wave.isBoss)
        {
            SpawnBoss(wave.boss);
        }

        for (int i = 0; i < wave.noEnemies; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.spawnRate);
        }

        state = SpawnState.Wait;
        Debug.Log("Spawned New Wave");
        yield break;
    }

    bool IsAlive()
    {
        aliveCountDown -= Time.deltaTime;
        if (aliveCountDown <= 0f)
        {
            aliveCountDown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    void SpawnEnemy (Transform enemy)
    {
        Transform spawn = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Transform _enemy = Instantiate(enemy, spawn.position, spawn.rotation);
        EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();

        if (enemyMovement != null)
        {
            enemyMovement.target = this.target;
        }

        Debug.Log("Spawned Enemy");
    }


    void SpawnBoss(Transform boss)
    {
        Transform _boss = Instantiate(boss, bossSpawnPoint.position, bossSpawnPoint.rotation);
        Debug.Log("Spawned Boss");
    }

    void WaveComplete()
    {
        Debug.Log("Wave finished");
        state = SpawnState.Count;
        waveCountDown = timeToNextWave;
        
        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("All waves finished, restarting");
        }
        else
        {
            nextWave++;
        }
    }
}

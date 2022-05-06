using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner_map1 : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public EnemyClass[] enemies;

        public int EnemyCount;

        public float timeBTWspawns;
    }
    public Wave[] Waves;

    public float timeBTWwaves;

    public Transform[] spawnPoints;

    private Wave currentWave;
    private int currentWaveNumber;
    private Transform player;
    private bool WaveComplete;

    public GameObject boss;
    public Transform boss_spawn;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(BeginNext_Wave(currentWaveNumber));
    }

    IEnumerator BeginNext_Wave(int number)
    {
        yield return new WaitForSeconds(timeBTWwaves);
        StartCoroutine(SpawnWave(number));
    }

    IEnumerator SpawnWave(int number)
    {
        currentWave = Waves[number];

        for(int i = 0; i < currentWave.EnemyCount; i++)
        {
            if(player == null)
            {
                yield break;
            }

            EnemyClass SpawnRandonEnemy = currentWave.enemies[Random.Range(0, currentWave.enemies.Length)];
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(SpawnRandonEnemy, randomSpawnPoint.position, randomSpawnPoint.rotation);
            if (i == currentWave.EnemyCount - 1)
            {
                WaveComplete = true;
            }
            else
            {
                WaveComplete = false;
            }
            yield return new WaitForSeconds(currentWave.timeBTWspawns);
        }
    }

    private void Update()
    {
        if (WaveComplete == true && GameObject.FindGameObjectsWithTag("Skeleton_Melee").Length == 0 && GameObject.FindGameObjectsWithTag("FireSnake").Length == 0 
            && GameObject.FindGameObjectsWithTag("DeathBringer").Length == 0)
        {
            WaveComplete = false;
            if(currentWaveNumber + 1 < Waves.Length)
            {
                currentWaveNumber++;
                StartCoroutine(BeginNext_Wave(currentWaveNumber));
            }
            else
            {
                Instantiate(boss, boss_spawn.position, boss_spawn.rotation);
            }
        }
    }
}

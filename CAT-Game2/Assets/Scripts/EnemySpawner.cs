using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject[] enemyPrefabs;
    private List<int> usedPoints = new List<int>();
    private int enemiesSpawned = 0;
    private int maxEnemies = 2;

    private void Awake()
    {
        enemiesSpawned = 0;
    }

    private void Update()
    {
        if(enemiesSpawned < maxEnemies)
        {
            SpawnEnemy();
            enemiesSpawned += 1;
        }
    }

    private void SpawnEnemy()
    {
        int randomEnemy = Random.Range(0, enemyPrefabs.Length);
        int randomPos = Random.Range(0, spawnPoints.Length);
        
        Instantiate(enemyPrefabs[randomEnemy], spawnPoints[randomPos]);
    }
}

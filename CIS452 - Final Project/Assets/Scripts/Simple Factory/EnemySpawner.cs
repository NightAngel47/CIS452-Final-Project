using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Simple_Factory
{
    [RequireComponent(typeof(EnemyFactory))]
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField, Tooltip("The type of enemy to spawn.")] private EnemyFactory.EnemyTypes enemyType;
        [SerializeField, Tooltip("The minimum spawn rate for random spawn time."), Range(0.1f, 10f)] private float minSpawnRate = 1;
        [SerializeField, Tooltip("The maximum spawn rate for random spawn time."), Range(0.1f, 10f)] private float maxSpawnRate = 2;
        
        private EnemyFactory enemyFactory;
        private Vector3 spawnPos;

        private void Awake()
        {
            enemyFactory = GetComponent<EnemyFactory>();
        }

        private void Start()
        {
            StartCoroutine(SpawnEnemy());
        }

        private IEnumerator SpawnEnemy()
        {
            spawnPos = transform.position;
            Instantiate(enemyFactory.EnemyToSpawn(enemyType), spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(minSpawnRate, maxSpawnRate));
            StartCoroutine(SpawnEnemy());
        }
    }
}
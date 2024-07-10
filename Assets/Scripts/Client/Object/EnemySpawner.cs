using System.Collections;
using Client.Object.Pool;
using UnityEngine;

namespace Client.Object
{
    public class EnemySpawner : MonoBehaviour
    {
        public GameObject enemyPrefab;
        public int initialPoolSize = 5;
        public int maxPoolSize = 10;
        public float spawnInterval = 3f;
        public int spawnCount = 1;
        public float spawnRadius = 5f;

        private void Start()
        {
            SingletonObjectPool<Enemy>.Instance.Init(enemyPrefab.GetComponent<Enemy>(), initialPoolSize, maxPoolSize);
            StartCoroutine(SpawnEnemiesCoroutine());
        }

        private IEnumerator SpawnEnemiesCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(spawnInterval);
                SpawnEnemies();
            }
        }

        private void SpawnEnemies()
        {
            for (var i = 0; i < spawnCount; i++)
            {
                var spawnPosition = transform.position + (Vector3)Random.insideUnitCircle * spawnRadius;
                SingletonObjectPool<Enemy>.Instance.Spawn(transform).transform.position = spawnPosition;
            }
        }
    }
}
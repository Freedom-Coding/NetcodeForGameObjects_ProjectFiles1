using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int maxEnemyCount = 5;
    [SerializeField] private float spawnCooldown = 2;
    [SerializeField] private Transform enemyPrefab;
    [SerializeField] private Vector2 minSpawnPos;
    [SerializeField] private Vector2 maxSpawnPos;

    public List<Transform> enemies = new List<Transform>();

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (enemies.Count < maxEnemyCount)
            {
                Vector2 spawnPos = new Vector2(Random.Range(minSpawnPos.x, maxSpawnPos.x), Random.Range(minSpawnPos.y, maxSpawnPos.y));
                Transform enemyTransform = Instantiate(enemyPrefab, spawnPos, Quaternion.identity, transform);
                enemyTransform.GetComponent<Enemy>().enemySpawner = this;
                enemies.Add(enemyTransform);

                yield return new WaitForSeconds(spawnCooldown);
            }

            yield return null;
        }
    }
}

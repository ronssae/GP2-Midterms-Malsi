using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemyPrefab;
    public float spawnInterval;

    private bool shouldSpawn = true;
    private Coroutine spawnCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        spawnCoroutine = StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnEnemies()
    {
        while (shouldSpawn)
        {
            int randomSpawnPoint = Random.Range(0, spawnPoints.Length);

            GameObject newEnemy = Instantiate(enemyPrefab, spawnPoints[randomSpawnPoint].position, Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}

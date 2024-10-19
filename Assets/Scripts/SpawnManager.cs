using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance { get; private set; }

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject dropMaterial;
    [SerializeField] private float spawnTimerInit = 0;
    [SerializeField] private float spawnTimerMax = 5.0f; // Spawn every 5 seconds
    [SerializeField] private int initialSpawnCount = 0; // Initial spawn count
    [SerializeField] private int maxSpawnCount = 3;

    private Vector3 SpawnPosForMaterial;

    private float minX = -18f;
    private float maxX = 18f;
    private float minZ = -40f;
    private float maxZ = -10f;
    private float posY = 2.5f;
    private int currentEnemies = 0;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {

    }


    private void Update()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        if (spawnTimerInit <= 10)
        {
            spawnTimerInit += Time.deltaTime;
        }
        if (spawnTimerInit >= spawnTimerMax)
        {
            // Check if we haven't reached the max enemies
            if (currentEnemies < maxSpawnCount)
            {
                Instantiate(enemyPrefab, new Vector3(Random.Range(minX, maxX), posY, Random.Range(minZ, maxZ)), Quaternion.identity);
                currentEnemies++;
                spawnTimerInit = 0;
            }
        }
    }

    public void EnemyKilled()
    {
        // Decrement enemy count and spawn a new enemy if needed
        if (currentEnemies <= 3)
        {
            currentEnemies--;
            SpawnEnemy();
        }
    }

    public void SpawnDropMaterial(Vector3 Position)
    {
        Instantiate(dropMaterial, Position, dropMaterial.transform.rotation);
    }


}


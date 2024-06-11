using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 5f;
    public Transform terrainTransform;
    public float terrainWidth = 200f;
    public float terrainLength = 200f;

    private float timer;

    void Start()
    {
        timer = spawnInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnEnemy();
            timer = spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = GetRandomPositionOnTerrain();
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    Vector3 GetRandomPositionOnTerrain()
    {
        float randomX = Random.Range(terrainTransform.position.x - terrainWidth / 2, terrainTransform.position.x + terrainWidth / 2);
        float randomZ = Random.Range(terrainTransform.position.z - terrainLength / 2, terrainTransform.position.z + terrainLength / 2);

        float randomY = terrainTransform.position.y + 20;

        return new Vector3(randomX, randomY, randomZ);
    }
}

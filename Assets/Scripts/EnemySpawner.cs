using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnRadius = 10f;
    [SerializeField] private float minimumDistance = 5f;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private DynamicObjectPool objectPool;
    private Transform playerTransform;
    private Coroutine myCoroutine;

    public void StartSpawn()
    {
        InitPool();
        myCoroutine = StartCoroutine(SpawnObjects());
    }

    public void StopSpawn()
    {
        StopCoroutine(myCoroutine);
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void SetPlayerPosition(Transform playerTransform)
    {
        this.playerTransform = playerTransform;
        StartSpawn();
    }

    public void InitPool()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        objectPool.InitPool();
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        GameObject enemy = objectPool.GetObject(spawnPosition, Quaternion.identity);

        Enemy enemyController = enemy.GetComponent<Enemy>();
        if (enemyController != null)
        {
            enemyController.SetPlayerPosition(playerTransform);
        }
        enemy.SetActive(true);
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector2 randomCirclePoint = Random.insideUnitCircle * spawnRadius;
        Vector3 randomPosition = new Vector3(randomCirclePoint.x, 0f, randomCirclePoint.y);

        float distanceToPlayer = Vector3.Distance(randomPosition, playerTransform.position);
        while (distanceToPlayer < minimumDistance)
        {
            randomCirclePoint = Random.insideUnitCircle.normalized * spawnRadius;
            randomPosition = new Vector3(randomCirclePoint.x, 0f, randomCirclePoint.y);
            distanceToPlayer = Vector3.Distance(randomPosition, playerTransform.position);
        }

        randomPosition += transform.position;
        return randomPosition;
    }
}

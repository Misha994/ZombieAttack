using UnityEngine;

public class MineSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRadius = 10f;
    [SerializeField] private float minimumDistance = 5f;
    [SerializeField] private int numberOfMines = 10;
    [SerializeField] private GameObject minePrefab;
    private Transform playerTransform;

    private void SpawnMines()
    {
        for (int i = 0; i < numberOfMines; i++)
        {
            Vector3 randomPosition = GetRandomSpawnPosition();
            Instantiate(minePrefab, randomPosition, Quaternion.identity);
        }
    }

    public void SetPlayerPosition(Transform playerTransform)
    {
        this.playerTransform = playerTransform;
        SpawnMines();
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
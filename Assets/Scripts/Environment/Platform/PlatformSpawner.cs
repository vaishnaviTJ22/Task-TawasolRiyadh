using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private GameObject[] platformPrefabs;
    [SerializeField] private int initialPlatformCount = 5;

    private Transform lastSpawnPoint;

    void Start()
    {
        CreatePools();
        SpawnInitialPlatforms();
    }

    void CreatePools()
    {
        int poolSize = initialPlatformCount + 2;

        foreach (GameObject prefab in platformPrefabs)
        {
            if (prefab == null) continue;

            string poolID = prefab.name;
            ObjectPooler.Instance.CreatePool(poolID, prefab, poolSize);
        }
    }

    void SpawnInitialPlatforms()
    {
        GameObject firstPlatform = SpawnRandomPlatform(Vector3.zero);

        if (firstPlatform != null)
        {
            Platform platformScript = firstPlatform.GetComponent<Platform>();
            if (platformScript != null && platformScript.SpawnPoint != null)
            {
                lastSpawnPoint = platformScript.SpawnPoint;

                for (int i = 1; i < initialPlatformCount; i++)
                {
                    SpawnNext();
                }
            }
        }
    }

    public void SpawnNext()
    {
        if (lastSpawnPoint == null) return;

        GameObject newPlatform = SpawnRandomPlatform(lastSpawnPoint.position);

        if (newPlatform != null)
        {
            Platform platformScript = newPlatform.GetComponent<Platform>();
            if (platformScript != null && platformScript.SpawnPoint != null)
            {
                lastSpawnPoint = platformScript.SpawnPoint;
            }
        }
    }

    GameObject SpawnRandomPlatform(Vector3 position)
    {
        if (platformPrefabs.Length == 0) return null;

        GameObject randomPrefab = platformPrefabs[Random.Range(0, platformPrefabs.Length)];
        string poolID = randomPrefab.name;

        GameObject spawned = ObjectPooler.Instance.Spawn(poolID, position, Quaternion.identity);

        if (spawned != null)
        {
            Platform platformScript = spawned.GetComponent<Platform>();
            if (platformScript != null)
            {
                platformScript.PoolID = poolID;
            }
        }

        return spawned;
    }
}

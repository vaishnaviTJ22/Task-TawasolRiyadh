using UnityEngine;

public class Platform : MonoBehaviour
{
    [Header("Required Setup")]
    [SerializeField] private Transform spawnPoint;

    [Header("Settings")]
    [SerializeField] private float despawnDistance = 50f;

    private Transform player;
    private PlatformSpawner spawner;
    private bool hasSpawnedNext;

    public Transform SpawnPoint => spawnPoint;
    public string PoolID { get; set; }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        spawner = FindFirstObjectByType<PlatformSpawner>();
    }

    void OnEnable()
    {
        hasSpawnedNext = false;
        ResetItems();
    }

    void ResetItems()
    {
        Obstacle[] obstacles = GetComponentsInChildren<Obstacle>(true);
        foreach (Obstacle obstacle in obstacles)
        {
            obstacle.gameObject.SetActive(true);
        }

        Collectable[] collectables = GetComponentsInChildren<Collectable>(true);
        foreach (Collectable collectable in collectables)
        {
            collectable.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        if (player == null) return;

        float distance = player.position.z - transform.position.z;

        if (distance > despawnDistance)
        {
            ReturnToPool();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasSpawnedNext && spawner != null)
        {
            hasSpawnedNext = true;
            spawner.SpawnNext();
        }
    }

    void ReturnToPool()
    {
        if (!string.IsNullOrEmpty(PoolID) && ObjectPooler.Instance != null)
        {
            ObjectPooler.Instance.Despawn(PoolID, gameObject);
        }
    }
}

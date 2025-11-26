using UnityEngine;

public class SpeedController : MonoBehaviour
{
    public static SpeedController Instance;

    [Header("Speed Settings")]
    [SerializeField] private float initialSpeed = 5f;
    [SerializeField] private float acceleration = 0.1f;
    [SerializeField] private float maxSpeed = 15f;

    public float currentSpeed;
    private bool isActive = true;

   

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        isActive = true;
        currentSpeed = initialSpeed;
    }

    void Update()
    {
        if (!isActive || GameManager.Instance.IsGameOver) return;

        if (currentSpeed < maxSpeed)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
    }

}

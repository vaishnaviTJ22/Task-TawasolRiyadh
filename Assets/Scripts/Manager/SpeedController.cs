using UnityEngine;

public class SpeedController : MonoBehaviour
{
    public static SpeedController Instance;

    [Header("Speed Settings")]
    [SerializeField] private float initialSpeed = 5f;
    [SerializeField] private float acceleration = 0.1f;
    [SerializeField] private float maxSpeed = 15f;

    private float currentSpeed;
    private bool isActive = true;

    public float Speed => currentSpeed;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        currentSpeed = initialSpeed;
    }

    void Update()
    {
        if (!isActive) return;

        if (currentSpeed < maxSpeed)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
    }

    public void Pause() => isActive = false;
    public void Resume() => isActive = true;
}

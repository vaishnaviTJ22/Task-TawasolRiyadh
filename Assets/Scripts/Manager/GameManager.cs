using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game Settings")]
    [SerializeField] private int startingHealth = 3;
    [SerializeField] private int scorePerCollectable = 10;

    private int currentHealth;
    private int currentScore;
    private bool isGameOver = false;

    public int CurrentHealth => currentHealth;
    public int CurrentScore => currentScore;
    public bool IsGameOver => isGameOver;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        InitializeGame();
        SubscribeToEvents();
    }

    void OnDestroy()
    {
        UnsubscribeFromEvents();
    }

    void InitializeGame()
    {
        currentHealth = startingHealth;
        currentScore = 0;
        isGameOver = false;

        EventManager.TriggerHealthChanged(currentHealth);
        EventManager.TriggerScoreChanged(currentScore);
    }

    void SubscribeToEvents()
    {
        EventManager.OnCollectablePickup += HandleCollectablePickup;
        EventManager.OnObstacleHit += HandleObstacleHit;
    }

    void UnsubscribeFromEvents()
    {
        EventManager.OnCollectablePickup -= HandleCollectablePickup;
        EventManager.OnObstacleHit -= HandleObstacleHit;
    }

    void HandleCollectablePickup()
    {
        AddScore(scorePerCollectable);
    }

    void HandleObstacleHit()
    {
        TakeDamage(1);
    }

    public void AddScore(int amount)
    {
        if (isGameOver) return;

        currentScore += amount;
        EventManager.TriggerScoreChanged(currentScore);
    }

    public void TakeDamage(int damage)
    {
        if (isGameOver) return;

        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);

        EventManager.TriggerHealthChanged(currentHealth);

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        isGameOver = true;
        EventManager.TriggerPlayerDeath();
        Debug.Log("Game Over! Final Score: " + currentScore);
    }

    public void RestartGame()
    {
        InitializeGame();
    }
}

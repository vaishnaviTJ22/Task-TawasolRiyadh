using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    public static event Action OnObstacleHit;
    public static event Action OnCollectablePickup;
    public static event Action OnPlayerDeath;
    public static event Action<int> OnScoreChanged;
    public static event Action<int> OnHealthChanged;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public static void TriggerObstacleHit()
    {
        OnObstacleHit?.Invoke();
    }

    public static void TriggerCollectablePickup()
    {
        OnCollectablePickup?.Invoke();
    }

    public static void TriggerPlayerDeath()
    {
        OnPlayerDeath?.Invoke();
    }

    public static void TriggerScoreChanged(int newScore)
    {
        OnScoreChanged?.Invoke(newScore);
    }

    public static void TriggerHealthChanged(int newHealth)
    {
        OnHealthChanged?.Invoke(newHealth);
    }
}

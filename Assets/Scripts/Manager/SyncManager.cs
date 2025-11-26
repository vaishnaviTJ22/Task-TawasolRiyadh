using UnityEngine;
using System.Collections.Generic;

public class SyncManager : MonoBehaviour
{
    public static SyncManager Instance;

    [Header("Sync Settings")]
    [SerializeField] private float networkDelay = 0.1f;
    [SerializeField] private int maxBufferSize = 300;
    [SerializeField] private bool enableInterpolation = true;

    private Queue<PlayerState> stateBuffer = new Queue<PlayerState>();
    private float gameStart;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else { Destroy(gameObject); return; }

        stateBuffer.Clear();
        gameStart = Time.time;
    }

    public void RecordState(PlayerState state)
    {
        if (stateBuffer.Count >= maxBufferSize)
            stateBuffer.Dequeue();

        stateBuffer.Enqueue(state);
    }

    public bool TryGetStateAtTime(float t, out PlayerState state)
    {
        state = default;
        if (stateBuffer.Count == 0) return false;

        PlayerState[] arr = stateBuffer.ToArray();

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i].timestamp >= t)
            {
                if (i == 0)
                {
                    state = arr[0];
                    return true;
                }

                if (enableInterpolation)
                    state = InterpolateStates(arr[i - 1], arr[i], t);
                else
                    state = arr[i - 1];

                return true;
            }
        }

        state = arr[arr.Length - 1];
        return true;
    }

    PlayerState InterpolateStates(PlayerState a, PlayerState b, float target)
    {
        float duration = b.timestamp - a.timestamp;
        if (duration <= 0) return b;

        float t = Mathf.Clamp01((target - a.timestamp) / duration);

        return new PlayerState(
            target,
            Vector3.Lerp(a.position, b.position, t),
            Vector3.Lerp(a.velocity, b.velocity, t),
            Quaternion.Slerp(a.rotation, b.rotation, t),
            t > 0.5f ? b.isJumping : a.isJumping,
            t > 0.5f ? b.isGrounded : a.isGrounded
        );
    }

    public float GetDelayedTime()
    {
        return Time.time - networkDelay;
    }
}

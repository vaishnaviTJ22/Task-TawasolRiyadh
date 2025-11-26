using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform target;

    [Header("Follow Settings")]
    [SerializeField] private Vector3 offset = new Vector3(0f, 5f, -10f);
    [SerializeField] private float smoothSpeed = 5f;

    [Header("Shake Settings")]
    [SerializeField] private float shakeDuration = 0.3f;
    [SerializeField] private float shakeMagnitude = 0.5f;

    private bool isShaking = false;

    void Start()
    {
        EventManager.OnObstacleHit += TriggerShake;
    }

    void OnDestroy()
    {
        EventManager.OnObstacleHit -= TriggerShake;
    }

    void TriggerShake()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        Vector3 originalPos = transform.localPosition;

        float duration = 0.3f;
        float strength = 0.25f;
        float time = 0f;

        while (time < duration)
        {
            transform.localPosition = originalPos + Random.insideUnitSphere * strength;
            time += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPos;
    }
}

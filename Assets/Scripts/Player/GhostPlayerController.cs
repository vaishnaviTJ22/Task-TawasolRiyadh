using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GhostPlayerController : MonoBehaviour
{
    [SerializeField] private float interpolationSpeed = 10f;

    private Rigidbody rb;

    private Vector3 targetPos;
    private Quaternion targetRot;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    void Update()
    {
        float delayedTime = SyncManager.Instance.GetDelayedTime();

        if (SyncManager.Instance.TryGetStateAtTime(delayedTime, out PlayerState state))
        {
            targetPos = state.position;
            targetRot = state.rotation;
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, Time.deltaTime * interpolationSpeed);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRot, Time.deltaTime * interpolationSpeed);
    }
}

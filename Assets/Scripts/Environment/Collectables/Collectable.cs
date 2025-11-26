using UnityEngine;

public class Collectable : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int scoreValue = 10;
    [SerializeField] private bool rotateAnimation = true;
    [SerializeField] private float rotationSpeed = 100f;

    private bool isCollected = false;

    void OnEnable()
    {
        isCollected = false;
    }

    void Update()
    {
        if (rotateAnimation)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (isCollected) return;

        if (other.CompareTag("Player"))
        {
            isCollected = true;
            EventManager.TriggerCollectablePickup();
            gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private bool disableOnHit = true;

    [Header("Dissolve Effect")]
    [SerializeField] private bool useDissolveEffect = true;
    [SerializeField] private float dissolveDuration = 0.5f;
    [SerializeField] private string dissolveProperty = "_Value";

    private Material mat;
    private Renderer rend;
    private bool isDissolving = false;

    void Awake()
    {
        rend = GetComponent<Renderer>();
        if (rend != null)
        {
            mat = rend.material;
        }
    }

    void OnEnable()
    {
        isDissolving = false;
        if (mat != null)
        {
            mat.SetFloat(dissolveProperty, 0f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (isDissolving) return;

        if (other.CompareTag("Player"))
        {
            EventManager.TriggerObstacleHit();

            if (disableOnHit)
            {
                if (useDissolveEffect && mat != null)
                {
                    StartCoroutine(DissolveEffect());
                }
                else
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }

    IEnumerator DissolveEffect()
    {
        isDissolving = true;
        float t = 0f;

        while (t < dissolveDuration)
        {
            float v = t / dissolveDuration;
            mat.SetFloat(dissolveProperty, v);
            t += Time.deltaTime;
            yield return null;
        }

        mat.SetFloat(dissolveProperty, 1f);
        gameObject.SetActive(false);
    }

    void OnDestroy()
    {
        if (mat != null)
        {
            Destroy(mat);
        }
    }
}

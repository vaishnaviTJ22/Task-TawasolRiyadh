using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;

    private Dictionary<string, Queue<GameObject>> pools = new Dictionary<string, Queue<GameObject>>();
    private Dictionary<string, GameObject> prefabs = new Dictionary<string, GameObject>();
    private Transform poolContainer;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        poolContainer = new GameObject("--- POOLS ---").transform;
        poolContainer.SetParent(transform);
    }

    public void CreatePool(string poolID, GameObject prefab, int size)
    {
        if (pools.ContainsKey(poolID))
            return;

        Queue<GameObject> objectQueue = new Queue<GameObject>();
        prefabs[poolID] = prefab;

        Transform poolParent = new GameObject($"Pool: {poolID}").transform;
        poolParent.SetParent(poolContainer);

        for (int i = 0; i < size; i++)
        {
            GameObject obj = Instantiate(prefab, poolParent);
            obj.name = prefab.name;
            obj.SetActive(false);
            objectQueue.Enqueue(obj);
        }

        pools[poolID] = objectQueue;
    }

    public GameObject Spawn(string poolID, Vector3 position, Quaternion rotation)
    {
        if (!pools.ContainsKey(poolID))
            return null;

        GameObject obj;

        if (pools[poolID].Count > 0)
        {
            obj = pools[poolID].Dequeue();
        }
        else
        {
            obj = Instantiate(prefabs[poolID]);
            obj.name = prefabs[poolID].name + "_Extra";
        }

        obj.transform.SetPositionAndRotation(position, rotation);
        obj.SetActive(true);
        return obj;
    }

    public void Despawn(string poolID, GameObject obj)
    {
        if (!pools.ContainsKey(poolID))
        {
            Destroy(obj);
            return;
        }

        obj.SetActive(false);
        Transform parent = poolContainer.Find($"Pool: {poolID}");
        if (parent != null)
            obj.transform.SetParent(parent);

        pools[poolID].Enqueue(obj);
    }
}

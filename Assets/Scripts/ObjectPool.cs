using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;

    private Queue<GameObject> availableObjects = new Queue<GameObject>();

    public static ObjectPool Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        GrowPool(10);
    }

    public GameObject GetFromPool()
    {
        if (availableObjects.Count == 0)
            GrowPool(3);

        var instance = availableObjects.Dequeue();
        instance.SetActive(true);
        return instance;
    }

    private void GrowPool(int size)
    {
        for (int i = 0; i < size; i++)
        {
            var instanceToAdd = Instantiate(prefab);
            instanceToAdd.transform.SetParent(transform);
            AddToPool(instanceToAdd);
        }
    }

    public void AddToPool(GameObject instance)
    {
        instance.SetActive(false);
        availableObjects.Enqueue(instance);
    }
}
using UnityEngine;
using System.Collections.Generic;

public class DynamicObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int initialSize = 10;
    [SerializeField] private int maxSize = 20;

    private List<GameObject> objectPool;

    public void InitPool()
    {
        objectPool = new List<GameObject>();
        for (int i = 0; i < initialSize; i++)
        {
            CreateObject();
        }
    }

    private void CreateObject()
    {
        GameObject obj = Instantiate(prefab);
        obj.SetActive(false);
        objectPool.Add(obj);
    }

    public GameObject GetObject(Vector3 spawnPosition, Quaternion rotation)
    {
        for (int i = 0; i < objectPool.Count; i++)
        {
            if (!objectPool[i].activeInHierarchy)
            {
                objectPool[i].transform.position = spawnPosition;
                objectPool[i].transform.rotation = rotation;
                return objectPool[i];
            }
        }

        if (objectPool.Count < maxSize)
        {
            GameObject newObj = Instantiate(prefab, spawnPosition, rotation);
            objectPool.Add(newObj);
            return newObj;
        }

        return null;
    }
}
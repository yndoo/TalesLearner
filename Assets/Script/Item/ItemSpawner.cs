using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public List<Vector3> spawnPosition;
    public List<ItemObject> spawnedObjects;

    private float updateTerm = 5f;
    private float lastUpdateTime = 0;

    private void Awake()
    {
        spawnedObjects = new List<ItemObject>();
    }

    private void Start()
    {
        for (int i = 0; i < spawnPosition.Count; i++)
        {
            ItemObject item = ItemPool.Instance.Get();
            spawnedObjects.Add(item);
            item.transform.parent = transform;
            item.transform.localPosition = spawnPosition[i];
        }
    }
    private void Update()
    {
        if(Time.time -  lastUpdateTime > updateTerm)
        {
            lastUpdateTime = Time.time;

            for (int i = 0; i < spawnedObjects.Count; i++)
            {
                if (spawnedObjects[i].gameObject.activeSelf == false)
                {
                    ItemObject item = ItemPool.Instance.Get();
                    spawnedObjects[i] = item;
                    item.transform.parent = transform;
                    item.transform.localPosition = spawnPosition[i];
                }
            }
        }
    }
}

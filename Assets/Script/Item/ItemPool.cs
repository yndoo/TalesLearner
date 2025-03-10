using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ItemPool : MonoBehaviour
{
    private static ItemPool instance;
    public static ItemPool Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new ItemPool();
            }
            return instance;
        }
    }

    private ObjectPool<ItemObject> pool;

    public List<ItemObject> itemPrefabs;
    public int poolSize = 5;

    private void Awake()
    {
        instance = this;
        pool = new ObjectPool<ItemObject>(itemPrefabs, 5, transform);
    }

    public ItemObject Get()
    {
        return pool.Get();
    }

    public void Return(ItemObject item)
    {
        item.transform.parent = transform;
        pool.Return(item);
    }
}

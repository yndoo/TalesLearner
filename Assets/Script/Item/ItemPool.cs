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
    //private Dictionary<ItemType, ObjectPool<ItemObject>> pool = new Dictionary<ItemType, ObjectPool<ItemObject>>(); // 아이템 타입별 풀
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

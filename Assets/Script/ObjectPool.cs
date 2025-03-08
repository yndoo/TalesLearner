using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    private Queue<T> pool = new Queue<T>();
    private T prefab;
    private Transform parent;

    // 생성자에서 initialSize만큼 만들어서 pool에 넣어놓기
    public ObjectPool(T prefab, int initialSize, Transform parent = null)
    {
        this.prefab = prefab;
        this.parent = parent;

        for(int i = 0; i < initialSize; i++)
        {
            T obj = Instantiate(prefab, parent);
            obj.gameObject.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    // 프리팹 여러종류 initialSize씩 생성
    public ObjectPool(List<T> prefabs, int initialSize, Transform parent = null)
    {
        this.prefab = prefabs[0];
        this.parent = parent;

        for(int i = 0; i < initialSize; i++)
        {
            for (int j = 0; j < prefabs.Count; j++)
            {
                T obj = Instantiate(prefabs[j], parent); // 종류별로 번갈아가며 생성
                obj.gameObject.SetActive(false);
                pool.Enqueue(obj);
            }
        }
    }

    // pool에 남아있다면 빼서 주고, 없다면 새로 만들어서 줌
    public T Get()
    {
        if(pool.Count > 0)
        {
            T obj = pool.Dequeue();
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            T obj = Instantiate(prefab, parent);
            return obj;
        }
    }

    // 반환된 오브젝트는 비활성화시켜서 다시 갖고 있기
    public void Return(T obj)
    {
        obj.gameObject.SetActive(false);
        pool.Enqueue(obj);
    }
}

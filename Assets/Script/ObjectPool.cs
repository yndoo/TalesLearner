using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    private Queue<T> pool = new Queue<T>();
    private T prefab;
    private Transform parent;

    // �����ڿ��� initialSize��ŭ ���� pool�� �־����
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

    // ������ �������� initialSize�� ����
    public ObjectPool(List<T> prefabs, int initialSize, Transform parent = null)
    {
        this.prefab = prefabs[0];
        this.parent = parent;

        for(int i = 0; i < initialSize; i++)
        {
            for (int j = 0; j < prefabs.Count; j++)
            {
                T obj = Instantiate(prefabs[j], parent); // �������� �����ư��� ����
                obj.gameObject.SetActive(false);
                pool.Enqueue(obj);
            }
        }
    }

    // pool�� �����ִٸ� ���� �ְ�, ���ٸ� ���� ���� ��
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

    // ��ȯ�� ������Ʈ�� ��Ȱ��ȭ���Ѽ� �ٽ� ���� �ֱ�
    public void Return(T obj)
    {
        obj.gameObject.SetActive(false);
        pool.Enqueue(obj);
    }
}

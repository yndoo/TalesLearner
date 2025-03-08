using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public List<Vector3> spawnPosition;

    private void Awake()
    {
        //spawnPosition = new List<Vector3>
        //    {
        //        new Vector3(0, 0, 0),
        //        new Vector3(2, 2, 2),
        //    };
    }

    private void Start()
    {
        for(int i = 0; i < spawnPosition.Count; i++)
        {
            ItemPool.Instance.Get().transform.localPosition = spawnPosition[i];
        }
    }
}

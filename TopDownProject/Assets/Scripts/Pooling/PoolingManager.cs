using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    public static PoolingManager Instance { get; private set; }
    [SerializeField]
    private Transform poolParent;
    private Dictionary<GameObject, Queue<GameObject>> pools = new Dictionary<GameObject, Queue<GameObject>>();
    private Dictionary<GameObject, Queue<GameObject>> spawnedObjects = new Dictionary<GameObject, Queue<GameObject>>();

    private void Awake()
    {
        Instance = this;
    }

    private void CreatePool(GameObject prefab)
    {
        pools.Add(prefab, new Queue<GameObject>());
    }


    public GameObject GetFromPool(GameObject prefab, Vector3 pos, Quaternion rot)
    {
        if (!pools.ContainsKey(prefab))
        {
            CreatePool(prefab);
        }
        GameObject result;
        if(pools[prefab].Count == 0)
        {
            result = Instantiate(prefab);
        }
        else
        {
            result = pools[prefab].Dequeue();
        }

        result.transform.position = pos;
        result.transform.rotation = rot;
        result.SetActive(true);
        spawnedObjects.Add(result, pools[prefab]);
        return result;
    }

    public void ReturnToPool(GameObject obj)
    {
        if(!spawnedObjects.TryGetValue(obj, out var poolRef))
        {
            Destroy(obj); //not a pooled object
            return;
        }
        obj.SetActive(false);
        obj.transform.parent = poolParent;
        poolRef.Enqueue(obj);
    }
}

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    public static PoolingManager Instance { get; private set; }

    [SerializeField]
    private Transform poolParent;
    private Dictionary<GameObject, Queue<GameObject>> pools = new Dictionary<GameObject, Queue<GameObject>>();

    private void Awake()
    {
        Instance = this;
    }

    private void CreatePool(GameObject prefab)
    {
        pools.Add(prefab, new Queue<GameObject>());
    }

    private void CheckPool(GameObject prefab)
    {
        if (!pools.ContainsKey(prefab))
        {
            CreatePool(prefab);
        }
    }

    public GameObject GetFromPool(GameObject prefab)
    {
        CheckPool(prefab);
        var result = pools[prefab].Count <= 0 ? Instantiate(prefab) : pools[prefab].Dequeue();
        return result;
    }

    public void ReturnToPool(GameObject prefab, GameObject obj)
    {
        CheckPool(prefab);
        obj.SetActive(false);
        obj.transform.parent = poolParent;
        pools[prefab].Enqueue(obj);
    }
}

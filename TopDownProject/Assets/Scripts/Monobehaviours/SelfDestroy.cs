using System.Collections;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    [SerializeField]
    private float delay;
    [SerializeField]
    private bool pooled;
    [SerializeField]
    private GameObject prefab;
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(delay);
        if (pooled)
        {
            PoolingManager.Instance.ReturnToPool(prefab, gameObject);
        }
    }
}

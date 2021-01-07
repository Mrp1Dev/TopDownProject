using System.Collections;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    [SerializeField]
    private float delay;
    private void OnEnable()
    {
        StartCoroutine(DestroyWithDelay(delay));
    }

    private IEnumerator DestroyWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        PoolingManager.Instance.ReturnToPool(gameObject);

    }
}

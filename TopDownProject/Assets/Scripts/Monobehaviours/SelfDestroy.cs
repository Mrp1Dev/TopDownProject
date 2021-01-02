using System.Collections;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    [SerializeField]
    private float delay;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}

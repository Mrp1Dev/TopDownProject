using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ForwardImpulse : MonoBehaviour
{
    [SerializeField]
    private MinMax<float> spawnForce;

    // Start is called before the first frame update
    void Start()
    {
        var force = Random.Range(spawnForce.min, spawnForce.max);
        GetComponent<Rigidbody2D>().AddForce(transform.up * force, ForceMode2D.Impulse);
    }

}

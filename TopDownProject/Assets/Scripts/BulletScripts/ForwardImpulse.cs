using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ForwardImpulse : MonoBehaviour
{
    [SerializeField]
    private MinMax<float> spawnForce;

    // Start is called before the first frame update
    void OnEnable()
    {
        var force = Random.Range(spawnForce.min, spawnForce.max);

        var rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        rb.AddForce(transform.up * force, ForceMode2D.Impulse);
    }

}

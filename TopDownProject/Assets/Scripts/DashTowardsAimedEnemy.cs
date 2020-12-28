using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(InputProvider))]
public class DashTowardsAimedEnemy : MonoBehaviour
{
    [SerializeField]
    private float dashForce;

    [Header("Enemy detection")]
    [SerializeField]
    private float enemyDetectionRadius;
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private LayerMask enemyLayer;

    private Rigidbody2D rb;

    private void Start()
    {
        GetComponent<InputProvider>().DashPressed += Dash;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Dash()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        var aimDirection = (mousePos - transform.position).normalized;
        var forceDirection = aimDirection;
        //gets the enemy in aim
        var hit = Physics2D.CircleCast(transform.position, enemyDetectionRadius, aimDirection, 10f ,enemyLayer).transform;
        if (hit)
        {
            forceDirection = (hit.position - transform.position).normalized;
        }
        rb.AddForce(forceDirection.normalized * dashForce, ForceMode2D.Impulse);
        
    }
}

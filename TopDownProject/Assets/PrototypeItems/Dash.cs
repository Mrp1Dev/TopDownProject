using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField]
    private float dashForce;
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private float rechargeAmountPerShot = 1f;
    [SerializeField]
    private float rechargePerSecond = 1f;
    [SerializeField]
    private Transform bulletPoint;
    [SerializeField]
    private float detectionCastRadius = 1f;
    [SerializeField]
    private LayerMask enemyLayer;
    public float Recharge { get; private set; }
    public bool AutoDashToEnemy { get; set; }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && Recharge >= 1f)
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            Vector2 dir = (mousePos - bulletPoint.position).normalized;
            var hitEnemy = Physics2D.CircleCast(bulletPoint.position,
                detectionCastRadius, dir, 10000f, enemyLayer);
            if (hitEnemy)
            {
                dir = (hitEnemy.point - (Vector2)transform.position).normalized;
            }

            GetComponent<Rigidbody2D>().AddForce(dir * dashForce, ForceMode2D.Impulse);
            Recharge = 0f;
        }
        else
        {
            Recharge += rechargePerSecond * Time.deltaTime;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(bulletPoint.position, detectionCastRadius);
    }

    public void RechargeShot()
    {
        Recharge += rechargeAmountPerShot;
    }
}

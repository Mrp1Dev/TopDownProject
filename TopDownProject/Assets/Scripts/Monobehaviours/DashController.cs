using UnityEditor.Rendering;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(InputProvider))]
public class DashController : MonoBehaviour
{
    [SerializeField]
    private float dashForce;

    [Header("Charge")]
    [SerializeField]
    private float maxRecharge;
    [SerializeField]
    private float chargeCostPerDash;
    [SerializeField]
    private float rechargePerSecond;
    private float currentCharge;

    [SerializeField]
    private AimWithLayerDetection enemyDetection;

    private Rigidbody2D rb;

    private void Start()
    {
        GetComponent<InputProvider>().DashPressed += TryDash;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Recharge(rechargePerSecond * Time.deltaTime);
        Debug.DrawRay(transform.position, enemyDetection.GetAim() * 3f, Color.red);
    }
    private void TryDash()
    {
        if (currentCharge >= chargeCostPerDash)
        {
            rb.AddForce(enemyDetection.GetAim() * dashForce, ForceMode2D.Impulse);
            Recharge(-chargeCostPerDash);
        }
    }

    public void Recharge(float amount)
    {
        currentCharge += amount;
        currentCharge = Mathf.Clamp(currentCharge, 0f, maxRecharge);
    }
}

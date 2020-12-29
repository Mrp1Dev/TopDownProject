using UnityEngine;

[RequireComponent(typeof(ShootingHandler))]
public class RechargeOnShoot : MonoBehaviour
{
    [SerializeField]
    private DashController dashing;
    [SerializeField]
    private float rechargeAmount;
    void Start()
    {
        GetComponent<ShootingHandler>().BulletShot += (_) => dashing.Recharge(rechargeAmount);
    }

}

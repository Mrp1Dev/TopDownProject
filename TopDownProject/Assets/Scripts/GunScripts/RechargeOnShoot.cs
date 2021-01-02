using UnityEngine;

[RequireComponent(typeof(ShootingHandler))]
public class RechargeOnShoot : ShootBehaviour
{
    [SerializeField]
    private DashController dashController;
    [SerializeField]
    private float rechargeAmount;

    protected override void OnShoot()
    {
        dashController.Recharge(rechargeAmount);
    }
}

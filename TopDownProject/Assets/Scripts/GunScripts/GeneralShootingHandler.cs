using System;
using UnityEngine;

public class GeneralShootingHandler : ShootingHandler
{
    [SerializeField]
    private ShootingDataProvider dataProvider;
    [SerializeField]
    private InputProvider input;

    public override event Action<ShootingDataProvider> BulletShot;

    private float rofTimer;

    private bool CanShoot => rofTimer <= 0f;

    private void Update()
    {
        if (input.ShootHeld && CanShoot)
        {
            Shoot();
            rofTimer = dataProvider.Data.RPM / 60f; // divided by 60 so its bullets per minute->second
        }
        else
        {
            rofTimer -= Time.deltaTime;
        }

    }
    public override void Shoot()
    {
        BulletShot?.Invoke(data);
    }

}

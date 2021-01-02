using System;
using UnityEngine;

public class GeneralShootingHandler : ShootingHandler
{
    [SerializeField]
    private InputProvider input;
    [SerializeField]
    private int RPM;
    public override event Action BulletShot;

    private float rofTimer;

    private bool CanShoot => rofTimer <= 0f;

    private void Update()
    {
        if (input.ShootHeld && CanShoot)
        {
            Shoot();
            rofTimer = 1f / (RPM / 60f); // divided by 60 so its bullets per minute->second
        }
        else
        {
            rofTimer -= Time.deltaTime;
        }

    }
    public override void Shoot()
    {
        BulletShot?.Invoke();
    }

}

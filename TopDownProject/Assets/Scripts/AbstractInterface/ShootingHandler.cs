using System;
using UnityEngine;

public abstract class ShootingHandler : MonoBehaviour
{
    public abstract void Shoot();
    public abstract event Action<ShootingDataProvider> BulletShot;
}

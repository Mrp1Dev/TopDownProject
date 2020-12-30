using UnityEngine;
using System;

[System.Serializable]
public struct ShootingData
{
    public float totalDamage;
    public MinMax<int> projectileAmountPerShot;
    public int rpm;
    public GameObject bulletPrefab;
    public float maxShootAngleOffset;
    public float knockbackOnShoot;
}

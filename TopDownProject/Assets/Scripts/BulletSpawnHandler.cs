using UnityEngine;

public struct ShootingData
{
    public MinMax<int> projectileAmountPerShot;
    public int rpm;
    public GameObject bulletPrefab;
    public MinMax<float> maxShootAngleOffset;
}

public class BulletSpawnHandler : MonoBehaviour
{
    public void SpawnBullets(ShootingData data)
    {

    }
}

using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(ShootingHandler))]
public class BulletSpawnHandler : ShootBehaviour
{
    [Header("Bullet Data")]
    [SerializeField]
    private float DPS;
    [SerializeField]
    private float RPM;

    [Header("Spawn Info")]
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private MinMax<int> projectileAmountPerShot;
    [SerializeField]
    private float maxShootAngleOffset;


    protected override void OnShoot()
    {
        var amount = Random.Range(projectileAmountPerShot.min, projectileAmountPerShot.max);   
        for (int i = 0; i < amount; i++)
        {
            var spawnPos = spawnPoint.position;
            var spawnRot = spawnPoint.eulerAngles;
            spawnRot.z += RandomOffset();
            var instantiated = Instantiate(bulletPrefab, spawnPos, Quaternion.Euler(spawnRot));
            if (instantiated.TryGetComponent<BulletBehaviour>(out var bullet))
            {
                var bulletDamage = (DPS / (RPM / 60f)) / amount;
                bullet.Init(bulletDamage);
            }
        }
    }

    private float RandomOffset()
    {
        return Random.Range(-maxShootAngleOffset, maxShootAngleOffset) / 2f;
    }
}

using UnityEngine;

[RequireComponent(typeof(ShootingHandler))]
public class BulletSpawnHandler : ShootBehaviour
{
    [Tooltip("this is the amount of damage all bullets together would deal, ie totalDamage/bulletAmt")]
    [SerializeField]
    private float totalDamage;
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
                bullet.Init(totalDamage / amount);
            }
        }
    }

    private float RandomOffset()
    {
        return Random.Range(-maxShootAngleOffset, maxShootAngleOffset) / 2f;
    }
}

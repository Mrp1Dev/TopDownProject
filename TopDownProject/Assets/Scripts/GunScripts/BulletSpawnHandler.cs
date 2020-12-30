using UnityEngine;

[RequireComponent(typeof(ShootingHandler))]
public class BulletSpawnHandler : MonoBehaviour
{
    [SerializeField]
    private ShootingHandler shootingHandler;
    [SerializeField]
    private Transform spawnPoint;

    private void Start()
    {
        shootingHandler.BulletShot += SpawnBullets;
    }
    public void SpawnBullets(ShootingData data)
    {
        var amount = Random.Range(data.projectileAmountPerShot.min, data.projectileAmountPerShot.max);   
        for (int i = 0; i < amount; i++)
        {
            var spawnPos = spawnPoint.position;
            var spawnRot = spawnPoint.eulerAngles;
            spawnRot.z += Random.Range(-data.maxShootAngleOffset, data.maxShootAngleOffset) / 2f;
            var instantiated = Instantiate(data.bulletPrefab, spawnPos, Quaternion.Euler(spawnRot));
            if(instantiated.TryGetComponent<BulletBehaviour>(out var bullet))
            {
                bullet.Init(data.totalDamage / amount);
            }
        }
    }
}

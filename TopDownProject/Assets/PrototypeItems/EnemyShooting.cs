using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab = default;
    [SerializeField]
    private Transform spawnPoint = default;
    [SerializeField]
    private int bulletsPerShot = 1;
    [SerializeField]
    private int rpm;
    [SerializeField]
    private float maxRandomOffsetAngle = 5f;
    [SerializeField]
    private float range;
    [SerializeField]
    private float oppositeForce;
    [SerializeField]
    private float damagePerBullet;
    [SerializeField]
    private float bulletKnockback;
    [SerializeField]
    private Transform player;
    private float shootTimer;

    private void Update()
    {
        var distance = (player.position - transform.position).magnitude;

        if (shootTimer <= 0f && distance <= range)
        {
            Shoot();
            shootTimer = 1f / (rpm / 60f);
        }
        else
        {
            shootTimer -= Time.deltaTime;
        }
    }

    private void Shoot()
    {
        if (TryGetComponent<Rigidbody2D>(out var rb))
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(-transform.up * oppositeForce, ForceMode2D.Impulse);

        }

        for (int i = 0; i < bulletsPerShot; i++)
        {
            var spawnPos = spawnPoint.position;
            var spawnRot = spawnPoint.rotation;
            spawnRot = Quaternion.Euler(0f, 0f,
                spawnRot.eulerAngles.z + Random.Range(-maxRandomOffsetAngle, maxRandomOffsetAngle) / 2f);
            var bulletGo = Instantiate(bulletPrefab, spawnPos, spawnRot);
            Bullet bullet = bulletGo.GetComponent<Bullet>();
            bullet.BaseDamage = damagePerBullet;
            bullet.KnockbackOnHit = bulletKnockback;
        }

    }

}

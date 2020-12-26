using Cinemachine;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab = default;
    [SerializeField]
    private Transform spawnPoint = default;
    [SerializeField]
    private int minProjectileAmount;
    [SerializeField]
    private int maxProjectileAmount;
    [SerializeField]
    private int rpm;
    [SerializeField]
    private float maxRandomOffsetAngle = 5f;
    [SerializeField]
    private float oppositeForce;
    [SerializeField]
    private CinemachineVirtualCamera cam;
    [SerializeField]
    private float shakeTimeOnShoot;
    [SerializeField]
    private float damagePerBullet;
    [SerializeField]
    private float bulletKnockback;
    private float rofTimer;

    private void Update()
    {
        if (Input.GetMouseButton(0) && rofTimer <= 0f)
        {
            Shoot();
            rofTimer = 1f / (rpm/60f);
        }
        else
        {
            rofTimer -= Time.deltaTime;
        }
    }

    private void Shoot()
    {
        if(TryGetComponent<Rigidbody2D>(out var rb))
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(-transform.up * oppositeForce, ForceMode2D.Impulse);
            
        }

        var projectileAmount = Random.Range(minProjectileAmount, maxProjectileAmount);
        for (int i = 0; i < projectileAmount; i++)
        {
            var spawnPos = spawnPoint.position;
            var spawnRot = spawnPoint.rotation;
            spawnRot = Quaternion.Euler(0f, 0f,
                spawnRot.eulerAngles.z + Random.Range(-maxRandomOffsetAngle, maxRandomOffsetAngle)/2f );
            var bulletGo = Instantiate(bulletPrefab, spawnPos, spawnRot);
            Bullet bullet = bulletGo.GetComponent<Bullet>();
            bullet.BaseDamage = damagePerBullet;
            bullet.KnockbackOnHit = bulletKnockback;
        }
        GetComponent<Dash>().RechargeShot();
        CameraShaker.Instance.Shake(shakeTimeOnShoot);
       
    }

    
}

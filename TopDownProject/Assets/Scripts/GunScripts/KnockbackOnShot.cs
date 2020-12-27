using UnityEngine;

public class KnockbackOnShot : MonoBehaviour
{
    [SerializeField]
    private ShootingHandler shootingHandler;
    [SerializeField]
    private Rigidbody2D bodyToKnockback;

    private void Start()
    {
        shootingHandler.BulletShot += Knockback;
    }

    private void Knockback(ShootingData data)
    {
        bodyToKnockback.velocity = Vector2.zero;
        bodyToKnockback.AddForce(-bodyToKnockback.transform.up * data.knockbackOnShoot, ForceMode2D.Impulse);
    }
}

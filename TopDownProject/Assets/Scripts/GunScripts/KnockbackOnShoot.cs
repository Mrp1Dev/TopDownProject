using UnityEngine;

public class KnockbackOnShoot : ShootBehaviour
{
    [SerializeField]
    private Rigidbody2D bodyToKnockback;
    [SerializeField]
    private float knockbackForce;

    protected override void OnShoot()
    {
        bodyToKnockback.velocity = Vector2.zero;
        bodyToKnockback.AddForce(-bodyToKnockback.transform.up * knockbackForce, ForceMode2D.Impulse);
    }
}

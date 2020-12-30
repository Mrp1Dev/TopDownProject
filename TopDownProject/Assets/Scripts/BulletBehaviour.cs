using Cinemachine;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private float damage;

    public void Init(float damage)
    {
        this.damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<DamageableObject>(out var damageable))
        {
            damageable.TakeDamage(damage);
            Debug.Log("hit enemy!");
            GetComponent<CinemachineImpulseSource>().GenerateImpulse();
            Destroy(gameObject);
        }
    }
}

using Cinemachine;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [Tooltip("damage is multiplied by the curve value at x distance.")]
    [SerializeField]
    private AnimationCurve damageOverDistance;
    private float damage;
    private Vector3 initialPosition;
    public void Init(float damage)
    {
        this.damage = damage;
    }

    private void OnEnable()
    {
        initialPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<DamageableObject>(out var damageable))
        {
            float damage = GetDamage();
            damageable.TakeDamage(damage);
            Debug.Log("hit enemy!");
            GetComponent<CinemachineImpulseSource>().GenerateImpulse();
            Destroy(gameObject);
        }
    }

    private float GetDamage()
    {
        var distance = (initialPosition - transform.position).magnitude;
        var damage = damageOverDistance.Evaluate(distance) * this.damage;
        return damage;
    }
}

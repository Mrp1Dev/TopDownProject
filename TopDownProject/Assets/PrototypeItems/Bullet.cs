using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float minSpeed;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float destructionTime = 2f;
    [SerializeField]
    private float shakeTimeOnHit = 0.1f;
    [SerializeField]
    private AnimationCurve damageOverDistance;
    public float BaseDamage { get; set; }
    public float KnockbackOnHit { get; set; }

    private float currentDamage;
    private float speed;
    private Vector2 initialPos;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
        initialPos = transform.position;
        yield return new WaitForSeconds(destructionTime);
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Damageable>(out var damageable))
        {
            var distanceTravelled = ((Vector2)transform.position - initialPos).magnitude;
            currentDamage = BaseDamage * damageOverDistance.Evaluate(distanceTravelled);
            damageable.Damage(currentDamage);
            if (collision.TryGetComponent<Rigidbody2D>(out var rb))
            {
                rb.AddForce((collision.transform.position - transform.position).normalized * KnockbackOnHit, ForceMode2D.Impulse);
            }
            CameraShaker.Instance.Shake(shakeTimeOnHit);
            Destroy(gameObject);
        }
    }


}

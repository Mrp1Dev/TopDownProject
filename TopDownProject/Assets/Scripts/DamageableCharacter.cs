using UnityEngine;

public class DamageableCharacter : DamageableObject
{
    [SerializeField]
    private float maxHealth;
    private float health;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        if(health <= 0f)
        {
            gameObject.SetActive(false);
        }
    }

    public override void TakeDamage(float amount)
    {
        health -= amount;
    }

}

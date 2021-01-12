using UnityEngine;


public class DamageablePlayer : DamageableObject
{
    [SerializeField]
    private bool takeDamageOnGrapple;
    [SerializeField]
    private GrappleController grappleController;
    [SerializeField]
    private float maxHealth;
    private float currentHealth;
    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public override void TakeDamage(float amount)
    {
        if (!takeDamageOnGrapple && grappleController.Grappling)
        {
            return;
        }
        currentHealth -= amount;
        TryDeath();
    }

    private void TryDeath()
    {
        if(currentHealth <= 0f)
        {
            gameObject.SetActive(false);
        }
        
    }
}

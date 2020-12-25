using UnityEngine;

public class Damageable : MonoBehaviour
{
    public float maxHealth;
    public float Health { get; private set; }

    public void Damage(float damage)
    {
        Health -= damage;
    }
    
    void Start()
    {
        Health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(Health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}

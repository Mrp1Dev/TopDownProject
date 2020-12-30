using UnityEngine;

public class EnemyInputProvider : InputProvider
{
    [Header("Shooting")]
    [SerializeField]
    private float range;
    [SerializeField]
    private Transform target;
    private void Update()
    {
        var distance = (target.position - transform.position).magnitude;
        if (distance <= range)
        {
            ShootHeld = true;
        }
    }
}

using UnityEngine;

[RequireComponent(typeof(ShootingHandler))]
public abstract class ShootBehaviour : MonoBehaviour
{
    protected ShootingHandler shootingHandler;
    protected virtual void OnEnable()
    {
        shootingHandler = GetComponent<ShootingHandler>();
        shootingHandler.BulletShot += OnShoot;
    }

    protected virtual void OnDisable()
    {
        shootingHandler.BulletShot -= OnShoot;
    }

    protected abstract void OnShoot();
}

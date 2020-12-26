using UnityEngine;

public class SerializedShootDataProvider : ShootingDataProvider
{
    [SerializeField]
    public MinMax<int> projectileAmountPerShot;
    [SerializeField]
    public int rpm;
    [SerializeField]
    public GameObject bulletPrefab;
    [SerializeField]
    public MinMax<float> maxShootAngleOffset;

    // Update is called once per frame
    private void Update()
    {
        InitParentFields();
    }

    private void InitParentFields()
    {
        ProjectileAmountPerShot = projectileAmountPerShot;
        RPM = rpm;
        BulletPrefab = bulletPrefab;
        MaxShootAngleOffset = maxShootAngleOffset;
    }
}

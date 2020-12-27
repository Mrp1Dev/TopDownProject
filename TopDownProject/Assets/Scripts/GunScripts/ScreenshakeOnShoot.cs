using Cinemachine;
using UnityEngine;

public class ScreenshakeOnShoot : MonoBehaviour
{
    [SerializeField]
    private ShootingHandler shootingHandler;
    [SerializeField]
    private CinemachineImpulseSource source;
    // Start is called before the first frame update
    void Start()
    {
        shootingHandler.BulletShot += (_) => Screenshake();
    }

    private void Screenshake()
    {
        source.GenerateImpulse();
    }
}

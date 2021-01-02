using Cinemachine;
using UnityEngine;

public class ScreenshakeOnShoot : ShootBehaviour
{
    [SerializeField]
    private CinemachineImpulseSource source;

    protected override void OnShoot()
    {
        source.GenerateImpulse();
    }
}

using UnityEngine;

public class MouseAimController : MonoBehaviour
{
    [SerializeField]
    private float turnSpeed;
    [SerializeField]
    private AimWithLayerDetection aimAssist;

    private AimInDirection aimHandler = new AimInDirection();
    // Update is called once per frame
    void Update()
    {
        var targetDir = aimAssist.GetAim();
        aimHandler.Execute(transform, targetDir, turnSpeed);
    }
}

using UnityEngine;

public class MouseAimProvider : AimDataProvider
{
    [SerializeField]
    private float turnSpeed;
    [SerializeField]
    private AimWithLayerDetection aimAssist;
    // Update is called once per frame
    void Update()
    {
        TurnSpeed = turnSpeed;
        TargetDir = aimAssist.GetAim();
    }
}

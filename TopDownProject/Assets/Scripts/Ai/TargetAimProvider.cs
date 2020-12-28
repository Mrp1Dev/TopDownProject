using UnityEngine;

public class TargetAimProvider : AimDataProvider
{
    [SerializeField]
    private MinMax<float> turnSpeed;
    [SerializeField]
    private Transform target;

    private void Update()
    {
        TargetDir = (target.position - transform.position).normalized;
        var lerpAmount = Vector2.Dot(TargetDir, transform.up).Remap(-1f, 1f, 0f, 1f); 
        // the more opposite the aim is, the closer to TurnSpeed.Max it will be.
        TurnSpeed = Mathf.Lerp(turnSpeed.max, turnSpeed.min, lerpAmount);
    }
}

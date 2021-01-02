using UnityEngine;

public class TargetAimController : MonoBehaviour
{
    [SerializeField]
    private MinMax<float> turnSpeed;
    [SerializeField]
    private Transform target;
    private AimInDirection aimHandler = new AimInDirection();
    private void Update()
    {
        var targetDir = (target.position - transform.position).normalized;
        var lerpAmount = Vector2.Dot(targetDir, transform.up).Remap(-1f, 1f, 0f, 1f); 
        // the more opposite the aim is, the closer to TurnSpeed.Max it will be.
        var currentTurnSpeed = Mathf.Lerp(turnSpeed.max, turnSpeed.min, lerpAmount);

        aimHandler.Execute(transform, targetDir, currentTurnSpeed);
    }
}

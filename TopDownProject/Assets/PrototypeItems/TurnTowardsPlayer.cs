using UnityEngine;

public class TurnTowardsPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform player = default;
    [SerializeField]
    private float minTurnSpeed = 4f;
    [SerializeField]
    private float maxTurnSpeed = 5f;

    private void Update()
    {
        var dir = (player.position - transform.position).normalized;
        var lerpAmount = Vector2.Dot(dir, transform.up).Remap(-1f, 1f, 0f, 1f);
        var turnSpeed = Mathf.Lerp(maxTurnSpeed, minTurnSpeed, lerpAmount);

        transform.up = Vector3.RotateTowards(transform.up, dir, turnSpeed * Time.deltaTime, 0f);
    }


}

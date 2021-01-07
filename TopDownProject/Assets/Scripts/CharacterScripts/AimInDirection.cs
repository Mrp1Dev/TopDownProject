using UnityEngine;

public class AimInDirection
{
    public void Execute(Transform transform, Vector2 targetDir, float turnSpeed)
    {
        transform.up = Vector3.RotateTowards(transform.up, targetDir, turnSpeed * Time.deltaTime, 0f);
    }
}

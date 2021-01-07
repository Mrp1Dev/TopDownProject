using UnityEngine;

public class CharacterMovement
{
    public void Execute(Rigidbody2D rb, Vector2 direction, float acceleration, float maxSpeed)
    {
        //clamps acceleration so that when it's added, velocity shouldn't exceed maxspeed.
        var clampedAcceleration = Mathf.Clamp(
            acceleration,
            0f,
            Mathf.Max(0f,maxSpeed - rb.velocity.magnitude));
        rb.velocity += direction * clampedAcceleration;
    }
}

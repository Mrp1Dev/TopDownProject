using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private MovementDataProvider data;
    [SerializeField]
    private Rigidbody2D rb;

    void FixedUpdate()
    {
        //clamps acceleration so that when it's added, velocity shouldn't exceed maxspeed.
        var clampedAcceleration = Mathf.Clamp(
            data.Acceleration,
            0f,
            Mathf.Max(0f, data.MaxSpeed - rb.velocity.magnitude));
        Debug.Log($"acceleration = {clampedAcceleration}");
        rb.velocity += data.Direction * clampedAcceleration;
        Debug.Log(rb.velocity.magnitude);
    }
}

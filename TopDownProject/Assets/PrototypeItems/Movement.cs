using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb = default;
    [SerializeField]
    private float acceleration;
    public float maxSpeed;
    private float inputX;
    private float inputY;

    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        var dir = new Vector2(inputX, inputY).normalized;
        float clampedAcceleration = Mathf.Clamp(acceleration, 0f, Mathf.Max(maxSpeed - rb.velocity.magnitude, 0f));
        rb.velocity += dir * clampedAcceleration;

    }
}

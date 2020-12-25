using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementDataProvider : MovementDataProvider
{
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float acceleration;

    private void Update()
    {
        MaxSpeed = maxSpeed;
        Acceleration = acceleration;
    }

    private void OnMovement(InputValue input)
    {
        Direction = input.Get<Vector2>().normalized;
    }
}

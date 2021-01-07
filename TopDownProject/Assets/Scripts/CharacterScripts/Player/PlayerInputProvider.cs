using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputProvider : InputProvider
{
    public override event Action DashPressed;

    private void OnMovement(InputValue input)
    {
        InputX = input.Get<Vector2>().x;
        InputY = input.Get<Vector2>().y;
    }

    private void OnShoot(InputValue input)
    {
        ShootHeld = input.Get<float>() > 0.7f;
    }

    private void OnDash()
    {
        DashPressed?.Invoke();
    }
}

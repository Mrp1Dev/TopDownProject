using UnityEngine;
using UnityEngine.InputSystem;

public class InputProvider : MonoBehaviour
{
    public float InputX { get; protected set; }
    public float InputY { get; private set; }
    public bool ShootHeld { get; private set; }
    public Vector2 InputVector => new Vector2(InputX, InputY).normalized;
    private void OnMovement(InputValue input)
    {
        InputX = input.Get<Vector2>().x;
        InputY = input.Get<Vector2>().y;
    }

    private void OnShoot(InputValue input)
    {
        ShootHeld = input.Get<float>() > 0.7f;
    }
}

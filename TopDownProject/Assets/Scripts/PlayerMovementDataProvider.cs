using UnityEngine;

public class PlayerMovementDataProvider : MovementDataProvider
{
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float acceleration;
    [SerializeField]
    private InputProvider input;

    private void Update()
    {
        MaxSpeed = maxSpeed;
        Acceleration = acceleration;
        Direction = input.InputVector;
    }

    
}

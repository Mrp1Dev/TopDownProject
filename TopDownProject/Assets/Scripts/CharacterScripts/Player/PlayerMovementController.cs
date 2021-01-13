using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float acceleration;
    [SerializeField]
    private InputProvider input;
    private Rigidbody2D rb;
    private CharacterMovement movementHandler = new CharacterMovement();

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if(!GetComponent<GrappleController>().Grappling)
        movementHandler.Execute(rb, input.InputVector, acceleration, maxSpeed);
    }

    
}

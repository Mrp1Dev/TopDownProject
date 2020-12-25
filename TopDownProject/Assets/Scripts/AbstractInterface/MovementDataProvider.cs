using UnityEngine;

public abstract class MovementDataProvider : MonoBehaviour
{
    public float MaxSpeed { get; protected set; }
    public float Acceleration { get; protected set; }
    public Vector2 Direction { get; protected set; }
    
}

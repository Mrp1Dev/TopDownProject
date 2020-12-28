using System;
using UnityEngine;

public abstract class InputProvider : MonoBehaviour
{
    public float InputX { get; protected set; }
    public float InputY { get; protected set; }
    public bool ShootHeld { get; protected set; }
    public virtual event Action DashPressed;
    public Vector2 InputVector => new Vector2(InputX, InputY).normalized;
}

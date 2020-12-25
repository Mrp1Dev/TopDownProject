using UnityEngine;

public abstract class AimDataProvider : MonoBehaviour
{
    public Vector2 TargetDir { get; protected set; }
    public float TurnSpeed { get; protected set; }
}

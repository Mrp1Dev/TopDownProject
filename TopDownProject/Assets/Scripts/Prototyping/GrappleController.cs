using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

[System.Serializable]
public class GrapplingHook
{
    [SerializeField]
    private LineRenderer lineRenderer;
    [SerializeField]
    private float hookSpeed;

    private float grappleProgress;
    public Vector2 MoveTowards(Vector2 origin, Vector2 target)
    {
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, origin);
        var currentEndPos = Vector2.Lerp(origin, target, grappleProgress);
        grappleProgress += hookSpeed * Time.deltaTime;
        lineRenderer.SetPosition(1, currentEndPos);
        return currentEndPos;
    }

    public void SetActive(bool active)
    {
        lineRenderer.enabled = active;
    }

    public void Reset()
    {
        grappleProgress = 0f;
    }
}

[RequireComponent(typeof(InputProvider))]
public class GrappleController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private GrapplingHook hook;
    //[SerializeField]
    //private float grappleSpeed;
    [SerializeField]
    private MinMax<float> grappleSpeedOverRange;
    [SerializeField]
    private float precision;
    [SerializeField]
    private AimWithLayerDetection grappleCast;
    public bool Grappling { get; private set; }

    private Transform target;
    private Vector3 grappledPosition;
    private Vector2 velocityOnGrapple;
    private float clockWise;
    private bool grappleForward;
    private float grappleSpeed;
    private void OnEnable()
    {
        GetComponent<InputProvider>().DashPressed += HandleClick;
    }
    private void OnDisable()
    {
        GetComponent<InputProvider>().DashPressed += HandleClick;
    }

    private void HandleClick()
    {
        var hit = grappleCast.GetHit();
        hook.Reset();
        if (hit)
        {
            target = hit.transform;
            var targetPos = target.GetComponent<Collider2D>().ClosestPoint(transform.position);
            var inputVector = GetComponent<InputProvider>().InputVector;
            var playerToHookDir = (targetPos - (Vector2)transform.position).normalized;

            
            clockWise = Vector2.Dot(Vector2.Perpendicular(playerToHookDir), inputVector.normalized) > 0 ? 1 : -1;
            grappleForward = Vector3.Angle(playerToHookDir, inputVector) <= 45f || inputVector.magnitude < Mathf.Epsilon;
        }
        else
        {
            StopGrappling();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null)
        {
            var targetPos = target.GetComponent<Collider2D>().ClosestPoint(transform.position);
            bool reached = (targetPos - (Vector2)transform.position).magnitude <= precision;
            var hookPos = hook.MoveTowards(transform.position, targetPos);
            bool hookReached = hookPos == targetPos;
            if (hookReached)
            {
                if (!reached)
                {
                    //rb.velocity += (targetPos - (Vector2)transform.position).normalized * grappleAccel;
                    grappleSpeed = Mathf.Lerp(grappleSpeedOverRange.min, grappleSpeedOverRange.max,
                (targetPos - (Vector2)transform.position).magnitude / grappleCast.Range);
                    var playerToHookDir = (targetPos - (Vector2)transform.position).normalized;
                    if (!grappleForward)
                    {
                        rb.velocity = Vector3.RotateTowards(Vector2.Perpendicular(playerToHookDir) * grappleSpeed * clockWise, playerToHookDir, 0.05f, 0f);
                    }
                    else
                    {
                        rb.velocity = playerToHookDir * grappleSpeed;
                    }
                    Debug.DrawRay(transform.position, rb.velocity);
                    var projectedVelocity = (Vector2)Vector3.Project(rb.velocity, -playerToHookDir);
                    if(Vector3.Dot(playerToHookDir, projectedVelocity.normalized) < 0)
                    {
                        rb.velocity -= projectedVelocity;
                    }
                    Grappling = true;

                }
                else
                {
                    StopGrappling();
                }
            }
        }
    }

    private void StopGrappling()
    {
        target = null;
        Grappling = false;
        hook.SetActive(false);
        hook.Reset();
    }

}

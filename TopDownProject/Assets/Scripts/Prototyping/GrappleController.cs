using System.Collections;
using UnityEngine;

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
    [SerializeField]
    private float proGrappleDrag;
    [SerializeField]
    private float normalGrappleAccel;
    [SerializeField]
    private AimWithLayerDetection normalGrappleCast;
    public bool AltMode { get; set; } = true;
    public bool Grappling { get; private set; }

    private Transform target;
    private Vector3 grappledPosition;
    private Vector2 velocityOnGrapple;
    private float clockWise;
    private bool grappleForward;
    private float grappleSpeed;
    private bool wasGrappling;
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
        var hit = (AltMode ? grappleCast : normalGrappleCast).GetHit();
        hook.Reset();
        if (hit)
        {
            target = hit.transform;
            var targetPos = target.GetComponent<Collider2D>().ClosestPoint(transform.position);
            //var inputVector = GetComponent<InputProvider>().InputVector;
            var playerToHookDir = (targetPos - (Vector2)transform.position).normalized;
            var velocityDir = rb.velocity.normalized;
            var angle = Vector2.Angle(velocityDir, playerToHookDir);
            clockWise = Vector2.Dot(Vector2.Perpendicular(playerToHookDir), velocityDir) > 0 ? 1 : -1;
            grappleForward = angle <= 45f || angle > (180f - 45f) || rb.velocity.magnitude < 0.1;
        }
        else
        {
            StopGrappling();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && Grappling)
        {
            grappleForward = true;
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
                        
                    var playerToHookDir = (targetPos - (Vector2)transform.position).normalized;
                    if (AltMode)
                    {
                        grappleSpeed = Mathf.Lerp(grappleSpeedOverRange.min, grappleSpeedOverRange.max,
                            (targetPos - (Vector2)transform.position).magnitude / grappleCast.Range);
                        if (!grappleForward)
                        {
                            rb.velocity = Vector3.RotateTowards(Vector2.Perpendicular(playerToHookDir) * grappleSpeed * clockWise, playerToHookDir, 0.07f, 0f);
                        }
                        else
                        {
                            rb.velocity = playerToHookDir * grappleSpeed;
                        }

                        Debug.DrawRay(transform.position, rb.velocity);
                    }
                    else
                    {
                        rb.velocity += (targetPos - (Vector2)transform.position).normalized * normalGrappleAccel;
                    }
                    var projectedVelocity = (Vector2)Vector3.Project(rb.velocity, -playerToHookDir);
                    if (Vector3.Dot(playerToHookDir, projectedVelocity.normalized) < 0)
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

        wasGrappling = Grappling;
    }
    private void LateUpdate()
    {
        if (wasGrappling && !Grappling)
        {
            StartCoroutine(DragVelocity(rb.velocity));
        }
    }
    private void StopGrappling()
    {
        target = null;
        Grappling = false;
        hook.SetActive(false);
        hook.Reset();

    }

    private IEnumerator DragVelocity(Vector2 oldVelocity)
    {
        var curPercent = 100f;
        while (curPercent > 0f)
        {
            rb.velocity += ((oldVelocity - rb.velocity) * curPercent / 100f) * 4f * Time.fixedDeltaTime;
            curPercent -= proGrappleDrag * Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

    }
}

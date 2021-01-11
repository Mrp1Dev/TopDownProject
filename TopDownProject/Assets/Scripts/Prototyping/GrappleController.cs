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
    [SerializeField]
    private float grappleAccel;
    [SerializeField]
    private float precision;
    [SerializeField]
    private AimWithLayerDetection grappleCast;
    public bool Grappling { get; private set; }

    private GameObject target;

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
            target = hit.transform.gameObject;
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
            bool hooxreached = hookPos == targetPos;
            if (hooxreached)
            {
                
                if (!reached)
                {
                    rb.velocity += (targetPos - (Vector2)transform.position).normalized * grappleAccel;
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

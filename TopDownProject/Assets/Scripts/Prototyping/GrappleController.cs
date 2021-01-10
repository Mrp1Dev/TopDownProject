using UnityEngine;

public class GrappleController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float grappleAccel;
    [SerializeField]
    private float precision;
    [SerializeField]
    private AimWithLayerDetection grappleCast;
    [SerializeField]
    private LineRenderer lineRenderer;

    public bool Grappling { get; private set; }

    private GameObject target;



    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            if (target != null)
            {
                var targetPos = target.GetComponent<Collider2D>().ClosestPoint(transform.position);
                if ((targetPos - (Vector2)transform.position).magnitude >= precision)
                {
                    rb.velocity += (targetPos - (Vector2)transform.position).normalized * grappleAccel;
                    Grappling = true;
                    lineRenderer.enabled = true;
                    lineRenderer.SetPosition(0, transform.position);
                    lineRenderer.SetPosition(1, targetPos);
                }
                else
                {
                    StopGrappling();
                }
            }
            else
            {
                var hit = grappleCast.GetHit();
                if (hit)
                {
                    target = hit.transform.gameObject;
                }
            }
        }
        else
        {
            StopGrappling();
        }


    }

    private void StopGrappling()
    {
        target = null;
        Grappling = false;
        lineRenderer.enabled = false;
    }
}

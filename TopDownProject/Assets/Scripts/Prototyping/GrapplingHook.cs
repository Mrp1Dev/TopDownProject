using UnityEngine;

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

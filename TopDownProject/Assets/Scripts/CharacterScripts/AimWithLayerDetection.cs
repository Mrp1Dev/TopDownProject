using UnityEngine;

[System.Serializable]
public class AimWithLayerDetection
{
    [SerializeField]
    private float range;
    [SerializeField]
    private float castThickness;
    [SerializeField]
    private Transform origin;
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private LayerMask layer;

    public Vector3 GetAim()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        var resultDir = (mousePos - origin.position).normalized;
        //offsets the position so that the cast is done that it doesn't overlap with behind and side hits.
        var offsetOrigin = origin.position + resultDir * castThickness;
        var offsetRange = range - castThickness;
        //gets the layer item in aim
        var hit = Physics2D.CircleCast(offsetOrigin, castThickness, resultDir, offsetRange, layer).transform;
        if (hit)
        {
            resultDir = (hit.position - origin.position).normalized;
        }
        return resultDir;
    }
    public RaycastHit2D GetHit()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        var resultDir = (mousePos - origin.position).normalized;
        //offsets the position so that the cast is done that it doesn't overlap with behind and side hits.
        var offsetOrigin = origin.position + resultDir * castThickness;
        var offsetRange = range - castThickness;
        //gets the layer item in aim
        var hit = Physics2D.CircleCast(offsetOrigin, castThickness, resultDir, offsetRange, layer);
        return hit;
    }
}

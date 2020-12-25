using UnityEngine;

public class FaceMouse : MonoBehaviour
{
    [SerializeField]
    private Camera cam = default;
    [SerializeField]
    private float rotSpeed;

    [Header("Aim assist")]
    [SerializeField]
    private float aimAssistCastRadius;
    [SerializeField]
    private LayerMask enemyLayer;
    public bool AimAssist { get; set; }
    private void Update()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        Vector2 rawDir = (mousePos - transform.position).normalized;
        Vector2 dir = rawDir;
        if (AimAssist)
        {
            var hitEnemy = Physics2D.CircleCast(transform.position,
                aimAssistCastRadius, rawDir, 6f, enemyLayer);
            if (hitEnemy)
            {
                Vector3 enemyPos = hitEnemy.transform.position;
                enemyPos.z = 0f;
                dir = (enemyPos - transform.position).normalized;
            }

        }
        transform.up = Vector3.RotateTowards(transform.up, dir, rotSpeed * Time.deltaTime, 0f);
    }
}

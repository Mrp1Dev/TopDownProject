using Cinemachine;
using UnityEngine;

public class DynamicFieldOfView : MonoBehaviour
{
    [SerializeField]
    private MinMax<float> size;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float increaseDampSpeed;
    [SerializeField]
    private float decreaseDampSpeed;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private CinemachineVirtualCamera cam;

    private float oldSpeed;
    // Update is called once per frame
    private void FixedUpdate()
    {
        var wantedSize = Mathf.Lerp(size.min, size.max, rb.velocity.magnitude / maxSpeed);
        var currentSize = cam.m_Lens.OrthographicSize;
        var dampSpeed = oldSpeed - rb.velocity.magnitude > 0f ? decreaseDampSpeed : increaseDampSpeed;
        currentSize = Mathf.MoveTowards(currentSize, wantedSize, dampSpeed * Time.deltaTime);
        cam.m_Lens.OrthographicSize = currentSize;
        oldSpeed = rb.velocity.magnitude;
    }
}

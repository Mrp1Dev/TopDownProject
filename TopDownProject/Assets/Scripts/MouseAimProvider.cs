using UnityEngine;

public class MouseAimProvider : AimDataProvider
{
    [SerializeField]
    private float turnSpeed;
    [SerializeField]
    private Camera cam;

    // Update is called once per frame
    void Update()
    {
        TurnSpeed = turnSpeed;
        var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        TargetDir = mousePos - transform.position;
    }
}

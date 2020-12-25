using UnityEngine;

public class AimInDirection : MonoBehaviour
{
    [SerializeField]
    private AimDataProvider data;

    // Update is called once per frame
    void Update()
    {
        transform.up = Vector3.RotateTowards(transform.up, data.TargetDir * Time.deltaTime, data.TurnSpeed, 0f);
    }
}

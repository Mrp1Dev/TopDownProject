using UnityEngine;
using UnityEngine.UI;

public class AutoDashToggle : MonoBehaviour
{
    [SerializeField]
    private Dash dash;

    private void Update()
    {
        dash.AutoDashToEnemy = GetComponent<Toggle>().isOn;
    }
}

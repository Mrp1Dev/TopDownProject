using UnityEngine;
using UnityEngine.UI;

public class AimAssistToggle : MonoBehaviour
{
    [SerializeField]
    private FaceMouse faceMouse;

    // Update is called once per frame
    void Update()
    {
        faceMouse.AimAssist = GetComponent<Toggle>().isOn;
    }
}

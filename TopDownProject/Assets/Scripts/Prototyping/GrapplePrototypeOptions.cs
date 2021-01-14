using UnityEngine;
using UnityEngine.UI;

public class GrapplePrototypeOptions : MonoBehaviour
{
    [SerializeField]
    private GrappleController controller;

    public void ChangeGrappleMode()
    {
        controller.AltMode = GetComponent<Toggle>().isOn;
    }
}

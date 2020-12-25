using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class SetCameraSize : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera cam;
    // Update is called once per frame
    void Update()
    {
        cam.m_Lens.OrthographicSize = GetComponent<Slider>().value;
    }
}

using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class CameraDampSetting : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera cam;

    // Update is called once per frame
    void Update()
    {
        var val = GetComponent<Slider>().value;
        cam.GetCinemachineComponent<CinemachineFramingTransposer>().m_XDamping = val;
        cam.GetCinemachineComponent<CinemachineFramingTransposer>().m_YDamping = val;
    }
}

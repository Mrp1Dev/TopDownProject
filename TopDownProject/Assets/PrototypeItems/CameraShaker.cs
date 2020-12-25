using Cinemachine;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public static CameraShaker Instance { get; private set; }
    private float currentTimer;
    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        var cam = GetComponent<CinemachineVirtualCamera>();
        if (currentTimer > 0f)
        {
            cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 2.5f;
            currentTimer -= Time.deltaTime;
        }
        else
        {
            cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0f;
        }
    }
    public void Shake(float time)
    {
        currentTimer = Mathf.Max(currentTimer, time);
    }
}

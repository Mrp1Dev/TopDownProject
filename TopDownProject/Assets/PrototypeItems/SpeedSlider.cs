using UnityEngine;
using UnityEngine.UI;

public class SpeedSlider : MonoBehaviour
{
    [SerializeField]
    private Movement movement;
    [SerializeField]
    private float minSpeed = 0f;
    [SerializeField]
    private float maxSpeed = 50f;
    

    // Update is called once per frame
    void Update()
    {
        movement.maxSpeed = Mathf.Lerp(minSpeed, maxSpeed,
            GetComponent<Slider>().value);    
    }
}

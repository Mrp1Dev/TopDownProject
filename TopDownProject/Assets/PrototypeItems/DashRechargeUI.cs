using UnityEngine;
using UnityEngine.UI;

public class DashRechargeUI : MonoBehaviour
{
    [SerializeField]
    private Dash dash;
    [SerializeField]
    private Image image;

    private Color defaultColor;
    private void Start()
    {
        defaultColor = image.color;
    }

    private void Update()
    {
        GetComponent<Slider>().value = dash.Recharge;
        if(Mathf.Approximately(GetComponent<Slider>().value, 1f))
        {
            image.color = Color.yellow;
        }
        else
        {
            image.color = defaultColor;
        }
    }
}

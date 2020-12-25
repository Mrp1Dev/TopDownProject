using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    private Damageable damageable;

    private void Update()
    {
        GetComponent<Slider>().value = damageable.Health / damageable.maxHealth;
    }
}

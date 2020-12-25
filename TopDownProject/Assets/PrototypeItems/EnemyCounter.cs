using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
    void Update()
    {
        var enemies = FindObjectsOfType<TurnTowardsPlayer>().Length;
        GetComponent<Text>().text = $"Enemies Left: <color=yellow>{enemies}</color>";       
    }
}

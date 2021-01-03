using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitchingHandler : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> weapons = new List<GameObject>();
    private int currentMouseIndex;

    private MinMax<int> weaponIndexRange => new MinMax<int>() { min = 0, max = weapons.Count - 1 }; 
    // Update is called once per frame
    private void Update()
    {
        currentMouseIndex += Mathf.RoundToInt(Input.mouseScrollDelta.y);
        if (currentMouseIndex > weaponIndexRange.max)
        {
            currentMouseIndex = weaponIndexRange.min;
        }
        else if (currentMouseIndex < weaponIndexRange.min)
        {
            currentMouseIndex = weaponIndexRange.max;
        }

        print(currentMouseIndex);
        ActivateExceptIndex(currentMouseIndex);
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    ActivateExcept(0);
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    ActivateExcept(1);
        //}

    }

    private void ActivateExceptIndex(int index)
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].SetActive(i == index);
        }
    }
}

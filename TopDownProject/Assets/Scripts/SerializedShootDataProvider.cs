using UnityEngine;

public class SerializedShootDataProvider : ShootingDataProvider
{
    [SerializeField]
    private ShootingData data;

    // Update is called once per frame
    private void Update()
    {
        Data = data;
    }

}

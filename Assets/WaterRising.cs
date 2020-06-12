using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRising : MonoBehaviour
{
    public float risingSpeed = 0.005f;

    // Update is called once per frame
    void Update()
    {
        var currentPosition = transform.position;

        var newWaterPositionY = currentPosition.y + risingSpeed;

        Vector3 newWaterPosition = new Vector3(currentPosition.x, newWaterPositionY, currentPosition.z);
        transform.position = newWaterPosition;
    }
}

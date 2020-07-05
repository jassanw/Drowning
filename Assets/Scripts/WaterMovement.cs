using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour
{
    WaterSpeed Speed;
    public float waterMovement;

    void Start()
    {
        Speed = new WaterSpeed();

        waterMovement = Speed.rise;
    }

    // Update is called once per frame
    void Update()
    {
        var currentPosition = transform.position;

        var newWaterPositionY = currentPosition.y + waterMovement;

        Vector3 newWaterPosition = new Vector3(currentPosition.x, newWaterPositionY, currentPosition.z);
        transform.position = newWaterPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.enabled = false;
        waterMovement = Speed.stop;
        StartCoroutine(Delay(2f));
    }

    private IEnumerator Delay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Time.timeScale = 0f;

    }

}

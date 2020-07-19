using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour
{
    private const float stop = 0f;
    public float rise = 1.5f;
    private float waterMovement;

    void Start()
    {
        waterMovement = rise;
    }

    // Update is called once per frame
    void Update()
    {
        var currentPosition = transform.position;

        var newWaterPositionY = currentPosition.y + (waterMovement * Time.deltaTime);

        Vector3 newWaterPosition = new Vector3(currentPosition.x, newWaterPositionY, currentPosition.z);
        transform.position = newWaterPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.enabled = false;
        StopWaterMovement();
        StartCoroutine(Delay(2f));
    }

    private IEnumerator Delay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Time.timeScale = 0f;

    }

    public void StopWaterMovement()
    {
        waterMovement = stop;
    }

    public void StartWaterMovement()
    {
        waterMovement = rise;
    }

    public void ChangeWaterSpeed(float newSpeed)
    {
        rise = newSpeed;
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour
{
    [SerializeField] EndGameScreen endGameController;
    [SerializeField] Player playerGO;
    [SerializeField] ScoreSystem scoreSystem;
 
    private const float stop = 0f;
    public float defaultRisingSpeed = 1.5f;
    private float waterMovement;
    private int previousScore = 0;

    void Start()
    {
        waterMovement = defaultRisingSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        var playerPosition = playerGO.GetPosition();
        var currentWaterPosition = transform.position;

        IncreaseWaterSpeed(scoreSystem.GetScore());

        if (playerPosition.y - currentWaterPosition.y > 11) {
            Vector3 desiredPosition = new Vector3(currentWaterPosition.x, playerPosition.y - 11);
            currentWaterPosition = Vector3.Lerp(currentWaterPosition, desiredPosition, 1.2f * Time.deltaTime);
        }

        var newWaterPositionY = currentWaterPosition.y + (waterMovement * Time.deltaTime);

        Vector3 newWaterPosition = new Vector3(currentWaterPosition.x, newWaterPositionY);
        transform.position = newWaterPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Events.PlayerDied.Invoke();
    }

   

    public void StopWaterMovement()
    {
        waterMovement = stop;
    }

    public void StartWaterMovement()
    {
        waterMovement = defaultRisingSpeed;
    }

    public void ChangeWaterSpeed(float newSpeed)
    {
        waterMovement = newSpeed;
    }

    public void IncreaseWaterSpeed(int score) {
        if (previousScore < score) {
            if (score != 0 && score % 10 == 0) {
                ChangeWaterSpeed(waterMovement * 1.02f);
                previousScore = score;
            }
        }
    }

   
}

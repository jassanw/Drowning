﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movementSpeed = 10f;
    public float tiltMultiplier = 3f;

    public Rigidbody2D playerRigidBody;
    float movement = 0.0f;
    float direction;


    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal") * movementSpeed;
        if (Input.acceleration.x != 0) {
            movement = Input.acceleration.x * movementSpeed * tiltMultiplier;
        }
        
        if (movement > 1 || movement < -1) {
            direction = movement / Math.Abs(movement);
            playerRigidBody.transform.localScale = new Vector3(
                direction * Math.Abs(playerRigidBody.transform.localScale.x), 
                playerRigidBody.transform.localScale.y, 
                0
            );
        }
    }

    private void FixedUpdate()
    {
        Vector2 velocity = playerRigidBody.velocity;
        velocity.x = movement;
        playerRigidBody.velocity = velocity;
    }

    public Vector3 GetPosition(){
        return transform.position;
    }

    public void DeactivatePlayer() {
        gameObject.SetActive(false);
    }
}

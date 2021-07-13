using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float tiltMultiplier = 3f;
    public float jumpForce = 10f;
    
    public Rigidbody2D playerRigidBody;
    float movement = 0.0f;
    float direction;
    bool _isSlowingDown;
    bool _playerFrozen = false;


    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
            movement = Input.GetAxis("Horizontal") * movementSpeed;
            if (Input.acceleration.x != 0)
            {
                movement = Input.acceleration.x * movementSpeed * tiltMultiplier;
            }

            if (movement > 1 || movement < -1)
            {
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
        if (_isSlowingDown)
        {
            playerRigidBody.velocity = playerRigidBody.velocity * 0.98f * Time.fixedDeltaTime;
        }
    }

    public Vector3 GetPosition(){
        return transform.position;
    }

    public void SetMovementSpeed(float movementSpeed)
    {
        this.movementSpeed = movementSpeed;
    }

    public void DeactivatePlayer() {
        gameObject.SetActive(false);
    }

    public void ResetPlayer()
    {
        movementSpeed = 10f;
        jumpForce = 10f;
        playerRigidBody.gravityScale = 1;
        playerRigidBody.mass = 1;
        _isSlowingDown = false;
        playerRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void SetPlayerFrozen(bool frozen)
    {
        _playerFrozen = frozen;
    }

    public void OnPlatformJump()
    {
        Vector2 velocity = playerRigidBody.velocity;
        velocity.y = jumpForce;
        playerRigidBody.velocity = velocity;
    }



}

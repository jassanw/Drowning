using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float jumpForce = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0.0f)
        {
            Rigidbody2D playerRB = collision.collider.GetComponent<Rigidbody2D>();

            if (playerRB)
            {
                Vector2 velocity = playerRB.velocity;
                velocity.y = jumpForce;
                playerRB.velocity = velocity;

            }
        }
    }


}

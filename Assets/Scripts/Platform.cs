using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float jumpForce = 10f;
    public Transform itemPosition;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0.0f)
        {
            Player player = collision.collider.GetComponent<Player>();
            if (player != null)
            {
                player.OnPlatformJump();
            }
        }
    }


}

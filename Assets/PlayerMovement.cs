using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D playerRigidBody;

    [SerializeField]
    float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hi");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D platformCollider)
    {

        GameObject colliderGameObject = platformCollider.gameObject;
        float platformY = colliderGameObject.transform.position.y;
        float playerY = this.gameObject.transform.position.y;

        float difference = playerY - platformY;

        if (difference > 0.463)
        {
            Debug.Log("test");
            playerRigidBody.AddForce(new Vector3(0, jumpForce, 0), ForceMode2D.Impulse);

        }
        else
        {
            Physics2D.IgnoreCollision(colliderGameObject.GetComponent<Collider2D>(), this.gameObject.GetComponent<Collider2D>(), true);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform playerTransform;

    public float smoothSpeed = 0.2f;
    void LateUpdate()
    {
        if (playerTransform.position.y > transform.position.y)
        {
            Vector3 desiredPosition = new Vector3(transform.position.x, playerTransform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

            // transform.LookAt(playerTransform);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    [SerializeField] EdgeCollider2D edgeCollider;
    public static event Action HalfWayEdge;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        edgeCollider.enabled = false;
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            HalfWayEdge?.Invoke();
        }
    }
}


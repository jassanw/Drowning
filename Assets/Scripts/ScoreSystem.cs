using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public GameObject player;

    public GameObject firstPlatform;

    private float platformHeight;

    private float playerHeight;

    public int maxHeight = 0;

    // Start is called before the first frame update
    void Start()
    {
        platformHeight = firstPlatform.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        playerHeight = player.transform.position.y;

        int height =  Convert.ToInt32(playerHeight - platformHeight);

        if (maxHeight < height) {
            maxHeight = height;
        } 

    }
}

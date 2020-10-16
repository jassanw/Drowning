using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickGenerator : MonoBehaviour
{

    public float minYHeight = 0.4f;
    public float maxYHeight = 10.0f;
    public GameObject brick;
    public GameObject intialBrick;
    public GameObject player;
    public GameObject BrickContainer;


    private float currentMaxBrickHeight;
    private float maxXWidth = 2f;
    private float minXWidth = -2f;
    private Vector3 spawnPosition;
    private GameObject newBrick;



    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = intialBrick.transform.position;
        generateBricks();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentMaxBrickHeight - player.transform.position.y < 20)
        {
            generateBricks();
        }
    }

    private void generateBricks()
    {
        for (int i = 0; i < 30; i++)
        {
            spawnPosition.y += Random.Range(minYHeight, maxYHeight);
            spawnPosition.x = Random.Range(minXWidth, maxXWidth);
            newBrick = Instantiate(brick, spawnPosition, Quaternion.identity);
            newBrick.transform.parent = BrickContainer.transform;
            if (i == 29)
            {
                currentMaxBrickHeight = spawnPosition.y;
            }
        }

    }
}

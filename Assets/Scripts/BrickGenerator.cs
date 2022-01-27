using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickGenerator : MonoBehaviour
{
    public float minYHeight = 0.4f;
    public float maxYHeight = 10.0f;
    private float maxXWidth = 2f;
    private float minXWidth = -2f;

    public  List<GameObject> bricks;
    public GameObject intialBrick;
    public GameObject player;
    public GameObject BrickContainer;

    private float currentMaxBrickHeight;
    private Vector3 spawnPosition;
    private GameObject newBrick;

    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = intialBrick.transform.position;
        GenerateBricks();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentMaxBrickHeight - player.transform.position.y < 10)
        {
            GenerateBricks();
        }
    }

    private void GenerateBricks()
    {
        for (int i = 0; i < 30; i++)
        {
            spawnPosition.y += Random.Range(minYHeight, maxYHeight);
            spawnPosition.x = Random.Range(minXWidth, maxXWidth);

            newBrick = Instantiate(
                bricks[Random.Range(0, bricks.Count)], 
                spawnPosition, 
                Quaternion.Euler(0, Rotation(), 0)
            );
            newBrick.transform.parent = BrickContainer.transform;

            if (i == 29)
            {
                currentMaxBrickHeight = spawnPosition.y;
            }
        }
    }

    private int Rotation() 
    {
        var rotation = 0;
        if (Random.value < 0.5f) 
        {
            rotation = 180;
        }    

        return rotation;
    }
}

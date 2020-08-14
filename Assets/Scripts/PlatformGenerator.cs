using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    public float minYHeight = 0.4f;
    public float maxYHeight = 3.0f;
    public GameObject platform;
    public GameObject intialPlatform;
    public GameObject player;
    public GameObject platformContainer;


    private float currentMaxPlatformHeight;
    private float maxXWidth = 2f;
    private float minXWidth = -2f;
    private Vector3 spawnPosition;
    private GameObject newPlatform;



    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = intialPlatform.transform.position;
        generatePlatforms();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentMaxPlatformHeight - player.transform.position.y < 20)
        {
            generatePlatforms();
        }
    }

    private void generatePlatforms()
    {
        for (int i = 0; i < 20; i++)
        {
            spawnPosition.y += Random.Range(minYHeight, maxYHeight);
            spawnPosition.x = Random.Range(minXWidth, maxXWidth);
            newPlatform = Instantiate(platform, spawnPosition, Quaternion.identity);
            newPlatform.transform.parent = platformContainer.transform;
            if (i == 19)
            {
                currentMaxPlatformHeight = spawnPosition.y;
            }
        }

    }
}

using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem: MonoBehaviour
{
    public GameObject player;
    public GameObject firstPlatform;

    private float platformHeight;
    private float playerHeight;

    private int maxHeight;

   
    // Start is called before the first frame update
    void Start()
    {
        maxHeight = 0;
        platformHeight = firstPlatform.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        playerHeight = player.transform.position.y;

        int height =  Convert.ToInt32(playerHeight - platformHeight);

        if (maxHeight < height) {
            maxHeight = height;
            Events.PlayerScoreUpdate.Invoke(maxHeight);
        }
    }

    public int GetScore() {
        return maxHeight;
    }

}

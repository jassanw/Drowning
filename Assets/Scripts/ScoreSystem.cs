using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public GameObject scoreObject;

    public GameObject finalScoreObject;
    public GameObject player;

    public GameObject firstPlatform;

    private float platformHeight;

    private float playerHeight;

    public int maxHeight = 0;

    private TMP_Text mainScoreText;

    private Text finalScoreText;

    // Start is called before the first frame update
    void Start()
    {
        platformHeight = firstPlatform.transform.position.y;
        mainScoreText = scoreObject.GetComponent<TMP_Text>();
        finalScoreText = finalScoreObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHeight = player.transform.position.y;

        int height =  Convert.ToInt32(playerHeight - platformHeight);

        if (maxHeight < height) {
            maxHeight = height;
        }

        mainScoreText.text = maxHeight.ToString();
        finalScoreText.text = mainScoreText.text;
    }

    public int GetScore() {
        return maxHeight;
    }

}

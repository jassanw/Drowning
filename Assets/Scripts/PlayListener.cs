using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayListener : MonoBehaviour
{
#pragma warning disable CS0649
    [SerializeField] Button PlayButton;
    [SerializeField] WaterMovement Water;
#pragma warning restore CS0649
    void Start()
    {
        PlayButton.onClick.AddListener(PlayGame);
    }
 
    public void PlayGame()
    {
        Water.StartWaterMovement();
        Time.timeScale = 1;
        PlayButton.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

    }
}

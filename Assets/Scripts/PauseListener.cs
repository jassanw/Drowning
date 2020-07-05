using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseListener : MonoBehaviour
{
    [SerializeField] Button PauseButton;
    [SerializeField] WaterMovement Water;
    private bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        PauseButton.onClick.AddListener(() => pauseGame());
    }
    public void pauseGame()
    {
        if (isPaused)
        {
            Water.risingSpeed = 0f;
            PauseButton.gameObject.SetActive(false);
            Time.timeScale = 1;
            isPaused = true;
        }
        else
        {
            Water.risingSpeed = 0.015f;
            PauseButton.gameObject.SetActive(false);
            Time.timeScale = 0;
            isPaused = false;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}

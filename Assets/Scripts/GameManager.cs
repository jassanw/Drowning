using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] WaterMovement water;
    // Start is called before the first frame update

    private void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Events.PauseButtonClicked.AddListener(OnPauseButtonClick);
        Events.ResumeButtonClicked.AddListener(OnResumeButtonClick);
        Events.ReplayButtonClicked.AddListener(RestartGame);
        Events.MenuButtonClicked.AddListener(OnMenuButtonClick);
        Events.PlayerDied.AddListener(OnPlayerDied);
    }
 
    private void OnDestroy()
    {
        Events.PauseButtonClicked.RemoveListener(OnPauseButtonClick);
        Events.ResumeButtonClicked.RemoveListener(OnResumeButtonClick);
        Events.ReplayButtonClicked.RemoveListener(RestartGame);
        Events.MenuButtonClicked.RemoveListener(OnMenuButtonClick);
        Events.PlayerDied.RemoveListener(OnPlayerDied);
    }


    private void OnPauseButtonClick()
    {
        water.StopWaterMovement();
        Time.timeScale = 0;
    }

    private void OnPlayerDied()
    {
        water.StopWaterMovement();
        if (player.GetScore() > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", player.GetScore());
        }
        player.OnPlayerDied();
    }

    private void OnResumeButtonClick()
    {
        water.StartWaterMovement();
        Time.timeScale = 1;
    }

    private void OnMenuButtonClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

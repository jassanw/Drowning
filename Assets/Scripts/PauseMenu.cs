using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
#pragma warning disable CS0649
    [SerializeField] WaterMovement Water;
    [SerializeField] Button ResumeButton;
    [SerializeField] Button PauseButton;
    [SerializeField] Button MenuButton;
    [SerializeField] Button ReplayButton;
    [SerializeField] GameObject Score;
#pragma warning restore CS0649



    public static event Action ResumeButtonClick;

    // Start is called before the first frame update
    void Start()
    {
        ResumeButton.onClick.AddListener(() => Events.ResumeButtonClicked.Invoke());
        MenuButton.onClick.AddListener(() => Events.MenuButtonClicked.Invoke());
        ReplayButton.onClick.AddListener(() => Events.ReplayButtonClicked.Invoke());
       
        ResumeButton.onClick.AddListener(PlayGame);
        MenuButton.onClick.AddListener(() => {
            PlayGame();
            SceneManager.LoadScene("MainMenu");
        });
        ReplayButton.onClick.AddListener(() => {
            PlayGame();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
    }

    void OnDestroy()
    {
        ResumeButton.onClick.RemoveAllListeners();
        MenuButton.onClick.RemoveAllListeners();
        ReplayButton.onClick.RemoveAllListeners();
    }

    public void PauseGame()
    {
        Water.StopWaterMovement();
        Time.timeScale = 0;
    }

    public void PlayGame()
    {
        Score.SetActive(true);
        Water.StartWaterMovement();
        Time.timeScale = 1;
        DisablePauseMenu();
        PauseButton.gameObject.SetActive(true);

    }
    public void EnablePauseMenu()
    {
        gameObject.SetActive(true);
    }

    public void DisablePauseMenu()
    {
        gameObject.SetActive(false);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] PauseMenu pauseMenu;
    [SerializeField] PlayingUI playingUI;
    [SerializeField] EndGameScreen endGameMenu;
    [SerializeField] Player player;

    private void Awake()
    {
        Events.PauseButtonClicked.AddListener(OnPauseMenuClick);
        Events.ResumeButtonClicked.AddListener(OnResumeGameClick);
        Events.PlayerScoreUpdate.AddListener(UpdateScoreText);
        Events.PlayerDied.AddListener(EnableGameEndScreen);
    }

    void OnDestroy()
    {
        Events.PauseButtonClicked.RemoveListener(OnPauseMenuClick);
        Events.ResumeButtonClicked.RemoveListener(OnResumeGameClick);
        Events.PlayerScoreUpdate.RemoveListenr(UpdateScoreText);
        Events.PlayerDied.RemoveListener(EnableGameEndScreen);
   
    }

    private void OnPauseMenuClick()
    {
        playingUI.HidePauseButton();
        pauseMenu.EnablePauseMenu();
    }

    private void OnResumeGameClick()
    {
        pauseMenu.DisablePauseMenu();
        playingUI.EnablePlayingUI();
    }

    private void EnableGameEndScreen()
    {
        playingUI.DisablePlayingUI();
        endGameMenu.SetScoreValues(player.GetScore().ToString(), PlayerPrefs.GetInt("HighScore", 0).ToString());
        endGameMenu.EnableEndGameScreen();
    }

    public void UpdateScoreText(int score)
    {
        playingUI.SetScoreText(score.ToString());
    }


}

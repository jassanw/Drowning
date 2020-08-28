using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
#pragma warning disable CS0649
    [SerializeField] WaterMovement Water;
    [SerializeField] Button PlayButton;
    [SerializeField] Button PauseButton;
    [SerializeField] Button MenuButton;
    [SerializeField] Button ReplayButton;
    [SerializeField] GameObject Score;
#pragma warning restore CS0649

    // Start is called before the first frame update
    void Start()
    {
        PlayButton.onClick.AddListener(PlayGame);
        MenuButton.onClick.AddListener(() => {
            PlayGame();
            SceneManager.LoadScene("MainMenu");
        });
        ReplayButton.onClick.AddListener(() => {
            PlayGame();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
    }

    public void PauseGame()
    {
        Score.SetActive(false);
        Water.StopWaterMovement();
        Time.timeScale = 0;
        EnablePauseMenu();
        PauseButton.gameObject.SetActive(false);
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

    private void DisablePauseMenu()
    {
        gameObject.SetActive(false);
    }
}

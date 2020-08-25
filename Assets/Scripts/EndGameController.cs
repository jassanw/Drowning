using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameController : MonoBehaviour
{
    public Button menuButton;
    public Button replayButton;
    public Button pauseButton;
    public GameObject score;

    // Start is called before the first frame update
    void Start()
    {
        menuButton.onClick.AddListener(() => SceneManager.LoadScene("MainMenu"));
        replayButton.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex));
    }

    public void EnableEndGameScreen()
    {
        gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        score.SetActive(false);
    }
}

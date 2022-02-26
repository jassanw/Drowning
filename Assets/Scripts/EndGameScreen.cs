using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameScreen : MonoBehaviour
{
    public Button menuButton;
    public Button replayButton;
    
    public TextMeshProUGUI score;
    public TextMeshProUGUI highscore;

    // Start is called before the first frame update
    void Start()
    {

        menuButton.onClick.AddListener(() => Events.MenuButtonClicked.Invoke());
        replayButton.onClick.AddListener(() => Events.ReplayButtonClicked.Invoke());
    }
    void OnDestroy()
    {
        menuButton.onClick.RemoveAllListeners();
        replayButton.onClick.RemoveAllListeners();
    }

    public void SetScoreValues(string score, string highscore)
    {
        this.score.text = score;
        this.highscore.text = highscore;
    }

    public void EnableEndGameScreen()
    {
        gameObject.SetActive(true);
    }

    public void DisableGameEndScreen()
    {
        gameObject.SetActive(false);
    }
}

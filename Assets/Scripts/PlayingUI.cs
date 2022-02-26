using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayingUI : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI currentScoreText;
    [SerializeField] Button pauseButton;
   
    // Start is called before the first frame update
    void Start()
    {
        currentScoreText.text = 0.ToString();
        pauseButton.onClick.AddListener(() => Events.PauseButtonClicked.Invoke());
    }

    void OnDestroy()
    {
        pauseButton.onClick.RemoveAllListeners();    
    }


    public void SetScoreText(string scoreText)
    {
        currentScoreText.text = scoreText;
    }

    public void HidePauseButton()
    {
        pauseButton.gameObject.SetActive(false);
    }
    
    public void DisablePlayingUI()
    {
        gameObject.SetActive(false);
    }

    public void EnablePlayingUI()
    {
        currentScoreText.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(true);
        gameObject.SetActive(true);
    }
}

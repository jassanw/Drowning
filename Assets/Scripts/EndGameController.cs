using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameController : MonoBehaviour
{
    [SerializeField] Button menuButton;
    [SerializeField] Button replayButton;


    // Start is called before the first frame update
    void Start()
    {
        menuButton.onClick.AddListener(() => SceneManager.LoadScene("MainMenu"));
        replayButton.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableEndGameScreen()
    {
        gameObject.SetActive(true);
    }
}

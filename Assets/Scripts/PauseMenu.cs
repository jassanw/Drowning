using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
#pragma warning disable CS0649
    [SerializeField] WaterMovement Water;
    [SerializeField] Button PlayButton;
    [SerializeField] Button PauseButton;
#pragma warning restore CS0649

    // Start is called before the first frame update
    void Start()
    {
        PlayButton.onClick.AddListener(PlayGame);
    }

    public void PlayGame()
    {
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButtonController : MonoBehaviour
{
    [SerializeField] PauseMenu PauseMenu;
    [SerializeField] Button PauseButton;
    [SerializeField] WaterMovement Water;

    void Start()
    {
        PauseButton.onClick.AddListener(PauseGame);
    }
    public void PauseGame()
    {
        Water.StopWaterMovement();
        Time.timeScale = 0;
        PauseButton.gameObject.SetActive(false);
        PauseMenu.EnablePauseMenu();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Events
{
    #region Button Events
    public static readonly Event PauseButtonClicked = new Event();
    public static readonly Event ReplayButtonClicked = new Event();
    public static readonly Event MenuButtonClicked = new Event();
    public static readonly Event ResumeButtonClicked = new Event();
    #endregion


    public static readonly Event<int> PlayerScoreUpdate = new Event<int>();
    public static readonly Event PlayerDied = new Event();

}

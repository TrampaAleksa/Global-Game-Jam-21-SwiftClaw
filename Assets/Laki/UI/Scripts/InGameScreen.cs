using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameScreen : UIScreen
{
    public enum SubScreenState
    {
        tutorial,
        inGame,
        tryAgain,
        congrats,
        pause
    }

    public bool isPaused;
    public UIScreen currentSubSreen;
    public SubScreenState screenIndex;
    public List<UIScreen> screens;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(currentSubSreen==screens[(int)SubScreenState.inGame] || currentSubSreen==screens[(int)SubScreenState.pause])
            {
                if(isPaused)
                {
                    UnPause();
                }
                else
                {
                    Pause();
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.T))
        {
            ChangeSubScreen(3);
        }
    }
    public void Pause()
    {
        Time.timeScale = 0;
        ChangeSubScreen((int)SubScreenState.pause);
        isPaused = true;
    }
    public void UnPause()
    {
        Time.timeScale = 1;
        ChangeSubScreen((int)SubScreenState.inGame);
        isPaused = false;
    }

    public void ChangeSubScreen(int index)
    {
        if (currentSubSreen != null)
            currentSubSreen.TurnOffScreen();
        var ind = (int)index;
        screens[ind].gameObject.SetActive(true);
        screens[ind].TurnOnScreen();
        currentSubSreen = screens[ind];
        screenIndex = (SubScreenState)ind;
    }
    public override void TurnOnScreen()
    {
        foreach (var screen in screens)
            screen.gameObject.SetActive(false);
        ChangeSubScreen((int)SubScreenState.tutorial);
    }
    public override void TurnOffScreen()
    {
        base.TurnOffScreen();
        currentSubSreen.TurnOffScreen();
        UnPause();
    }
}
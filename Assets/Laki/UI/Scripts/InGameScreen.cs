using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameScreen : UIScreen
{
    public enum ListOfSubScreens
    {
        tutorial,
        inGame,
        tryAgain,
        congrats,
        pause
    }
    public UIScreen currentSubSreen;
    public ListOfSubScreens screenIndex;
    List<UIScreen> screens = new List<UIScreen>();
    private void Start()
    {
        var scr= gameObject.GetComponentsInChildren<UIScreen>();
        foreach(var screen in scr)
        {
            screens.Add(screen);
        }
    }
    public void ChangeSubScreen(ListOfSubScreens index)
    {
        if (currentSubSreen != null)
            currentSubSreen.TurnOffScreen();
        var ind = (int)index;
        screens[ind].gameObject.SetActive(true);
        screens[ind].TurnOnScreen();
        currentSubSreen = screens[ind];
    }
    public override void TurnOnScreen()
    {
        ChangeSubScreen(ListOfSubScreens.tutorial);
    }
    public override void TurnOffScreen()
    {
        base.TurnOffScreen();
        currentSubSreen.TurnOffScreen();
    }
}

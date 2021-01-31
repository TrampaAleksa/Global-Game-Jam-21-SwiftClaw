using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratsScreen : UIScreen
{
    public override void TurnOnScreen()
    {
        base.TurnOnScreen();
        Time.timeScale = 0;
    }
    public override void TurnOffScreen()
    {
        base.TurnOffScreen();
        Time.timeScale = 1;
    }
}
